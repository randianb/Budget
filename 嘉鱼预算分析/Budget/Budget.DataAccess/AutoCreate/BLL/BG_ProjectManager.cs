//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/21 16:13:06
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_ProjectManager
    {
        public static BG_Project AddBG_Project(BG_Project bG_Project)
        {
            return BG_ProjectService.AddBG_Project(bG_Project);
        }

        public static bool DeleteBG_Project(BG_Project bG_Project)
        {
            return BG_ProjectService.DeleteBG_Project(bG_Project);
        }

        public static bool DeleteBG_ProjectByID(int pJID)
        {
            return BG_ProjectService.DeleteBG_ProjectByPJID(pJID);
        }

		public static bool ModifyBG_Project(BG_Project bG_Project)
        {
            return BG_ProjectService.ModifyBG_Project(bG_Project);
        }
        
        public static DataTable GetAllBG_Project()
        {
            return BG_ProjectService.GetAllBG_Project();
        }

        public static BG_Project GetBG_ProjectByPJID(int pJID)
        {
            return BG_ProjectService.GetBG_ProjectByPJID(pJID);
        }

    }
}
