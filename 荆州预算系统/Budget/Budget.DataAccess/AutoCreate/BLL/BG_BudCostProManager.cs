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

    public static partial class BG_BudCostProManager
    {
        public static BG_BudCostPro AddBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
        {
            return BG_BudCostProService.AddBG_BudCostPro(bG_BudCostPro);
        }

        public static bool DeleteBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
        {
            return BG_BudCostProService.DeleteBG_BudCostPro(bG_BudCostPro);
        }

        public static bool DeleteBG_BudCostProByID(int costID)
        {
            return BG_BudCostProService.DeleteBG_BudCostProByCostID(costID);
        }

		public static bool ModifyBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
        {
            return BG_BudCostProService.ModifyBG_BudCostPro(bG_BudCostPro);
        }
        
        public static DataTable GetAllBG_BudCostPro()
        {
            return BG_BudCostProService.GetAllBG_BudCostPro();
        }

        public static BG_BudCostPro GetBG_BudCostProByCostID(int costID)
        {
            return BG_BudCostProService.GetBG_BudCostProByCostID(costID);
        }

    }
}
