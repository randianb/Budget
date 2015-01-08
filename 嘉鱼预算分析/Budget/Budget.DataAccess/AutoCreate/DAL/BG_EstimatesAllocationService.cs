//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_EstimatesAllocationService
	{
        public static BG_EstimatesAllocation AddBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
		{
            string sql =
				"INSERT BG_EstimatesAllocation (DepID, PIID, BEAMon, BEAYear)" +
				"VALUES (@DepID, @PIID, @BEAMon, @BEAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_EstimatesAllocation.DepID),
					new SqlParameter("@PIID", bG_EstimatesAllocation.PIID),
					new SqlParameter("@BEAMon", bG_EstimatesAllocation.BEAMon),
					new SqlParameter("@BEAYear", bG_EstimatesAllocation.BEAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_EstimatesAllocationByBEAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
		{
			return DeleteBG_EstimatesAllocationByBEAID( bG_EstimatesAllocation.BEAID );
		}

        public static bool DeleteBG_EstimatesAllocationByBEAID(int bEAID)
		{
            string sql = "DELETE BG_EstimatesAllocation WHERE BEAID = @BEAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BEAID", bEAID)
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
					


        public static bool ModifyBG_EstimatesAllocation(BG_EstimatesAllocation bG_EstimatesAllocation)
        {
            string sql =
                "UPDATE BG_EstimatesAllocation " +
                "SET " +
	                "DepID = @DepID, " +
	                "PIID = @PIID, " +
	                "BEAMon = @BEAMon, " +
	                "BEAYear = @BEAYear " +
                "WHERE BEAID = @BEAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BEAID", bG_EstimatesAllocation.BEAID),
					new SqlParameter("@DepID", bG_EstimatesAllocation.DepID),
					new SqlParameter("@PIID", bG_EstimatesAllocation.PIID),
					new SqlParameter("@BEAMon", bG_EstimatesAllocation.BEAMon),
					new SqlParameter("@BEAYear", bG_EstimatesAllocation.BEAYear)
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


        public static DataTable GetAllBG_EstimatesAllocation()
        {
            string sqlAll = "SELECT * FROM BG_EstimatesAllocation";
			return GetBG_EstimatesAllocationBySql( sqlAll );
        }
		

        public static BG_EstimatesAllocation GetBG_EstimatesAllocationByBEAID(int bEAID)
        {
            string sql = "SELECT * FROM BG_EstimatesAllocation WHERE BEAID = @BEAID";

            try
            {
                SqlParameter para = new SqlParameter("@BEAID", bEAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_EstimatesAllocation bG_EstimatesAllocation = new BG_EstimatesAllocation();

                    bG_EstimatesAllocation.BEAID = dt.Rows[0]["BEAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BEAID"];
                    bG_EstimatesAllocation.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_EstimatesAllocation.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_EstimatesAllocation.BEAMon = dt.Rows[0]["BEAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BEAMon"];
                    bG_EstimatesAllocation.BEAYear = dt.Rows[0]["BEAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BEAYear"];
                    
                    return bG_EstimatesAllocation;
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
	

      

        private static DataTable GetBG_EstimatesAllocationBySql(string safeSql)
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
		
        private static DataTable GetBG_EstimatesAllocationBySql(string sql, params SqlParameter[] values)
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
