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
    public partial class diagIngredient : Form
    {
        public diagIngredient()
        {
            InitializeComponent();
        }
        public string ingSelected { get; set; }
        IngredientBL BL;
        IngredientBO BO;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void diagIngredient_Load(object sender, EventArgs e)
        {

        }

        private DataTable searchIng(string ing)
        {
            BO.ing = ing;
            return BL.searchIngNameOnly(BO);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            BL = new IngredientBL();
            BO = new IngredientBO();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                ingSelected = row.Cells[0].ToString();
            }
        }
    }
}
