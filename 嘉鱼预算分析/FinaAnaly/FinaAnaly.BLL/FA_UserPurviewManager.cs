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

    public static partial class FA_UserPurviewManager
    {
        public static FA_UserPurview AddFA_UserPurview(FA_UserPurview fA_UserPurview)
        {
            return FA_UserPurviewService.AddFA_UserPurview(fA_UserPurview);
        }

        public static bool DeleteFA_UserPurview(FA_UserPurview fA_UserPurview)
        {
            return FA_UserPurviewService.DeleteFA_UserPurview(fA_UserPurview);
        }

        public static bool DeleteFA_UserPurviewByID(int uPID)
        {
            return FA_UserPurviewService.DeleteFA_UserPurviewByUPID(uPID);
        }

		public static bool ModifyFA_UserPurview(FA_UserPurview fA_UserPurview)
        {
            return FA_UserPurviewService.ModifyFA_UserPurview(fA_UserPurview);
        }
        
        public static DataTable GetAllFA_UserPurview()
        {
            return FA_UserPurviewService.GetAllFA_UserPurview();
        }

        public static FA_UserPurview GetFA_UserPurviewByUPID(int uPID)
        {
            return FA_UserPurviewService.GetFA_UserPurviewByUPID(uPID);
        }

    }
}
