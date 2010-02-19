using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using InadrgExporter.DataSources;
using InadrgExporter.FileReaderCollections;
using InadrgExporter.Forms;
using InadrgExporter.Properties;

namespace InadrgExporter.Forms
{
    public struct ExporterArguments
    {
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string KdCustomer { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public bool ForVerifikator { get; set; }
        public UngroupableHandlingMode UngroupableHandlingMode { get; set; }
    }

    enum Task {ExportFromDatabase, Group, ExportToExcel}

    enum PreviewMode { Database, TextFile }

    public partial class ExporterForm : Form
    {
        private PreviewMode previewMode = PreviewMode.Database;
        private DateTime groupedFrom, groupedUntil;
        private PreviewBindingSource currentBindingSource;
        private DataTable currentTable;

        public bool ShowFailedGroupingsOnly { get; set; }

        #region Construction
        public ExporterForm()
        {
            ShowFailedGroupingsOnly = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cUSTOMERTableAdapter.Fill(customerDataset.CUSTOMER);
            comboBoxCustomer.SelectedIndex = 3;
            fromDateTimePicker.Value = new DateTime(2009, 6, 1);
            untilDateTimePicker.Value = new DateTime(2009, 6, 30);
            Text += " - " + Settings.Default.NamaRumahSakit + " - Type " +
                    Settings.Default.RumahSakit[Settings.Default.TypeRumahSakit];
        }
        #endregion Construction

        #region HelperFunctions

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

            if (currentConnectionString.Length == 0)
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
        #endregion HelperFunctions

        #region ButtonEventHandlers
        private void refreshButton_Click(object sender, EventArgs e)
        {
            var arguments = new ExporterArguments
                                {
                                    From = fromDateTimePicker.Value,
                                    Until = untilDateTimePicker.Value,
                                    KdCustomer = comboBoxCustomer.SelectedValue.ToString(),
                                    OutputFile =
                                        Path.Combine(Application.StartupPath, Settings.Default.ToGrouperFileName),
                                    ForVerifikator = false
                                };
            groupedFrom = arguments.From;
            groupedUntil = arguments.Until;
            exportFromDatabaseWorker.RunWorkerAsync(arguments);
        }

        private void exportWithDemographics_Click(object sender, EventArgs e)
        {
            var outputFileName = OpenFileDialog(Resources.WithDemographicsFileName);
            if (outputFileName.Length == 0)
                return;
            var arguments = new ExporterArguments
            {
                InputFile = Path.Combine(Application.StartupPath, Settings.Default.FromGrouperFileName),
                OutputFile = outputFileName, 
                UngroupableHandlingMode = UngroupableHandlingMode.SkipUngroupable,
                ForVerifikator = false
            };
            exportkeExcelWorker.RunWorkerAsync(arguments);
        }

        private void toolStripMenuItemChangeConnectionstring_Click(object sender, EventArgs e)
        {
            PromptForConnectionString(Settings.Default.RSKUPANGConnectionString);
        }
        
        private void aboutINADRGExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        
        private void exportForVerifikator_Click(object sender, EventArgs e)
        {
            var outputFileName = OpenFileDialog(Resources.WithoutDemographicsFileName);
            if (outputFileName.Length == 0)
                return;

            var arguments = new ExporterArguments
            {
                InputFile = Path.Combine(Application.StartupPath, Settings.Default.FromGrouperFileName),
                OutputFile = outputFileName, 
                UngroupableHandlingMode = UngroupableHandlingMode.SkipUngroupable,
                ForVerifikator = true
            };

            exportkeExcelWorker.RunWorkerAsync(arguments);
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
        
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.Database;
            RefreshPreview(fromDateTimePicker.Value, untilDateTimePicker.Value,
                           comboBoxCustomer.SelectedValue.ToString(), UngroupableHandlingMode.None);
        }
        
        private void keExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.TextFile;
            RefreshPreview(fromDateTimePicker.Value, untilDateTimePicker.Value,
                           comboBoxCustomer.SelectedValue.ToString(), UngroupableHandlingMode.IncludeUngroupable);
        }
        
        private void excelYangSalahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewMode = PreviewMode.TextFile;
            RefreshPreview(fromDateTimePicker.Value, untilDateTimePicker.Value,
                           comboBoxCustomer.SelectedValue.ToString(), UngroupableHandlingMode.OnlyUngroupable);
        }

        private void compareOldFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputFileName = OpenFileDialog(Resources.WithoutDemographicsFileName);
            if (inputFileName.Length == 0)
                return;

            var arguments = new ExporterArguments
                                {
                                    InputFile = inputFileName,
                                    UngroupableHandlingMode = UngroupableHandlingMode.IncludeUngroupable,
                                    From = fromDateTimePicker.Value,
                                    Until = untilDateTimePicker.Value,
                                    ForVerifikator = true
                                };

            var datasource = new DatabaseDataSource(arguments.From, arguments.Until,
                                                    comboBoxCustomer.SelectedValue.ToString(),
                                                    new RSKUPANGDataSet.inadrgDataTable());
            var comparer = new RepairsComparer(datasource, arguments);
            var bindingSource = new PreviewBindingSource(comparer, new RSKUPANGDataSet.inadrgDataTable(), arguments.From,
                                                         arguments.Until, Int32.MaxValue);
            bindingSource.Refresh();
            currentBindingSource = bindingSource;
            bindingNavigator1.BindingSource = currentBindingSource;
            dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
            dataGridView1.CellFormatting += dataGridView1_CompareCellFormatting;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = currentBindingSource.DataSource;
        }

        #endregion ButtonEventHandlers

        #region ProgressHandlers
        private void exportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = true;
            exportGridKeExcelProgressBar.Value = e.ProgressPercentage;
            toolStripStatusLabel.Text = e.UserState.ToString();
            Cursor = e.UserState.ToString() == "Data telah export." ? Cursors.Default : Cursors.WaitCursor;
        }

        private void exportGridKeExcelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = true;
            exportGridKeExcelProgressBar.Value = e.ProgressPercentage;
        }

        private static void ReportProgress(BackgroundWorker backgroundWorker, int percentage, int linesRead, int linesWritten)
        {
            backgroundWorker.ReportProgress(percentage,
                                               string.Format(CultureInfo.CurrentCulture, Resources.LinesReadWritten, linesRead, linesWritten));
        }
        #endregion ProgressHandlers

        #region WorkerThreads
        private void refreshPreviewWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var arguments = (ExporterArguments)e.Argument;

            dataGridView1.CellFormatting -= dataGridView1_CompareCellFormatting;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;


            var table = new RSKUPANGDataSet.inadrgDataTable();
            int stepSize;
            IDataSource datasource;
            if (previewMode == PreviewMode.Database)
            {
                datasource = new DatabaseDataSource(arguments.From, arguments.Until, arguments.KdCustomer,
                                                    new RSKUPANGDataSet.inadrgDataTable());
                stepSize = Settings.Default.PreviewSize;
            }
            else
            {
                var reader =
                    new CsvReaderCollection(Path.Combine(Application.StartupPath, arguments.InputFile), GrouperHelper.ReadMapping("dic_excel_mapping.dic"));
                datasource = new TextFileDataSource(reader, arguments.UngroupableHandlingMode, table);
                stepSize = Int32.MaxValue;
            }
            var bindingSource = new PreviewBindingSource(datasource, table, arguments.From, arguments.Until, stepSize);
            bindingSource.Refresh();
            currentBindingSource = bindingSource;
        }
        
        private void exportGridKeExcelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //var args = (ExporterArguments)e.Argument;
            //DataTable dataTable;
            //using (var connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            //{
            //    connection.Open();
            //    var selectCommand = string.Format("", GrouperHelper.ToSqlDate(args.From),
            //                                      GrouperHelper.ToSqlDate(args.Until), args.KdCustomer
            //                                      , string.Empty);
            //    inadrgTableAdapter.Adapter.SelectCommand = new SqlCommand(selectCommand, connection);
            //    dataTable = new RSKUPANGDataSet.inadrgDataTable();
            //}
            //inadrgTableAdapter.Adapter.Fill(dataTable);

            //ToExcelExporter.WriteToExcelSpreadsheet(@"c:\hoi.xls", dataTable, sender as BackgroundWorker);
        }
        
        private void exportFromDatabaseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var arguments = (ExporterArguments)e.Argument;
            var backgroundWorker = (BackgroundWorker) sender;
            try
            {
                exportFromDatabaseWorker.ReportProgress(0, "Sabar. Sedang baca database. . . ");
                using (
                    var writer = new ToGrouperWriter(arguments.OutputFile, arguments.From, arguments.Until,
                                                     arguments.KdCustomer))
                {
                    var line = 1;
                    while (writer.NextLine())
                    {
                        exportFromDatabaseWorker.ReportProgress((int)(((double)line / writer.Length) * 100.0), "Menulis textfile: " + line);
                        line++;
                    }
                    currentTable = writer.Table;
                }

                exportFromDatabaseWorker.ReportProgress(0, "Data telah export.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMessage, ex.Message), Resources.ErrorTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            arguments.InputFile = Path.Combine(Application.StartupPath, Settings.Default.ToGrouperFileName);
            arguments.OutputFile = Path.Combine(Application.StartupPath, Settings.Default.FromGrouperFileName);
            GroupDiagnoses(backgroundWorker, arguments);
        }
        
        private void exportkeExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var arguments = (ExporterArguments)e.Argument;
                var backgroundWorker = (BackgroundWorker) sender;
                
                var idatasource = new TextFileDataSource(new FieldWidthReaderCollection(arguments.InputFile,
                                                                                           GrouperHelper.ReadDictionary(
                                                                                               "cgs_ina_out.dic"), GrouperHelper.ReadMapping("dic_excel_mapping.dic")),
                                                            arguments.UngroupableHandlingMode, new RSKUPANGDataSet.inadrgDataTable());
                using (var reader = new FromGrouperReader(currentTable, idatasource, arguments.OutputFile, arguments.ForVerifikator, arguments.UngroupableHandlingMode))
                {
                    var linesRead = 0;
                    var linesWritten = 0;
                    var linesReadLastTime = -1;
                    const int stepSize = 200;

                    reader.WriteHeaders();

                    while (linesRead > linesReadLastTime && !reader.EndOfData())
                    {
                        linesReadLastTime = linesRead;

                        while (reader.ReadNextLine())
                        {
                            linesRead++;
                            if (linesRead % stepSize == 0)
                                break;
                            ReportProgress(backgroundWorker, (int)(((double)linesWritten / reader.Length) * 100.0), linesRead, linesWritten);
                        }

                        reader.ExecuteQuery();
                        while (reader.WriteLine())
                        {
                            linesWritten++;
                            if (linesWritten % stepSize == 0)
                                break;
                            ReportProgress(backgroundWorker, (int)(((double)linesWritten / reader.Length) * 100.0), linesRead, linesWritten);
                        }
                        reader.ClearTempDB();
                    }
                }
                idatasource.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMessage, ex.Message), Resources.ErrorTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }

        }
        
        #endregion WorkerThreads

        #region Commands
        private void ExportToExcel(BackgroundWorker backgroundWorker, ExporterArguments arguments)
        {
            arguments.UngroupableHandlingMode = UngroupableHandlingMode.IncludeUngroupable;
            exportkeExcel_DoWork(backgroundWorker, new DoWorkEventArgs(arguments));
        }

        private void RefreshPreview(DateTime from, DateTime until, string kdCustomer, UngroupableHandlingMode ungroupableHandlingMode)
        {
            exportGridKeExcelProgressBar.Style = ProgressBarStyle.Marquee;
            exportGridKeExcelProgressBar.Visible = true;
            bindingNavigator1.Enabled = previewMode != PreviewMode.TextFile;

            var args = new ExporterArguments
                           {
                               From = from,
                               Until = until,
                               KdCustomer = kdCustomer,
                               UngroupableHandlingMode = ungroupableHandlingMode,
                               ForVerifikator = false,
                               InputFile = Settings.Default.ToExcelFileName
                           };
            refreshPreviewWorker.RunWorkerAsync(args);
        }

        private void GroupDiagnoses(BackgroundWorker backgroundWorker, ExporterArguments arguments)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.FileName = Path.Combine(Settings.Default.ThreeMHISDirectory,
                                                              Settings.Default.ThreeHMISExecutable);
                    process.StartInfo.Arguments = string.Format(CultureInfo.InvariantCulture,
                                                                Settings.Default.ThreeMHISCommandLine,
                                                                Path.Combine(Application.StartupPath,
                                                                             arguments.InputFile),
                                                                Path.Combine(Application.StartupPath,
                                                                             arguments.OutputFile),
                                                                Settings.Default.GroupingProfile);
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMessage, ex.Message), Resources.ErrorTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            arguments.InputFile = Path.Combine(Application.StartupPath, Settings.Default.FromGrouperFileName);
            arguments.OutputFile = Path.Combine(Application.StartupPath, Settings.Default.ToExcelFileName);
            ExportToExcel(backgroundWorker, arguments);
        }
        #endregion Commands

        #region EventHandlers
        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (fromDateTimePicker.Value > untilDateTimePicker.Value)
                untilDateTimePicker.Value = fromDateTimePicker.Value;
            CheckGroupedRange();
        }

        private void untilDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (untilDateTimePicker.Value < fromDateTimePicker.Value)
                fromDateTimePicker.Value = untilDateTimePicker.Value;
            CheckGroupedRange();
        }

        private void ExporterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }


        //private void exportGridKeExcelButton_Click(object sender, EventArgs e)
        //{
        //    exportGridKeExcelProgressBar.Visible = true;
        //    var args = new ExporterArguments
        //                   {
        //                       From = fromDateTimePicker.Value,
        //                       Until = untilDateTimePicker.Value,
        //                       KdCustomer = comboBoxCustomer.SelectedValue.ToString()
        //                   };
        //    exportGridKeExcelWorker.RunWorkerAsync(args);
        //}
        #endregion EventHandlers

        #region CompletedHandlers
        private void exportGridKeExcelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = false;
            Cursor = Cursors.Arrow;
            CheckGroupedRange();
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportGridKeExcelProgressBar.Visible = false;
            Cursor = Cursors.Arrow;
            CheckGroupedRange();
        }
        #endregion CompletedHandlers

        private void OpenReportViewer(string reportFileName)
        {
            var table = new RSKUPANGDataSet.inadrgDataTable();
            var idatasource =
                new TextFileDataSource(
                    new CsvReaderCollection(Path.Combine(Application.StartupPath, Settings.Default.ToExcelFileName), GrouperHelper.ReadMapping("dic_excel_mapping.dic")),
                    UngroupableHandlingMode.SkipUngroupable, table);
            var bindingSource = new PreviewBindingSource(idatasource, table, fromDateTimePicker.Value,
                                                          untilDateTimePicker.Value, Int32.MaxValue);
            bindingSource.Refresh();

            var viewer = new IndividualReportViewer { IndividualsDataSet = table, ReportFileName = reportFileName };
            viewer.ShowDialog();
        }
        private void CheckGroupedRange()
        {
            if (fromDateTimePicker.Value < groupedFrom || untilDateTimePicker.Value > groupedUntil)
            {
                refreshButton.BackColor = Color.Red;
                refreshButton.ToolTipText = Resources.RegroupNeededToolTip;
                keExcelToolStripMenuItem.Enabled = true;
                excelYangSalahToolStripMenuItem.Enabled = true;
                exportDropDownButton.Enabled = true;
            }
            else
            {
                refreshButton.BackColor = Color.Transparent;
                refreshButton.ToolTipText = Resources.RegroupToolTip;
                keExcelToolStripMenuItem.Enabled = true;
                excelYangSalahToolStripMenuItem.Enabled = true;
                exportDropDownButton.Enabled = true;
            }
        }

        private void refreshPreviewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportGridKeExcelProgressBar.Style = ProgressBarStyle.Blocks;
            exportGridKeExcelProgressBar.Visible = false;
            bindingNavigator1.BindingSource = currentBindingSource;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = currentBindingSource.DataSource;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            var view = (DataGridView) sender;
            var currentColumn = view.Columns[e.ColumnIndex];
            var cell = view[e.ColumnIndex, e.RowIndex];

            if (currentColumn.ValueType == typeof(int))
            {
                if (cell.Value != DBNull.Value && (int)cell.Value < 0) cell.Style.BackColor = Color.Red;
            }

            switch (currentColumn.DataPropertyName)
            {
                case "JK":
                    cell.Style.BackColor = (int)cell.Value == 1 ? Color.LightBlue : Color.LightPink;
                    break;
                case "Jnsrawat":
                    cell.Style.BackColor = (int)cell.Value == 1 ? Color.PaleGreen : Color.Moccasin;
                    break;
                default:
                    break;
            }
        }
        private static void dataGridView1_CompareCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            var view = (DataGridView)sender;
            var currentColumn = view.Columns[e.ColumnIndex];
            var cell = view[e.ColumnIndex, e.RowIndex];

            var row = view.Rows[e.RowIndex];
            var changeCell = row.Cells["Perubahan"].Value;
            if (changeCell != DBNull.Value)
            {
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                string changes = (string)changeCell;
                var columns = changes.Split(';');
                foreach (string change in columns)
                {
                    if (change.Length == 0)
                        continue;
                    var pair = change.Split(':');
                    string columnName = pair[0];
                    string beforeAfter = pair[1];
                    if (currentColumn.DataPropertyName == columnName)
                    {
                        cell.ToolTipText = beforeAfter;
                        e.CellStyle.BackColor = Color.DarkRed;
                        e.CellStyle.ForeColor = Color.White;
                        
                    }
                }
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }

        }


    }
}