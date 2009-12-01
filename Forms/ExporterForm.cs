using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using INADRGExporter.Forms;
using INADRGExporter.Properties;

namespace INADRGExporter
{
    struct ReaderArguments
    {
        public DateTime from;
        public DateTime until;
        public string kdCustomer;
        public string inputFile;
        public string outputFile;
    }
    enum PreviewMode { Database, TextFile }
    
    public partial class ExporterForm : Form
    {
        private readonly string commandText = "";
        private PreviewMode previewMode = PreviewMode.Database;
        private AutoResetEvent resetEvent;

        public bool ShowFailedGroupingsOnly { get; set; }

        public ExporterForm()
        {
            resetEvent = new AutoResetEvent(true);
            ShowFailedGroupingsOnly = true;
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog(toGrouperTextBox);
        }
        private void browseInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog(toExcelTextBox);
        }


        private void openFileDialog(Control textbox)
        {
            openFileDialog1.FileName = textbox.Text;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                textbox.Text = openFileDialog1.FileName;
        }

        private static void PromptForConnectionString(string currentConnectionString)
        {
            MSDASC.DataLinks dataLinks = new MSDASC.DataLinksClass();
            ADODB.Connection dialogConnection;
            string generatedConnectionString = string.Empty;

            if (currentConnectionString == String.Empty)
            {                dialogConnection = (ADODB.Connection)dataLinks.PromptNew();
                generatedConnectionString = dialogConnection.ConnectionString;
            }
            else
            {
                dialogConnection = new ADODB.Connection { Provider = "SQLOLEDB.1" };
                var persistProperty = dialogConnection.Properties["Persist Security Info"];
                persistProperty.Value = true;

                dialogConnection.ConnectionString = currentConnectionString;
                dataLinks = new MSDASC.DataLinks();

                object objConn = dialogConnection;
                if (dataLinks.PromptEdit(ref objConn))
                {
                    generatedConnectionString = dialogConnection.ConnectionString;
                }
            }

            generatedConnectionString = generatedConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
            if (
                    !generatedConnectionString.Contains("Integrated Security=SSPI")
                    && !generatedConnectionString.Contains("Trusted_Connection=True")
                    && !generatedConnectionString.Contains("Password=")
                    && !generatedConnectionString.Contains("Pwd=")
                )
                if (dialogConnection.Properties["Password"] != null)
                    generatedConnectionString += ";Password=" + dialogConnection.Properties["Password"].Value;
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //config.ConnectionStrings.ConnectionStrings["INADRGReader.Properties.Settings.RSKUPANGConnectionString"].
            //    ConnectionString = generatedConnectionString;
            //config.Save(ConfigurationSaveMode.Modified);
            //Properties.Settings.Default["RSKUPANGConnectionString"] = generatedConnectionString;


            //ConfigurationManager.RefreshSection("connectionStrings");
            return;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = inadrgTableAdapter.GetData(fromDateTimePicker.Value, untilDateTimePicker.Value);
            var arguments = new ReaderArguments
                                {
                                    from = fromDateTimePicker.Value,
                                    until = untilDateTimePicker.Value,
                                    kdCustomer = comboBoxCustomer.SelectedValue.ToString(),
                                    inputFile = toGrouperTextBox.Text
                                };
            exportWorker.RunWorkerAsync(arguments);
        }


        private void exportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel.Text = e.UserState.ToString();
            Cursor = e.UserState.ToString() == "Data telah export." ? Cursors.Default : Cursors.WaitCursor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cUSTOMERTableAdapter.Fill(customerDataset.CUSTOMER);
            comboBoxCustomer.SelectedIndex = 3;
            fromDateTimePicker.Value = new DateTime(2009,6,20);
            untilDateTimePicker.Value = new DateTime(2009, 6, 20);
            Text += " - " + Settings.Default.NamaRumahSakit + " - Type " +
                    Settings.Default.RumahSakit[Settings.Default.TypeRumahSakit];
        }

        private void toolStripMenuItemChangeConnectionstring_Click(object sender, EventArgs e)
        {
            PromptForConnectionString(Settings.Default.RSKUPANGConnectionString);
        }

        private void RefreshPreview(UngroupableHandlingMode ungroupableHandlingMode)
        {
            var table = new RSKUPANGDataSet.inadrgDataTable {Locale = new CultureInfo("id-ID")};

            PreviewBindingSource bindingSource;
            if (previewMode == PreviewMode.Database)
                bindingSource = new DatabaseBindingSource(table, Settings.Default.PreviewSize, fromDateTimePicker.Value,
                                                          untilDateTimePicker.Value,
                                                          comboBoxCustomer.SelectedValue.ToString());
            else
                bindingSource = new TextFileBindingSource(table, toExcelTextBox.Text,
                                                          fromDateTimePicker.Value, untilDateTimePicker.Value,
                                                          ungroupableHandlingMode);

            bindingNavigator1.BindingSource = bindingSource;
            bindingSource.Refresh();
            dataGridView1.DataSource = table;
            totalRecords.Text = string.Format("Jumlah baris: {0} ", table.Rows.Count);
        }


        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            untilDateTimePicker.MinDate = fromDateTimePicker.Value;
        }

        private void untilDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDateTimePicker.MaxDate = untilDateTimePicker.Value;
        }



        private void ReportProgress(int linesRead, int linesWritten)
        {
            exportkeExcelWorker.ReportProgress(0,
                                               string.Format("Lines read: {0}. Lines written: {1}",
                                                             linesRead,
                                                             linesWritten));
        }


        private void ExporterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }


        private void exportGridKeExcelButton_Click(object sender, EventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = true;
            var args = new ReaderArguments
                           {
                               from = fromDateTimePicker.Value,
                               until = untilDateTimePicker.Value,
                               kdCustomer = comboBoxCustomer.SelectedValue.ToString()
                           };
            exportGridKeExcelWorker.RunWorkerAsync(args);
        }


        private void exportGridKeExcelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportGridKeExcelProgressBar.Value = e.ProgressPercentage;
        }

        private void exportGridKeExcelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = false;
            Cursor = Cursors.Arrow;
            resetEvent.Reset();
        }

        private void aboutINADRGExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var arguments = new ReaderArguments
            {
                inputFile = fromGrouperBox.Text,
                outputFile = toExcelTextBox.Text
            };

            exportkeExcelWorker.RunWorkerAsync(arguments);
        }

        private void exportGridKeExcelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (ReaderArguments)e.Argument;
            DataTable dataTable;
            using (var connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            {
                connection.Open();
                var selectCommand = string.Format(commandText, GrouperHelper.ToSQLDate(args.from),
                                                  GrouperHelper.ToSQLDate(args.until), args.kdCustomer
                                                  , string.Empty);
                inadrgTableAdapter.Adapter.SelectCommand = new SqlCommand(selectCommand, connection);
                dataTable = new RSKUPANGDataSet.inadrgDataTable();
            }
            inadrgTableAdapter.Adapter.Fill(dataTable);

            ToExcelExporter.WriteToExcelSpreadsheet(@"c:\hoi.xls", dataTable, sender as BackgroundWorker);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                exportWorker.ReportProgress(0, "Sabar. Sedang baca database. . . ");
                var arguments = (ReaderArguments) e.Argument;
                using (
                    var writer = new ToGrouperWriter(arguments.inputFile, arguments.from, arguments.until,
                                                     arguments.kdCustomer))
                {
                    var line = 1;
                    while (writer.NextLine())
                    {
                        exportWorker.ReportProgress(0, "Menulis textfile: " + line);
                        line++;
                    }
                }
                exportWorker.ReportProgress(0, "Data telah export.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error, tolong hubungi SIMRS dan berlapor ini: \\{0}", ex.Message));
            }
        }
        private void exportkeExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var args = (ReaderArguments) e.Argument;
                using (var reader = new FromGrouperReader(args.inputFile, args.outputFile))
                {
                    var linesRead = 0;
                    var linesWritten = 0;
                    var linesReadLastTime = -1;
                    const int stepsize = 200;

                    reader.writeHeaders();

                    while (linesRead > linesReadLastTime && !reader.endOfData())
                    {
                        linesReadLastTime = linesRead;

                        while (reader.readNextLine())
                        {
                            linesRead++;
                            if (linesRead%stepsize == 0)
                                break;
                            ReportProgress(linesRead, linesWritten);
                        }

                        reader.executeQuery();
                        while (reader.writeLine())
                        {
                            linesWritten++;
                            if (linesWritten%stepsize == 0)
                                break;
                            ReportProgress(linesRead, linesWritten);
                        }
                        reader.clearTempDB();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error, tolong hubungi SIMRS dan berlapor ini: \\{0}", ex.Message));
            }
        }

        private void browseFromGrouperButton_Click(object sender, EventArgs e)
        {
            openFileDialog(fromGrouperBox);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsWindow().Show();
        }

        private void reportRekapitulasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReportViewer("rpt_rekapitulasi.rpt");
        }

        private void reportIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReportViewer("rpt_individual.rpt");
        }

        private void OpenReportViewer(string reportFileName)
        {
            var table = new RSKUPANGDataSet.inadrgDataTable { Locale = new CultureInfo("id-ID") };
            var bindingSource = new TextFileBindingSource(table, toExcelTextBox.Text, fromDateTimePicker.Value,
                                                          untilDateTimePicker.Value, UngroupableHandlingMode.SkipUngroupable);
            bindingSource.Start();

            var viewer = new IndividualReportViewer { IndividualsDataset = table, ReportFileName = reportFileName };
            viewer.ShowDialog();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.Database;
            RefreshPreview(UngroupableHandlingMode.None);
        }

        private void keExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.TextFile;
            RefreshPreview(UngroupableHandlingMode.IncludeUngroupable);
        }

        private void excelYangSalahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.TextFile;
            RefreshPreview(UngroupableHandlingMode.OnlyUngroupable);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.FileName = Path.Combine(Settings.Default.ThreeMHISDirectory,
                                                              Settings.Default.ThreeHMISExecutable);
                    process.StartInfo.Arguments = string.Format(" -i {0} -u {1} -p {2} -w", toGrouperTextBox.Text,
                                                                fromGrouperBox.Text, Settings.Default.GroupingProfile);
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error, tolong hubungi SIMRS dan berlapor ini: \\{0}", ex.Message));
            }
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resetEvent.Set();
        }

    }
}
