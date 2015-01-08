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

    public static partial class FA_OutlayDepCKManager
    {
        public static FA_OutlayDepCK AddFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
        {
            return FA_OutlayDepCKService.AddFA_OutlayDepCK(fA_OutlayDepCK);
        }

        public static bool DeleteFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
        {
            return FA_OutlayDepCKService.DeleteFA_OutlayDepCK(fA_OutlayDepCK);
        }

        public static bool DeleteFA_OutlayDepCKByID(int oDID)
        {
            return FA_OutlayDepCKService.DeleteFA_OutlayDepCKByODID(oDID);
        }

		public static bool ModifyFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
        {
            return FA_OutlayDepCKService.ModifyFA_OutlayDepCK(fA_OutlayDepCK);
        }
        
        public static DataTable GetAllFA_OutlayDepCK()
        {
            return FA_OutlayDepCKService.GetAllFA_OutlayDepCK();
        }

        public static FA_OutlayDepCK GetFA_OutlayDepCKByODID(int oDID)
        {
            return FA_OutlayDepCKService.GetFA_OutlayDepCKByODID(oDID);
        }

    }
}
