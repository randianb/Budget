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

    public static partial class BG_PreviewStructManager
    {
        public static BG_PreviewStruct AddBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
        {
            return BG_PreviewStructService.AddBG_PreviewStruct(bG_PreviewStruct);
        }

        public static bool DeleteBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
        {
            return BG_PreviewStructService.DeleteBG_PreviewStruct(bG_PreviewStruct);
        }

        public static bool DeleteBG_PreviewStructByID(int pSID)
        {
            return BG_PreviewStructService.DeleteBG_PreviewStructByPSID(pSID);
        }

		public static bool ModifyBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
        {
            return BG_PreviewStructService.ModifyBG_PreviewStruct(bG_PreviewStruct);
        }
        
        public static DataTable GetAllBG_PreviewStruct()
        {
            return BG_PreviewStructService.GetAllBG_PreviewStruct();
        }

        public static BG_PreviewStruct GetBG_PreviewStructByPSID(int pSID)
        {
            return BG_PreviewStructService.GetBG_PreviewStructByPSID(pSID);
        }

    }
}
