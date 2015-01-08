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

    public static partial class BG_BudgetConManager
    {
        public static BG_BudgetCon AddBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
        {
            return BG_BudgetConService.AddBG_BudgetCon(bG_BudgetCon);
        }

        public static bool DeleteBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
        {
            return BG_BudgetConService.DeleteBG_BudgetCon(bG_BudgetCon);
        }

        public static bool DeleteBG_BudgetConByID(int pIID)
        {
            return BG_BudgetConService.DeleteBG_BudgetConByPIID(pIID);
        }

		public static bool ModifyBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
        {
            return BG_BudgetConService.ModifyBG_BudgetCon(bG_BudgetCon);
        }
        
        public static DataTable GetAllBG_BudgetCon()
        {
            return BG_BudgetConService.GetAllBG_BudgetCon();
        }

        public static BG_BudgetCon GetBG_BudgetConByPIID(int pIID)
        {
            return BG_BudgetConService.GetBG_BudgetConByPIID(pIID);
        }

    }
}
