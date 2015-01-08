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
	public static partial class BG_MonPayPlanService
	{
        public static BG_MonPayPlan AddBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
		{
            string sql =
				"INSERT BG_MonPayPlan (PIID, MPFunding, DeptID, MPTime)" +
				"VALUES (@PIID, @MPFunding, @DeptID, @MPTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_MonPayPlan.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan.MPTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonPayPlanByCPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
		{
			return DeleteBG_MonPayPlanByCPID( bG_MonPayPlan.CPID );
		}

        public static bool DeleteBG_MonPayPlanByCPID(int cPID)
		{
            string sql = "DELETE BG_MonPayPlan WHERE CPID = @CPID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CPID", cPID)
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
					


        public static bool ModifyBG_MonPayPlan(BG_MonPayPlan bG_MonPayPlan)
        {
            string sql =
                "UPDATE BG_MonPayPlan " +
                "SET " +
	                "PIID = @PIID, " +
	                "MPFunding = @MPFunding, " +
	                "DeptID = @DeptID, " +
	                "MPTime = @MPTime " +
                "WHERE CPID = @CPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CPID", bG_MonPayPlan.CPID),
					new SqlParameter("@PIID", bG_MonPayPlan.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan.MPTime)
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


        public static DataTable GetAllBG_MonPayPlan()
        {
            string sqlAll = "SELECT * FROM BG_MonPayPlan";
			return GetBG_MonPayPlanBySql( sqlAll );
        }
		

        public static BG_MonPayPlan GetBG_MonPayPlanByCPID(int cPID)
        {
            string sql = "SELECT * FROM BG_MonPayPlan WHERE CPID = @CPID";

            try
            {
                SqlParameter para = new SqlParameter("@CPID", cPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_MonPayPlan bG_MonPayPlan = new BG_MonPayPlan();

                    bG_MonPayPlan.CPID = dt.Rows[0]["CPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPID"];
                    bG_MonPayPlan.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_MonPayPlan.MPFunding = dt.Rows[0]["MPFunding"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MPFunding"];
                    bG_MonPayPlan.DeptID = dt.Rows[0]["DeptID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DeptID"];
                    bG_MonPayPlan.MPTime = dt.Rows[0]["MPTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MPTime"];
                    
                    return bG_MonPayPlan;
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
	

      

        private static DataTable GetBG_MonPayPlanBySql(string safeSql)
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
		
        private static DataTable GetBG_MonPayPlanBySql(string sql, params SqlParameter[] values)
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
