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
	public static partial class FA_XIncomeAccAllocatService
	{
        public static FA_XIncomeAccAllocat AddFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
		{
            string sql =
				"INSERT FA_XIncomeAccAllocat (PIID, IAAMon, IAAYear)" +
				"VALUES (@PIID, @IAAMon, @IAAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_XIncomeAccAllocat.PIID),
					new SqlParameter("@IAAMon", fA_XIncomeAccAllocat.IAAMon),
					new SqlParameter("@IAAYear", fA_XIncomeAccAllocat.IAAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_XIncomeAccAllocatByIAAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
		{
			return DeleteFA_XIncomeAccAllocatByIAAID( fA_XIncomeAccAllocat.IAAID );
		}

        public static bool DeleteFA_XIncomeAccAllocatByIAAID(int iAAID)
		{
            string sql = "DELETE FA_XIncomeAccAllocat WHERE IAAID = @IAAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IAAID", iAAID)
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
					


        public static bool ModifyFA_XIncomeAccAllocat(FA_XIncomeAccAllocat fA_XIncomeAccAllocat)
        {
            string sql =
                "UPDATE FA_XIncomeAccAllocat " +
                "SET " +
	                "PIID = @PIID, " +
	                "IAAMon = @IAAMon, " +
	                "IAAYear = @IAAYear " +
                "WHERE IAAID = @IAAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IAAID", fA_XIncomeAccAllocat.IAAID),
					new SqlParameter("@PIID", fA_XIncomeAccAllocat.PIID),
					new SqlParameter("@IAAMon", fA_XIncomeAccAllocat.IAAMon),
					new SqlParameter("@IAAYear", fA_XIncomeAccAllocat.IAAYear)
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


        public static DataTable GetAllFA_XIncomeAccAllocat()
        {
            string sqlAll = "SELECT * FROM FA_XIncomeAccAllocat";
			return GetFA_XIncomeAccAllocatBySql( sqlAll );
        }
		

        public static FA_XIncomeAccAllocat GetFA_XIncomeAccAllocatByIAAID(int iAAID)
        {
            string sql = "SELECT * FROM FA_XIncomeAccAllocat WHERE IAAID = @IAAID";

            try
            {
                SqlParameter para = new SqlParameter("@IAAID", iAAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_XIncomeAccAllocat fA_XIncomeAccAllocat = new FA_XIncomeAccAllocat();

                    fA_XIncomeAccAllocat.IAAID = dt.Rows[0]["IAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAID"];
                    fA_XIncomeAccAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XIncomeAccAllocat.IAAMon = dt.Rows[0]["IAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IAAMon"];
                    fA_XIncomeAccAllocat.IAAYear = dt.Rows[0]["IAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAYear"];
                    
                    return fA_XIncomeAccAllocat;
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
	

      

        private static DataTable GetFA_XIncomeAccAllocatBySql(string safeSql)
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
		
        private static DataTable GetFA_XIncomeAccAllocatBySql(string sql, params SqlParameter[] values)
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
