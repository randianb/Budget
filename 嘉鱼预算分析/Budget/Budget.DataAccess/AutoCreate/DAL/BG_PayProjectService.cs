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
	public static partial class BG_PayProjectService
	{
        public static BG_PayProject AddBG_PayProject(BG_PayProject bG_PayProject)
		{
            string sql =
				"INSERT BG_PayProject (PayPrjName, PIID)" +
				"VALUES (@PayPrjName, @PIID)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PayPrjName", bG_PayProject.PayPrjName),
					new SqlParameter("@PIID", bG_PayProject.PIID)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PayProjectByPPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PayProject(BG_PayProject bG_PayProject)
		{
			return DeleteBG_PayProjectByPPID( bG_PayProject.PPID );
		}

        public static bool DeleteBG_PayProjectByPPID(int pPID)
		{
            string sql = "DELETE BG_PayProject WHERE PPID = @PPID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PPID", pPID)
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
					


        public static bool ModifyBG_PayProject(BG_PayProject bG_PayProject)
        {
            string sql =
                "UPDATE BG_PayProject " +
                "SET " +
	                "PayPrjName = @PayPrjName, " +
	                "PIID = @PIID " +
                "WHERE PPID = @PPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PPID", bG_PayProject.PPID),
					new SqlParameter("@PayPrjName", bG_PayProject.PayPrjName),
					new SqlParameter("@PIID", bG_PayProject.PIID)
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


        public static DataTable GetAllBG_PayProject()
        {
            string sqlAll = "SELECT * FROM BG_PayProject";
			return GetBG_PayProjectBySql( sqlAll );
        }
		

        public static BG_PayProject GetBG_PayProjectByPPID(int pPID)
        {
            string sql = "SELECT * FROM BG_PayProject WHERE PPID = @PPID";

            try
            {
                SqlParameter para = new SqlParameter("@PPID", pPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PayProject bG_PayProject = new BG_PayProject();

                    bG_PayProject.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_PayProject.PayPrjName = dt.Rows[0]["PayPrjName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PayPrjName"];
                    bG_PayProject.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    
                    return bG_PayProject;
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
	

      

        private static DataTable GetBG_PayProjectBySql(string safeSql)
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
		
        private static DataTable GetBG_PayProjectBySql(string sql, params SqlParameter[] values)
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
