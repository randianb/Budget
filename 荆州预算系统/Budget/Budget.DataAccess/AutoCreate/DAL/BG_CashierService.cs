//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:44
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_CashierService
	{
        public static BG_Cashier AddBG_Cashier(BG_Cashier bG_Cashier)
		{
            string sql =
				"INSERT BG_Cashier (Piid, BgMon, CZMon, QTMon, BQMon, DepID, CTime)" +
				"VALUES (@Piid, @BgMon, @CZMon, @QTMon, @BQMon, @DepID, @CTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Piid", bG_Cashier.Piid),
					new SqlParameter("@BgMon", bG_Cashier.BgMon),
					new SqlParameter("@CZMon", bG_Cashier.CZMon),
					new SqlParameter("@QTMon", bG_Cashier.QTMon),
					new SqlParameter("@BQMon", bG_Cashier.BQMon),
					new SqlParameter("@DepID", bG_Cashier.DepID),
					new SqlParameter("@CTime", bG_Cashier.CTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_CashierByCashierid(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Cashier(BG_Cashier bG_Cashier)
		{
			return DeleteBG_CashierByCashierid( bG_Cashier.Cashierid );
		}

        public static bool DeleteBG_CashierByCashierid(int cashierid)
		{
            string sql = "DELETE BG_Cashier WHERE Cashierid = @Cashierid";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Cashierid", cashierid)
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
					


        public static bool ModifyBG_Cashier(BG_Cashier bG_Cashier)
        {
            string sql =
                "UPDATE BG_Cashier " +
                "SET " +
	                "Piid = @Piid, " +
	                "BgMon = @BgMon, " +
	                "CZMon = @CZMon, " +
	                "QTMon = @QTMon, " +
	                "BQMon = @BQMon, " +
	                "DepID = @DepID, " +
	                "CTime = @CTime " +
                "WHERE Cashierid = @Cashierid";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Cashierid", bG_Cashier.Cashierid),
					new SqlParameter("@Piid", bG_Cashier.Piid),
					new SqlParameter("@BgMon", bG_Cashier.BgMon),
					new SqlParameter("@CZMon", bG_Cashier.CZMon),
					new SqlParameter("@QTMon", bG_Cashier.QTMon),
					new SqlParameter("@BQMon", bG_Cashier.BQMon),
					new SqlParameter("@DepID", bG_Cashier.DepID),
					new SqlParameter("@CTime", bG_Cashier.CTime)
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


        public static DataTable GetAllBG_Cashier()
        {
            string sqlAll = "SELECT * FROM BG_Cashier";
			return GetBG_CashierBySql( sqlAll );
        }
		

        public static BG_Cashier GetBG_CashierByCashierid(int cashierid)
        {
            string sql = "SELECT * FROM BG_Cashier WHERE Cashierid = @Cashierid";

            try
            {
                SqlParameter para = new SqlParameter("@Cashierid", cashierid);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Cashier bG_Cashier = new BG_Cashier();

                    bG_Cashier.Cashierid = dt.Rows[0]["Cashierid"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Cashierid"];
                    bG_Cashier.Piid = dt.Rows[0]["Piid"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Piid"];
                    bG_Cashier.BgMon = dt.Rows[0]["BgMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BgMon"];
                    bG_Cashier.CZMon = dt.Rows[0]["CZMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["CZMon"];
                    bG_Cashier.QTMon = dt.Rows[0]["QTMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["QTMon"];
                    bG_Cashier.BQMon = dt.Rows[0]["BQMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BQMon"];
                    bG_Cashier.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_Cashier.CTime = dt.Rows[0]["CTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["CTime"];
                    
                    return bG_Cashier;
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
	

      

        private static DataTable GetBG_CashierBySql(string safeSql)
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
		
        private static DataTable GetBG_CashierBySql(string sql, params SqlParameter[] values)
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
