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

    public static partial class FA_FundsAccountUDetailManager
    {
        public static FA_FundsAccountUDetail AddFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
        {
            return FA_FundsAccountUDetailService.AddFA_FundsAccountUDetail(fA_FundsAccountUDetail);
        }

        public static bool DeleteFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
        {
            return FA_FundsAccountUDetailService.DeleteFA_FundsAccountUDetail(fA_FundsAccountUDetail);
        }

        public static bool DeleteFA_FundsAccountUDetailByID(int fAUDID)
        {
            return FA_FundsAccountUDetailService.DeleteFA_FundsAccountUDetailByFAUDID(fAUDID);
        }

		public static bool ModifyFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
        {
            return FA_FundsAccountUDetailService.ModifyFA_FundsAccountUDetail(fA_FundsAccountUDetail);
        }
        
        public static DataTable GetAllFA_FundsAccountUDetail()
        {
            return FA_FundsAccountUDetailService.GetAllFA_FundsAccountUDetail();
        }

        public static FA_FundsAccountUDetail GetFA_FundsAccountUDetailByFAUDID(int fAUDID)
        {
            return FA_FundsAccountUDetailService.GetFA_FundsAccountUDetailByFAUDID(fAUDID);
        }

    }
}
