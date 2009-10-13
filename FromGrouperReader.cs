using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
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

        public FromGrouperReader(string inputFile, string outputFile)
        {
            reader = new StreamReader(inputFile, true);
            writer = new StreamWriter(outputFile, false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_out.dic");
            tarifJamkesmas = readTarifJamkesmas();
            parser = CreateTextFieldParser();
            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();
            var cmd = new SqlCommand("create table #DRG (rm VARCHAR(6), tglMasuk DATETIME)", connection);
            cmd.ExecuteNonQuery();
        }

        private static string outputBuffer = "";
        public bool readNextLine()
        {
            if (parser.EndOfData)
                return false;

            List<Tuple> toExcelDictionary;
            var fields = new List<string>(parser.ReadFields());
            string drg;
            string rm;
            DateTime tglMasuk;
            ParseLine(fields, dictionary, out toExcelDictionary, out drg, out rm, out tglMasuk);

            AddTarif(fields, drg, tarifJamkesmas);

            InsertIntoTempTable(rm, tglMasuk, connection);

            rows.Add(fields);

            return true;
        }
        public void executeQuery()
        {
            const string queryDetails =
                "select rm, tglMasuk, p.Nama as Nama, p.NO_ASURANSI AS SKP, MAX(d.NAMA) AS Dokter " +
                "from #DRG AS drg LEFT OUTER JOIN dbo.KUNJUNGAN AS k " +
                "ON k.TGL_MASUK = drg.tglMasuk " +
                "AND RIGHT('000000' + REPLACE(k.KD_PASIEN, '-', ''), 6) = drg.rm " +
                "LEFT OUTER JOIN dbo.PASIEN AS p ON p.KD_PASIEN = k.KD_PASIEN " +
                "LEFT OUTER JOIN dbo.DOKTER AS d ON k.KD_DOKTER = d.KD_DOKTER " +
                "group by rm, tglMasuk, p.Nama, p.NO_ASURANSI";

            var command = new SqlCommand(
                queryDetails, connection);

            dataReader = command.ExecuteReader();
            
        }
        public bool writeLine()
        {
            if (!dataReader.Read())
                return false;

            var fields = rows[currentRow] as List<string>;
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

        private static void AddTarif(ICollection<string> fields, string drg, IDictionary<string, Tarif> tarifJamkesmas)
        {
            fields.Add(drg);
            var tarif = tarifJamkesmas[drg];
            fields.Add(tarif.Harga.ToString());
            fields.Add(tarif.Deskripsi);
            fields.Add(tarif.Alos.ToString());
        }

        private static void ParseLine(List<string> fields, IEnumerable<Tuple> dictionary, out List<Tuple> toExcelDictionary, out string drg, out string rm, out DateTime tglMasuk)
        {
            if (fields == null) throw new ArgumentNullException("fields");

            rm = fields[dictionary.AsQueryable().Single(t => t.name == "VISIT_ID").number];
            tglMasuk = DateTime.ParseExact(fields[dictionary.AsQueryable().Single(t => t.name == "IMP_ADM_DATE").number],
                                           "dd/MM/yyyy", CultureInfo.InvariantCulture);
            drg = fields[dictionary.AsQueryable().Single(t => t.name == "DRG").number];
            toExcelDictionary = GrouperHelper.ReadDictionary("cgs_ina_in.dic");
            int maxColumn = toExcelDictionary.Max(t => t.number);
            fields.RemoveRange(maxColumn, fields.Count - maxColumn);
        }

        private static void InsertIntoTempTable(string rm, DateTime tglMasuk, SqlConnection connection)
        {
            var insertCommand =
                new SqlCommand(
                    string.Format("INSERT INTO #DRG VALUES ('{0}','{1}')", rm, tglMasuk.ToString("yyyy-MM-dd")),
                    connection);

            insertCommand.ExecuteNonQuery();
        }

        public static void WriteAsLine(List<string> values, StreamWriter writer)
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

            var connectionString = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" +
                                   Directory.GetCurrentDirectory();

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
                        tarif.Harga = float.Parse(reader["B"].ToString());
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
    }
}
