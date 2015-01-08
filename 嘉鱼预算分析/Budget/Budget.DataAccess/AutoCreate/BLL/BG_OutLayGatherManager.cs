//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:04
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_OutLayGatherManager
    {
        public static BG_OutLayGather AddBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
        {
            return BG_OutLayGatherService.AddBG_OutLayGather(bG_OutLayGather);
        }

        public static bool DeleteBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
        {
            return BG_OutLayGatherService.DeleteBG_OutLayGather(bG_OutLayGather);
        }

        public static bool DeleteBG_OutLayGatherByID(int oGID)
        {
            return BG_OutLayGatherService.DeleteBG_OutLayGatherByOGID(oGID);
        }

		public static bool ModifyBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
        {
            return BG_OutLayGatherService.ModifyBG_OutLayGather(bG_OutLayGather);
        }
        
        public static DataTable GetAllBG_OutLayGather()
        {
            return BG_OutLayGatherService.GetAllBG_OutLayGather();
        }

        public static BG_OutLayGather GetBG_OutLayGatherByOGID(int oGID)
        {
            return BG_OutLayGatherService.GetBG_OutLayGatherByOGID(oGID);
        }

    }
}
