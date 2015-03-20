//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/3/4 16:05:10
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_UserManager
    {
        public static BG_User AddBG_User(BG_User bG_User)
        {
            return BG_UserService.AddBG_User(bG_User);
        }

        public static bool DeleteBG_User(BG_User bG_User)
        {
            return BG_UserService.DeleteBG_User(bG_User);
        }

        public static bool DeleteBG_UserByID(int userID)
        {
            return BG_UserService.DeleteBG_UserByUserID(userID);
        }

		public static bool ModifyBG_User(BG_User bG_User)
        {
            return BG_UserService.ModifyBG_User(bG_User);
        }
        
        public static DataTable GetAllBG_User()
        {
            return BG_UserService.GetAllBG_User();
        }

        public static BG_User GetBG_UserByUserID(int userID)
        {
            return BG_UserService.GetBG_UserByUserID(userID);
        }

    }
}
