using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Catering_Menu
{
    public partial class frmCatering : Form
    {
        public frmCatering()
        {
            InitializeComponent();
        }
        CateringBL CatBL;
        CateringBO CatBO;
        IngredientBL IngBL;
        IngredientBO IngBO;
        RecipeBL RecBL;
        RecipeBO RecBO;
        decimal totalPriceP = 0;
        decimal totalPriceC = 0;
        decimal totalPriceS = 0;
        private void frmCatering_Load(object sender, EventArgs e)
        {
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            getEventsSpecificDate(Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")));
            CatBO.DateOfEvent=DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            try
            {
                DataTable dt = CatBL.checkEventIfDone(CatBO);
                foreach (DataRow row in dt.Rows)
                {
                    if (row.ItemArray[0].ToString() != "DONE")
                    {
                        CatBO.DateOfEvent = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                        CatBL.updateAllActiveEvent(CatBO);
                        time = 0;
                        notifier("Yesterday events are all done!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                        dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                        dataGridView2.DataSource = "";
                        groupBox2.Text = "Event details";  
                    }
                }
            }
            catch (Exception)
            {
                frmSysSettings sys = new frmSysSettings();
                sys.Show();
                this.Hide();
            }
        }
        private void getEventsSpecificDate(string date)
        {
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            try
            {
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            catch (Exception)
            {
                MessageBox.Show("You cant connect to database please setup the connection!");
                frmSysSettings sys = new frmSysSettings();
                sys.Show();
                this.Hide();
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            try
            {
                CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                CatBO.Status = "";
                dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    CatBO.catID = row.Cells[0].Value.ToString();
                    groupBox2.Text = "Event details of client : " + row.Cells[1].Value.ToString() + " PAX " + (Convert.ToInt32(row.Cells[3].Value.ToString()) + Convert.ToInt32(row.Cells[4].Value.ToString()) + Convert.ToInt32(row.Cells[5].Value.ToString()) + Convert.ToInt32(row.Cells[6].Value.ToString()) + Convert.ToInt32(row.Cells[7].Value.ToString()));
                    CatBO.category = "";
                    dataGridView2.DataSource = CatBL.getCateringDishWithoutPrice(CatBO);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void notifier(string notif)
        {
            lblNotif.Text = notif;
            panel3.Visible = true;
            timer1.Start();
        }


        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView1, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                CatBO.catID = row.Cells[0].Value.ToString();
                selectedcatID = row.Cells[0].Value.ToString();
                selectedstatus = row.Cells[9].Value.ToString();
            }
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void Action_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatBL = new CateringBL();
            CatBO = new CateringBO();
            frmMenu menu = new frmMenu("Add","");
            if (menu.ShowDialog()== DialogResult.OK)
            {
                time = 0;
                notifier("Event successfully added!");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                CatBO.Status = "";
                dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
                dataGridView2.DataSource = "";
                groupBox2.Text = "Event details";
            }
        }

        private void editScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatBL = new CateringBL();
            CatBO = new CateringBO();
            frmMenu menu = new frmMenu("Update", selectedcatID);
            if (selectedcatID!="")
            {
                if (selectedstatus == "ACTIVE")
                {
                    if (menu.ShowDialog() == DialogResult.OK)
                    {

                        time = 0;
                        notifier("Event successfully updated!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                        CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        CatBO.Status = "";
                        dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
                        dataGridView2.DataSource = "";
                        groupBox2.Text = "Event details";
                    }
                }
                else
                {
                    time = 0;
                    notifier("Cannot edit a DONE/CANCELLED event!");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                } 
            }
        }

        public string selectedcatID { get; set; }

        private void manageIngredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngredient ing = new frmIngredient("Normal");
            ing.Show();
            this.Hide();
        }

        private void manageDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecipes rec = new frmRecipes();
            rec.Show();
            this.Hide();
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

        private void changeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatBL = new CateringBL();
            CatBO = new CateringBO();
            try
            {
                DateTime dt = new DateTime();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dt = Convert.ToDateTime(row.Cells[8].Value.ToString());
                }
                if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) <= Convert.ToDateTime(dt.ToString("yyyy-MM-dd")))
                {
                    if (selectedstatus == "ACTIVE")
                    {
                        CatBO.Status = "CANCELLED";
                        CatBO.catID = selectedcatID;
                        CatBL.updateStatusCat(CatBO);
                        time = 0;
                        notifier("Update complete!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                        CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        CatBO.Status = "";
                        dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
                        dataGridView2.DataSource = "";
                        groupBox2.Text = "Event details";
                    }
                    else if (selectedstatus == "CANCELLED")
                    {
                        CatBO.Status = "ACTIVE";
                        CatBO.catID = selectedcatID;
                        CatBL.updateStatusCat(CatBO);
                        time = 0;
                        notifier("Update complete!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                        CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        CatBO.Status = "";
                        dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
                        dataGridView2.DataSource = "";
                        groupBox2.Text = "Event details";
                    }
                    else
                    {
                        time = 0;
                        notifier("Cannot cancel a done event!");
                        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                        this.panel3.BackColor = System.Drawing.Color.Tomato;
                    }
                }
                else
                {
                    time = 0;
                    notifier("Cannot alter past event!");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                } 
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string selectedstatus { get; set; }

        private void makeAllActiveEventDoneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CatBO = new CateringBO();
            CatBL = new CateringBL();
            try
            {
                CatBO.DateOfEvent = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                CatBL.updateAllActiveEvent(CatBO); 
                time = 0;
                notifier("Yesterday events are all done!");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                dataGridView2.DataSource = "";
                groupBox2.Text = "Event details";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void seeEventsTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getEventsSpecificDate(Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")));
        }

        private void generateEventSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void prepareDatatable()
        {
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //IngBO = new IngredientBO();
            //IngBL = new IngredientBL();
            //CatBO = new CateringBO();
            //CatBL = new CateringBL();
            //List<string> values = new List<string>();
            //DataTable eventdetail;
            //DataTable eventDishes;
            //DataTable dishesrecipe;
            //List<string> Categories = new List<string>();
            //DataTable Excel = new DataTable();
            //Excel.Columns.Add("clientName");
            //Excel.Columns.Add("date");
            //Excel.Columns.Add("venue");
            //Excel.Columns.Add("pax");
            //Excel.Columns.Add("category");
            //Excel.Columns.Add("dish");
            //Excel.Columns.Add("ingredients");
            //Excel.Columns.Add("qty");
            //Excel.Columns.Add("popoy");
            //Excel.Columns.Add("cdad");
            //Excel.Columns.Add("supp");
            //string pax = "";
            //int categoryshower = 0;
            //List<double> popoyP = new List<double>();
            //List<double> cdadP = new List<double>();
            //List<double> suppP = new List<double>();
            //double popoyFP = 0;
            //double cdadFP = 0;
            //double suppFP = 0;
            ////try
            ////{
            //CatBO.catID = selectedcatID;
            //int categorysorter = 0;
            //int counter = 0;
            //foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
            //{
            //    Categories.Add(item.ItemArray[0].ToString());
            //}
            //int rowcounter = 0;
            //categorysorter = Categories.Count() - 1;
            //while (counter < categorysorter)
            //{
            //    eventdetail = CatBL.getCatDetail(CatBO);
            //    foreach (DataRow detail in eventdetail.Rows)
            //    {
            //        pax = detail.ItemArray[3].ToString();
            //        contractfilename = detail.ItemArray[1].ToString() + pax;
            //        //Excel.Rows.Add("Name", row.ItemArray[1].ToString(), "Date", row.ItemArray[5].ToString(), "", "");
            //        //Excel.Rows.Add("NO.Of PAX", row.ItemArray[3].ToString(), "Venue", row.ItemArray[2].ToString(), "", "");
            //        CatBO.catID = selectedcatID;
            //        CatBO.category = Categories[counter];
            //        dishesrecipe = CatBL.getRecipeNameFormulaPrice(CatBO);
            //        eventDishes = CatBL.getCateringDish(CatBO);
            //        foreach (DataRow dish in eventDishes.Rows)
            //        {
            //            //if (rowcounter == 0)
            //            //{
            //            //    Excel.Rows.Add("", "", "", "", "", "");
            //            //    Excel.Rows.Add("MENU", "", "Quantity", "POPOY", "CDAD", "SUPPLIERS");
            //            //}
            //            //if (categoryshower == 0)
            //            //{
            //            //    Excel.Rows.Add(Categories[counter], "", "", "", "", "");
            //            //}
            //            //Excel.Rows.Add("", row.ItemArray[0].ToString(), "", "", "", "");
            //            foreach (DataRow ing in dishesrecipe.Rows)
            //            {
            //                values.Add(detail.ItemArray[1].ToString());
            //                values.Add(detail.ItemArray[5].ToString());
            //                values.Add(detail.ItemArray[2].ToString());
            //                values.Add(detail.ItemArray[3].ToString());
            //                values.Add(Categories[counter]);
            //                values.Add(dish.ItemArray[0].ToString());
            //                values.Add(ing.ItemArray[0].ToString());
            //                values.Add(Convert.ToString((getPrice(ing.ItemArray[1].ToString(), pax)) + " " + ing.ItemArray[5].ToString()));
            //                values.Add(Convert.ToString((Convert.ToDouble(ing.ItemArray[2].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax))));
            //                values.Add(Convert.ToString((Convert.ToDouble(ing.ItemArray[3].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax))));
            //                values.Add(Convert.ToString((Convert.ToDouble(ing.ItemArray[4].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax))));
            //                popoyP.Add(Convert.ToDouble(ing.ItemArray[2].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax));
            //                cdadP.Add(Convert.ToDouble(ing.ItemArray[3].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax));
            //                suppP.Add(Convert.ToDouble(ing.ItemArray[4].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax));
            //                //Excel.Rows.Add("", ing.ItemArray[0].ToString(),
            //                //    Convert.ToString(getPrice(ing.ItemArray[1].ToString(), pax)) + " " + ing.ItemArray[5].ToString(),
            //                //    Convert.ToString(Convert.ToDouble(ing.ItemArray[2].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax)),
            //                //     Convert.ToString(Convert.ToDouble(ing.ItemArray[3].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax)),
            //                //      Convert.ToString(Convert.ToDouble(ing.ItemArray[4].ToString()) * getPrice(ing.ItemArray[1].ToString(), pax)));
            //                Excel.Rows.Add(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10]);
            //                values.Clear();
            //            }
            //            double tempPPrice = popoyP.Sum();
            //            double tempCPrice = cdadP.Sum();
            //            double tempSPrice = suppP.Sum();
            //            popoyFP = popoyFP + tempPPrice;
            //            cdadFP = cdadFP + tempCPrice;
            //            suppFP = suppFP + tempSPrice;
            //            //Excel.Rows.Add("", "", "TOTAL", tempPPrice, tempCPrice, tempSPrice);
            //            rowcounter++;
            //            categoryshower = categoryshower + 1;
            //        }
            //        categoryshower = 0;
            //        counter = counter + 1;
            //    }
            //}

            //frmManageMenu menu = new frmManageMenu(Excel);
            //menu.Show();
            ////}
            ////catch (Exception)
            ////{
            ////    throw;
            ////}
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

        public static void WriteCsv(DataTable dt, string path)
        {
            StreamWriter wr = new StreamWriter(path);
            try
            {

              
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string contractfilename { get; set; }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        public string vip { get; set; }

        public string guest { get; set; }

        public string kids { get; set; }

        public string crew { get; set; }

        private void doneAllEventsOnGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                if (Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")) <= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    DataTable dt = CatBL.checkEventIfDone(CatBO);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.ItemArray[0].ToString() != "DONE")
                        {
                            CatBO.Status = "";
                            CatBL.updateAllActiveEvent(CatBO);
                            time = 0;
                            notifier("Events are mark as done!");
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
                            dateTimePicker1.Value = Convert.ToDateTime(CatBO.DateOfEvent);
                            CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
                            dataGridView2.DataSource = "";
                            groupBox2.Text = "Event details";
                        }
                        else
                        {
                            time = 0;
                            notifier("None of shown events are active!");
                            lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                            this.panel3.BackColor = System.Drawing.Color.Tomato;
                        }

                    }
                }
                else
                {
                    time = 0;
                    notifier("Cannot mark future event done!");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string supp1 { get; set; }

        public string supp2 { get; set; }

        public string supp3 { get; set; }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplier spp = new frmSupplier();
            spp.Show();
        }

        private void breakdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            foreach (DataRow supp in BL.getSupplier().Rows)
            {
                supp1 = supp.ItemArray[0].ToString().ToUpper();
                supp2 = supp.ItemArray[1].ToString().ToUpper();
                supp3 = supp.ItemArray[2].ToString().ToUpper();
            }
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
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
            List<string> Categories = new List<string>();
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            string pax = "";
            int categoryshower = 0;
            int categoryshowerO = 0;
            string lastCat = "";
            string lastCatOther = "";
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> popoyPO = new List<decimal>();
            List<decimal> cdadPO = new List<decimal>();
            List<decimal> suppPO = new List<decimal>();
            decimal popoyFP = 0;
            decimal cdadFP = 0;
            decimal suppFP = 0;
            string guestType = "";
            //try
            //{
                if (selectedcatID != "")
                {
                    CatBO.catID = selectedcatID;
                    int categorysorter = 0;
                    int counter = 0;
                        foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
                        {
                            Categories.Add(item.ItemArray[0].ToString());
                        } 
                    eventdetail = CatBL.getCatDetail(CatBO);
                    foreach (DataRow row in eventdetail.Rows)
                    {
                        vip = row.ItemArray[3].ToString();
                        guest = row.ItemArray[4].ToString();
                        kids = row.ItemArray[5].ToString();
                        crew = row.ItemArray[6].ToString();
                        Other = row.ItemArray[7].ToString();
                        contractfilename = row.ItemArray[1].ToString();
                        Excel.Rows.Add("Name", row.ItemArray[1].ToString(), "Date", row.ItemArray[9].ToString(), "", "");
                        Excel.Rows.Add("NO.Of PAX", row.ItemArray[3].ToString() + " VIP , " + row.ItemArray[4].ToString() + " Guest , " + row.ItemArray[5].ToString() + " Kids , " + row.ItemArray[6].ToString() + " Crew , " + row.ItemArray[7].ToString() + " Other", "Venue", row.ItemArray[2].ToString(), "", "");
                        Excel.Rows.Add("Type of Event ",row.ItemArray[11].ToString(), "Type of Service ", row.ItemArray[12].ToString(), "", "");
                        Excel.Rows.Add("", "", "", "", "", "");
                        Excel.Rows.Add("MENU", "", "Quantity", supp1, supp2, supp3);
                    }
                    int rowcounter = 0;
                    categorysorter = Categories.Count();
                    string recid = "";
                    while (counter < categorysorter)
                    {
                        CatBO.catID = selectedcatID;
                        CatBO.category = Categories[counter];
                        eventDishes = CatBL.getCateringDishStatic(CatBO);
                        foreach (DataRow row in eventDishes.Rows)
                        {
                            guestType=row.ItemArray[0].ToString();
                            RecBO.recipe = row.ItemArray[1].ToString();
                            foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                            {
                                recid = rec.ItemArray[0].ToString();
                            }
                            CatBO.recipeid = recid;
                            CatBO.guest = row.ItemArray[0].ToString();
                            dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                            if (categoryshower==0)
                            {
                                 Excel.Rows.Add(Categories[counter], "", "", "", "", "");
                            }
                            Excel.Rows.Add("Dish PAX: "+row.ItemArray[6].ToString(), row.ItemArray[0].ToString() + "-" + row.ItemArray[1].ToString(), "", "", "", "");
                           
                            
                            foreach (DataRow ing in dishesrecipe.Rows)
                            {
                                
                                rowcounter++;
                                decimal qty = decimal.Round(Convert.ToDecimal(getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())), 2, MidpointRounding.AwayFromZero);
                                
                                if (row.ItemArray[0].ToString() == "VIP")
                                {

                                    popoyP.Add(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty);
                                    cdadP.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                                    suppP.Add(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty);
                                    Excel.Rows.Add("", ing.ItemArray[0].ToString(),
                                                               Convert.ToString(getPrice(ing.ItemArray[1].ToString(), vip)) + " " + ing.ItemArray[5].ToString(),
                                                               Convert.ToString(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty),
                                                                Convert.ToString(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty),
                                                                 Convert.ToString(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty));
                                }
                                else if (row.ItemArray[0].ToString() == "Guest")
                                {
                                    popoyP.Add(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty);
                                    cdadP.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                                    suppP.Add(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty);
                                    Excel.Rows.Add("", ing.ItemArray[0].ToString(),
                                                               Convert.ToString(getPrice(ing.ItemArray[1].ToString(), guest)) + " " + ing.ItemArray[5].ToString(),
                                                               Convert.ToString(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty),
                                                                Convert.ToString(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty),
                                                                 Convert.ToString(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty));
                                }
                                else if (row.ItemArray[0].ToString() == "KIDS")
                                {
                                    popoyP.Add(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty);
                                    cdadP.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                                    suppP.Add(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty);
                                    Excel.Rows.Add("", ing.ItemArray[0].ToString(),
                                                               Convert.ToString(getPrice(ing.ItemArray[1].ToString(), kids)) + " " + ing.ItemArray[5].ToString(),
                                                               Convert.ToString(Convert.ToDecimal(ing.ItemArray[2].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())),
                                                                Convert.ToString(Convert.ToDecimal(ing.ItemArray[3].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())),
                                                                 Convert.ToString(Convert.ToDecimal(ing.ItemArray[4].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())));
                                }
                                else if (row.ItemArray[0].ToString() == "CREW")
                                {
                                    popoyP.Add(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty);
                                    cdadP.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                                    suppP.Add(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty);
                                    Excel.Rows.Add("", ing.ItemArray[0].ToString(),
                                                               Convert.ToString(getPrice(ing.ItemArray[1].ToString(), crew)) + " " + ing.ItemArray[5].ToString(),
                                                               Convert.ToString(Convert.ToDecimal(ing.ItemArray[2].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())),
                                                                Convert.ToString(Convert.ToDecimal(ing.ItemArray[3].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())),
                                                                 Convert.ToString(Convert.ToDecimal(ing.ItemArray[4].ToString()) * getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())));
                                }
                                else
                                {
                                    popoyPO.Add(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty);
                                    cdadPO.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                                    suppPO.Add(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty);
                                    Others.Rows.Add("", ing.ItemArray[0].ToString(),
                                                               Convert.ToString(getPrice(ing.ItemArray[1].ToString(), Other)) + " " + ing.ItemArray[5].ToString(),
                                                               Convert.ToString(Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty),
                                                                Convert.ToString(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty),
                                                                 Convert.ToString(Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty));
                                }
                            }
                            decimal tempPPrice;
                            decimal tempCPrice;
                            decimal tempSPrice;
                                 tempPPrice = popoyP.Sum();
                                 tempCPrice = cdadP.Sum();
                                 tempSPrice = suppP.Sum(); 
                             popoyP.Clear();
                            cdadP.Clear();
                            suppP.Clear();
                            popoyFP = popoyFP + tempPPrice;
                            cdadFP = cdadFP + tempCPrice;
                            suppFP = suppFP + tempSPrice;
                            Excel.Rows.Add("", "", "TOTAL", "P " + tempPPrice, "P " + tempCPrice, "P " + tempSPrice); 
                            catTotal1=catTotal1+tempPPrice;
                            catTotal2=catTotal2+tempCPrice;
                            catTotal3=catTotal3+tempSPrice;
                            tempPPrice = 0;
                            tempCPrice = 0;
                            tempSPrice = 0;
                            categoryshower = categoryshower + 1;
                        }
                        //if (guestType == "VIP" || guestType == "Guest" || guestType == "KIDS" || guestType == "CREW")
                        //{
                        Excel.Rows.Add("", "", "", "", "", "");
                        if (rowcounter != 0)
                        {
                            Excel.Rows.Add("", "TOTAL FOR " + Categories[counter], "", "P " + catTotal1, "P " + catTotal2, "P " + catTotal3); 
                        }
                        //}
                        //else
                        //{
                        //    Others.Rows.Add("", "", "", "", "", "");
                        //    Others.Rows.Add("", "TOTAL FOR " + Categories[counter], "", "P " + catTotal1, "P " + catTotal2, "P " + catTotal3);
                        //}
                        catTotal1 = 0;
                        catTotal2 = 0;
                        catTotal3 = 0;
                        categoryshower = 0;
                        counter = counter + 1;
                    }
                    DataTable other = showDynamic();
                    foreach (DataRow import in other.Rows)
                    {
                        Excel.Rows.Add(import.ItemArray[0].ToString(), import.ItemArray[1].ToString(), import.ItemArray[2].ToString(), import.ItemArray[3].ToString(), import.ItemArray[4].ToString(), import.ItemArray[5].ToString());
                    }
                    popoyFP = popoyFP + totalPriceP;
                    cdadFP = cdadFP + totalPriceC;
                    suppFP = suppFP + totalPriceS;
                    Excel.Rows.Add("", "", "", "", "", "");
                    Excel.Rows.Add("", "SUBTOTAL", "", "P " + popoyFP, "P " + cdadFP, "P " + suppFP);
                    Excel.Rows.Add("", "Grand Total of event", "", "", "", "P " + (popoyFP + cdadFP + suppFP));
                    Excel.Rows.Add("", "", "", "", "", "");
                    diagReport menu = new diagReport(Excel, contractfilename);
                    menu.Show();
                    popoyFP = 0;
                    cdadFP = 0;
                    suppFP = 0;
                    totalPriceP = 0;
                    totalPriceC = 0;
                    totalPriceS = 0;
                }
                else
                {
                    time = 0;
                    notifier("Select a event");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void wOBreakdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SupplierBL BL = new SupplierBL();
            //SupplierBO BO = new SupplierBO();
            //foreach (DataRow supp in BL.getSupplier().Rows)
            //{
            //    supp1 = supp.ItemArray[0].ToString().ToUpper();
            //    supp2 = supp.ItemArray[1].ToString().ToUpper();
            //    supp3 = supp.ItemArray[2].ToString().ToUpper();
            //}
            //RecBO = new RecipeBO();
            //RecBL = new RecipeBL();
            //IngBO = new IngredientBO();
            //IngBL = new IngredientBL();
            //CatBO = new CateringBO();
            //CatBL = new CateringBL();
            //DataTable eventdetail;
            //DataTable eventDishes;
            //DataTable dishesrecipe;
            //List<string> Categories = new List<string>();
            //DataTable Excel = new DataTable();
            //Excel.Columns.Add("1");
            //Excel.Columns.Add("2");
            //Excel.Columns.Add("3");
            //Excel.Columns.Add("4");
            //Excel.Columns.Add("5");
            //Excel.Columns.Add("6");
            //string pax = "";
            //int categoryshower = 0;
            //List<decimal> popoyP = new List<decimal>();
            //List<decimal> cdadP = new List<decimal>();
            //List<decimal> suppP = new List<decimal>();
            //decimal popoyFP = 0;
            //decimal cdadFP = 0;
            //decimal suppFP = 0;
            //try
            //{
            //    if (selectedcatID != "")
            //    {
            //        CatBO.catID = selectedcatID;
            //        int categorysorter = 0;
            //        int counter = 0;
            //        foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
            //        {
            //            Categories.Add(item.ItemArray[0].ToString());
            //        }
            //        eventdetail = CatBL.getCatDetail(CatBO);
            //        foreach (DataRow row in eventdetail.Rows)
            //        {
            //            vip = row.ItemArray[3].ToString();
            //            guest = row.ItemArray[4].ToString();
            //            kids = row.ItemArray[5].ToString();
            //            crew = row.ItemArray[6].ToString();
            //            Other= row.ItemArray[7].ToString();
            //            contractfilename = row.ItemArray[1].ToString();
            //            Excel.Rows.Add("Name", row.ItemArray[1].ToString(), "Date", row.ItemArray[9].ToString(), "", "");
            //            Excel.Rows.Add("NO.Of PAX", row.ItemArray[3].ToString() + " VIP , " + row.ItemArray[4].ToString() + " Guest , " + row.ItemArray[5].ToString() + " Kids , " + row.ItemArray[6].ToString() + " Crew , " + row.ItemArray[7].ToString() + " Other", "Venue", row.ItemArray[2].ToString(), "", "");
            //            Excel.Rows.Add("Type of Event", row.ItemArray[11].ToString(), "Type of Service", row.ItemArray[12].ToString(), "", "");
            //            Excel.Rows.Add("", "", "", "", "", "");
            //            Excel.Rows.Add("MENU", "", "", supp1 + " Budget", supp2 + " Budget", supp3 + " Budget");
            //        }
            //        int rowcounter = 0;
            //        categorysorter = Categories.Count();
            //        string recid = "";
            //        while (counter < categorysorter)
            //        {
            //            CatBO.catID = selectedcatID;
            //            CatBO.category = Categories[counter];
            //            eventDishes = CatBL.getCateringDishStatic(CatBO);
            //            foreach (DataRow row in eventDishes.Rows)
            //            {
            //                RecBO.recipe = row.ItemArray[1].ToString();
            //                foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
            //                {
            //                    recid = rec.ItemArray[0].ToString();
            //                }
            //                CatBO.recipeid = recid;
            //                CatBO.guest = row.ItemArray[0].ToString();
            //                dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                          
            //                if (categoryshower == 0)
            //                {
            //                    Excel.Rows.Add(Categories[counter], "", "", "", "", "");
            //                }
            //                foreach (DataRow ing in dishesrecipe.Rows)
            //                {
            //                    decimal qty = decimal.Round(Convert.ToDecimal(getPrice(ing.ItemArray[1].ToString(), row.ItemArray[6].ToString())), 2, MidpointRounding.AwayFromZero);
            //                    if (row.ItemArray[0].ToString() == "VIP")
            //                    {
            //                        popoyP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        cdadP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        suppP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
                                   
            //                    }
            //                    else if (row.ItemArray[0].ToString() == "Guest")
            //                    {

            //                        popoyP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        cdadP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        suppP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                    }
            //                    else if (row.ItemArray[0].ToString() == "KIDS")
            //                    {
            //                        popoyP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        cdadP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        suppP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
                                   
            //                    }
            //                    else if (row.ItemArray[0].ToString() == "CREW")
            //                    {
            //                        popoyP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        cdadP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        suppP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                    }
            //                    else if (row.ItemArray[0].ToString() == "OTHERS")
            //                    {
            //                        popoyP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[2].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        cdadP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                        suppP.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[4].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
            //                    }
            //                }
            //                decimal tempPPrice = popoyP.Sum();
            //                decimal tempCPrice = cdadP.Sum();
            //                decimal tempSPrice = suppP.Sum();
            //                popoyP.Clear();
            //                cdadP.Clear();
            //                suppP.Clear();
            //                popoyFP = popoyFP + tempPPrice;
            //                cdadFP = cdadFP + tempCPrice;
            //                suppFP = suppFP + tempSPrice; 
            //                catTotal1 = catTotal1 + tempPPrice;
            //                catTotal2 = catTotal2 + tempCPrice;
            //                catTotal3 = catTotal3 + tempSPrice;
            //                Excel.Rows.Add("Dish PAX: " + row.ItemArray[6].ToString(), row.ItemArray[0].ToString() + "-" + row.ItemArray[1].ToString(), "", "P " + String.Format("{0:n}", decimal.Round(tempPPrice, 2, MidpointRounding.AwayFromZero)), "P " + String.Format("{0:n}", decimal.Round(tempCPrice, 2, MidpointRounding.AwayFromZero)), "P " + String.Format("{0:n}", decimal.Round(tempSPrice, 2, MidpointRounding.AwayFromZero)));
            //                decimal sample = (decimal.Round((tempPPrice), 2, MidpointRounding.AwayFromZero) + decimal.Round((tempCPrice), 2, MidpointRounding.AwayFromZero) + decimal.Round((tempSPrice), 2, MidpointRounding.AwayFromZero));
            //                Excel.Rows.Add("", "", "TOTAL COST", "", "", "P " + String.Format("{0:n}", sample));
            //                tempPPrice = 0;
            //                tempCPrice = 0;
            //                tempSPrice = 0;
            //                rowcounter++;
            //                categoryshower = categoryshower + 1;
            //            }
            //            Excel.Rows.Add("", "", "", "", "", "");
            //            if (rowcounter != 0)
            //            {
                            
            //            }
            //            catTotal1 = 0;
            //            catTotal2 = 0;
            //            catTotal3 = 0;
            //            categoryshower = 0;
            //            counter = counter + 1;
            //        }
            //        DataTable other = showDynamicNoBreak();
            //        foreach (DataRow import in other.Rows)
            //        {
            //            Excel.Rows.Add(import.ItemArray[0].ToString(), import.ItemArray[1].ToString(), import.ItemArray[2].ToString(), import.ItemArray[3].ToString(), import.ItemArray[4].ToString(), import.ItemArray[5].ToString());
            //        }
            //        popoyFP = popoyFP + totalPriceP;
            //        cdadFP = cdadFP + totalPriceC;
            //        suppFP = suppFP + totalPriceS;
            //        Excel.Rows.Add("", "", "", "", "", "");
            //        Excel.Rows.Add("", "SUBTOTAL", "", "P " + String.Format("{0:n}", decimal.Round(popoyFP, 2, MidpointRounding.AwayFromZero)), "P " + String.Format("{0:n}", decimal.Round(cdadFP, 2, MidpointRounding.AwayFromZero)), "P " + String.Format("{0:n}", decimal.Round(suppFP, 2, MidpointRounding.AwayFromZero)));
            //        decimal gtotal = (decimal.Round((popoyFP), 2, MidpointRounding.AwayFromZero) + decimal.Round((cdadFP), 2, MidpointRounding.AwayFromZero) + decimal.Round((suppFP), 2, MidpointRounding.AwayFromZero));
            //        Excel.Rows.Add("", "Grand Total of event", "", "", "", "P " + String.Format("{0:n}", (gtotal)));
            //        diagReport menu = new diagReport(Excel, contractfilename);
            //        menu.Show();
            //        popoyFP = 0;
            //        cdadFP = 0;
            //        suppFP = 0;
            //        totalPriceP = 0;
            //        totalPriceC = 0;
            //        totalPriceS = 0;
            //    }
            //    else
            //    {
            //        time = 0;
            //        notifier("Select a event");
            //        lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
            //        this.panel3.BackColor = System.Drawing.Color.Tomato;
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
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
            List<string> Categories = new List<string>();
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            string pax = "";
            int categoryshower = 0;
            int categoryshowerO = 0;
            string lastCat = "";
            string lastCatOther = "";
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> popoyPO = new List<decimal>();
            List<decimal> cdadPO = new List<decimal>();
            List<decimal> suppPO = new List<decimal>();
            List<decimal> totalPrice = new List<decimal>();
            decimal  totalStockPrice=0;
            decimal totalFP = 0;
            string typeofevent = "";
            string guestType = "";

            if (selectedcatID != "")
            {
                CatBO.catID = selectedcatID;
                int categorysorter = 0;
                int counter = 0;
                foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
                {
                    Categories.Add(item.ItemArray[0].ToString());
                }
                eventdetail = CatBL.getCatDetail(CatBO);
                foreach (DataRow row in eventdetail.Rows)
                {
                    typeofevent = row.ItemArray[12].ToString();
                    vip = row.ItemArray[3].ToString();
                    guest = row.ItemArray[4].ToString();
                    kids = row.ItemArray[5].ToString();
                    crew = row.ItemArray[6].ToString();
                    Other = row.ItemArray[7].ToString();
                    contractfilename = row.ItemArray[1].ToString();
                    Excel.Rows.Add("Name", row.ItemArray[1].ToString(), "Date", row.ItemArray[9].ToString(), "", "");
                    Excel.Rows.Add("NO.Of PAX", row.ItemArray[3].ToString() + " VIP , " + row.ItemArray[4].ToString() + " Guest , " + row.ItemArray[5].ToString() + " Kids , " + row.ItemArray[6].ToString() + " Crew , " + row.ItemArray[7].ToString() + " Other", "Venue", row.ItemArray[2].ToString(), "", "");
                    Excel.Rows.Add("Type of Event ", row.ItemArray[11].ToString(), "Type of Service ", row.ItemArray[12].ToString(), "", "");
                    Excel.Rows.Add("", "", "", "", "", "");
                    Excel.Rows.Add("MENU", "", "PAX"," Budget");
                }
                int rowcounter = 0;
                categorysorter = Categories.Count();
                string recid = "";
                while (counter < categorysorter)
                {
                    CatBO.catID = selectedcatID;
                    CatBO.category = Categories[counter];
                    eventDishes = CatBL.getCateringDishStatic(CatBO);
                    foreach (DataRow row in eventDishes.Rows)
                    {
                        guestType = row.ItemArray[0].ToString();
                        RecBO.recipe = row.ItemArray[1].ToString();
                        foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                        {
                            recid = rec.ItemArray[0].ToString();
                        }
                        CatBO.recipeid = recid;
                        CatBO.guest = row.ItemArray[0].ToString();
                        dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                        if (categoryshower == 0)
                        {
                            Excel.Rows.Add(Categories[counter], "", "", "", "", "");
                        }

                        int ingCount = 0;
                        foreach (DataRow ing in dishesrecipe.Rows)
                        {
                           
                            if (row.ItemArray[0].ToString() == "VIP")
                            {
                                decimal qty = getPrice(ing.ItemArray[1].ToString(),vip);
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);

                            }
                            else if (row.ItemArray[0].ToString() == "Guest")
                            {
                                decimal qty = getPrice(ing.ItemArray[1].ToString(), guest);
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                            }
                            else if (row.ItemArray[0].ToString() == "KIDS")
                            {
                                decimal qty = getPrice(ing.ItemArray[1].ToString(), kids);
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                            }
                            else if (row.ItemArray[0].ToString() == "CREW")
                            {
                                decimal qty = getPrice(ing.ItemArray[1].ToString(),crew);
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                            }
                            else
                            {
                                decimal qty =getPrice(ing.ItemArray[1].ToString(), Other);
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty);
                            }
                            ingCount++;
                            rowcounter++;
                        }
                        
                        decimal tempPPrice = totalPrice.Sum();
                        totalStockPrice = totalStockPrice+Convert.ToDecimal(row.ItemArray[2].ToString());
                        totalFP = totalFP+ tempPPrice;
                        catTotal1 = catTotal1 + tempPPrice;
                        Excel.Rows.Add("", row.ItemArray[0].ToString() + "-" + row.ItemArray[1].ToString(), row.ItemArray[4].ToString(), "P "+row.ItemArray[2].ToString());
                        totalPrice.Clear();
                        rowcounter++;
                        categoryshower = categoryshower + 1;
                    }
                    Excel.Rows.Add("", "", "", "", "", "");
                    if (rowcounter != 0)
                    {

                    }
                    catTotal1 = 0;
                    catTotal2 = 0;
                    catTotal3 = 0;
                    categoryshower = 0;
                    counter = counter + 1;
                } 
                Excel.Rows.Add("", "", "", "", "", "");
                DataTable other = showDynamicNoBreak();
                foreach (DataRow import in other.Rows)
                {
                    Excel.Rows.Add(import.ItemArray[0].ToString(), import.ItemArray[1].ToString(), import.ItemArray[2].ToString(), import.ItemArray[3].ToString(), import.ItemArray[4].ToString(), import.ItemArray[5].ToString());
                }
                totalStockPrice = totalStockPrice + totalPriceP;
                Excel.Rows.Add("", "", "", "", "", "");
                decimal gtotal = (decimal.Round((totalStockPrice), 2, MidpointRounding.AwayFromZero));
                Excel.Rows.Add("", "Grand Total of event", "", "P " + String.Format("{0:n}", (gtotal)));
                Excel.Rows.Add("", "", "", "", "", "");
                diagReport menu = new diagReport(Excel, "Summary");
                menu.Show();
                totalStockPrice = 0;
                gtotal = 0;
                totalPriceP = 0;
            }
            else
            {
                time = 0;
                notifier("Select a event");
                lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                this.panel3.BackColor = System.Drawing.Color.Tomato;
            }
        }

        public DataTable showDynamic()
        {
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            DataTable eventDishes;
            DataTable dishesrecipe;
            string recid = "";
            DataTable otherMerge = new DataTable();
            otherMerge.Columns.Add("1");
            otherMerge.Columns.Add("2");
            otherMerge.Columns.Add("3");
            otherMerge.Columns.Add("4");
            otherMerge.Columns.Add("5");
            otherMerge.Columns.Add("6");
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> ototalPrice = new List<decimal>();
            List<string> Category = new List<string>();
            int categorysorter = 0;
            int counter = 0;
            CatBO.catID = selectedcatID;
            DataTable dt= CatBL.getCategoryOfDynamic(CatBO);
            foreach (DataRow item in dt.Rows)
            {
                Category.Add(item.ItemArray[0].ToString());
            }
            int category = Category.Count();
            int catSort = category;
            int categoryShower = 0;
            while (counter < catSort)
            {
                CatBO.guestTarget = Category[counter];
                CatBO.catID = selectedcatID;
                CatBO.category = "";
                eventDishes = CatBL.getCateringDishDynamic(CatBO);
                foreach (DataRow dish in eventDishes.Rows)
                {
                    RecBO.recipe = dish.ItemArray[1].ToString();
                    foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                    {
                        recid = rec.ItemArray[0].ToString();
                    }
                    CatBO.recipeid = recid;
                    CatBO.guest = dish.ItemArray[0].ToString();
                    dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                    if (categoryShower == 0)
                    {
                        otherMerge.Rows.Add(Category[counter], "", "", "", "", "");
                    }
                    otherMerge.Rows.Add("Dish PAX: " + "("+dish.ItemArray[4].ToString()+") ", dish.ItemArray[1].ToString(), "", "", "", "");
                    int numberofIngredients = 0;
                    foreach (DataRow ing in dishesrecipe.Rows)
                    {
                        decimal qty =Convert.ToDecimal(getPrice(ing.ItemArray[1].ToString(), dish.ItemArray[4].ToString()));
                        ototalPrice.Add((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty));
                        otherMerge.Rows.Add("", ing.ItemArray[0].ToString(),
                                                   (getPrice(ing.ItemArray[1].ToString(), Other)).ToString("") + " " + ing.ItemArray[4].ToString(),
                                                    String.Format("{0:n}", ototalPrice[numberofIngredients]));
                        numberofIngredients++;
                    }
                    decimal tempPrice;
                    tempPrice = ototalPrice.Sum();
                    ototalPrice.Clear();
                    //otherMerge.Rows.Add("", "", "TOTAL", "P " + String.Format("{0:n}", tempPPrice), "P " + String.Format("{0:n}", tempCPrice), "P " + String.Format("{0:n}", tempSPrice));
                    otherMerge.Rows.Add("", "", "TOTAL COST", "P " +  String.Format("{0:n}", tempPrice));
                    catTotal1 = catTotal1 + tempPrice;
                    totalPriceP = tempPrice + totalPriceP;
                    tempPrice = 0;
                    categoryShower = categoryShower + 1;
                }

                otherMerge.Rows.Add("", "", "", "", "", "");
                //}
                //else
                //{
                //    Others.Rows.Add("", "", "", "", "", "");
                //    Others.Rows.Add("", "TOTAL FOR " + Categories[counter], "", "P " + catTotal1, "P " + catTotal2, "P " + catTotal3);
                //}
                catTotal1 = 0;
                catTotal2 = 0;
                catTotal3 = 0;
                categoryShower = 0;
                counter = counter + 1;
            }
            return otherMerge;
        }
        public DataTable showDynamicNoBreak()
        {
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            DataTable eventDishes;
            DataTable dishesrecipe;
            string recid = "";
            DataTable otherMerge = new DataTable();
            otherMerge.Columns.Add("1");
            otherMerge.Columns.Add("2");
            otherMerge.Columns.Add("3");
            otherMerge.Columns.Add("4");
            otherMerge.Columns.Add("5");
            otherMerge.Columns.Add("6");
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> oTotalPrice = new List<decimal>();
            List<string> Category = new List<string>();
            
            int categorysorter = 0;
            int counter = 0;
            CatBO.catID = selectedcatID;
            DataTable dt = CatBL.getCategoryOfDynamic(CatBO);
            foreach (DataRow item in dt.Rows)
            {
                Category.Add(item.ItemArray[0].ToString());
            }
            int category = Category.Count();
            int catSort = category;
            int categoryShower = 0;
            while (counter < catSort)
            {
                CatBO.guestTarget = Category[counter];
                CatBO.catID = selectedcatID;
                CatBO.category = "";
                eventDishes = CatBL.getCateringDishDynamic(CatBO);
                foreach (DataRow dish in eventDishes.Rows)
                {
                    RecBO.recipe = dish.ItemArray[1].ToString();
                    foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                    {
                        recid = rec.ItemArray[0].ToString();
                    }
                    CatBO.recipeid = recid;
                    CatBO.guest = dish.ItemArray[0].ToString();
                    dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                    if (categoryShower == 0)
                    {
                        otherMerge.Rows.Add(Category[counter], "", "", "", "", "");
                    }
                    foreach (DataRow ing in dishesrecipe.Rows)
                    {
                        decimal qty = Convert.ToDecimal(getPrice(ing.ItemArray[1].ToString(), dish.ItemArray[4].ToString()));
                        oTotalPrice.Add((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty));
                    }
                    decimal tempPPrice;
                    tempPPrice = oTotalPrice.Sum();
                    oTotalPrice.Clear();
                    decimal totalCost = 0;
                    totalCost = totalCost + tempPPrice;
                    otherMerge.Rows.Add("", dish.ItemArray[0].ToString() + "-" + dish.ItemArray[1].ToString(), dish.ItemArray[4].ToString(), "P " + dish.ItemArray[2].ToString());
                    catTotal1 = catTotal1 + tempPPrice;
                    totalPriceP = Convert.ToDecimal(dish.ItemArray[2].ToString())+totalPriceP;
                    tempPPrice = 0;
                    categoryShower = categoryShower + 1;
                }
                otherMerge.Rows.Add("", "", "", "", "", "");
                //}
                //else
                //{
                //    Others.Rows.Add("", "", "", "", "", "");
                //    Others.Rows.Add("", "TOTAL FOR " + Categories[counter], "", "P " + catTotal1, "P " + catTotal2, "P " + catTotal3);
                //}
                catTotal1 = 0;
                catTotal2 = 0;
                catTotal3 = 0;
                categoryShower = 0;
                counter = counter + 1;
            }
            return otherMerge;
        }

        public decimal catTotal1 { get; set; }

        public decimal catTotal2 { get; set; }

        public decimal catTotal3 { get; set; }

        public string Other { get; set; }

        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
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
            List<string> Categories = new List<string>();
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            string pax = "";
            int categoryshower = 0;
            int categoryshowerO = 0;
            string lastCat = "";
            string lastCatOther = "";
            List<decimal> popoyP = new List<decimal>();
            List<decimal> cdadP = new List<decimal>();
            List<decimal> suppP = new List<decimal>();
            List<decimal> popoyPO = new List<decimal>();
            List<decimal> cdadPO = new List<decimal>();
            List<decimal> suppPO = new List<decimal>();
            List<decimal> totalPrice = new List<decimal>();
            decimal totalFP = 0;
            string typeofevent = "";
            string guestType = "";
           
                if (selectedcatID != "")
                {
                    CatBO.catID = selectedcatID;
                    int categorysorter = 0;
                    int counter = 0;
                    foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
                    {
                        Categories.Add(item.ItemArray[0].ToString());
                    }
                    eventdetail = CatBL.getCatDetail(CatBO);
                    foreach (DataRow row in eventdetail.Rows)
                    {
                        typeofevent = row.ItemArray[12].ToString();
                        vip = row.ItemArray[3].ToString();
                        guest = row.ItemArray[4].ToString();
                        kids = row.ItemArray[5].ToString();
                        crew = row.ItemArray[6].ToString();
                        Other = row.ItemArray[7].ToString();
                        contractfilename = row.ItemArray[1].ToString();
                        Excel.Rows.Add("Name", row.ItemArray[1].ToString(), "Date", row.ItemArray[9].ToString(), "", "");
                        Excel.Rows.Add("NO.Of PAX", row.ItemArray[3].ToString() + " VIP , " + row.ItemArray[4].ToString() + " Guest , " + row.ItemArray[5].ToString() + " Kids , " + row.ItemArray[6].ToString() + " Crew , " + row.ItemArray[7].ToString() + " Other", "Venue", row.ItemArray[2].ToString(), "", "");
                        Excel.Rows.Add("Type of Event ", row.ItemArray[11].ToString(), "Type of Service ", row.ItemArray[12].ToString(), "", "");
                        Excel.Rows.Add("", "", "", "", "", "");
                        Excel.Rows.Add("MENU", "", "Quantity", supp1 + " Budget");
                    }
                    int rowcounter = 0;
                    categorysorter = Categories.Count();
                    string recid = "";
                    while (counter < categorysorter)
                    {
                        CatBO.catID = selectedcatID;
                        CatBO.category = Categories[counter];
                        eventDishes = CatBL.getCateringDishStatic(CatBO);
                        foreach (DataRow row in eventDishes.Rows)
                        {
                            guestType = row.ItemArray[0].ToString();
                            RecBO.recipe = row.ItemArray[1].ToString();
                            foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                            {
                                recid = rec.ItemArray[0].ToString();
                            }
                            CatBO.recipeid = recid;
                            CatBO.guest = row.ItemArray[0].ToString();
                            dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);
                            if (categoryshower == 0)
                            {
                                Excel.Rows.Add(Categories[counter], "", "", "", "", "");
                            }
                            Excel.Rows.Add("Dish PAX: " + row.ItemArray[4].ToString(), "(" +row.ItemArray[0].ToString() + ") " + row.ItemArray[1].ToString(), "", "", "", "");

                            int ingCount = 0;
                            foreach (DataRow ing in dishesrecipe.Rows)
                            {
                                decimal qty = getPrice(ing.ItemArray[1].ToString(), row.ItemArray[4].ToString());
                                if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                {
                                    qty = qty * Properties.Settings.Default.Plated;
                                }
                                totalPrice.Add(decimal.Round((Convert.ToDecimal(ing.ItemArray[3].ToString()) * qty), 2, MidpointRounding.AwayFromZero));
                                    if (row.ItemArray[0].ToString() == "VIP")
                                    {
                                        decimal vipqty = getPrice(ing.ItemArray[1].ToString(), vip);
                                        if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                        {
                                            vipqty = vipqty * Properties.Settings.Default.Plated;
                                        }
                                        Excel.Rows.Add("", ing.ItemArray[0].ToString(),(vipqty).ToString() + " " + ing.ItemArray[4].ToString(),
                                                                 String.Format("{0:n}", totalPrice[ingCount]));
                                                                
                                    }
                                    else if (row.ItemArray[0].ToString() == "Guest")
                                    {
                                        decimal Guestqty =getPrice(ing.ItemArray[1].ToString(),guest);
                                        if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                        {
                                            Guestqty = Guestqty * Properties.Settings.Default.Plated;
                                        }
                                        Excel.Rows.Add("", ing.ItemArray[0].ToString(), (Guestqty).ToString() + " " + ing.ItemArray[4].ToString(),
                                                                 String.Format("{0:n}", totalPrice[ingCount]));
                                    }
                                    else if (row.ItemArray[0].ToString() == "KIDS")
                                    {
                                        decimal kidsQty = getPrice(ing.ItemArray[1].ToString(), kids);
                                        if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                        {
                                            kidsQty = kidsQty * Properties.Settings.Default.Plated;
                                        }
                                        Excel.Rows.Add("", ing.ItemArray[0].ToString(), (kidsQty).ToString() + " " + ing.ItemArray[4].ToString(),
                                                                 String.Format("{0:n}", totalPrice[ingCount]));
                                    }
                                    else if (row.ItemArray[0].ToString() == "CREW")
                                    {
                                        decimal CrewQty = getPrice(ing.ItemArray[1].ToString(), crew);
                                        if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                        {
                                            CrewQty = CrewQty * Properties.Settings.Default.Plated;
                                        }
                                        Excel.Rows.Add("", ing.ItemArray[0].ToString(), (CrewQty).ToString()+ " " + ing.ItemArray[4].ToString(),
                                                                 String.Format("{0:n}", totalPrice[ingCount]));
                                    }
                                    else
                                    {
                                        decimal otherQty = getPrice(ing.ItemArray[1].ToString(), Other);
                                        if (Categories[counter] == "Main dish" && typeofevent == "Plated")
                                        {
                                            otherQty = otherQty * Properties.Settings.Default.Plated;
                                        }
                                        Excel.Rows.Add("", ing.ItemArray[0].ToString(), (otherQty).ToString() + " " + ing.ItemArray[4].ToString(),
                                                                 String.Format("{0:n}", totalPrice[ingCount]));
                                    }
                                ingCount++;
                                rowcounter++;
                            }
                            decimal tempPrice;
                            tempPrice = totalPrice.Sum();
                            totalPrice.Clear();
                            totalFP = totalFP + tempPrice;
                            Excel.Rows.Add("", "", "TOTAL", "P " + String.Format("{0:n}", decimal.Round(tempPrice, 2, MidpointRounding.AwayFromZero)));
                            //decimal sample = (decimal.Round((tempPPrice), 2, MidpointRounding.AwayFromZero) + decimal.Round((tempCPrice), 2, MidpointRounding.AwayFromZero) + decimal.Round((tempSPrice), 2, MidpointRounding.AwayFromZero));
                            //Excel.Rows.Add("", "", "TOTAL COST", "", "", "P " + String.Format("{0:n}", sample));
                            catTotal1 = catTotal1 + tempPrice;
                            tempPrice = 0;
                            categoryshower = categoryshower + 1;
                        }
                        //if (guestType == "VIP" || guestType == "Guest" || guestType == "KIDS" || guestType == "CREW")
                        //{
                        Excel.Rows.Add("", "", "", "", "", "");
                        if (rowcounter != 0)
                        {
                            
                        }
                        //}
                        //else
                        //{
                        //    Others.Rows.Add("", "", "", "", "", "");
                        //    Others.Rows.Add("", "TOTAL FOR " + Categories[counter], "", "P " + catTotal1, "P " + catTotal2, "P " + catTotal3);
                        //}
                        catTotal1 = 0;
                        catTotal2 = 0;
                        catTotal3 = 0;
                        categoryshower = 0;
                        counter = counter + 1;
                    }
                    DataTable other = showDynamic();
                    foreach (DataRow import in other.Rows)
                    {
                        Excel.Rows.Add(import.ItemArray[0].ToString(), import.ItemArray[1].ToString(), import.ItemArray[2].ToString(), import.ItemArray[3].ToString(), import.ItemArray[4].ToString(), import.ItemArray[5].ToString());
                    }
                    totalFP = totalFP+ totalPriceP;
                    Excel.Rows.Add("", "", "", "", "", "");
                    decimal gtotal = (decimal.Round((totalFP), 2, MidpointRounding.AwayFromZero));
                    Excel.Rows.Add("", "Grand Total of event","","P " + String.Format("{0:n}", (gtotal)));
                    Excel.Rows.Add("", "", "", "", "", "");
                    diagReport menu = new diagReport(Excel,"Summary");
                    menu.Show();
                    totalFP = 0;
                    gtotal = 0;
                    totalPriceP = 0;
                }
                else
                {
                    time = 0;
                    notifier("Select a event");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
       
        }

        private void selectedEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
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
            foreach(DataRow supp in BL.getSupplier().Rows)
            {
                suppliers.Rows.Add(supp.ItemArray[0].ToString());
            }
                if (selectedcatID != "")
                {
                    CatBO.catID = selectedcatID;
                    int categorysorter = 0;
                    int counter = 0;
                    foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
                    {
                        Categories.Add(item.ItemArray[0].ToString());
                    }
                    eventdetail = CatBL.getCatDetail(CatBO);
                    foreach (DataRow row in eventdetail.Rows)
                    {
                        typeofservice = row.ItemArray[12].ToString();
                        vip = row.ItemArray[3].ToString();
                        guest = row.ItemArray[4].ToString();
                        kids = row.ItemArray[5].ToString();
                        crew = row.ItemArray[6].ToString();
                        Other = row.ItemArray[7].ToString();
                        contractfilename = row.ItemArray[1].ToString();
                        Excel.Rows.Add("P.O Of Ingredients", "", "", "", "");
                        Excel.Rows.Add("", "", "", "", "");
                        Excel.Rows.Add(row.ItemArray[1].ToString() + "'s Event","", "", "", "");
                        Excel.Rows.Add("Date: " + row.ItemArray[9].ToString(), "", "", "", "", "");
                        Excel.Rows.Add("Place of Event: " + row.ItemArray[2].ToString(), "", "", "");
                        Excel.Rows.Add("", "", "", "", "");
                        Excel.Rows.Add(guest + " Guest, " + vip + " Vip, " +kids+" Kids", "", "", "", "", "");
                        Excel.Rows.Add(crew + " Crew, " + Other + " Other", "", "", "", "", "");
                        Excel.Rows.Add("", "", "", "", "");
                        Excel.Rows.Add("Ingredient","Quantity", " Budget");
                    }
                    int rowcounter = 0;
                    categorysorter = Categories.Count();
                    string recid = "";
                    while (counter < categorysorter)
                    {
                        CatBO.catID = selectedcatID;
                        CatBO.category = Categories[counter];
                        eventDishes = CatBL.getCateringDish(CatBO);
                        foreach (DataRow row in eventDishes.Rows)
                        {
                            category = row.ItemArray[2].ToString();
                            guestType = row.ItemArray[0].ToString();
                            RecBO.recipe = row.ItemArray[1].ToString();
                            foreach (DataRow rec in RecBL.searchRecipeByName(RecBO).Rows)
                            {
                                recid = rec.ItemArray[0].ToString();
                            }
                            CatBO.recipeid = recid;
                            CatBO.guest = row.ItemArray[0].ToString();
                            dishesrecipe = CatBL.getRecipeNameAndFormulaAndPrice(CatBO);                         
                            foreach (DataRow ing in dishesrecipe.Rows)
                            {
                                string paxx = row.ItemArray[3].ToString();
                                rowcounter++;
                                 string ins=ing[0].ToString();
                                 decimal b =getPrice(ing.ItemArray[1].ToString(), paxx);
                                 if (typeofservice=="Plated" && category == "Main dish")
                                 {
                                     b = b * Properties.Settings.Default.Plated;
                                 }
                                 //decimal b = getPrice(ing.ItemArray[1].ToString(), paxx);
                                if (ingredients.Rows.Contains(ins))
                                {

                                    for (int i = 0; i < ingredients.Rows.Count; i++)
                                    {
                                        string temp = ingredients.Rows[i][0].ToString();
                                        if (ins == temp)
                                        {
                                            ingredients.Rows[i][2] = (Convert.ToDecimal(ingredients.Rows[i][2].ToString()) + Convert.ToDecimal(b));
                                            i = ingredients.Rows.Count;
                                        }
                                    }
                                }
                                else
                                {
                                    ingredients.Rows.Add(ing[0].ToString(), ing[2].ToString(),b);
                                 }
                                }
                            }
                        categoryshower = categoryshower + 1;
                        counter = counter + 1;
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
                    notifier("Select a event");
                    lblNotif.Left = (this.ClientSize.Width - lblNotif.Size.Width) / 2;
                    this.panel3.BackColor = System.Drawing.Color.Tomato;
                }
            }
          
        

        private void eventSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wOBreakdownToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eventReportyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void purchaseOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void byPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngredientReport IR = new frmIngredientReport();
            IR.Show();
        }

        private void chooseEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmSelectEventReport ser = new frmSelectEventReport("PO");
            ser.Show();
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSysSettings sys = new frmSysSettings();
            sys.Show();
            this.Hide();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void byPeriodToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.Show();
        }

        private void chooseEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSelectEventReport ser = new frmSelectEventReport("Summary");
            ser.Show();
        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChef chef = new frmChef();
            chef.Show();
            
        }

    }
}
