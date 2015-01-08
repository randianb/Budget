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

    public static partial class FA_XIncomeBudAllocatManager
    {
        public static FA_XIncomeBudAllocat AddFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
        {
            return FA_XIncomeBudAllocatService.AddFA_XIncomeBudAllocat(fA_XIncomeBudAllocat);
        }

        public static bool DeleteFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
        {
            return FA_XIncomeBudAllocatService.DeleteFA_XIncomeBudAllocat(fA_XIncomeBudAllocat);
        }

        public static bool DeleteFA_XIncomeBudAllocatByID(int iBAID)
        {
            return FA_XIncomeBudAllocatService.DeleteFA_XIncomeBudAllocatByIBAID(iBAID);
        }

		public static bool ModifyFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
        {
            return FA_XIncomeBudAllocatService.ModifyFA_XIncomeBudAllocat(fA_XIncomeBudAllocat);
        }
        
        public static DataTable GetAllFA_XIncomeBudAllocat()
        {
            return FA_XIncomeBudAllocatService.GetAllFA_XIncomeBudAllocat();
        }

        public static FA_XIncomeBudAllocat GetFA_XIncomeBudAllocatByIBAID(int iBAID)
        {
            return FA_XIncomeBudAllocatService.GetFA_XIncomeBudAllocatByIBAID(iBAID);
        }

    }
}
