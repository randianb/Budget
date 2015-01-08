//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:45
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_ReimAppendixManager
    {
        public static BG_ReimAppendix AddBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
        {
            return BG_ReimAppendixService.AddBG_ReimAppendix(bG_ReimAppendix);
        }

        public static bool DeleteBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
        {
            return BG_ReimAppendixService.DeleteBG_ReimAppendix(bG_ReimAppendix);
        }

        public static bool DeleteBG_ReimAppendixByID(int rADID)
        {
            return BG_ReimAppendixService.DeleteBG_ReimAppendixByRADID(rADID);
        }

		public static bool ModifyBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
        {
            return BG_ReimAppendixService.ModifyBG_ReimAppendix(bG_ReimAppendix);
        }
        
        public static DataTable GetAllBG_ReimAppendix()
        {
            return BG_ReimAppendixService.GetAllBG_ReimAppendix();
        }

        public static BG_ReimAppendix GetBG_ReimAppendixByRADID(int rADID)
        {
            return BG_ReimAppendixService.GetBG_ReimAppendixByRADID(rADID);
        }

    }
}
