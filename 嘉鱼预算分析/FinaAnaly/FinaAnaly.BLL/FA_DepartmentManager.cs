//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{

    public static partial class FA_DepartmentManager
    {
        public static FA_Department AddFA_Department(FA_Department fA_Department)
        {
            return FA_DepartmentService.AddFA_Department(fA_Department);
        }

        public static bool DeleteFA_Department(FA_Department fA_Department)
        {
            return FA_DepartmentService.DeleteFA_Department(fA_Department);
        }

        public static bool DeleteFA_DepartmentByID(int depID)
        {
            return FA_DepartmentService.DeleteFA_DepartmentByDepID(depID);
        }

		public static bool ModifyFA_Department(FA_Department fA_Department)
        {
            return FA_DepartmentService.ModifyFA_Department(fA_Department);
        }
        
        public static DataTable GetAllFA_Department()
        {
            return FA_DepartmentService.GetAllFA_Department();
        }

        public static FA_Department GetFA_DepartmentByDepID(int depID)
        {
            return FA_DepartmentService.GetFA_DepartmentByDepID(depID);
        }

    }
}
