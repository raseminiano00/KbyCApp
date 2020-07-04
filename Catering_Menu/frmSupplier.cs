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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable newsupp = new DataTable();
        DataTable oldsupp = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to rename supplier named " + textBox1.Text + " to " + textBox2.Text, "Update", MessageBoxButtons.YesNo);
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            BO.supp1 = textBox1.Text;
            bool notExistText1 = true;
            foreach (DataRow row in BL.searchSupp(BO).Rows)
            {
                notExistText1 = false;
            }
            try
            {
                if (!notExistText1)
                {
                    if (textBox2.Text != "")
                    {
                        BO.old = selectedsupp;
                        BO.supp1 = textBox2.Text.Trim();
                        BL.updateSupplier(BO);
                        loadSupplier();
                        textBox1.Text = "";
                        textBox2.Text = ""; MessageBox.Show("Success!");  
                    }
                    else
                    {
                        MessageBox.Show("Please input the altered name of supplier!");
                    }
                } 
                else
                {
                    MessageBox.Show("There's no such a supplier named " + textBox1.Text);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Entered supplier is already registered!");
            }
           
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadSupplier();

        }
        public void loadSupplier()
        {
            SupplierBL bl = new SupplierBL();
            SupplierBO bo = new SupplierBO();
            oldsupp = bl.getSupplier();
            dataGridView1.Rows.Clear();
            foreach (DataRow supp in bl.getSupplier().Rows)
            {
                dataGridView1.Rows.Add(supp.ItemArray[0].ToString());
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                selectedsupp = row.Cells[0].Value.ToString();
                textBox1.Text = selectedsupp;

            }
        }

        public string selectedsupp { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierBL bl = new SupplierBL();
            SupplierBO bo = new SupplierBO();
            int count = 0;
            foreach (DataRow row in bl.getSupplier().Rows)
            {
                count++;
            }
            try
            {
                if (textBox4.Text != "")
                {
                    if (count != 20)
                    {
                        bo.supp1 = textBox4.Text;
                        bl.addSupp(bo);
                        loadSupplier();
                        textBox4.Text = "";
                        MessageBox.Show("Success!"); 
                    }
                    else
                    {
                        MessageBox.Show("Supplier allowed is 20 only");
                    }
                }
                else
                {
                    MessageBox.Show("Enter the name of supplier!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot add existing");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SupplierBL bl = new SupplierBL();
            SupplierBO bo = new SupplierBO();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + textBox1.Text + " and transfer the data to " + textBox2.Text + Environment.NewLine + Environment.NewLine +
                "NOTE : All data of deleted supplier will be transfered to " + textBox2.Text + Environment.NewLine + Environment.NewLine +
                "ADVICE : If you there's no substitute for the deletion , create a temporary supplier that will be dummy of deleted supplier to keep the data accurate", "Delete Supplier", MessageBoxButtons.YesNo);
            bo.supp1 = textBox2.Text;
            bool notExistTextBox2 = true;
            foreach (DataRow row in bl.searchSupp(bo).Rows)
            {
                notExistTextBox2 = false;
            }
            if (dialogResult == DialogResult.Yes)
            {
                if (textBox2.Text != "")
                {
                    if (!notExistTextBox2)
                    {
                        bo.supp1 = textBox1.Text;
                        bo.supp2 = textBox2.Text;
                        bl.delSupp(bo);
                        textBox2.Text = "";
                        textBox1.Text = "";
                        loadSupplier(); MessageBox.Show("Success!");   
                    }
                    else
                    {
                        MessageBox.Show("There's no such a supplier named " + textBox2.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Please input the destination of deleted supplier's data");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to transfer all data of " + textBox1.Text + " to " +textBox2.Text, "Transfer", MessageBoxButtons.YesNo);

            SupplierBL bl = new SupplierBL();
            SupplierBO bo = new SupplierBO();
            bo.supp1 = textBox2.Text;
            bool notExistTextBox2=true;
            foreach (DataRow row in bl.searchSupp(bo).Rows)
	            {
		             notExistTextBox2=false;
	            }
            bo.supp1 = textBox1.Text;
            bool notExistText1 = true;
            foreach (DataRow row in bl.searchSupp(bo).Rows)
            {
                notExistText1 = false;
            }
            if (dialogResult == DialogResult.Yes)
            {
                if (!notExistTextBox2)
                {
                    if (!notExistText1)
                    {
                        bo.supp1 = textBox2.Text;
                        bo.supp2 = textBox1.Text;
                        bl.updateIngSuppOnly(bo);
                        textBox2.Text = "";
                        textBox1.Text = "";
                        loadSupplier();
                        MessageBox.Show("Success!"); 
                    }
                    else
                    {
                        MessageBox.Show("There's no such a supplier named " + textBox1.Text);
                    }
                }
                else
                {
                    MessageBox.Show("There's no such a supplier named "+ textBox2.Text);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            diagArrangeSupplier arange = new diagArrangeSupplier();
            if (arange.ShowDialog()==DialogResult.OK)
            {
                
            }
        }
    }
}
