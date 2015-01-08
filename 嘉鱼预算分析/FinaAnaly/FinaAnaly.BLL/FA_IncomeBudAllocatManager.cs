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

    public static partial class FA_IncomeBudAllocatManager
    {
        public static FA_IncomeBudAllocat AddFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
        {
            return FA_IncomeBudAllocatService.AddFA_IncomeBudAllocat(fA_IncomeBudAllocat);
        }

        public static bool DeleteFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
        {
            return FA_IncomeBudAllocatService.DeleteFA_IncomeBudAllocat(fA_IncomeBudAllocat);
        }

        public static bool DeleteFA_IncomeBudAllocatByID(int iBAID)
        {
            return FA_IncomeBudAllocatService.DeleteFA_IncomeBudAllocatByIBAID(iBAID);
        }

		public static bool ModifyFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
        {
            return FA_IncomeBudAllocatService.ModifyFA_IncomeBudAllocat(fA_IncomeBudAllocat);
        }
        
        public static DataTable GetAllFA_IncomeBudAllocat()
        {
            return FA_IncomeBudAllocatService.GetAllFA_IncomeBudAllocat();
        }

        public static FA_IncomeBudAllocat GetFA_IncomeBudAllocatByIBAID(int iBAID)
        {
            return FA_IncomeBudAllocatService.GetFA_IncomeBudAllocatByIBAID(iBAID);
        }

    }
}
