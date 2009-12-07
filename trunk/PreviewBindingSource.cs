using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using InadrgExporter.DataSources;

namespace InadrgExporter
{
    public sealed class PreviewBindingSource : BindingSource
    {
        public DataTable Table { get; set; }

        private DateTime From { get; set; }
        private DateTime Until { get; set; }
        private int stepSize = 100;
        private int previousPosition;
        private readonly IEnumerator enumerator;
        private readonly IDataSource datasource;

        private int StepSize
        {
            get { return stepSize; }
            set { stepSize = value; }
        }

        public PreviewBindingSource(IDataSource datasource, DataTable table, DateTime from, DateTime until, int stepSize)
            : base(table, string.Empty)
        {
            Table = table;
            StepSize = stepSize;
            From = from;
            Until = until;
            DataMember = table.TableName;
            enumerator = Table.Rows.GetEnumerator();
            this.datasource = datasource;
        }
        
        public override int Count
        {
            get { return (int)Length + 1; }
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
            if (Position != previousPosition)
            {
                int positionPlusStepSize;
                if (Position > previousPosition)
                {
                    positionPlusStepSize = previousPosition + StepSize - (Position < StepSize ? 1 : 0);
                    if (positionPlusStepSize > Count)
                    {
                        Position = previousPosition;
                        return;
                    }
                }
                else
                {
                    positionPlusStepSize = previousPosition - StepSize + (Position < StepSize ? 1 : 0);
                }

                previousPosition = positionPlusStepSize;
                Position = positionPlusStepSize;
                ReadRows(positionPlusStepSize);
            }
            if (Position == 0)
            {
                ReadRows(0);
            }
            
        }

        public long Length { get; private set; }

        public void ReadRows(int startPosition)
        {
            BeginReadingRows();
            datasource.ReadRows(From, Until, startPosition, StepSize);
            while (datasource.MoveNext())
            {
                GrouperHelper.AddRow(Table, datasource.Current);
            }
            EndReadingRows();
            Length = datasource.Length;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        private void BeginReadingRows()
        {
            Table.Rows.Clear();
            Table.BeginLoadData();
        }

        private void EndReadingRows()
        {
            try
            {
                Table.EndLoadData();
            }
            catch (ConstraintException) {}
        }

        public void Refresh()
        {
            OnPositionChanged(new EventArgs());
        }

        public new bool MoveNext()
        {
            return enumerator.MoveNext();
        }
    }
}