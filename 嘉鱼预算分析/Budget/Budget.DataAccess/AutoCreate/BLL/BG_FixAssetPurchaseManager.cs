//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_FixAssetPurchaseManager
    {
        public static BG_FixAssetPurchase AddBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
        {
            return BG_FixAssetPurchaseService.AddBG_FixAssetPurchase(bG_FixAssetPurchase);
        }

        public static bool DeleteBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
        {
            return BG_FixAssetPurchaseService.DeleteBG_FixAssetPurchase(bG_FixAssetPurchase);
        }

        public static bool DeleteBG_FixAssetPurchaseByID(int fAID)
        {
            return BG_FixAssetPurchaseService.DeleteBG_FixAssetPurchaseByFAID(fAID);
        }

		public static bool ModifyBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
        {
            return BG_FixAssetPurchaseService.ModifyBG_FixAssetPurchase(bG_FixAssetPurchase);
        }
        
        public static DataTable GetAllBG_FixAssetPurchase()
        {
            return BG_FixAssetPurchaseService.GetAllBG_FixAssetPurchase();
        }

        public static BG_FixAssetPurchase GetBG_FixAssetPurchaseByFAID(int fAID)
        {
            return BG_FixAssetPurchaseService.GetBG_FixAssetPurchaseByFAID(fAID);
        }

    }
}
