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
    public partial class frmMenu : Form
    {
        public frmMenu(string action, string catid)
        {
            InitializeComponent();
            CatID = catid;
            SelectedAction = action;

        }
        string SelectedAction = "";
        string CatID = "";
        CateringBL catBL;
        CateringBO catBO;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeBL = new RecipeBL();
            RecipeBO = new RecipeBO();
            try
            {

                if (textBox5.Text != "Search box")
                {
                    RecipeBO.recipe = textBox5.Text.Trim();
                }
                else
                {
                    RecipeBO.recipe = "";
                }
                RecipeBO.cat = comboBox1.Text;
                dataGridView1.DataSource = RecipeBL.searchRecipeTwoColumns(RecipeBO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void manageIngredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngredient frmIng = new frmIngredient("Normal");
            frmIng.Show();
            this.Hide();
        }

        private void manageDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecipes frmRec = new frmRecipes();
            frmRec.Show();
            this.Hide();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {

            if (textBox5.Text == "Search box")
            {
                textBox5.ForeColor = Color.Black;
                this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                textBox5.Text = "";
            }
        }
        RecipeBL RecipeBL;
        RecipeBO RecipeBO;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            RecipeBL = new RecipeBL();
            RecipeBO = new RecipeBO();
            Cursor = Cursors.WaitCursor;
            try
            {
                if (textBox5.Text != "Search box")
                {
                    if (comboBox1.Text != "")
                    {
                        RecipeBO.recipe = textBox5.Text.Trim();
                        RecipeBO.cat = comboBox1.Text;
                        dataGridView1.DataSource = RecipeBL.searchRecipeTwoColumns(RecipeBO);
                    }
                    else
                    {
                        RecipeBO.recipe = textBox5.Text.Trim();
                        RecipeBO.cat = " ";
                        dataGridView1.DataSource = RecipeBL.searchRecipeTwoColumns(RecipeBO);
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

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                this.textBox5.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                textBox5.Text = "Search box";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        RecipeBL RecBL;
        RecipeBO RecBO;

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //catBL = new CateringBL();
            //catBO = new CateringBO();
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //int recipeid = 0;
            //decimal price = 0;
            //int count = 0;
            //int counter = 0;
            //List<decimal> popoy = new List<decimal>();
            //List<decimal> cdad = new List<decimal>();
            //List<decimal> supp = new List<decimal>();
            //List<decimal> popoyP = new List<decimal>();
            //List<decimal> cdadP = new List<decimal>();
            //List<decimal> suppP = new List<decimal>();
            //int paramcounter = 0;
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    if (txtVip.Text != "")
            //    {
            //        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //        {
            //            RecBO.recipe = row.Cells[0].Value.ToString();
            //            RecBO.cat = comboBox1.Text.Trim();
            //            foreach (DataRow rows in RecBL.searchRecipe(RecBO).Rows)
            //            {
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                foreach (DataRow prices in catBL.getSuppPrices(catBO).Rows)
            //                {
            //                    popoy.Add(Convert.ToDecimal(prices.ItemArray[0].ToString()));
            //                    cdad.Add(Convert.ToDecimal(prices.ItemArray[1].ToString()));
            //                    supp.Add(Convert.ToDecimal(prices.ItemArray[2].ToString()));
            //                }
            //                recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                catBO.catID = catID;
            //            }
            //        }
            //        RecBO.recipeid = Convert.ToString(recipeid);
            //        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            price = price + getPrice(row.ItemArray[2].ToString(), txtVip.Text.Trim());
            //            if (popoyP.Count == 0)
            //            {
            //                popoyP.Add(popoy[counter] * Convert.ToDecimal(price));
            //                cdadP.Add(cdad[counter] * Convert.ToDecimal(price));
            //                suppP.Add(supp[counter] * Convert.ToDecimal(price));
            //            }
            //            else
            //            {
            //                popoyP[paramcounter] = popoyP[paramcounter] + (popoy[counter] * Convert.ToDecimal(price));
            //                cdadP[paramcounter] = cdadP[paramcounter] + (cdad[counter] * Convert.ToDecimal(price));
            //                suppP[paramcounter] = suppP[paramcounter] + (supp[counter] * Convert.ToDecimal(price));
            //            }
            //            counter = counter + 1;
            //            price = 0;
            //        }
            //        catBO.popoy = Convert.ToString(popoyP[paramcounter]);
            //        catBO.cdad = Convert.ToString(cdadP[paramcounter]);
            //        catBO.supp = Convert.ToString(suppP[paramcounter]);
            //        catBL.addCatDish(catBO);
            //        catBO.catID = catID;
            //        time = 0;
            //        notifier("Dish successfully added.");
            //        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
            //        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            //        catBO.catID = catID;
            //        catBO.category = "";
            //        dataGridView2.DataSource = catBL.getCateringDish(catBO);
            //    }
            //}
        }
        private void notifier(string notif)
        {
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        List<string> nums = new List<string>();
        List<string> operations = new List<string>();
        private decimal getPrice(string form, string pax)
        {
            int lengthofstring = 0;
            lengthofstring = form.Count();
            lngthofstring = form.Count();
            formula = form.ToString();
            char[] arrayformula = formula.ToCharArray();
            counter = 0;
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
            decimal answer = 0;
            int numofoper = operations.Count();
            while (numofoper != 0)
            {
                if (counter == 0)
                {
                    switch (Convert.ToChar(operations[counter]))
                    {
                        case '+':
                            answer = Convert.ToDecimal(nums[0]) + Convert.ToDecimal(nums[1]);
                            break;
                        case '-':
                            answer = Convert.ToDecimal(nums[0]) - Convert.ToDecimal(nums[1]);
                            break;
                        case '*':
                            answer = Convert.ToDecimal(nums[0]) * Convert.ToDecimal(nums[1]);
                            break;
                        case '/':
                            answer = Convert.ToDecimal(nums[0]) / Convert.ToDecimal(nums[1]);
                            break;
                    }


                }
                else
                {
                    switch (Convert.ToChar(operations[counter]))
                    {
                        case '+':
                            answer = answer + Convert.ToDecimal(nums[numbercounter]);
                            break;
                        case '-':
                            answer = answer - Convert.ToDecimal(nums[numbercounter]);
                            break;
                        case '*':
                            answer = answer * Convert.ToDecimal(nums[numbercounter]);
                            break;
                        case '/':
                            answer = answer / Convert.ToDecimal(nums[numbercounter]);
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
        public int parameter { get; set; }

        public int counter { get; set; }

        public int opercounter = 1;

        public string formula { get; set; }

        public int lngthofstring { get; set; }

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
        string catID = "";
        private void frmMenu_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Appetizer";
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL(); 
            bool inuse=false;
            string NotInuseID = "";
            if (SelectedAction == "Add")
            {
                DataTable dt = catBL.getLastCatID(catBO);
                   
                    DataTable notinuse =catBL.SearchEventNotInuse(catBO);
                   
                    foreach (DataRow row in notinuse.Rows)
                    {
                        inuse = true;
                        NotInuseID = row[0].ToString();
                        catBO.catID = NotInuseID;
                        catID = NotInuseID;
                        catBO.inuse = "1";
                        catBL.ChangeEventInuse(catBO);
                    }
                   
                    if (inuse == true)
                    {
                        catID = NotInuseID;
                    }
                    else 
                    {
                        catBL.AddEventInuse(catBO);
                        DataTable foruse = catBL.SearchEventCanBeUse(catBO);
                        foreach (DataRow row in foruse.Rows)
                        {
                            catID = row[0].ToString();
                        }
                        catBO.catID = catID;
                        catBO.inuse = "1";
                        catBL.ChangeEventInuse(catBO);
                    } 

                    foreach (DataRow supps in BL.getSupplier().Rows)
                    {
                        BO.catid = catID;
                        BO.supp1 = supps.ItemArray[0].ToString();
                        BO.amount = 0;
                        BL.addSuppBudget(BO);
                    }
            }
            else
            {
                catID = CatID;
                catBO.catID = CatID;
                catBO.category = "";
                oldDishes = catBL.getCateringDish(catBO);
                BO.catid = catID;
                oldsuppBud = BL.getSupplierBudget(BO);
                DataTable dts = catBL.getCatDetail(catBO);
                foreach (DataRow row in dts.Rows)
                {
                    textBox2.Text = row.ItemArray[1].ToString();
                    txtVip.Text = row.ItemArray[3].ToString();
                    textBox3.Text = row.ItemArray[2].ToString();
                    txtGuest.Text = row.ItemArray[4].ToString();
                    txtKids.Text = row.ItemArray[5].ToString();
                    txtCrew.Text = row.ItemArray[6].ToString();
                    txtOthers.Text = row.ItemArray[7].ToString();
                    dateTimePicker1.Value = DateTime.Parse(row.ItemArray[9].ToString());
                    comboBox2.Text = row.ItemArray[11].ToString();
                    comboBox3.Text = row.ItemArray[12].ToString();
                }
                showSelected();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            try
            {
                if (MessageBox.Show("All selected dishes will be removed.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    catBO.catID = catID;
                    BO.catid = catID;
                    BL.removeAllSupBudget(BO);
                    catBL.removeDishes(catBO);
                    notifier("Dishes removed.");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                    catBO.catID = catID;
                    catBO.category = "";
                    foreach (DataRow row in BL.getSupplier().Rows)
                    {
                        BO.catid = catID;
                        BO.supp1 = row.ItemArray[0].ToString();
                        BO.amount = 0;
                        BL.addSuppBudget(BO);
                    }
                    showSelected();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private DataTable getSelectedDishes(string catid)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            catBO.catID = catid;
            catBO.category = "";
            return catBL.getCateringDish(catBO);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void removeDishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            SupplierBL SuppBL = new SupplierBL();
            SupplierBO SuppBO = new SupplierBO();
            int recipeid = 0;
            List<decimal> IngredientPrice = new List<decimal>();
            DataTable Suppliers = new DataTable();
            Suppliers.Columns.Add("Supplier", typeof(string));
            Suppliers.Columns.Add("Amount", typeof(decimal));
            Suppliers.PrimaryKey = new DataColumn[] { Suppliers.Columns["Supplier"] };
            var SuppAmount = new Dictionary<string, decimal>();
            int paramcounter = 0;
            int pricecounter = 0;
            string recipeids = "";
            decimal p = 0;
            List<decimal>totalPrice=new List<decimal>();
                catBO.catID = catID;
                RecBO.recipe = recipeDesc;
                foreach (DataRow row in RecBL.searchRecipeByName(RecBO).Rows)
                {
                    recipeids=row.ItemArray[0].ToString();
                }
                catBO.recipeid = recipeids;
                catBO.pax = paxTarget;
                catBO.guest = guest;

                foreach (DataRow supps in SuppBL.getSupplier().Rows)
                {
                    SuppAmount[supps.ItemArray[0].ToString()] = 0;
                }
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    RecBO.recipe = row.Cells[1].Value.ToString();
                    RecBO.cat = row.Cells[4].Value.ToString();
                    DataTable recipe = RecBL.searchRecipeSingle(RecBO);
                    foreach (DataRow rows in recipe.Rows)
                    {
                        catBO.recipeid = rows.ItemArray[0].ToString();
                        DataTable supps = catBL.getSuppPrices(catBO);
                        foreach (DataRow prices in supps.Rows)
                        {
                            if (!Suppliers.Rows.Contains(prices.ItemArray[1].ToString()))
                            {
                                Suppliers.Rows.Add(prices.ItemArray[1].ToString(), 0);
                            }
                            IngredientPrice.Add(Convert.ToDecimal(prices.ItemArray[0].ToString()));
                        }
                        recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
                        catBO.recipeid = rows.ItemArray[0].ToString();
                        catBO.catID = catID;
                    }
                }
                RecBO.recipeid = Convert.ToString(recipeids);
                DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                foreach (DataRow row in dt.Rows)
                {
                    //AddDish
                    p = p + getPrice(row.ItemArray[2].ToString(), paxTarget);
                    if (totalPrice.Count == 0)
                    {
                        decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(p);
                        if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                        {
                            qty = qty * Properties.Settings.Default.Plated;
                        }
                        SuppAmount[row.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[row.ItemArray[3].ToString()] + qty).ToString("0.##"));
                        totalPrice.Add(qty);
                    }
                    else
                    {
                        decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(p);
                        if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                        {
                            qty = qty * Properties.Settings.Default.Plated;
                        }
                        SuppAmount[row.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[row.ItemArray[3].ToString()] + qty).ToString("0.##"));
                        totalPrice[paramcounter] = totalPrice[paramcounter] + qty;

                    }
                    pricecounter = pricecounter + 1;
                    counter = counter + 1;
                    p = 0;
                }
                i = 0;
                //catBO.popoy = Convert.ToString(popoyP[paramcounter]);
                DataTable toInsert = new DataTable();
                toInsert.Columns.Add("Supplier", typeof(string));
                toInsert.Columns.Add("Amount", typeof(decimal));
                toInsert.PrimaryKey = new DataColumn[] { toInsert.Columns["Supplier"] };
                SuppBO.catid = catID;
                DataTable oldBudget = SuppBL.getSupplierBudget(SuppBO);
                foreach (DataRow Transfer in oldBudget.Rows)
                {
                        decimal TotalS = Convert.ToDecimal(Transfer.ItemArray[2].ToString()) - SuppAmount[Transfer.ItemArray[1].ToString()];
                        SuppBO.supp1 = Transfer.ItemArray[1].ToString();
                        SuppBO.amount = TotalS;
                        SuppBO.catid = catID;
                        SuppBL.UpdateSupplierBudget(SuppBO);
                        i = 0;
                }
                catBO.recipeid = recipeids;
                catBL.removeDish(catBO);
                notifier("Dish removed.");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.Tomato;
                catBO.catID = catID;
                catBO.category = "";
                showSelected();
        }
        List<string> prices = new List<string>();
        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView2, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                recipeDesc = row.Cells[1].Value.ToString();
                paxTarget = row.Cells[2].Value.ToString();
                guest = row.Cells[0].Value.ToString();
            }
        }
        public string recipeDesc { get; set; }
        public string price { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            catBO.service = comboBox3.Text.Trim();
            catBO.Status = "ACTIVE";
            if (Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")) >= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                if (dataGridView2.Rows.Count != 0)
                {
                    if (txtVip.Text != "" && textBox2.Text != "" && textBox3.Text != "" && txtGuest.Text != "" && txtKids.Text != "" && comboBox2.Text != ""&& txtCrew.Text != "" && txtOthers.Text != "" && comboBox3.Text != "" )
                    {
                        catBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        catBO.clientName = textBox2.Text;
                        catBO.vip = txtVip.Text.Trim();
                        catBO.guest = txtGuest.Text.Trim();
                        catBO.kids = txtKids.Text.Trim();
                        catBO.crew= txtCrew.Text.Trim();
                        catBO.placeOfEvent = textBox3.Text;
                        catBO.typeOfevent = comboBox2.Text;
                        catBO.other = txtOthers.Text.Trim();
                        catBO.service = comboBox3.Text.Trim();
                        catBO.Status ="ACTIVE";
                        catBO.catID = catID;
                        if (SelectedAction == "Add")
                        {
                            catBL.updateCatOrder(catBO);
                            Cursor = Cursors.Arrow;
                            isaccept = true;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            catBO.catID = catID;
                            int counter = 0;
                            List<double> IngredientPrice = new List<double>();
                            List<double> TotalPrice = new List<double>();
                            int paramcounter = 0;
                            catBO.category = "";
                            if (MessageBox.Show("Done updating event?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                DataTable dts=catBL.getCateringDish(catBO);
                                foreach (DataRow row in dts.Rows)
                                {
                                    guestarget = row.ItemArray[0].ToString();
                                    catBO.guest = guestarget;
                                    RecBO.recipe = row.ItemArray[1].ToString();
                                    RecBO.cat = row.ItemArray[2].ToString();
                                    DataTable dtt = RecBL.searchRecipeSingle(RecBO);
                                    foreach (DataRow rows in dtt.Rows)
                                    {
                                        catBO.recipeid = rows.ItemArray[0].ToString();
                                        DataTable Dts = catBL.getSuppPrices(catBO);
                                        foreach (DataRow prices in Dts.Rows)
                                        {
                                            IngredientPrice.Add(Convert.ToDouble(prices.ItemArray[0].ToString()));
                                        }
                                        catBO.catID = catID;
                                        RecBO.recipeid = rows.ItemArray[0].ToString();
                                        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                                        counter = 0;
                                        foreach (DataRow rowss in dt.Rows)
                                        {
                                            catBO.dishprice = price;
                                            if (guestarget=="VIP")
                                            {
                                                price = price + getPrice(rowss.ItemArray[2].ToString(), txtVip.Text.Trim()); 
                                            }
                                            else if(guestarget=="Guest")
                                            {
                                                price = price + getPrice(rowss.ItemArray[2].ToString(), txtGuest.Text.Trim());
                                            }
                                            else if (guestarget == "KIDS")
                                            {
                                                price = price + getPrice(rowss.ItemArray[2].ToString(), txtKids.Text.Trim());
                                            }
                                            else if (guestarget == "CREW")
                                            {
                                                price = price + getPrice(rowss.ItemArray[2].ToString(), txtCrew.Text.Trim());
                                            }
                                            else
                                            {
                                                price = price + getPrice(rowss.ItemArray[2].ToString(), txtOthers.Text.Trim());
                                            }
                                            if (TotalPrice.Count == 0)
                                            {
                                                TotalPrice.Add(IngredientPrice[counter] * Convert.ToDouble(price));
                                            }
                                            else
                                            {
                                                TotalPrice[paramcounter] = TotalPrice[paramcounter] + (IngredientPrice[counter] * Convert.ToDouble(price));
                                            }
                                            counter = counter + 1;
                                            price = "";
                                        }
                                        catBO.price= Convert.ToString(TotalPrice[paramcounter]);
                                        TotalPrice.Clear();
                                        IngredientPrice.Clear();
                                        //catBL.updateDishPrice(catBO);
                                    }
                                }
                                catBO.catID = catID;
                                catBO.clientName = textBox2.Text.Trim();
                                catBO.placeOfEvent = textBox3.Text.Trim();
                                catBO.vip = txtVip.Text.Trim();
                                catBO.guest = txtGuest.Text.Trim();
                                catBO.kids = txtKids.Text.Trim();
                                catBO.crew = txtCrew.Text.Trim();
                                catBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                                catBL.updateCatOrder(catBO);
                                isaccept = true;
                                DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else
                    {
                        time = 0;
                        notifier("Fill all the blanks!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }
                }
                else
                {
                    time = 0;
                    notifier("Select dishes to serve!");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
            }
            else
            {
                time = 0;
                notifier("Date is not valid!");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.Tomato;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public DataTable oldDishes { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            if (MessageBox.Show("Progress will be lost and not be saved.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SelectedAction == "Update")
                {
                    catBO.catID = catID;
                    catBL.removeDishes(catBO);
                    BO.catid = catID;
                    BL.deleteSupplierBudget(BO);
                    foreach (DataRow budget in oldsuppBud.Rows)
                    {
                        BO.catid = catID;
                        BO.supp1 = budget.ItemArray[1].ToString();
                        BO.amount = budget.ItemArray[2].ToString();
                        BL.addSuppBudget(BO);
                    }
                    foreach (DataRow row in oldDishes.Rows)
                    {
                        catBO.catID = catID;
                        RecBO.recipe = row.ItemArray[1].ToString();
                        DataTable dt= RecBL.searchRecipeByName(RecBO);
                        foreach (DataRow rows in dt.Rows)
                        {
                            catBO.recipeid = rows.ItemArray[0].ToString();
                        }
                        catBO.price = row.ItemArray[4].ToString();
                        catBO.pax = row.ItemArray[3].ToString();
                        catBO.guest = row.ItemArray[0].ToString();
                        catBL.addCatDish(catBO);
                    }
                    cancelButton = true;
                    isaccept = false;
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    catBO.catID = catID;
                    catBO.inuse = "0";
                    catBL.ChangeEventInuse(catBO);
                    BO.catid = catID;
                    BL.deleteSupplierBudget(BO);
                    cancelButton = true;
                    isaccept = false;
                    catBL.removeDishes(catBO);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            diagAddRecipe rec = new diagAddRecipe("New", "");
            if (rec.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            if (isaccept != true && cancelButton == false)
            {
                if (MessageBox.Show("Progress will be lost and not be saved.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SelectedAction == "Update")
                    {
                        catBO.catID = catID;
                        catBL.removeDishes(catBO);
                        foreach (DataRow row in oldDishes.Rows)
                        {
                            catBO.catID = catID;
                            RecBO.recipe = row.ItemArray[1].ToString();
                            DataTable dt = RecBL.searchRecipeByName(RecBO);
                            BO.catid = catID;
                            BL.deleteSupplierBudget(BO);
                            foreach (DataRow budget in oldsuppBud.Rows)
                            {
                                BO.catid = catID;
                                BO.supp1 = budget.ItemArray[1].ToString();
                                BO.amount = budget.ItemArray[2].ToString();
                                BL.addSuppBudget(BO);
                            }
                            foreach (DataRow rows in dt.Rows)
                            {
                                catBO.recipeid = rows.ItemArray[0].ToString();
                            }
                            catBO.price = row.ItemArray[4].ToString();
                            catBO.pax = row.ItemArray[3].ToString();
                            catBO.guest = row.ItemArray[0].ToString();
                            catBL.addCatDish(catBO);
                        }
                        cancelButton = true;
                        isaccept = false;
                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        catBO.catID = catID;
                        catBO.inuse = "0";
                        catBL.ChangeEventInuse(catBO);
                        BO.catid = catID;
                        BL.deleteSupplierBudget(BO);
                        catBL.removeDishes(catBO);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void button3_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void frmMenu_ImeModeChanged(object sender, EventArgs e)
        {

        }

        public bool isaccept = false;

        public bool cancelButton = false;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //catBL = new CateringBL();
            //catBO = new CateringBO();
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //int recipeid = 0;
            //double price = 0;
            //int count = 0;
            //int counter = 0;
            //List<double> popoy = new List<double>();
            //List<double> cdad = new List<double>();
            //List<double> supp = new List<double>();
            //List<double> popoyP = new List<double>();
            //List<double> cdadP = new List<double>();
            //List<double> suppP = new List<double>();
            //int paramcounter = 0;
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    if (textBox1.Text != "")
            //    {
            //        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //        {
            //            RecBO.recipe = row.Cells[0].Value.ToString();
            //            RecBO.cat = comboBox1.Text.Trim();
            //            foreach (DataRow rows in RecBL.searchRecipe(RecBO).Rows)
            //            {
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                foreach (DataRow prices in catBL.getSuppPrices(catBO).Rows)
            //                {
            //                    popoy.Add(Convert.ToDouble(prices.ItemArray[0].ToString()));
            //                    cdad.Add(Convert.ToDouble(prices.ItemArray[1].ToString()));
            //                    supp.Add(Convert.ToDouble(prices.ItemArray[2].ToString()));
            //                }
            //                recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                catBO.catID = catID;
            //            }
            //        }
            //        RecBO.recipeid = Convert.ToString(recipeid);
            //        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            price = price + Convert.ToDouble(getPrice(row.ItemArray[2].ToString(), textBox1.Text.Trim()));
            //            if (popoyP.Count == 0)
            //            {
            //                popoyP.Add(popoy[counter] * Convert.ToDouble(price));
            //                cdadP.Add(cdad[counter] * Convert.ToDouble(price));
            //                suppP.Add(supp[counter] * Convert.ToDouble(price));
            //            }
            //            else
            //            {
            //                popoyP[paramcounter] = popoyP[paramcounter] + (popoy[counter] * Convert.ToDouble(price));
            //                cdadP[paramcounter] = cdadP[paramcounter] + (cdad[counter] * Convert.ToDouble(price));
            //                suppP[paramcounter] = suppP[paramcounter] + (supp[counter] * Convert.ToDouble(price));
            //            }
            //            counter = counter + 1;
            //            price = 0;
            //        }
            //        catBO.popoy = Convert.ToString(popoyP[paramcounter]);
            //        catBO.cdad = Convert.ToString(cdadP[paramcounter]);
            //        catBO.supp = Convert.ToString(suppP[paramcounter]);
            //        catBO.guest = "VIP";
            //        catBO.pax = textBox1.Text.Trim();
            //        catBL.addCatDish(catBO);
            //        catBO.catID = catID;
            //        time = 0;
            //        notifier("Dish successfully added.");
            //        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
            //        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            //        catBO.catID = catID;
            //        catBO.category = "";
            //        dataGridView2.DataSource = catBL.getCateringDishWithoutPrice(catBO);
            //    }
            //}
            Adddish(txtVip.Text,"VIP");
        }
        private void addDishToGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adddish(txtGuest.Text,"Guest");
        }
        public void Adddish(string pax,string Target)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            SupplierBL SuppBL=new SupplierBL();
            SupplierBO SuppBO=new SupplierBO();
            int recipeid = 0;
            decimal price = 0;
            int count = 0;
            int counter = 0; 
            int pricecounter = 0;
            List<decimal> popoy = new List<decimal>();
            List<decimal> cdad = new List<decimal>();
            List<decimal> supp = new List<decimal>();
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> totalPrice = new List<decimal>();
            List<decimal> IngredientPrice = new List<decimal>();
            List<string> Categories = new List<string>();
            string typeofevent = "";
            DataTable Suppliers = new DataTable();
            Suppliers.Columns.Add("Supplier",typeof(string));
            Suppliers.Columns.Add("Amount", typeof(decimal));
            Suppliers.PrimaryKey = new DataColumn[] { Suppliers.Columns["Supplier"] };
            var SuppAmount = new Dictionary<string, decimal>();
            int paramcounter = 0;
            if (pax != "")
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    if (Target != "")
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            RecBO.recipe = row.Cells[0].Value.ToString();
                            RecBO.cat = comboBox1.Text.Trim();
                            DataTable Recipe = RecBL.searchRecipeSingle(RecBO);
                            foreach (DataRow rows in Recipe.Rows)
                            {
                                catBO.recipeid = rows.ItemArray[0].ToString();
                                DataTable supps = catBL.getSuppPrices(catBO);
                                foreach (DataRow prices in supps.Rows)
                                {
                                    if (!SuppAmount.Keys.Contains(prices.ItemArray[1].ToString()))
                                    {
                                        SuppAmount[prices.ItemArray[1].ToString()] = 0;
                                    }

                                    if (!Suppliers.Rows.Contains(prices.ItemArray[1].ToString()))
                                    {

                                        Suppliers.Rows.Add(prices.ItemArray[1].ToString());
                                    }
                                    IngredientPrice.Add(Convert.ToDecimal(prices.ItemArray[0].ToString()));
                                }
                                recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
                                catBO.recipeid = rows.ItemArray[0].ToString();
                                catBO.catID = catID;
                            }
                        }
                        RecBO.recipeid = Convert.ToString(recipeid);
                        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                        foreach (DataRow row in dt.Rows)
                        {
                            //AddDish
                            price = price + getPrice(row.ItemArray[2].ToString(), pax);
                            if (totalPrice.Count == 0)
                            {
                                decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                SuppAmount[row.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[row.ItemArray[3].ToString()] + qty).ToString("0.##"));
                                totalPrice.Add(qty);
                            }
                            else
                            {
                                decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                SuppAmount[row.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[row.ItemArray[3].ToString()] + qty).ToString("0.##"));
                                totalPrice[paramcounter] = totalPrice[paramcounter] + qty;

                            }
                            pricecounter = pricecounter + 1;
                            price = 0;
                        }
                        i = 0;
                        //catBO.popoy = Convert.ToString(popoyP[paramcounter]);
                        DataTable toInsert = new DataTable();
                        toInsert.Columns.Add("Supplier", typeof(string));
                        toInsert.Columns.Add("Amount", typeof(decimal));
                        toInsert.PrimaryKey = new DataColumn[] { toInsert.Columns["Supplier"] };
                        SuppBO.catid = catID;
                        DataTable oldBudget = SuppBL.getSupplierBudget(SuppBO);
                        foreach (DataRow Transfer in oldBudget.Rows)
                        {
                            if (SuppAmount.Keys.Contains(Transfer.ItemArray[1].ToString()))
                            {
                                decimal TotalS = SuppAmount[Transfer.ItemArray[1].ToString()] + Convert.ToDecimal(Transfer.ItemArray[2].ToString());
                                SuppBO.supp1 = Transfer.ItemArray[1].ToString();
                                SuppBO.amount = TotalS;
                                SuppBO.catid = catID;
                                SuppBL.UpdateSupplierBudget(SuppBO);
                                i = 0;
                            }
                            else
                            {

                            }
                        }
                        if (oldBudget.Rows.Count == 0)
                        {
                            foreach (DataRow insert in Suppliers.Rows)
                            {
                                if (SuppAmount.Keys.Contains(insert.ItemArray[0].ToString()))
                                {
                                    SuppBO.supp1 = insert.ItemArray[0].ToString();
                                    SuppBO.amount = SuppAmount[insert.ItemArray[0].ToString()].ToString("0.##");
                                    SuppBO.catid = catID;
                                    SuppBL.addSuppBudget(SuppBO);
                                }
                            }
                        }
                        catBO.price = totalPrice[paramcounter].ToString("0.##");
                        catBO.guest = Target;
                        catBO.pax = pax;
                        catBL.addCatDish(catBO);
                        catBO.catID = catID;
                        time = 0;
                        notifier("Dish successfully added.");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                        showSelected();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter the PAX!");
            }
        }
        public void showSelected()
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            catBO.catID = catID;
            catBO.category = "";
            dataGridView2.Rows.Clear();
            DataTable dt= catBL.getCateringDishWithoutPrice(catBO);
            foreach (DataRow dishes in dt.Rows)
            {
                dataGridView2.Rows.Add(dishes.ItemArray[0].ToString(), dishes.ItemArray[1].ToString(), dishes.ItemArray[2].ToString(), dishes.ItemArray[4].ToString(), dishes.ItemArray[3].ToString());
            }
        }
        private void addDishToKidsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //catBL = new CateringBL();
            //catBO = new CateringBO();
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //int recipeid = 0;
            //double price = 0;
            //int count = 0;
            //int counter = 0;
            //List<double> popoy = new List<double>();
            //List<double> cdad = new List<double>();
            //List<double> supp = new List<double>();
            //List<double> popoyP = new List<double>();
            //List<double> cdadP = new List<double>();
            //List<double> suppP = new List<double>();
            //int paramcounter = 0;
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    if (textBox6.Text != "")
            //    {
            //        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //        {
            //            RecBO.recipe = row.Cells[0].Value.ToString();
            //            RecBO.cat = comboBox1.Text.Trim();
            //            foreach (DataRow rows in RecBL.searchRecipe(RecBO).Rows)
            //            {
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                foreach (DataRow prices in catBL.getSuppPrices(catBO).Rows)
            //                {
            //                    popoy.Add(Convert.ToDouble(prices.ItemArray[0].ToString()));
            //                    cdad.Add(Convert.ToDouble(prices.ItemArray[1].ToString()));
            //                    supp.Add(Convert.ToDouble(prices.ItemArray[2].ToString()));
            //                }
            //                recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                catBO.catID = catID;
            //            }
            //        }
            //        RecBO.recipeid = Convert.ToString(recipeid);
            //        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            //price = price + getPrice(row.ItemArray[2].ToString(), textBox6.Text.Trim());
            //            if (popoyP.Count == 0)
            //            {
            //                popoyP.Add(popoy[counter] * Convert.ToDouble(price));
            //                cdadP.Add(cdad[counter] * Convert.ToDouble(price));
            //                suppP.Add(supp[counter] * Convert.ToDouble(price));
            //            }
            //            else
            //            {
            //                popoyP[paramcounter] = popoyP[paramcounter] + (popoy[counter] * Convert.ToDouble(price));
            //                cdadP[paramcounter] = cdadP[paramcounter] + (cdad[counter] * Convert.ToDouble(price));
            //                suppP[paramcounter] = suppP[paramcounter] + (supp[counter] * Convert.ToDouble(price));
            //            }
            //            counter = counter + 1;
            //            price = 0;
            //        }
            //        catBO.popoy = Convert.ToString(popoyP[paramcounter]);
            //        catBO.cdad = Convert.ToString(cdadP[paramcounter]);
            //        catBO.supp = Convert.ToString(suppP[paramcounter]);
            //        catBO.guest = "KIDS";
            //        catBO.pax = textBox6.Text.Trim();
            //        catBL.addCatDish(catBO);
            //        catBO.catID = catID;
            //        time = 0;
            //        notifier("Dish successfully added.");
            //        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
            //        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            //        catBO.catID = catID;
            //        catBO.category = "";
            //        dataGridView2.DataSource = catBL.getCateringDish(catBO);
            //    }
            //}
            Adddish(txtKids.Text,"KIDS");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, e.Location);
            }
        }

        private void addDishToCrewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //catBL = new CateringBL();
            //catBO = new CateringBO();
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //int recipeid = 0;
            //double price = 0;
            //int count = 0;
            //int counter = 0;
            //List<double> popoy = new List<double>();
            //List<double> cdad = new List<double>();
            //List<double> supp = new List<double>();
            //List<double> popoyP = new List<double>();
            //List<double> cdadP = new List<double>();
            //List<double> suppP = new List<double>();
            //int paramcounter = 0;
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    if (textBox7.Text != "")
            //    {
            //        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //        {
            //            RecBO.recipe = row.Cells[0].Value.ToString();
            //            RecBO.cat = comboBox1.Text.Trim();
            //            foreach (DataRow rows in RecBL.searchRecipe(RecBO).Rows)
            //            {
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                foreach (DataRow prices in catBL.getSuppPrices(catBO).Rows)
            //                {
            //                    popoy.Add(Convert.ToDouble(prices.ItemArray[0].ToString()));
            //                    cdad.Add(Convert.ToDouble(prices.ItemArray[1].ToString()));
            //                    supp.Add(Convert.ToDouble(prices.ItemArray[2].ToString()));
            //                }
            //                recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
            //                catBO.recipeid = rows.ItemArray[0].ToString();
            //                catBO.catID = catID;
            //            }
            //        }
            //        RecBO.recipeid = Convert.ToString(recipeid);
            //        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            //price = price + getPrice(row.ItemArray[2].ToString(), textBox7.Text.Trim());
            //            if (popoyP.Count == 0)
            //            {
            //                popoyP.Add(popoy[counter] * Convert.ToDouble(price));
            //                cdadP.Add(cdad[counter] * Convert.ToDouble(price));
            //                suppP.Add(supp[counter] * Convert.ToDouble(price));
            //            }
            //            else
            //            {
            //                popoyP[paramcounter] = popoyP[paramcounter] + (popoy[counter] * Convert.ToDouble(price));
            //                cdadP[paramcounter] = cdadP[paramcounter] + (cdad[counter] * Convert.ToDouble(price));
            //                suppP[paramcounter] = suppP[paramcounter] + (supp[counter] * Convert.ToDouble(price));
            //            }
            //            counter = counter + 1;
            //            price = 0;
            //        }
            //        catBO.popoy = Convert.ToString(popoyP[paramcounter]);
            //        catBO.cdad = Convert.ToString(cdadP[paramcounter]);
            //        catBO.supp = Convert.ToString(suppP[paramcounter]);
            //        catBO.guest = "CREW";
            //        catBO.pax = textBox7.Text.Trim();
            //        catBL.addCatDish(catBO);
            //        catBO.catID = catID;
            //        time = 0;
            //        notifier("Dish successfully added.");
            //        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
            //        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            //        catBO.catID = catID;
            //        catBO.category = "";
            //        dataGridView2.DataSource = catBL.getCateringDishWithoutPrice(catBO);
            //    }
            //}
            Adddish(txtCrew.Text,"CREW");
        }

        public string guestarget { get; set; }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addDishToOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            int recipeid = 0;
            decimal price = 0;
            int count = 0;
            int counter = 0;
            List<decimal> IngredientPrice = new List<decimal>();
            List<decimal> cdad = new List<decimal>();
            List<decimal> supp = new List<decimal>();
            List<decimal> TotalPrice = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            int paramcounter = 0;
            if (dataGridView1.Rows.Count != 0)
            {
                if (txtOthers.Text != "")
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        RecBO.recipe = row.Cells[0].Value.ToString();
                        RecBO.cat = comboBox1.Text.Trim();
                        foreach (DataRow rows in RecBL.searchRecipeSingle(RecBO).Rows)
                        {
                            catBO.recipeid = rows.ItemArray[0].ToString();
                            foreach (DataRow prices in catBL.getSuppPrices(catBO).Rows)
                            {
                                IngredientPrice.Add(Convert.ToDecimal(prices.ItemArray[0].ToString()));
                               
                            }
                            recipeid = Convert.ToInt32(rows.ItemArray[0].ToString());
                            catBO.recipeid = rows.ItemArray[0].ToString();
                            catBO.catID = catID;
                        }
                    }
                    RecBO.recipeid = Convert.ToString(recipeid);
                    DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                    foreach (DataRow row in dt.Rows)
                    {
                        price = price + (getPrice(row.ItemArray[2].ToString(), txtOthers.Text.Trim()));
                        if (TotalPrice.Count == 0)
                        {
                            TotalPrice.Add(IngredientPrice[counter] * Convert.ToDecimal(price));
                           
                        }
                        else
                        {
                            TotalPrice[paramcounter] = TotalPrice[paramcounter] + (IngredientPrice[counter] * Convert.ToDecimal(price));
                        }
                        counter = counter + 1;
                        price = 0;
                    }
                    catBO.price = TotalPrice[paramcounter].ToString("0.##");
                    Form1 diagOthers=new Form1();
                    if (diagOthers.ShowDialog() == DialogResult.OK)
                    {
                        catBO.guest = diagOthers.oName;
                    }
                    else
                    {
                        catBO.guest = "OTHERS";
                    }
                    catBO.pax = txtOthers.Text.Trim();
                    catBL.addCatDish(catBO);
                    catBO.catID = catID;
                    time = 0;
                    notifier("Dish successfully added.");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                    catBO.catID = catID;
                    catBO.category = "";
                    showSelected();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string guest { get; set; }
        public string paxTarget { get; set; }

        public bool inuse { get; set; }

        public string NotInuseID { get; set; }

        public int i = 0;

        public DataTable oldsuppBud { get; set; }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox5.Text = "";
            textBox5.Focus();
        }

        private void textBox5_LocationChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TabStopChanged(object sender, EventArgs e)
        {

        }
    }
}
