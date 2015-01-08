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

    public static partial class FA_PUCIssNumManager
    {
        public static FA_PUCIssNum AddFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
        {
            return FA_PUCIssNumService.AddFA_PUCIssNum(fA_PUCIssNum);
        }

        public static bool DeleteFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
        {
            return FA_PUCIssNumService.DeleteFA_PUCIssNum(fA_PUCIssNum);
        }

        public static bool DeleteFA_PUCIssNumByID(int pUCID)
        {
            return FA_PUCIssNumService.DeleteFA_PUCIssNumByPUCID(pUCID);
        }

		public static bool ModifyFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
        {
            return FA_PUCIssNumService.ModifyFA_PUCIssNum(fA_PUCIssNum);
        }
        
        public static DataTable GetAllFA_PUCIssNum()
        {
            return FA_PUCIssNumService.GetAllFA_PUCIssNum();
        }

        public static FA_PUCIssNum GetFA_PUCIssNumByPUCID(int pUCID)
        {
            return FA_PUCIssNumService.GetFA_PUCIssNumByPUCID(pUCID);
        }

    }
}
