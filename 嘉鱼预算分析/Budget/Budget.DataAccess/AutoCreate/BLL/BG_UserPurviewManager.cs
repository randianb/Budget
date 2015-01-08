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

    public static partial class BG_UserPurviewManager
    {
        public static BG_UserPurview AddBG_UserPurview(BG_UserPurview bG_UserPurview)
        {
            return BG_UserPurviewService.AddBG_UserPurview(bG_UserPurview);
        }

        public static bool DeleteBG_UserPurview(BG_UserPurview bG_UserPurview)
        {
            return BG_UserPurviewService.DeleteBG_UserPurview(bG_UserPurview);
        }

        public static bool DeleteBG_UserPurviewByID(int uPID)
        {
            return BG_UserPurviewService.DeleteBG_UserPurviewByUPID(uPID);
        }

		public static bool ModifyBG_UserPurview(BG_UserPurview bG_UserPurview)
        {
            return BG_UserPurviewService.ModifyBG_UserPurview(bG_UserPurview);
        }
        
        public static DataTable GetAllBG_UserPurview()
        {
            return BG_UserPurviewService.GetAllBG_UserPurview();
        }

        public static BG_UserPurview GetBG_UserPurviewByUPID(int uPID)
        {
            return BG_UserPurviewService.GetBG_UserPurviewByUPID(uPID);
        }

    }
}
