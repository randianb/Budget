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
	public static partial class FA_BudConNumService
	{
        public static FA_BudConNum AddFA_BudConNum(FA_BudConNum fA_BudConNum)
		{
            string sql =
				"INSERT FA_BudConNum (BCNBasExpBudMon, BCNProExpBudMon, BCNBasAddBudMon, BCNProAddBudMon, BCNYear)" +
				"VALUES (@BCNBasExpBudMon, @BCNProExpBudMon, @BCNBasAddBudMon, @BCNProAddBudMon, @BCNYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCNBasExpBudMon", fA_BudConNum.BCNBasExpBudMon),
					new SqlParameter("@BCNProExpBudMon", fA_BudConNum.BCNProExpBudMon),
					new SqlParameter("@BCNBasAddBudMon", fA_BudConNum.BCNBasAddBudMon),
					new SqlParameter("@BCNProAddBudMon", fA_BudConNum.BCNProAddBudMon),
					new SqlParameter("@BCNYear", fA_BudConNum.BCNYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_BudConNumByBCID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_BudConNum(FA_BudConNum fA_BudConNum)
		{
			return DeleteFA_BudConNumByBCID( fA_BudConNum.BCID );
		}

        public static bool DeleteFA_BudConNumByBCID(int bCID)
		{
            string sql = "DELETE FA_BudConNum WHERE BCID = @BCID";

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
					


        public static bool ModifyFA_BudConNum(FA_BudConNum fA_BudConNum)
        {
            string sql =
                "UPDATE FA_BudConNum " +
                "SET " +
	                "BCNBasExpBudMon = @BCNBasExpBudMon, " +
	                "BCNProExpBudMon = @BCNProExpBudMon, " +
	                "BCNBasAddBudMon = @BCNBasAddBudMon, " +
	                "BCNProAddBudMon = @BCNProAddBudMon, " +
	                "BCNYear = @BCNYear " +
                "WHERE BCID = @BCID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BCID", fA_BudConNum.BCID),
					new SqlParameter("@BCNBasExpBudMon", fA_BudConNum.BCNBasExpBudMon),
					new SqlParameter("@BCNProExpBudMon", fA_BudConNum.BCNProExpBudMon),
					new SqlParameter("@BCNBasAddBudMon", fA_BudConNum.BCNBasAddBudMon),
					new SqlParameter("@BCNProAddBudMon", fA_BudConNum.BCNProAddBudMon),
					new SqlParameter("@BCNYear", fA_BudConNum.BCNYear)
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


        public static DataTable GetAllFA_BudConNum()
        {
            string sqlAll = "SELECT * FROM FA_BudConNum";
			return GetFA_BudConNumBySql( sqlAll );
        }
		

        public static FA_BudConNum GetFA_BudConNumByBCID(int bCID)
        {
            string sql = "SELECT * FROM FA_BudConNum WHERE BCID = @BCID";

            try
            {
                SqlParameter para = new SqlParameter("@BCID", bCID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_BudConNum fA_BudConNum = new FA_BudConNum();

                    fA_BudConNum.BCID = dt.Rows[0]["BCID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCID"];
                    fA_BudConNum.BCNBasExpBudMon = dt.Rows[0]["BCNBasExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNBasExpBudMon"];
                    fA_BudConNum.BCNProExpBudMon = dt.Rows[0]["BCNProExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNProExpBudMon"];
                    fA_BudConNum.BCNBasAddBudMon = dt.Rows[0]["BCNBasAddBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNBasAddBudMon"];
                    fA_BudConNum.BCNProAddBudMon = dt.Rows[0]["BCNProAddBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNProAddBudMon"];
                    fA_BudConNum.BCNYear = dt.Rows[0]["BCNYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCNYear"];
                    
                    return fA_BudConNum;
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
	

      

        private static DataTable GetFA_BudConNumBySql(string safeSql)
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
		
        private static DataTable GetFA_BudConNumBySql(string sql, params SqlParameter[] values)
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
