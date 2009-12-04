using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using INADRGExporter.FileReaders;
using INADRGExporter.Forms;
using INADRGExporter.Properties;

namespace INADRGExporter.Forms
{
    struct ReaderArguments
    {
        public DateTime from;
        public DateTime until;
        public string kdCustomer;
        public string inputFile;
        public string outputFile;
        public bool forVerifikator;
    }

    enum Task {ExportFromDatabase, Group, ExportToExcel}

    enum PreviewMode { Database, TextFile }

    public partial class ExporterForm : Form
    {
        private PreviewMode previewMode = PreviewMode.Database;

        public bool ShowFailedGroupingsOnly { get; set; }

        public ExporterForm()
        {
            ShowFailedGroupingsOnly = true;
            InitializeComponent();
        }

        private string OpenFileDialog(string fileName)
        {
            openFileDialog1.FileName = fileName;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                return openFileDialog1.FileName;
            return string.Empty;
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


        private void refreshButton_Click(object sender, EventArgs e)
        {
            var arguments = new ReaderArguments
                                {
                                    from = fromDateTimePicker.Value,
                                    until = untilDateTimePicker.Value,
                                    kdCustomer = comboBoxCustomer.SelectedValue.ToString(),
                                    inputFile = Path.Combine(Application.StartupPath, Settings.Default.ToGrouperFileName)
                                };
            exportFromDatabaseWorker.RunWorkerAsync(arguments);
        }

        private void ExportToExcel()
        {
            var arguments = new ReaderArguments
                                {
                                    inputFile = Path.Combine(Application.StartupPath,Settings.Default.FromGrouperFileName),
                                    outputFile = Path.Combine(Application.StartupPath,Settings.Default.ToExcelFileName),
                                    forVerifikator = false
                                };
            exportkeExcelWorker.RunWorkerAsync(arguments);
        }


        private void exportWithDemographics_Click(object sender, EventArgs e)
        {
            var arguments = new ReaderArguments
                                {
                                    inputFile = Path.Combine(Application.StartupPath,Settings.Default.FromGrouperFileName),
                                    outputFile = OpenFileDialog(""),
                                    forVerifikator = false
                                };
            exportkeExcelWorker.RunWorkerAsync(arguments);
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
            var table = new RSKUPANGDataSet.inadrgDataTable();

            PreviewBindingSource bindingSource;
            if (previewMode == PreviewMode.Database)
                bindingSource = new DatabaseBindingSource(table, Settings.Default.PreviewSize, fromDateTimePicker.Value,
                                                          untilDateTimePicker.Value,
                                                          comboBoxCustomer.SelectedValue.ToString());
            else
            {
                var reader = new FieldWidthReader(Path.Combine(Application.StartupPath,Settings.Default.FromGrouperFileName), GrouperHelper.ReadDictionary("cgs_ina_out.dic"));
                bindingSource = new TextFileBindingSource(reader, table, fromDateTimePicker.Value, untilDateTimePicker.Value,
                                                          ungroupableHandlingMode);
            }

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


        //private void exportGridKeExcelButton_Click(object sender, EventArgs e)
        //{
        //    exportGridKeExcelProgressBar.Visible = true;
        //    var args = new ReaderArguments
        //                   {
        //                       from = fromDateTimePicker.Value,
        //                       until = untilDateTimePicker.Value,
        //                       kdCustomer = comboBoxCustomer.SelectedValue.ToString()
        //                   };
        //    exportGridKeExcelWorker.RunWorkerAsync(args);
        //}


        private void exportGridKeExcelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportGridKeExcelProgressBar.Value = e.ProgressPercentage;
        }

        private void exportGridKeExcelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = false;
            Cursor = Cursors.Arrow;
        }

        private void aboutINADRGExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exportForVerifikator_Click(object sender, EventArgs e)
        {
            var arguments = new ReaderArguments
                                {
                                    inputFile = Path.Combine(Application.StartupPath,Settings.Default.FromGrouperFileName),
                                    outputFile = OpenFileDialog(""),
                                    forVerifikator = true
                                };

            exportkeExcelWorker.RunWorkerAsync(arguments);
        }

        private void exportGridKeExcelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //var args = (ReaderArguments)e.Argument;
            //DataTable dataTable;
            //using (var connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            //{
            //    connection.Open();
            //    var selectCommand = string.Format("", GrouperHelper.ToSQLDate(args.from),
            //                                      GrouperHelper.ToSQLDate(args.until), args.kdCustomer
            //                                      , string.Empty);
            //    inadrgTableAdapter.Adapter.SelectCommand = new SqlCommand(selectCommand, connection);
            //    dataTable = new RSKUPANGDataSet.inadrgDataTable();
            //}
            //inadrgTableAdapter.Adapter.Fill(dataTable);

            //ToExcelExporter.WriteToExcelSpreadsheet(@"c:\hoi.xls", dataTable, sender as BackgroundWorker);
        }


        private void exportFromDatabaseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                exportFromDatabaseWorker.ReportProgress(0, "Sabar. Sedang baca database. . . ");
                var arguments = (ReaderArguments) e.Argument;
                using (
                    var writer = new ToGrouperWriter(arguments.inputFile, arguments.from, arguments.until,
                                                     arguments.kdCustomer))
                {
                    var line = 1;
                    while (writer.NextLine())
                    {
                        exportFromDatabaseWorker.ReportProgress(0, "Menulis textfile: " + line);
                        line++;
                    }
                }
                exportFromDatabaseWorker.ReportProgress(0, "Data telah export.");
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
                using (var reader = new FromGrouperReader(args.inputFile, args.outputFile, args.forVerifikator))
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
                RefreshPreview(UngroupableHandlingMode.OnlyUngroupable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error, tolong hubungi SIMRS dan berlapor ini: \\{0}", ex.Message));
            }
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
            var table = new RSKUPANGDataSet.inadrgDataTable();
            var reader = new CSVReader(Path.Combine(Application.StartupPath, Settings.Default.ToExcelFileName));
            var bindingSource = new TextFileBindingSource(reader, table, fromDateTimePicker.Value,
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

        private void GroupDiagnoses()
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.FileName = Path.Combine(Settings.Default.ThreeMHISDirectory,
                                                              Settings.Default.ThreeHMISExecutable);
                    process.StartInfo.Arguments = string.Format(" -i \"{0}\" -u \"{1}\" -p {2} -w ", Path.Combine(Application.StartupPath, Settings.Default.ToGrouperFileName),
                                                                Path.Combine(Application.StartupPath, Settings.Default.FromGrouperFileName), Settings.Default.GroupingProfile);
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error, tolong hubungi SIMRS dan berlapor ini: \\{0}", ex.Message));
            }
            ExportToExcel();
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GroupDiagnoses();
        }

    }
}