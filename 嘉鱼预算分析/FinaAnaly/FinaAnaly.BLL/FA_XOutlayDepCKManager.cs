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

    public static partial class FA_XOutlayDepCKManager
    {
        public static FA_XOutlayDepCK AddFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
        {
            return FA_XOutlayDepCKService.AddFA_XOutlayDepCK(fA_XOutlayDepCK);
        }

        public static bool DeleteFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
        {
            return FA_XOutlayDepCKService.DeleteFA_XOutlayDepCK(fA_XOutlayDepCK);
        }

        public static bool DeleteFA_XOutlayDepCKByID(int oDID)
        {
            return FA_XOutlayDepCKService.DeleteFA_XOutlayDepCKByODID(oDID);
        }

		public static bool ModifyFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
        {
            return FA_XOutlayDepCKService.ModifyFA_XOutlayDepCK(fA_XOutlayDepCK);
        }
        
        public static DataTable GetAllFA_XOutlayDepCK()
        {
            return FA_XOutlayDepCKService.GetAllFA_XOutlayDepCK();
        }

        public static FA_XOutlayDepCK GetFA_XOutlayDepCKByODID(int oDID)
        {
            return FA_XOutlayDepCKService.GetFA_XOutlayDepCKByODID(oDID);
        }

    }
}
