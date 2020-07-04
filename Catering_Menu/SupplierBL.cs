using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class SupplierBL
    {
        DataAccessLayer oDAL;
        public void updateSupplier(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supp1", DbType.String, BO.supp1);
            oDAL.addParameter("_old", DbType.String, BO.old);
            oDAL.executeQuery("  updateSupplier");
        }
        public DataTable getSupplier()
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("  getSupplier");
        }
        public DataTable searchSupp(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supp1", DbType.String, BO.supp1);
            return oDAL.getDataTable("searchSupplier");
        }
        public DataTable addSupp(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supplier", DbType.String, BO.supp1);
            return oDAL.getDataTable("  addSupplier");
        }
        public DataTable delSupp(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supp1", DbType.String, BO.supp1);
            oDAL.addParameter("_new", DbType.String, BO.supp2);
            return oDAL.getDataTable("  deleteSupp");
        }
        public DataTable updateIngSuppOnly(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_supp1", DbType.String, BO.supp1);
            oDAL.addParameter("_supp2", DbType.String, BO.supp2);
            return oDAL.getDataTable("  updateIngSuppOnly");
        }
        public DataTable getSupplierBudget(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catID", DbType.String, BO.catid);
            return oDAL.getDataTable("getSupplierBudget");
        }
        public void addSuppBudget(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catid);
            oDAL.addParameter("_supp", DbType.String, BO.supp1);
            oDAL.addParameter("_amount", DbType.String, BO.amount);
            oDAL.getDataTable("  addSuppBudget");
        }
        public void updatePrioritySupplier(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_prior", DbType.Int32, BO.prior);
            oDAL.addParameter("_supp", DbType.String, BO.supp1);
            oDAL.getDataTable("  updatePrioritySupplier");
        }
        public void UpdateSupplierBudget(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_amount", DbType.String, BO.amount);
            oDAL.addParameter("_supp", DbType.String, BO.supp1);
            oDAL.addParameter("_catid", DbType.String, BO.catid);
            oDAL.getDataTable("  UpdateSupplierBudget");
        }
        public void deleteSupplierBudget(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catid);
            oDAL.getDataTable("  deleteSupplierBudget");
        }
        public void removeAllSupBudget(SupplierBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_catid", DbType.String, BO.catid);
            oDAL.getDataTable("  removeAllSupBudget");
        }
    }
    partial class SupplierBO
    {

        public object supp1 { get; set; }

        public object supp3 { get; set; }

        public object supp2 { get; set; }

        public object old { get; set; }

        public object catid { get; set; }

        public object amount { get; set; }

        public object prior { get; set; }
    }
}
