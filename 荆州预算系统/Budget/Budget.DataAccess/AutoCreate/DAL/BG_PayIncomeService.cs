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
	public static partial class BG_PayIncomeService
	{
        public static BG_PayIncome AddBG_PayIncome(BG_PayIncome bG_PayIncome)
		{
            string sql =
				"INSERT BG_PayIncome (PIEcoSubCoding, PIEcoSubLev, PIEcoSubParID, PIEcoSubName, PIType, ISSign)" +
				"VALUES (@PIEcoSubCoding, @PIEcoSubLev, @PIEcoSubParID, @PIEcoSubName, @PIType, @ISSign)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIEcoSubCoding", bG_PayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", bG_PayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", bG_PayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", bG_PayIncome.PIEcoSubName),
					new SqlParameter("@PIType", bG_PayIncome.PIType),
					new SqlParameter("@ISSign", bG_PayIncome.ISSign)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PayIncomeByPIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PayIncome(BG_PayIncome bG_PayIncome)
		{
			return DeleteBG_PayIncomeByPIID( bG_PayIncome.PIID );
		}

        public static bool DeleteBG_PayIncomeByPIID(int pIID)
		{
            string sql = "DELETE BG_PayIncome WHERE PIID = @PIID";

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
					


        public static bool ModifyBG_PayIncome(BG_PayIncome bG_PayIncome)
        {
            string sql =
                "UPDATE BG_PayIncome " +
                "SET " +
	                "PIEcoSubCoding = @PIEcoSubCoding, " +
	                "PIEcoSubLev = @PIEcoSubLev, " +
	                "PIEcoSubParID = @PIEcoSubParID, " +
	                "PIEcoSubName = @PIEcoSubName, " +
	                "PIType = @PIType, " +
	                "ISSign = @ISSign " +
                "WHERE PIID = @PIID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_PayIncome.PIID),
					new SqlParameter("@PIEcoSubCoding", bG_PayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", bG_PayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", bG_PayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", bG_PayIncome.PIEcoSubName),
					new SqlParameter("@PIType", bG_PayIncome.PIType),
					new SqlParameter("@ISSign", bG_PayIncome.ISSign)
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


        public static DataTable GetAllBG_PayIncome()
        {
            string sqlAll = "SELECT * FROM BG_PayIncome";
			return GetBG_PayIncomeBySql( sqlAll );
        }
		

        public static BG_PayIncome GetBG_PayIncomeByPIID(int pIID)
        {
            string sql = "SELECT * FROM BG_PayIncome WHERE PIID = @PIID";

            try
            {
                SqlParameter para = new SqlParameter("@PIID", pIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PayIncome bG_PayIncome = new BG_PayIncome();

                    bG_PayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_PayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    bG_PayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    bG_PayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    bG_PayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    bG_PayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];
                    bG_PayIncome.ISSign = dt.Rows[0]["ISSign"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ISSign"];
                    
                    return bG_PayIncome;
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
	

      

        private static DataTable GetBG_PayIncomeBySql(string safeSql)
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
		
        private static DataTable GetBG_PayIncomeBySql(string sql, params SqlParameter[] values)
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
