//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-4 10:04:32
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{

    public static partial class FA_OutLayGatherManager
    {
        public static FA_OutLayGather AddFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
        {
            return FA_OutLayGatherService.AddFA_OutLayGather(fA_OutLayGather);
        }

        public static bool DeleteFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
        {
            return FA_OutLayGatherService.DeleteFA_OutLayGather(fA_OutLayGather);
        }

        public static bool DeleteFA_OutLayGatherByID(int oGID)
        {
            return FA_OutLayGatherService.DeleteFA_OutLayGatherByOGID(oGID);
        }

		public static bool ModifyFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
        {
            return FA_OutLayGatherService.ModifyFA_OutLayGather(fA_OutLayGather);
        }
        
        public static DataTable GetAllFA_OutLayGather()
        {
            return FA_OutLayGatherService.GetAllFA_OutLayGather();
        }

        public static FA_OutLayGather GetFA_OutLayGatherByOGID(int oGID)
        {
            return FA_OutLayGatherService.GetFA_OutLayGatherByOGID(oGID);
        }

    }
}
