//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/6/12 11:28:32
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_PreService
	{
        public static BG_Pre AddBG_Pre(BG_Pre bG_Pre)
		{
            string sql =
				"INSERT BG_Pre (PreMon, Year)" +
				"VALUES (@PreMon, @Year)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PreMon", bG_Pre.PreMon),
					new SqlParameter("@Year", bG_Pre.Year)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PreByPreID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Pre(BG_Pre bG_Pre)
		{
			return DeleteBG_PreByPreID( bG_Pre.PreID );
		}

        public static bool DeleteBG_PreByPreID(int preID)
		{
            string sql = "DELETE BG_Pre WHERE PreID = @PreID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PreID", preID)
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
					


        public static bool ModifyBG_Pre(BG_Pre bG_Pre)
        {
            string sql =
                "UPDATE BG_Pre " +
                "SET " +
	                "PreMon = @PreMon, " +
	                "Year = @Year " +
                "WHERE PreID = @PreID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PreID", bG_Pre.PreID),
					new SqlParameter("@PreMon", bG_Pre.PreMon),
					new SqlParameter("@Year", bG_Pre.Year)
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


        public static DataTable GetAllBG_Pre()
        {
            string sqlAll = "SELECT * FROM BG_Pre";
			return GetBG_PreBySql( sqlAll );
        }
		

        public static BG_Pre GetBG_PreByPreID(int preID)
        {
            string sql = "SELECT * FROM BG_Pre WHERE PreID = @PreID";

            try
            {
                SqlParameter para = new SqlParameter("@PreID", preID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Pre bG_Pre = new BG_Pre();

                    bG_Pre.PreID = dt.Rows[0]["PreID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PreID"];
                    bG_Pre.PreMon = dt.Rows[0]["PreMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PreMon"];
                    bG_Pre.Year = dt.Rows[0]["Year"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Year"];
                    
                    return bG_Pre;
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
	

      

        private static DataTable GetBG_PreBySql(string safeSql)
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
		
        private static DataTable GetBG_PreBySql(string sql, params SqlParameter[] values)
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
