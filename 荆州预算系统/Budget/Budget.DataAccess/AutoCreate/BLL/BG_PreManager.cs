//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:45
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_PreManager
    {
        public static BG_Pre AddBG_Pre(BG_Pre bG_Pre)
        {
            return BG_PreService.AddBG_Pre(bG_Pre);
        }

        public static bool DeleteBG_Pre(BG_Pre bG_Pre)
        {
            return BG_PreService.DeleteBG_Pre(bG_Pre);
        }

        public static bool DeleteBG_PreByID(int preID)
        {
            return BG_PreService.DeleteBG_PreByPreID(preID);
        }

		public static bool ModifyBG_Pre(BG_Pre bG_Pre)
        {
            return BG_PreService.ModifyBG_Pre(bG_Pre);
        }
        
        public static DataTable GetAllBG_Pre()
        {
            return BG_PreService.GetAllBG_Pre();
        }

        public static BG_Pre GetBG_PreByPreID(int preID)
        {
            return BG_PreService.GetBG_PreByPreID(preID);
        }

    }
}
