using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace INADRGExporter
{
    public struct Tuple
    {
        public string name;
        public int characters;
        public int number;
        public int repeat;
        public bool filler;
    }

    public struct Map
    {
        public int number;
        public string excelColumn;
        public string dicColumn;
        public int columnNumber;
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
