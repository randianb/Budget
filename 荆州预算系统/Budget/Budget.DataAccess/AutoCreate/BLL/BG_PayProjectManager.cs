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

    public static partial class BG_PayProjectManager
    {
        public static BG_PayProject AddBG_PayProject(BG_PayProject bG_PayProject)
        {
            return BG_PayProjectService.AddBG_PayProject(bG_PayProject);
        }

        public static bool DeleteBG_PayProject(BG_PayProject bG_PayProject)
        {
            return BG_PayProjectService.DeleteBG_PayProject(bG_PayProject);
        }

        public static bool DeleteBG_PayProjectByID(int pPID)
        {
            return BG_PayProjectService.DeleteBG_PayProjectByPPID(pPID);
        }

		public static bool ModifyBG_PayProject(BG_PayProject bG_PayProject)
        {
            return BG_PayProjectService.ModifyBG_PayProject(bG_PayProject);
        }
        
        public static DataTable GetAllBG_PayProject()
        {
            return BG_PayProjectService.GetAllBG_PayProject();
        }

        public static BG_PayProject GetBG_PayProjectByPPID(int pPID)
        {
            return BG_PayProjectService.GetBG_PayProjectByPPID(pPID);
        }

    }
}
