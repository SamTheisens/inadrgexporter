using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InadrgExporter;
using InadrgExporter.Properties;

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
                                    Characters = int.Parse(columns[15], CultureInfo.InvariantCulture),
                                    Repeat = int.Parse(columns[16], CultureInfo.InvariantCulture),
                                    Filler = string.Equals(columns[0], "filler")
                                };
                i += tuple.Repeat;
                dic.Add(tuple);
                line = file.ReadLine();
            }
            return dic;
        }
        public static Collection<FieldMapping> ReadMapping(string fileName)
        {
            var file = new StreamReader(Path.Combine(Application.StartupPath, Path.Combine(@"Dictionaries\", fileName)));
            file.ReadLine();
            var dic = new Collection<FieldMapping>();
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
                    ColumnNumber = int.Parse(columns[2], CultureInfo.InvariantCulture)
                };
                dic.Add(tuple);
                i++;
            }
            return dic;
        }
        public static Dictionary<string, int> CreateMappingDictionary(Collection<FieldMapping> maps, List<DictionaryField> dictionary)
        {
            var mappingDictionary = new Dictionary<string, int>();
            foreach (var dicField in dictionary)
            {
                for (int i = 0; i < dicField.Repeat; i++)
                {
                    if (dicField.Filler)
                        continue;
                    var map = maps.SingleOrDefault(m => m.DictionaryColumn == dicField.Name && m.ColumnNumber == i + 1);
                    if (map.DictionaryColumn != null)
                    {
                        mappingDictionary[map.ExcelColumn] = dicField.Number + i;
                    }
                }
            }
            return mappingDictionary;
        }

        public static Dictionary<string, string> JoinMapping(Collection<FieldMapping> maps, Dictionary<string, int> mappingDictionary, string[] readFields)
        {
            var rowSet = new Dictionary<string, string>();
            foreach (var pair in mappingDictionary)
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
        public static string ToSqlDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }


        public static Dictionary<string, Tariff> ReadTarifJamkesmas()
        {
            var tarifJamkesmas = new Dictionary<string, Tariff>();

            if (!File.Exists(Path.Combine(Application.StartupPath, "tarif.dbf")))
                throw new FileNotFoundException(string.Format(CultureInfo.InvariantCulture, "tarif.dbf not found in {0}", Application.StartupPath));
            var connectionString = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" +
                                   Application.StartupPath;

            using (var connection = new OdbcConnection(connectionString))
            {
                var command = new OdbcCommand(
                    "Select * From tarif.dbf", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var tarif = new Tariff
                                        {
                                            Deskripsi = reader["DESKRIPSI"].ToString(),
                                            Alos = ((double)reader["ALOS"]),
                                            Harga = ((double)reader[Settings.Default.RumahSakit[Settings.Default.TypeRumahSakit]])
                                        };
                        tarifJamkesmas[reader["KODE"].ToString()] = tarif;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return tarifJamkesmas;
        }

        public static void AddRow(DataTable table, Dictionary<string, object> rowSet)
        {
            var row = table.NewRow();
            var objects = new object[row.ItemArray.Length];
            foreach (var pair in rowSet)
            {
                var index = table.Columns.IndexOf(pair.Key);
                objects[index] = pair.Value;
            }
            row.ItemArray = objects;
            table.Rows.Add(row);
        }

        public static string ToString(object obj)
        {
            if (obj == null)
                return string.Empty;
            string output;
            if (obj is DateTime)
            {
                output = ((DateTime)obj).ToString(Settings.Default.DateFormat, CultureInfo.InvariantCulture);
            }
            else
            {
                output = obj.ToString();
            }
            return output;
        }
    }
}