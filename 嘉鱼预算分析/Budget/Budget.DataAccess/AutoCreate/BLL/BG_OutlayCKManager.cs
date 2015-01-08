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

    public static partial class BG_OutlayCKManager
    {
        public static BG_OutlayCK AddBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
        {
            return BG_OutlayCKService.AddBG_OutlayCK(bG_OutlayCK);
        }

        public static bool DeleteBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
        {
            return BG_OutlayCKService.DeleteBG_OutlayCK(bG_OutlayCK);
        }

        public static bool DeleteBG_OutlayCKByID(int oAID)
        {
            return BG_OutlayCKService.DeleteBG_OutlayCKByOAID(oAID);
        }

		public static bool ModifyBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
        {
            return BG_OutlayCKService.ModifyBG_OutlayCK(bG_OutlayCK);
        }
        
        public static DataTable GetAllBG_OutlayCK()
        {
            return BG_OutlayCKService.GetAllBG_OutlayCK();
        }

        public static BG_OutlayCK GetBG_OutlayCKByOAID(int oAID)
        {
            return BG_OutlayCKService.GetBG_OutlayCKByOAID(oAID);
        }

    }
}
