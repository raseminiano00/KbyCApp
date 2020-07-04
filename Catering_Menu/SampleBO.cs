using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Catering_Menu
{
    class SampleBO
    {
        DataAccessLayer oDAL;
        public DataTable sample ()
        {
            oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            return oDAL.getDataTable("call samplesp()");
        }
    }
}
