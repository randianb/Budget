//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_ReimAppendixService
	{
        public static BG_ReimAppendix AddBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
		{
            string sql =
				"INSERT BG_ReimAppendix (ARID, ARType, ARName, ARContent, ARTime)" +
				"VALUES (@ARID, @ARType, @ARName, @ARContent, @ARTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ARID", bG_ReimAppendix.ARID),
					new SqlParameter("@ARType", bG_ReimAppendix.ARType),
					new SqlParameter("@ARName", bG_ReimAppendix.ARName),
					new SqlParameter("@ARContent", bG_ReimAppendix.ARContent),
					new SqlParameter("@ARTime", bG_ReimAppendix.ARTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ReimAppendixByRADID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
		{
			return DeleteBG_ReimAppendixByRADID( bG_ReimAppendix.RADID );
		}

        public static bool DeleteBG_ReimAppendixByRADID(int rADID)
		{
            string sql = "DELETE BG_ReimAppendix WHERE RADID = @RADID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RADID", rADID)
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
					


        public static bool ModifyBG_ReimAppendix(BG_ReimAppendix bG_ReimAppendix)
        {
            string sql =
                "UPDATE BG_ReimAppendix " +
                "SET " +
	                "ARID = @ARID, " +
	                "ARType = @ARType, " +
	                "ARName = @ARName, " +
	                "ARContent = @ARContent, " +
	                "ARTime = @ARTime " +
                "WHERE RADID = @RADID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RADID", bG_ReimAppendix.RADID),
					new SqlParameter("@ARID", bG_ReimAppendix.ARID),
					new SqlParameter("@ARType", bG_ReimAppendix.ARType),
					new SqlParameter("@ARName", bG_ReimAppendix.ARName),
					new SqlParameter("@ARContent", bG_ReimAppendix.ARContent),
					new SqlParameter("@ARTime", bG_ReimAppendix.ARTime)
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


        public static DataTable GetAllBG_ReimAppendix()
        {
            string sqlAll = "SELECT * FROM BG_ReimAppendix";
			return GetBG_ReimAppendixBySql( sqlAll );
        }
		

        public static BG_ReimAppendix GetBG_ReimAppendixByRADID(int rADID)
        {
            string sql = "SELECT * FROM BG_ReimAppendix WHERE RADID = @RADID";

            try
            {
                SqlParameter para = new SqlParameter("@RADID", rADID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ReimAppendix bG_ReimAppendix = new BG_ReimAppendix();

                    bG_ReimAppendix.RADID = dt.Rows[0]["RADID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["RADID"];
                    bG_ReimAppendix.ARID = dt.Rows[0]["ARID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ARID"];
                    bG_ReimAppendix.ARType = dt.Rows[0]["ARType"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARType"];
                    bG_ReimAppendix.ARName = dt.Rows[0]["ARName"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARName"];
                    bG_ReimAppendix.ARContent = dt.Rows[0]["ARContent"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARContent"];
                    bG_ReimAppendix.ARTime = dt.Rows[0]["ARTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ARTime"];
                    
                    return bG_ReimAppendix;
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
	

      

        private static DataTable GetBG_ReimAppendixBySql(string safeSql)
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
		
        private static DataTable GetBG_ReimAppendixBySql(string sql, params SqlParameter[] values)
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
