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

    public static partial class FA_BudConNumManager
    {
        public static FA_BudConNum AddFA_BudConNum(FA_BudConNum fA_BudConNum)
        {
            return FA_BudConNumService.AddFA_BudConNum(fA_BudConNum);
        }

        public static bool DeleteFA_BudConNum(FA_BudConNum fA_BudConNum)
        {
            return FA_BudConNumService.DeleteFA_BudConNum(fA_BudConNum);
        }

        public static bool DeleteFA_BudConNumByID(int bCID)
        {
            return FA_BudConNumService.DeleteFA_BudConNumByBCID(bCID);
        }

		public static bool ModifyFA_BudConNum(FA_BudConNum fA_BudConNum)
        {
            return FA_BudConNumService.ModifyFA_BudConNum(fA_BudConNum);
        }
        
        public static DataTable GetAllFA_BudConNum()
        {
            return FA_BudConNumService.GetAllFA_BudConNum();
        }

        public static FA_BudConNum GetFA_BudConNumByBCID(int bCID)
        {
            return FA_BudConNumService.GetFA_BudConNumByBCID(bCID);
        }

    }
}
