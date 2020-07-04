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
    public partial class diagRecipeMeas : Form
    {
        public diagRecipeMeas(string SelectedIng)
        {
            InitializeComponent();
            selectedIng = SelectedIng;
        }
        string selectedIng = "";
        public string meas { get; set; }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                meas = textBox1.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Enter a measurement!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == Char.Parse(".") || e.KeyChar == Char.Parse("P") || e.KeyChar == Char.Parse("A") || e.KeyChar == Char.Parse("X") || e.KeyChar == Char.Parse("/") || e.KeyChar == Char.Parse("*") || e.KeyChar == Char.Parse("-") || e.KeyChar == Char.Parse("+"));
        }

        private void diagRecipeMeas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
