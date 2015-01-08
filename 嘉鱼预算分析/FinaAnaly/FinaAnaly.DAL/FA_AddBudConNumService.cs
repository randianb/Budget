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
	public static partial class FA_AddBudConNumService
	{
        public static FA_AddBudConNum AddFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
		{
            string sql =
				"INSERT FA_AddBudConNum (TUserMon, TPubMon, TFamMon, AddUserMon, AddPubMon, AddFamMon, AddYear)" +
				"VALUES (@TUserMon, @TPubMon, @TFamMon, @AddUserMon, @AddPubMon, @AddFamMon, @AddYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@TUserMon", fA_AddBudConNum.TUserMon),
					new SqlParameter("@TPubMon", fA_AddBudConNum.TPubMon),
					new SqlParameter("@TFamMon", fA_AddBudConNum.TFamMon),
					new SqlParameter("@AddUserMon", fA_AddBudConNum.AddUserMon),
					new SqlParameter("@AddPubMon", fA_AddBudConNum.AddPubMon),
					new SqlParameter("@AddFamMon", fA_AddBudConNum.AddFamMon),
					new SqlParameter("@AddYear", fA_AddBudConNum.AddYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_AddBudConNumByAddID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
		{
			return DeleteFA_AddBudConNumByAddID( fA_AddBudConNum.AddID );
		}

        public static bool DeleteFA_AddBudConNumByAddID(int addID)
		{
            string sql = "DELETE FA_AddBudConNum WHERE AddID = @AddID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AddID", addID)
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
					


        public static bool ModifyFA_AddBudConNum(FA_AddBudConNum fA_AddBudConNum)
        {
            string sql =
                "UPDATE FA_AddBudConNum " +
                "SET " +
	                "TUserMon = @TUserMon, " +
	                "TPubMon = @TPubMon, " +
	                "TFamMon = @TFamMon, " +
	                "AddUserMon = @AddUserMon, " +
	                "AddPubMon = @AddPubMon, " +
	                "AddFamMon = @AddFamMon, " +
	                "AddYear = @AddYear " +
                "WHERE AddID = @AddID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AddID", fA_AddBudConNum.AddID),
					new SqlParameter("@TUserMon", fA_AddBudConNum.TUserMon),
					new SqlParameter("@TPubMon", fA_AddBudConNum.TPubMon),
					new SqlParameter("@TFamMon", fA_AddBudConNum.TFamMon),
					new SqlParameter("@AddUserMon", fA_AddBudConNum.AddUserMon),
					new SqlParameter("@AddPubMon", fA_AddBudConNum.AddPubMon),
					new SqlParameter("@AddFamMon", fA_AddBudConNum.AddFamMon),
					new SqlParameter("@AddYear", fA_AddBudConNum.AddYear)
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


        public static DataTable GetAllFA_AddBudConNum()
        {
            string sqlAll = "SELECT * FROM FA_AddBudConNum";
			return GetFA_AddBudConNumBySql( sqlAll );
        }
		

        public static FA_AddBudConNum GetFA_AddBudConNumByAddID(int addID)
        {
            string sql = "SELECT * FROM FA_AddBudConNum WHERE AddID = @AddID";

            try
            {
                SqlParameter para = new SqlParameter("@AddID", addID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_AddBudConNum fA_AddBudConNum = new FA_AddBudConNum();

                    fA_AddBudConNum.AddID = dt.Rows[0]["AddID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["AddID"];
                    fA_AddBudConNum.TUserMon = dt.Rows[0]["TUserMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TUserMon"];
                    fA_AddBudConNum.TPubMon = dt.Rows[0]["TPubMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TPubMon"];
                    fA_AddBudConNum.TFamMon = dt.Rows[0]["TFamMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TFamMon"];
                    fA_AddBudConNum.AddUserMon = dt.Rows[0]["AddUserMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddUserMon"];
                    fA_AddBudConNum.AddPubMon = dt.Rows[0]["AddPubMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddPubMon"];
                    fA_AddBudConNum.AddFamMon = dt.Rows[0]["AddFamMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddFamMon"];
                    fA_AddBudConNum.AddYear = dt.Rows[0]["AddYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["AddYear"];
                    
                    return fA_AddBudConNum;
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
	

      

        private static DataTable GetFA_AddBudConNumBySql(string safeSql)
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
		
        private static DataTable GetFA_AddBudConNumBySql(string sql, params SqlParameter[] values)
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
