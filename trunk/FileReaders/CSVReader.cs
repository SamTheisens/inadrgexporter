using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace InadrgExporter.FileReaders
{
    public sealed class CSVReader : ITextFileFieldReader
    {
        private readonly long rows;
        private readonly CachedCsvReader reader;
        private readonly Dictionary<string, string> currentFields = new Dictionary<string, string>();
        private readonly List<FieldMapping> excelMapping;

        public CSVReader(string fileName)
        {
            reader = new CachedCsvReader(new StreamReader(fileName), true, ';');
            reader.ReadToEnd();
            rows = reader.CurrentRecordIndex;
            reader.MoveToStart();
            excelMapping = GrouperHelper.ReadMapping("dic_excel_mapping.dic");
        }

        public long Rows
        {
            get { return rows; }
        }

        public void MoveToRow(int rowNumber)
        {
            reader.MoveTo(rowNumber);
        }

        public string[] Headers
        {
            get { return reader.GetFieldHeaders(); }
        }

        public bool EndOfData
        {
            get { return reader.EndOfStream; }
        }

        public IEnumerator GetEnumerator()
        {
            return reader.GetEnumerator();
        }

        public bool MoveNext()
        {
            currentFields.Clear();
            return reader.ReadNextRecord();
        }

        public void Reset()
        {
            reader.MoveToStart();
        }

        public object Current
        {
            get
            {
                foreach (var map in excelMapping)
                {
                    var colName = map.ExcelColumn;
                    currentFields[colName] = Headers.Contains(colName) ? reader[colName] : string.Empty;
                }
                return currentFields;
            }
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
