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

    public static partial class FA_DepBudAllocatManager
    {
        public static FA_DepBudAllocat AddFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
        {
            return FA_DepBudAllocatService.AddFA_DepBudAllocat(fA_DepBudAllocat);
        }

        public static bool DeleteFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
        {
            return FA_DepBudAllocatService.DeleteFA_DepBudAllocat(fA_DepBudAllocat);
        }

        public static bool DeleteFA_DepBudAllocatByID(int dBAID)
        {
            return FA_DepBudAllocatService.DeleteFA_DepBudAllocatByDBAID(dBAID);
        }

		public static bool ModifyFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
        {
            return FA_DepBudAllocatService.ModifyFA_DepBudAllocat(fA_DepBudAllocat);
        }
        
        public static DataTable GetAllFA_DepBudAllocat()
        {
            return FA_DepBudAllocatService.GetAllFA_DepBudAllocat();
        }

        public static FA_DepBudAllocat GetFA_DepBudAllocatByDBAID(int dBAID)
        {
            return FA_DepBudAllocatService.GetFA_DepBudAllocatByDBAID(dBAID);
        }

    }
}
