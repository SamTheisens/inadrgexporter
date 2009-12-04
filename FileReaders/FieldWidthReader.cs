using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace INADRGExporter.FileReaders
{
    public class FieldWidthReader : ITextFileFieldReader
    {
        private readonly long rows;
        private readonly TextFieldParser parser;
        private Dictionary<string,string> currentFields;
        private readonly Dictionary<string, int> mappingDictionary;
        private readonly List<Map> excelMapping;


        public FieldWidthReader(string fileName, List<DicField> dictionary)
        {
            parser = new TextFieldParser(fileName) {TextFieldType = FieldType.FixedWidth};

            var widths = new List<int>();
            int lineWidth = 0;
            excelMapping = GrouperHelper.ReadMapping("dic_excel_mapping.dic");

            foreach (var tuple in dictionary)
            {
                for (int i = 0; i < tuple.repeat; i++)
                    widths.Add(tuple.characters);
                lineWidth += tuple.characters;
            }
            parser.SetFieldWidths(widths.ToArray());
            mappingDictionary = GrouperHelper.CreateMappingDictionary(excelMapping, dictionary);

            var size = new FileInfo(fileName).Length;
            rows = size/ (lineWidth + 2);
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

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            var readFields = parser.ReadFields();
            var rowSet = GrouperHelper.JoinMapping(excelMapping, mappingDictionary, readFields);
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
    }
}
