using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Catering_Menu
{
    public partial class frmSysSettings : Form
    {
        public frmSysSettings()
        {
            InitializeComponent();
        }

        ConnectBL BL;
        private void frmSysSettings_Load(object sender, EventArgs e)
        {
           
            textBox1.Text = Properties.Settings.Default.ip;
            textBox2.Text = Properties.Settings.Default.port;
            textBox3.Text = Properties.Settings.Default.Database;
            textBox4.Text = Properties.Settings.Default.user;
            textBox5.Text = Properties.Settings.Default.pass;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL = new ConnectBL();
            try
            {
                Properties.Settings.Default.ip = textBox1.Text;
                Properties.Settings.Default.port = textBox2.Text;
                Properties.Settings.Default.Database = textBox3.Text;
                Properties.Settings.Default.user = textBox4.Text;
                Properties.Settings.Default.pass = textBox5.Text;
                BL.checkConn();
                frmCatering cat = new frmCatering();
                cat.Show();
                Properties.Settings.Default.Save();
                this.Hide();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Errors[0].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectBL conBL= new ConnectBL();
            ConnectBO conBO = new ConnectBO();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                conBO.path = openFileDialog1.FileName;
                conBL.Export(conBO);
                MessageBox.Show("Export Completed!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectBL conBL = new ConnectBL();
            ConnectBO conBO = new ConnectBO();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            diagPass pass=new diagPass();
            if (pass.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "All files (*.*)|*.*";
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    conBO.path = openFileDialog1.FileName;
                    conBL.Import(conBO);
                    MessageBox.Show("Import Completed!");
                }
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectBL conBL = new ConnectBL();
            ConnectBO conBO = new ConnectBO();
            try
            {
                conBO.db = textBox3.Text;
                conBL.CreateDb(conBO);
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Errors[0].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConnectBL BL = new ConnectBL();
            try
            {
                BL.checkConn();
                MessageBox.Show("System is connected to database!");
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Errors[0].ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPlatedMultiplier diagChangeMult = new frmPlatedMultiplier();
            if (diagChangeMult.ShowDialog()==DialogResult.OK)
            {
                Properties.Settings.Default.Plated = diagChangeMult.multiplier;
                Properties.Settings.Default.Save();
                MessageBox.Show("Multiplier successfully changed!");
            }
        }
    }
}
