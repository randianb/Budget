//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_SupplementaryService
	{
        public static BG_Supplementary AddBG_Supplementary(BG_Supplementary bG_Supplementary)
		{
            string sql =
				"INSERT BG_Supplementary (SuppMon, Year)" +
				"VALUES (@SuppMon, @Year)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SuppMon", bG_Supplementary.SuppMon),
					new SqlParameter("@Year", bG_Supplementary.Year)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_SupplementaryBySuppID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Supplementary(BG_Supplementary bG_Supplementary)
		{
			return DeleteBG_SupplementaryBySuppID( bG_Supplementary.SuppID );
		}

        public static bool DeleteBG_SupplementaryBySuppID(int suppID)
		{
            string sql = "DELETE BG_Supplementary WHERE SuppID = @SuppID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SuppID", suppID)
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
					


        public static bool ModifyBG_Supplementary(BG_Supplementary bG_Supplementary)
        {
            string sql =
                "UPDATE BG_Supplementary " +
                "SET " +
	                "SuppMon = @SuppMon, " +
	                "Year = @Year " +
                "WHERE SuppID = @SuppID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SuppID", bG_Supplementary.SuppID),
					new SqlParameter("@SuppMon", bG_Supplementary.SuppMon),
					new SqlParameter("@Year", bG_Supplementary.Year)
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


        public static DataTable GetAllBG_Supplementary()
        {
            string sqlAll = "SELECT * FROM BG_Supplementary";
			return GetBG_SupplementaryBySql( sqlAll );
        }
		

        public static BG_Supplementary GetBG_SupplementaryBySuppID(int suppID)
        {
            string sql = "SELECT * FROM BG_Supplementary WHERE SuppID = @SuppID";

            try
            {
                SqlParameter para = new SqlParameter("@SuppID", suppID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Supplementary bG_Supplementary = new BG_Supplementary();

                    bG_Supplementary.SuppID = dt.Rows[0]["SuppID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["SuppID"];
                    bG_Supplementary.SuppMon = dt.Rows[0]["SuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["SuppMon"];
                    bG_Supplementary.Year = dt.Rows[0]["Year"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Year"];
                    
                    return bG_Supplementary;
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
	

      

        private static DataTable GetBG_SupplementaryBySql(string safeSql)
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
		
        private static DataTable GetBG_SupplementaryBySql(string sql, params SqlParameter[] values)
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
