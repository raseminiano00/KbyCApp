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
    public partial class frmChef : Form
    {
        public frmChef()
        {
            InitializeComponent();
        }
        
        IngredientBL IngBL;
        IngredientBO IngBO;
        RecipeBL RecipeBL;
        RecipeBO RecipeBO;
        CateringBL catBL;
        CateringBO catBO;
        DataTable reserve = new DataTable();
        DataTable ResultQty = new DataTable();
        List<Dish> selectedDishes = new List<Dish>();
        private void frmChef_Load(object sender, EventArgs e)
        {
            result = new DataTable();
            result.Columns.Add("1");
            result.Columns.Add("2");
            result.Columns.Add("3");
            showerdt = new DataTable();
            reserve = new DataTable();
            showerdt.Columns.Add("Dish");
            showerdt.Columns.Add("PAX");
            comboBox1.Text = "Appetizer";
            reserve.Columns.Add("1");
            reserve.Columns.Add("2");
            ResultQty = new DataTable();
            ResultQty.Columns.Add("1");
            ResultQty.Columns.Add("2");
          
        }
        public int parameter { get; set; }

        public int counter { get; set; }

        public int opercounter = 1;

        public string formula { get; set; }

        public int lngthofstring { get; set; }

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
        
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            RecipeBL RecipeBL = new RecipeBL();
            RecipeBO RecipeBO = new RecipeBO();
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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Search box")
            {
                textBox5.ForeColor = Color.Black;
                this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                textBox5.Text = "";
            }
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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, e.Location);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView2, e.Location);
            }
        }

        private void addDishToGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            catBL = new CateringBL();
            catBO = new CateringBO();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                addSingleDish(txtGuest.Text);
            }
            else
            {
                addSingleDish(txtGuest.Text);
            }
        }
        RecipeBL RecBL;
        RecipeBO RecBO;
        DataTable result = new DataTable();
        DataTable showerdt = new DataTable();
        decimal totalExpense = 0;
        public void addSingleDish(string pax)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            decimal dishprice = 0;
            SupplierBL SuppBL = new SupplierBL();
            SupplierBO SuppBO = new SupplierBO();
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
            Suppliers.Columns.Add("Supplier", typeof(string));
            Suppliers.Columns.Add("Amount", typeof(decimal));
            Suppliers.PrimaryKey = new DataColumn[] { Suppliers.Columns["Supplier"] };
            var SuppAmount = new Dictionary<string, decimal>();
            string dishName="";
            int paramcounter = 0;
            if (pax != "")
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {

                        dishselected++;
                        dishName = row.Cells[0].Value.ToString();
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
                            showerdt.Rows.Add(row.Cells[0].Value.ToString(),pax);
                        }
                        result.Rows.Add(dishselected+": "+row.Cells[0].Value.ToString()+" (PAX:"+txtGuest.Text+" SERVICE:"+comboBox3.Text+")", "Quantity", "Price");
                        ResultQty.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")", "Quantity");
                        reserve.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")");
                        RecBO.recipeid = Convert.ToString(recipeid);
                        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                        foreach (DataRow rowss in dt.Rows)
                        {
                            //AddDish
                            price = price + getPrice(rowss.ItemArray[2].ToString(), pax);
                            if (totalPrice.Count == 0)
                            {
                                decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                dishprice = dishprice + qty;
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice.Add(qty);
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                            }
                            else
                            {
                                decimal qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                dishprice = dishprice + qty;
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice[paramcounter] = totalPrice[paramcounter] + qty;
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                            }
                            pricecounter = pricecounter + 1;
                            price = 0;
                        }
                    }
                    totalExpense = totalPrice[0] + totalExpense;
                    dataGridView2.DataSource = showerdt;
                    ResultQty.Rows.Add("", "");
                    result.Rows.Add("Total ", "-------------", "P " + dishprice.ToString("0.##"));
                    result.Rows.Add("","","");
                    dishprice = 0;
                }
                notifier("Dish added!");
                dishAdded(dishName, comboBox1.Text, Convert.ToInt32(pax), comboBox3.Text, recipeid.ToString());

            }
            else
            {
                MessageBox.Show("Enter the PAX!");
            }
        }
        public void addAllDish(string pax)
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            decimal dishprice = 0;
            SupplierBL SuppBL = new SupplierBL();
            SupplierBO SuppBO = new SupplierBO();
            int recipeid = 0;
            decimal price = 0;
            int count = 0;
            int counter = 0;
            int pricecounter = 0;
            string dishName = "";
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
            Suppliers.Columns.Add("Supplier", typeof(string));
            Suppliers.Columns.Add("Amount", typeof(decimal));
            Suppliers.PrimaryKey = new DataColumn[] { Suppliers.Columns["Supplier"] };
            var SuppAmount = new Dictionary<string, decimal>();
            int paramcounter = 0;

            if (pax != "")
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dishselected++;
                        dishName = row.Cells[0].Value.ToString(); 
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
                            showerdt.Rows.Add(row.Cells[0].Value.ToString(), pax);
                            
                        }
                        result.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")", "Quantity", "Price");
                        ResultQty.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")", "Quantity");
                        reserve.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")");
                        RecBO.recipeid = Convert.ToString(recipeid);
                        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                        decimal qty = 0;
                        foreach (DataRow rowss in dt.Rows)
                        {
                            //AddDish
                            price = price + getPrice(rowss.ItemArray[2].ToString(), pax);
                            if (totalPrice.Count == 0)
                            {
                               qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice.Add(qty);
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                                dishprice = dishprice + qty;
                            }
                            else
                            {
                               qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice[paramcounter] = totalPrice[paramcounter] + qty;
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                                dishprice = dishprice + qty;

                            }
                            pricecounter = pricecounter + 1;
                            price = 0;
                        }

                        ResultQty.Rows.Add("","");
                        result.Rows.Add("Total ", "-------------", "P " + dishprice.ToString("0.##"));
                        dishprice = 0;
                        result.Rows.Add("", "", "");
                        dishAdded(dishName, comboBox1.Text,Convert.ToInt32(pax),comboBox3.Text, recipeid.ToString());
                    }
                    totalExpense = totalPrice[0] + totalExpense;
                    dataGridView2.DataSource = showerdt;
                    notifier("All Dish added!");
                }
            }
            else
            {
                MessageBox.Show("Enter the PAX!");
            }
        }
        private void notifier(string notif)
        {
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }
        public string catID = "0";

        public int time { get; set; }

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

        public int i { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                if (first == true)
                {
                    result.Rows.Add("Total Expense", "", "P. " + totalExpense.ToString("0.##"));
                    first = false;
                }
                else
                {
                    for (int i = result.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow drs = result.Rows[i];
                        if (drs["1"] == "Total Expense")
                            drs.Delete();
                    }
                    result.AcceptChanges();
                    result.Rows.Add("Total Expense", "", "P. " + totalExpense.ToString("0.##"));
                }
                diagReport dr = new diagReport(result, "PO");
                dr.Show();
            }
            else
            {
                MessageBox.Show("Select dish!");
            }
            
        }

        public int dishselected = 0;

        public bool first = true;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addAllDish(txtGuest.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result.Rows.Clear();
            ResultQty.Rows.Clear();
            first = true;
            showerdt.Rows.Clear();
            dishselected = 0;
            dataGridView2.DataSource = showerdt;
            totalExpense = 0;
        }

        private void removeDishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isdelete=false;
            int index = dataGridView2.SelectedRows[0].Index;
            string delete = "";

            string next = "";
            int count = 0;
            foreach (DataRow row in reserve.Rows)
            {
                if (count == index)
                {

                    delete = row.ItemArray[0].ToString();
                    break;
                }
                count++;
            }

            foreach (DataRow row in reserve.Rows)
            {
                if (count == index+1)
                {

                    next = row.ItemArray[0].ToString();
                    break;
                }
                count++;
            }
            for (int i = 0; i <= result.Rows.Count - 1; i++)
            {
                DataRow drs = result.Rows[i];
                if (drs[0] == delete)
                    isdelete = true;
                if (drs[0] == next)
                    isdelete = false;
                if (isdelete)
                {
                    drs.Delete();
                }
            }
            removeDish(index);
        }
        public void addAlteredDish()
        {
            catBL = new CateringBL();
            catBO = new CateringBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            decimal dishprice = 0;
            SupplierBL SuppBL = new SupplierBL();
            SupplierBO SuppBO = new SupplierBO();
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
            Suppliers.Columns.Add("Supplier", typeof(string));
            Suppliers.Columns.Add("Amount", typeof(decimal));
            Suppliers.PrimaryKey = new DataColumn[] { Suppliers.Columns["Supplier"] };
            var SuppAmount = new Dictionary<string, decimal>();
            int paramcounter = 0;

                if (dataGridView2.Rows.Count != 0)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        dishselected++;
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
                        result.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")", "Quantity", "Price");
                        ResultQty.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")", "Quantity");
                        reserve.Rows.Add(dishselected + ": " + row.Cells[0].Value.ToString() + " (PAX:" + txtGuest.Text + " SERVICE:" + comboBox3.Text + ")");
                        RecBO.recipeid = Convert.ToString(recipeid);
                        DataTable dt = RecBL.getIngByRecIdOrig(RecBO);
                        decimal priceout = 0;
                        decimal qty = 0;
                        foreach (DataRow rowss in dt.Rows)
                        {
                            //AddDish
                            price = price + getPrice(rowss.ItemArray[2].ToString(), row.Cells[1].Value.ToString());
                            if (totalPrice.Count == 0)
                            {
                                qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                dishprice = dishprice + qty;
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice.Add(qty);
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                            }
                            else
                            {
                                qty = IngredientPrice[pricecounter] * Convert.ToDecimal(price);
                                if (comboBox1.Text == "Main dish" && comboBox3.Text == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                    price = price * Properties.Settings.Default.Plated;
                                }
                                dishprice = dishprice + qty;
                                SuppAmount[rowss.ItemArray[3].ToString()] = Convert.ToDecimal((SuppAmount[rowss.ItemArray[3].ToString()] + qty));
                                totalPrice[paramcounter] = totalPrice[paramcounter] + qty;
                                result.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString(), "P. " + qty.ToString("0.##"));
                                ResultQty.Rows.Add("   " + rowss.ItemArray[4].ToString(), price + " " + rowss.ItemArray[5].ToString());
                            }
                            pricecounter = pricecounter + 1;
                            price = 0;
                        }

                        ResultQty.Rows.Add("", "");
                        result.Rows.Add("Total ", "-------------", "P " + dishprice.ToString("0.##"));
                        result.Rows.Add("", "", "");
                        dishprice = 0;
                    }
                    if (totalPrice.Count != 0)
                    {
                        totalExpense = totalPrice[0] + totalExpense;
                    }
                    notifier("Dish deleted!");
                }
            
        }

        private void removeDishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           int count = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (dataGridView2.SelectedRows[0].Index==count)
                {
                    dataGridView2.Rows.Remove(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index]); 
                }
                count++;
            }
            result.Rows.Clear();
            ResultQty.Rows.Clear();
            first = true;
            dishselected = 0;
            totalExpense = 0;
            addAlteredDish();
            notifier("Dish removed!");
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                if (first == true)
                {
                    first = false;
                }
                else
                {
                    for (int i = ResultQty.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow drs = ResultQty.Rows[i];
                        if (drs["1"] == "Total Expense")
                            drs.Delete();
                    }
                    ResultQty.AcceptChanges();
                }
                diagReport dr = new diagReport(ResultQty, "PO");
                dr.Show();
            }
            else
            {
                MessageBox.Show("Select dish!");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            catBO = new CateringBO();
            catBL = new CateringBL();
            DataTable eventdetail;
            DataTable eventDishes;
            DataTable dishesrecipe;
            DataTable Others = new DataTable();
            Others.Columns.Add("1");
            Others.Columns.Add("2");
            Others.Columns.Add("3");
            Others.Columns.Add("4");
            Others.Columns.Add("5");
            Others.Columns.Add("6");
            DataTable ingredients = new DataTable();
            ingredients.Columns.Add("1", typeof(String));
            ingredients.Columns.Add("2");
            ingredients.Columns.Add("3");
            ingredients.Columns.Add("4");
            ingredients.Columns.Add("5");
            ingredients.Columns.Add("6");
            ingredients.PrimaryKey = new DataColumn[] { ingredients.Columns["1"] };
            DataTable popoy = new DataTable();
            popoy.Columns.Add("name", typeof(String));
            popoy.Columns.Add("2");
            popoy.Columns.Add("3");
            popoy.Columns.Add("4");
            popoy.Columns.Add("5");
            popoy.Columns.Add("6");
            popoy.Columns.Add("7");
            DataTable cdad = new DataTable();
            cdad.Columns.Add("name", typeof(String));
            cdad.Columns.Add("2");
            cdad.Columns.Add("3");
            cdad.Columns.Add("4");
            cdad.Columns.Add("5");
            cdad.Columns.Add("6");
            cdad.Columns.Add("7");
            DataTable supps = new DataTable();
            supps.Columns.Add("name", typeof(String));
            supps.Columns.Add("2");
            supps.Columns.Add("3");
            supps.Columns.Add("4");
            supps.Columns.Add("5");
            supps.Columns.Add("6");
            supps.Columns.Add("7");
            List<string> Categories = new List<string>();
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            Excel.Columns.Add("7");
            Excel.Columns.Add("8");
            string pax = "";
            int categoryshower = 0;
            int categoryshowerO = 0;
            string lastCat = "";
            string lastCatOther = "";
            List<double> popoyP = new List<double>();
            List<double> cdadP = new List<double>();
            List<double> suppP = new List<double>();
            List<double> popoyPO = new List<double>();
            List<double> cdadPO = new List<double>();
            List<decimal> Total = new List<decimal>();
            DataTable suppliers = new DataTable();
            suppliers.Columns.Add("Supp");
            string typeofservice = "";
            string category = "";
            double popoyFP = 0;
            double cdadFP = 0;
            double suppFP = 0;
            string guestType = "";
            foreach (DataRow supp in BL.getSupplier().Rows)
            {
                suppliers.Rows.Add(supp.ItemArray[0].ToString());
            }
            if (selectedDishes.Count()>0)
            {
                Excel.Rows.Add("P.O Of Ingredients", "", "", "", "");
                Excel.Rows.Add("", "", "", "", "");
                Excel.Rows.Add("Ingredient", "Quantity", " Budget");
                int rowcounter = 0;
                //categorysorter = Categories.Count();
                string recid = "";
                foreach(Dish dish in selectedDishes)
                {
                    ingredients.Merge(dish.GetIngredientsListWithCost());
                }
                decimal OverAll = 0;
                Excel.Rows.Add("", "", "", "", "", "");
                categoryshower = 0;
                counter = counter + 1;
                DataView ingredientSorted = new DataView(ingredients);
                ingredientSorted.Sort = "[1] ASC";
                foreach (DataRow supplier in suppliers.Rows)
                {
                    Excel.Rows.Add(supplier.ItemArray[0].ToString().ToUpper(), "", "");
                    foreach (DataRowView ingredient in ingredientSorted)
                    {
                        IngBO.ing = ingredient[0].ToString();
                        DataTable dt = IngBL.searchIngredientReturnPrice(IngBO);
                        string suppliedby = ingredient[1].ToString();
                        if (supplier.ItemArray[0].ToString() == suppliedby)
                        {
                            foreach (DataRow price in dt.Rows)
                            {
                                Total.Add(Convert.ToDecimal(ingredient[2].ToString()) * Convert.ToDecimal(price.ItemArray[4].ToString()));
                                Excel.Rows.Add(" " + ingredient[0].ToString(), ingredient[2].ToString() + " " + price.ItemArray[2].ToString(), "P " + (Convert.ToDecimal(ingredient[2].ToString()) * Convert.ToDecimal(price.ItemArray[4].ToString())).ToString("0.##"));
                            }
                        }
                    }
                    Excel.Rows.Add("", "", "");
                    Excel.Rows.Add("Budget for " + supplier.ItemArray[0].ToString(), "", "P " + (Total.Sum()).ToString("0.##"));
                    Excel.Rows.Add("", "", "");
                    Excel.Rows.Add("", "", "");
                    OverAll = OverAll + Total.Sum();
                    Total.Clear();
                }
                Excel.Rows.Add("", "Grand Total", "P " + OverAll.ToString("0.##"));
                diagReport menu = new diagReport(Excel, "PO");
                menu.Show();
            }
            else
            {
                time = 0;
                notifier("Please select Dish");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.Tomato;
            }
        }
        private void dishAdded(string dishName, string category, int pax, string typeOfService, string recipeID)
        {
            this.selectedDishes.Add(new Dish(dishName, category, pax, typeOfService, recipeID));
        }
        private void removeDish(int index)
        {
            this.selectedDishes.RemoveAt(index);
        }
    }
}
