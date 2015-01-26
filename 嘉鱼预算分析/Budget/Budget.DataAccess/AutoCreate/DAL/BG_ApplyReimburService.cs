//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/22 11:04:07
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_ApplyReimburService
	{
        public static BG_ApplyReimbur AddBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
		{
            string sql =
				"INSERT BG_ApplyReimbur (DepID, ARTime, ARReiSinNum, PPID, ARExpType, ARRepDep, ARAgent, ARMon, ARExcu, ARListSta, ARReason)" +
				"VALUES (@DepID, @ARTime, @ARReiSinNum, @PPID, @ARExpType, @ARRepDep, @ARAgent, @ARMon, @ARExcu, @ARListSta, @ARReason)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_ApplyReimbur.DepID),
					new SqlParameter("@ARTime", bG_ApplyReimbur.ARTime),
					new SqlParameter("@ARReiSinNum", bG_ApplyReimbur.ARReiSinNum),
					new SqlParameter("@PPID", bG_ApplyReimbur.PPID),
					new SqlParameter("@ARExpType", bG_ApplyReimbur.ARExpType),
					new SqlParameter("@ARRepDep", bG_ApplyReimbur.ARRepDep),
					new SqlParameter("@ARAgent", bG_ApplyReimbur.ARAgent),
					new SqlParameter("@ARMon", bG_ApplyReimbur.ARMon),
					new SqlParameter("@ARExcu", bG_ApplyReimbur.ARExcu),
					new SqlParameter("@ARListSta", bG_ApplyReimbur.ARListSta),
					new SqlParameter("@ARReason", bG_ApplyReimbur.ARReason)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ApplyReimburByARID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
		{
			return DeleteBG_ApplyReimburByARID( bG_ApplyReimbur.ARID );
		}

        public static bool DeleteBG_ApplyReimburByARID(int aRID)
		{
            string sql = "DELETE BG_ApplyReimbur WHERE ARID = @ARID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ARID", aRID)
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
					


        public static bool ModifyBG_ApplyReimbur(BG_ApplyReimbur bG_ApplyReimbur)
        {
            string sql =
                "UPDATE BG_ApplyReimbur " +
                "SET " +
	                "DepID = @DepID, " +
	                "ARTime = @ARTime, " +
	                "ARReiSinNum = @ARReiSinNum, " +
	                "PPID = @PPID, " +
	                "ARExpType = @ARExpType, " +
	                "ARRepDep = @ARRepDep, " +
	                "ARAgent = @ARAgent, " +
	                "ARMon = @ARMon, " +
	                "ARExcu = @ARExcu, " +
	                "ARListSta = @ARListSta, " +
	                "ARReason = @ARReason " +
                "WHERE ARID = @ARID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ARID", bG_ApplyReimbur.ARID),
					new SqlParameter("@DepID", bG_ApplyReimbur.DepID),
					new SqlParameter("@ARTime", bG_ApplyReimbur.ARTime),
					new SqlParameter("@ARReiSinNum", bG_ApplyReimbur.ARReiSinNum),
					new SqlParameter("@PPID", bG_ApplyReimbur.PPID),
					new SqlParameter("@ARExpType", bG_ApplyReimbur.ARExpType),
					new SqlParameter("@ARRepDep", bG_ApplyReimbur.ARRepDep),
					new SqlParameter("@ARAgent", bG_ApplyReimbur.ARAgent),
					new SqlParameter("@ARMon", bG_ApplyReimbur.ARMon),
					new SqlParameter("@ARExcu", bG_ApplyReimbur.ARExcu),
					new SqlParameter("@ARListSta", bG_ApplyReimbur.ARListSta),
					new SqlParameter("@ARReason", bG_ApplyReimbur.ARReason)
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


        public static DataTable GetAllBG_ApplyReimbur()
        {
            string sqlAll = "SELECT * FROM BG_ApplyReimbur";
			return GetBG_ApplyReimburBySql( sqlAll );
        }
		

        public static BG_ApplyReimbur GetBG_ApplyReimburByARID(int aRID)
        {
            string sql = "SELECT * FROM BG_ApplyReimbur WHERE ARID = @ARID";

            try
            {
                SqlParameter para = new SqlParameter("@ARID", aRID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ApplyReimbur bG_ApplyReimbur = new BG_ApplyReimbur();

                    bG_ApplyReimbur.ARID = dt.Rows[0]["ARID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ARID"];
                    bG_ApplyReimbur.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_ApplyReimbur.ARTime = dt.Rows[0]["ARTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ARTime"];
                    bG_ApplyReimbur.ARReiSinNum = dt.Rows[0]["ARReiSinNum"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARReiSinNum"];
                    bG_ApplyReimbur.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_ApplyReimbur.ARExpType = dt.Rows[0]["ARExpType"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARExpType"];
                    bG_ApplyReimbur.ARRepDep = dt.Rows[0]["ARRepDep"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARRepDep"];
                    bG_ApplyReimbur.ARAgent = dt.Rows[0]["ARAgent"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARAgent"];
                    bG_ApplyReimbur.ARMon = dt.Rows[0]["ARMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ARMon"];
                    bG_ApplyReimbur.ARExcu = dt.Rows[0]["ARExcu"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARExcu"];
                    bG_ApplyReimbur.ARListSta = dt.Rows[0]["ARListSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARListSta"];
                    bG_ApplyReimbur.ARReason = dt.Rows[0]["ARReason"] == DBNull.Value ? "" : (string)dt.Rows[0]["ARReason"];
                    
                    return bG_ApplyReimbur;
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
	

      

        private static DataTable GetBG_ApplyReimburBySql(string safeSql)
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
		
        private static DataTable GetBG_ApplyReimburBySql(string sql, params SqlParameter[] values)
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
