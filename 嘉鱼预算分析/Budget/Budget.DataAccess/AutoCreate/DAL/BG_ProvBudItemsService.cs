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
	public static partial class BG_ProvBudItemsService
	{
        public static BG_ProvBudItems AddBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
		{
            string sql =
				"INSERT BG_ProvBudItems (PBType, PBMon, PBYear, DepID)" +
				"VALUES (@PBType, @PBMon, @PBYear, @DepID)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PBType", bG_ProvBudItems.PBType),
					new SqlParameter("@PBMon", bG_ProvBudItems.PBMon),
					new SqlParameter("@PBYear", bG_ProvBudItems.PBYear),
					new SqlParameter("@DepID", bG_ProvBudItems.DepID)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProvBudItemsByPBID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
		{
			return DeleteBG_ProvBudItemsByPBID( bG_ProvBudItems.PBID );
		}

        public static bool DeleteBG_ProvBudItemsByPBID(int pBID)
		{
            string sql = "DELETE BG_ProvBudItems WHERE PBID = @PBID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PBID", pBID)
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
					


        public static bool ModifyBG_ProvBudItems(BG_ProvBudItems bG_ProvBudItems)
        {
            string sql =
                "UPDATE BG_ProvBudItems " +
                "SET " +
	                "PBType = @PBType, " +
	                "PBMon = @PBMon, " +
	                "PBYear = @PBYear, " +
	                "DepID = @DepID " +
                "WHERE PBID = @PBID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PBID", bG_ProvBudItems.PBID),
					new SqlParameter("@PBType", bG_ProvBudItems.PBType),
					new SqlParameter("@PBMon", bG_ProvBudItems.PBMon),
					new SqlParameter("@PBYear", bG_ProvBudItems.PBYear),
					new SqlParameter("@DepID", bG_ProvBudItems.DepID)
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


        public static DataTable GetAllBG_ProvBudItems()
        {
            string sqlAll = "SELECT * FROM BG_ProvBudItems";
			return GetBG_ProvBudItemsBySql( sqlAll );
        }
		

        public static BG_ProvBudItems GetBG_ProvBudItemsByPBID(int pBID)
        {
            string sql = "SELECT * FROM BG_ProvBudItems WHERE PBID = @PBID";

            try
            {
                SqlParameter para = new SqlParameter("@PBID", pBID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ProvBudItems bG_ProvBudItems = new BG_ProvBudItems();

                    bG_ProvBudItems.PBID = dt.Rows[0]["PBID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PBID"];
                    bG_ProvBudItems.PBType = dt.Rows[0]["PBType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PBType"];
                    bG_ProvBudItems.PBMon = dt.Rows[0]["PBMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBMon"];
                    bG_ProvBudItems.PBYear = dt.Rows[0]["PBYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PBYear"];
                    bG_ProvBudItems.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    
                    return bG_ProvBudItems;
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
	

      

        private static DataTable GetBG_ProvBudItemsBySql(string safeSql)
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
		
        private static DataTable GetBG_ProvBudItemsBySql(string sql, params SqlParameter[] values)
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
