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
    public partial class frmPlatedMultiplier : Form
    {
        public frmPlatedMultiplier()
        {
            InitializeComponent();
        }
        public decimal multiplier { get; set; }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            multiplier = Convert.ToDecimal(numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
        }

        private void frmPlatedMultiplier_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Properties.Settings.Default.Plated;
        }
    }
}
