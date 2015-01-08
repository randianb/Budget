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

    public static partial class BG_BudgetAllocationManager
    {
        public static BG_BudgetAllocation AddBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
        {
            return BG_BudgetAllocationService.AddBG_BudgetAllocation(bG_BudgetAllocation);
        }

        public static bool DeleteBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
        {
            return BG_BudgetAllocationService.DeleteBG_BudgetAllocation(bG_BudgetAllocation);
        }

        public static bool DeleteBG_BudgetAllocationByID(int bAAID)
        {
            return BG_BudgetAllocationService.DeleteBG_BudgetAllocationByBAAID(bAAID);
        }

		public static bool ModifyBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
        {
            return BG_BudgetAllocationService.ModifyBG_BudgetAllocation(bG_BudgetAllocation);
        }
        
        public static DataTable GetAllBG_BudgetAllocation()
        {
            return BG_BudgetAllocationService.GetAllBG_BudgetAllocation();
        }

        public static BG_BudgetAllocation GetBG_BudgetAllocationByBAAID(int bAAID)
        {
            return BG_BudgetAllocationService.GetBG_BudgetAllocationByBAAID(bAAID);
        }

    }
}
