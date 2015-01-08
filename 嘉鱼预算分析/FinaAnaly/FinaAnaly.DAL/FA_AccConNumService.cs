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
	public static partial class FA_AccConNumService
	{
        public static FA_AccConNum AddFA_AccConNum(FA_AccConNum fA_AccConNum)
		{
            string sql =
				"INSERT FA_AccConNum (ACNBasExpBudMon, ACNProExpBudMon, ACNYear)" +
				"VALUES (@ACNBasExpBudMon, @ACNProExpBudMon, @ACNYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ACNBasExpBudMon", fA_AccConNum.ACNBasExpBudMon),
					new SqlParameter("@ACNProExpBudMon", fA_AccConNum.ACNProExpBudMon),
					new SqlParameter("@ACNYear", fA_AccConNum.ACNYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_AccConNumByACID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_AccConNum(FA_AccConNum fA_AccConNum)
		{
			return DeleteFA_AccConNumByACID( fA_AccConNum.ACID );
		}

        public static bool DeleteFA_AccConNumByACID(int aCID)
		{
            string sql = "DELETE FA_AccConNum WHERE ACID = @ACID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ACID", aCID)
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
					


        public static bool ModifyFA_AccConNum(FA_AccConNum fA_AccConNum)
        {
            string sql =
                "UPDATE FA_AccConNum " +
                "SET " +
	                "ACNBasExpBudMon = @ACNBasExpBudMon, " +
	                "ACNProExpBudMon = @ACNProExpBudMon, " +
	                "ACNYear = @ACNYear " +
                "WHERE ACID = @ACID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ACID", fA_AccConNum.ACID),
					new SqlParameter("@ACNBasExpBudMon", fA_AccConNum.ACNBasExpBudMon),
					new SqlParameter("@ACNProExpBudMon", fA_AccConNum.ACNProExpBudMon),
					new SqlParameter("@ACNYear", fA_AccConNum.ACNYear)
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


        public static DataTable GetAllFA_AccConNum()
        {
            string sqlAll = "SELECT * FROM FA_AccConNum";
			return GetFA_AccConNumBySql( sqlAll );
        }
		

        public static FA_AccConNum GetFA_AccConNumByACID(int aCID)
        {
            string sql = "SELECT * FROM FA_AccConNum WHERE ACID = @ACID";

            try
            {
                SqlParameter para = new SqlParameter("@ACID", aCID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_AccConNum fA_AccConNum = new FA_AccConNum();

                    fA_AccConNum.ACID = dt.Rows[0]["ACID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ACID"];
                    fA_AccConNum.ACNBasExpBudMon = dt.Rows[0]["ACNBasExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ACNBasExpBudMon"];
                    fA_AccConNum.ACNProExpBudMon = dt.Rows[0]["ACNProExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ACNProExpBudMon"];
                    fA_AccConNum.ACNYear = dt.Rows[0]["ACNYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ACNYear"];
                    
                    return fA_AccConNum;
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
	

      

        private static DataTable GetFA_AccConNumBySql(string safeSql)
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
		
        private static DataTable GetFA_AccConNumBySql(string sql, params SqlParameter[] values)
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
