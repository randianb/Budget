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
	public static partial class BG_PreviewDevideService
	{
        public static BG_PreviewDevide AddBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
		{
            string sql =
				"INSERT BG_PreviewDevide (DepID, PSID, DevMon)" +
				"VALUES (@DepID, @PSID, @DevMon)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_PreviewDevide.DepID),
					new SqlParameter("@PSID", bG_PreviewDevide.PSID),
					new SqlParameter("@DevMon", bG_PreviewDevide.DevMon)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PreviewDevideByPDID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
		{
			return DeleteBG_PreviewDevideByPDID( bG_PreviewDevide.PDID );
		}

        public static bool DeleteBG_PreviewDevideByPDID(int pDID)
		{
            string sql = "DELETE BG_PreviewDevide WHERE PDID = @PDID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PDID", pDID)
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
					


        public static bool ModifyBG_PreviewDevide(BG_PreviewDevide bG_PreviewDevide)
        {
            string sql =
                "UPDATE BG_PreviewDevide " +
                "SET " +
	                "DepID = @DepID, " +
	                "PSID = @PSID, " +
	                "DevMon = @DevMon " +
                "WHERE PDID = @PDID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PDID", bG_PreviewDevide.PDID),
					new SqlParameter("@DepID", bG_PreviewDevide.DepID),
					new SqlParameter("@PSID", bG_PreviewDevide.PSID),
					new SqlParameter("@DevMon", bG_PreviewDevide.DevMon)
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


        public static DataTable GetAllBG_PreviewDevide()
        {
            string sqlAll = "SELECT * FROM BG_PreviewDevide";
			return GetBG_PreviewDevideBySql( sqlAll );
        }
		

        public static BG_PreviewDevide GetBG_PreviewDevideByPDID(int pDID)
        {
            string sql = "SELECT * FROM BG_PreviewDevide WHERE PDID = @PDID";

            try
            {
                SqlParameter para = new SqlParameter("@PDID", pDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PreviewDevide bG_PreviewDevide = new BG_PreviewDevide();

                    bG_PreviewDevide.PDID = dt.Rows[0]["PDID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PDID"];
                    bG_PreviewDevide.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_PreviewDevide.PSID = dt.Rows[0]["PSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PSID"];
                    bG_PreviewDevide.DevMon = dt.Rows[0]["DevMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DevMon"];
                    
                    return bG_PreviewDevide;
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
	

      

        private static DataTable GetBG_PreviewDevideBySql(string safeSql)
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
		
        private static DataTable GetBG_PreviewDevideBySql(string sql, params SqlParameter[] values)
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
