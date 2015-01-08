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

    public static partial class BG_MonPayPlanManager
    {
        public static BG_MonPayPlan AddBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
        {
            return BG_MonPayPlanService.AddBG_MonPayPlan(bG_MonPayPlan);
        }

        public static bool DeleteBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
        {
            return BG_MonPayPlanService.DeleteBG_MonPayPlan(bG_MonPayPlan);
        }

        public static bool DeleteBG_MonPayPlanByID(int cPID)
        {
            return BG_MonPayPlanService.DeleteBG_MonPayPlanByCPID(cPID);
        }

		public static bool ModifyBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
        {
            return BG_MonPayPlanService.ModifyBG_MonPayPlan(bG_MonPayPlan);
        }
        
        public static DataTable GetAllBG_MonPayPlan()
        {
            return BG_MonPayPlanService.GetAllBG_MonPayPlan();
        }

        public static BG_MonPayPlan GetBG_MonPayPlanByCPID(int cPID)
        {
            return BG_MonPayPlanService.GetBG_MonPayPlanByCPID(cPID);
        }

    }
}
