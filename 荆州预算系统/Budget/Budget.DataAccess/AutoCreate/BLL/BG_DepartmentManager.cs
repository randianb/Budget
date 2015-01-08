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

    public static partial class BG_DepartmentManager
    {
        public static BG_Department AddBG_Department(BG_Department bG_Department)
        {
            return BG_DepartmentService.AddBG_Department(bG_Department);
        }

        public static bool DeleteBG_Department(BG_Department bG_Department)
        {
            return BG_DepartmentService.DeleteBG_Department(bG_Department);
        }

        public static bool DeleteBG_DepartmentByID(int depID)
        {
            return BG_DepartmentService.DeleteBG_DepartmentByDepID(depID);
        }

		public static bool ModifyBG_Department(BG_Department bG_Department)
        {
            return BG_DepartmentService.ModifyBG_Department(bG_Department);
        }
        
        public static DataTable GetAllBG_Department()
        {
            return BG_DepartmentService.GetAllBG_Department();
        }

        public static BG_Department GetBG_DepartmentByDepID(int depID)
        {
            return BG_DepartmentService.GetBG_DepartmentByDepID(depID);
        }

    }
}
