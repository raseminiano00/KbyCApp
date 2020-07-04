using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class IngredientBO
    {
        public string ingid { get; set; }
        public string ing { get; set; }
        public string measurement { get; set; }
        public string popoy { get; set; }
        public string cdad { get; set; }
        public string sup { get; set; }


        public string supp1 { get; set; }

        public string supp2 { get; set; }

        public string supp3 { get; set; }

        public object price { get; set; }
    }
    partial class IngredientBL
    {
        DataAccessLayer oDAL;
        public DataTable searchIng(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supp1", DbType.String, BO.supp1);
            oDAL.addParameter("_supp2", DbType.String, BO.supp2);
            oDAL.addParameter("_supp3", DbType.String, BO.supp3);
            oDAL.addParameter("_ing", DbType.String, BO.ing);
            return oDAL.getDataTable(" searchIng");
        }
        public DataTable searchIngredientReturnPrice(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ing", DbType.String, BO.ing);
            return oDAL.getDataTable("  searchIngredientReturnPrice");
        }
        public void addIng(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ingDesc", DbType.String, BO.ing);
            oDAL.addParameter("_meas", DbType.String, BO.measurement);
            oDAL.addParameter("_sup", DbType.String, BO.sup);
            oDAL.addParameter("_price", DbType.String, BO.price);
            oDAL.executeQuery("  adding");
        }
        public DataTable checkIng(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_id", DbType.String, BO.ingid);
            oDAL.addParameter("_ing", DbType.String, BO.ing);
            return oDAL.getDataTable("  checkIng");
        }
        public void updateing(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ingDesc", DbType.String, BO.ing);
            oDAL.addParameter("_meas", DbType.String, BO.measurement);
            oDAL.addParameter("_sup", DbType.String, BO.sup);
            oDAL.addParameter("_price", DbType.String, BO.price);
            oDAL.addParameter("_ingid", DbType.String, BO.ingid);
            oDAL.executeQuery("  updateing");
        }
        public DataTable checkIngByDesc(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ing", DbType.String, BO.ing);
            return oDAL.getDataTable("  checkIngByDesc");
        }
        public void deleteing(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ingid", DbType.String, BO.ingid);
            oDAL.executeQuery("  deleteing");
        }
        public DataTable getAllrecipeWithIng(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ingid", DbType.String, BO.ingid);
            return oDAL.getDataTable("  getAllrecipeWithIng");
        }
        public DataTable searchIngNameOnly(IngredientBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_ingdesc", DbType.String, BO.ing);
            return oDAL.getDataTable("  searchIngNameOnly");
        }

    }
}
