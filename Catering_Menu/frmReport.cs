using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Catering_Menu
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        CateringBL CatBL;
        CateringBO CatBO;
        SupplierBL BL;
        SupplierBO BO;
        string catid = "";
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            BL=new SupplierBL();
            BO=new SupplierBO();
            DataTable dt = new DataTable();
            DataTable amounts = new DataTable();
            DataTable suppliers= BL.getSupplier();
            List<string> supps = new List<string>();
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            dt.Columns.Add("6");
            dt.Columns.Add("7");
            dt.Columns.Add("8");
            dt.Columns.Add("9");
            dt.Columns.Add("10");
            dt.Columns.Add("11");
            dt.Columns.Add("12");
            dt.Columns.Add("13");
            dt.Columns.Add("14");
            dt.Columns.Add("15");
            dt.Columns.Add("16");
            dt.Columns.Add("17");
            dt.Columns.Add("18");
            dt.Columns.Add("19");
            dt.Columns.Add("20");
            dt.Columns.Add("21");
            dt.Columns.Add("22");
            List<decimal> totalExp = new List<decimal>();
            var tExp = new Dictionary<string, decimal>();
            int count = 0;
            for (int i = 0; i < 20; i++)
            {
                supps.Add("");
                totalExp.Add(0);
            }
                if (Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")) <= Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd")))
                {
                    CatBL = new CateringBL();
                    CatBO = new CateringBO();
                    decimal exp = 0;
                    CatBO.dateF = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    CatBO.dateT = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    if (comboBox1.Text=="BOTH")
                    {
                        CatBO.Status = "";
                    }
                    else if (comboBox1.Text == "ACTIVE")
                    {
                        CatBO.Status = "DONE";
                    }
                    else if (comboBox1.Text == "DONE")
                    {
                        CatBO.Status = "ACTIVE";
                    }

                    DataTable disec = CatBL.showReport(CatBO);
                    string showonce = "";
                    int numberofevent = disec.Rows.Count;
                    foreach (DataRow nameOfSupplier in suppliers.Rows)
                    {
                        supps[count]=(nameOfSupplier.ItemArray[0].ToString());
                        tExp.Add(nameOfSupplier.ItemArray[0].ToString(), 0);
                        count++;
                    }
                    count = 0;
                    int diff=supps.Count-tExp.Count;
                    int supptigil = tExp.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        tExp.Add("Vacant"+(i+1), 0);
                        supps[supptigil]  = ("Vacant"+(i+1));
                        supptigil++;
                    }
                    dt.Rows.Add("", supps[0], supps[1], supps[2], supps[3], supps[4], supps[5], supps[6], supps[7], supps[8], supps[9], supps[10], supps[11], supps[12], supps[13], supps[14], supps[15], supps[16], supps[17], supps[18], supps[19], "Total Expense");
                    foreach (DataRow eventdetail in disec.Rows)
                    {
                        dt.Rows.Add(eventdetail.ItemArray[5].ToString());
                        if (showonce == eventdetail.ItemArray[5].ToString() && dt.Rows.Count != 0)
                        {
                            dt.Rows.RemoveAt(dt.Rows.Count - 1);
                        }
                        showonce = eventdetail.ItemArray[5].ToString();
                        catid = eventdetail.ItemArray[8].ToString();
                        BO.catid = catid;
                        amounts = BL.getSupplierBudget(BO);
                        foreach (DataRow amount in amounts.Rows)
                        {
                            totalExp[count] = (Convert.ToDecimal(amount.ItemArray[2].ToString()));
                            tExp[amount.ItemArray[1].ToString()]= (Convert.ToDecimal(amount.ItemArray[2].ToString()));
                            count++; 
                        }

                        dt.Rows.Add(eventdetail.ItemArray[2].ToString() + " (" + eventdetail.ItemArray[3].ToString() + ")(" + eventdetail.ItemArray[6].ToString() + ")(" + eventdetail.ItemArray[7].ToString() + ")", "P " + tExp[supps[0]], "P " + tExp[supps[1]], "P " + tExp[supps[2]], "P " + tExp[supps[3]], "P " + tExp[supps[4]], "P " + tExp[supps[5]], "P " + tExp[supps[6]], "P " + tExp[supps[7]], "P " + tExp[supps[8]], "P " + tExp[supps[9]], "P " + tExp[supps[10]], "P " + tExp[supps[11]], "P " + tExp[supps[12]], "P " + tExp[supps[13]], "P " + tExp[supps[14]], "P " + tExp[supps[15]], "P " + tExp[supps[16]], "P " + tExp[supps[17]], "P " + tExp[supps[18]], "P " + tExp[supps[19]], "P " + totalExp.Sum().ToString("0.##"));
                        exp = exp + totalExp.Sum();
                        totalExp.Clear();
                        for (int i = 0; i < 20; i++)
                        {
                            totalExp.Add(0);
                            supps.Add("");
                        }
                        count = 0;
                    }
                    dt.Rows.Add("Number of Events : " + numberofevent, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Total Expense: ", "P " + exp);
                    OverallReport cr = new OverallReport();
                    cr.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = cr;
                }
                else
                {

                }
            }
          

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
