using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public FromGrouperReader(IDataSource grouperSource, string outputFile, bool verifikator, UngroupableHandlingMode ungroupableHandlingMode)
        {
            this.ungroupableHandlingMode = ungroupableHandlingMode;
            this.grouperSource = grouperSource;

            writer = new StreamWriter(outputFile, false);

            headers = verifikator
                          ? GrouperHelper.ReadHeaderFile("header_excel_verifikator.txt")
                          : GrouperHelper.ReadHeaderFile("header_excel_dengan_nama.txt");

            connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString);
            connection.Open();

            var sqlCommand = new SqlCommand("create table #DRG (urut INT, rm INT, tglMasuk DATETIME)", connection);
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
            
            InsertIntoTempTable((string)rowSet["Norm"], (DateTime)rowSet["Tglmsk"]);
            rows.Add(rowSet);
            return true;
        }
        public bool EndOfData()
        {
            return currentRow >= grouperSource.Length -1;
        }
        public void ExecuteQuery()
        {
            var insertCommand = new SqlCommand(insertBuffer, connection);
            insertCommand.ExecuteNonQuery();
            insertBuffer = string.Empty;
            currentReadRow = 0;

            var command = new SqlCommand(SqlCodeService.Instance.PatientDetailsQuery, connection);

            dataReader = command.ExecuteReader();
        }
        public bool WriteLine()
        {
            if (!dataReader.Read())
                return false;

            var fields = rows[currentRow] as Dictionary<string, object>;
            fields["Nama"] = dataReader["Nama"].ToString();
            fields["Dokter"] = dataReader["Dokter"].ToString();
            fields["SKP"] = dataReader["SKP"].ToString();

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


        private static void InsertIntoTempTable(string rm, DateTime tglMasuk)
        {
            insertBuffer += string.Format(CultureInfo.InvariantCulture, "INSERT INTO #DRG VALUES ({0},{1},'{2}');", currentReadRow, rm.Replace("\'", ""),
                                          GrouperHelper.ToSqlDate(tglMasuk));
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
            connection.Close();
        }

    }
}