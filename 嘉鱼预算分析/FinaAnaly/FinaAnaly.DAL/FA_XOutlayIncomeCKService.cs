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
	public static partial class FA_XOutlayIncomeCKService
	{
        public static FA_XOutlayIncomeCK AddFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
		{
            string sql =
				"INSERT FA_XOutlayIncomeCK (PIID, ODCKAreaMon, ODCKZeroMon, ODCKTime)" +
				"VALUES (@PIID, @ODCKAreaMon, @ODCKZeroMon, @ODCKTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_XOutlayIncomeCK.PIID),
					new SqlParameter("@ODCKAreaMon", fA_XOutlayIncomeCK.ODCKAreaMon),
					new SqlParameter("@ODCKZeroMon", fA_XOutlayIncomeCK.ODCKZeroMon),
					new SqlParameter("@ODCKTime", fA_XOutlayIncomeCK.ODCKTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_XOutlayIncomeCKByODID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
		{
			return DeleteFA_XOutlayIncomeCKByODID( fA_XOutlayIncomeCK.ODID );
		}

        public static bool DeleteFA_XOutlayIncomeCKByODID(int oDID)
		{
            string sql = "DELETE FA_XOutlayIncomeCK WHERE ODID = @ODID";

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
					


        public static bool ModifyFA_XOutlayIncomeCK(FA_XOutlayIncomeCK fA_XOutlayIncomeCK)
        {
            string sql =
                "UPDATE FA_XOutlayIncomeCK " +
                "SET " +
	                "PIID = @PIID, " +
	                "ODCKAreaMon = @ODCKAreaMon, " +
	                "ODCKZeroMon = @ODCKZeroMon, " +
	                "ODCKTime = @ODCKTime " +
                "WHERE ODID = @ODID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ODID", fA_XOutlayIncomeCK.ODID),
					new SqlParameter("@PIID", fA_XOutlayIncomeCK.PIID),
					new SqlParameter("@ODCKAreaMon", fA_XOutlayIncomeCK.ODCKAreaMon),
					new SqlParameter("@ODCKZeroMon", fA_XOutlayIncomeCK.ODCKZeroMon),
					new SqlParameter("@ODCKTime", fA_XOutlayIncomeCK.ODCKTime)
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


        public static DataTable GetAllFA_XOutlayIncomeCK()
        {
            string sqlAll = "SELECT * FROM FA_XOutlayIncomeCK";
			return GetFA_XOutlayIncomeCKBySql( sqlAll );
        }
		

        public static FA_XOutlayIncomeCK GetFA_XOutlayIncomeCKByODID(int oDID)
        {
            string sql = "SELECT * FROM FA_XOutlayIncomeCK WHERE ODID = @ODID";

            try
            {
                SqlParameter para = new SqlParameter("@ODID", oDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fA_XOutlayIncomeCK = new FA_XOutlayIncomeCK();

                    fA_XOutlayIncomeCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_XOutlayIncomeCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XOutlayIncomeCK.ODCKAreaMon = dt.Rows[0]["ODCKAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKAreaMon"];
                    fA_XOutlayIncomeCK.ODCKZeroMon = dt.Rows[0]["ODCKZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKZeroMon"];
                    fA_XOutlayIncomeCK.ODCKTime = dt.Rows[0]["ODCKTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCKTime"];
                    
                    return fA_XOutlayIncomeCK;
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
	

      

        private static DataTable GetFA_XOutlayIncomeCKBySql(string safeSql)
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
		
        private static DataTable GetFA_XOutlayIncomeCKBySql(string sql, params SqlParameter[] values)
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
