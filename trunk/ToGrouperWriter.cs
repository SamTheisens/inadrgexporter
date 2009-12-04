using System;
using System.Collections.Generic;
using System.IO;
using InadrgExporter;
using InadrgExporter.Properties;

namespace InadrgExporter
{
    public class ToGrouperWriter: IDisposable
    {
        private static string outputBuffer = "";
        private readonly StreamWriter writer;
        private readonly List<DictionaryField> dictionary;
        private readonly DatabaseBindingSource bindingSource;
        private int currentRow;

        public ToGrouperWriter(string outputFile, DateTime from, DateTime until, string kdCustomer)
        {
            writer = new StreamWriter(outputFile, false);
            dictionary = GrouperHelper.ReadDictionary("cgs_ina_in.dic");
            bindingSource = new DatabaseBindingSource(new RSKUPANGDataSet.inadrgDataTable(), Int32.MaxValue, from,
                                                       until, kdCustomer);
            bindingSource.Start();

        }
        public long Length
        {
            get
            {
                return bindingSource.Length;
            }
        }
        public bool NextLine()
        {
            if (currentRow >= bindingSource.Table.Rows.Count)
                return false;
            var rowSet = bindingSource.Table.Rows[currentRow];
            currentRow++;
            WriteAsLine(rowSet.ItemArray, dictionary, writer);
            return true;
        }

        private static void WriteAsLine(object[] values, IList<DictionaryField> dictionary, TextWriter writer)
        {
            var nocolumn = 0;
            for (var i = 0; i < dictionary.Count && nocolumn < values.Length; i++)
            {
                for (var j = 0; j < dictionary[i].Repeat; j++)
                {
                    if (dictionary[i].Filler)
                        printColumn("", dictionary[i].Characters);
                    else
                    {
                        printColumn(values[nocolumn], dictionary[i].Characters);
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
        }
    }
}