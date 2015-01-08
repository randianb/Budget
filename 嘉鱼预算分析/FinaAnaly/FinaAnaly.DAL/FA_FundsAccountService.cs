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
	public static partial class FA_FundsAccountService
	{
        public static FA_FundsAccount AddFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
		{
            string sql =
				"INSERT FA_FundsAccount (DEPARTMENT, NUMBEROFPEOPLE, LIMIT, RFOUNDING, ATCFOR, JXGLYXDY, DFLZYXDW, WBWLWCXJJ, BYHBSHGDW, GFJLJF)" +
				"VALUES (@DEPARTMENT, @NUMBEROFPEOPLE, @LIMIT, @RFOUNDING, @ATCFOR, @JXGLYXDY, @DFLZYXDW, @WBWLWCXJJ, @BYHBSHGDW, @GFJLJF)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DEPARTMENT", fA_FundsAccount.DEPARTMENT),
					new SqlParameter("@NUMBEROFPEOPLE", fA_FundsAccount.NUMBEROFPEOPLE),
					new SqlParameter("@LIMIT", fA_FundsAccount.LIMIT),
					new SqlParameter("@RFOUNDING", fA_FundsAccount.RFOUNDING),
					new SqlParameter("@ATCFOR", fA_FundsAccount.ATCFOR),
					new SqlParameter("@JXGLYXDY", fA_FundsAccount.JXGLYXDY),
					new SqlParameter("@DFLZYXDW", fA_FundsAccount.DFLZYXDW),
					new SqlParameter("@WBWLWCXJJ", fA_FundsAccount.WBWLWCXJJ),
					new SqlParameter("@BYHBSHGDW", fA_FundsAccount.BYHBSHGDW),
					new SqlParameter("@GFJLJF", fA_FundsAccount.GFJLJF)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_FundsAccountByFAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
		{
			return DeleteFA_FundsAccountByFAID( fA_FundsAccount.FAID );
		}

        public static bool DeleteFA_FundsAccountByFAID(int fAID)
		{
            string sql = "DELETE FA_FundsAccount WHERE FAID = @FAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", fAID)
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
					


        public static bool ModifyFA_FundsAccount(FA_FundsAccount fA_FundsAccount)
        {
            string sql =
                "UPDATE FA_FundsAccount " +
                "SET " +
	                "DEPARTMENT = @DEPARTMENT, " +
	                "NUMBEROFPEOPLE = @NUMBEROFPEOPLE, " +
	                "LIMIT = @LIMIT, " +
	                "RFOUNDING = @RFOUNDING, " +
	                "ATCFOR = @ATCFOR, " +
	                "JXGLYXDY = @JXGLYXDY, " +
	                "DFLZYXDW = @DFLZYXDW, " +
	                "WBWLWCXJJ = @WBWLWCXJJ, " +
	                "BYHBSHGDW = @BYHBSHGDW, " +
	                "GFJLJF = @GFJLJF " +
                "WHERE FAID = @FAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", fA_FundsAccount.FAID),
					new SqlParameter("@DEPARTMENT", fA_FundsAccount.DEPARTMENT),
					new SqlParameter("@NUMBEROFPEOPLE", fA_FundsAccount.NUMBEROFPEOPLE),
					new SqlParameter("@LIMIT", fA_FundsAccount.LIMIT),
					new SqlParameter("@RFOUNDING", fA_FundsAccount.RFOUNDING),
					new SqlParameter("@ATCFOR", fA_FundsAccount.ATCFOR),
					new SqlParameter("@JXGLYXDY", fA_FundsAccount.JXGLYXDY),
					new SqlParameter("@DFLZYXDW", fA_FundsAccount.DFLZYXDW),
					new SqlParameter("@WBWLWCXJJ", fA_FundsAccount.WBWLWCXJJ),
					new SqlParameter("@BYHBSHGDW", fA_FundsAccount.BYHBSHGDW),
					new SqlParameter("@GFJLJF", fA_FundsAccount.GFJLJF)
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


        public static DataTable GetAllFA_FundsAccount()
        {
            string sqlAll = "SELECT * FROM FA_FundsAccount";
			return GetFA_FundsAccountBySql( sqlAll );
        }
		

        public static FA_FundsAccount GetFA_FundsAccountByFAID(int fAID)
        {
            string sql = "SELECT * FROM FA_FundsAccount WHERE FAID = @FAID";

            try
            {
                SqlParameter para = new SqlParameter("@FAID", fAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_FundsAccount fA_FundsAccount = new FA_FundsAccount();

                    fA_FundsAccount.FAID = dt.Rows[0]["FAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAID"];
                    fA_FundsAccount.DEPARTMENT = dt.Rows[0]["DEPARTMENT"] == DBNull.Value ? "" : (string)dt.Rows[0]["DEPARTMENT"];
                    fA_FundsAccount.NUMBEROFPEOPLE = dt.Rows[0]["NUMBEROFPEOPLE"] == DBNull.Value ? 0 : (int)dt.Rows[0]["NUMBEROFPEOPLE"];
                    fA_FundsAccount.LIMIT = dt.Rows[0]["LIMIT"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["LIMIT"];
                    fA_FundsAccount.RFOUNDING = dt.Rows[0]["RFOUNDING"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["RFOUNDING"];
                    fA_FundsAccount.ATCFOR = dt.Rows[0]["ATCFOR"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ATCFOR"];
                    fA_FundsAccount.JXGLYXDY = dt.Rows[0]["JXGLYXDY"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["JXGLYXDY"];
                    fA_FundsAccount.DFLZYXDW = dt.Rows[0]["DFLZYXDW"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DFLZYXDW"];
                    fA_FundsAccount.WBWLWCXJJ = dt.Rows[0]["WBWLWCXJJ"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["WBWLWCXJJ"];
                    fA_FundsAccount.BYHBSHGDW = dt.Rows[0]["BYHBSHGDW"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BYHBSHGDW"];
                    fA_FundsAccount.GFJLJF = dt.Rows[0]["GFJLJF"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["GFJLJF"];
                    
                    return fA_FundsAccount;
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
	

      

        private static DataTable GetFA_FundsAccountBySql(string safeSql)
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
		
        private static DataTable GetFA_FundsAccountBySql(string sql, params SqlParameter[] values)
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
