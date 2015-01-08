//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:04
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_ProvBudItemsManager
    {
        public static BG_ProvBudItems AddBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
        {
            return BG_ProvBudItemsService.AddBG_ProvBudItems(bG_ProvBudItems);
        }

        public static bool DeleteBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
        {
            return BG_ProvBudItemsService.DeleteBG_ProvBudItems(bG_ProvBudItems);
        }

        public static bool DeleteBG_ProvBudItemsByID(int pBID)
        {
            return BG_ProvBudItemsService.DeleteBG_ProvBudItemsByPBID(pBID);
        }

		public static bool ModifyBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
        {
            return BG_ProvBudItemsService.ModifyBG_ProvBudItems(bG_ProvBudItems);
        }
        
        public static DataTable GetAllBG_ProvBudItems()
        {
            return BG_ProvBudItemsService.GetAllBG_ProvBudItems();
        }

        public static BG_ProvBudItems GetBG_ProvBudItemsByPBID(int pBID)
        {
            return BG_ProvBudItemsService.GetBG_ProvBudItemsByPBID(pBID);
        }

    }
}
