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

    public static partial class BG_CashierManager
    {
        public static BG_Cashier AddBG_Cashier(BG_Cashier bG_Cashier)
        {
            return BG_CashierService.AddBG_Cashier(bG_Cashier);
        }

        public static bool DeleteBG_Cashier(BG_Cashier bG_Cashier)
        {
            return BG_CashierService.DeleteBG_Cashier(bG_Cashier);
        }

        public static bool DeleteBG_CashierByID(int cashierid)
        {
            return BG_CashierService.DeleteBG_CashierByCashierid(cashierid);
        }

		public static bool ModifyBG_Cashier(BG_Cashier bG_Cashier)
        {
            return BG_CashierService.ModifyBG_Cashier(bG_Cashier);
        }
        
        public static DataTable GetAllBG_Cashier()
        {
            return BG_CashierService.GetAllBG_Cashier();
        }

        public static BG_Cashier GetBG_CashierByCashierid(int cashierid)
        {
            return BG_CashierService.GetBG_CashierByCashierid(cashierid);
        }

    }
}
