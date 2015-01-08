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

    public static partial class BG_BudgetConCellManager
    {
        public static BG_BudgetConCell AddBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
        {
            return BG_BudgetConCellService.AddBG_BudgetConCell(bG_BudgetConCell);
        }

        public static bool DeleteBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
        {
            return BG_BudgetConCellService.DeleteBG_BudgetConCell(bG_BudgetConCell);
        }

        public static bool DeleteBG_BudgetConCellByID(int bCCID)
        {
            return BG_BudgetConCellService.DeleteBG_BudgetConCellByBCCID(bCCID);
        }

		public static bool ModifyBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
        {
            return BG_BudgetConCellService.ModifyBG_BudgetConCell(bG_BudgetConCell);
        }
        
        public static DataTable GetAllBG_BudgetConCell()
        {
            return BG_BudgetConCellService.GetAllBG_BudgetConCell();
        }

        public static BG_BudgetConCell GetBG_BudgetConCellByBCCID(int bCCID)
        {
            return BG_BudgetConCellService.GetBG_BudgetConCellByBCCID(bCCID);
        }

    }
}
