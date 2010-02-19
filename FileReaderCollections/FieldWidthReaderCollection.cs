using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace InadrgExporter.FileReaderCollections
{
    public sealed class FieldWidthReaderCollection : ITextFileFieldReaderCollection
    {
        private readonly long rows;
        private readonly TextFieldParser parser;
        private bool disposed;
        private Dictionary<string,string> currentFields;
        private readonly Dictionary<string, int> mappingDictionary;
        private readonly Collection<FieldMapping> fieldMapping;


        public FieldWidthReaderCollection(string fileName, List<DictionaryField> dictionary, Collection<FieldMapping> fieldMapping)
        {
            parser = new TextFieldParser(fileName) {TextFieldType = FieldType.FixedWidth};

            var widths = new Collection<int>();
            int lineWidth = 0;
            this.fieldMapping = fieldMapping;
            mappingDictionary = GrouperHelper.CreateMappingDictionary(this.fieldMapping, dictionary);

            foreach (var tuple in dictionary)
            {
                for (int i = 0; i < tuple.Repeat; i++)
                    widths.Add(tuple.Characters);
                lineWidth += tuple.Characters * tuple.Repeat;
            }
            parser.SetFieldWidths(widths.ToArray());
            

            var size = new FileInfo(fileName).Length;
            rows = size/ (lineWidth + 1);
        }

        public long Rows
        {
            get { return rows; }
        }

        public void MoveToRow(int rowNumber)
        {
            throw new System.NotImplementedException();
        }

        public string[] Headers
        {
            get { return null; }
        }

        public bool EndOfData
        {
            get { return parser.EndOfData; }
        }

        IEnumerator<Dictionary<string, string>> IEnumerable<Dictionary<string, string>>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            var readFields = parser.ReadFields();
            if (readFields == null)
                return false;
            var rowSet = GrouperHelper.JoinMapping(fieldMapping, mappingDictionary, readFields);
            currentFields = rowSet;
            return !EndOfData;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public object Current
        {
            get { return currentFields; }
        }

        Dictionary<string, string> IEnumerator<Dictionary<string, string>>.Current
        {
            get { return currentFields; }
        }


        public void Dispose()
        {
            if (disposed)
                return;
            parser.Close();
            parser.Dispose();
            disposed = true;
        }
    }
}