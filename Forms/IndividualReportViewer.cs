using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using INADRGExporter.Properties;

namespace INADRGExporter.Forms
{
    public partial class IndividualReportViewer : Form
    {
        private ReportDocument individualReport;
        public RSKUPANGDataSet.inadrgDataTable IndividualsDataset { get; set; }
        public string ReportFileName { get; set; }

        public IndividualReportViewer()
        {
            InitializeComponent();
        }

        private void IndividualReportViewer_Load(object sender, EventArgs e)
        {
            individualReport = new ReportDocument();
            string reportPath = Path.Combine(Application.StartupPath, ReportFileName);
            individualReport.Load(reportPath);
            IndividualsDataset.TarifColumn.AllowDBNull = true;

            try
            {
                individualReport.SetDataSource((DataTable)IndividualsDataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorMessage, ex.Message);
            }
            crystalReportViewer1.ReportSource = individualReport;

        }
    }
}