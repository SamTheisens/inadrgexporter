using System;
using System.Data;
using System.Windows.Forms;
using INADRGExporter.Properties;

namespace INADRGExporter
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

        protected virtual void AddRow(object[] objects)
        {
            var row = table.NewRow();
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