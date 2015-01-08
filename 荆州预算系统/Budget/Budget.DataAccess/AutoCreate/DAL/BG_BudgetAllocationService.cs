//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudgetAllocationService
	{
        public static BG_BudgetAllocation AddBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
		{
            string sql =
				"INSERT BG_BudgetAllocation (DepID, PIID, BAAMon, SuppMon, BAAYear)" +
				"VALUES (@DepID, @PIID, @BAAMon, @SuppMon, @BAAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_BudgetAllocation.DepID),
					new SqlParameter("@PIID", bG_BudgetAllocation.PIID),
					new SqlParameter("@BAAMon", bG_BudgetAllocation.BAAMon),
					new SqlParameter("@SuppMon", bG_BudgetAllocation.SuppMon),
					new SqlParameter("@BAAYear", bG_BudgetAllocation.BAAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudgetAllocationByBAAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
		{
			return DeleteBG_BudgetAllocationByBAAID( bG_BudgetAllocation.BAAID );
		}

        public static bool DeleteBG_BudgetAllocationByBAAID(int bAAID)
		{
            string sql = "DELETE BG_BudgetAllocation WHERE BAAID = @BAAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BAAID", bAAID)
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
					


        public static bool ModifyBG_BudgetAllocation(BG_BudgetAllocation bG_BudgetAllocation)
        {
            string sql =
                "UPDATE BG_BudgetAllocation " +
                "SET " +
	                "DepID = @DepID, " +
	                "PIID = @PIID, " +
	                "BAAMon = @BAAMon, " +
	                "SuppMon = @SuppMon, " +
	                "BAAYear = @BAAYear " +
                "WHERE BAAID = @BAAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BAAID", bG_BudgetAllocation.BAAID),
					new SqlParameter("@DepID", bG_BudgetAllocation.DepID),
					new SqlParameter("@PIID", bG_BudgetAllocation.PIID),
					new SqlParameter("@BAAMon", bG_BudgetAllocation.BAAMon),
					new SqlParameter("@SuppMon", bG_BudgetAllocation.SuppMon),
					new SqlParameter("@BAAYear", bG_BudgetAllocation.BAAYear)
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


        public static DataTable GetAllBG_BudgetAllocation()
        {
            string sqlAll = "SELECT * FROM BG_BudgetAllocation";
			return GetBG_BudgetAllocationBySql( sqlAll );
        }
		

        public static BG_BudgetAllocation GetBG_BudgetAllocationByBAAID(int bAAID)
        {
            string sql = "SELECT * FROM BG_BudgetAllocation WHERE BAAID = @BAAID";

            try
            {
                SqlParameter para = new SqlParameter("@BAAID", bAAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudgetAllocation bG_BudgetAllocation = new BG_BudgetAllocation();

                    bG_BudgetAllocation.BAAID = dt.Rows[0]["BAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAID"];
                    bG_BudgetAllocation.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudgetAllocation.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudgetAllocation.BAAMon = dt.Rows[0]["BAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BAAMon"];
                    bG_BudgetAllocation.SuppMon = dt.Rows[0]["SuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["SuppMon"];
                    bG_BudgetAllocation.BAAYear = dt.Rows[0]["BAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAYear"];
                    
                    return bG_BudgetAllocation;
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
	

      

        private static DataTable GetBG_BudgetAllocationBySql(string safeSql)
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
		
        private static DataTable GetBG_BudgetAllocationBySql(string sql, params SqlParameter[] values)
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
