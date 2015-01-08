//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:01
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudAppendixService
	{
        public static BG_BudAppendix AddBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
		{
            string sql =
				"INSERT BG_BudAppendix (BudID, APPath, ApName, ApTime)" +
				"VALUES (@BudID, @APPath, @ApName, @ApTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", bG_BudAppendix.BudID),
					new SqlParameter("@APPath", bG_BudAppendix.APPath),
					new SqlParameter("@ApName", bG_BudAppendix.ApName),
					new SqlParameter("@ApTime", bG_BudAppendix.ApTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudAppendixByAPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
		{
			return DeleteBG_BudAppendixByAPID( bG_BudAppendix.APID );
		}

        public static bool DeleteBG_BudAppendixByAPID(int aPID)
		{
            string sql = "DELETE BG_BudAppendix WHERE APID = @APID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@APID", aPID)
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
					


        public static bool ModifyBG_BudAppendix(BG_BudAppendix bG_BudAppendix)
        {
            string sql =
                "UPDATE BG_BudAppendix " +
                "SET " +
	                "BudID = @BudID, " +
	                "APPath = @APPath, " +
	                "ApName = @ApName, " +
	                "ApTime = @ApTime " +
                "WHERE APID = @APID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@APID", bG_BudAppendix.APID),
					new SqlParameter("@BudID", bG_BudAppendix.BudID),
					new SqlParameter("@APPath", bG_BudAppendix.APPath),
					new SqlParameter("@ApName", bG_BudAppendix.ApName),
					new SqlParameter("@ApTime", bG_BudAppendix.ApTime)
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


        public static DataTable GetAllBG_BudAppendix()
        {
            string sqlAll = "SELECT * FROM BG_BudAppendix";
			return GetBG_BudAppendixBySql( sqlAll );
        }
		

        public static BG_BudAppendix GetBG_BudAppendixByAPID(int aPID)
        {
            string sql = "SELECT * FROM BG_BudAppendix WHERE APID = @APID";

            try
            {
                SqlParameter para = new SqlParameter("@APID", aPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudAppendix bG_BudAppendix = new BG_BudAppendix();

                    bG_BudAppendix.APID = dt.Rows[0]["APID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["APID"];
                    bG_BudAppendix.BudID = dt.Rows[0]["BudID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudID"];
                    bG_BudAppendix.APPath = dt.Rows[0]["APPath"] == DBNull.Value ? "" : (string)dt.Rows[0]["APPath"];
                    bG_BudAppendix.ApName = dt.Rows[0]["ApName"] == DBNull.Value ? "" : (string)dt.Rows[0]["ApName"];
                    bG_BudAppendix.ApTime = dt.Rows[0]["ApTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ApTime"];
                    
                    return bG_BudAppendix;
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
	

      

        private static DataTable GetBG_BudAppendixBySql(string safeSql)
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
		
        private static DataTable GetBG_BudAppendixBySql(string sql, params SqlParameter[] values)
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
