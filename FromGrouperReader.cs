using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using InadrgExporter.DataSources;
using InadrgExporter.Properties;

namespace InadrgExporter
{
    public struct Tariff
    {
        public string Deskripsi { get; set; }
        public double Alos { get; set; }
        public double Harga { get; set; }
    }

    public sealed class FromGrouperReader : IDisposable
    {
        private readonly StreamWriter writer;
        private readonly IDataSource grouperSource;
        private readonly SqlConnection connection;

        private readonly Collection<object> rows = new Collection<object>();
        private SqlDataReader dataReader;
        private int currentRow;
        private static int currentReadRow;
        private static string insertBuffer = "";
        private static string outputBuffer = "";
        private readonly string[] headers;
        private Dictionary<string, object> rowSet = new Dictionary<string, object>();
        private bool endFile;
        private readonly UngroupableHandlingMode ungroupableHandlingMode;
        private readonly DataTable table;

        public FromGrouperReader(DataTable table, IDataSource grouperSource, string outputFile, bool verifikator, UngroupableHandlingMode ungroupableHandlingMode)
        {
            this.ungroupableHandlingMode = ungroupableHandlingMode;
            this.grouperSource = grouperSource;
            this.table = table;

            writer = new StreamWriter(outputFile, false);

            headers = verifikator
                          ? GrouperHelper.ReadHeaderFile("header_excel_verifikator.txt")
                          : GrouperHelper.ReadHeaderFile("header_excel_dengan_nama.txt");

            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();

            var sqlCommand = new SqlCommand("create table #DRG (urut INT, rm INT, tglMasuk DATETIME, kdUnit VARCHAR(5), urutMasuk INT)", connection);
            sqlCommand.ExecuteNonQuery();
        }
        public long Length
        {
            get { return grouperSource.Length; }
        }

        public void ClearTempDB()
        {
            dataReader.Close();
            var clearDB = new SqlCommand("delete From #DRG", connection);
            clearDB.ExecuteNonQuery();
        }
        public bool ReadNextLine()
        {
            endFile = grouperSource.MoveNext();
            if (!endFile)
                return false;
            rowSet = grouperSource.Current;
            var recId = long.Parse((string)rowSet["Recid"]);
            var tableRow = FindRow(recId);

            InsertIntoTempTable(tableRow["Norm"].ToString(), (DateTime) tableRow["Tglmsk"],
                                tableRow["KdUnit"].ToString(), tableRow["UrutMasuk"].ToString());
            rows.Add(rowSet);
            return true;
        }

        private DataRow FindRow(long recId)
        {
            foreach (DataRow row in table.Rows)
            {
                if ((long)row["Recid"] == recId)
                    return row;
            }
            return null;
        }

        public bool EndOfData()
        {
            return currentRow >= grouperSource.Length -1;
        }
        public void ExecuteQuery()
        {
            if (insertBuffer.Length == 0)
                return;
            var insertCommand = new SqlCommand(insertBuffer, connection);
            insertCommand.ExecuteNonQuery();
            insertBuffer = string.Empty;
            currentReadRow = 0;

            var command = new SqlCommand(SqlCodeService.Instance.PatientDetailsQuery, connection);
            dataReader = command.ExecuteReader();

        }
        public bool WriteLine()
        {
            if (dataReader.IsClosed || !dataReader.Read())
                return false;

            var fields = rows[currentRow] as Dictionary<string, object>;
            InsertQueriedFields(fields);

            var row = new Collection<string>(); 
            foreach (var header in headers)
            {
                if (fields.ContainsKey(header))
                    row.Add(GrouperHelper.ToString(fields[header]));
                else
                    row.Add(string.Empty);
            }
            if (ungroupableHandlingMode == UngroupableHandlingMode.IncludeUngroupable ||
                (ungroupableHandlingMode == UngroupableHandlingMode.SkipUngroupable &&
                fields["Tarif"] != null))
                WriteAsLine(row.ToArray(), writer);
            currentRow++;
            return true;
        }

        private void InsertQueriedFields(IDictionary<string, object> fields)
        {
            if (!fields["Norm"].Equals(dataReader["rm"].ToString()))
                throw new ArgumentException(string.Format("Cari info pasien tidak berhasil: Norm tidak sesuai {0} -> {1} ", fields["Norm"],
                                                          dataReader["rm"]));

            fields["Nama"] = dataReader["Nama"].ToString();
            fields["Dokter"] = dataReader["Dokter"].ToString();
            fields["SKP"] = dataReader["SKP"].ToString();
            fields["KdUnit"] = dataReader["KdUnit"].ToString();
            fields["UrutMasuk"] = dataReader["UrutMasuk"].ToString();
        }


        private static void InsertIntoTempTable(string rm, DateTime tglMasuk, string kdUnit, string urutMasuk)
        {
            insertBuffer += string.Format(CultureInfo.InvariantCulture, "INSERT INTO #DRG VALUES ({0},{1},'{2}','{3}',{4});", currentReadRow, rm.Replace("\'", ""),
                                          GrouperHelper.ToSqlDate(tglMasuk), kdUnit, urutMasuk);
            currentReadRow++;
        }

        public static void WriteAsLine(string[] values, TextWriter writer)
        {
            outputBuffer = string.Join(";", values) + ";";
            PrintNextLine(writer);
        }

        private static void PrintNextLine(TextWriter writer)
        {
            writer.WriteLine(outputBuffer);
            outputBuffer = "";
        }

        public void WriteHeaders()
        {
            writer.WriteLine(String.Join(";", headers) + ";");
        }
        
        public void Dispose()
        {
            grouperSource.Dispose();
            dataReader.Close();
            writer.Flush();
            writer.Close();
            writer.Dispose();
            connection.Close();
        }

    }
}