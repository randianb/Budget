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

    public static partial class BG_PreviewDevideManager
    {
        public static BG_PreviewDevide AddBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
        {
            return BG_PreviewDevideService.AddBG_PreviewDevide(bG_PreviewDevide);
        }

        public static bool DeleteBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
        {
            return BG_PreviewDevideService.DeleteBG_PreviewDevide(bG_PreviewDevide);
        }

        public static bool DeleteBG_PreviewDevideByID(int pDID)
        {
            return BG_PreviewDevideService.DeleteBG_PreviewDevideByPDID(pDID);
        }

		public static bool ModifyBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
        {
            return BG_PreviewDevideService.ModifyBG_PreviewDevide(bG_PreviewDevide);
        }
        
        public static DataTable GetAllBG_PreviewDevide()
        {
            return BG_PreviewDevideService.GetAllBG_PreviewDevide();
        }

        public static BG_PreviewDevide GetBG_PreviewDevideByPDID(int pDID)
        {
            return BG_PreviewDevideService.GetBG_PreviewDevideByPDID(pDID);
        }

    }
}
