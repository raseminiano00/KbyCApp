using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Catering_Menu
{
    public class Dish
    {
        public string Category { get; set; }
        public int Pax { get; set; }
        public string TypeOfService { get; set; }

        public string RecipeID { get; set; }
        public string RecipeName { get; set; }
        public Dish(string recipeName, string category, int pax,string typeOfService,string recipeID)
        {
            Category = category;
            Pax = pax;
            TypeOfService = typeOfService;
            RecipeID = recipeID;
            RecipeName = recipeName;
        }

        public DataTable GetIngredientsListWithCost()
        {
            DataTable ingredients = new DataTable();
            ingredients.Columns.Add("1", typeof(String));
            ingredients.Columns.Add("2");
            ingredients.Columns.Add("3");
            ingredients.Columns.Add("4");
            ingredients.Columns.Add("5");
            ingredients.Columns.Add("6");
            ingredients.PrimaryKey = new DataColumn[] { ingredients.Columns["1"] };

            RecipeBL recipeBL = new RecipeBL();
            RecipeBO recipeBO = new RecipeBO();

            CateringBL CatBL = new CateringBL();
            CateringBO CatBO = new CateringBO();
            recipeBO.recipeid = this.RecipeID;
            var dishesrecipe = recipeBL.getRecipeNameAndFormulaAndPriceByDish(recipeBO);
            foreach (DataRow ing in dishesrecipe.Rows)
            {
                string paxx = this.Pax.ToString();
                string ins = ing[0].ToString();
                decimal actualPrice = getPrice(ing.ItemArray[1].ToString(), paxx);
                if (this.TypeOfService == "Plated" && this.Category == "Main dish")
                {
                    actualPrice = actualPrice * Properties.Settings.Default.Plated;
                }
                //decimal b = getPrice(ing.ItemArray[1].ToString(), paxx);
                if (ingredients.Rows.Contains(ins))
                {

                    for (int i = 0; i < ingredients.Rows.Count; i++)
                    {
                        string temp = ingredients.Rows[i][0].ToString();
                        if (ins == temp)
                        {
                            ingredients.Rows[i][2] = (Convert.ToDecimal(ingredients.Rows[i][2].ToString()) + Convert.ToDecimal(actualPrice));
                            i = ingredients.Rows.Count;
                        }
                    }
                }
                else
                {
                    ingredients.Rows.Add(ing[0].ToString(), ing[2].ToString(), actualPrice);
                }
            }
            return ingredients;
        }
        private int parameter { get; set; }

        private int counter { get; set; }

        private int opercounter = 1;

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
        public DataTable ToPODishDescription()
        {
            DataTable Excel = new DataTable();
            Excel.Columns.Add("1");
            Excel.Columns.Add("2");
            Excel.Columns.Add("3");
            Excel.Columns.Add("4");
            Excel.Columns.Add("5");
            Excel.Columns.Add("6");
            Excel.Columns.Add("7");
            Excel.Columns.Add("8");
            Excel.Rows.Add("", RecipeName, "", "", Pax);
            return Excel;
        }
    }
}