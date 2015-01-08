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

    public static partial class BG_OutlayAnaManager
    {
        public static BG_OutlayAna AddBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
        {
            return BG_OutlayAnaService.AddBG_OutlayAna(bG_OutlayAna);
        }

        public static bool DeleteBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
        {
            return BG_OutlayAnaService.DeleteBG_OutlayAna(bG_OutlayAna);
        }

        public static bool DeleteBG_OutlayAnaByID(int oAID)
        {
            return BG_OutlayAnaService.DeleteBG_OutlayAnaByOAID(oAID);
        }

		public static bool ModifyBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
        {
            return BG_OutlayAnaService.ModifyBG_OutlayAna(bG_OutlayAna);
        }
        
        public static DataTable GetAllBG_OutlayAna()
        {
            return BG_OutlayAnaService.GetAllBG_OutlayAna();
        }

        public static BG_OutlayAna GetBG_OutlayAnaByOAID(int oAID)
        {
            return BG_OutlayAnaService.GetBG_OutlayAnaByOAID(oAID);
        }

    }
}
