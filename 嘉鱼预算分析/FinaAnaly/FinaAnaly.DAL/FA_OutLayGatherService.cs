//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-4 10:04:31
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_OutLayGatherService
	{
        public static FA_OutLayGather AddFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
		{
            string sql =
				"INSERT FA_OutLayGather (DepID, OtlMon, OtlType, OtlYear)" +
				"VALUES (@DepID, @OtlMon, @OtlType, @OtlYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", fA_OutLayGather.DepID),
					new SqlParameter("@OtlMon", fA_OutLayGather.OtlMon),
					new SqlParameter("@OtlType", fA_OutLayGather.OtlType),
					new SqlParameter("@OtlYear", fA_OutLayGather.OtlYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_OutLayGatherByOGID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
		{
			return DeleteFA_OutLayGatherByOGID( fA_OutLayGather.OGID );
		}

        public static bool DeleteFA_OutLayGatherByOGID(int oGID)
		{
            string sql = "DELETE FA_OutLayGather WHERE OGID = @OGID";

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
					


        public static bool ModifyFA_OutLayGather(FA_OutLayGather fA_OutLayGather)
        {
            string sql =
                "UPDATE FA_OutLayGather " +
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
					new SqlParameter("@OGID", fA_OutLayGather.OGID),
					new SqlParameter("@DepID", fA_OutLayGather.DepID),
					new SqlParameter("@OtlMon", fA_OutLayGather.OtlMon),
					new SqlParameter("@OtlType", fA_OutLayGather.OtlType),
					new SqlParameter("@OtlYear", fA_OutLayGather.OtlYear)
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


        public static DataTable GetAllFA_OutLayGather()
        {
            string sqlAll = "SELECT * FROM FA_OutLayGather";
			return GetFA_OutLayGatherBySql( sqlAll );
        }
		

        public static FA_OutLayGather GetFA_OutLayGatherByOGID(int oGID)
        {
            string sql = "SELECT * FROM FA_OutLayGather WHERE OGID = @OGID";

            try
            {
                SqlParameter para = new SqlParameter("@OGID", oGID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_OutLayGather fA_OutLayGather = new FA_OutLayGather();

                    fA_OutLayGather.OGID = dt.Rows[0]["OGID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OGID"];
                    fA_OutLayGather.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_OutLayGather.OtlMon = dt.Rows[0]["OtlMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OtlMon"];
                    fA_OutLayGather.OtlType = dt.Rows[0]["OtlType"] == DBNull.Value ? "" : (string)dt.Rows[0]["OtlType"];
                    fA_OutLayGather.OtlYear = dt.Rows[0]["OtlYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OtlYear"];
                    
                    return fA_OutLayGather;
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
	

      

        private static DataTable GetFA_OutLayGatherBySql(string safeSql)
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
		
        private static DataTable GetFA_OutLayGatherBySql(string sql, params SqlParameter[] values)
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
