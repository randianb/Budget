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

    public static partial class FA_UserManager
    {
        public static FA_User AddFA_User(FA_User fA_User)
        {
            return FA_UserService.AddFA_User(fA_User);
        }

        public static bool DeleteFA_User(FA_User fA_User)
        {
            return FA_UserService.DeleteFA_User(fA_User);
        }

        public static bool DeleteFA_UserByID(int userID)
        {
            return FA_UserService.DeleteFA_UserByUserID(userID);
        }

		public static bool ModifyFA_User(FA_User fA_User)
        {
            return FA_UserService.ModifyFA_User(fA_User);
        }
        
        public static DataTable GetAllFA_User()
        {
            return FA_UserService.GetAllFA_User();
        }

        public static FA_User GetFA_UserByUserID(int userID)
        {
            return FA_UserService.GetFA_UserByUserID(userID);
        }

    }
}
