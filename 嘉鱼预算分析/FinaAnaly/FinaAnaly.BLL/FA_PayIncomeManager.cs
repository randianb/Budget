//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{

    public static partial class FA_PayIncomeManager
    {
        public static FA_PayIncome AddFA_PayIncome(FA_PayIncome fA_PayIncome)
        {
            return FA_PayIncomeService.AddFA_PayIncome(fA_PayIncome);
        }

        public static bool DeleteFA_PayIncome(FA_PayIncome fA_PayIncome)
        {
            return FA_PayIncomeService.DeleteFA_PayIncome(fA_PayIncome);
        }

        public static bool DeleteFA_PayIncomeByID(int pIID)
        {
            return FA_PayIncomeService.DeleteFA_PayIncomeByPIID(pIID);
        }

		public static bool ModifyFA_PayIncome(FA_PayIncome fA_PayIncome)
        {
            return FA_PayIncomeService.ModifyFA_PayIncome(fA_PayIncome);
        }
        
        public static DataTable GetAllFA_PayIncome()
        {
            return FA_PayIncomeService.GetAllFA_PayIncome();
        }

        public static FA_PayIncome GetFA_PayIncomeByPIID(int pIID)
        {
            return FA_PayIncomeService.GetFA_PayIncomeByPIID(pIID);
        }

    }
}
