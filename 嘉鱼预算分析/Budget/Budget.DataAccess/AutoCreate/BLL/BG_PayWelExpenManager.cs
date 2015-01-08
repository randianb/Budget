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

    public static partial class BG_PayWelExpenManager
    {
        public static BG_PayWelExpen AddBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
        {
            return BG_PayWelExpenService.AddBG_PayWelExpen(bG_PayWelExpen);
        }

        public static bool DeleteBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
        {
            return BG_PayWelExpenService.DeleteBG_PayWelExpen(bG_PayWelExpen);
        }

        public static bool DeleteBG_PayWelExpenByID(int pWEID)
        {
            return BG_PayWelExpenService.DeleteBG_PayWelExpenByPWEID(pWEID);
        }

		public static bool ModifyBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
        {
            return BG_PayWelExpenService.ModifyBG_PayWelExpen(bG_PayWelExpen);
        }
        
        public static DataTable GetAllBG_PayWelExpen()
        {
            return BG_PayWelExpenService.GetAllBG_PayWelExpen();
        }

        public static BG_PayWelExpen GetBG_PayWelExpenByPWEID(int pWEID)
        {
            return BG_PayWelExpenService.GetBG_PayWelExpenByPWEID(pWEID);
        }

    }
}
