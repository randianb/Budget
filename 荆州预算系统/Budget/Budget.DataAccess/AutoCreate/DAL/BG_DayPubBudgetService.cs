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
	public static partial class BG_DayPubBudgetService
	{
        public static BG_DayPubBudget AddBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
		{
            string sql =
				"INSERT BG_DayPubBudget (DPBYear, DepID, DPBTotal, DPBSubTotal, DPBOffCost, DPBWatEleCost, DPBPostCost, DPBCarMaiCost, DPBTraCost, DPBMaiCost, DPBMeetCost, DPBCulCost, DPBOffRecCost, DPBOffAbrCost, DPBTraUniCost, DPBWelCost, DPBComOther, DPBOffSubTotal, DPBOffEquAcqExp, DPBCapOther)" +
				"VALUES (@DPBYear, @DepID, @DPBTotal, @DPBSubTotal, @DPBOffCost, @DPBWatEleCost, @DPBPostCost, @DPBCarMaiCost, @DPBTraCost, @DPBMaiCost, @DPBMeetCost, @DPBCulCost, @DPBOffRecCost, @DPBOffAbrCost, @DPBTraUniCost, @DPBWelCost, @DPBComOther, @DPBOffSubTotal, @DPBOffEquAcqExp, @DPBCapOther)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DPBYear", bG_DayPubBudget.DPBYear),
					new SqlParameter("@DepID", bG_DayPubBudget.DepID),
					new SqlParameter("@DPBTotal", bG_DayPubBudget.DPBTotal),
					new SqlParameter("@DPBSubTotal", bG_DayPubBudget.DPBSubTotal),
					new SqlParameter("@DPBOffCost", bG_DayPubBudget.DPBOffCost),
					new SqlParameter("@DPBWatEleCost", bG_DayPubBudget.DPBWatEleCost),
					new SqlParameter("@DPBPostCost", bG_DayPubBudget.DPBPostCost),
					new SqlParameter("@DPBCarMaiCost", bG_DayPubBudget.DPBCarMaiCost),
					new SqlParameter("@DPBTraCost", bG_DayPubBudget.DPBTraCost),
					new SqlParameter("@DPBMaiCost", bG_DayPubBudget.DPBMaiCost),
					new SqlParameter("@DPBMeetCost", bG_DayPubBudget.DPBMeetCost),
					new SqlParameter("@DPBCulCost", bG_DayPubBudget.DPBCulCost),
					new SqlParameter("@DPBOffRecCost", bG_DayPubBudget.DPBOffRecCost),
					new SqlParameter("@DPBOffAbrCost", bG_DayPubBudget.DPBOffAbrCost),
					new SqlParameter("@DPBTraUniCost", bG_DayPubBudget.DPBTraUniCost),
					new SqlParameter("@DPBWelCost", bG_DayPubBudget.DPBWelCost),
					new SqlParameter("@DPBComOther", bG_DayPubBudget.DPBComOther),
					new SqlParameter("@DPBOffSubTotal", bG_DayPubBudget.DPBOffSubTotal),
					new SqlParameter("@DPBOffEquAcqExp", bG_DayPubBudget.DPBOffEquAcqExp),
					new SqlParameter("@DPBCapOther", bG_DayPubBudget.DPBCapOther)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_DayPubBudgetByDPBID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
		{
			return DeleteBG_DayPubBudgetByDPBID( bG_DayPubBudget.DPBID );
		}

        public static bool DeleteBG_DayPubBudgetByDPBID(int dPBID)
		{
            string sql = "DELETE BG_DayPubBudget WHERE DPBID = @DPBID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DPBID", dPBID)
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
					


        public static bool ModifyBG_DayPubBudget(BG_DayPubBudget bG_DayPubBudget)
        {
            string sql =
                "UPDATE BG_DayPubBudget " +
                "SET " +
	                "DPBYear = @DPBYear, " +
	                "DepID = @DepID, " +
	                "DPBTotal = @DPBTotal, " +
	                "DPBSubTotal = @DPBSubTotal, " +
	                "DPBOffCost = @DPBOffCost, " +
	                "DPBWatEleCost = @DPBWatEleCost, " +
	                "DPBPostCost = @DPBPostCost, " +
	                "DPBCarMaiCost = @DPBCarMaiCost, " +
	                "DPBTraCost = @DPBTraCost, " +
	                "DPBMaiCost = @DPBMaiCost, " +
	                "DPBMeetCost = @DPBMeetCost, " +
	                "DPBCulCost = @DPBCulCost, " +
	                "DPBOffRecCost = @DPBOffRecCost, " +
	                "DPBOffAbrCost = @DPBOffAbrCost, " +
	                "DPBTraUniCost = @DPBTraUniCost, " +
	                "DPBWelCost = @DPBWelCost, " +
	                "DPBComOther = @DPBComOther, " +
	                "DPBOffSubTotal = @DPBOffSubTotal, " +
	                "DPBOffEquAcqExp = @DPBOffEquAcqExp, " +
	                "DPBCapOther = @DPBCapOther " +
                "WHERE DPBID = @DPBID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DPBID", bG_DayPubBudget.DPBID),
					new SqlParameter("@DPBYear", bG_DayPubBudget.DPBYear),
					new SqlParameter("@DepID", bG_DayPubBudget.DepID),
					new SqlParameter("@DPBTotal", bG_DayPubBudget.DPBTotal),
					new SqlParameter("@DPBSubTotal", bG_DayPubBudget.DPBSubTotal),
					new SqlParameter("@DPBOffCost", bG_DayPubBudget.DPBOffCost),
					new SqlParameter("@DPBWatEleCost", bG_DayPubBudget.DPBWatEleCost),
					new SqlParameter("@DPBPostCost", bG_DayPubBudget.DPBPostCost),
					new SqlParameter("@DPBCarMaiCost", bG_DayPubBudget.DPBCarMaiCost),
					new SqlParameter("@DPBTraCost", bG_DayPubBudget.DPBTraCost),
					new SqlParameter("@DPBMaiCost", bG_DayPubBudget.DPBMaiCost),
					new SqlParameter("@DPBMeetCost", bG_DayPubBudget.DPBMeetCost),
					new SqlParameter("@DPBCulCost", bG_DayPubBudget.DPBCulCost),
					new SqlParameter("@DPBOffRecCost", bG_DayPubBudget.DPBOffRecCost),
					new SqlParameter("@DPBOffAbrCost", bG_DayPubBudget.DPBOffAbrCost),
					new SqlParameter("@DPBTraUniCost", bG_DayPubBudget.DPBTraUniCost),
					new SqlParameter("@DPBWelCost", bG_DayPubBudget.DPBWelCost),
					new SqlParameter("@DPBComOther", bG_DayPubBudget.DPBComOther),
					new SqlParameter("@DPBOffSubTotal", bG_DayPubBudget.DPBOffSubTotal),
					new SqlParameter("@DPBOffEquAcqExp", bG_DayPubBudget.DPBOffEquAcqExp),
					new SqlParameter("@DPBCapOther", bG_DayPubBudget.DPBCapOther)
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


        public static DataTable GetAllBG_DayPubBudget()
        {
            string sqlAll = "SELECT * FROM BG_DayPubBudget";
			return GetBG_DayPubBudgetBySql( sqlAll );
        }
		

        public static BG_DayPubBudget GetBG_DayPubBudgetByDPBID(int dPBID)
        {
            string sql = "SELECT * FROM BG_DayPubBudget WHERE DPBID = @DPBID";

            try
            {
                SqlParameter para = new SqlParameter("@DPBID", dPBID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_DayPubBudget bG_DayPubBudget = new BG_DayPubBudget();

                    bG_DayPubBudget.DPBID = dt.Rows[0]["DPBID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DPBID"];
                    bG_DayPubBudget.DPBYear = dt.Rows[0]["DPBYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DPBYear"];
                    bG_DayPubBudget.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_DayPubBudget.DPBTotal = dt.Rows[0]["DPBTotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBTotal"];
                    bG_DayPubBudget.DPBSubTotal = dt.Rows[0]["DPBSubTotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBSubTotal"];
                    bG_DayPubBudget.DPBOffCost = dt.Rows[0]["DPBOffCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBOffCost"];
                    bG_DayPubBudget.DPBWatEleCost = dt.Rows[0]["DPBWatEleCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBWatEleCost"];
                    bG_DayPubBudget.DPBPostCost = dt.Rows[0]["DPBPostCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBPostCost"];
                    bG_DayPubBudget.DPBCarMaiCost = dt.Rows[0]["DPBCarMaiCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBCarMaiCost"];
                    bG_DayPubBudget.DPBTraCost = dt.Rows[0]["DPBTraCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBTraCost"];
                    bG_DayPubBudget.DPBMaiCost = dt.Rows[0]["DPBMaiCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBMaiCost"];
                    bG_DayPubBudget.DPBMeetCost = dt.Rows[0]["DPBMeetCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBMeetCost"];
                    bG_DayPubBudget.DPBCulCost = dt.Rows[0]["DPBCulCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBCulCost"];
                    bG_DayPubBudget.DPBOffRecCost = dt.Rows[0]["DPBOffRecCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBOffRecCost"];
                    bG_DayPubBudget.DPBOffAbrCost = dt.Rows[0]["DPBOffAbrCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBOffAbrCost"];
                    bG_DayPubBudget.DPBTraUniCost = dt.Rows[0]["DPBTraUniCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBTraUniCost"];
                    bG_DayPubBudget.DPBWelCost = dt.Rows[0]["DPBWelCost"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBWelCost"];
                    bG_DayPubBudget.DPBComOther = dt.Rows[0]["DPBComOther"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBComOther"];
                    bG_DayPubBudget.DPBOffSubTotal = dt.Rows[0]["DPBOffSubTotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBOffSubTotal"];
                    bG_DayPubBudget.DPBOffEquAcqExp = dt.Rows[0]["DPBOffEquAcqExp"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBOffEquAcqExp"];
                    bG_DayPubBudget.DPBCapOther = dt.Rows[0]["DPBCapOther"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DPBCapOther"];
                    
                    return bG_DayPubBudget;
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
	

      

        private static DataTable GetBG_DayPubBudgetBySql(string safeSql)
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
		
        private static DataTable GetBG_DayPubBudgetBySql(string sql, params SqlParameter[] values)
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
