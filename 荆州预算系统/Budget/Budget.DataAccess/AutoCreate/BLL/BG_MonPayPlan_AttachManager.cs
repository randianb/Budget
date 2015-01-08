//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/8 17:48:04
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_MonPayPlan_AttachManager
    {
        public static BG_MonPayPlan_Attach AddBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
        {
            return BG_MonPayPlan_AttachService.AddBG_MonPayPlan_Attach(bG_MonPayPlan_Attach);
        }

        public static bool DeleteBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
        {
            return BG_MonPayPlan_AttachService.DeleteBG_MonPayPlan_Attach(bG_MonPayPlan_Attach);
        }

        public static bool DeleteBG_MonPayPlan_AttachByID(int cPAID)
        {
            return BG_MonPayPlan_AttachService.DeleteBG_MonPayPlan_AttachByCPAID(cPAID);
        }

		public static bool ModifyBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
        {
            return BG_MonPayPlan_AttachService.ModifyBG_MonPayPlan_Attach(bG_MonPayPlan_Attach);
        }
        
        public static DataTable GetAllBG_MonPayPlan_Attach()
        {
            return BG_MonPayPlan_AttachService.GetAllBG_MonPayPlan_Attach();
        }

        public static BG_MonPayPlan_Attach GetBG_MonPayPlan_AttachByCPAID(int cPAID)
        {
            return BG_MonPayPlan_AttachService.GetBG_MonPayPlan_AttachByCPAID(cPAID);
        }

    }
}
