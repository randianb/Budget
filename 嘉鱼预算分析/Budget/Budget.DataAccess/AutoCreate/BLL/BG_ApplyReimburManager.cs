//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/22 11:04:10
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_ApplyReimburManager
    {
        public static BG_ApplyReimbur AddBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
        {
            return BG_ApplyReimburService.AddBG_ApplyReimbur(bG_ApplyReimbur);
        }

        public static bool DeleteBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
        {
            return BG_ApplyReimburService.DeleteBG_ApplyReimbur(bG_ApplyReimbur);
        }

        public static bool DeleteBG_ApplyReimburByID(int aRID)
        {
            return BG_ApplyReimburService.DeleteBG_ApplyReimburByARID(aRID);
        }

		public static bool ModifyBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
        {
            return BG_ApplyReimburService.ModifyBG_ApplyReimbur(bG_ApplyReimbur);
        }
        
        public static DataTable GetAllBG_ApplyReimbur()
        {
            return BG_ApplyReimburService.GetAllBG_ApplyReimbur();
        }

        public static BG_ApplyReimbur GetBG_ApplyReimburByARID(int aRID)
        {
            return BG_ApplyReimburService.GetBG_ApplyReimburByARID(aRID);
        }

    }
}
