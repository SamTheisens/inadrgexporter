using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using InadrgExporter.FileReaderCollections;
using InadrgExporter.Properties;

namespace InadrgExporter.DataSources
{
    public enum UngroupableHandlingMode
    {
        None,
        SkipUngroupable,
        IncludeUngroupable,
        OnlyUngroupable
    }

    public class TextFileDataSource : IDataSource
    {
        private readonly ITextFileFieldReaderCollection readerCollection;
        private readonly UngroupableHandlingMode ungroupableHandlingMode;
        private readonly Dictionary<string, Tariff> tarif;
        private readonly Dictionary<string, string> errorCodes;
        private readonly DataTable table;

        private Dictionary<string, object> currentRow;
        
        
        public TextFileDataSource(ITextFileFieldReaderCollection readerCollection, UngroupableHandlingMode ungroupableHandlingMode, DataTable table)
        {
            this.ungroupableHandlingMode = ungroupableHandlingMode;
            this.readerCollection = readerCollection;
            this.table = table;
            errorCodes = GrouperHelper.ReadErrorCodes("errorcodes.dic");
            tarif = GrouperHelper.ReadTarifJamkesmas();
        }


        public int Length
        {
            get
            {
                if (table.Rows.Count > 0)
                    return table.Rows.Count;
                return (int)readerCollection.Rows;
            }
        }

        public void ReadRows(DateTime from, DateTime until, int startPosition, int stepSize)
        {
            for (int i = 0; table.Rows.Count < stepSize && MoveNext(); i++)
            {
                bool hasTarif = false;

                if (Current["Tarif"] != null)
                    hasTarif = true;
                Current["TglSampai"] = until;
                Current["TglDari"] = from;
                var currentRowTglKlr = (DateTime)currentRow["Tglklr"];

                if (currentRowTglKlr >= from && currentRowTglKlr <= until)
                {
                    switch (ungroupableHandlingMode)
                    {
                        case (UngroupableHandlingMode.IncludeUngroupable):
                            GrouperHelper.AddRow(table, currentRow);
                            break;
                        case (UngroupableHandlingMode.SkipUngroupable):
                            if (hasTarif)
                                GrouperHelper.AddRow(table, currentRow);
                            break;
                        case (UngroupableHandlingMode.OnlyUngroupable):
                            if (!hasTarif)
                                GrouperHelper.AddRow(table, currentRow);
                            break;
                        default:
                            GrouperHelper.AddRow(table, currentRow);
                            break;
                    }
                }
            }
        }

        public void Dispose()
        {
            readerCollection.Dispose();
        }

        public bool MoveNext()
        {
            if (!readerCollection.MoveNext())
            {
                return false;
            }

            var readerRowSet = readerCollection.Current;
            currentRow = new Dictionary<string, object>();
            foreach (var pair in readerRowSet)
            {
                var index = table.Columns.IndexOf(pair.Key);
                if (index == -1)
                    continue;

                if (string.IsNullOrEmpty(pair.Value))
                {
                    currentRow[pair.Key] = DBNull.Value;
                    continue;
                }

                object value = pair.Value;

                if (table.Columns[index].DataType == typeof(double))
                {
                    var formatInfo = new NumberFormatInfo
                                         {
                                             NumberDecimalSeparator = (pair.Value.Contains(",") ? "," : ".")
                                         };
                    value = double.Parse(pair.Value, NumberStyles.AllowDecimalPoint, formatInfo);
                }
                if (table.Columns[index].DataType == typeof(DateTime))
                {
                    value = DateTime.ParseExact(pair.Value, Settings.Default.DateFormat,
                                                CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
                currentRow[pair.Key] = value;
            }

            var inadrg = (string)currentRow["Inadrg"];
            if (tarif.ContainsKey(inadrg))
            {
                currentRow["Tarif"] = tarif[inadrg].Harga;
                currentRow["Deskripsi"] = tarif[inadrg].Deskripsi;
                currentRow["Alos"] = tarif[inadrg].Alos;
            }
            else
            {
                currentRow["Tarif"] = null;
                if (errorCodes.ContainsKey(inadrg)) currentRow["Deskripsi"] = errorCodes[inadrg];
                currentRow["Alos"] = null;
            }
            currentRow["Namars"] = Settings.Default.NamaRumahSakit;
            currentRow["KdRs"] = Settings.Default.KodeRumahSakit;
            return true;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> Current
        {
            get { return currentRow; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}