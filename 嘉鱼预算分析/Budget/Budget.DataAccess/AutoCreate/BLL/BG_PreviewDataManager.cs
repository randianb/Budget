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

    public static partial class BG_PreviewDataManager
    {
        public static BG_PreviewData AddBG_PreviewData(BG_PreviewData bG_PreviewData)
        {
            return BG_PreviewDataService.AddBG_PreviewData(bG_PreviewData);
        }

        public static bool DeleteBG_PreviewData(BG_PreviewData bG_PreviewData)
        {
            return BG_PreviewDataService.DeleteBG_PreviewData(bG_PreviewData);
        }

        public static bool DeleteBG_PreviewDataByID(int pSID)
        {
            return BG_PreviewDataService.DeleteBG_PreviewDataByPSID(pSID);
        }

		public static bool ModifyBG_PreviewData(BG_PreviewData bG_PreviewData)
        {
            return BG_PreviewDataService.ModifyBG_PreviewData(bG_PreviewData);
        }
        
        public static DataTable GetAllBG_PreviewData()
        {
            return BG_PreviewDataService.GetAllBG_PreviewData();
        }

        public static BG_PreviewData GetBG_PreviewDataByPSID(int pSID)
        {
            return BG_PreviewDataService.GetBG_PreviewDataByPSID(pSID);
        }

    }
}
