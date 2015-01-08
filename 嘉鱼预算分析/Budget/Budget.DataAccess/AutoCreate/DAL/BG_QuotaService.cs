//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-05-13 11:24:25
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_QuotaService
	{
        public static BG_Quota AddBG_Quota(BG_Quota bG_Quota)
		{
            string sql =
				"INSERT BG_Quota (PIID, Money, Year)" +
				"VALUES (@PIID, @Money, @Year)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_Quota.PIID),
					new SqlParameter("@Money", bG_Quota.Money),
					new SqlParameter("@Year", bG_Quota.Year)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_QuotaByQtID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Quota(BG_Quota bG_Quota)
		{
			return DeleteBG_QuotaByQtID( bG_Quota.QtID );
		}

        public static bool DeleteBG_QuotaByQtID(int qtID)
		{
            string sql = "DELETE BG_Quota WHERE QtID = @QtID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QtID", qtID)
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
					


        public static bool ModifyBG_Quota(BG_Quota bG_Quota)
        {
            string sql =
                "UPDATE BG_Quota " +
                "SET " +
	                "PIID = @PIID, " +
	                "Money = @Money, " +
	                "Year = @Year " +
                "WHERE QtID = @QtID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QtID", bG_Quota.QtID),
					new SqlParameter("@PIID", bG_Quota.PIID),
					new SqlParameter("@Money", bG_Quota.Money),
					new SqlParameter("@Year", bG_Quota.Year)
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


        public static DataTable GetAllBG_Quota()
        {
            string sqlAll = "SELECT * FROM BG_Quota";
			return GetBG_QuotaBySql( sqlAll );
        }
		

        public static BG_Quota GetBG_QuotaByQtID(int qtID)
        {
            string sql = "SELECT * FROM BG_Quota WHERE QtID = @QtID";

            try
            {
                SqlParameter para = new SqlParameter("@QtID", qtID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Quota bG_Quota = new BG_Quota();

                    bG_Quota.QtID = dt.Rows[0]["QtID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["QtID"];
                    bG_Quota.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_Quota.Money = dt.Rows[0]["Money"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["Money"];
                    bG_Quota.Year = dt.Rows[0]["Year"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Year"];
                    
                    return bG_Quota;
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
	

      

        private static DataTable GetBG_QuotaBySql(string safeSql)
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
		
        private static DataTable GetBG_QuotaBySql(string sql, params SqlParameter[] values)
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
