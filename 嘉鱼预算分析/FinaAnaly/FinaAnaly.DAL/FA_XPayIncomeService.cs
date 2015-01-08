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
	public static partial class FA_XPayIncomeService
	{
        public static FA_XPayIncome AddFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
		{
            string sql =
				"INSERT FA_XPayIncome (PIEcoSubCoding, PIEcoSubLev, PIEcoSubParID, PIEcoSubName, PIType)" +
				"VALUES (@PIEcoSubCoding, @PIEcoSubLev, @PIEcoSubParID, @PIEcoSubName, @PIType)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIEcoSubCoding", fA_XPayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", fA_XPayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", fA_XPayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", fA_XPayIncome.PIEcoSubName),
					new SqlParameter("@PIType", fA_XPayIncome.PIType)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_XPayIncomeByPIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
		{
			return DeleteFA_XPayIncomeByPIID( fA_XPayIncome.PIID );
		}

        public static bool DeleteFA_XPayIncomeByPIID(int pIID)
		{
            string sql = "DELETE FA_XPayIncome WHERE PIID = @PIID";

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
					


        public static bool ModifyFA_XPayIncome(FA_XPayIncome fA_XPayIncome)
        {
            string sql =
                "UPDATE FA_XPayIncome " +
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
					new SqlParameter("@PIID", fA_XPayIncome.PIID),
					new SqlParameter("@PIEcoSubCoding", fA_XPayIncome.PIEcoSubCoding),
					new SqlParameter("@PIEcoSubLev", fA_XPayIncome.PIEcoSubLev),
					new SqlParameter("@PIEcoSubParID", fA_XPayIncome.PIEcoSubParID),
					new SqlParameter("@PIEcoSubName", fA_XPayIncome.PIEcoSubName),
					new SqlParameter("@PIType", fA_XPayIncome.PIType)
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


        public static DataTable GetAllFA_XPayIncome()
        {
            string sqlAll = "SELECT * FROM FA_XPayIncome";
			return GetFA_XPayIncomeBySql( sqlAll );
        }
		

        public static FA_XPayIncome GetFA_XPayIncomeByPIID(int pIID)
        {
            string sql = "SELECT * FROM FA_XPayIncome WHERE PIID = @PIID";

            try
            {
                SqlParameter para = new SqlParameter("@PIID", pIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_XPayIncome fA_XPayIncome = new FA_XPayIncome();

                    fA_XPayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XPayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    fA_XPayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    fA_XPayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    fA_XPayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_XPayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];
                    
                    return fA_XPayIncome;
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
	

      

        private static DataTable GetFA_XPayIncomeBySql(string safeSql)
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
		
        private static DataTable GetFA_XPayIncomeBySql(string sql, params SqlParameter[] values)
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
