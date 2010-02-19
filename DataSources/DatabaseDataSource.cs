using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using InadrgExporter.Properties;

namespace InadrgExporter.DataSources
{
    public class DatabaseDataSource : IDataSource
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private Dictionary<string, object> currentRow;


        private readonly string selectCommand;
        private int length;

        public DatabaseDataSource(DateTime from, DateTime until, string kdCustomer, DataTable table)
        {
            selectCommand = string.Format(CultureInfo.InvariantCulture, SqlCodeService.Instance.InadrgQuery,
                                          GrouperHelper.ToSqlDate(from),
                                          GrouperHelper.ToSqlDate(until),
                                          kdCustomer,
                                          "{0}",
                                          Settings.Default.NamaRumahSakit,
                                          Settings.Default.KodeRumahSakit,
                                          Settings.Default.TypeRumahSakit + 1);

            
            using (var countConnection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            {
                countConnection.Open();
                var countCommand =
                    new SqlCommand(string.Format(CultureInfo.InvariantCulture, selectCommand, SqlCodeService.Instance.CountInadrgPredicate),
                                   countConnection);
                length = (int) countCommand.ExecuteScalar();
                countConnection.Close();
            }
        }

        public int Length
        {
            get { return length; }
        }

        public void ReadRows(DateTime from, DateTime until, int startPosition, int stepSize)
        {
            FetchDatabaseRows(startPosition, stepSize);
        }

        private void FetchDatabaseRows(int startPosition, int stepSize)
        {
            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();
            var rangeSelectCommand = string.Format(CultureInfo.InvariantCulture,
                                                   string.Format(CultureInfo.InvariantCulture, selectCommand,
                                                                 SqlCodeService.Instance.SelectInadrgPredicate),
                                                   string.Format(CultureInfo.InvariantCulture,
                                                                 "WHERE Recid between {0} and {1}",
                                                                 startPosition + 1,
                                                                 startPosition + stepSize));
            var command = new SqlCommand(rangeSelectCommand, connection);

            reader = command.ExecuteReader();
        }


        public void Dispose()
        {
            connection.Close();
        }

        public bool MoveNext()
        {
            if (!reader.Read())
                return false;
            currentRow = new Dictionary<string, object>();
            for (int i = 0; i < reader.FieldCount; i++)
                currentRow.Add(reader.GetName(i), reader.GetValue(i));
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> Current
        {
            get { return currentRow; }
        }

        object IEnumerator.Current
        {
            get { return currentRow; }
        }
    }
}