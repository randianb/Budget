//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/21 16:13:05
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_ProjectService
	{
        public static BG_Project AddBG_Project(BG_Project bG_Project)
		{
            string sql =
				"INSERT BG_Project (PJName)" +
				"VALUES (@PJName)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PJName", bG_Project.PJName)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProjectByPJID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Project(BG_Project bG_Project)
		{
			return DeleteBG_ProjectByPJID( bG_Project.PJID );
		}

        public static bool DeleteBG_ProjectByPJID(int pJID)
		{
            string sql = "DELETE BG_Project WHERE PJID = @PJID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PJID", pJID)
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
					


        public static bool ModifyBG_Project(BG_Project bG_Project)
        {
            string sql =
                "UPDATE BG_Project " +
                "SET " +
	                "PJName = @PJName " +
                "WHERE PJID = @PJID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PJID", bG_Project.PJID),
					new SqlParameter("@PJName", bG_Project.PJName)
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


        public static DataTable GetAllBG_Project()
        {
            string sqlAll = "SELECT * FROM BG_Project";
			return GetBG_ProjectBySql( sqlAll );
        }
		

        public static BG_Project GetBG_ProjectByPJID(int pJID)
        {
            string sql = "SELECT * FROM BG_Project WHERE PJID = @PJID";

            try
            {
                SqlParameter para = new SqlParameter("@PJID", pJID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Project bG_Project = new BG_Project();

                    bG_Project.PJID = dt.Rows[0]["PJID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PJID"];
                    bG_Project.PJName = dt.Rows[0]["PJName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PJName"];
                    
                    return bG_Project;
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
	

      

        private static DataTable GetBG_ProjectBySql(string safeSql)
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
		
        private static DataTable GetBG_ProjectBySql(string sql, params SqlParameter[] values)
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
