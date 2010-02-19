using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace InadrgExporter.FileReaderCollections
{
    public sealed class CsvReaderCollection : ITextFileFieldReaderCollection
    {
        private readonly long rows;
        private bool disposed;
        private readonly CachedCsvReader reader;
        private readonly Dictionary<string, string> currentFields = new Dictionary<string, string>();
        private readonly Collection<FieldMapping> excelMapping;

        public CsvReaderCollection(string fileName, Collection<FieldMapping> excelMapping)
        {
            this.excelMapping = excelMapping;
            reader = new CachedCsvReader(new StreamReader(fileName), true, ';');
            reader.ReadToEnd();
            rows = reader.CurrentRecordIndex;
            reader.MoveToStart();
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

        IEnumerator<Dictionary<string, string>> IEnumerable<Dictionary<string, string>>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return reader.GetEnumerator();
        }

        public bool MoveNext()
        {
            currentFields.Clear();
            bool hasRows = reader.ReadNextRecord();
            foreach (var map in excelMapping)
            {
                var colName = map.ExcelColumn;
                currentFields[colName] = Headers.Contains(colName) ? reader[colName] : string.Empty;
            }
            return hasRows;
        }

        public void Reset()
        {
            reader.MoveToStart();
        }

        Dictionary<string, string> IEnumerator<Dictionary<string, string>>.Current
        {
            get { return currentFields; }
        }

        public object Current
        {
            get { return currentFields; }
        }

        public void Dispose()
        {
            if (disposed)
                return;
            reader.Dispose();
            disposed = true;
        }
    }
}