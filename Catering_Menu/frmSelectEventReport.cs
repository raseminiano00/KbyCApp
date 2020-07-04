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
    public partial class frmSelectEventReport : Form
    {
        public frmSelectEventReport(string report)
        {
            InitializeComponent();
            reportType = report;
        }
        DataTable passedDt = new DataTable();
        string reportType = "";
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedcatID != null)
            {
                if (passedDt.Rows.Contains(selectedcatID) == false)
                {
                    passedDt.Rows.Add(selectedcatID, selectedEvent, selectedDate, selectedstatus);
                    dataGridView2.DataSource = passedDt;
                }
                else
                {
                    MessageBox.Show("Event already added!");
                }
            }
            else
            {
                MessageBox.Show("Select a event!");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CateringBL CatBL = new CateringBL();
            CateringBO CatBO = new CateringBO();
            CatBO.DateOfEvent = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            CatBO.Status = "";
            dataGridView1.DataSource = CatBL.searchCatOrder(CatBO);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Right)
            {
                Action.Show(dataGridView1, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                selectedcatID = row.Cells[0].Value.ToString();
                selectedstatus = row.Cells[9].Value.ToString();
                selectedEvent = row.Cells[1].Value.ToString();
                selectedDate = row.Cells[8].Value.ToString();
            }
        }

        public string selectedcatID { get; set; }

        public string selectedstatus { get; set; }

        public string selectedDate { get; set; }

        public string selectedEvent { get; set; }
        string catid = "";
        private void frmSelectEventReport_Load(object sender, EventArgs e)
        {
            passedDt = new DataTable();
            passedDt.Columns.Add("Eventid");
            passedDt.PrimaryKey=new DataColumn[] {passedDt.Columns["Eventid"]};
            passedDt.Columns.Add("EventName");
            passedDt.Columns.Add("Date");
            passedDt.Columns.Add("Status");
        }

        private void dataGridView2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Action2.Show(dataGridView2, e.Location);
            }
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                selectedcatID = row.Cells[0].Value.ToString();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove selected event ? ","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                for (int i = 0; i < passedDt.Rows.Count; i++)
                {
                    if (passedDt.Rows[i][0].ToString() == selectedcatID)
                    {
                        passedDt.Rows.Remove(passedDt.Rows[i]);
                    }
                } 
            }

            //for (int i = 0; i < ingredients.Rows.Count; i++)
            //{
            //    string temp = ingredients.Rows[i][1].ToString();
            //    if (ins == temp)
            //    {
            //        if (ing[2].ToString() != "0")
            //        {
            //            ingredients.Rows[i][3] = Convert.ToDouble(ingredients.Rows[i][3].ToString()) + b;
            //            i = ingredients.Rows.Count;
            //        }
            //        else if (ing[3].ToString() != "0")
            //        {
            //            ingredients.Rows[i][4] = Convert.ToDouble(ingredients.Rows[i][4].ToString()) + b;
            //            i = ingredients.Rows.Count;
            //        }
            //        else if (ing[4].ToString() != "0")
            //        {
            //            ingredients.Rows[i][5] = Convert.ToDouble(ingredients.Rows[i][5].ToString()) + b;
            //            i = ingredients.Rows.Count;
            //        }
            //    }
            //}
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierBL BL = new SupplierBL();
            SupplierBO BO = new SupplierBO();
            RecBO = new RecipeBO();
            RecBL = new RecipeBL();
            IngBO = new IngredientBO();
            IngBL = new IngredientBL();
            CatBO = new CateringBO();
            CatBL = new CateringBL();
            if (reportType == "PO")
            {
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
                List<double> suppPO = new List<double>();
                List<decimal> Total = new List<decimal>();
                List<string> nameEvents = new List<string>();
                string typeofservice = "";
                string category = "";
                int eventcount = 0;
                double popoyFP = 0;
                double cdadFP = 0;
                double suppFP = 0;
                string guestType = "";
                int indicator = 0;
                decimal OverAll = 0;
                int categorysorter = 0;
                int counter = 0;
                eventcount = passedDt.Rows.Count;
                int foreachcutter = 0;
                string sampleevent = "";
                int showfirst = 1;
                DataTable suppliers = new DataTable();
                suppliers.Columns.Add("Supp");
                foreach (DataRow supp in BL.getSupplier().Rows)
                {
                    suppliers.Rows.Add(supp.ItemArray[0].ToString());
                }
                foreach (DataRow events in passedDt.Rows)
                {
                    nameEvents.Add(events.ItemArray[1].ToString());
                }
                foreach (DataRow passed in passedDt.Rows)
                {
                    #region oldcode

                    #endregion
                    sampleevent = passed.ItemArray[1].ToString();
                    if (selectedcatID != "")
                    {
                        CatBO.catID = passed.ItemArray[0].ToString();
                        foreach (DataRow item in CatBL.getCategoryOfRecipes(CatBO).Rows)
                        {
                            Categories.Add(item.ItemArray[0].ToString());
                        }
                        eventdetail = CatBL.getCatDetail(CatBO);
                        foreach (DataRow row in eventdetail.Rows)
                        {
                            vip = vip + Convert.ToInt32(row.ItemArray[3].ToString());
                            guest = guest + Convert.ToInt32(row.ItemArray[4].ToString());
                            kids = kids + Convert.ToInt32(row.ItemArray[5].ToString());
                            crew = crew + Convert.ToInt32(row.ItemArray[6].ToString());
                            Other = Other + Convert.ToInt32(row.ItemArray[7].ToString());
                            typeofservice = row.ItemArray[12].ToString();
                            contractfilename = row.ItemArray[1].ToString();
                            if (showfirst == eventcount)
                            {
                                Excel.Rows.Add("P.O Of Ingredients", "", "", "", "");
                                Excel.Rows.Add("", "", "");
                                Excel.Rows.Add("No. Of event selected : " + eventcount, "", "", "", "", "", "", "");
                                Excel.Rows.Add("List of event selected : ", "", "", "", "", "", "", "");
                                foreach (string eventnames in nameEvents)
                                {
                                    Excel.Rows.Add("  " + eventnames, "("+row.ItemArray[9].ToString()+")", "", "", "", "", "", "");
                                }
                                Excel.Rows.Add("", "", "", "", "");
                                Excel.Rows.Add(guest + " Guest, " + vip + " Vip, " + kids + " Kids", "", "", "", "", "");
                                Excel.Rows.Add(crew + " Crew, " + Other + " Other", "", "", "", "", "");
                                Excel.Rows.Add("", "", "", "", "");
                                Excel.Rows.Add("Ingredient", "Quantity", " Budget");

                            }
                            showfirst++;
                        }
                        int rowcounter = 0;
                        categorysorter = Categories.Count();
                        string recid = "";
                        while (counter < categorysorter)
                        {
                            CatBO.catID = passed.ItemArray[0].ToString();
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
                                    string ins = ing[0].ToString();
                                    decimal b = getPrice(ing.ItemArray[1].ToString(), paxx);
                                    if (typeofservice == "Plated" && category == "Main dish")
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
                                                ingredients.Rows[i][2] = Convert.ToDecimal(ingredients.Rows[i][2].ToString()) + b;
                                                i = ingredients.Rows.Count;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ingredients.Rows.Add(ing[0].ToString(), ing[2].ToString(), b);
                                    }
                                }
                            }
                            categoryshower = categoryshower + 1;
                            counter = counter + 1;
                            indicator = indicator + 1;
                        }

                    }
                }
                if (indicator != 0)
                {
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
                    vip = 0;
                    guest = 0;
                    kids = 0;
                    crew = 0;
                    Other = 0;
                    indicator = 0;
                    Excel.Rows.Add("", "Grand Total", "P " + OverAll.ToString("0.##"));
                    diagReport menu = new diagReport(Excel, "PO");
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Select a event first!");
                }
            }
            else if (reportType=="Summary")
            {
                DataTable dt = new DataTable();
                DataTable amounts = new DataTable();
                DataTable suppliers = BL.getSupplier();
                List<string> supps = new List<string>();
                dt.Columns.Add("1");
                dt.Columns.Add("2");
                dt.Columns.Add("3");
                dt.Columns.Add("4");
                dt.Columns.Add("5");
                dt.Columns.Add("6");
                dt.Columns.Add("7");
                dt.Columns.Add("8");
                dt.Columns.Add("9");
                dt.Columns.Add("10");
                dt.Columns.Add("11");
                dt.Columns.Add("12");
                dt.Columns.Add("13");
                dt.Columns.Add("14");
                dt.Columns.Add("15");
                dt.Columns.Add("16");
                dt.Columns.Add("17");
                dt.Columns.Add("18");
                dt.Columns.Add("19");
                dt.Columns.Add("20");
                dt.Columns.Add("21");
                dt.Columns.Add("22");
                List<decimal> totalExp = new List<decimal>();
                var tExp = new Dictionary<string, decimal>();
                int count = 0;
                for (int i = 0; i < 20; i++)
                {
                    supps.Add("");
                    totalExp.Add(0);
                }
                    CatBL = new CateringBL();
                    CatBO = new CateringBO();
                    decimal exp = 0;
                    string collectedid = "";
                    int countif1 = 0;
                    foreach (DataRow eventids in passedDt.Rows)
                    {
                        if (countif1==0)
                        {
                            collectedid = eventids.ItemArray[0].ToString();
                            countif1++;
                        }
                        else
                        {
                            collectedid = collectedid + "," + eventids.ItemArray[0].ToString(); 
                        }
                    }
                    CatBO.catID = collectedid;
                    DataTable disec = CatBL.showReportByEvent(CatBO);
                    string showonce = "";
                    int numberofevent = disec.Rows.Count;
                    foreach (DataRow nameOfSupplier in suppliers.Rows)
                    {
                        tExp.Add(nameOfSupplier.ItemArray[0].ToString(), 0);
                        supps[count] = (nameOfSupplier.ItemArray[0].ToString());
                        count++;
                    }
                    count = 0; 
                    int diff = supps.Count - tExp.Count;
                    int supptigil = tExp.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        tExp.Add("Vacant" + (i + 1), 0);
                        supps[supptigil] = ("Vacant" + (i + 1));
                        supptigil++;
                    }
                    dt.Rows.Add("", supps[0], supps[1], supps[2], supps[3], supps[4], supps[5], supps[6], supps[7], supps[8], supps[9], supps[10], supps[11], supps[12], supps[13], supps[14], supps[15], supps[16], supps[17], supps[18], supps[19], "Total Expense");
                    foreach (DataRow eventdetail in disec.Rows)
                    {
                        dt.Rows.Add(eventdetail.ItemArray[5].ToString());
                        if (showonce == eventdetail.ItemArray[5].ToString() && dt.Rows.Count != 0)
                        {
                            dt.Rows.RemoveAt(dt.Rows.Count - 1);
                        }
                        showonce = eventdetail.ItemArray[5].ToString();
                        catid = eventdetail.ItemArray[8].ToString();
                        BO.catid = catid;
                        amounts = BL.getSupplierBudget(BO);
                        foreach (DataRow amount in amounts.Rows)
                        {
                            totalExp[count] = (Convert.ToDecimal(amount.ItemArray[2].ToString()));
                            tExp[amount.ItemArray[1].ToString()] = (Convert.ToDecimal(amount.ItemArray[2].ToString()));
                            count++;
                        }

                        dt.Rows.Add(eventdetail.ItemArray[2].ToString() + " (" + eventdetail.ItemArray[3].ToString() + ")(" + eventdetail.ItemArray[6].ToString() + ")(" + eventdetail.ItemArray[7].ToString() + ")", "P " + tExp[supps[0]], "P " + tExp[supps[1]], "P " + tExp[supps[2]], "P " + tExp[supps[3]], "P " + tExp[supps[4]], "P " + tExp[supps[5]], "P " + tExp[supps[6]], "P " + tExp[supps[7]], "P " + tExp[supps[8]], "P " + tExp[supps[9]], "P " + tExp[supps[10]], "P " + tExp[supps[11]], "P " + tExp[supps[12]], "P " + tExp[supps[13]], "P " + tExp[supps[14]], "P " + tExp[supps[15]], "P " + tExp[supps[16]], "P " + tExp[supps[17]], "P " + tExp[supps[18]], "P " + tExp[supps[19]], "P " + totalExp.Sum().ToString("0.##"));
                        exp = exp + totalExp.Sum();
                        totalExp.Clear();
                        for (int i = 0; i < 20; i++)
                        {
                            totalExp.Add(0);
                            supps.Add("");
                        }
                        count = 0;
                    }
                    dt.Rows.Add("Number of Events : " + numberofevent, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Total Expense: ", "P " + exp);
                    OverallReport cr = new OverallReport();
                    diagReport diag = new diagReport(dt, "OverallReport");
                    diag.Show();
                
            }
        }
        List<string> nums = new List<string>();
        List<string> operations = new List<string>();
        private decimal getPrice(string form, string pax)
        {
            int lngthofstring = 0;

            string formula = "";

            int parameter = 0;

            int opercounter = 1;

            int counters = 0;
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
                            nums[counters] = nums[counters] + (Convert.ToString(arrayformula[parameter]));
                        }
                    }
                    else
                    {
                        nums.Add(pax);
                        parameter = parameter + 2;
                        counters = counters + 1;
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
                        counters = counters + 1;
                    }
                    opercounter = 1;

                }
                parameter = parameter + 1;
                lengthofstring = lengthofstring - 1;

            }
            parameter = 0;
            counters = 0;
            int numbercounter = 1;
            decimal answer = 0;
            int numofoper = operations.Count();
            while (numofoper != 0)
            {
                if (counters == 0)
                {
                    switch (Convert.ToChar(operations[counters]))
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
                    switch (Convert.ToChar(operations[counters]))
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
                counters = counters + 1;
                numofoper = numofoper - 1;
            }
            opercounter = 1;
            counters = 0;
            nums.Clear();
            parameter = 0;
            numbercounter = 0;
            operations.Clear();
            return answer;
        }
        internal RecipeBO RecBO { get; set; }

        internal RecipeBL RecBL { get; set; }

        internal IngredientBO IngBO { get; set; }

        internal IngredientBL IngBL { get; set; }

        internal CateringBO CatBO { get; set; }

        internal CateringBL CatBL { get; set; }

        public string supp1 { get; set; }

        public string supp2 { get; set; }

        public string supp3 { get; set; }

        public int vip { get; set; }

        public int guest { get; set; }

        public int kids { get; set; }

        public int crew { get; set; }

        public int Other { get; set; }

        public string contractfilename { get; set; }
    }
}
