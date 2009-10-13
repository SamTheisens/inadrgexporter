using System;
using System.Configuration;
using System.Windows.Forms;
using INADRGExporter.Properties;

namespace INADRGExporter
{
    struct ReaderArguments
    {
        public DateTime from;
        public DateTime until;
        public string kdCustomer;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = fromGrouperTextBox.Text;
            openFileDialog1.Filter = "*.txt";
            openFileDialog1.ShowDialog();
        }
        private static string PromptForConnectionString(string currentConnectionString)
        {
            MSDASC.DataLinks dataLinks = new MSDASC.DataLinksClass();
            ADODB.Connection dialogConnection;
            string generatedConnectionString = string.Empty;

            if (currentConnectionString == String.Empty)
            {
                dialogConnection = (ADODB.Connection)dataLinks.PromptNew();
                generatedConnectionString = dialogConnection.ConnectionString;
            }
            else
            {
                dialogConnection = new ADODB.Connection {Provider = "SQLOLEDB.1"};
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
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["INADRGReader.Properties.Settings.RSKUPANGConnectionString"].
                ConnectionString = generatedConnectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = inadrgTableAdapter.GetData(fromDateTimePicker.Value, untilDateTimePicker.Value);
            var arguments = new ReaderArguments
                                {
                                    from = fromDateTimePicker.Value,
                                    until = untilDateTimePicker.Value,
                                    kdCustomer = comboBoxCustomer.SelectedValue.ToString()
                                };
            exportWorker.RunWorkerAsync(arguments);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
            exportWorker.ReportProgress(0, "Sabar. Sedang baca database. . . ");
            var arguments = (ReaderArguments) e.Argument;
            using (var writer = new ToGrouperWriter(arguments.from, arguments.until, arguments.kdCustomer))
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

        private void progressLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rSKUPANGDataSetCustomer.CUSTOMER' table. You can move, or remove it, as needed.
            cUSTOMERTableAdapter.Fill(rSKUPANGDataSetCustomer.CUSTOMER);
            comboBoxCustomer.SelectedIndex = 3;
            comboBoxCustomer.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PromptForConnectionString(ConfigurationManager.ConnectionStrings["INADRGReader.Properties.Settings.RSKUPANGConnectionString"].ConnectionString);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inadrgTableAdapter.GetData(fromDateTimePicker.Value, untilDateTimePicker.Value,
                                                                  comboBoxCustomer.SelectedValue.ToString());
        }

    }
}
