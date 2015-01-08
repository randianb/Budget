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

    public static partial class BG_ProBasiPerPayTwoManager
    {
        public static BG_ProBasiPerPayTwo AddBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
        {
            return BG_ProBasiPerPayTwoService.AddBG_ProBasiPerPayTwo(bG_ProBasiPerPayTwo);
        }

        public static bool DeleteBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
        {
            return BG_ProBasiPerPayTwoService.DeleteBG_ProBasiPerPayTwo(bG_ProBasiPerPayTwo);
        }

        public static bool DeleteBG_ProBasiPerPayTwoByID(int pTID)
        {
            return BG_ProBasiPerPayTwoService.DeleteBG_ProBasiPerPayTwoByPTID(pTID);
        }

		public static bool ModifyBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
        {
            return BG_ProBasiPerPayTwoService.ModifyBG_ProBasiPerPayTwo(bG_ProBasiPerPayTwo);
        }
        
        public static DataTable GetAllBG_ProBasiPerPayTwo()
        {
            return BG_ProBasiPerPayTwoService.GetAllBG_ProBasiPerPayTwo();
        }

        public static BG_ProBasiPerPayTwo GetBG_ProBasiPerPayTwoByPTID(int pTID)
        {
            return BG_ProBasiPerPayTwoService.GetBG_ProBasiPerPayTwoByPTID(pTID);
        }

    }
}
