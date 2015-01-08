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

    public static partial class BG_DataRecordManager
    {
        public static BG_DataRecord AddBG_DataRecord(BG_DataRecord bG_DataRecord)
        {
            return BG_DataRecordService.AddBG_DataRecord(bG_DataRecord);
        }

        public static bool DeleteBG_DataRecord(BG_DataRecord bG_DataRecord)
        {
            return BG_DataRecordService.DeleteBG_DataRecord(bG_DataRecord);
        }

        public static bool DeleteBG_DataRecordByID(int dRID)
        {
            return BG_DataRecordService.DeleteBG_DataRecordByDRID(dRID);
        }

		public static bool ModifyBG_DataRecord(BG_DataRecord bG_DataRecord)
        {
            return BG_DataRecordService.ModifyBG_DataRecord(bG_DataRecord);
        }
        
        public static DataTable GetAllBG_DataRecord()
        {
            return BG_DataRecordService.GetAllBG_DataRecord();
        }

        public static BG_DataRecord GetBG_DataRecordByDRID(int dRID)
        {
            return BG_DataRecordService.GetBG_DataRecordByDRID(dRID);
        }

    }
}
