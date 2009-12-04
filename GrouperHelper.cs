using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using INADRGExporter;

namespace INADRGExporter
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

        public static List<DicField> ReadDictionary(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            file.ReadLine();
            string line = file.ReadLine();
            var dic = new List<DicField>();
            int i = 0;
            while (!line.Contains("newline"))
            {
                var columns = line.Split(':');
                var tuple = new DicField
                                {
                                    number = i,
                                    name = columns[1],
                                    characters = int.Parse(columns[15]),
                                    repeat = int.Parse(columns[16]),
                                    filler = string.Equals(columns[0], "filler")
                                };
                i+= tuple.repeat;
                dic.Add(tuple);
                line = file.ReadLine();
            }
            return dic;
        }
        public static List<Map> ReadMapping(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            file.ReadLine();
            var dic = new List<Map>();
            int i = 0;
            string line;
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                var columns = line.Split(':');
                var tuple = new Map
                {
                    number = i,
                    excelColumn = columns[0],
                    dicColumn = columns[1],
                    columnNumber = int.Parse(columns[2])
                };
                dic.Add(tuple);
            }
            return dic;
        }
        public static Dictionary<string, int> CreateMappingDictionary(List<Map> maps, List<DicField> dictionary)
        {
            var mappingDic = new Dictionary<string, int>();
            foreach (var dicField in dictionary)
            {
                for (int i = 0; i < dicField.repeat; i++)
                {
                    if (dicField.filler)
                        continue;
                    var map = maps.SingleOrDefault(m => m.dicColumn == dicField.name && m.columnNumber == i + 1);
                    if (map.dicColumn != null)
                    {
                        mappingDic[map.excelColumn] = dicField.number + i;
                    }
                }
            }
            return mappingDic;
        }

        public static Dictionary<string, string> JoinMapping(List<Map> maps, Dictionary<string, int> mappingDic, string[] readFields)
        {
            var rowSet = new Dictionary<string, string>();
            foreach (var pair in mappingDic)
            {
                rowSet[pair.Key] = readFields[pair.Value];
            }
            var resultSet = new Dictionary<string, string>();
            foreach (var map in maps)
            {
                resultSet[map.excelColumn] = rowSet.ContainsKey(map.excelColumn)
                                                 ? rowSet[map.excelColumn]
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