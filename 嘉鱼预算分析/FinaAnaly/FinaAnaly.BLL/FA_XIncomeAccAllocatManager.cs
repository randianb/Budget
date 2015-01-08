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

    public static partial class FA_XIncomeAccAllocatManager
    {
        public static FA_XIncomeAccAllocat AddFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
        {
            return FA_XIncomeAccAllocatService.AddFA_XIncomeAccAllocat(fA_XIncomeAccAllocat);
        }

        public static bool DeleteFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
        {
            return FA_XIncomeAccAllocatService.DeleteFA_XIncomeAccAllocat(fA_XIncomeAccAllocat);
        }

        public static bool DeleteFA_XIncomeAccAllocatByID(int iAAID)
        {
            return FA_XIncomeAccAllocatService.DeleteFA_XIncomeAccAllocatByIAAID(iAAID);
        }

		public static bool ModifyFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
        {
            return FA_XIncomeAccAllocatService.ModifyFA_XIncomeAccAllocat(fA_XIncomeAccAllocat);
        }
        
        public static DataTable GetAllFA_XIncomeAccAllocat()
        {
            return FA_XIncomeAccAllocatService.GetAllFA_XIncomeAccAllocat();
        }

        public static FA_XIncomeAccAllocat GetFA_XIncomeAccAllocatByIAAID(int iAAID)
        {
            return FA_XIncomeAccAllocatService.GetFA_XIncomeAccAllocatByIAAID(iAAID);
        }

    }
}
