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
    public partial class diagArrangeSupplier : Form
    {
        public diagArrangeSupplier()
        {
            InitializeComponent();
        }

        private void diagArrangeSupplier_Load(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            foreach (DataRow row in BL.getSupplier().Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierBO BO = new SupplierBO();
            SupplierBL BL = new SupplierBL();
            int countsupp = 0;
            try
            {
                foreach (DataRow row in BL.getSupplier().Rows)
                {
                    countsupp++;
                }
                int[] duplicate = new int[countsupp];
                int outcount = 0;
                int incount = 0;
                int count = 0;
                int duplicatepriority = 0;
                bool toContinue = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    duplicate[count] = Convert.ToInt32(row.Cells[1].Value.ToString());
                    count++;
                }
                count = 0;
                foreach (int item in duplicate)
                {

                    foreach (int items in duplicate)
                    {
                        if (item == items)
                        {
                            if (outcount != incount)
                            {
                                duplicatepriority = item;
                                toContinue = false;
                                break;
                            }
                        }
                        incount++;
                        if (!toContinue)
                        {
                            break;
                        }
                    }
                    incount = 0;
                    outcount++;
                }
                if (toContinue)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        BO.supp1 = row.Cells[0].Value.ToString();
                        BO.prior = Convert.ToInt32(row.Cells[1].Value.ToString());
                        BL.updatePrioritySupplier(BO);

                    }
                    MessageBox.Show("Updating Complete");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("There is a duplicate priority!");
                    priority = duplicatepriority;
                    toContinue = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Numbers only allowed");
            }
        }
        int priority = 1;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void makeThisSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[selectedIndex].Cells[1].Value = priority;
            priority++;
            makeThisSupplierToolStripMenuItem.Text = "Set to priority " +priority;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        public int selectedIndex { get; set; }
    }
}
