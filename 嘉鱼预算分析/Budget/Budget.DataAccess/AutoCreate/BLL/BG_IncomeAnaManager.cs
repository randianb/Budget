//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:04
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_IncomeAnaManager
    {
        public static BG_IncomeAna AddBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
        {
            return BG_IncomeAnaService.AddBG_IncomeAna(bG_IncomeAna);
        }

        public static bool DeleteBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
        {
            return BG_IncomeAnaService.DeleteBG_IncomeAna(bG_IncomeAna);
        }

        public static bool DeleteBG_IncomeAnaByID(int iAID)
        {
            return BG_IncomeAnaService.DeleteBG_IncomeAnaByIAID(iAID);
        }

		public static bool ModifyBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
        {
            return BG_IncomeAnaService.ModifyBG_IncomeAna(bG_IncomeAna);
        }
        
        public static DataTable GetAllBG_IncomeAna()
        {
            return BG_IncomeAnaService.GetAllBG_IncomeAna();
        }

        public static BG_IncomeAna GetBG_IncomeAnaByIAID(int iAID)
        {
            return BG_IncomeAnaService.GetBG_IncomeAnaByIAID(iAID);
        }

    }
}
