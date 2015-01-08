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

    public static partial class BG_DayPubBudgetManager
    {
        public static BG_DayPubBudget AddBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
        {
            return BG_DayPubBudgetService.AddBG_DayPubBudget(bG_DayPubBudget);
        }

        public static bool DeleteBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
        {
            return BG_DayPubBudgetService.DeleteBG_DayPubBudget(bG_DayPubBudget);
        }

        public static bool DeleteBG_DayPubBudgetByID(int dPBID)
        {
            return BG_DayPubBudgetService.DeleteBG_DayPubBudgetByDPBID(dPBID);
        }

		public static bool ModifyBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
        {
            return BG_DayPubBudgetService.ModifyBG_DayPubBudget(bG_DayPubBudget);
        }
        
        public static DataTable GetAllBG_DayPubBudget()
        {
            return BG_DayPubBudgetService.GetAllBG_DayPubBudget();
        }

        public static BG_DayPubBudget GetBG_DayPubBudgetByDPBID(int dPBID)
        {
            return BG_DayPubBudgetService.GetBG_DayPubBudgetByDPBID(dPBID);
        }

    }
}
