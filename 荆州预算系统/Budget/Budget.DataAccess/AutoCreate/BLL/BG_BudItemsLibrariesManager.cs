//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:44
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_BudItemsLibrariesManager
    {
        public static BG_BudItemsLibraries AddBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
        {
            return BG_BudItemsLibrariesService.AddBG_BudItemsLibraries(bG_BudItemsLibraries);
        }

        public static bool DeleteBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
        {
            return BG_BudItemsLibrariesService.DeleteBG_BudItemsLibraries(bG_BudItemsLibraries);
        }

        public static bool DeleteBG_BudItemsLibrariesByID(int budItID)
        {
            return BG_BudItemsLibrariesService.DeleteBG_BudItemsLibrariesByBudItID(budItID);
        }

		public static bool ModifyBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
        {
            return BG_BudItemsLibrariesService.ModifyBG_BudItemsLibraries(bG_BudItemsLibraries);
        }
        
        public static DataTable GetAllBG_BudItemsLibraries()
        {
            return BG_BudItemsLibrariesService.GetAllBG_BudItemsLibraries();
        }

        public static BG_BudItemsLibraries GetBG_BudItemsLibrariesByBudItID(int budItID)
        {
            return BG_BudItemsLibrariesService.GetBG_BudItemsLibrariesByBudItID(budItID);
        }

    }
}
