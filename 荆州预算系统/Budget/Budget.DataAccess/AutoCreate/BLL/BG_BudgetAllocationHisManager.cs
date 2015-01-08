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

    public static partial class BG_BudgetAllocationHisManager
    {
        public static BG_BudgetAllocationHis AddBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
        {
            return BG_BudgetAllocationHisService.AddBG_BudgetAllocationHis(bG_BudgetAllocationHis);
        }

        public static bool DeleteBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
        {
            return BG_BudgetAllocationHisService.DeleteBG_BudgetAllocationHis(bG_BudgetAllocationHis);
        }

        public static bool DeleteBG_BudgetAllocationHisByID(int bAAHisID)
        {
            return BG_BudgetAllocationHisService.DeleteBG_BudgetAllocationHisByBAAHisID(bAAHisID);
        }

		public static bool ModifyBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
        {
            return BG_BudgetAllocationHisService.ModifyBG_BudgetAllocationHis(bG_BudgetAllocationHis);
        }
        
        public static DataTable GetAllBG_BudgetAllocationHis()
        {
            return BG_BudgetAllocationHisService.GetAllBG_BudgetAllocationHis();
        }

        public static BG_BudgetAllocationHis GetBG_BudgetAllocationHisByBAAHisID(int bAAHisID)
        {
            return BG_BudgetAllocationHisService.GetBG_BudgetAllocationHisByBAAHisID(bAAHisID);
        }

    }
}
