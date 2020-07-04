using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class CateringBO
    {
        public string catID { get; set; }
        public string recipeid { get; set; }
        public string clientName { get; set; }
        public string placeOfEvent { get; set; }
        public string pax { get; set; }
        public string DateApproved { get; set; }
        public string DateOfEvent { get; set; }
        public string Status { get; set; }

        public object dishprice { get; set; }

        public string popoy { get; set; }

        public string cdad { get; set; }

        public string supp { get; set; }

        public object category { get; set; }

        public string guest { get; set; }

        public object vip { get; set; }

        public object kids { get; set; }

        public object crew { get; set; }

        public object dateT { get; set; }

        public object dateF { get; set; }

        public string typeOfevent { get; set; }

        public string other { get; set; }

        public object guestTarget { get; set; }

        public object service { get; set; }

        public object inuse { get; set; }

        public string price { get; set; }
    }
    partial class CateringBL
    {
        DataAccessLayer oDAL;
        public void addCatDish(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_recipeID", DbType.String, BO.recipeid);
            oDAL.addParameter("_price", DbType.String, BO.price);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.addParameter("_pax", DbType.String, BO.pax);
            oDAL.executeQuery("  addCatDish");
        }
        public void insertSampleCat(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_vip", DbType.String, BO.vip);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.addParameter("_kids", DbType.String, BO.kids);
            oDAL.addParameter("_crew", DbType.String, BO.crew);
            oDAL.addParameter("_other", DbType.String, BO.other);
            oDAL.executeQuery("addCatDish");
        }
        public void AddEventInuse(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.executeQuery("AddEventInuse");
        }
        public void ChangeEventInuse(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_inuse", DbType.String, BO.inuse);
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.executeQuery("ChangeEventInuse");
        }
        public void updateAllActiveEvent(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_date", DbType.String, BO.DateOfEvent);
            oDAL.executeQuery("  updateAllActiveEvent");
        }
        public void updateDishPrice(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_popoy", DbType.String, BO.popoy);
            oDAL.addParameter("_cdad", DbType.String, BO.cdad);
            oDAL.addParameter("_supp", DbType.String, BO.supp);
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.executeQuery("  updateDishPrice");
        }
        public void updateStatusCat(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_stat", DbType.String, BO.Status);
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.executeQuery("  updateStatusCat");
        }
        public DataTable SearchEventNotInuse(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("SearchEventNotInuse");
        }
        public DataTable SearchEventCanBeUse(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("SearchEventCanBeUse");
        }
        public DataTable getLastCatID(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("  getLastCatID");
        }
        public DataTable checkEventIfDone(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_date", DbType.String, BO.DateOfEvent);
            return oDAL.getDataTable("checkEventIfDone");
        }
        public DataTable getCatDetailByPeriod(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_statu", DbType.String, BO.Status);
            oDAL.addParameter("_dateF", DbType.String, BO.dateF);
            oDAL.addParameter("_dateT", DbType.String, BO.dateT);
            return oDAL.getDataTable("  getCatDetailByPeriod");
        }
        public DataTable showReport(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_dateF", DbType.String, BO.dateF);
            oDAL.addParameter("_dateT", DbType.String, BO.dateT);
            oDAL.addParameter("_statu", DbType.String, BO.Status);
            return oDAL.getDataTable("  showReport");
        }
        public DataTable showReportByEvent(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_events", DbType.String, BO.catID);
            return oDAL.getDataTable("  showReportByEvent");
        }
        public DataTable getRecipeNameAndFormulaAndPrice(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_cat", DbType.String, BO.category);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("  getRecipeNameAndFormulaAndPrice");
        }
        public DataTable getCateringDish(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_cat", DbType.String, BO.category);
            return oDAL.getDataTable("  getCateringDish");
        }
        public DataTable getCateringDishStatic(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_cat", DbType.String, BO.category);
            return oDAL.getDataTable("  getCateringDishStatic");
        }
        public DataTable getCategoryOfDynamic(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            return oDAL.getDataTable("  getCategoryOfDynamic");
        }
        public DataTable getCateringDishDynamic(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_cat", DbType.String, BO.category);
            oDAL.addParameter("_guestTarget", DbType.String, BO.guestTarget);
            return oDAL.getDataTable("  getCateringDishDynamic");
        }
        public DataTable getCateringDishWithoutPrice(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_cat", DbType.String, BO.category);
            return oDAL.getDataTable("  getCateringDishWithoutPrice");
        }
        public DataTable getCategoryOfRecipes(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            return oDAL.getDataTable("  getCategoryOfRecipes");
        }
        public void removeDishes(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.executeQuery("removeDishes");
        }
        public void removeDish(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.addParameter("_recipeID", DbType.String, BO.recipeid);
            oDAL.addParameter("_pax", DbType.String, BO.pax);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.executeQuery("removeDish");
        }
        public void addCateringOrder(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_cn", DbType.String, BO.clientName);
            oDAL.addParameter("_place", DbType.String, BO.placeOfEvent);
            oDAL.addParameter("_vip", DbType.String, BO.vip);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.addParameter("_kids", DbType.String, BO.kids);
            oDAL.addParameter("_crew", DbType.String, BO.crew);
            oDAL.addParameter("_other", DbType.String, BO.other);
            oDAL.addParameter("_date", DbType.String, BO.DateOfEvent);
            oDAL.addParameter("_type", DbType.String, BO.typeOfevent);
            oDAL.addParameter("_service", DbType.String, BO.service);
            oDAL.executeQuery("addCateringOrder");
        }
        public void updateCatOrder(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_cn", DbType.String, BO.clientName);
            oDAL.addParameter("_place", DbType.String, BO.placeOfEvent);
            oDAL.addParameter("_vip", DbType.String, BO.vip);
            oDAL.addParameter("_guest", DbType.String, BO.guest);
            oDAL.addParameter("_kids", DbType.String, BO.kids);
            oDAL.addParameter("_crew", DbType.String, BO.crew);
            oDAL.addParameter("_other", DbType.String, BO.other);
            oDAL.addParameter("_Date", DbType.String, BO.DateOfEvent);
            oDAL.addParameter("_type", DbType.String, BO.typeOfevent);
            oDAL.addParameter("_service", DbType.String, BO.service);
            oDAL.addParameter("_status", DbType.String, BO.Status);
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            oDAL.executeQuery("updateCatOrder");
        }
        public DataTable searchCatOrder(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_date", DbType.String, BO.DateOfEvent);
            oDAL.addParameter("_stat", DbType.String, BO.Status);
            return oDAL.getDataTable("searchCatOrder");
        }
        public DataTable getCatDetail(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catID);
            return oDAL.getDataTable("getCatDetail");
        }
        public DataTable getSuppPrices(CateringBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_recid", DbType.String, BO.recipeid);
            return oDAL.getDataTable("getSuppPrices");
        }
    }
}
