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
	public static partial class FA_IncomeBudAllocatService
	{
        public static FA_IncomeBudAllocat AddFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
		{
            string sql =
				"INSERT FA_IncomeBudAllocat (PIID, IBAMon, IBAYear)" +
				"VALUES (@PIID, @IBAMon, @IBAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_IncomeBudAllocat.PIID),
					new SqlParameter("@IBAMon", fA_IncomeBudAllocat.IBAMon),
					new SqlParameter("@IBAYear", fA_IncomeBudAllocat.IBAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_IncomeBudAllocatByIBAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
		{
			return DeleteFA_IncomeBudAllocatByIBAID( fA_IncomeBudAllocat.IBAID );
		}

        public static bool DeleteFA_IncomeBudAllocatByIBAID(int iBAID)
		{
            string sql = "DELETE FA_IncomeBudAllocat WHERE IBAID = @IBAID";

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
					


        public static bool ModifyFA_IncomeBudAllocat(FA_IncomeBudAllocat fA_IncomeBudAllocat)
        {
            string sql =
                "UPDATE FA_IncomeBudAllocat " +
                "SET " +
	                "PIID = @PIID, " +
	                "IBAMon = @IBAMon, " +
	                "IBAYear = @IBAYear " +
                "WHERE IBAID = @IBAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IBAID", fA_IncomeBudAllocat.IBAID),
					new SqlParameter("@PIID", fA_IncomeBudAllocat.PIID),
					new SqlParameter("@IBAMon", fA_IncomeBudAllocat.IBAMon),
					new SqlParameter("@IBAYear", fA_IncomeBudAllocat.IBAYear)
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


        public static DataTable GetAllFA_IncomeBudAllocat()
        {
            string sqlAll = "SELECT * FROM FA_IncomeBudAllocat";
			return GetFA_IncomeBudAllocatBySql( sqlAll );
        }
		

        public static FA_IncomeBudAllocat GetFA_IncomeBudAllocatByIBAID(int iBAID)
        {
            string sql = "SELECT * FROM FA_IncomeBudAllocat WHERE IBAID = @IBAID";

            try
            {
                SqlParameter para = new SqlParameter("@IBAID", iBAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_IncomeBudAllocat fA_IncomeBudAllocat = new FA_IncomeBudAllocat();

                    fA_IncomeBudAllocat.IBAID = dt.Rows[0]["IBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAID"];
                    fA_IncomeBudAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_IncomeBudAllocat.IBAMon = dt.Rows[0]["IBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IBAMon"];
                    fA_IncomeBudAllocat.IBAYear = dt.Rows[0]["IBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAYear"];
                    
                    return fA_IncomeBudAllocat;
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
	

      

        private static DataTable GetFA_IncomeBudAllocatBySql(string safeSql)
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
		
        private static DataTable GetFA_IncomeBudAllocatBySql(string sql, params SqlParameter[] values)
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
