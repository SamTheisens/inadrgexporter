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
    public static class FromGrouperReader
    {
        private struct Tarif
        {
            public string Deskripsi;
            public double Alos;
            public double Harga;
        }

        private static string outputBuffer = "";
        public static void readFromGrouper()
        {
            var dictionary = GrouperHelper.ReadDictionary("cgs_ina_out.dic");
            var reader = new StreamReader(@"C:\fromgrouper.txt", true);
            var tarifJamkesmas = readTarifJamkesmas();
            var parser = new TextFieldParser(reader) {TextFieldType = FieldType.FixedWidth};

            var widths = new List<int>();
            foreach (var tuple in dictionary)
            {
                for(int i = 0; i < tuple.repeat; i++)
                    widths.Add(tuple.characters);
            }
            parser.SetFieldWidths(widths.ToArray());

            var writer = new StreamWriter(@"C:\toexcel.txt", false);

            var toExcelDictionary = new List<Tuple>();
            using (var connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("create table #DRG (rm VARCHAR(6), tglMasuk DATETIME)", connection);
                cmd.ExecuteNonQuery();
                
                var rows = new List<object>();
                while (!parser.EndOfData)
                {
                    var fields = new List<string>(parser.ReadFields());
                    string drg;
                    string rm;
                    DateTime tglMasuk;
                    ParseLine(fields, dictionary, out toExcelDictionary, out drg, out rm, out tglMasuk);

                    AddTarif(fields, drg, tarifJamkesmas);

                    FetchPatientDetails(fields, rm, tglMasuk, connection);

                    rows.Add(fields);
                }

                const string queryDetails = "select ISNULL(p.NAMA, '') AS Nama, MAX(ISNULL(d.NAMA, '')) AS Dokter, MAX(ISNULL(p.NO_ASURANSI, '')) AS SKP " +
                                            "from #DRG AS drg INNER JOIN " +
                                            "dbo.PASIEN AS p ON ISNULL(RIGHT('000000' + REPLACE(p.KD_PASIEN, '-', ''), 6), '0') = drg.rm " +
                                            "LEFT OUTER JOIN dbo.KUNJUNGAN AS k ON ISNULL(RIGHT('000000' + REPLACE(p.KD_PASIEN, '-', ''), 6), '0') = drg.rm " +
                                            "AND drg.tglMasuk = k.TGL_MASUK INNER JOIN dbo.DOKTER AS d ON k.KD_DOKTER = d.KD_DOKTER ";

                var command = new SqlCommand(
                    queryDetails, connection);

                var sqlReader = command.ExecuteReader();

                try
                {
                    const int i = 0;
                    while (sqlReader.Read())
                    {
                        var fields = rows[i] as List<string>;
                        fields.Add(sqlReader["Nama"].ToString());
                        fields.Add(sqlReader["Dokter"].ToString());
                        fields.Add(sqlReader["SKP"].ToString());
                        WriteAsLine(fields, toExcelDictionary, writer);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
                writer.Flush();
                writer.Close();
            }
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

        private static void FetchPatientDetails(ICollection<string> fields, string rm, DateTime tglMasuk, SqlConnection connection)
        {
            var insertCommand =
                new SqlCommand(
                    string.Format("INSERT INTO #DRG VALUES ('{0}','{1}')", rm, tglMasuk.ToString("yyyy-MM-dd")),
                    connection);

            insertCommand.ExecuteNonQuery();

        }

        public static void WriteAsLine(List<string> values, List<Tuple> dictionary, StreamWriter writer)
        {
            foreach (var s in values)
            {
                printColumn(s, 1);
            }
            printNextLine(writer);
        }

        private static void printNextLine(TextWriter writer)
        {
            writer.WriteLine(outputBuffer);
            outputBuffer = "";
        }

        private static void printColumn(object col, int digits)
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
                OdbcDataReader reader = command.ExecuteReader();
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
    }
}
