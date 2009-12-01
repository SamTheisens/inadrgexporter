using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using INADRGExporter.Properties;
using LumenWorks.Framework.IO.Csv;

namespace INADRGExporter
{
    public enum UngroupableHandlingMode
    {
        None,
        SkipUngroupable,
        IncludeUngroupable,
        OnlyUngroupable
    }
    public class TextFileBindingSource : PreviewBindingSource
    {
        private readonly CachedCsvReader csv;
        private readonly UngroupableHandlingMode ungroupableHandlingMode;

        public TextFileBindingSource(DataTable table, string excelFile, DateTime from, DateTime until, UngroupableHandlingMode ungroupableHandlingMode) :
            base(table, Int32.MaxValue, from, until)
        {
            this.ungroupableHandlingMode = ungroupableHandlingMode;
            csv = new CachedCsvReader(new StreamReader(excelFile), true, ';');
            csv.ReadToEnd();
            count = csv.CurrentRecordIndex;
            csv.MoveToStart();
        }
        protected override object[] BeginReadingRows(int startPosition)
        {
            csv.MoveTo(startPosition);
            var objects = base.BeginReadingRows(startPosition);
            objects[table.Columns.IndexOf("TglSampai")] = until;
            objects[table.Columns.IndexOf("TglDari")] = from;
            objects[table.Columns.IndexOf("NamaRs")] = Settings.Default.NamaRumahSakit;
            objects[table.Columns.IndexOf("KdRs")] = Settings.Default.KodeRumahSakit;
            return objects;
        }

        protected override void ReadRows(int startPosition)
        {
            var objects = BeginReadingRows(startPosition);
            if (stepsize == 0) stepsize = Int32.MaxValue;
            for (int i = 0; table.Rows.Count < stepsize && csv.ReadNextRecord(); i++)
            {
                bool hasTarif = false;
                var currentRowTglKlr = new DateTime();
                for (int j = 0; j < csv.FieldCount; j++)
                {
                    string currentCell = csv[j];
                    var currentHeader = csv.GetFieldHeaders()[j];

                    var time = new DateTime();
                    if (DateTime.TryParseExact(currentCell, Settings.Default.DateFormat,
                                               CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                    {
                        currentCell = GrouperHelper.ToSQLDate(time);
                        if (currentHeader == "Tglklr")
                            currentRowTglKlr = time;
                    }
                    
                    var columnNumber = table.Columns.IndexOf(currentHeader);

                    object cell = currentCell;


                    if (string.IsNullOrEmpty(currentCell))
                        cell = DBNull.Value;
                    else cell = currentCell;

                    if (columnNumber != -1 )
                    {
                        if (!string.IsNullOrEmpty(currentCell) && table.Columns[columnNumber].DataType == typeof(double))
                        {
                            var formatInfo = new NumberFormatInfo {NumberDecimalSeparator = Settings.Default.DecimalSeparator};
                            cell = double.Parse(currentCell, NumberStyles.AllowDecimalPoint, formatInfo);
                            hasTarif = true;
                        }
                        objects[columnNumber] = cell;
                    }
                }
                if (currentRowTglKlr >= from && currentRowTglKlr <= until)
                {
                    switch (ungroupableHandlingMode)
                    {
                        case (UngroupableHandlingMode.IncludeUngroupable):
                            AddRow(objects);
                            break;
                        case (UngroupableHandlingMode.SkipUngroupable):
                            if (hasTarif)
                                AddRow(objects);
                            break;
                        case (UngroupableHandlingMode.OnlyUngroupable):
                            if (!hasTarif)
                                AddRow(objects);
                            break;
                        default:
                            AddRow(objects);
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
