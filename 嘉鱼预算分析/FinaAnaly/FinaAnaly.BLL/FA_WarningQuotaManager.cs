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

    public static partial class FA_WarningQuotaManager
    {
        public static FA_WarningQuota AddFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
        {
            return FA_WarningQuotaService.AddFA_WarningQuota(fA_WarningQuota);
        }

        public static bool DeleteFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
        {
            return FA_WarningQuotaService.DeleteFA_WarningQuota(fA_WarningQuota);
        }

        public static bool DeleteFA_WarningQuotaByID(int wQID)
        {
            return FA_WarningQuotaService.DeleteFA_WarningQuotaByWQID(wQID);
        }

		public static bool ModifyFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
        {
            return FA_WarningQuotaService.ModifyFA_WarningQuota(fA_WarningQuota);
        }
        
        public static DataTable GetAllFA_WarningQuota()
        {
            return FA_WarningQuotaService.GetAllFA_WarningQuota();
        }

        public static FA_WarningQuota GetFA_WarningQuotaByWQID(int wQID)
        {
            return FA_WarningQuotaService.GetFA_WarningQuotaByWQID(wQID);
        }

    }
}
