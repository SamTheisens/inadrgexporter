using System.IO;
using System.Windows.Forms;

namespace InadrgExporter
{
    public sealed class SqlCodeService
    {
        private static SqlCodeService instance;

        static SqlCodeService()
        {
        }

        SqlCodeService()
        {
            using (var reader = new StreamReader(Path.Combine(Application.StartupPath, @"SQLCode\SelectInadrg.sql")))
                InadrgQuery = reader.ReadToEnd();
            using (var reader = new StreamReader(Path.Combine(Application.StartupPath, @"SQLCode\SelectPatientDetails.sql")))
                PatientDetailsQuery = reader.ReadToEnd();
            using (var reader = new StreamReader(Path.Combine(Application.StartupPath, @"SQLCode\SelectInadrgPredicate.sql")))
                SelectInadrgPredicate = reader.ReadToEnd();
            using (var reader = new StreamReader(Path.Combine(Application.StartupPath, @"SQLCode\CountInadrgPredicate.sql")))
                CountInadrgPredicate = reader.ReadToEnd();

        }

        public string InadrgQuery { get; private set; }
        public string SelectInadrgPredicate { get; private set; }
        public string CountInadrgPredicate { get; private set; }

        public string PatientDetailsQuery { get; private set; }

        public static SqlCodeService Instance
        {
            get
            {
                if (instance == null)
                    instance = new SqlCodeService();
                return instance;
            }
        }

    }
}
