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
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_DataRecordService
	{
        public static BG_DataRecord AddBG_DataRecord(BG_DataRecord bG_DataRecord)
		{
            string sql =
				"INSERT BG_DataRecord (DRType, DRTime, DRName, IsBackUp)" +
				"VALUES (@DRType, @DRTime, @DRName, @IsBackUp)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DRType", bG_DataRecord.DRType),
					new SqlParameter("@DRTime", bG_DataRecord.DRTime),
					new SqlParameter("@DRName", bG_DataRecord.DRName),
					new SqlParameter("@IsBackUp", bG_DataRecord.IsBackUp)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_DataRecordByDRID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_DataRecord(BG_DataRecord bG_DataRecord)
		{
			return DeleteBG_DataRecordByDRID( bG_DataRecord.DRID );
		}

        public static bool DeleteBG_DataRecordByDRID(int dRID)
		{
            string sql = "DELETE BG_DataRecord WHERE DRID = @DRID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DRID", dRID)
				};
			
                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
				throw e;
            }
		}
					


        public static bool ModifyBG_DataRecord(BG_DataRecord bG_DataRecord)
        {
            string sql =
                "UPDATE BG_DataRecord " +
                "SET " +
	                "DRType = @DRType, " +
	                "DRTime = @DRTime, " +
	                "DRName = @DRName, " +
	                "IsBackUp = @IsBackUp " +
                "WHERE DRID = @DRID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DRID", bG_DataRecord.DRID),
					new SqlParameter("@DRType", bG_DataRecord.DRType),
					new SqlParameter("@DRTime", bG_DataRecord.DRTime),
					new SqlParameter("@DRName", bG_DataRecord.DRName),
					new SqlParameter("@IsBackUp", bG_DataRecord.IsBackUp)
				};

                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		


        public static DataTable GetAllBG_DataRecord()
        {
            string sqlAll = "SELECT * FROM BG_DataRecord";
			return GetBG_DataRecordBySql( sqlAll );
        }
		

        public static BG_DataRecord GetBG_DataRecordByDRID(int dRID)
        {
            string sql = "SELECT * FROM BG_DataRecord WHERE DRID = @DRID";

            try
            {
                SqlParameter para = new SqlParameter("@DRID", dRID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_DataRecord bG_DataRecord = new BG_DataRecord();

                    bG_DataRecord.DRID = dt.Rows[0]["DRID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DRID"];
                    bG_DataRecord.DRType = dt.Rows[0]["DRType"] == DBNull.Value ? "" : (string)dt.Rows[0]["DRType"];
                    bG_DataRecord.DRTime = dt.Rows[0]["DRTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["DRTime"];
                    bG_DataRecord.DRName = dt.Rows[0]["DRName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DRName"];
                    bG_DataRecord.IsBackUp = dt.Rows[0]["IsBackUp"] == DBNull.Value ? "" : (string)dt.Rows[0]["IsBackUp"];
                    
                    return bG_DataRecord;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
	

      

        private static DataTable GetBG_DataRecordBySql(string safeSql)
        {

			try
			{
				DataTable dt = DBUnity.AdapterToTab(safeSql);
                return dt;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
		
        private static DataTable GetBG_DataRecordBySql(string sql, params SqlParameter[] values)
        {

			try
			{
				DataTable dt = DBUnity.AdapterToTab(sql, values);
                return dt;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
			
        }
		
	}
}
