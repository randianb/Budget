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

    public static partial class FA_IncomeAccAllocatManager
    {
        public static FA_IncomeAccAllocat AddFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
        {
            return FA_IncomeAccAllocatService.AddFA_IncomeAccAllocat(fA_IncomeAccAllocat);
        }

        public static bool DeleteFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
        {
            return FA_IncomeAccAllocatService.DeleteFA_IncomeAccAllocat(fA_IncomeAccAllocat);
        }

        public static bool DeleteFA_IncomeAccAllocatByID(int iAAID)
        {
            return FA_IncomeAccAllocatService.DeleteFA_IncomeAccAllocatByIAAID(iAAID);
        }

		public static bool ModifyFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
        {
            return FA_IncomeAccAllocatService.ModifyFA_IncomeAccAllocat(fA_IncomeAccAllocat);
        }
        
        public static DataTable GetAllFA_IncomeAccAllocat()
        {
            return FA_IncomeAccAllocatService.GetAllFA_IncomeAccAllocat();
        }

        public static FA_IncomeAccAllocat GetFA_IncomeAccAllocatByIAAID(int iAAID)
        {
            return FA_IncomeAccAllocatService.GetFA_IncomeAccAllocatByIAAID(iAAID);
        }

    }
}
