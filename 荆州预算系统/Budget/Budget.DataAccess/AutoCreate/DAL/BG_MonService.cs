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
	public static partial class BG_MonService
	{
        public static BG_Mon AddBG_Mon(BG_Mon bG_Mon)
		{
            string sql =
				"INSERT BG_Mon (BGMon, BGYear, IsEditMon)" +
				"VALUES (@BGMon, @BGYear, @IsEditMon)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BGMon", bG_Mon.BGMon),
					new SqlParameter("@BGYear", bG_Mon.BGYear),
					new SqlParameter("@IsEditMon", bG_Mon.IsEditMon)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonByBGID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Mon(BG_Mon bG_Mon)
		{
			return DeleteBG_MonByBGID( bG_Mon.BGID );
		}

        public static bool DeleteBG_MonByBGID(int bGID)
		{
            string sql = "DELETE BG_Mon WHERE BGID = @BGID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BGID", bGID)
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
					


        public static bool ModifyBG_Mon(BG_Mon bG_Mon)
        {
            string sql =
                "UPDATE BG_Mon " +
                "SET " +
	                "BGMon = @BGMon, " +
	                "BGYear = @BGYear, " +
	                "IsEditMon = @IsEditMon " +
                "WHERE BGID = @BGID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BGID", bG_Mon.BGID),
					new SqlParameter("@BGMon", bG_Mon.BGMon),
					new SqlParameter("@BGYear", bG_Mon.BGYear),
					new SqlParameter("@IsEditMon", bG_Mon.IsEditMon)
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


        public static DataTable GetAllBG_Mon()
        {
            string sqlAll = "SELECT * FROM BG_Mon";
			return GetBG_MonBySql( sqlAll );
        }
		

        public static BG_Mon GetBG_MonByBGID(int bGID)
        {
            string sql = "SELECT * FROM BG_Mon WHERE BGID = @BGID";

            try
            {
                SqlParameter para = new SqlParameter("@BGID", bGID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Mon bG_Mon = new BG_Mon();

                    bG_Mon.BGID = dt.Rows[0]["BGID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BGID"];
                    bG_Mon.BGMon = dt.Rows[0]["BGMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BGMon"];
                    bG_Mon.BGYear = dt.Rows[0]["BGYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BGYear"];
                    bG_Mon.IsEditMon = dt.Rows[0]["IsEditMon"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IsEditMon"];
                    
                    return bG_Mon;
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
	

      

        private static DataTable GetBG_MonBySql(string safeSql)
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
		
        private static DataTable GetBG_MonBySql(string sql, params SqlParameter[] values)
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
