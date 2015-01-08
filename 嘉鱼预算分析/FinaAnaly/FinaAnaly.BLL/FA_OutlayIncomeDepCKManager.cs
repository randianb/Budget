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

    public static partial class FA_OutlayIncomeDepCKManager
    {
        public static FA_OutlayIncomeDepCK AddFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
        {
            return FA_OutlayIncomeDepCKService.AddFA_OutlayIncomeDepCK(fA_OutlayIncomeDepCK);
        }

        public static bool DeleteFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
        {
            return FA_OutlayIncomeDepCKService.DeleteFA_OutlayIncomeDepCK(fA_OutlayIncomeDepCK);
        }

        public static bool DeleteFA_OutlayIncomeDepCKByID(int oDID)
        {
            return FA_OutlayIncomeDepCKService.DeleteFA_OutlayIncomeDepCKByODID(oDID);
        }

		public static bool ModifyFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
        {
            return FA_OutlayIncomeDepCKService.ModifyFA_OutlayIncomeDepCK(fA_OutlayIncomeDepCK);
        }
        
        public static DataTable GetAllFA_OutlayIncomeDepCK()
        {
            return FA_OutlayIncomeDepCKService.GetAllFA_OutlayIncomeDepCK();
        }

        public static FA_OutlayIncomeDepCK GetFA_OutlayIncomeDepCKByODID(int oDID)
        {
            return FA_OutlayIncomeDepCKService.GetFA_OutlayIncomeDepCKByODID(oDID);
        }

    }
}
