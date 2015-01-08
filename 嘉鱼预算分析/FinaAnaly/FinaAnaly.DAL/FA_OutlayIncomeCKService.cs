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
	public static partial class FA_OutlayIncomeCKService
	{
        public static FA_OutlayIncomeCK AddFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
		{
            string sql =
				"INSERT FA_OutlayIncomeCK (PIID, OICkAreaMon, OICkZeroMon, OICkTime)" +
				"VALUES (@PIID, @OICkAreaMon, @OICkZeroMon, @OICkTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_OutlayIncomeCK.PIID),
					new SqlParameter("@OICkAreaMon", fA_OutlayIncomeCK.OICkAreaMon),
					new SqlParameter("@OICkZeroMon", fA_OutlayIncomeCK.OICkZeroMon),
					new SqlParameter("@OICkTime", fA_OutlayIncomeCK.OICkTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_OutlayIncomeCKByOIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
		{
			return DeleteFA_OutlayIncomeCKByOIID( fA_OutlayIncomeCK.OIID );
		}

        public static bool DeleteFA_OutlayIncomeCKByOIID(int oIID)
		{
            string sql = "DELETE FA_OutlayIncomeCK WHERE OIID = @OIID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OIID", oIID)
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
					


        public static bool ModifyFA_OutlayIncomeCK(FA_OutlayIncomeCK fA_OutlayIncomeCK)
        {
            string sql =
                "UPDATE FA_OutlayIncomeCK " +
                "SET " +
	                "PIID = @PIID, " +
	                "OICkAreaMon = @OICkAreaMon, " +
	                "OICkZeroMon = @OICkZeroMon, " +
	                "OICkTime = @OICkTime " +
                "WHERE OIID = @OIID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OIID", fA_OutlayIncomeCK.OIID),
					new SqlParameter("@PIID", fA_OutlayIncomeCK.PIID),
					new SqlParameter("@OICkAreaMon", fA_OutlayIncomeCK.OICkAreaMon),
					new SqlParameter("@OICkZeroMon", fA_OutlayIncomeCK.OICkZeroMon),
					new SqlParameter("@OICkTime", fA_OutlayIncomeCK.OICkTime)
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


        public static DataTable GetAllFA_OutlayIncomeCK()
        {
            string sqlAll = "SELECT * FROM FA_OutlayIncomeCK";
			return GetFA_OutlayIncomeCKBySql( sqlAll );
        }
		

        public static FA_OutlayIncomeCK GetFA_OutlayIncomeCKByOIID(int oIID)
        {
            string sql = "SELECT * FROM FA_OutlayIncomeCK WHERE OIID = @OIID";

            try
            {
                SqlParameter para = new SqlParameter("@OIID", oIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_OutlayIncomeCK fA_OutlayIncomeCK = new FA_OutlayIncomeCK();

                    fA_OutlayIncomeCK.OIID = dt.Rows[0]["OIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OIID"];
                    fA_OutlayIncomeCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_OutlayIncomeCK.OICkAreaMon = dt.Rows[0]["OICkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OICkAreaMon"];
                    fA_OutlayIncomeCK.OICkZeroMon = dt.Rows[0]["OICkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OICkZeroMon"];
                    fA_OutlayIncomeCK.OICkTime = dt.Rows[0]["OICkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["OICkTime"];
                    
                    return fA_OutlayIncomeCK;
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
	

      

        private static DataTable GetFA_OutlayIncomeCKBySql(string safeSql)
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
		
        private static DataTable GetFA_OutlayIncomeCKBySql(string sql, params SqlParameter[] values)
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
