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

    public static partial class BG_MonManager
    {
        public static BG_Mon AddBG_Mon(BG_Mon bG_Mon)
        {
            return BG_MonService.AddBG_Mon(bG_Mon);
        }

        public static bool DeleteBG_Mon(BG_Mon bG_Mon)
        {
            return BG_MonService.DeleteBG_Mon(bG_Mon);
        }

        public static bool DeleteBG_MonByID(int bGID)
        {
            return BG_MonService.DeleteBG_MonByBGID(bGID);
        }

		public static bool ModifyBG_Mon(BG_Mon bG_Mon)
        {
            return BG_MonService.ModifyBG_Mon(bG_Mon);
        }
        
        public static DataTable GetAllBG_Mon()
        {
            return BG_MonService.GetAllBG_Mon();
        }

        public static BG_Mon GetBG_MonByBGID(int bGID)
        {
            return BG_MonService.GetBG_MonByBGID(bGID);
        }

    }
}
