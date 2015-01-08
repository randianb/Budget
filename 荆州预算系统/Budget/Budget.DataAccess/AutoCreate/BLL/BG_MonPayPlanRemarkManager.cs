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

    public static partial class BG_MonPayPlanRemarkManager
    {
        public static BG_MonPayPlanRemark AddBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
        {
            return BG_MonPayPlanRemarkService.AddBG_MonPayPlanRemark(bG_MonPayPlanRemark);
        }

        public static bool DeleteBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
        {
            return BG_MonPayPlanRemarkService.DeleteBG_MonPayPlanRemark(bG_MonPayPlanRemark);
        }

        public static bool DeleteBG_MonPayPlanRemarkByID(int pRID)
        {
            return BG_MonPayPlanRemarkService.DeleteBG_MonPayPlanRemarkByPRID(pRID);
        }

		public static bool ModifyBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
        {
            return BG_MonPayPlanRemarkService.ModifyBG_MonPayPlanRemark(bG_MonPayPlanRemark);
        }
        
        public static DataTable GetAllBG_MonPayPlanRemark()
        {
            return BG_MonPayPlanRemarkService.GetAllBG_MonPayPlanRemark();
        }

        public static BG_MonPayPlanRemark GetBG_MonPayPlanRemarkByPRID(int pRID)
        {
            return BG_MonPayPlanRemarkService.GetBG_MonPayPlanRemarkByPRID(pRID);
        }

    }
}
