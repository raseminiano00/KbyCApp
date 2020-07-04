using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class ConnectBO
    {

        public string path { get; set; }
        public string db { get; set; }
    }
    partial class ConnectBL
    {
        DataAccessLayer oDAL;
        public void checkConn()
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.executeQuery("  checkConn");
        }
        public void Export(ConnectBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.Backup(BO.path);
        }
        public void Import(ConnectBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.Restore(BO.path);
        }
        public void CreateDb(ConnectBO BO)
        {
            oDAL = new DataAccessLayer();
            oDAL.addParameter("_database", DbType.String, BO.db);
            oDAL.executeQuery("createDatabase");
        }
    }
}
