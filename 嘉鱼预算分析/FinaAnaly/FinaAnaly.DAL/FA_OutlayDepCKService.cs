//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_OutlayDepCKService
	{
        public static FA_OutlayDepCK AddFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
		{
            string sql =
				"INSERT FA_OutlayDepCK (PIID, DepID, ODCkAreaMon, ODCkZeroMon, ODCkTime)" +
				"VALUES (@PIID, @DepID, @ODCkAreaMon, @ODCkZeroMon, @ODCkTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_OutlayDepCK.PIID),
					new SqlParameter("@DepID", fA_OutlayDepCK.DepID),
					new SqlParameter("@ODCkAreaMon", fA_OutlayDepCK.ODCkAreaMon),
					new SqlParameter("@ODCkZeroMon", fA_OutlayDepCK.ODCkZeroMon),
					new SqlParameter("@ODCkTime", fA_OutlayDepCK.ODCkTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_OutlayDepCKByODID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
		{
			return DeleteFA_OutlayDepCKByODID( fA_OutlayDepCK.ODID );
		}

        public static bool DeleteFA_OutlayDepCKByODID(int oDID)
		{
            string sql = "DELETE FA_OutlayDepCK WHERE ODID = @ODID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ODID", oDID)
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
					


        public static bool ModifyFA_OutlayDepCK(FA_OutlayDepCK fA_OutlayDepCK)
        {
            string sql =
                "UPDATE FA_OutlayDepCK " +
                "SET " +
	                "PIID = @PIID, " +
	                "DepID = @DepID, " +
	                "ODCkAreaMon = @ODCkAreaMon, " +
	                "ODCkZeroMon = @ODCkZeroMon, " +
	                "ODCkTime = @ODCkTime " +
                "WHERE ODID = @ODID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ODID", fA_OutlayDepCK.ODID),
					new SqlParameter("@PIID", fA_OutlayDepCK.PIID),
					new SqlParameter("@DepID", fA_OutlayDepCK.DepID),
					new SqlParameter("@ODCkAreaMon", fA_OutlayDepCK.ODCkAreaMon),
					new SqlParameter("@ODCkZeroMon", fA_OutlayDepCK.ODCkZeroMon),
					new SqlParameter("@ODCkTime", fA_OutlayDepCK.ODCkTime)
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


        public static DataTable GetAllFA_OutlayDepCK()
        {
            string sqlAll = "SELECT * FROM FA_OutlayDepCK";
			return GetFA_OutlayDepCKBySql( sqlAll );
        }
		

        public static FA_OutlayDepCK GetFA_OutlayDepCKByODID(int oDID)
        {
            string sql = "SELECT * FROM FA_OutlayDepCK WHERE ODID = @ODID";

            try
            {
                SqlParameter para = new SqlParameter("@ODID", oDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_OutlayDepCK fA_OutlayDepCK = new FA_OutlayDepCK();

                    fA_OutlayDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_OutlayDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_OutlayDepCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_OutlayDepCK.ODCkAreaMon = dt.Rows[0]["ODCkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkAreaMon"];
                    fA_OutlayDepCK.ODCkZeroMon = dt.Rows[0]["ODCkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkZeroMon"];
                    fA_OutlayDepCK.ODCkTime = dt.Rows[0]["ODCkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCkTime"];
                    
                    return fA_OutlayDepCK;
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
	

      

        private static DataTable GetFA_OutlayDepCKBySql(string safeSql)
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
		
        private static DataTable GetFA_OutlayDepCKBySql(string sql, params SqlParameter[] values)
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
