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
	public static partial class FA_DepBudAllocatService
	{
        public static FA_DepBudAllocat AddFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
		{
            string sql =
				"INSERT FA_DepBudAllocat (DepID, DBAMon, DBAYear)" +
				"VALUES (@DepID, @DBAMon, @DBAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", fA_DepBudAllocat.DepID),
					new SqlParameter("@DBAMon", fA_DepBudAllocat.DBAMon),
					new SqlParameter("@DBAYear", fA_DepBudAllocat.DBAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_DepBudAllocatByDBAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
		{
			return DeleteFA_DepBudAllocatByDBAID( fA_DepBudAllocat.DBAID );
		}

        public static bool DeleteFA_DepBudAllocatByDBAID(int dBAID)
		{
            string sql = "DELETE FA_DepBudAllocat WHERE DBAID = @DBAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DBAID", dBAID)
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
					


        public static bool ModifyFA_DepBudAllocat(FA_DepBudAllocat fA_DepBudAllocat)
        {
            string sql =
                "UPDATE FA_DepBudAllocat " +
                "SET " +
	                "DepID = @DepID, " +
	                "DBAMon = @DBAMon, " +
	                "DBAYear = @DBAYear " +
                "WHERE DBAID = @DBAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DBAID", fA_DepBudAllocat.DBAID),
					new SqlParameter("@DepID", fA_DepBudAllocat.DepID),
					new SqlParameter("@DBAMon", fA_DepBudAllocat.DBAMon),
					new SqlParameter("@DBAYear", fA_DepBudAllocat.DBAYear)
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


        public static DataTable GetAllFA_DepBudAllocat()
        {
            string sqlAll = "SELECT * FROM FA_DepBudAllocat";
			return GetFA_DepBudAllocatBySql( sqlAll );
        }
		

        public static FA_DepBudAllocat GetFA_DepBudAllocatByDBAID(int dBAID)
        {
            string sql = "SELECT * FROM FA_DepBudAllocat WHERE DBAID = @DBAID";

            try
            {
                SqlParameter para = new SqlParameter("@DBAID", dBAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_DepBudAllocat fA_DepBudAllocat = new FA_DepBudAllocat();

                    fA_DepBudAllocat.DBAID = dt.Rows[0]["DBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAID"];
                    fA_DepBudAllocat.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_DepBudAllocat.DBAMon = dt.Rows[0]["DBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DBAMon"];
                    fA_DepBudAllocat.DBAYear = dt.Rows[0]["DBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAYear"];
                    
                    return fA_DepBudAllocat;
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
	

      

        private static DataTable GetFA_DepBudAllocatBySql(string safeSql)
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
		
        private static DataTable GetFA_DepBudAllocatBySql(string sql, params SqlParameter[] values)
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
