using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class RecipeBO
    {
        public string recipeid { get; set; }
        public string recipe { get; set; }
        public string cat { get; set; }


        public object ingid { get; set; }

        public object meas { get; set; }

        public object ingdesc { get; set; }

        public object status { get; set; }
    }
    partial class RecipeBL
    {
        DataAccessLayer oDAL;
        public DataTable SearchRecipeCanBeUse()
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("  SearchRecipeCanBeUse");
        }
        public void addRecipeSlot(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.executeQuery("  addRecipeSlot");
        }
        public DataTable ChangeRecipeInuse(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_status", DbType.String, BO.status);
            oDAL.addParameter("_recID", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  ChangeRecipeInuse");
        }
        public DataTable searchRecipeTwoColumns(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            oDAL.addParameter("_cat", DbType.String, BO.cat);
            return oDAL.getDataTable("  searchRecipeTwoColumns");
        }
        public DataTable searchRecipe(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            oDAL.addParameter("_cat", DbType.String, BO.cat);
            return oDAL.getDataTable("  searchRecipe");
        }
        public DataTable searchRecipeSingle(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            oDAL.addParameter("_cat", DbType.String, BO.cat);
            return oDAL.getDataTable("  searchRecipeSingle");
        }
        public DataTable getLastRecipeID(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("  getLastRecipeID");
        }
        public void addRecipeIng(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipeid", DbType.String, BO.recipeid);
            oDAL.addParameter("_ingID", DbType.String, BO.ingid);
            oDAL.addParameter("_meas", DbType.String, BO.meas);
            oDAL.executeQuery("  addRecipeIng");
        }
        public DataTable getIngByRecID(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  getIngByRecID");
        }

        public void addRecipe(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recdesc", DbType.String, BO.recipe);
            oDAL.addParameter("_category", DbType.String, BO.cat);
            oDAL.executeQuery("  addRecipe");
        }
        public DataTable searchRecipeByName(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            return oDAL.getDataTable("  searchRecipeByName");
        }
        public DataTable checkRecipeIng(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.addParameter("_ingid", DbType.String, BO.ingid);
            return oDAL.getDataTable("  checkRecipeIng");
        }
        public void removeRecipeIng(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.addParameter("_ingdesc", DbType.String, BO.ingdesc);
            oDAL.executeQuery("  removeRecipeIng");
        }
        public DataTable checkRecipeName(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            return oDAL.getDataTable("  checkRecipeName");
        }
        public DataTable searchRecipeByID(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  searchRecipeByID");
        }
        public DataTable checkRecipe(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.addParameter("_recdesc", DbType.String, BO.recipe);
            return oDAL.getDataTable("  checkRecipe");
        }
        public void removeNewlyAddedIngToRecipe(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.addParameter("_ingid", DbType.String, BO.ingid);
            oDAL.executeQuery("  removeNewlyAddedIngToRecipe");
        }
        public void updateRecipe(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recdesc", DbType.String, BO.recipe);
            oDAL.addParameter("_cat", DbType.String, BO.cat);
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.executeQuery("  updateRecipe");
        }
        public void makeRecipeUnavail(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.executeQuery("  makeRecipeUnavail");
        }
        public DataTable searchRecipeUn(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recipe", DbType.String, BO.recipe);
            oDAL.addParameter("_cat", DbType.String, BO.cat);
            return oDAL.getDataTable("  searchRecipeUn");
        }
        public void makeRecipeAvail(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.executeQuery("  makeRecipeAvail");
        }
        public DataTable searchIngByID(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ing", DbType.String, BO.ingid);
            return oDAL.getDataTable("  searchIngByID");
        }
        public DataTable getIngByRecIdOrig(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  getIngByRecIdOrig");
        }
        public void deleteAllRecIng(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.executeQuery("  deleteAllRecIng");
        }
        public DataTable getRecipeNameAndFormulaAndPriceByDish(RecipeBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  getRecipeNameAndFormulaAndPriceByDish");
        }
    }
}
