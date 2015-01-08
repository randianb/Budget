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
	public static partial class BG_IncomeAnaService
	{
        public static BG_IncomeAna AddBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
		{
            string sql =
				"INSERT BG_IncomeAna (EIID, DepID, IABudMon, IAAudMon, IACkMon, IAYear)" +
				"VALUES (@EIID, @DepID, @IABudMon, @IAAudMon, @IACkMon, @IAYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EIID", bG_IncomeAna.EIID),
					new SqlParameter("@DepID", bG_IncomeAna.DepID),
					new SqlParameter("@IABudMon", bG_IncomeAna.IABudMon),
					new SqlParameter("@IAAudMon", bG_IncomeAna.IAAudMon),
					new SqlParameter("@IACkMon", bG_IncomeAna.IACkMon),
					new SqlParameter("@IAYear", bG_IncomeAna.IAYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_IncomeAnaByIAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
		{
			return DeleteBG_IncomeAnaByIAID( bG_IncomeAna.IAID );
		}

        public static bool DeleteBG_IncomeAnaByIAID(int iAID)
		{
            string sql = "DELETE BG_IncomeAna WHERE IAID = @IAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IAID", iAID)
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
					


        public static bool ModifyBG_IncomeAna(BG_IncomeAna bG_IncomeAna)
        {
            string sql =
                "UPDATE BG_IncomeAna " +
                "SET " +
	                "EIID = @EIID, " +
	                "DepID = @DepID, " +
	                "IABudMon = @IABudMon, " +
	                "IAAudMon = @IAAudMon, " +
	                "IACkMon = @IACkMon, " +
	                "IAYear = @IAYear " +
                "WHERE IAID = @IAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IAID", bG_IncomeAna.IAID),
					new SqlParameter("@EIID", bG_IncomeAna.EIID),
					new SqlParameter("@DepID", bG_IncomeAna.DepID),
					new SqlParameter("@IABudMon", bG_IncomeAna.IABudMon),
					new SqlParameter("@IAAudMon", bG_IncomeAna.IAAudMon),
					new SqlParameter("@IACkMon", bG_IncomeAna.IACkMon),
					new SqlParameter("@IAYear", bG_IncomeAna.IAYear)
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


        public static DataTable GetAllBG_IncomeAna()
        {
            string sqlAll = "SELECT * FROM BG_IncomeAna";
			return GetBG_IncomeAnaBySql( sqlAll );
        }
		

        public static BG_IncomeAna GetBG_IncomeAnaByIAID(int iAID)
        {
            string sql = "SELECT * FROM BG_IncomeAna WHERE IAID = @IAID";

            try
            {
                SqlParameter para = new SqlParameter("@IAID", iAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_IncomeAna bG_IncomeAna = new BG_IncomeAna();

                    bG_IncomeAna.IAID = dt.Rows[0]["IAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAID"];
                    bG_IncomeAna.EIID = dt.Rows[0]["EIID"] == DBNull.Value ? "" : (string)dt.Rows[0]["EIID"];
                    bG_IncomeAna.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepID"];
                    bG_IncomeAna.IABudMon = dt.Rows[0]["IABudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IABudMon"];
                    bG_IncomeAna.IAAudMon = dt.Rows[0]["IAAudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IAAudMon"];
                    bG_IncomeAna.IACkMon = dt.Rows[0]["IACkMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IACkMon"];
                    bG_IncomeAna.IAYear = dt.Rows[0]["IAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAYear"];
                    
                    return bG_IncomeAna;
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
	

      

        private static DataTable GetBG_IncomeAnaBySql(string safeSql)
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
		
        private static DataTable GetBG_IncomeAnaBySql(string sql, params SqlParameter[] values)
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
