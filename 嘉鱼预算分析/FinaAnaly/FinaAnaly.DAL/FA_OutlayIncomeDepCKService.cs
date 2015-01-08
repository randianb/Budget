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
	public static partial class FA_OutlayIncomeDepCKService
	{
        public static FA_OutlayIncomeDepCK AddFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
		{
            string sql =
				"INSERT FA_OutlayIncomeDepCK (PIID, ODCKAreaMon, ODCKZeroMon, ODCKTime)" +
				"VALUES (@PIID, @ODCKAreaMon, @ODCKZeroMon, @ODCKTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_OutlayIncomeDepCK.PIID),
					new SqlParameter("@ODCKAreaMon", fA_OutlayIncomeDepCK.ODCKAreaMon),
					new SqlParameter("@ODCKZeroMon", fA_OutlayIncomeDepCK.ODCKZeroMon),
					new SqlParameter("@ODCKTime", fA_OutlayIncomeDepCK.ODCKTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_OutlayIncomeDepCKByODID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
		{
			return DeleteFA_OutlayIncomeDepCKByODID( fA_OutlayIncomeDepCK.ODID );
		}

        public static bool DeleteFA_OutlayIncomeDepCKByODID(int oDID)
		{
            string sql = "DELETE FA_OutlayIncomeDepCK WHERE ODID = @ODID";

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
					


        public static bool ModifyFA_OutlayIncomeDepCK(FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK)
        {
            string sql =
                "UPDATE FA_OutlayIncomeDepCK " +
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
					new SqlParameter("@ODID", fA_OutlayIncomeDepCK.ODID),
					new SqlParameter("@PIID", fA_OutlayIncomeDepCK.PIID),
					new SqlParameter("@ODCKAreaMon", fA_OutlayIncomeDepCK.ODCKAreaMon),
					new SqlParameter("@ODCKZeroMon", fA_OutlayIncomeDepCK.ODCKZeroMon),
					new SqlParameter("@ODCKTime", fA_OutlayIncomeDepCK.ODCKTime)
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


        public static DataTable GetAllFA_OutlayIncomeDepCK()
        {
            string sqlAll = "SELECT * FROM FA_OutlayIncomeDepCK";
			return GetFA_OutlayIncomeDepCKBySql( sqlAll );
        }
		

        public static FA_OutlayIncomeDepCK GetFA_OutlayIncomeDepCKByODID(int oDID)
        {
            string sql = "SELECT * FROM FA_OutlayIncomeDepCK WHERE ODID = @ODID";

            try
            {
                SqlParameter para = new SqlParameter("@ODID", oDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_OutlayIncomeDepCK fA_OutlayIncomeDepCK = new FA_OutlayIncomeDepCK();

                    fA_OutlayIncomeDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_OutlayIncomeDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_OutlayIncomeDepCK.ODCKAreaMon = dt.Rows[0]["ODCKAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKAreaMon"];
                    fA_OutlayIncomeDepCK.ODCKZeroMon = dt.Rows[0]["ODCKZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKZeroMon"];
                    fA_OutlayIncomeDepCK.ODCKTime = dt.Rows[0]["ODCKTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCKTime"];
                    
                    return fA_OutlayIncomeDepCK;
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
	

      

        private static DataTable GetFA_OutlayIncomeDepCKBySql(string safeSql)
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
		
        private static DataTable GetFA_OutlayIncomeDepCKBySql(string sql, params SqlParameter[] values)
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
