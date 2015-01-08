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

    public static partial class BG_ProBasiPubPayManager
    {
        public static BG_ProBasiPubPay AddBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
        {
            return BG_ProBasiPubPayService.AddBG_ProBasiPubPay(bG_ProBasiPubPay);
        }

        public static bool DeleteBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
        {
            return BG_ProBasiPubPayService.DeleteBG_ProBasiPubPay(bG_ProBasiPubPay);
        }

        public static bool DeleteBG_ProBasiPubPayByID(int pBID)
        {
            return BG_ProBasiPubPayService.DeleteBG_ProBasiPubPayByPBID(pBID);
        }

		public static bool ModifyBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
        {
            return BG_ProBasiPubPayService.ModifyBG_ProBasiPubPay(bG_ProBasiPubPay);
        }
        
        public static DataTable GetAllBG_ProBasiPubPay()
        {
            return BG_ProBasiPubPayService.GetAllBG_ProBasiPubPay();
        }

        public static BG_ProBasiPubPay GetBG_ProBasiPubPayByPBID(int pBID)
        {
            return BG_ProBasiPubPayService.GetBG_ProBasiPubPayByPBID(pBID);
        }

    }
}
