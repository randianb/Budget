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
	public static partial class BG_OutlayCKService
	{
        public static BG_OutlayCK AddBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
		{
            string sql =
				"INSERT BG_OutlayCK (PIID, PPID, DepID, OACkMon, OATime, OACkType)" +
				"VALUES (@PIID, @PPID, @DepID, @OACkMon, @OATime, @OACkType)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_OutlayCK.PIID),
					new SqlParameter("@PPID", bG_OutlayCK.PPID),
					new SqlParameter("@DepID", bG_OutlayCK.DepID),
					new SqlParameter("@OACkMon", bG_OutlayCK.OACkMon),
					new SqlParameter("@OATime", bG_OutlayCK.OATime),
					new SqlParameter("@OACkType", bG_OutlayCK.OACkType)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_OutlayCKByOAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
		{
			return DeleteBG_OutlayCKByOAID( bG_OutlayCK.OAID );
		}

        public static bool DeleteBG_OutlayCKByOAID(int oAID)
		{
            string sql = "DELETE BG_OutlayCK WHERE OAID = @OAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OAID", oAID)
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
					


        public static bool ModifyBG_OutlayCK(BG_OutlayCK bG_OutlayCK)
        {
            string sql =
                "UPDATE BG_OutlayCK " +
                "SET " +
	                "PIID = @PIID, " +
	                "PPID = @PPID, " +
	                "DepID = @DepID, " +
	                "OACkMon = @OACkMon, " +
	                "OATime = @OATime, " +
	                "OACkType = @OACkType " +
                "WHERE OAID = @OAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OAID", bG_OutlayCK.OAID),
					new SqlParameter("@PIID", bG_OutlayCK.PIID),
					new SqlParameter("@PPID", bG_OutlayCK.PPID),
					new SqlParameter("@DepID", bG_OutlayCK.DepID),
					new SqlParameter("@OACkMon", bG_OutlayCK.OACkMon),
					new SqlParameter("@OATime", bG_OutlayCK.OATime),
					new SqlParameter("@OACkType", bG_OutlayCK.OACkType)
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


        public static DataTable GetAllBG_OutlayCK()
        {
            string sqlAll = "SELECT * FROM BG_OutlayCK";
			return GetBG_OutlayCKBySql( sqlAll );
        }
		

        public static BG_OutlayCK GetBG_OutlayCKByOAID(int oAID)
        {
            string sql = "SELECT * FROM BG_OutlayCK WHERE OAID = @OAID";

            try
            {
                SqlParameter para = new SqlParameter("@OAID", oAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_OutlayCK bG_OutlayCK = new BG_OutlayCK();

                    bG_OutlayCK.OAID = dt.Rows[0]["OAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OAID"];
                    bG_OutlayCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_OutlayCK.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_OutlayCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_OutlayCK.OACkMon = dt.Rows[0]["OACkMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OACkMon"];
                    bG_OutlayCK.OATime = dt.Rows[0]["OATime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["OATime"];
                    bG_OutlayCK.OACkType = dt.Rows[0]["OACkType"] == DBNull.Value ? "" : (string)dt.Rows[0]["OACkType"];
                    
                    return bG_OutlayCK;
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
	

      

        private static DataTable GetBG_OutlayCKBySql(string safeSql)
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
		
        private static DataTable GetBG_OutlayCKBySql(string sql, params SqlParameter[] values)
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
