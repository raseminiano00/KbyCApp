using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Catering_Menu
{
    class PurchaseOrderGenerator : IReportGenerator
    {
        List<Dish> dishes;
        public DataTable Generate()
        {
            return new DataTable();
        }
    }
}
