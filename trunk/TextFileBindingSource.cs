using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using InadrgExporter.FileReaders;
using InadrgExporter.Properties;

namespace InadrgExporter
{
    public enum UnGroupableHandlingMode
    {
        None,
        SkipUngroupable,
        IncludeUngroupable,
        OnlyUngroupable
    }
    public class TextFileBindingSource : PreviewBindingSource
    {
        private readonly ITextFileFieldReader reader;
        private readonly UnGroupableHandlingMode unGroupableHandlingMode;
        private readonly Dictionary<string, Tarif> tarif;
        private readonly Dictionary<string, string> errorCodes;

        public TextFileBindingSource(ITextFileFieldReader reader, DataTable table, DateTime from, DateTime until, UnGroupableHandlingMode unGroupableHandlingMode) :
            base(table, Int32.MaxValue, from, until)
        {
            this.unGroupableHandlingMode = unGroupableHandlingMode;
            this.reader = reader;
            errorCodes = GrouperHelper.ReadErrorCodes("errorcodes.dic");
            tarif = FromGrouperReader.readTarifJamkesmas();
        }

        protected override void ReadRows(int startPosition)
        {
            BeginReadingRows(startPosition);
            for (int i = 0; table.Rows.Count < stepsize && reader.MoveNext(); i++)
            {
                bool hasTarif = false;
                
                var readerRowSet = (Dictionary<string, string>) reader.Current;
                var rowSet = new Dictionary<string, object>();
                foreach (var pair in readerRowSet)
                {
                    var index = table.Columns.IndexOf(pair.Key);
                    if (index == -1)
                        continue;

                    if (string.IsNullOrEmpty(pair.Value))
                    {
                        rowSet[pair.Key] = DBNull.Value;
                        continue;
                    }

                    object value = pair.Value;
                        
                    if (table.Columns[index].DataType == typeof(double))
                    {
                        var formatInfo = new NumberFormatInfo
                        {
                            NumberDecimalSeparator = (pair.Value.Contains(",") ? "," : ".")
                        };
                        value = double.Parse(pair.Value, NumberStyles.AllowDecimalPoint, formatInfo); ;
                    }
                    if (table.Columns[index].DataType == typeof(DateTime))
                    {
                        value = DateTime.ParseExact(pair.Value, Settings.Default.DateFormat,
                                                       CultureInfo.InvariantCulture, DateTimeStyles.None);
                    }
                    rowSet[pair.Key] = value;
                }

                var currentRowTglKlr = (DateTime)rowSet["Tglklr"];

                var inadrg = (string)rowSet["Inadrg"];
                if (tarif.ContainsKey(inadrg))
                {
                    rowSet["Tarif"] = tarif[inadrg].Harga;
                    rowSet["Deskripsi"] = tarif[inadrg].Deskripsi;
                    rowSet["Alos"] = tarif[inadrg].Alos;
                }
                else
                {
                    rowSet["Tarif"] = null;
                    if (errorCodes.ContainsKey(inadrg)) rowSet["Deskripsi"] = errorCodes[inadrg];
                    rowSet["Alos"] = null;
                }
                if (rowSet["Tarif"] != null) 
                    hasTarif = true;
                rowSet["TglSampai"] = until;
                rowSet["TglDari"] = from;
                rowSet["Namars"] = Settings.Default.NamaRumahSakit;
                rowSet["KdRs"] = Settings.Default.KodeRumahSakit;

                if (currentRowTglKlr >= from && currentRowTglKlr <= until)
                {
                    switch (unGroupableHandlingMode)
                    {
                        case (UnGroupableHandlingMode.IncludeUngroupable):
                            AddRow(rowSet);
                            break;
                        case (UnGroupableHandlingMode.SkipUngroupable):
                            if (hasTarif)
                                AddRow(rowSet);
                            break;
                        case (UnGroupableHandlingMode.OnlyUngroupable):
                            if (!hasTarif)
                                AddRow(rowSet);
                            break;
                        default:
                            AddRow(rowSet);
                            break;
                    }
                }
            }
            EndReadingRows();
            count = table.Rows.Count;
            base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }
        public void Start()
        {
            base.OnPositionChanged(new EventArgs());
        }
    }
}
