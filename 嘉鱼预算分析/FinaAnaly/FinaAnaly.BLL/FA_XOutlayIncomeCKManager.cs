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

    public static partial class FA_XOutlayIncomeCKManager
    {
        public static FA_XOutlayIncomeCK AddFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
        {
            return FA_XOutlayIncomeCKService.AddFA_XOutlayIncomeCK(fA_XOutlayIncomeCK);
        }

        public static bool DeleteFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
        {
            return FA_XOutlayIncomeCKService.DeleteFA_XOutlayIncomeCK(fA_XOutlayIncomeCK);
        }

        public static bool DeleteFA_XOutlayIncomeCKByID(int oDID)
        {
            return FA_XOutlayIncomeCKService.DeleteFA_XOutlayIncomeCKByODID(oDID);
        }

		public static bool ModifyFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
        {
            return FA_XOutlayIncomeCKService.ModifyFA_XOutlayIncomeCK(fA_XOutlayIncomeCK);
        }
        
        public static DataTable GetAllFA_XOutlayIncomeCK()
        {
            return FA_XOutlayIncomeCKService.GetAllFA_XOutlayIncomeCK();
        }

        public static FA_XOutlayIncomeCK GetFA_XOutlayIncomeCKByODID(int oDID)
        {
            return FA_XOutlayIncomeCKService.GetFA_XOutlayIncomeCKByODID(oDID);
        }

    }
}
