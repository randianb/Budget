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

    public static partial class BG_EstimatesAllocationManager
    {
        public static BG_EstimatesAllocation AddBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
        {
            return BG_EstimatesAllocationService.AddBG_EstimatesAllocation(bG_EstimatesAllocation);
        }

        public static bool DeleteBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
        {
            return BG_EstimatesAllocationService.DeleteBG_EstimatesAllocation(bG_EstimatesAllocation);
        }

        public static bool DeleteBG_EstimatesAllocationByID(int bEAID)
        {
            return BG_EstimatesAllocationService.DeleteBG_EstimatesAllocationByBEAID(bEAID);
        }

		public static bool ModifyBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
        {
            return BG_EstimatesAllocationService.ModifyBG_EstimatesAllocation(bG_EstimatesAllocation);
        }
        
        public static DataTable GetAllBG_EstimatesAllocation()
        {
            return BG_EstimatesAllocationService.GetAllBG_EstimatesAllocation();
        }

        public static BG_EstimatesAllocation GetBG_EstimatesAllocationByBEAID(int bEAID)
        {
            return BG_EstimatesAllocationService.GetBG_EstimatesAllocationByBEAID(bEAID);
        }

    }
}
