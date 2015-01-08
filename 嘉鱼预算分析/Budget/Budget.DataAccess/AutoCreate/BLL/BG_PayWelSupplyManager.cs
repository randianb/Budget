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

    public static partial class BG_PayWelSupplyManager
    {
        public static BG_PayWelSupply AddBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
        {
            return BG_PayWelSupplyService.AddBG_PayWelSupply(bG_PayWelSupply);
        }

        public static bool DeleteBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
        {
            return BG_PayWelSupplyService.DeleteBG_PayWelSupply(bG_PayWelSupply);
        }

        public static bool DeleteBG_PayWelSupplyByID(int gSEID)
        {
            return BG_PayWelSupplyService.DeleteBG_PayWelSupplyByGSEID(gSEID);
        }

		public static bool ModifyBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
        {
            return BG_PayWelSupplyService.ModifyBG_PayWelSupply(bG_PayWelSupply);
        }
        
        public static DataTable GetAllBG_PayWelSupply()
        {
            return BG_PayWelSupplyService.GetAllBG_PayWelSupply();
        }

        public static BG_PayWelSupply GetBG_PayWelSupplyByGSEID(int gSEID)
        {
            return BG_PayWelSupplyService.GetBG_PayWelSupplyByGSEID(gSEID);
        }

    }
}
