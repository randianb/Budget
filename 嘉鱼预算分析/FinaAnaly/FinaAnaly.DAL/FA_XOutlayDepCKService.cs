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
	public static partial class FA_XOutlayDepCKService
	{
        public static FA_XOutlayDepCK AddFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
		{
            string sql =
				"INSERT FA_XOutlayDepCK (PIID, DepID, ODCkAreaMon, ODCkZeroMon, ODCkTime)" +
				"VALUES (@PIID, @DepID, @ODCkAreaMon, @ODCkZeroMon, @ODCkTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_XOutlayDepCK.PIID),
					new SqlParameter("@DepID", fA_XOutlayDepCK.DepID),
					new SqlParameter("@ODCkAreaMon", fA_XOutlayDepCK.ODCkAreaMon),
					new SqlParameter("@ODCkZeroMon", fA_XOutlayDepCK.ODCkZeroMon),
					new SqlParameter("@ODCkTime", fA_XOutlayDepCK.ODCkTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_XOutlayDepCKByODID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
		{
			return DeleteFA_XOutlayDepCKByODID( fA_XOutlayDepCK.ODID );
		}

        public static bool DeleteFA_XOutlayDepCKByODID(int oDID)
		{
            string sql = "DELETE FA_XOutlayDepCK WHERE ODID = @ODID";

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
					


        public static bool ModifyFA_XOutlayDepCK(FA_XOutlayDepCK fA_XOutlayDepCK)
        {
            string sql =
                "UPDATE FA_XOutlayDepCK " +
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
					new SqlParameter("@ODID", fA_XOutlayDepCK.ODID),
					new SqlParameter("@PIID", fA_XOutlayDepCK.PIID),
					new SqlParameter("@DepID", fA_XOutlayDepCK.DepID),
					new SqlParameter("@ODCkAreaMon", fA_XOutlayDepCK.ODCkAreaMon),
					new SqlParameter("@ODCkZeroMon", fA_XOutlayDepCK.ODCkZeroMon),
					new SqlParameter("@ODCkTime", fA_XOutlayDepCK.ODCkTime)
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


        public static DataTable GetAllFA_XOutlayDepCK()
        {
            string sqlAll = "SELECT * FROM FA_XOutlayDepCK";
			return GetFA_XOutlayDepCKBySql( sqlAll );
        }
		

        public static FA_XOutlayDepCK GetFA_XOutlayDepCKByODID(int oDID)
        {
            string sql = "SELECT * FROM FA_XOutlayDepCK WHERE ODID = @ODID";

            try
            {
                SqlParameter para = new SqlParameter("@ODID", oDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_XOutlayDepCK fA_XOutlayDepCK = new FA_XOutlayDepCK();

                    fA_XOutlayDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_XOutlayDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XOutlayDepCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_XOutlayDepCK.ODCkAreaMon = dt.Rows[0]["ODCkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkAreaMon"];
                    fA_XOutlayDepCK.ODCkZeroMon = dt.Rows[0]["ODCkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkZeroMon"];
                    fA_XOutlayDepCK.ODCkTime = dt.Rows[0]["ODCkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCkTime"];
                    
                    return fA_XOutlayDepCK;
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
	

      

        private static DataTable GetFA_XOutlayDepCKBySql(string safeSql)
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
		
        private static DataTable GetFA_XOutlayDepCKBySql(string sql, params SqlParameter[] values)
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
