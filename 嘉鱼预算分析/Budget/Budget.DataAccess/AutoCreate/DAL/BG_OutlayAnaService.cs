//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_OutlayAnaService
	{
        public static BG_OutlayAna AddBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
		{
            string sql =
				"INSERT BG_OutlayAna (PIID, PPID, DepID, OABudMon, OAAudMon, OACkMon, OAType, OAYear, Mark)" +
				"VALUES (@PIID, @PPID, @DepID, @OABudMon, @OAAudMon, @OACkMon, @OAType, @OAYear, @Mark)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_OutlayAna.PIID),
					new SqlParameter("@PPID", bG_OutlayAna.PPID),
					new SqlParameter("@DepID", bG_OutlayAna.DepID),
					new SqlParameter("@OABudMon", bG_OutlayAna.OABudMon),
					new SqlParameter("@OAAudMon", bG_OutlayAna.OAAudMon),
					new SqlParameter("@OACkMon", bG_OutlayAna.OACkMon),
					new SqlParameter("@OAType", bG_OutlayAna.OAType),
					new SqlParameter("@OAYear", bG_OutlayAna.OAYear),
					new SqlParameter("@Mark", bG_OutlayAna.Mark)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_OutlayAnaByOAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
		{
			return DeleteBG_OutlayAnaByOAID( bG_OutlayAna.OAID );
		}

        public static bool DeleteBG_OutlayAnaByOAID(int oAID)
		{
            string sql = "DELETE BG_OutlayAna WHERE OAID = @OAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OAID", oAID)
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
					


        public static bool ModifyBG_OutlayAna(BG_OutlayAna bG_OutlayAna)
        {
            string sql =
                "UPDATE BG_OutlayAna " +
                "SET " +
	                "PIID = @PIID, " +
	                "PPID = @PPID, " +
	                "DepID = @DepID, " +
	                "OABudMon = @OABudMon, " +
	                "OAAudMon = @OAAudMon, " +
	                "OACkMon = @OACkMon, " +
	                "OAType = @OAType, " +
	                "OAYear = @OAYear, " +
	                "Mark = @Mark " +
                "WHERE OAID = @OAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@OAID", bG_OutlayAna.OAID),
					new SqlParameter("@PIID", bG_OutlayAna.PIID),
					new SqlParameter("@PPID", bG_OutlayAna.PPID),
					new SqlParameter("@DepID", bG_OutlayAna.DepID),
					new SqlParameter("@OABudMon", bG_OutlayAna.OABudMon),
					new SqlParameter("@OAAudMon", bG_OutlayAna.OAAudMon),
					new SqlParameter("@OACkMon", bG_OutlayAna.OACkMon),
					new SqlParameter("@OAType", bG_OutlayAna.OAType),
					new SqlParameter("@OAYear", bG_OutlayAna.OAYear),
					new SqlParameter("@Mark", bG_OutlayAna.Mark)
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


        public static DataTable GetAllBG_OutlayAna()
        {
            string sqlAll = "SELECT * FROM BG_OutlayAna";
			return GetBG_OutlayAnaBySql( sqlAll );
        }
		

        public static BG_OutlayAna GetBG_OutlayAnaByOAID(int oAID)
        {
            string sql = "SELECT * FROM BG_OutlayAna WHERE OAID = @OAID";

            try
            {
                SqlParameter para = new SqlParameter("@OAID", oAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_OutlayAna bG_OutlayAna = new BG_OutlayAna();

                    bG_OutlayAna.OAID = dt.Rows[0]["OAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OAID"];
                    bG_OutlayAna.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_OutlayAna.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_OutlayAna.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_OutlayAna.OABudMon = dt.Rows[0]["OABudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OABudMon"];
                    bG_OutlayAna.OAAudMon = dt.Rows[0]["OAAudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OAAudMon"];
                    bG_OutlayAna.OACkMon = dt.Rows[0]["OACkMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OACkMon"];
                    bG_OutlayAna.OAType = dt.Rows[0]["OAType"] == DBNull.Value ? "" : (string)dt.Rows[0]["OAType"];
                    bG_OutlayAna.OAYear = dt.Rows[0]["OAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OAYear"];
                    bG_OutlayAna.Mark = dt.Rows[0]["Mark"] == DBNull.Value ? "" : (string)dt.Rows[0]["Mark"];
                    
                    return bG_OutlayAna;
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
	

      

        private static DataTable GetBG_OutlayAnaBySql(string safeSql)
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
		
        private static DataTable GetBG_OutlayAnaBySql(string sql, params SqlParameter[] values)
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
