//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_PayWelExpenService
	{
        public static BG_PayWelExpen AddBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
		{
            string sql =
				"INSERT BG_PayWelExpen (PWEYear, DepID, PWESubTotal, PWEBasWage, PWEAlloSub, PWEPrize, PWEPerWage, PWESafePay, PWEOth)" +
				"VALUES (@PWEYear, @DepID, @PWESubTotal, @PWEBasWage, @PWEAlloSub, @PWEPrize, @PWEPerWage, @PWESafePay, @PWEOth)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PWEYear", bG_PayWelExpen.PWEYear),
					new SqlParameter("@DepID", bG_PayWelExpen.DepID),
					new SqlParameter("@PWESubTotal", bG_PayWelExpen.PWESubTotal),
					new SqlParameter("@PWEBasWage", bG_PayWelExpen.PWEBasWage),
					new SqlParameter("@PWEAlloSub", bG_PayWelExpen.PWEAlloSub),
					new SqlParameter("@PWEPrize", bG_PayWelExpen.PWEPrize),
					new SqlParameter("@PWEPerWage", bG_PayWelExpen.PWEPerWage),
					new SqlParameter("@PWESafePay", bG_PayWelExpen.PWESafePay),
					new SqlParameter("@PWEOth", bG_PayWelExpen.PWEOth)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PayWelExpenByPWEID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
		{
			return DeleteBG_PayWelExpenByPWEID( bG_PayWelExpen.PWEID );
		}

        public static bool DeleteBG_PayWelExpenByPWEID(int pWEID)
		{
            string sql = "DELETE BG_PayWelExpen WHERE PWEID = @PWEID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PWEID", pWEID)
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
					


        public static bool ModifyBG_PayWelExpen(BG_PayWelExpen bG_PayWelExpen)
        {
            string sql =
                "UPDATE BG_PayWelExpen " +
                "SET " +
	                "PWEYear = @PWEYear, " +
	                "DepID = @DepID, " +
	                "PWESubTotal = @PWESubTotal, " +
	                "PWEBasWage = @PWEBasWage, " +
	                "PWEAlloSub = @PWEAlloSub, " +
	                "PWEPrize = @PWEPrize, " +
	                "PWEPerWage = @PWEPerWage, " +
	                "PWESafePay = @PWESafePay, " +
	                "PWEOth = @PWEOth " +
                "WHERE PWEID = @PWEID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PWEID", bG_PayWelExpen.PWEID),
					new SqlParameter("@PWEYear", bG_PayWelExpen.PWEYear),
					new SqlParameter("@DepID", bG_PayWelExpen.DepID),
					new SqlParameter("@PWESubTotal", bG_PayWelExpen.PWESubTotal),
					new SqlParameter("@PWEBasWage", bG_PayWelExpen.PWEBasWage),
					new SqlParameter("@PWEAlloSub", bG_PayWelExpen.PWEAlloSub),
					new SqlParameter("@PWEPrize", bG_PayWelExpen.PWEPrize),
					new SqlParameter("@PWEPerWage", bG_PayWelExpen.PWEPerWage),
					new SqlParameter("@PWESafePay", bG_PayWelExpen.PWESafePay),
					new SqlParameter("@PWEOth", bG_PayWelExpen.PWEOth)
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


        public static DataTable GetAllBG_PayWelExpen()
        {
            string sqlAll = "SELECT * FROM BG_PayWelExpen";
			return GetBG_PayWelExpenBySql( sqlAll );
        }
		

        public static BG_PayWelExpen GetBG_PayWelExpenByPWEID(int pWEID)
        {
            string sql = "SELECT * FROM BG_PayWelExpen WHERE PWEID = @PWEID";

            try
            {
                SqlParameter para = new SqlParameter("@PWEID", pWEID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PayWelExpen bG_PayWelExpen = new BG_PayWelExpen();

                    bG_PayWelExpen.PWEID = dt.Rows[0]["PWEID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PWEID"];
                    bG_PayWelExpen.PWEYear = dt.Rows[0]["PWEYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PWEYear"];
                    bG_PayWelExpen.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_PayWelExpen.PWESubTotal = dt.Rows[0]["PWESubTotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWESubTotal"];
                    bG_PayWelExpen.PWEBasWage = dt.Rows[0]["PWEBasWage"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWEBasWage"];
                    bG_PayWelExpen.PWEAlloSub = dt.Rows[0]["PWEAlloSub"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWEAlloSub"];
                    bG_PayWelExpen.PWEPrize = dt.Rows[0]["PWEPrize"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWEPrize"];
                    bG_PayWelExpen.PWEPerWage = dt.Rows[0]["PWEPerWage"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWEPerWage"];
                    bG_PayWelExpen.PWESafePay = dt.Rows[0]["PWESafePay"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWESafePay"];
                    bG_PayWelExpen.PWEOth = dt.Rows[0]["PWEOth"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PWEOth"];
                    
                    return bG_PayWelExpen;
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
	

      

        private static DataTable GetBG_PayWelExpenBySql(string safeSql)
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
		
        private static DataTable GetBG_PayWelExpenBySql(string sql, params SqlParameter[] values)
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
