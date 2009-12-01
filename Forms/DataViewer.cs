using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;

namespace INADRGExporter.Forms
{
    public partial class DataViewer : Form
    {
        public DataViewer()
        {
            InitializeComponent();
            using (var csv = new CachedCsvReader(new StreamReader(@"C:\keexcel.txt"), true, ';'))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                var dataset = new RSKUPANGDataSet();
                dataGridView.ColumnCount = headers.Length;
                var columnHeaderStyle =
                    new DataGridViewCellStyle {BackColor = Color.Aqua, Font = new Font("Verdana", 10, FontStyle.Bold)};
                dataGridView.ColumnHeadersDefaultCellStyle =
                    columnHeaderStyle;

                for (int i = 0; i < headers.Length; i++)
                {
                    var col = dataGridView.Columns[i];
                    col.Name = headers[i];
                    col.HeaderText = headers[i];
                    col.ValueType = TryGetValueType(dataset, headers[i]);
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                }

                //dataGridView1.DataSource = csv;
                //RSKUPANGDataSet.GetTypedDataSetSchema(schema);
                //dataGridView1.Rows.Add()

                for (int i = 0; i < 30 && csv.ReadNextRecord(); i++)
                {
                    for (int j = 0; j < fieldCount; j++)
                    {
                        dataGridView.Rows[i].Cells[j].Value = csv[j];
                    }
                }

            }

        }
        private static Type TryGetValueType(RSKUPANGDataSet dataset, string header)
        {
            int pos = dataset.inadrg.Columns.IndexOf(header);
            if (pos == -1)
                return null;
            return dataset.inadrg.Columns[dataset.inadrg.Columns.IndexOf(header)].DataType;
        }

    }
}