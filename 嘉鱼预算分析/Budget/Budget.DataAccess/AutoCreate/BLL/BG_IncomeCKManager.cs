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

    public static partial class BG_IncomeCKManager
    {
        public static BG_IncomeCK AddBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
        {
            return BG_IncomeCKService.AddBG_IncomeCK(bG_IncomeCK);
        }

        public static bool DeleteBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
        {
            return BG_IncomeCKService.DeleteBG_IncomeCK(bG_IncomeCK);
        }

        public static bool DeleteBG_IncomeCKByID(int iKID)
        {
            return BG_IncomeCKService.DeleteBG_IncomeCKByIKID(iKID);
        }

		public static bool ModifyBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
        {
            return BG_IncomeCKService.ModifyBG_IncomeCK(bG_IncomeCK);
        }
        
        public static DataTable GetAllBG_IncomeCK()
        {
            return BG_IncomeCKService.GetAllBG_IncomeCK();
        }

        public static BG_IncomeCK GetBG_IncomeCKByIKID(int iKID)
        {
            return BG_IncomeCKService.GetBG_IncomeCKByIKID(iKID);
        }

    }
}
