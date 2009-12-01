using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace INADRGExporter
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
                
            }
            crystalReportViewer1.ReportSource = individualReport;

        }
    }
}
