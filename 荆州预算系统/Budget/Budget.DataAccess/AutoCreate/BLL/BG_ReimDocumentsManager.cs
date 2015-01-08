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

    public static partial class BG_ReimDocumentsManager
    {
        public static BG_ReimDocuments AddBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
        {
            return BG_ReimDocumentsService.AddBG_ReimDocuments(bG_ReimDocuments);
        }

        public static bool DeleteBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
        {
            return BG_ReimDocumentsService.DeleteBG_ReimDocuments(bG_ReimDocuments);
        }

        public static bool DeleteBG_ReimDocumentsByID(int rDID)
        {
            return BG_ReimDocumentsService.DeleteBG_ReimDocumentsByRDID(rDID);
        }

		public static bool ModifyBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
        {
            return BG_ReimDocumentsService.ModifyBG_ReimDocuments(bG_ReimDocuments);
        }
        
        public static DataTable GetAllBG_ReimDocuments()
        {
            return BG_ReimDocumentsService.GetAllBG_ReimDocuments();
        }

        public static BG_ReimDocuments GetBG_ReimDocumentsByRDID(int rDID)
        {
            return BG_ReimDocumentsService.GetBG_ReimDocumentsByRDID(rDID);
        }

    }
}
