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

    public static partial class BG_BudItemHisManager
    {
        public static BG_BudItemHis AddBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
        {
            return BG_BudItemHisService.AddBG_BudItemHis(bG_BudItemHis);
        }

        public static bool DeleteBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
        {
            return BG_BudItemHisService.DeleteBG_BudItemHis(bG_BudItemHis);
        }

        public static bool DeleteBG_BudItemHisByID(int budHisID)
        {
            return BG_BudItemHisService.DeleteBG_BudItemHisByBudHisID(budHisID);
        }

		public static bool ModifyBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
        {
            return BG_BudItemHisService.ModifyBG_BudItemHis(bG_BudItemHis);
        }
        
        public static DataTable GetAllBG_BudItemHis()
        {
            return BG_BudItemHisService.GetAllBG_BudItemHis();
        }

        public static BG_BudItemHis GetBG_BudItemHisByBudHisID(int budHisID)
        {
            return BG_BudItemHisService.GetBG_BudItemHisByBudHisID(budHisID);
        }

    }
}
