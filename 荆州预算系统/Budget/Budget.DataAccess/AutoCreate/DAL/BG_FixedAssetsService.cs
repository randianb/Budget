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
	public static partial class BG_FixedAssetsService
	{
        public static BG_FixedAssets AddBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
		{
            string sql =
				"INSERT BG_FixedAssets (FACode, FAMon, FAYear, FAMonth)" +
				"VALUES (@FACode, @FAMon, @FAYear, @FAMonth)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FACode", bG_FixedAssets.FACode),
					new SqlParameter("@FAMon", bG_FixedAssets.FAMon),
					new SqlParameter("@FAYear", bG_FixedAssets.FAYear),
					new SqlParameter("@FAMonth", bG_FixedAssets.FAMonth)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_FixedAssetsByFAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
		{
			return DeleteBG_FixedAssetsByFAID( bG_FixedAssets.FAID );
		}

        public static bool DeleteBG_FixedAssetsByFAID(int fAID)
		{
            string sql = "DELETE BG_FixedAssets WHERE FAID = @FAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", fAID)
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
					


        public static bool ModifyBG_FixedAssets(BG_FixedAssets bG_FixedAssets)
        {
            string sql =
                "UPDATE BG_FixedAssets " +
                "SET " +
	                "FACode = @FACode, " +
	                "FAMon = @FAMon, " +
	                "FAYear = @FAYear, " +
	                "FAMonth = @FAMonth " +
                "WHERE FAID = @FAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", bG_FixedAssets.FAID),
					new SqlParameter("@FACode", bG_FixedAssets.FACode),
					new SqlParameter("@FAMon", bG_FixedAssets.FAMon),
					new SqlParameter("@FAYear", bG_FixedAssets.FAYear),
					new SqlParameter("@FAMonth", bG_FixedAssets.FAMonth)
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


        public static DataTable GetAllBG_FixedAssets()
        {
            string sqlAll = "SELECT * FROM BG_FixedAssets";
			return GetBG_FixedAssetsBySql( sqlAll );
        }
		

        public static BG_FixedAssets GetBG_FixedAssetsByFAID(int fAID)
        {
            string sql = "SELECT * FROM BG_FixedAssets WHERE FAID = @FAID";

            try
            {
                SqlParameter para = new SqlParameter("@FAID", fAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_FixedAssets bG_FixedAssets = new BG_FixedAssets();

                    bG_FixedAssets.FAID = dt.Rows[0]["FAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAID"];
                    bG_FixedAssets.FACode = dt.Rows[0]["FACode"] == DBNull.Value ? "" : (string)dt.Rows[0]["FACode"];
                    bG_FixedAssets.FAMon = dt.Rows[0]["FAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["FAMon"];
                    bG_FixedAssets.FAYear = dt.Rows[0]["FAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAYear"];
                    bG_FixedAssets.FAMonth = dt.Rows[0]["FAMonth"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAMonth"];
                    
                    return bG_FixedAssets;
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
	

      

        private static DataTable GetBG_FixedAssetsBySql(string safeSql)
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
		
        private static DataTable GetBG_FixedAssetsBySql(string sql, params SqlParameter[] values)
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
