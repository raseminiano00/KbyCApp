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
    public partial class diagAddRecipe : Form
    {
        public diagAddRecipe(string action,string recipeID)
        {
            InitializeComponent();
            SelectedAction = action;
            if (recipeID!="")
            {
                RecipeID = Convert.ToInt32(recipeID); 
            }
        }
        IngredientBO IngBO;
        IngredientBL IngBL;
        RecipeBL RecBL;
        RecipeBO RecBO;
        int RecipeID = 1;
        private void diagAddRecipe_Load(object sender, EventArgs e)
        {
            RecBL = new RecipeBL();
            RecBO = new RecipeBO();

            if (SelectedAction == "New")
            {
                getRecipeID();
            }
            else
            {
                backToolStripMenuItem.Text = "Close";
                RecBO.recipeid = Convert.ToString(RecipeID);
                DataTable dt= RecBL.searchRecipeByID(RecBO);
                foreach (DataRow row in dt.Rows)
                {
                    oldStatus = row.ItemArray[3].ToString();
                    textBox1.Text = row.ItemArray[1].ToString();
                     origDesc = row.ItemArray[1].ToString();
                    comboBox1.Text = row.ItemArray[2].ToString();
                    RecBO.recipeid = row.ItemArray[0].ToString();
                    dataGridView1.DataSource = RecBL.getIngByRecID(RecBO);
                }
                RecBO.recipeid = Convert.ToString(RecipeID);
                origIng = RecBL.getIngByRecIdOrig(RecBO);
            }
        }
        private void getRecipeID()
        {
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            RecBL = new RecipeBL();
            RecBO = new RecipeBO();

            foreach (DataRow row in RecBL.SearchRecipeCanBeUse().Rows)
            {
                RecipeID = Convert.ToInt32(row[0].ToString());
                RecBO.status = "1";
                RecBO.recipeid = Convert.ToString(RecipeID);
                RecBL.ChangeRecipeInuse(RecBO); 
            }
             if (RecipeID==1)
            {
                RecBL.addRecipeSlot(RecBO);
                foreach (DataRow row in RecBL.SearchRecipeCanBeUse().Rows)
                {
                    RecipeID = Convert.ToInt32(row[0].ToString());
                }
                RecBO.status = "1";
                RecBO.recipeid = Convert.ToString(RecipeID);
                RecBL.ChangeRecipeInuse(RecBO);
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private DataTable searchIng(string ing)
        {
            IngBL = new IngredientBL();
            IngBO = new IngredientBO();
            IngBO.ing = ing;
            return IngBL.searchIngNameOnly(IngBO);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            IngBL = new IngredientBL();
            IngBO = new IngredientBO();
            try
            {
                if (textBox2.Text != "Search box")
                {
                    dataGridView2.DataSource = searchIng(textBox2.Text.Trim());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                this.textBox2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                textBox2.Text = "Search box";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Search box")
            {
                textBox2.ForeColor = Color.Black;
                this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                textBox2.Text = "";
            }
        }
        string[] newlyaddeding = new string[100];
        int numOfAddedIng = 0;
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            RecBL = new RecipeBL();
            RecBO = new RecipeBO();
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                selectedIng = row.Cells[0].Value.ToString();
            }
            RecBO.recipeid = Convert.ToString(RecipeID);
            RecBO.ingid = selectedIng;
            DataTable dt= RecBL.checkRecipeIng(RecBO);
            if (dt.Rows.Count == 0)
            {
                diagRecipeMeas diagMeas = new diagRecipeMeas(selectedIng);
                if (diagMeas.ShowDialog() == DialogResult.OK)
                {
                    newlyaddeding[numOfAddedIng] = selectedIng;
                    numOfAddedIng = numOfAddedIng + 1;
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    RecBO.ingid = selectedIng;
                    RecBO.meas = diagMeas.meas;
                    RecBL.addRecipeIng(RecBO);
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    dataGridView1.DataSource = RecBL.getIngByRecID(RecBO);
                    time = 0;
                    notifier("Ingredient Successfully added!");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                }
            }
            else
            {
                time = 0;
                notifier("Ingredient is already included!");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.Tomato;

            }
        }


        private void notifier(string notif)
        {
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }


        public string selectedIng { get; set; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            RecBL = new RecipeBL();
            RecBO = new RecipeBO();
            try
            {
                RecBO.recipe = textBox1.Text.Trim();
                RecBO.cat = comboBox1.Text.Trim();
                RecBO.recipeid = Convert.ToString(RecipeID);
                if (SelectedAction == "New")
                {
                    if (RecBL.checkRecipeName(RecBO).Rows.Count == 0)
                    {
                        if (dataGridView1.Rows.Count != 0 && textBox1.Text != "" && comboBox1.Text != "")
                        {
                            RecBL.makeRecipeAvail(RecBO);
                            RecBL.updateRecipe(RecBO);
                            time = 0;
                            notifier("Dish Successfully added!");
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                            acceptbutton = true;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            time = 0;
                            notifier("Fill Dish description and add ingredients to dish!");
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.Tomato;
                        }
                    }
                    else
                    {
                        time = 0;
                        notifier("Dish name is already registered!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }
                }
                else
                {
                        RecBO.recipeid= Convert.ToString(RecipeID);
                        RecBO.recipe = textBox1.Text.Trim();
                        bool notaltered = !(RecBL.checkRecipe(RecBO).Rows.Count == 1);
                        bool unique = !(RecBL.checkRecipeName(RecBO).Rows.Count == 1);
                        if (string.Equals(textBox1.Text, origDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            notaltered = true;
                            unique = true;
                        }
                        if(notaltered && unique)
                        {
                            RecBO.recipeid = Convert.ToString(RecipeID);
                            RecBO.recipe = textBox1.Text.Trim();
                            RecBO.cat = comboBox1.Text.Trim();
                            if (MessageBox.Show("Done updating dish?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                RecBL.updateRecipe(RecBO);
                                recipename = textBox1.Text.Trim();
                                acceptbutton = true;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        bool cancelButton = false;
        bool acceptbutton = false;
        private void button2_Click(object sender, EventArgs e)
        {
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            try
            {
                if (MessageBox.Show("Dish/Changes will not be saved." + Environment.NewLine + "Are you sure you want to cancel?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    RecBO.status = "0";
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    RecBL.ChangeRecipeInuse(RecBO); 
                    while (numOfAddedIng >= 0)
                    {
                        RecBO.recipeid = Convert.ToString(RecipeID);
                        RecBO.ingid = newlyaddeding[numOfAddedIng];
                        RecBL.removeNewlyAddedIngToRecipe(RecBO);
                        numOfAddedIng = numOfAddedIng - 1;
                    }
                    if (SelectedAction == "Update")
                    {
                        RecBO.status = oldStatus;
                        RecBO.recipeid = Convert.ToString(RecipeID);
                        RecBL.ChangeRecipeInuse(RecBO); 
                        RecBO.recipeid = Convert.ToString(RecipeID);
                        RecBL.deleteAllRecIng(RecBO);
                        RecBO.recipeid = Convert.ToString(RecipeID);
                        foreach (DataRow row in origIng.Rows)
                        {
                            RecBO.recipeid = row.ItemArray[0].ToString();
                            RecBO.ingid = row.ItemArray[1].ToString();
                            RecBO.meas = row.ItemArray[2].ToString();
                            RecBL.addRecipeIng(RecBO);
                        }
                    }
                    cancelButton = true;
                    acceptbutton = false;
                    this.Close(); 
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView1, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                ingdesc = row.Cells[0].Value.ToString();
                ingmeass = row.Cells[1].Value.ToString().ToCharArray();
            }
        }
        List<string> tempRemoveIng = new List<string>();
        List<string> tempRemoveIngMeas = new List<string>();
        int countremovedIng = 0;
        private void removeIngredientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            int counter=ingmeass.Count();
            int index = 0;
            if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int indicator = 0;
                RecBO.recipeid = Convert.ToString(RecipeID);
                RecBO.ingdesc = ingdesc;
                RecBL.removeRecipeIng(RecBO);
                countremovedIng=countremovedIng+1;
                foreach (DataRow row in RecBL.searchIngByID(RecBO).Rows)
                {
                    tempRemoveIng.Add(row.ItemArray[0].ToString());
                }
                RecBO.recipeid = Convert.ToString(RecipeID);
                dataGridView1.DataSource = RecBL.getIngByRecID(RecBO);
                time = 0;
                notifier("Ingredient successfully remove to the dish!");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            }
        }

        public string ingdesc { get; set; }

        public string SelectedAction { get; set; }
    
public  string origDesc { get; set; }
public string recipename { get; set; }

public string ingmeas { get; set; }

public char[] ingmeass { get; set; }

public DataTable origIng { get; set; }

private void button4_Click(object sender, EventArgs e)
{
    frmIngredient ing = new frmIngredient("Diag");
    if (ing.ShowDialog()==DialogResult.OK)
    {
        
    }
}

private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void groupBox2_Enter(object sender, EventArgs e)
{

}

private void backToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (backToolStripMenuItem.Text == "Back")
    {
        this.Close();
    }
    else
    {
        this.DialogResult = DialogResult.OK;
    }
}

private void diagAddRecipe_FormClosing(object sender, FormClosingEventArgs e)
{
    RecBO = new RecipeBO();
    RecBL = new RecipeBL();
    try
    {
        if (acceptbutton != true && cancelButton == false)
        {
            if (MessageBox.Show("Dish/Changes will not be saved." + Environment.NewLine + "Are you sure you want to cancel?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                RecBO.status = "0";
                RecBO.recipeid = Convert.ToString(RecipeID);
                RecBL.ChangeRecipeInuse(RecBO);
                while (numOfAddedIng >= 0)
                {
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    RecBO.ingid = newlyaddeding[numOfAddedIng];
                    RecBL.removeNewlyAddedIngToRecipe(RecBO);
                    numOfAddedIng = numOfAddedIng - 1;
                    this.DialogResult = DialogResult.Cancel;
                }
                if (SelectedAction == "Update")
                {
                    RecBO.status = oldStatus;
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    RecBL.ChangeRecipeInuse(RecBO); 
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    RecBL.deleteAllRecIng(RecBO);
                    RecBO.recipeid = Convert.ToString(RecipeID);
                    foreach (DataRow row in origIng.Rows)
                    {
                        RecBO.recipeid = row.ItemArray[0].ToString();
                        RecBO.ingid = row.ItemArray[1].ToString();
                        RecBO.meas = row.ItemArray[2].ToString();
                        RecBL.addRecipeIng(RecBO);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
    catch (Exception)
    {

        throw;
    }
}

public int canbeuse { get; set; }

public string oldStatus { get; set; }
    }
}
