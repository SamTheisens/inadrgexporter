using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using INADRGExporter.Properties;

namespace INADRGExporter
{
    class DatabaseBindingSource : PreviewBindingSource
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        private readonly string selectCommand;

        public DataTable Table
        {
            get
            {
                return table;
            }
        }

        public DatabaseBindingSource(DataTable table, int stepsize, DateTime from, DateTime until, string kdCustomer)
            : base(table, stepsize, from, until)
        {
            selectCommand = string.Format(SQLCodeService.Instance.InadrgQuery,
                                              GrouperHelper.ToSQLDate(from),
                                              GrouperHelper.ToSQLDate(until),
                                              kdCustomer,
                                              "{0}",
                                              Settings.Default.NamaRumahSakit,
                                              Settings.Default.KodeRumahSakit,
                                              Settings.Default.TypeRumahSakit + 1);

            
            using (var countConnection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            {
                countConnection.Open();
                var countCommand =
                    new SqlCommand(string.Format(selectCommand, SQLCodeService.Instance.CountInadrgPredicate),
                                   countConnection);
                count = (int) countCommand.ExecuteScalar();
                countConnection.Close();
            }
        }

        protected override object[] BeginReadingRows(int startPosition)
        {
            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();
            var rangeSelectCommand = string.Format(string.Format(selectCommand,SQLCodeService.Instance.SelectInadrgPredicate),
                                                   string.Format("WHERE Recid between {0} and {1}",
                                                                 startPosition + 1,
                                                                 startPosition + stepsize));
            var command = new SqlCommand(rangeSelectCommand, connection);

            reader = command.ExecuteReader();
            return base.BeginReadingRows(startPosition);
        }

        protected override void ReadRows(int startPosition)
        {
            BeginReadingRows(startPosition);
            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++) 
                    dict.Add(reader.GetName(i), reader.GetValue(i));
                AddRow(dict);
            }
            EndReadingRows();
        }
        protected override void EndReadingRows()
        {
            base.EndReadingRows();
            connection.Close();
        }

        public void Start()
        {
            base.OnPositionChanged(new EventArgs());
        }

    }
}
