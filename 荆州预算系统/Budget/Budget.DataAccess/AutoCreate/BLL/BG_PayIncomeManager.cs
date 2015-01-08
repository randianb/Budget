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

    public static partial class BG_PayIncomeManager
    {
        public static BG_PayIncome AddBG_PayIncome(BG_PayIncome bG_PayIncome)
        {
            return BG_PayIncomeService.AddBG_PayIncome(bG_PayIncome);
        }

        public static bool DeleteBG_PayIncome(BG_PayIncome bG_PayIncome)
        {
            return BG_PayIncomeService.DeleteBG_PayIncome(bG_PayIncome);
        }

        public static bool DeleteBG_PayIncomeByID(int pIID)
        {
            return BG_PayIncomeService.DeleteBG_PayIncomeByPIID(pIID);
        }

		public static bool ModifyBG_PayIncome(BG_PayIncome bG_PayIncome)
        {
            return BG_PayIncomeService.ModifyBG_PayIncome(bG_PayIncome);
        }
        
        public static DataTable GetAllBG_PayIncome()
        {
            return BG_PayIncomeService.GetAllBG_PayIncome();
        }

        public static BG_PayIncome GetBG_PayIncomeByPIID(int pIID)
        {
            return BG_PayIncomeService.GetBG_PayIncomeByPIID(pIID);
        }

    }
}
