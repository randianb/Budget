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
	public static partial class BG_IncomeCPayService
	{
        public static BG_IncomeCPay AddBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
		{
            string sql =
				"INSERT BG_IncomeCPay (DepID, InComeSouce, InComeMon, ICPTime)" +
				"VALUES (@DepID, @InComeSouce, @InComeMon, @ICPTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_IncomeCPay.DepID),
					new SqlParameter("@InComeSouce", bG_IncomeCPay.InComeSouce),
					new SqlParameter("@InComeMon", bG_IncomeCPay.InComeMon),
					new SqlParameter("@ICPTime", bG_IncomeCPay.ICPTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_IncomeCPayByICPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
		{
			return DeleteBG_IncomeCPayByICPID( bG_IncomeCPay.ICPID );
		}

        public static bool DeleteBG_IncomeCPayByICPID(int iCPID)
		{
            string sql = "DELETE BG_IncomeCPay WHERE ICPID = @ICPID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ICPID", iCPID)
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
					


        public static bool ModifyBG_IncomeCPay(BG_IncomeCPay bG_IncomeCPay)
        {
            string sql =
                "UPDATE BG_IncomeCPay " +
                "SET " +
	                "DepID = @DepID, " +
	                "InComeSouce = @InComeSouce, " +
	                "InComeMon = @InComeMon, " +
	                "ICPTime = @ICPTime " +
                "WHERE ICPID = @ICPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ICPID", bG_IncomeCPay.ICPID),
					new SqlParameter("@DepID", bG_IncomeCPay.DepID),
					new SqlParameter("@InComeSouce", bG_IncomeCPay.InComeSouce),
					new SqlParameter("@InComeMon", bG_IncomeCPay.InComeMon),
					new SqlParameter("@ICPTime", bG_IncomeCPay.ICPTime)
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


        public static DataTable GetAllBG_IncomeCPay()
        {
            string sqlAll = "SELECT * FROM BG_IncomeCPay";
			return GetBG_IncomeCPayBySql( sqlAll );
        }
		

        public static BG_IncomeCPay GetBG_IncomeCPayByICPID(int iCPID)
        {
            string sql = "SELECT * FROM BG_IncomeCPay WHERE ICPID = @ICPID";

            try
            {
                SqlParameter para = new SqlParameter("@ICPID", iCPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_IncomeCPay bG_IncomeCPay = new BG_IncomeCPay();

                    bG_IncomeCPay.ICPID = dt.Rows[0]["ICPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ICPID"];
                    bG_IncomeCPay.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_IncomeCPay.InComeSouce = dt.Rows[0]["InComeSouce"] == DBNull.Value ? "" : (string)dt.Rows[0]["InComeSouce"];
                    bG_IncomeCPay.InComeMon = dt.Rows[0]["InComeMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["InComeMon"];
                    bG_IncomeCPay.ICPTime = dt.Rows[0]["ICPTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ICPTime"];
                    
                    return bG_IncomeCPay;
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
	

      

        private static DataTable GetBG_IncomeCPayBySql(string safeSql)
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
		
        private static DataTable GetBG_IncomeCPayBySql(string sql, params SqlParameter[] values)
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
