using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Catering_Menu
{
    static class Program
    {
        /// ^<summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmIngredient("Normal"));
            //Application.Run(new diagIngredient());
            //Application.Run(new frmRecipes());
            //Application.Run(new diagAddRecipe());
            //Application.Run(new frmManageMenu(null));
            ////Application.Run(new frmMenu());
            //Application.Run(new frmSelectEventReport());
            Application.Run(new frmCatering());
            //Application.Run(new frmSysSettings());
        }
    }
}
