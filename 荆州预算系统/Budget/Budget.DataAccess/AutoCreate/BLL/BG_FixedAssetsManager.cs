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

    public static partial class BG_FixedAssetsManager
    {
        public static BG_FixedAssets AddBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
        {
            return BG_FixedAssetsService.AddBG_FixedAssets(bG_FixedAssets);
        }

        public static bool DeleteBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
        {
            return BG_FixedAssetsService.DeleteBG_FixedAssets(bG_FixedAssets);
        }

        public static bool DeleteBG_FixedAssetsByID(int fAID)
        {
            return BG_FixedAssetsService.DeleteBG_FixedAssetsByFAID(fAID);
        }

		public static bool ModifyBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
        {
            return BG_FixedAssetsService.ModifyBG_FixedAssets(bG_FixedAssets);
        }
        
        public static DataTable GetAllBG_FixedAssets()
        {
            return BG_FixedAssetsService.GetAllBG_FixedAssets();
        }

        public static BG_FixedAssets GetBG_FixedAssetsByFAID(int fAID)
        {
            return BG_FixedAssetsService.GetBG_FixedAssetsByFAID(fAID);
        }

    }
}
