using System;
using System.Windows.Forms;
using InadrgExporter.Forms;

namespace InadrgExporter
{
    public struct DictionaryField
    {
        public string Name { get; set; }
        public int Characters { get; set; }
        public int Number { get; set; }
        public int Repeat { get; set; }
        public bool Filler { get; set; }
    }

    public struct FieldMapping
    {
        public int Number { get; set; }
        public string ExcelColumn { get; set; }
        public string DictionaryColumn { get; set; }
        public int ColumnNumber { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExporterForm());
        }
    }
}
