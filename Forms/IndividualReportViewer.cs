using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using InadrgExporter.Properties;

namespace InadrgExporter.Forms
{
    public partial class IndividualReportViewer : Form
    {
        private ReportDocument individualReport;
        public RSKUPANGDataSet.inadrgDataTable IndividualsDataSet { get; set; }
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
            IndividualsDataSet.TarifColumn.AllowDBNull = true;

            try
            {
                individualReport.SetDataSource((DataTable)IndividualsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMessage, ex.Message), Resources.ErrorTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            crystalReportViewer1.ReportSource = individualReport;
        }
    }
}