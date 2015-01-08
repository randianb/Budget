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

    public static partial class BG_ProPayManager
    {
        public static BG_ProPay AddBG_ProPay(BG_ProPay bG_ProPay)
        {
            return BG_ProPayService.AddBG_ProPay(bG_ProPay);
        }

        public static bool DeleteBG_ProPay(BG_ProPay bG_ProPay)
        {
            return BG_ProPayService.DeleteBG_ProPay(bG_ProPay);
        }

        public static bool DeleteBG_ProPayByID(int proPID)
        {
            return BG_ProPayService.DeleteBG_ProPayByProPID(proPID);
        }

		public static bool ModifyBG_ProPay(BG_ProPay bG_ProPay)
        {
            return BG_ProPayService.ModifyBG_ProPay(bG_ProPay);
        }
        
        public static DataTable GetAllBG_ProPay()
        {
            return BG_ProPayService.GetAllBG_ProPay();
        }

        public static BG_ProPay GetBG_ProPayByProPID(int proPID)
        {
            return BG_ProPayService.GetBG_ProPayByProPID(proPID);
        }

    }
}
