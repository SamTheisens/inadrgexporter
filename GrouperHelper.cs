using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InadrgExporter;

namespace InadrgExporter
{
    public static class GrouperHelper
    {
        public static Dictionary<string, string> ReadErrorCodes(string fileName)
        {
            var errorCodes = new Dictionary<string, string>();
            using (
                var file =
                    new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName))))
            {
                while (!file.EndOfStream)
                {
                    var fields = file.ReadLine().Split(';');
                    errorCodes[fields[0]] = fields[1];
                }
            }
            return errorCodes;
        }
        public static string[] ReadHeaderFile(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            return file.ReadLine().Split(';');
        }

        public static List<DictionaryField> ReadDictionary(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            file.ReadLine();
            string line = file.ReadLine();
            var dic = new List<DictionaryField>();
            int i = 0;
            while (!line.Contains("newline"))
            {
                var columns = line.Split(':');
                var tuple = new DictionaryField
                                {
                                    Number = i,
                                    Name = columns[1],
                                    Characters = int.Parse(columns[15]),
                                    Repeat = int.Parse(columns[16]),
                                    Filler = string.Equals(columns[0], "filler")
                                };
                i+= tuple.Repeat;
                dic.Add(tuple);
                line = file.ReadLine();
            }
            return dic;
        }
        public static List<FieldMapping> ReadMapping(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            file.ReadLine();
            var dic = new List<FieldMapping>();
            int i = 0;
            string line;
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                var columns = line.Split(':');
                var tuple = new FieldMapping
                {
                    Number = i,
                    ExcelColumn = columns[0],
                    DictionaryColumn = columns[1],
                    ColumnNumber = int.Parse(columns[2])
                };
                dic.Add(tuple);
            }
            return dic;
        }
        public static Dictionary<string, int> CreateMappingDictionary(List<FieldMapping> maps, List<DictionaryField> dictionary)
        {
            var mappingDic = new Dictionary<string, int>();
            foreach (var dicField in dictionary)
            {
                for (int i = 0; i < dicField.Repeat; i++)
                {
                    if (dicField.Filler)
                        continue;
                    var map = maps.SingleOrDefault(m => m.DictionaryColumn == dicField.Name && m.ColumnNumber == i + 1);
                    if (map.DictionaryColumn != null)
                    {
                        mappingDic[map.ExcelColumn] = dicField.Number + i;
                    }
                }
            }
            return mappingDic;
        }

        public static Dictionary<string, string> JoinMapping(List<FieldMapping> maps, Dictionary<string, int> mappingDic, string[] readFields)
        {
            var rowSet = new Dictionary<string, string>();
            foreach (var pair in mappingDic)
            {
                rowSet[pair.Key] = readFields[pair.Value];
            }
            var resultSet = new Dictionary<string, string>();
            foreach (var map in maps)
            {
                resultSet[map.ExcelColumn] = rowSet.ContainsKey(map.ExcelColumn)
                                                 ? rowSet[map.ExcelColumn]
                                                 : string.Empty;
            }
            return resultSet;
        }
        public static string ToSQLDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        
    }
}