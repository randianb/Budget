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

    public static partial class FA_OutlayIncomeCKManager
    {
        public static FA_OutlayIncomeCK AddFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
        {
            return FA_OutlayIncomeCKService.AddFA_OutlayIncomeCK(fA_OutlayIncomeCK);
        }

        public static bool DeleteFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
        {
            return FA_OutlayIncomeCKService.DeleteFA_OutlayIncomeCK(fA_OutlayIncomeCK);
        }

        public static bool DeleteFA_OutlayIncomeCKByID(int oIID)
        {
            return FA_OutlayIncomeCKService.DeleteFA_OutlayIncomeCKByOIID(oIID);
        }

		public static bool ModifyFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
        {
            return FA_OutlayIncomeCKService.ModifyFA_OutlayIncomeCK(fA_OutlayIncomeCK);
        }
        
        public static DataTable GetAllFA_OutlayIncomeCK()
        {
            return FA_OutlayIncomeCKService.GetAllFA_OutlayIncomeCK();
        }

        public static FA_OutlayIncomeCK GetFA_OutlayIncomeCKByOIID(int oIID)
        {
            return FA_OutlayIncomeCKService.GetFA_OutlayIncomeCKByOIID(oIID);
        }

    }
}
