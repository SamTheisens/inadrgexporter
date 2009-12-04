using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using InadrgExporter.FileReaders;
using InadrgExporter.Properties;

namespace InadrgExporter
{
    public struct Tarif
    {
        public string Deskripsi { get; set; }
        public double Alos { get; set; }
        public double Harga { get; set; }
    }

    public class FromGrouperReader : IDisposable
    {
        private readonly StreamWriter writer;
        private readonly List<DictionaryField> dictionary;
        private readonly Dictionary<string, Tarif> tarifJamkesmas;
        private readonly ITextFileFieldReader fieldWidthReader;
        private readonly SqlConnection connection;

        private readonly List<object> rows = new List<object>();
        private SqlDataReader dataReader;
        private int currentRow;
        private static int currentReadRow;
        private static string insertBuffer = "";
        private readonly Dictionary<string,string> errorCodes;
        private readonly string[] headers;
        private Dictionary<string, string> rowSet = new Dictionary<string, string>();
        private bool endFile;

        public FromGrouperReader(string inputFile, string outputFile, bool verifikator)
        {
            writer = new StreamWriter(outputFile, false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_out.dic");
            fieldWidthReader = new FieldWidthReader(inputFile, dictionary);

            errorCodes = GrouperHelper.ReadErrorCodes("errorcodes.dic");
            headers = verifikator
                          ? GrouperHelper.ReadHeaderFile("header_excel_verifikator.txt")
                          : GrouperHelper.ReadHeaderFile("header_excel_dengan_nama.txt");
            tarifJamkesmas = readTarifJamkesmas();
            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();
            var cmd = new SqlCommand("create table #DRG (urut INT, rm INT, tglMasuk DATETIME)", connection);
            cmd.ExecuteNonQuery();
        }
        public long Length
        {
            get
            {
                return fieldWidthReader.Rows;
            }
        }

        private static string outputBuffer = "";
        public void clearTempDB()
        {
            dataReader.Close();
            var clearDB = new SqlCommand("delete from #DRG", connection);
            clearDB.ExecuteNonQuery();
        }
        public bool readNextLine()
        {
            endFile = !fieldWidthReader.MoveNext();
            if (endFile)
                return false;
            rowSet = (Dictionary<string, string>) fieldWidthReader.Current;
            AddTarif();
            InsertIntoTempTable(rowSet["Norm"], DateTime.ParseExact(rowSet["Tglmsk"], Settings.Default.DateFormat,
                                                                    CultureInfo.InvariantCulture, DateTimeStyles.None));
            rows.Add(rowSet);

            return true;
        }
        public bool endOfData()
        {
            return endFile;
        }
        public void executeQuery()
        {
            var insertCommand = new SqlCommand(insertBuffer, connection);
            insertCommand.ExecuteNonQuery();
            insertBuffer = string.Empty;
            currentReadRow = 0;

            var command = new SqlCommand(SQLCodeService.Instance.PatientDetailsQuery, connection);

            dataReader = command.ExecuteReader();
        }
        public bool writeLine()
        {
            if (!dataReader.Read())
                return false;

            var fields = rows[currentRow] as Dictionary<string, string>;
            fields["Nama"] = dataReader["Nama"].ToString();
            fields["Dokter"] = dataReader["Dokter"].ToString();
            fields["SKP"] = dataReader["SKP"].ToString();

            var row = new List<string>(); 
            foreach (var header in headers)
            {
                row.Add(fields[header]);
            }
            if (!string.IsNullOrEmpty(fields["Tarif"]))
                WriteAsLine(row.ToArray(), writer);
            currentRow++;
            return true;
        }

        private void AddTarif()
        {
            var inadrg = rowSet["Inadrg"];
            if (tarifJamkesmas.ContainsKey(inadrg))
            {
                rowSet["Tarif"] = String.Format("{0:0.##}", tarifJamkesmas[inadrg].Harga);
                rowSet["Deskripsi"] = tarifJamkesmas[inadrg].Deskripsi;
                rowSet["Alos"] = String.Format("{0:0.##}", tarifJamkesmas[inadrg].Alos);
            }
            else
            {
                rowSet["Tarif"] = string.Empty;
                if (errorCodes.ContainsKey(inadrg)) rowSet["Deskripsi"] = errorCodes[inadrg];
                rowSet["Alos"] = string.Empty;
            }
        }

        private static void InsertIntoTempTable(string rm, DateTime tglMasuk)
        {
            insertBuffer += string.Format(CultureInfo.InvariantCulture, "INSERT INTO #DRG VALUES ({0},{1},'{2}');", currentReadRow, rm.Replace("\'", ""),
                                          GrouperHelper.ToSQLDate(tglMasuk));
            currentReadRow++;
        }

        public static void WriteAsLine(string[] values, StreamWriter writer)
        {
            outputBuffer = string.Join(";", values) + ";";
            printNextLine(writer);
        }

        private static void printNextLine(TextWriter writer)
        {
            writer.WriteLine(outputBuffer);
            outputBuffer = "";
        }

        public static Dictionary<string, Tarif> readTarifJamkesmas()
        {
            var tarifJamkesmas = new Dictionary<string, Tarif>();

            if (!File.Exists(Path.Combine(Application.StartupPath, "tarif.dbf")))
                throw new FileNotFoundException(string.Format(CultureInfo.InvariantCulture, "tarif.dbf not found in {0}", Application.StartupPath));
            var connectionString = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" +
                                   Application.StartupPath;

            using (var connection = new OdbcConnection(connectionString))
            {
                var command = new OdbcCommand(
                    "Select * From tarif.dbf", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var tarif = new Tarif();
                        tarif.Deskripsi = reader["DESKRIPSI"].ToString();
                        tarif.Alos = ((double) reader["ALOS"]);
                        tarif.Harga = ((double)
                                       reader[Settings.Default.RumahSakit[Settings.Default.TypeRumahSakit]]);
                        tarifJamkesmas[reader["KODE"].ToString()] =  tarif;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return tarifJamkesmas;
        }

        public void Dispose()
        {
            dataReader.Close();
            writer.Flush();
            writer.Close();
            connection.Close();
        }

        public void writeHeaders()
        {
            writer.WriteLine(String.Join(";", headers) + ";");
        }
    }
}