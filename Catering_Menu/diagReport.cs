using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Catering_Menu
{
    public partial class diagReport : Form
    {
        public diagReport(DataTable dt,string clientname)
        {
            InitializeComponent();
            eventDetails = dt;
            clientnamE = clientname;
        }
        string clientnamE = "";
        DataTable eventDetails;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        public string formula { get; set; }

        public int lngthofstring { get; set; }

        private void frmManageMenu_Load(object sender, EventArgs e)
        {

            this.Text = "Reporting";
            if (clientnamE == "PO")
            {
                this.Text = clientnamE + " event";
                CrystalReport2 eventss = new CrystalReport2();
                eventss.SetDataSource(eventDetails);
                CrystalDecisions.Shared.ExcelFormatOptions XLSFormatOptions = new CrystalDecisions.Shared.ExcelFormatOptions();
                XLSFormatOptions.ShowGridLines = true;
                XLSFormatOptions.ExportPageBreaksForEachPage = true;
                crystalReportViewer1.ReportSource = eventss; 
            }
            else if (clientnamE == "Summary")
            {
                this.Text = clientnamE + " event";
                SummaryReport eventss = new SummaryReport();
                eventss.SetDataSource(eventDetails);
                crystalReportViewer1.ReportSource = eventss;
            }
            else if (clientnamE == "OverallReport")
            {
                this.Text = "Selected events Summary";
                OverallReport eventss = new OverallReport();
                eventss.SetDataSource(eventDetails);
                crystalReportViewer1.ReportSource = eventss;
            }
            else
            {

                CrystalReport1 eventss = new CrystalReport1();
                int exportFormatFlags = (int)(CrystalDecisions.Shared.ViewerExportFormats.PdfFormat | CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat);
                crystalReportViewer1.AllowedExportFormats = exportFormatFlags;
                eventss.SetDataSource(eventDetails);
                crystalReportViewer1.ReportSource = eventss; 
            }
        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
