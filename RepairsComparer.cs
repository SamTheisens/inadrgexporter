using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using InadrgExporter.DataSources;
using InadrgExporter.FileReaderCollections;
using InadrgExporter.Forms;

namespace InadrgExporter
{
    class RepairsComparer : IDataSource
    {
        private readonly ITextFileFieldReaderCollection reader;
        private readonly IDataSource grouperSource;
        private readonly IDataSource textFile;
        private readonly DataTable sourceTable;
        private readonly DataTable destinationTable;
        private Dictionary<string, object> currentRow;
        private IEnumerator rowEnumerator;
        private readonly string[] fieldsToCompare;

        public RepairsComparer(IDataSource grouperSource, ExporterArguments arguments)
        {
            this.grouperSource = grouperSource;
            reader = new CsvReaderCollection(arguments.InputFile, GrouperHelper.ReadMapping("dic_excel_mapping.dic"));
            sourceTable = new RSKUPANGDataSet.inadrgDataTable();
            destinationTable = new RSKUPANGDataSet.inadrgDataTable();
            textFile = new TextFileDataSource(reader, arguments.UngroupableHandlingMode, sourceTable);
            fieldsToCompare = GrouperHelper.ReadHeaderFile("fields_to_compare.txt");

        }
        public DataTable Table
        {
            get { return destinationTable; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return rowEnumerator.MoveNext();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> Current
        {
            get
            {
                var dataRow = (DataRow) rowEnumerator.Current;
                var cols = dataRow.Table.Columns;
                currentRow = new Dictionary<string, object>();
                foreach (DataColumn column in cols)
                {
                    currentRow[column.ColumnName] = dataRow[column.ColumnName];
                }
                return currentRow;
            }
        }

        object IEnumerator.Current
        {
            get { return rowEnumerator.Current; }
        }

        public int Length
        {
            get { return destinationTable.Rows.Count; }
        }

        public void ReadRows(DateTime from, DateTime until, int startPosition, int stepSize)
        {
            grouperSource.ReadRows(from, until, 0, Int32.MaxValue);
            textFile.ReadRows(from, until, 0, Int32.MaxValue);
            destinationTable.BeginLoadData();
            while (grouperSource.MoveNext())
            {
                var currentGrouperRow = grouperSource.Current;
                var primaryKey = new object[4];
                primaryKey[0] = currentGrouperRow["Norm"].ToString();
                primaryKey[1] = GrouperHelper.ToSqlDate((DateTime)currentGrouperRow["Tglmsk"]);
                primaryKey[2] = currentGrouperRow["KdUnit"].ToString();
                primaryKey[3] = currentGrouperRow["UrutMasuk"].ToString();
                var sourceRow = sourceTable.Rows.Find(primaryKey);


                if (sourceRow == null)
                {
                    currentGrouperRow["Recid"] = -1;
                    GrouperHelper.AddRow(destinationTable, currentGrouperRow);
                }
                else
                {
                    Equals(sourceRow, currentGrouperRow);
                }
            }
            try
            {
                destinationTable.EndLoadData();
            }
            catch (ConstraintException) {}
            rowEnumerator = destinationTable.Rows.GetEnumerator();
            rowEnumerator.Reset();
        }
        private void Equals(DataRow leftRow, Dictionary<string, object> rightRow)
        {
            var changes = new Dictionary<string, string>();
            foreach (string field in fieldsToCompare)
            {
                if (!leftRow[field].Equals(rightRow[field]))
                {
                    string before = string.IsNullOrEmpty(leftRow[field].ToString()) ? "kosong" : leftRow[field].ToString();
                    string after = string.IsNullOrEmpty(rightRow[field].ToString()) ? "kosong" : rightRow[field].ToString();

                    changes[field] = "Sebelumnya -> " + before + " Sekarang -> " + after;
                }
            }
            if (changes.Count > 0)
            {
                var newRow = destinationTable.NewRow();

                newRow.ItemArray = leftRow.ItemArray;
                newRow["Perubahan"] = ExtractChanges(changes);
                newRow["Recid"] = -2;
                destinationTable.Rows.Add(newRow);
            }
        }
        private static string ExtractChanges(Dictionary<string, string> errorDictionary)
        {
            string concatenatedErrors = "";
            foreach (var pair in errorDictionary)
            {
                concatenatedErrors += pair.Key + ":" + pair.Value + ";";
            }
            return concatenatedErrors;
        }
    }
}
