using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using INADRGExporter.Properties;
using Microsoft.VisualBasic.FileIO;

namespace INADRGExporter
{
    public class FromGrouperReader : IDisposable
    {
        private struct Tarif
        {
            public string Deskripsi;
            public double Alos;
            public double Harga;
        }

        private readonly StreamReader reader;
        private readonly StreamWriter writer;
        private readonly List<Tuple> dictionary;
        private readonly Dictionary<string, Tarif> tarifJamkesmas;
        private readonly TextFieldParser parser;
        private readonly SqlConnection connection;

        private readonly List<object> rows = new List<object>();
        private SqlDataReader dataReader;
        private int currentRow;
        private static int currentReadRow;
        private static string insertBuffer = "";
        private readonly List<Map> excelColumns;
        private readonly Dictionary<string,string> errorCodes;

        public FromGrouperReader(string inputFile, string outputFile)
        {
            reader = new StreamReader(inputFile, true);
            writer = new StreamWriter(outputFile, false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_out.dic");
            excelColumns = GrouperHelper.ReadMapping("dic_excel_mapping.dic");
            errorCodes = GrouperHelper.ReadErrorCodes("errorcodes.dic");
            tarifJamkesmas = readTarifJamkesmas();
            parser = CreateTextFieldParser();
            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();
            var cmd = new SqlCommand("create table #DRG (urut INT, rm VARCHAR(6), tglMasuk DATETIME)", connection);
            cmd.ExecuteNonQuery();
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
            if (parser.EndOfData)
                return false;

            var fields = new List<string>(parser.ReadFields());
            string drg;
            string rm;
            DateTime tglMasuk;
            List<object> outputColumns;
            ParseLine(fields, dictionary, excelColumns.Where(col => col.dicColumn != string.Empty).ToList(), out outputColumns, out drg, out rm, out tglMasuk);
            AddTarif(outputColumns, drg, tarifJamkesmas);
            InsertIntoTempTable(rm, tglMasuk);
            rows.Add(outputColumns);

            return true;
        }
        public bool endOfData()
        {
            return parser.EndOfData;
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

            var fields = rows[currentRow] as List<object>;

            fields.Add(dataReader["Nama"].ToString());
            fields.Add(dataReader["Dokter"].ToString());
            fields.Add(dataReader["SKP"].ToString());
            WriteAsLine(fields, writer);
            currentRow++;
            return true;
        }

        private TextFieldParser CreateTextFieldParser()
        {
            var parser = new TextFieldParser(reader) {TextFieldType = FieldType.FixedWidth};

            var widths = new List<int>();
            foreach (var tuple in dictionary)
            {
                for(int i = 0; i < tuple.repeat; i++)
                    widths.Add(tuple.characters);
            }
            parser.SetFieldWidths(widths.ToArray());
            return parser;
        }

        private void AddTarif(ICollection<object> outputColumns, string drg, IDictionary<string, Tarif> tarifJamkesmas)
        {
            Tarif tarif;
            if (tarifJamkesmas.TryGetValue(drg, out tarif))
            {
                outputColumns.Add(tarif.Harga.ToString());
                outputColumns.Add(tarif.Deskripsi);
                outputColumns.Add(tarif.Alos.ToString());
            }
            else
            {
                outputColumns.Add(string.Empty);
                if (errorCodes.ContainsKey(drg)) outputColumns.Add(errorCodes[drg]);
                outputColumns.Add(string.Empty);
            }
        }

        private static void ParseLine(IList<string> fields, IEnumerable<Tuple> dictionary, List<Map> excelColumns, out List<object> outputColumns, out string drg, out string rm, out DateTime tglMasuk)
        {
            outputColumns = new List<object>();
            if (fields == null) throw new ArgumentNullException("fields");
            foreach (var map in excelColumns)
            {
                var tuple = getTuple(dictionary, map.dicColumn);
                var cell = fields[tuple.number + map.columnNumber - 1];
                outputColumns.Add(cell);
            }

            rm = fields[getFieldIndex(dictionary, "VISIT_ID")];

            tglMasuk = DateTime.ParseExact(fields[getFieldIndex(dictionary, "IMP_ADM_DATE")], Settings.Default.DateFormat,
                                           CultureInfo.InvariantCulture);
            drg = fields[getFieldIndex(dictionary, "DRG")];
        }

        private static Tuple getTuple(IEnumerable<Tuple> dictionary, string tupleName)
        {
            return dictionary.Single(t => t.name == tupleName);
        }


        private static int getFieldIndex(IEnumerable<Tuple> dictionary, string tupleName)
        {
            return dictionary.Single(t => t.name == tupleName).number;
        }

        private static void InsertIntoTempTable(string rm, DateTime tglMasuk)
        {
            insertBuffer += string.Format("INSERT INTO #DRG VALUES ({0},'{1}','{2}');", currentReadRow, rm.Replace("\'", ""),
                                          GrouperHelper.ToSQLDate(tglMasuk));
            currentReadRow++;
        }

        public static void WriteAsLine(List<object> values, StreamWriter writer)
        {
            foreach (var s in values)
            {
                printColumn(s);
            }
            printNextLine(writer);
        }

        private static void printNextLine(TextWriter writer)
        {
            writer.WriteLine(outputBuffer);
            outputBuffer = "";
        }

        private static void printColumn(object col)
        {
            string output = col.ToString();
            outputBuffer += output + ";";
        }

        private static Dictionary<string, Tarif> readTarifJamkesmas()
        {
            var tarifJamkesmas = new Dictionary<string, Tarif>();

            if (!File.Exists(Path.Combine(Application.StartupPath, "tarif.dbf")))
                throw new FileNotFoundException(string.Format("tarif.dbf not found in {0}", Application.StartupPath ));
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
                        Tarif tarif;
                        tarif.Deskripsi = reader["DESKRIPSI"].ToString();
                        tarif.Alos = float.Parse(reader["ALOS"].ToString());
                        tarif.Harga =
                            float.Parse(reader[Settings.Default.RumahSakit[Settings.Default.TypeRumahSakit]].ToString());
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
            writer.WriteLine(String.Join(";", excelColumns.Select(c => c.excelColumn).ToArray()));
        }
    }
}