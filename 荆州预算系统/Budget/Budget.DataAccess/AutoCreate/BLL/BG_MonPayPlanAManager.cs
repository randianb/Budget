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

    public static partial class BG_MonPayPlanAManager
    {
        public static BG_MonPayPlanA AddBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
        {
            return BG_MonPayPlanAService.AddBG_MonPayPlanA(bG_MonPayPlanA);
        }

        public static bool DeleteBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
        {
            return BG_MonPayPlanAService.DeleteBG_MonPayPlanA(bG_MonPayPlanA);
        }

        public static bool DeleteBG_MonPayPlanAByID(int cAID)
        {
            return BG_MonPayPlanAService.DeleteBG_MonPayPlanAByCAID(cAID);
        }

		public static bool ModifyBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
        {
            return BG_MonPayPlanAService.ModifyBG_MonPayPlanA(bG_MonPayPlanA);
        }
        
        public static DataTable GetAllBG_MonPayPlanA()
        {
            return BG_MonPayPlanAService.GetAllBG_MonPayPlanA();
        }

        public static BG_MonPayPlanA GetBG_MonPayPlanAByCAID(int cAID)
        {
            return BG_MonPayPlanAService.GetBG_MonPayPlanAByCAID(cAID);
        }

    }
}
