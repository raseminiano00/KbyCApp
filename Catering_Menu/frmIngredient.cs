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
    public partial class frmIngredient : Form
    {
        public frmIngredient(string selectedAction)
        {
            InitializeComponent();
            selectedaction = selectedAction;
        }
        string selectedaction = "";
        List<string> Suppliers = new List<string>();
        private void frmIngredient_Load(object sender, EventArgs e)
        {
            SupplierBL SuppBL= new SupplierBL();
            SupplierBO SuppBO = new SupplierBO();
            foreach (DataRow row in SuppBL.getSupplier().Rows)
            {
                //supp1 = row.ItemArray[0].ToString();
                //supp2=row.ItemArray[1].ToString();
                //supp3=row.ItemArray[2].ToString();
                //label3.Text = "Supplier 1 : "+ row.ItemArray[0].ToString()+"";
                //label4.Text = "Supplier 2 : " + row.ItemArray[1].ToString() + "";
                //label5.Text = "Supplier 3 : " + row.ItemArray[2].ToString() + "";
                comboBox1.Items.Add(row.ItemArray[0].ToString());
            }
            if (selectedaction == "Diag")
            {
                backToolStripMenuItem.Text = "Close";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        IngredientBL BL;
        IngredientBO BO;
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            BL = new IngredientBL();
            BO = new IngredientBO();
            Cursor = Cursors.WaitCursor;
            try
            {
                if (textBox6.Text != "Search box")
                {
                    dataGridView1.DataSource = searchIng(textBox6.Text.Trim());
                }
            }
            catch (Exception)
            {

                throw;
            }
            Cursor = Cursors.Arrow;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == Char.Parse("."));
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                this.textBox6.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                textBox6.Text = "Search box";
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Search box")
            {
                textBox6.ForeColor = Color.Black;
                this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                textBox6.Text = "";
            }
        }


        private void notifier(string notif,Color bgcolor)
        {

            panel3.BackColor = bgcolor;
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }

        private DataTable searchIng(string ing)
        {
            BO.ing = ing;
            BO.supp1 = supp1;
            BO.supp2 = supp2;
            BO.supp3 = supp3;
            return BL.searchIng(BO);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BO = new IngredientBO();
            BL = new IngredientBL();
            try
            {

                if (button1.Text == "Add ingredient")
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    comboBox1.Enabled = true;
                    textBox3.Enabled = true;
                    button2.Text = "Cancel";
                    button1.Text = "Save";
                   
                }
                // Save for add
                else if (button1.Text == "Save")
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        BO.ing = textBox1.Text.Trim();
                        if (BL.checkIngByDesc(BO).Rows.Count == 0)
                        {
                            //calling database
                            BO.ing = textBox1.Text.Trim();
                            BO.measurement = textBox2.Text.Trim();
                                //BO.popoy = textBox3.Text.Trim();
                                //BO.cdad = textBox4.Text.Trim();
                                //BO.sup = textBox5.Text.Trim();
                            BO.sup = comboBox1.Text;
                            BO.price = textBox3.Text;
                            BL.addIng(BO);
                            //going back to orig state
                            button1.Text = "Add ingredient";
                            button2.Text = "Update selected";
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            comboBox1.Enabled = false;
                            textBox3.Enabled = false;
                            comboBox1.Text = "";
                            textBox3.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            dataGridView1.DataSource = searchIng("");
                            time = 0;
                            notifier("Successfully added!",Color.DodgerBlue);
                            ingid = "";
                            //}

                        }
                        else
                        {
                            time = 0;
                            notifier("Ingredient is already exists!",Color.Tomato);
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.Tomato;
                        }
                    }
                    else
                    {
                        time = 0;
                        notifier("Fill all blanks!", Color.Tomato);
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }
                }
                //save for Update
                else if (button1.Text == "Save changes")
                {

                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        BO.ingid = ingid;
                        BO.ing = textBox1.Text.Trim();
                        bool notaltered = !(BL.checkIng(BO).Rows.Count == 1);
                        bool unique = !(BL.checkIngByDesc(BO).Rows.Count == 1);
                        if (string.Equals(textBox1.Text, ingdesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            notaltered = true;
                            unique = true;
                        }
                        if (notaltered && unique)
                        {
                            //calling database
                            BO.ing = textBox1.Text.Trim();
                            BO.measurement = textBox2.Text.Trim();
                            BO.sup = comboBox1.Text;
                            BO.price = textBox3.Text;
                            BO.ingid = ingid;
                            BL.updateing(BO);
                            //going back to orig state
                            button1.Text = "Add ingredient";
                            button2.Text = "Update selected";
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            comboBox1.Enabled = false;
                            textBox3.Enabled = false ;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            comboBox1.Text = "";
                            //notifier called
                            dataGridView1.DataSource = searchIng("");
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            notifier("Successfully Updated!", Color.DodgerBlue);
                            ingid = "";

                        }
                        else
                        {
                            time = 0;
                            notifier("Ingredient is already exists!", Color.Tomato);
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.Tomato;
                        }
                    }
                    else
                    {
                        time = 0;
                        notifier("Fill all blanks!", Color.Tomato);
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            Cursor = Cursors.Arrow;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text == "Cancel")
                {
                    button1.Text = "Add ingredient";
                    button2.Text = "Update selected";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    comboBox1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Cursor = Cursors.WaitCursor;
                    ingid = "";
                    Cursor = Cursors.Arrow;
                }
                else if (button2.Text == "Update selected")
                {
                    if (ingid != "")
                    {
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        comboBox1.Enabled = true;
                        textBox3.Enabled = true;
                        button2.Text = "Cancel";
                        button1.Text = "Save changes";
                    }
                    else
                    {
                        time = 0;
                        notifier("No ingredient selected!", Color.Tomato);
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time + 1;
            if (time == 5)
            {
                panel3.Visible = false;
                time = 0;
                timer1.Stop();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                ingid = row.Cells[0].Value.ToString();
                ingdesc = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        public string ingid = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string ingdesc { get; set; }
        
        private void button3_Click(object sender, EventArgs e)
        {
            BO = new IngredientBO();
            BL = new IngredientBL();
            DataTable recipes;
            try
            {
                if (ingid != "")
                {
                    if (MessageBox.Show("Are you sure you want to delete '" + ingdesc + "'?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (MessageBox.Show("Is there a replacement ingredient for deleted ingredient ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            diagIngredient diag=new diagIngredient();
                            if (diag.ShowDialog() == DialogResult.OK)
                            {
                                BO.ingid = diag.ingSelected;
                                recipes = BL.getAllrecipeWithIng(BO);
                                foreach (DataRow row in recipes.Rows)
                                {
                                   
                                }
                            }
                            
                        }
                        BO.ingid = ingid;
                        BL.deleteing(BO);
                        //notifier called
                        dataGridView1.DataSource = searchIng("");
                        notifier("Successfully deleted!", Color.DodgerBlue);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        ingid = "";
                    }
                }
                else
                {
                    time = 0;
                    notifier("No ingredient selected!", Color.Tomato);
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backToolStripMenuItem.Text == "Back")
            {
                frmCatering cat = new frmCatering();
                cat.Show();
                this.Hide();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public string supp1 { get; set; }

        public string supp2 { get; set; }

        public string supp3 { get; set; }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            DataTable dt = (DataTable)(dataGridView1.DataSource);
            Excel.Rows.Add( "List of Ingredient ","As of "+DateTime.UtcNow.ToString("MM/dd/yyyy"));
            Excel.Rows.Add("", "Ingredient", "Measurement", "Supplier", "Price");
            foreach (DataRow row in dt.Rows)
            {
                Excel.Rows.Add("", row[1].ToString(),row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
            diagReport report = new diagReport(Excel, "");
            report.Show();
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == Char.Parse("."));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == Char.Parse("."));
        }
    }
}
