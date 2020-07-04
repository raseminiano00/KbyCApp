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
    public partial class frmRecipes : Form
    {
        public frmRecipes()
        {
            InitializeComponent();
        }
        RecipeBL RecipeBL;
        RecipeBO RecipeBO;
        private void frmRecipes_Load(object sender, EventArgs e)
        {
            RecipeBL = new Catering_Menu.RecipeBL();
            RecipeBO = new Catering_Menu.RecipeBO();
            cat = "Appetizer";
            try
            {
                RecipeBO.recipe = "";
                RecipeBO.cat = cat;
                dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            RecipeBL = new RecipeBL();
            RecipeBO = new RecipeBO();
            Cursor = Cursors.WaitCursor;
            try
            {
                if (textBox6.Text != "Search box")
                {
                    if (radioButton1.Checked == true)
                    {
                        RecipeBO.recipe = textBox6.Text.Trim();
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
                    }
                    else
                    {
                        RecipeBO.recipe = textBox6.Text.Trim();
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipeUn(RecipeBO);
                    }
                }
            }
            catch (Exception)
            {
                Cursor = Cursors.Arrow;
                throw;
            }
            Cursor = Cursors.Arrow;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string cat { get; set; }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }
        private void notifier(string notif)
        {
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeBL = new RecipeBL();
            RecipeBO = new RecipeBO();
            try
            {
                int selectedcat = Convert.ToInt32(tabControl1.SelectedIndex.ToString());
                if (selectedcat == 0)
                {
                    cat = "Appetizer";
                }
                else if (selectedcat == 1)
                {
                    cat = "Bread Service";
                }
                else if (selectedcat == 2)
                {
                    cat = "Soup";
                }
                else if (selectedcat == 3)
                {
                    cat = "Salad";
                }
                else if (selectedcat == 4)
                {
                    cat = "Pasta";
                }
                else if (selectedcat == 5)
                {
                    cat = "Main Dish";
                }
                else if (selectedcat == 6)
                {
                    cat = "Kiddie Meal";
                }
                else if(selectedcat == 7)
                {
                    cat = "Rice";
                }
                else if (selectedcat ==8)
                {
                    cat = "Dessert";
                }
                else if (selectedcat == 9)
                {
                    cat = "Cake";
                }
                else if (selectedcat == 10)
                {
                    cat = "Drinks";
                }
                else if (selectedcat == 11)
                {
                    cat = "Crew meal";
                }
                else if (selectedcat == 12)
                {
                    cat = "Others";
                }
                
                if (radioButton1.Checked == true)
                {
                    RecipeBO.recipe = textBox6.Text.Trim();
                    if (textBox6.Text == "Search box")
                    {
                        RecipeBO.recipe = "";
                    }
                    RecipeBO.cat = cat;
                    dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
                }
                else
                {
                    RecipeBO.recipe = textBox6.Text.Trim();
                    if (textBox6.Text == "Search box")
                    {
                        RecipeBO.recipe = " ";
                    }
                    RecipeBO.cat = cat;
                    dataGridView1.DataSource = RecipeBL.searchRecipeUn(RecipeBO);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        string status = "";
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView1, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                RecipeID = row.Cells[0].Value.ToString();
                status = row.Cells[2].Value.ToString();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            diagAddRecipe diagAdd = new diagAddRecipe("New","");

            if (diagAdd.ShowDialog() == DialogResult.OK)
            {
                time = 0;
                notifier("Dish successfully added.");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            recBO = new RecipeBO();
            recBL = new RecipeBL();
            IngredientBL IngBL = new IngredientBL();
            IngredientBO ingBO = new IngredientBO();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    RecipeID = row.Cells[0].Value.ToString();
                    Recipe = row.Cells[1].Value.ToString();
                    groupBox2.Text = Recipe;
                }
                recBO.recipeid = Convert.ToString(RecipeID);
                DataTable dt = recBL.getIngByRecID(recBO);
                double dishprice = 0;
                
                foreach (DataRow row in dt.Rows)
                {
                    ingBO.ing = row[0].ToString();
                    DataTable ings =  IngBL.searchIngredientReturnPrice(ingBO);
                    foreach (DataRow ing in ings.Rows)
                    {
                        dishprice = dishprice + (getPrice(row[1].ToString(), "1") * Convert.ToDouble(ing[4].ToString()));  
                    }
                }
                dt.Rows.Add("TOTAL ","P " +dishprice.ToString("F"));
                dataGridView2.DataSource = dt;
            
          
        }

        public string RecipeID { get; set; }
        RecipeBO recBO;
        RecipeBL recBL;

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            recBO = new RecipeBO();
            recBL = new RecipeBL();
            diagAddRecipe diagAdd = new diagAddRecipe("Update",RecipeID);

            if (diagAdd.ShowDialog() == DialogResult.OK)
            {
                time = 0;
                notifier("Dish successfully updated.");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.DodgerBlue; 
                try
                {

                    RecipeBO.recipe = diagAdd.recipename;
                    RecipeBO.cat = cat;
                    dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        private void Action_Opening(object sender, CancelEventArgs e)
        {

        }

        public string Recipe { get; set; }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            recBO = new RecipeBO();
            recBL = new RecipeBL();
            try
            {
                if (RecipeID != "" && RecipeID != null)
                {
                    recBO.recipeid = RecipeID;
                    recBO.recipe = "";
                    recBO.cat = cat; 
                    if (status == "AVAILABLE")
                    {
                        recBL.makeRecipeUnavail(recBO);
                        radioButton1.Checked = !radioButton1.Checked;
                    }
                    else
                    {
                        recBL.makeRecipeAvail(recBO);
                        radioButton1.Checked = !radioButton1.Checked;
                    }
                    time = 0;
                    RecipeID = "";
                    notifier("Dish successfully status changed.");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                    RecipeBO.recipe = "";
                    RecipeBO.cat = cat; 
                    
                }
                else
                {
                    time = 0;
                    notifier("Please select a dish.");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;  
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RecipeBL = new RecipeBL();
            RecipeBO = new RecipeBO();
            try
            {
                if (textBox6.Text != "Search box")
                {
                    if (radioButton1.Checked == true)
                    {
                        RecipeBO.recipe = textBox6.Text.Trim();
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
                    }
                    else
                    {
                        RecipeBO.recipe = textBox6.Text.Trim();
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipeUn(RecipeBO);
                    }
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        RecipeBO.recipe = "";
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipe(RecipeBO);
                    }
                    else
                    {
                        RecipeBO.recipe = "";
                        RecipeBO.cat = cat;
                        dataGridView1.DataSource = RecipeBL.searchRecipeUn(RecipeBO);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatering cat = new frmCatering();
            cat.Show();
            this.Hide();

        } 
        List<string> nums = new List<string>();
        List<string> operations = new List<string>();
        private double getPrice(string form, string pax)
        {
            int lengthofstring = 0;
            lengthofstring = form.Count();
            lngthofstring = form.Count();
            formula = form.ToString();
            char[] arrayformula = formula.ToCharArray();
            while (lengthofstring != 0)
            {
                if (char.IsDigit(arrayformula[parameter]) || arrayformula[parameter] == char.Parse(".") || Convert.ToString(arrayformula[parameter]) == "P")
                {
                    if (Convert.ToString(arrayformula[parameter]) != "P")
                    {
                        if (opercounter == 1)
                        {
                            nums.Add(Convert.ToString(arrayformula[parameter]));
                            opercounter = 0;
                        }
                        else
                        {
                            nums[counter] = nums[counter] + (Convert.ToString(arrayformula[parameter]));
                        }
                    }
                    else
                    {
                        nums.Add(pax);
                        parameter = parameter + 2;
                        counter = counter + 1;
                        lengthofstring = lengthofstring - 2;
                    }
                    //number[counter] = number[counter] + Convert.ToString(arrayformula[parameter]); 0.02*PAX*100

                }
                else
                {
                    switch (arrayformula[parameter])
                    {
                        case '+':
                            operations.Add("+");
                            break;
                        case '-':
                            operations.Add("-");
                            break;
                        case '*':
                            operations.Add("*");
                            break;
                        case '/':
                            operations.Add("/");
                            break;
                    }
                    if (opercounter == 0)
                    {
                        counter = counter + 1;
                    }
                    opercounter = 1;

                }
                parameter = parameter + 1;
                lengthofstring = lengthofstring - 1;

            }
            parameter = 0;
            counter = 0;
            int numbercounter = 1;
            double answer = 0;
            int numofoper = operations.Count();
            while (numofoper != 0)
            {
                if (counter == 0)
                {
                    switch (Convert.ToChar(operations[counter]))
                    {
                        case '+':
                            answer = Convert.ToDouble(nums[0]) + Convert.ToDouble(nums[1]);
                            break;
                        case '-':
                            answer = Convert.ToDouble(nums[0]) - Convert.ToDouble(nums[1]);
                            break;
                        case '*':
                            answer = Convert.ToDouble(nums[0]) * Convert.ToDouble(nums[1]);
                            break;
                        case '/':
                            answer = Convert.ToDouble(nums[0]) / Convert.ToDouble(nums[1]);
                            break;
                    }


                }
                else
                {
                    switch (Convert.ToChar(operations[counter]))
                    {
                        case '+':
                            answer = answer + Convert.ToDouble(nums[numbercounter]);
                            break;
                        case '-':
                            answer = answer - Convert.ToDouble(nums[numbercounter]);
                            break;
                        case '*':
                            answer = answer * Convert.ToDouble(nums[numbercounter]);
                            break;
                        case '/':
                            answer = answer / Convert.ToDouble(nums[numbercounter]);
                            break;
                    }

                }
                numbercounter = numbercounter + 1;
                counter = counter + 1;
                numofoper = numofoper - 1;
            }
            opercounter = 1;
            counter = 0;
            nums.Clear();
            parameter = 0;
            numbercounter = 0;
            operations.Clear();
            return answer;
        }

        public int lngthofstring { get; set; }

        public string formula { get; set; }

        public int parameter = 0;

        public int opercounter = 1;

        public int counter { get; set; }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
