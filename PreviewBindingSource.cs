using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace InadrgExporter
{
    public class PreviewBindingSource : BindingSource
    {
        public DataTable table;
        protected long count;
        protected DateTime from;
        protected DateTime until;
        protected int stepsize = 100;
        protected int rowsTriedAdding;

        public PreviewBindingSource(DataTable table, int stepsize, DateTime from, DateTime until)
            : base(table, "")
        {
            this.table = table;
            this.stepsize = stepsize;
            this.from = from;
            this.until = until;
            DataMember = table.TableName;
        }
        
        public override int Count
        {
            get { return ((int)count / stepsize) + 1; }
        }
        public long Length
        {
            get { return count; }
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override object this[int index]
        {
            get { return null; }
        }

        protected override void OnPositionChanged(EventArgs e)
        {
            ReadRows((Position < 0 ? 0 : Position) * stepsize - 1);
        }

        protected virtual void ReadRows(int startPosition) {}

        protected virtual object[] BeginReadingRows(int startPosition)
        {
            table.Rows.Clear();
            table.BeginLoadData();
            
            var objects = new object[table.Columns.Count];
            return objects;
        }

        protected virtual void AddRow(Dictionary<string, object> rowSet)
        {
            var row = table.NewRow();
            var objects = new object[row.ItemArray.Length];
            foreach (var pair in rowSet)
            {
                var index = table.Columns.IndexOf(pair.Key);
                objects[index] = pair.Value;
            }
            row.ItemArray = objects;
            table.Rows.Add(row);
        }

        protected virtual void EndReadingRows()
        {
            try
            {
                table.EndLoadData();
            }
            catch (ConstraintException)
            {
            }
        }
        public void Refresh()
        {
            OnPositionChanged(new EventArgs());
        }
    }
}