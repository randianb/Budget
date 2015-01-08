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

    public static partial class BG_MonPayPlan_HisManager
    {
        public static BG_MonPayPlan_His AddBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
        {
            return BG_MonPayPlan_HisService.AddBG_MonPayPlan_His(bG_MonPayPlan_His);
        }

        public static bool DeleteBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
        {
            return BG_MonPayPlan_HisService.DeleteBG_MonPayPlan_His(bG_MonPayPlan_His);
        }

        public static bool DeleteBG_MonPayPlan_HisByID(int mPPHis)
        {
            return BG_MonPayPlan_HisService.DeleteBG_MonPayPlan_HisByMPPHis(mPPHis);
        }

		public static bool ModifyBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
        {
            return BG_MonPayPlan_HisService.ModifyBG_MonPayPlan_His(bG_MonPayPlan_His);
        }
        
        public static DataTable GetAllBG_MonPayPlan_His()
        {
            return BG_MonPayPlan_HisService.GetAllBG_MonPayPlan_His();
        }

        public static BG_MonPayPlan_His GetBG_MonPayPlan_HisByMPPHis(int mPPHis)
        {
            return BG_MonPayPlan_HisService.GetBG_MonPayPlan_HisByMPPHis(mPPHis);
        }

    }
}
