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

    public static partial class BG_SupplementaryManager
    {
        public static BG_Supplementary AddBG_Supplementary(BG_Supplementary bG_Supplementary)
        {
            return BG_SupplementaryService.AddBG_Supplementary(bG_Supplementary);
        }

        public static bool DeleteBG_Supplementary(BG_Supplementary bG_Supplementary)
        {
            return BG_SupplementaryService.DeleteBG_Supplementary(bG_Supplementary);
        }

        public static bool DeleteBG_SupplementaryByID(int suppID)
        {
            return BG_SupplementaryService.DeleteBG_SupplementaryBySuppID(suppID);
        }

		public static bool ModifyBG_Supplementary(BG_Supplementary bG_Supplementary)
        {
            return BG_SupplementaryService.ModifyBG_Supplementary(bG_Supplementary);
        }
        
        public static DataTable GetAllBG_Supplementary()
        {
            return BG_SupplementaryService.GetAllBG_Supplementary();
        }

        public static BG_Supplementary GetBG_SupplementaryBySuppID(int suppID)
        {
            return BG_SupplementaryService.GetBG_SupplementaryBySuppID(suppID);
        }

    }
}
