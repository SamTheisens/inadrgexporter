using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using INADRGExporter.Properties;
using INADRGExporter;

namespace INADRGExporter
{
    public class ToGrouperWriter: IDisposable
    {
        private static string outputBuffer = "";
        private SqlConnection connection;
        private SqlDataReader reader;
        private StreamWriter writer;
        private List<Tuple> dictionary;
        
        public ToGrouperWriter(DateTime from, DateTime until, string kdCustomer)
        {
            writer = new StreamWriter(@"C:\togrouper.txt", false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_in.dic");

            var queryString = string.Format("exec dbo.RSUD_GET_INADRG '{0}', '{1}', '{2}'", from.ToUniversalTime(),
                                            until.ToUniversalTime(), kdCustomer);


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

        private static void WriteAsLine(object[] values, List<Tuple> dictionary, StreamWriter writer)
        {
            int nocolumn = 0;
            for (int i = 0; i < dictionary.Count && nocolumn < values.Length; i++)
            {
                for (int j = 0; j < dictionary[i].repeat; j++)
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
                output = tgl.ToString("dd/MM/yyyy");
            }
            else
            {
                output = col.ToString();
            }
            outputBuffer += output.PadRight(digits);
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