//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:44
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_IncomeGatherManager
    {
        public static BG_IncomeGather AddBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
        {
            return BG_IncomeGatherService.AddBG_IncomeGather(bG_IncomeGather);
        }

        public static bool DeleteBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
        {
            return BG_IncomeGatherService.DeleteBG_IncomeGather(bG_IncomeGather);
        }

        public static bool DeleteBG_IncomeGatherByID(int iGID)
        {
            return BG_IncomeGatherService.DeleteBG_IncomeGatherByIGID(iGID);
        }

		public static bool ModifyBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
        {
            return BG_IncomeGatherService.ModifyBG_IncomeGather(bG_IncomeGather);
        }
        
        public static DataTable GetAllBG_IncomeGather()
        {
            return BG_IncomeGatherService.GetAllBG_IncomeGather();
        }

        public static BG_IncomeGather GetBG_IncomeGatherByIGID(int iGID)
        {
            return BG_IncomeGatherService.GetBG_IncomeGatherByIGID(iGID);
        }

    }
}
