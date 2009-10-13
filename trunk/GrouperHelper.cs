using System.Collections.Generic;
using System.IO;
using INADRGExporter;

namespace INADRGExporter
{
    public static class GrouperHelper
    {
        public static List<Tuple> ReadDictionary(string fileName)
        {
            var file = new StreamReader(fileName);
            file.ReadLine();
            string line = file.ReadLine();
            var dic = new List<Tuple>();
            int i = 0;
            while (!line.Contains("newline"))
            {
                var columns = line.Split(':');
                var tuple = new Tuple
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

        
    }
}