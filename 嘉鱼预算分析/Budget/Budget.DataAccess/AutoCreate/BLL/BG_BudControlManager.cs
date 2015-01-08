//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_BudControlManager
    {
        public static BG_BudControl AddBG_BudControl(BG_BudControl bG_BudControl)
        {
            return BG_BudControlService.AddBG_BudControl(bG_BudControl);
        }

        public static bool DeleteBG_BudControl(BG_BudControl bG_BudControl)
        {
            return BG_BudControlService.DeleteBG_BudControl(bG_BudControl);
        }

        public static bool DeleteBG_BudControlByID(int bCID)
        {
            return BG_BudControlService.DeleteBG_BudControlByBCID(bCID);
        }

		public static bool ModifyBG_BudControl(BG_BudControl bG_BudControl)
        {
            return BG_BudControlService.ModifyBG_BudControl(bG_BudControl);
        }
        
        public static DataTable GetAllBG_BudControl()
        {
            return BG_BudControlService.GetAllBG_BudControl();
        }

        public static BG_BudControl GetBG_BudControlByBCID(int bCID)
        {
            return BG_BudControlService.GetBG_BudControlByBCID(bCID);
        }

    }
}
