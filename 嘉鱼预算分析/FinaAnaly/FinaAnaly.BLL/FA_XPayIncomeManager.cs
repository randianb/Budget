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

    public static partial class FA_XPayIncomeManager
    {
        public static FA_XPayIncome AddFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
        {
            return FA_XPayIncomeService.AddFA_XPayIncome(fA_XPayIncome);
        }

        public static bool DeleteFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
        {
            return FA_XPayIncomeService.DeleteFA_XPayIncome(fA_XPayIncome);
        }

        public static bool DeleteFA_XPayIncomeByID(int pIID)
        {
            return FA_XPayIncomeService.DeleteFA_XPayIncomeByPIID(pIID);
        }

		public static bool ModifyFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
        {
            return FA_XPayIncomeService.ModifyFA_XPayIncome(fA_XPayIncome);
        }
        
        public static DataTable GetAllFA_XPayIncome()
        {
            return FA_XPayIncomeService.GetAllFA_XPayIncome();
        }

        public static FA_XPayIncome GetFA_XPayIncomeByPIID(int pIID)
        {
            return FA_XPayIncomeService.GetFA_XPayIncomeByPIID(pIID);
        }

    }
}
