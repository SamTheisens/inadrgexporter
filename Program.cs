using System;
using System.IO;
using System.Windows.Forms;
using InadrgExporter.Forms;
using InadrgExporter.Properties;

namespace InadrgExporter
{
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
            var preRequisites = CheckPrerequisites();
            Application.Run(new ExporterForm());
        }
        private static string CheckPrerequisites()
        {
            var missing = string.Empty;
            var grouperPath = Path.Combine(Settings.Default.ThreeMHISDirectory, Settings.Default.ThreeHMISExecutable);
            if (!File.Exists(grouperPath))
                missing = string.Format(Resources.ErrorGrouperMissing, grouperPath);
            return missing;
        }
    }
}
