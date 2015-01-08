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
	public static partial class FA_PUCIssNumService
	{
        public static FA_PUCIssNum AddFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
		{
            string sql =
				"INSERT FA_PUCIssNum (PIEcoSubName, PUCMon, PUCYear)" +
				"VALUES (@PIEcoSubName, @PUCMon, @PUCYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIEcoSubName", fA_PUCIssNum.PIEcoSubName),
					new SqlParameter("@PUCMon", fA_PUCIssNum.PUCMon),
					new SqlParameter("@PUCYear", fA_PUCIssNum.PUCYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_PUCIssNumByPUCID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
		{
			return DeleteFA_PUCIssNumByPUCID( fA_PUCIssNum.PUCID );
		}

        public static bool DeleteFA_PUCIssNumByPUCID(int pUCID)
		{
            string sql = "DELETE FA_PUCIssNum WHERE PUCID = @PUCID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PUCID", pUCID)
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
					


        public static bool ModifyFA_PUCIssNum(FA_PUCIssNum fA_PUCIssNum)
        {
            string sql =
                "UPDATE FA_PUCIssNum " +
                "SET " +
	                "PIEcoSubName = @PIEcoSubName, " +
	                "PUCMon = @PUCMon, " +
	                "PUCYear = @PUCYear " +
                "WHERE PUCID = @PUCID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PUCID", fA_PUCIssNum.PUCID),
					new SqlParameter("@PIEcoSubName", fA_PUCIssNum.PIEcoSubName),
					new SqlParameter("@PUCMon", fA_PUCIssNum.PUCMon),
					new SqlParameter("@PUCYear", fA_PUCIssNum.PUCYear)
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


        public static DataTable GetAllFA_PUCIssNum()
        {
            string sqlAll = "SELECT * FROM FA_PUCIssNum";
			return GetFA_PUCIssNumBySql( sqlAll );
        }
		

        public static FA_PUCIssNum GetFA_PUCIssNumByPUCID(int pUCID)
        {
            string sql = "SELECT * FROM FA_PUCIssNum WHERE PUCID = @PUCID";

            try
            {
                SqlParameter para = new SqlParameter("@PUCID", pUCID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_PUCIssNum fA_PUCIssNum = new FA_PUCIssNum();

                    fA_PUCIssNum.PUCID = dt.Rows[0]["PUCID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PUCID"];
                    fA_PUCIssNum.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_PUCIssNum.PUCMon = dt.Rows[0]["PUCMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PUCMon"];
                    fA_PUCIssNum.PUCYear = dt.Rows[0]["PUCYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PUCYear"];
                    
                    return fA_PUCIssNum;
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
	

      

        private static DataTable GetFA_PUCIssNumBySql(string safeSql)
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
		
        private static DataTable GetFA_PUCIssNumBySql(string sql, params SqlParameter[] values)
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
