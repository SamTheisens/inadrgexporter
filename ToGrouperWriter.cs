using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using INADRGExporter;
using INADRGExporter.Properties;

namespace INADRGExporter
{
    public class ToGrouperWriter: IDisposable
    {
        private static string outputBuffer = "";
        private readonly SqlConnection connection;
        private readonly SqlDataReader reader;
        private readonly StreamWriter writer;
        private readonly List<DicField> dictionary;

        public ToGrouperWriter(string outputFile, DateTime from, DateTime until, string kdCustomer)
        {
            writer = new StreamWriter(outputFile, false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_in.dic");

            var queryString = string.Format(SQLCodeService.Instance.InadrgQuery,
                                  GrouperHelper.ToSQLDate(from),
                                  GrouperHelper.ToSQLDate(until),
                                  kdCustomer,
                                  string.Format(SQLCodeService.Instance.SelectInadrgPredicate, ""),
                                  Settings.Default.NamaRumahSakit,
                                  Settings.Default.KodeRumahSakit,
                                  Settings.Default.TypeRumahSakit + 1);

            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            var command = new SqlCommand(queryString, connection);
            connection.Open();
            reader = command.ExecuteReader();
        }
        public bool NextLine()
        {
            if (!reader.Read())
                return false;
            var values = new object[reader.FieldCount];
            reader.GetValues(values);
            WriteAsLine(values, dictionary, writer);
            return true;
        }

        private static void WriteAsLine(object[] values, IList<DicField> dictionary, TextWriter writer)
        {
            var nocolumn = 0;
            for (var i = 0; i < dictionary.Count && nocolumn < values.Length; i++)
            {
                for (var j = 0; j < dictionary[i].repeat; j++)
                {
                    if (dictionary[i].filler)
                        printColumn("", dictionary[i].characters);
                    else
                    {
                        printColumn(values[nocolumn], dictionary[i].characters);
                        nocolumn++;
                    }
                }
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
            string output;
            if (col is DateTime)
            {
                var tgl = (DateTime)col;
                output = tgl.ToString(Settings.Default.DateFormat);
            }
            else
            {
                output = col.ToString();
            }
            outputBuffer += (output.PadRight(digits)).Substring(0,digits);
        }
        public void Dispose()
        {
            writer.Flush();
            writer.Close();
            reader.Close();
            connection.Close();
        }
    }
}