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

    public static partial class FA_AccConNumManager
    {
        public static FA_AccConNum AddFA_AccConNum(FA_AccConNum fA_AccConNum)
        {
            return FA_AccConNumService.AddFA_AccConNum(fA_AccConNum);
        }

        public static bool DeleteFA_AccConNum(FA_AccConNum fA_AccConNum)
        {
            return FA_AccConNumService.DeleteFA_AccConNum(fA_AccConNum);
        }

        public static bool DeleteFA_AccConNumByID(int aCID)
        {
            return FA_AccConNumService.DeleteFA_AccConNumByACID(aCID);
        }

		public static bool ModifyFA_AccConNum(FA_AccConNum fA_AccConNum)
        {
            return FA_AccConNumService.ModifyFA_AccConNum(fA_AccConNum);
        }
        
        public static DataTable GetAllFA_AccConNum()
        {
            return FA_AccConNumService.GetAllFA_AccConNum();
        }

        public static FA_AccConNum GetFA_AccConNumByACID(int aCID)
        {
            return FA_AccConNumService.GetFA_AccConNumByACID(aCID);
        }

    }
}
