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
	public static partial class FA_WarningQuotaService
	{
        public static FA_WarningQuota AddFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
		{
            string sql =
				"INSERT FA_WarningQuota (YellowWarning, RedWarning, WQYear)" +
				"VALUES (@YellowWarning, @RedWarning, @WQYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@YellowWarning", fA_WarningQuota.YellowWarning),
					new SqlParameter("@RedWarning", fA_WarningQuota.RedWarning),
					new SqlParameter("@WQYear", fA_WarningQuota.WQYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_WarningQuotaByWQID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
		{
			return DeleteFA_WarningQuotaByWQID( fA_WarningQuota.WQID );
		}

        public static bool DeleteFA_WarningQuotaByWQID(int wQID)
		{
            string sql = "DELETE FA_WarningQuota WHERE WQID = @WQID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@WQID", wQID)
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
					


        public static bool ModifyFA_WarningQuota(FA_WarningQuota fA_WarningQuota)
        {
            string sql =
                "UPDATE FA_WarningQuota " +
                "SET " +
	                "YellowWarning = @YellowWarning, " +
	                "RedWarning = @RedWarning, " +
	                "WQYear = @WQYear " +
                "WHERE WQID = @WQID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@WQID", fA_WarningQuota.WQID),
					new SqlParameter("@YellowWarning", fA_WarningQuota.YellowWarning),
					new SqlParameter("@RedWarning", fA_WarningQuota.RedWarning),
					new SqlParameter("@WQYear", fA_WarningQuota.WQYear)
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


        public static DataTable GetAllFA_WarningQuota()
        {
            string sqlAll = "SELECT * FROM FA_WarningQuota";
			return GetFA_WarningQuotaBySql( sqlAll );
        }
		

        public static FA_WarningQuota GetFA_WarningQuotaByWQID(int wQID)
        {
            string sql = "SELECT * FROM FA_WarningQuota WHERE WQID = @WQID";

            try
            {
                SqlParameter para = new SqlParameter("@WQID", wQID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_WarningQuota fA_WarningQuota = new FA_WarningQuota();

                    fA_WarningQuota.WQID = dt.Rows[0]["WQID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["WQID"];
                    fA_WarningQuota.YellowWarning = dt.Rows[0]["YellowWarning"] == DBNull.Value ? "" : (string)dt.Rows[0]["YellowWarning"];
                    fA_WarningQuota.RedWarning = dt.Rows[0]["RedWarning"] == DBNull.Value ? "" : (string)dt.Rows[0]["RedWarning"];
                    fA_WarningQuota.WQYear = dt.Rows[0]["WQYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["WQYear"];
                    
                    return fA_WarningQuota;
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
	

      

        private static DataTable GetFA_WarningQuotaBySql(string safeSql)
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
		
        private static DataTable GetFA_WarningQuotaBySql(string sql, params SqlParameter[] values)
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
