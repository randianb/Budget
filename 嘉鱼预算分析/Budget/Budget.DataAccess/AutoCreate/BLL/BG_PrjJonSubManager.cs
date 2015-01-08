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

    public static partial class BG_PrjJonSubManager
    {
        public static BG_PrjJonSub AddBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
        {
            return BG_PrjJonSubService.AddBG_PrjJonSub(bG_PrjJonSub);
        }

        public static bool DeleteBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
        {
            return BG_PrjJonSubService.DeleteBG_PrjJonSub(bG_PrjJonSub);
        }

        public static bool DeleteBG_PrjJonSubByID(int pSID)
        {
            return BG_PrjJonSubService.DeleteBG_PrjJonSubByPSID(pSID);
        }

		public static bool ModifyBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
        {
            return BG_PrjJonSubService.ModifyBG_PrjJonSub(bG_PrjJonSub);
        }
        
        public static DataTable GetAllBG_PrjJonSub()
        {
            return BG_PrjJonSubService.GetAllBG_PrjJonSub();
        }

        public static BG_PrjJonSub GetBG_PrjJonSubByPSID(int pSID)
        {
            return BG_PrjJonSubService.GetBG_PrjJonSubByPSID(pSID);
        }

    }
}
