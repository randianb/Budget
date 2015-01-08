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
	public static partial class BG_BudControlService
	{
        public static BG_BudControl AddBG_BudControl(BG_BudControl bG_BudControl)
		{
            string sql =
				"INSERT BG_BudControl (BCName, BCType, BCMon, BCAdjust)" +
				"VALUES (@BCName, @BCType, @BCMon, @BCAdjust)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCName", bG_BudControl.BCName),
					new SqlParameter("@BCType", bG_BudControl.BCType),
					new SqlParameter("@BCMon", bG_BudControl.BCMon),
					new SqlParameter("@BCAdjust", bG_BudControl.BCAdjust)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudControlByBCID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudControl(BG_BudControl bG_BudControl)
		{
			return DeleteBG_BudControlByBCID( bG_BudControl.BCID );
		}

        public static bool DeleteBG_BudControlByBCID(int bCID)
		{
            string sql = "DELETE BG_BudControl WHERE BCID = @BCID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCID", bCID)
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
					


        public static bool ModifyBG_BudControl(BG_BudControl bG_BudControl)
        {
            string sql =
                "UPDATE BG_BudControl " +
                "SET " +
	                "BCName = @BCName, " +
	                "BCType = @BCType, " +
	                "BCMon = @BCMon, " +
	                "BCAdjust = @BCAdjust " +
                "WHERE BCID = @BCID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCID", bG_BudControl.BCID),
					new SqlParameter("@BCName", bG_BudControl.BCName),
					new SqlParameter("@BCType", bG_BudControl.BCType),
					new SqlParameter("@BCMon", bG_BudControl.BCMon),
					new SqlParameter("@BCAdjust", bG_BudControl.BCAdjust)
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


        public static DataTable GetAllBG_BudControl()
        {
            string sqlAll = "SELECT * FROM BG_BudControl";
			return GetBG_BudControlBySql( sqlAll );
        }
		

        public static BG_BudControl GetBG_BudControlByBCID(int bCID)
        {
            string sql = "SELECT * FROM BG_BudControl WHERE BCID = @BCID";

            try
            {
                SqlParameter para = new SqlParameter("@BCID", bCID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudControl bG_BudControl = new BG_BudControl();

                    bG_BudControl.BCID = dt.Rows[0]["BCID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCID"];
                    bG_BudControl.BCName = dt.Rows[0]["BCName"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCName"];
                    bG_BudControl.BCType = dt.Rows[0]["BCType"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCType"];
                    bG_BudControl.BCMon = dt.Rows[0]["BCMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCMon"];
                    bG_BudControl.BCAdjust = dt.Rows[0]["BCAdjust"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCAdjust"];
                    
                    return bG_BudControl;
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
	

      

        private static DataTable GetBG_BudControlBySql(string safeSql)
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
		
        private static DataTable GetBG_BudControlBySql(string sql, params SqlParameter[] values)
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
