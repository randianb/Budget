//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:44
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_ChangePwdManager
    {
        public static BG_ChangePwd AddBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
        {
            return BG_ChangePwdService.AddBG_ChangePwd(bG_ChangePwd);
        }

        public static bool DeleteBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
        {
            return BG_ChangePwdService.DeleteBG_ChangePwd(bG_ChangePwd);
        }

        public static bool DeleteBG_ChangePwdByID(int pwdID)
        {
            return BG_ChangePwdService.DeleteBG_ChangePwdByPwdID(pwdID);
        }

		public static bool ModifyBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
        {
            return BG_ChangePwdService.ModifyBG_ChangePwd(bG_ChangePwd);
        }
        
        public static DataTable GetAllBG_ChangePwd()
        {
            return BG_ChangePwdService.GetAllBG_ChangePwd();
        }

        public static BG_ChangePwd GetBG_ChangePwdByPwdID(int pwdID)
        {
            return BG_ChangePwdService.GetBG_ChangePwdByPwdID(pwdID);
        }

    }
}
