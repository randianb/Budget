//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:45
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_QuotaManager
    {
        public static BG_Quota AddBG_Quota(BG_Quota bG_Quota)
        {
            return BG_QuotaService.AddBG_Quota(bG_Quota);
        }

        public static bool DeleteBG_Quota(BG_Quota bG_Quota)
        {
            return BG_QuotaService.DeleteBG_Quota(bG_Quota);
        }

        public static bool DeleteBG_QuotaByID(int qtID)
        {
            return BG_QuotaService.DeleteBG_QuotaByQtID(qtID);
        }

		public static bool ModifyBG_Quota(BG_Quota bG_Quota)
        {
            return BG_QuotaService.ModifyBG_Quota(bG_Quota);
        }
        
        public static DataTable GetAllBG_Quota()
        {
            return BG_QuotaService.GetAllBG_Quota();
        }

        public static BG_Quota GetBG_QuotaByQtID(int qtID)
        {
            return BG_QuotaService.GetBG_QuotaByQtID(qtID);
        }

    }
}
