//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_PayIncomeService
	{
        public static FA_PayIncome AddFA_PayIncome(FA_PayIncome fA_PayIncome)
		{
            string sql =
				"INSERT FA_PayIncome (PIEcoSubCoding, PIEcoSubLev, PIEcoSubParID, PIEcoSubName, PIType)" +
				"VALUES (@PIEcoSubCoding, @PIEcoSubLev, @PIEcoSubParID, @PIEcoSubName, @PIType)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIEcoSubCoding", fA_PayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", fA_PayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", fA_PayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", fA_PayIncome.PIEcoSubName),
					new SqlParameter("@PIType", fA_PayIncome.PIType)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_PayIncomeByPIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_PayIncome(FA_PayIncome fA_PayIncome)
		{
			return DeleteFA_PayIncomeByPIID( fA_PayIncome.PIID );
		}

        public static bool DeleteFA_PayIncomeByPIID(int pIID)
		{
            string sql = "DELETE FA_PayIncome WHERE PIID = @PIID";

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
					


        public static bool ModifyFA_PayIncome(FA_PayIncome fA_PayIncome)
        {
            string sql =
                "UPDATE FA_PayIncome " +
                "SET " +
	                "PIEcoSubCoding = @PIEcoSubCoding, " +
	                "PIEcoSubLev = @PIEcoSubLev, " +
	                "PIEcoSubParID = @PIEcoSubParID, " +
	                "PIEcoSubName = @PIEcoSubName, " +
	                "PIType = @PIType " +
                "WHERE PIID = @PIID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", fA_PayIncome.PIID),
					new SqlParameter("@PIEcoSubCoding", fA_PayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", fA_PayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", fA_PayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", fA_PayIncome.PIEcoSubName),
					new SqlParameter("@PIType", fA_PayIncome.PIType)
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


        public static DataTable GetAllFA_PayIncome()
        {
            string sqlAll = "SELECT * FROM FA_PayIncome";
			return GetFA_PayIncomeBySql( sqlAll );
        }
		

        public static FA_PayIncome GetFA_PayIncomeByPIID(int pIID)
        {
            string sql = "SELECT * FROM FA_PayIncome WHERE PIID = @PIID";

            try
            {
                SqlParameter para = new SqlParameter("@PIID", pIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_PayIncome fA_PayIncome = new FA_PayIncome();

                    fA_PayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_PayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    fA_PayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    fA_PayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    fA_PayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_PayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];
                    
                    return fA_PayIncome;
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
	

      

        private static DataTable GetFA_PayIncomeBySql(string safeSql)
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
		
        private static DataTable GetFA_PayIncomeBySql(string sql, params SqlParameter[] values)
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
