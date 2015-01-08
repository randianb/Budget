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
	public static partial class FA_IncomeAccAllocatService
	{
        public static FA_IncomeAccAllocat AddFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
		{
            string sql =
				"INSERT FA_IncomeAccAllocat (PIID, IAAMon, IAAYear)" +
				"VALUES (@PIID, @IAAMon, @IAAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_IncomeAccAllocat.PIID),
					new SqlParameter("@IAAMon", fA_IncomeAccAllocat.IAAMon),
					new SqlParameter("@IAAYear", fA_IncomeAccAllocat.IAAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_IncomeAccAllocatByIAAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
		{
			return DeleteFA_IncomeAccAllocatByIAAID( fA_IncomeAccAllocat.IAAID );
		}

        public static bool DeleteFA_IncomeAccAllocatByIAAID(int iAAID)
		{
            string sql = "DELETE FA_IncomeAccAllocat WHERE IAAID = @IAAID";

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
					


        public static bool ModifyFA_IncomeAccAllocat(FA_IncomeAccAllocat fA_IncomeAccAllocat)
        {
            string sql =
                "UPDATE FA_IncomeAccAllocat " +
                "SET " +
	                "PIID = @PIID, " +
	                "IAAMon = @IAAMon, " +
	                "IAAYear = @IAAYear " +
                "WHERE IAAID = @IAAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IAAID", fA_IncomeAccAllocat.IAAID),
					new SqlParameter("@PIID", fA_IncomeAccAllocat.PIID),
					new SqlParameter("@IAAMon", fA_IncomeAccAllocat.IAAMon),
					new SqlParameter("@IAAYear", fA_IncomeAccAllocat.IAAYear)
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


        public static DataTable GetAllFA_IncomeAccAllocat()
        {
            string sqlAll = "SELECT * FROM FA_IncomeAccAllocat";
			return GetFA_IncomeAccAllocatBySql( sqlAll );
        }
		

        public static FA_IncomeAccAllocat GetFA_IncomeAccAllocatByIAAID(int iAAID)
        {
            string sql = "SELECT * FROM FA_IncomeAccAllocat WHERE IAAID = @IAAID";

            try
            {
                SqlParameter para = new SqlParameter("@IAAID", iAAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_IncomeAccAllocat fA_IncomeAccAllocat = new FA_IncomeAccAllocat();

                    fA_IncomeAccAllocat.IAAID = dt.Rows[0]["IAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAID"];
                    fA_IncomeAccAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_IncomeAccAllocat.IAAMon = dt.Rows[0]["IAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IAAMon"];
                    fA_IncomeAccAllocat.IAAYear = dt.Rows[0]["IAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAYear"];
                    
                    return fA_IncomeAccAllocat;
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
	

      

        private static DataTable GetFA_IncomeAccAllocatBySql(string safeSql)
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
		
        private static DataTable GetFA_IncomeAccAllocatBySql(string sql, params SqlParameter[] values)
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
