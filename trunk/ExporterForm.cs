using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using INADRGExporter.Properties;
using Mmm.His.Cgs.AppPlg.Batch;
using Mmm.His.Cgs.CGSMainForms;
using Mmm.His.Prm.Std.Global;

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
    public partial class ExporterForm : Form
    {
        private readonly string commandText;
        private const int selectionWindowSize = 10;
        private int selectionWindowStart;
        public ExporterForm()
        {
            InitializeComponent();
            using (var reader = new StreamReader("SelectInadrg.sql"))
            {
                commandText = reader.ReadToEnd();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = fromGrouperTextBox.Text;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
        }
        private static string PromptForConnectionString(string currentConnectionString)
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
            return "";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = inadrgTableAdapter.GetData(fromDateTimePicker.Value, untilDateTimePicker.Value);
            var arguments = new ReaderArguments
                                {
                                    from = fromDateTimePicker.Value,
                                    until = untilDateTimePicker.Value,
                                    kdCustomer = comboBoxCustomer.SelectedValue.ToString(),
                                    inputFile = fromGrouperTextBox.Text
                                };
            exportWorker.RunWorkerAsync(arguments);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            exportWorker.ReportProgress(0, "Sabar. Sedang baca database. . . ");
            var arguments = (ReaderArguments)e.Argument;
            using (var writer = new ToGrouperWriter(arguments.inputFile, arguments.from, arguments.until, arguments.kdCustomer))
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

        private void exportWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.UserState.ToString();
            Cursor = e.UserState.ToString() == "Data telah export." ? Cursors.Default : Cursors.WaitCursor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cUSTOMERTableAdapter.Fill(rSKUPANGDataSetCustomer.CUSTOMER);
            comboBoxCustomer.SelectedIndex = 3;
            comboBoxCustomer.Refresh();
            fromDateTimePicker.Value = new DateTime(2009,6,20);
            untilDateTimePicker.Value = new DateTime(2009, 6, 20);
        }

        private void toolStripMenuItemChangeConnectionstring_Click(object sender, EventArgs e)
        {
            PromptForConnectionString(Settings.Default.RSKUPANGConnectionString);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectionWindowStart = 0;
            RefreshPreview();
//            dataGridView1.DataSource = inadrgTableAdapter.GetData(fromDateTimePicker.Value, untilDateTimePicker.Value,
//                                                                  );
        }

        private void RefreshPreview()
        {
            using (var connection = new SqlConnection(Settings.Default.RSKUPANGConnectionString))
            {
                connection.Open();
                var selectCommand = string.Format(commandText, GrouperHelper.ToSQLDate(fromDateTimePicker.Value),
                                                  GrouperHelper.ToSQLDate(untilDateTimePicker.Value),
                                                  comboBoxCustomer.SelectedValue,
                                                  string.Format("WHERE Recid between {0} and {1}", selectionWindowStart + 1, selectionWindowStart + selectionWindowSize));
                inadrgTableAdapter.Adapter.SelectCommand = new SqlCommand(selectCommand, connection);
                var dataTable = new RSKUPANGDataSet.inadrgDataTable();
                inadrgTableAdapter.Adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                selanjutnyaButton.Enabled = dataTable.Rows.Count >= selectionWindowSize;
                sebelumnyaButton.Enabled = selectionWindowStart > 0;
                dataGridView1.Refresh();
            }
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            untilDateTimePicker.MinDate = fromDateTimePicker.Value;
        }

        private void untilDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDateTimePicker.MaxDate = untilDateTimePicker.Value;
        }

        private void exportkeExcelButton_Click(object sender, EventArgs e)
        {
            var arguments = new ReaderArguments
            {
                inputFile = inputExcelTextBox.Text,
                outputFile = outputExcelTextBox.Text
            };

            exportkeExcelWorker.RunWorkerAsync(arguments);
        }

        private void exportkeExcel_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = (ReaderArguments) e.Argument;
            using (var reader = new FromGrouperReader(args.inputFile, args.outputFile))
            {
                var linesRead = 0;
                var linesWritten = 0;
                var linesReadLastTime = -1;
                const int stepsize = 200;
                while (linesRead > linesReadLastTime && !reader.endOfData())
                {
                    linesReadLastTime = linesRead;
                    while (reader.readNextLine())
                    {
                        linesRead++;
                        if (linesRead % stepsize == 0)
                            break;
                        ReportProgress(linesRead, linesWritten);
                    }
                    reader.executeQuery();
                    while (reader.writeLine())
                    {
                        linesWritten++;
                        if (linesWritten % stepsize == 0)
                            break;
                        ReportProgress(linesRead, linesWritten);
                    }
                    reader.clearTempDB();
                }
            }
        }

        private void ReportProgress(int linesRead, int linesWritten)
        {
            exportkeExcelWorker.ReportProgress(0,
                                               string.Format("Lines read: {0}. Lines written: {1}",
                                                             linesRead,
                                                             linesWritten));
        }

        private void exportkeExcel_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            label5.Text = e.UserState.ToString();
        }

        private void ExporterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CGSGlobalCommandLine.GetInstance();
            string commandLine = "-O ";
            var frm = new UsageForm();
            frm.ShowDialog();

            GlobalContainer.CreateInstance(@"C:\3mhis\3M_CGS\3M CGS INA");
            CGSProcessBatch batch = new CGSProcessBatch();
            var directories = Directories.GetInstance();
            //directories.InstanceFilePath = @"C:\3mhis\3M_CGS\3M CGS INA";
            //directories.StdReportsFilePath = Path(@"C:\3mhis\3M_CGS\3M CGS INA\common\config\groupingprofiles");
                
            string profile = @"C:\3mhis\3M_CGS\3M CGS INA\common\config\groupingprofiles\default.pro";
            CGSGroupingProfile profieletje = new CGSGroupingProfile();
            profieletje.LoadFromXml(@"default.pro");
            profieletje.InFile = @"C:\kegrouper-dari-inadrg.txt";
            profieletje.OutFile = @"C:\batch-output.txt";
            string errorstr = "Errortjes : \\n";
            foreach (var error in profieletje.ErrorList())
            {
                errorstr += error.Errortext + @"\n";
            }

            if (profieletje.HasErrors())
            {
                MessageBox.Show(errorstr);
            }
            profieletje.SaveToXml(@"c:\profielo.tdxt");
                batch.InitFromParameterObject(profieletje);

            var errors = batch.Execute(@"C:\kegrouper-dari-inadrg.txt", @"C:\batch-output.txt", @"C:\poep.rpt", "", true);
            errorstr = "Errortjes : \\n";
           
            foreach (var error in errors)
            {
                errorstr += error.Errortext + @"\n";
            }
            MessageBox.Show(errorstr, "Errors!");
            Thread.Sleep(4000);

///            Execute(string infile, string outfile, string preportfile, string pauditfile, bool overwrite)

        }

        private void selanjutnyaButton_Click(object sender, EventArgs e)
        {
            selectionWindowStart += selectionWindowSize;
            RefreshPreview();
        }

        private void sebelumnyaButton_Click(object sender, EventArgs e)
        {
            selectionWindowStart -= selectionWindowSize;
            RefreshPreview();
        }
    }
}
