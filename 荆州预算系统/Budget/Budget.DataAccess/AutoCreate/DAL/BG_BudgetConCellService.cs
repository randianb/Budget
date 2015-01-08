//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudgetConCellService
	{
        public static BG_BudgetConCell AddBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
		{
            string sql =
				"INSERT BG_BudgetConCell (PIID, BCCName, BCCStan, BCCUseSta)" +
				"VALUES (@PIID, @BCCName, @BCCStan, @BCCUseSta)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_BudgetConCell.PIID),
					new SqlParameter("@BCCName", bG_BudgetConCell.BCCName),
					new SqlParameter("@BCCStan", bG_BudgetConCell.BCCStan),
					new SqlParameter("@BCCUseSta", bG_BudgetConCell.BCCUseSta)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudgetConCellByBCCID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
		{
			return DeleteBG_BudgetConCellByBCCID( bG_BudgetConCell.BCCID );
		}

        public static bool DeleteBG_BudgetConCellByBCCID(int bCCID)
		{
            string sql = "DELETE BG_BudgetConCell WHERE BCCID = @BCCID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCCID", bCCID)
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
					


        public static bool ModifyBG_BudgetConCell(BG_BudgetConCell bG_BudgetConCell)
        {
            string sql =
                "UPDATE BG_BudgetConCell " +
                "SET " +
	                "PIID = @PIID, " +
	                "BCCName = @BCCName, " +
	                "BCCStan = @BCCStan, " +
	                "BCCUseSta = @BCCUseSta " +
                "WHERE BCCID = @BCCID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCCID", bG_BudgetConCell.BCCID),
					new SqlParameter("@PIID", bG_BudgetConCell.PIID),
					new SqlParameter("@BCCName", bG_BudgetConCell.BCCName),
					new SqlParameter("@BCCStan", bG_BudgetConCell.BCCStan),
					new SqlParameter("@BCCUseSta", bG_BudgetConCell.BCCUseSta)
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


        public static DataTable GetAllBG_BudgetConCell()
        {
            string sqlAll = "SELECT * FROM BG_BudgetConCell";
			return GetBG_BudgetConCellBySql( sqlAll );
        }
		

        public static BG_BudgetConCell GetBG_BudgetConCellByBCCID(int bCCID)
        {
            string sql = "SELECT * FROM BG_BudgetConCell WHERE BCCID = @BCCID";

            try
            {
                SqlParameter para = new SqlParameter("@BCCID", bCCID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudgetConCell bG_BudgetConCell = new BG_BudgetConCell();

                    bG_BudgetConCell.BCCID = dt.Rows[0]["BCCID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCCID"];
                    bG_BudgetConCell.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudgetConCell.BCCName = dt.Rows[0]["BCCName"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCCName"];
                    bG_BudgetConCell.BCCStan = dt.Rows[0]["BCCStan"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCCStan"];
                    bG_BudgetConCell.BCCUseSta = dt.Rows[0]["BCCUseSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCCUseSta"];
                    
                    return bG_BudgetConCell;
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
	

      

        private static DataTable GetBG_BudgetConCellBySql(string safeSql)
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
		
        private static DataTable GetBG_BudgetConCellBySql(string sql, params SqlParameter[] values)
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
