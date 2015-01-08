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
	public static partial class BG_OutLayGatherService
	{
        public static BG_OutLayGather AddBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
		{
            string sql =
				"INSERT BG_OutLayGather (DepID, OtlMon, OtlType, OtlYear)" +
				"VALUES (@DepID, @OtlMon, @OtlType, @OtlYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_OutLayGather.DepID),
					new SqlParameter("@OtlMon", bG_OutLayGather.OtlMon),
					new SqlParameter("@OtlType", bG_OutLayGather.OtlType),
					new SqlParameter("@OtlYear", bG_OutLayGather.OtlYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_OutLayGatherByOGID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
		{
			return DeleteBG_OutLayGatherByOGID( bG_OutLayGather.OGID );
		}

        public static bool DeleteBG_OutLayGatherByOGID(int oGID)
		{
            string sql = "DELETE BG_OutLayGather WHERE OGID = @OGID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OGID", oGID)
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
					


        public static bool ModifyBG_OutLayGather(BG_OutLayGather bG_OutLayGather)
        {
            string sql =
                "UPDATE BG_OutLayGather " +
                "SET " +
	                "DepID = @DepID, " +
	                "OtlMon = @OtlMon, " +
	                "OtlType = @OtlType, " +
	                "OtlYear = @OtlYear " +
                "WHERE OGID = @OGID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OGID", bG_OutLayGather.OGID),
					new SqlParameter("@DepID", bG_OutLayGather.DepID),
					new SqlParameter("@OtlMon", bG_OutLayGather.OtlMon),
					new SqlParameter("@OtlType", bG_OutLayGather.OtlType),
					new SqlParameter("@OtlYear", bG_OutLayGather.OtlYear)
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


        public static DataTable GetAllBG_OutLayGather()
        {
            string sqlAll = "SELECT * FROM BG_OutLayGather";
			return GetBG_OutLayGatherBySql( sqlAll );
        }
		

        public static BG_OutLayGather GetBG_OutLayGatherByOGID(int oGID)
        {
            string sql = "SELECT * FROM BG_OutLayGather WHERE OGID = @OGID";

            try
            {
                SqlParameter para = new SqlParameter("@OGID", oGID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_OutLayGather bG_OutLayGather = new BG_OutLayGather();

                    bG_OutLayGather.OGID = dt.Rows[0]["OGID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OGID"];
                    bG_OutLayGather.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_OutLayGather.OtlMon = dt.Rows[0]["OtlMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OtlMon"];
                    bG_OutLayGather.OtlType = dt.Rows[0]["OtlType"] == DBNull.Value ? "" : (string)dt.Rows[0]["OtlType"];
                    bG_OutLayGather.OtlYear = dt.Rows[0]["OtlYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OtlYear"];
                    
                    return bG_OutLayGather;
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
	

      

        private static DataTable GetBG_OutLayGatherBySql(string safeSql)
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
		
        private static DataTable GetBG_OutLayGatherBySql(string sql, params SqlParameter[] values)
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
