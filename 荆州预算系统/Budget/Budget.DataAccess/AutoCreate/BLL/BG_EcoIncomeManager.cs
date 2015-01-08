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

    public static partial class BG_EcoIncomeManager
    {
        public static BG_EcoIncome AddBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
        {
            return BG_EcoIncomeService.AddBG_EcoIncome(bG_EcoIncome);
        }

        public static bool DeleteBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
        {
            return BG_EcoIncomeService.DeleteBG_EcoIncome(bG_EcoIncome);
        }

        public static bool DeleteBG_EcoIncomeByID(int eIID)
        {
            return BG_EcoIncomeService.DeleteBG_EcoIncomeByEIID(eIID);
        }

		public static bool ModifyBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
        {
            return BG_EcoIncomeService.ModifyBG_EcoIncome(bG_EcoIncome);
        }
        
        public static DataTable GetAllBG_EcoIncome()
        {
            return BG_EcoIncomeService.GetAllBG_EcoIncome();
        }

        public static BG_EcoIncome GetBG_EcoIncomeByEIID(int eIID)
        {
            return BG_EcoIncomeService.GetBG_EcoIncomeByEIID(eIID);
        }

    }
}
