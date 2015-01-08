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

    public static partial class BG_IncomeCPayManager
    {
        public static BG_IncomeCPay AddBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
        {
            return BG_IncomeCPayService.AddBG_IncomeCPay(bG_IncomeCPay);
        }

        public static bool DeleteBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
        {
            return BG_IncomeCPayService.DeleteBG_IncomeCPay(bG_IncomeCPay);
        }

        public static bool DeleteBG_IncomeCPayByID(int iCPID)
        {
            return BG_IncomeCPayService.DeleteBG_IncomeCPayByICPID(iCPID);
        }

		public static bool ModifyBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
        {
            return BG_IncomeCPayService.ModifyBG_IncomeCPay(bG_IncomeCPay);
        }
        
        public static DataTable GetAllBG_IncomeCPay()
        {
            return BG_IncomeCPayService.GetAllBG_IncomeCPay();
        }

        public static BG_IncomeCPay GetBG_IncomeCPayByICPID(int iCPID)
        {
            return BG_IncomeCPayService.GetBG_IncomeCPayByICPID(iCPID);
        }

    }
}
