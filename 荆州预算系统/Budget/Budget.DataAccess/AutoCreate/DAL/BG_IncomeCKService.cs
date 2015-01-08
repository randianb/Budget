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
	public static partial class BG_IncomeCKService
	{
        public static BG_IncomeCK AddBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
		{
            string sql =
				"INSERT BG_IncomeCK (EIID, DepID, IACkMon, IATime)" +
				"VALUES (@EIID, @DepID, @IACkMon, @IATime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EIID", bG_IncomeCK.EIID),
					new SqlParameter("@DepID", bG_IncomeCK.DepID),
					new SqlParameter("@IACkMon", bG_IncomeCK.IACkMon),
					new SqlParameter("@IATime", bG_IncomeCK.IATime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_IncomeCKByIKID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
		{
			return DeleteBG_IncomeCKByIKID( bG_IncomeCK.IKID );
		}

        public static bool DeleteBG_IncomeCKByIKID(int iKID)
		{
            string sql = "DELETE BG_IncomeCK WHERE IKID = @IKID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IKID", iKID)
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
					


        public static bool ModifyBG_IncomeCK(BG_IncomeCK bG_IncomeCK)
        {
            string sql =
                "UPDATE BG_IncomeCK " +
                "SET " +
	                "EIID = @EIID, " +
	                "DepID = @DepID, " +
	                "IACkMon = @IACkMon, " +
	                "IATime = @IATime " +
                "WHERE IKID = @IKID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IKID", bG_IncomeCK.IKID),
					new SqlParameter("@EIID", bG_IncomeCK.EIID),
					new SqlParameter("@DepID", bG_IncomeCK.DepID),
					new SqlParameter("@IACkMon", bG_IncomeCK.IACkMon),
					new SqlParameter("@IATime", bG_IncomeCK.IATime)
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


        public static DataTable GetAllBG_IncomeCK()
        {
            string sqlAll = "SELECT * FROM BG_IncomeCK";
			return GetBG_IncomeCKBySql( sqlAll );
        }
		

        public static BG_IncomeCK GetBG_IncomeCKByIKID(int iKID)
        {
            string sql = "SELECT * FROM BG_IncomeCK WHERE IKID = @IKID";

            try
            {
                SqlParameter para = new SqlParameter("@IKID", iKID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_IncomeCK bG_IncomeCK = new BG_IncomeCK();

                    bG_IncomeCK.IKID = dt.Rows[0]["IKID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IKID"];
                    bG_IncomeCK.EIID = dt.Rows[0]["EIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["EIID"];
                    bG_IncomeCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_IncomeCK.IACkMon = dt.Rows[0]["IACkMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IACkMon"];
                    bG_IncomeCK.IATime = dt.Rows[0]["IATime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["IATime"];
                    
                    return bG_IncomeCK;
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
	

      

        private static DataTable GetBG_IncomeCKBySql(string safeSql)
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
		
        private static DataTable GetBG_IncomeCKBySql(string sql, params SqlParameter[] values)
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
