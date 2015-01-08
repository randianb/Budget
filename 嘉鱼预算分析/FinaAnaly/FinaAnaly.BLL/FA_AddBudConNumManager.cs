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

    public static partial class FA_AddBudConNumManager
    {
        public static FA_AddBudConNum AddFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
        {
            return FA_AddBudConNumService.AddFA_AddBudConNum(fA_AddBudConNum);
        }

        public static bool DeleteFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
        {
            return FA_AddBudConNumService.DeleteFA_AddBudConNum(fA_AddBudConNum);
        }

        public static bool DeleteFA_AddBudConNumByID(int addID)
        {
            return FA_AddBudConNumService.DeleteFA_AddBudConNumByAddID(addID);
        }

		public static bool ModifyFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
        {
            return FA_AddBudConNumService.ModifyFA_AddBudConNum(fA_AddBudConNum);
        }
        
        public static DataTable GetAllFA_AddBudConNum()
        {
            return FA_AddBudConNumService.GetAllFA_AddBudConNum();
        }

        public static FA_AddBudConNum GetFA_AddBudConNumByAddID(int addID)
        {
            return FA_AddBudConNumService.GetFA_AddBudConNumByAddID(addID);
        }

    }
}
