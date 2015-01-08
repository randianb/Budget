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
	public static partial class BG_MonPayPlanAService
	{
        public static BG_MonPayPlanA AddBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
		{
            string sql =
				"INSERT BG_MonPayPlanA (CPID, MABasicExp, MAProExp, MATotal, MATime, MAFunding)" +
				"VALUES (@CPID, @MABasicExp, @MAProExp, @MATotal, @MATime, @MAFunding)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CPID", bG_MonPayPlanA.CPID),
					new SqlParameter("@MABasicExp", bG_MonPayPlanA.MABasicExp),
					new SqlParameter("@MAProExp", bG_MonPayPlanA.MAProExp),
					new SqlParameter("@MATotal", bG_MonPayPlanA.MATotal),
					new SqlParameter("@MATime", bG_MonPayPlanA.MATime),
					new SqlParameter("@MAFunding", bG_MonPayPlanA.MAFunding)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonPayPlanAByCAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
		{
			return DeleteBG_MonPayPlanAByCAID( bG_MonPayPlanA.CAID );
		}

        public static bool DeleteBG_MonPayPlanAByCAID(int cAID)
		{
            string sql = "DELETE BG_MonPayPlanA WHERE CAID = @CAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CAID", cAID)
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
					


        public static bool ModifyBG_MonPayPlanA(BG_MonPayPlanA bG_MonPayPlanA)
        {
            string sql =
                "UPDATE BG_MonPayPlanA " +
                "SET " +
	                "CPID = @CPID, " +
	                "MABasicExp = @MABasicExp, " +
	                "MAProExp = @MAProExp, " +
	                "MATotal = @MATotal, " +
	                "MATime = @MATime, " +
	                "MAFunding = @MAFunding " +
                "WHERE CAID = @CAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CAID", bG_MonPayPlanA.CAID),
					new SqlParameter("@CPID", bG_MonPayPlanA.CPID),
					new SqlParameter("@MABasicExp", bG_MonPayPlanA.MABasicExp),
					new SqlParameter("@MAProExp", bG_MonPayPlanA.MAProExp),
					new SqlParameter("@MATotal", bG_MonPayPlanA.MATotal),
					new SqlParameter("@MATime", bG_MonPayPlanA.MATime),
					new SqlParameter("@MAFunding", bG_MonPayPlanA.MAFunding)
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


        public static DataTable GetAllBG_MonPayPlanA()
        {
            string sqlAll = "SELECT * FROM BG_MonPayPlanA";
			return GetBG_MonPayPlanABySql( sqlAll );
        }
		

        public static BG_MonPayPlanA GetBG_MonPayPlanAByCAID(int cAID)
        {
            string sql = "SELECT * FROM BG_MonPayPlanA WHERE CAID = @CAID";

            try
            {
                SqlParameter para = new SqlParameter("@CAID", cAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_MonPayPlanA bG_MonPayPlanA = new BG_MonPayPlanA();

                    bG_MonPayPlanA.CAID = dt.Rows[0]["CAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CAID"];
                    bG_MonPayPlanA.CPID = dt.Rows[0]["CPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPID"];
                    bG_MonPayPlanA.MABasicExp = dt.Rows[0]["MABasicExp"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MABasicExp"];
                    bG_MonPayPlanA.MAProExp = dt.Rows[0]["MAProExp"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MAProExp"];
                    bG_MonPayPlanA.MATotal = dt.Rows[0]["MATotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MATotal"];
                    bG_MonPayPlanA.MATime = dt.Rows[0]["MATime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MATime"];
                    bG_MonPayPlanA.MAFunding = dt.Rows[0]["MAFunding"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MAFunding"];
                    
                    return bG_MonPayPlanA;
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
	

      

        private static DataTable GetBG_MonPayPlanABySql(string safeSql)
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
		
        private static DataTable GetBG_MonPayPlanABySql(string sql, params SqlParameter[] values)
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
