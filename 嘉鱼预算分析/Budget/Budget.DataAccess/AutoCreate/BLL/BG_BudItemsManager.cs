//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_BudItemsManager
    {
        public static BG_BudItems AddBG_BudItems(BG_BudItems bG_BudItems)
        {
            return BG_BudItemsService.AddBG_BudItems(bG_BudItems);
        }

        public static bool DeleteBG_BudItems(BG_BudItems bG_BudItems)
        {
            return BG_BudItemsService.DeleteBG_BudItems(bG_BudItems);
        }

        public static bool DeleteBG_BudItemsByID(int budID)
        {
            return BG_BudItemsService.DeleteBG_BudItemsByBudID(budID);
        }

		public static bool ModifyBG_BudItems(BG_BudItems bG_BudItems)
        {
            return BG_BudItemsService.ModifyBG_BudItems(bG_BudItems);
        }
        
        public static DataTable GetAllBG_BudItems()
        {
            return BG_BudItemsService.GetAllBG_BudItems();
        }

        public static BG_BudItems GetBG_BudItemsByBudID(int budID)
        {
            return BG_BudItemsService.GetBG_BudItemsByBudID(budID);
        }

    }
}
