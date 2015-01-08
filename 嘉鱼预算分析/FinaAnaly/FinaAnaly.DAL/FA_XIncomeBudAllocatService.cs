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
	public static partial class FA_XIncomeBudAllocatService
	{
        public static FA_XIncomeBudAllocat AddFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
		{
            string sql =
				"INSERT FA_XIncomeBudAllocat (PIID, IBAMon, IBAYear)" +
				"VALUES (@PIID, @IBAMon, @IBAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_XIncomeBudAllocat.PIID),
					new SqlParameter("@IBAMon", fA_XIncomeBudAllocat.IBAMon),
					new SqlParameter("@IBAYear", fA_XIncomeBudAllocat.IBAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_XIncomeBudAllocatByIBAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
		{
			return DeleteFA_XIncomeBudAllocatByIBAID( fA_XIncomeBudAllocat.IBAID );
		}

        public static bool DeleteFA_XIncomeBudAllocatByIBAID(int iBAID)
		{
            string sql = "DELETE FA_XIncomeBudAllocat WHERE IBAID = @IBAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IBAID", iBAID)
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
					


        public static bool ModifyFA_XIncomeBudAllocat(FA_XIncomeBudAllocat fA_XIncomeBudAllocat)
        {
            string sql =
                "UPDATE FA_XIncomeBudAllocat " +
                "SET " +
	                "PIID = @PIID, " +
	                "IBAMon = @IBAMon, " +
	                "IBAYear = @IBAYear " +
                "WHERE IBAID = @IBAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IBAID", fA_XIncomeBudAllocat.IBAID),
					new SqlParameter("@PIID", fA_XIncomeBudAllocat.PIID),
					new SqlParameter("@IBAMon", fA_XIncomeBudAllocat.IBAMon),
					new SqlParameter("@IBAYear", fA_XIncomeBudAllocat.IBAYear)
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


        public static DataTable GetAllFA_XIncomeBudAllocat()
        {
            string sqlAll = "SELECT * FROM FA_XIncomeBudAllocat";
			return GetFA_XIncomeBudAllocatBySql( sqlAll );
        }
		

        public static FA_XIncomeBudAllocat GetFA_XIncomeBudAllocatByIBAID(int iBAID)
        {
            string sql = "SELECT * FROM FA_XIncomeBudAllocat WHERE IBAID = @IBAID";

            try
            {
                SqlParameter para = new SqlParameter("@IBAID", iBAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_XIncomeBudAllocat fA_XIncomeBudAllocat = new FA_XIncomeBudAllocat();

                    fA_XIncomeBudAllocat.IBAID = dt.Rows[0]["IBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAID"];
                    fA_XIncomeBudAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XIncomeBudAllocat.IBAMon = dt.Rows[0]["IBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IBAMon"];
                    fA_XIncomeBudAllocat.IBAYear = dt.Rows[0]["IBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAYear"];
                    
                    return fA_XIncomeBudAllocat;
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
	

      

        private static DataTable GetFA_XIncomeBudAllocatBySql(string safeSql)
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
		
        private static DataTable GetFA_XIncomeBudAllocatBySql(string sql, params SqlParameter[] values)
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
