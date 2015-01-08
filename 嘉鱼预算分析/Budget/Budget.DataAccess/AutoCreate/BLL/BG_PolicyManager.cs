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

    public static partial class BG_PolicyManager
    {
        public static BG_Policy AddBG_Policy(BG_Policy bG_Policy)
        {
            return BG_PolicyService.AddBG_Policy(bG_Policy);
        }

        public static bool DeleteBG_Policy(BG_Policy bG_Policy)
        {
            return BG_PolicyService.DeleteBG_Policy(bG_Policy);
        }

        public static bool DeleteBG_PolicyByID(int pLID)
        {
            return BG_PolicyService.DeleteBG_PolicyByPLID(pLID);
        }

		public static bool ModifyBG_Policy(BG_Policy bG_Policy)
        {
            return BG_PolicyService.ModifyBG_Policy(bG_Policy);
        }
        
        public static DataTable GetAllBG_Policy()
        {
            return BG_PolicyService.GetAllBG_Policy();
        }

        public static BG_Policy GetBG_PolicyByPLID(int pLID)
        {
            return BG_PolicyService.GetBG_PolicyByPLID(pLID);
        }

    }
}
