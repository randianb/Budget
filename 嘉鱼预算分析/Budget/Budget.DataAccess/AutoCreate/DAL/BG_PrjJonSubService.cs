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
	public static partial class BG_PrjJonSubService
	{
        public static BG_PrjJonSub AddBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
		{
            string sql =
				"INSERT BG_PrjJonSub (PPID, PIID)" +
				"VALUES (@PPID, @PIID)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PPID", bG_PrjJonSub.PPID),
					new SqlParameter("@PIID", bG_PrjJonSub.PIID)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PrjJonSubByPSID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
		{
			return DeleteBG_PrjJonSubByPSID( bG_PrjJonSub.PSID );
		}

        public static bool DeleteBG_PrjJonSubByPSID(int pSID)
		{
            string sql = "DELETE BG_PrjJonSub WHERE PSID = @PSID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSID", pSID)
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
					


        public static bool ModifyBG_PrjJonSub(BG_PrjJonSub bG_PrjJonSub)
        {
            string sql =
                "UPDATE BG_PrjJonSub " +
                "SET " +
	                "PPID = @PPID, " +
	                "PIID = @PIID " +
                "WHERE PSID = @PSID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSID", bG_PrjJonSub.PSID),
					new SqlParameter("@PPID", bG_PrjJonSub.PPID),
					new SqlParameter("@PIID", bG_PrjJonSub.PIID)
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


        public static DataTable GetAllBG_PrjJonSub()
        {
            string sqlAll = "SELECT * FROM BG_PrjJonSub";
			return GetBG_PrjJonSubBySql( sqlAll );
        }
		

        public static BG_PrjJonSub GetBG_PrjJonSubByPSID(int pSID)
        {
            string sql = "SELECT * FROM BG_PrjJonSub WHERE PSID = @PSID";

            try
            {
                SqlParameter para = new SqlParameter("@PSID", pSID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PrjJonSub bG_PrjJonSub = new BG_PrjJonSub();

                    bG_PrjJonSub.PSID = dt.Rows[0]["PSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PSID"];
                    bG_PrjJonSub.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_PrjJonSub.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    
                    return bG_PrjJonSub;
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
	

      

        private static DataTable GetBG_PrjJonSubBySql(string safeSql)
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
		
        private static DataTable GetBG_PrjJonSubBySql(string sql, params SqlParameter[] values)
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
