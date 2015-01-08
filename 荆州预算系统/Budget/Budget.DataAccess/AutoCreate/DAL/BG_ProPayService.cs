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
	public static partial class BG_ProPayService
	{
        public static BG_ProPay AddBG_ProPay(BG_ProPay bG_ProPay)
		{
            string sql =
				"INSERT BG_ProPay (DepID, ProPYear, PPID, ProPA0M)" +
				"VALUES (@DepID, @ProPYear, @PPID, @ProPA0M)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_ProPay.DepID),
					new SqlParameter("@ProPYear", bG_ProPay.ProPYear),
					new SqlParameter("@PPID", bG_ProPay.PPID),
					new SqlParameter("@ProPA0M", bG_ProPay.ProPA0M)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProPayByProPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ProPay(BG_ProPay bG_ProPay)
		{
			return DeleteBG_ProPayByProPID( bG_ProPay.ProPID );
		}

        public static bool DeleteBG_ProPayByProPID(int proPID)
		{
            string sql = "DELETE BG_ProPay WHERE ProPID = @ProPID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ProPID", proPID)
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
					


        public static bool ModifyBG_ProPay(BG_ProPay bG_ProPay)
        {
            string sql =
                "UPDATE BG_ProPay " +
                "SET " +
	                "DepID = @DepID, " +
	                "ProPYear = @ProPYear, " +
	                "PPID = @PPID, " +
	                "ProPA0M = @ProPA0M " +
                "WHERE ProPID = @ProPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ProPID", bG_ProPay.ProPID),
					new SqlParameter("@DepID", bG_ProPay.DepID),
					new SqlParameter("@ProPYear", bG_ProPay.ProPYear),
					new SqlParameter("@PPID", bG_ProPay.PPID),
					new SqlParameter("@ProPA0M", bG_ProPay.ProPA0M)
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


        public static DataTable GetAllBG_ProPay()
        {
            string sqlAll = "SELECT * FROM BG_ProPay";
			return GetBG_ProPayBySql( sqlAll );
        }
		

        public static BG_ProPay GetBG_ProPayByProPID(int proPID)
        {
            string sql = "SELECT * FROM BG_ProPay WHERE ProPID = @ProPID";

            try
            {
                SqlParameter para = new SqlParameter("@ProPID", proPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ProPay bG_ProPay = new BG_ProPay();

                    bG_ProPay.ProPID = dt.Rows[0]["ProPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ProPID"];
                    bG_ProPay.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_ProPay.ProPYear = dt.Rows[0]["ProPYear"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ProPYear"];
                    bG_ProPay.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? "" : (string)dt.Rows[0]["PPID"];
                    bG_ProPay.ProPA0M = dt.Rows[0]["ProPA0M"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ProPA0M"];
                    
                    return bG_ProPay;
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
	

      

        private static DataTable GetBG_ProPayBySql(string safeSql)
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
		
        private static DataTable GetBG_ProPayBySql(string sql, params SqlParameter[] values)
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
