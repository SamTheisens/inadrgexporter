
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using InadrgExporter;
using InadrgExporter.DataSources;
using InadrgExporter.FileReaderCollections;
using NUnit.Framework;
using NUnit.Mocks;
using System.Windows.Forms;

namespace INADRGExporterTestSuite
{
    [TestFixture]
    public class FileReaderCollectionsTest
    {
        public FileReaderCollectionsTest()
        {
            
        }
        private static string dictionaryPath = GetStartupPath(@"Dictionaries\cgs_ina_out.dic");
        private static string excelMappingPath = GetStartupPath(@"Dictionaries\dic_excel_mapping.dic");

        [Test]
        public void CSVReaderTest()
        {
            using (var reader = new CsvReaderCollection("darigrouper-ke-excel.txt", GrouperHelper.ReadMapping(excelMappingPath)))
            {
                CheckReader(reader);
            }
        }

        [Test]
        public void FieldWidthReaderTest()
        {
            using (var reader = new FieldWidthReaderCollection("darigrouper-dari-inadrg.txt",
                                                        GrouperHelper.ReadDictionary(dictionaryPath),
                                                        GrouperHelper.ReadMapping(excelMappingPath)))
            {
                CheckReader(reader);
            }
        }

        private static void CheckReader(ITextFileFieldReaderCollection reader)
        {
            Assert.AreEqual(3, reader.Rows);
            Assert.False(reader.EndOfData);
            var rowSet = new Dictionary<string, string>();
            reader.MoveNext();
            rowSet = reader.Current;
            Assert.AreEqual("01/06/2009", rowSet["Tglmsk"]);
            reader.MoveNext();
            rowSet = reader.Current;
            Assert.AreEqual("2", rowSet["Recid"]);
            Assert.AreEqual("K011", rowSet["Dutama"]);
            reader.MoveNext();
            rowSet = reader.Current;
            Assert.AreEqual("3", rowSet["Recid"]);
            reader.MoveNext();
            Assert.True(reader.EndOfData);
        }

        private static string GetStartupPath(string fileName)
        {
            var split = Application.StartupPath.Split('\\');
            string result = "";
            for (int i = 0; i < split.Length; i++)
                result += "..\\";
            result += Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName).Replace("C:\\", "");
            return result;
        }
    }
}
