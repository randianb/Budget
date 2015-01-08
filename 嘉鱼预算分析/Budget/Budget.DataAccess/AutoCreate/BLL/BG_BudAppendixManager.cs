//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_BudAppendixManager
    {
        public static BG_BudAppendix AddBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
        {
            return BG_BudAppendixService.AddBG_BudAppendix(bG_BudAppendix);
        }

        public static bool DeleteBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
        {
            return BG_BudAppendixService.DeleteBG_BudAppendix(bG_BudAppendix);
        }

        public static bool DeleteBG_BudAppendixByID(int aPID)
        {
            return BG_BudAppendixService.DeleteBG_BudAppendixByAPID(aPID);
        }

		public static bool ModifyBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
        {
            return BG_BudAppendixService.ModifyBG_BudAppendix(bG_BudAppendix);
        }
        
        public static DataTable GetAllBG_BudAppendix()
        {
            return BG_BudAppendixService.GetAllBG_BudAppendix();
        }

        public static BG_BudAppendix GetBG_BudAppendixByAPID(int aPID)
        {
            return BG_BudAppendixService.GetBG_BudAppendixByAPID(aPID);
        }

    }
}
