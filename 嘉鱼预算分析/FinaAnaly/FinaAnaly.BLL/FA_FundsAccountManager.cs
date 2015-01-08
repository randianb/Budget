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

    public static partial class FA_FundsAccountManager
    {
        public static FA_FundsAccount AddFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
        {
            return FA_FundsAccountService.AddFA_FundsAccount(fA_FundsAccount);
        }

        public static bool DeleteFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
        {
            return FA_FundsAccountService.DeleteFA_FundsAccount(fA_FundsAccount);
        }

        public static bool DeleteFA_FundsAccountByID(int fAID)
        {
            return FA_FundsAccountService.DeleteFA_FundsAccountByFAID(fAID);
        }

		public static bool ModifyFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
        {
            return FA_FundsAccountService.ModifyFA_FundsAccount(fA_FundsAccount);
        }
        
        public static DataTable GetAllFA_FundsAccount()
        {
            return FA_FundsAccountService.GetAllFA_FundsAccount();
        }

        public static FA_FundsAccount GetFA_FundsAccountByFAID(int fAID)
        {
            return FA_FundsAccountService.GetFA_FundsAccountByFAID(fAID);
        }

    }
}
