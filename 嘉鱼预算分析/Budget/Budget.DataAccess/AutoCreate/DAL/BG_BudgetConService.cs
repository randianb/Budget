//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:01
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudgetConService
	{
        public static BG_BudgetCon AddBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
		{
            string sql =
				"INSERT BG_BudgetCon (YNUse, BCRemark)" +
				"VALUES (@YNUse, @BCRemark)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@YNUse", bG_BudgetCon.YNUse),
					new SqlParameter("@BCRemark", bG_BudgetCon.BCRemark)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudgetConByPIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
		{
			return DeleteBG_BudgetConByPIID( bG_BudgetCon.PIID );
		}

        public static bool DeleteBG_BudgetConByPIID(int pIID)
		{
            string sql = "DELETE BG_BudgetCon WHERE PIID = @PIID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", pIID)
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
					


        public static bool ModifyBG_BudgetCon(BG_BudgetCon bG_BudgetCon)
        {
            string sql =
                "UPDATE BG_BudgetCon " +
                "SET " +
	                "YNUse = @YNUse, " +
	                "BCRemark = @BCRemark " +
                "WHERE PIID = @PIID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_BudgetCon.PIID),
					new SqlParameter("@YNUse", bG_BudgetCon.YNUse),
					new SqlParameter("@BCRemark", bG_BudgetCon.BCRemark)
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


        public static DataTable GetAllBG_BudgetCon()
        {
            string sqlAll = "SELECT * FROM BG_BudgetCon";
			return GetBG_BudgetConBySql( sqlAll );
        }
		

        public static BG_BudgetCon GetBG_BudgetConByPIID(int pIID)
        {
            string sql = "SELECT * FROM BG_BudgetCon WHERE PIID = @PIID";

            try
            {
                SqlParameter para = new SqlParameter("@PIID", pIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudgetCon bG_BudgetCon = new BG_BudgetCon();

                    bG_BudgetCon.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudgetCon.YNUse = dt.Rows[0]["YNUse"] == DBNull.Value ? "" : (string)dt.Rows[0]["YNUse"];
                    bG_BudgetCon.BCRemark = dt.Rows[0]["BCRemark"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCRemark"];
                    
                    return bG_BudgetCon;
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
	

      

        private static DataTable GetBG_BudgetConBySql(string safeSql)
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
		
        private static DataTable GetBG_BudgetConBySql(string sql, params SqlParameter[] values)
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
