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
	public static partial class BG_PolicyService
	{
        public static BG_Policy AddBG_Policy(BG_Policy bG_Policy)
		{
            string sql =
				"INSERT BG_Policy (PTitle, PContent, PTime, PFrom, POrder, PType, PStatus)" +
				"VALUES (@PTitle, @PContent, @PTime, @PFrom, @POrder, @PType, @PStatus)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PTitle", bG_Policy.PTitle),
					new SqlParameter("@PContent", bG_Policy.PContent),
					new SqlParameter("@PTime", bG_Policy.PTime),
					new SqlParameter("@PFrom", bG_Policy.PFrom),
					new SqlParameter("@POrder", bG_Policy.POrder),
					new SqlParameter("@PType", bG_Policy.PType),
					new SqlParameter("@PStatus", bG_Policy.PStatus)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PolicyByPLID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Policy(BG_Policy bG_Policy)
		{
			return DeleteBG_PolicyByPLID( bG_Policy.PLID );
		}

        public static bool DeleteBG_PolicyByPLID(int pLID)
		{
            string sql = "DELETE BG_Policy WHERE PLID = @PLID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PLID", pLID)
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
					


        public static bool ModifyBG_Policy(BG_Policy bG_Policy)
        {
            string sql =
                "UPDATE BG_Policy " +
                "SET " +
	                "PTitle = @PTitle, " +
	                "PContent = @PContent, " +
	                "PTime = @PTime, " +
	                "PFrom = @PFrom, " +
	                "POrder = @POrder, " +
	                "PType = @PType, " +
	                "PStatus = @PStatus " +
                "WHERE PLID = @PLID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PLID", bG_Policy.PLID),
					new SqlParameter("@PTitle", bG_Policy.PTitle),
					new SqlParameter("@PContent", bG_Policy.PContent),
					new SqlParameter("@PTime", bG_Policy.PTime),
					new SqlParameter("@PFrom", bG_Policy.PFrom),
					new SqlParameter("@POrder", bG_Policy.POrder),
					new SqlParameter("@PType", bG_Policy.PType),
					new SqlParameter("@PStatus", bG_Policy.PStatus)
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


        public static DataTable GetAllBG_Policy()
        {
            string sqlAll = "SELECT * FROM BG_Policy";
			return GetBG_PolicyBySql( sqlAll );
        }
		

        public static BG_Policy GetBG_PolicyByPLID(int pLID)
        {
            string sql = "SELECT * FROM BG_Policy WHERE PLID = @PLID";

            try
            {
                SqlParameter para = new SqlParameter("@PLID", pLID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Policy bG_Policy = new BG_Policy();

                    bG_Policy.PLID = dt.Rows[0]["PLID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PLID"];
                    bG_Policy.PTitle = dt.Rows[0]["PTitle"] == DBNull.Value ? "" : (string)dt.Rows[0]["PTitle"];
                    bG_Policy.PContent = dt.Rows[0]["PContent"] == DBNull.Value ? "" : (string)dt.Rows[0]["PContent"];
                    bG_Policy.PTime = dt.Rows[0]["PTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["PTime"];
                    bG_Policy.PFrom = dt.Rows[0]["PFrom"] == DBNull.Value ? "" : (string)dt.Rows[0]["PFrom"];
                    bG_Policy.POrder = dt.Rows[0]["POrder"] == DBNull.Value ? 0 : (int)dt.Rows[0]["POrder"];
                    bG_Policy.PType = dt.Rows[0]["PType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PType"];
                    bG_Policy.PStatus = dt.Rows[0]["PStatus"] == DBNull.Value ? "" : (string)dt.Rows[0]["PStatus"];
                    
                    return bG_Policy;
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
	

      

        private static DataTable GetBG_PolicyBySql(string safeSql)
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
		
        private static DataTable GetBG_PolicyBySql(string sql, params SqlParameter[] values)
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
