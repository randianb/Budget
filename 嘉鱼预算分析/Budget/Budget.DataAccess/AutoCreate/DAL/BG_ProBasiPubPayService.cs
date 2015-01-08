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
	public static partial class BG_ProBasiPubPayService
	{
        public static BG_ProBasiPubPay AddBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
		{
            string sql =
				"INSERT BG_ProBasiPubPay (DepID, PBYear, PBOE, PBUtilities, PBPF, OBCFE, PBTravelE, PBRE, PBME, PBTrainE, OBRE, PBAE, LUMD, PBWE, PBOCE, OOPE, OCASE, PBIDTitol)" +
				"VALUES (@DepID, @PBYear, @PBOE, @PBUtilities, @PBPF, @OBCFE, @PBTravelE, @PBRE, @PBME, @PBTrainE, @OBRE, @PBAE, @LUMD, @PBWE, @PBOCE, @OOPE, @OCASE, @PBIDTitol)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_ProBasiPubPay.DepID),
					new SqlParameter("@PBYear", bG_ProBasiPubPay.PBYear),
					new SqlParameter("@PBOE", bG_ProBasiPubPay.PBOE),
					new SqlParameter("@PBUtilities", bG_ProBasiPubPay.PBUtilities),
					new SqlParameter("@PBPF", bG_ProBasiPubPay.PBPF),
					new SqlParameter("@OBCFE", bG_ProBasiPubPay.OBCFE),
					new SqlParameter("@PBTravelE", bG_ProBasiPubPay.PBTravelE),
					new SqlParameter("@PBRE", bG_ProBasiPubPay.PBRE),
					new SqlParameter("@PBME", bG_ProBasiPubPay.PBME),
					new SqlParameter("@PBTrainE", bG_ProBasiPubPay.PBTrainE),
					new SqlParameter("@OBRE", bG_ProBasiPubPay.OBRE),
					new SqlParameter("@PBAE", bG_ProBasiPubPay.PBAE),
					new SqlParameter("@LUMD", bG_ProBasiPubPay.LUMD),
					new SqlParameter("@PBWE", bG_ProBasiPubPay.PBWE),
					new SqlParameter("@PBOCE", bG_ProBasiPubPay.PBOCE),
					new SqlParameter("@OOPE", bG_ProBasiPubPay.OOPE),
					new SqlParameter("@OCASE", bG_ProBasiPubPay.OCASE),
					new SqlParameter("@PBIDTitol", bG_ProBasiPubPay.PBIDTitol)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProBasiPubPayByPBID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
		{
			return DeleteBG_ProBasiPubPayByPBID( bG_ProBasiPubPay.PBID );
		}

        public static bool DeleteBG_ProBasiPubPayByPBID(int pBID)
		{
            string sql = "DELETE BG_ProBasiPubPay WHERE PBID = @PBID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PBID", pBID)
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
					


        public static bool ModifyBG_ProBasiPubPay(BG_ProBasiPubPay bG_ProBasiPubPay)
        {
            string sql =
                "UPDATE BG_ProBasiPubPay " +
                "SET " +
	                "DepID = @DepID, " +
	                "PBYear = @PBYear, " +
	                "PBOE = @PBOE, " +
	                "PBUtilities = @PBUtilities, " +
	                "PBPF = @PBPF, " +
	                "OBCFE = @OBCFE, " +
	                "PBTravelE = @PBTravelE, " +
	                "PBRE = @PBRE, " +
	                "PBME = @PBME, " +
	                "PBTrainE = @PBTrainE, " +
	                "OBRE = @OBRE, " +
	                "PBAE = @PBAE, " +
	                "LUMD = @LUMD, " +
	                "PBWE = @PBWE, " +
	                "PBOCE = @PBOCE, " +
	                "OOPE = @OOPE, " +
	                "OCASE = @OCASE, " +
	                "PBIDTitol = @PBIDTitol " +
                "WHERE PBID = @PBID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PBID", bG_ProBasiPubPay.PBID),
					new SqlParameter("@DepID", bG_ProBasiPubPay.DepID),
					new SqlParameter("@PBYear", bG_ProBasiPubPay.PBYear),
					new SqlParameter("@PBOE", bG_ProBasiPubPay.PBOE),
					new SqlParameter("@PBUtilities", bG_ProBasiPubPay.PBUtilities),
					new SqlParameter("@PBPF", bG_ProBasiPubPay.PBPF),
					new SqlParameter("@OBCFE", bG_ProBasiPubPay.OBCFE),
					new SqlParameter("@PBTravelE", bG_ProBasiPubPay.PBTravelE),
					new SqlParameter("@PBRE", bG_ProBasiPubPay.PBRE),
					new SqlParameter("@PBME", bG_ProBasiPubPay.PBME),
					new SqlParameter("@PBTrainE", bG_ProBasiPubPay.PBTrainE),
					new SqlParameter("@OBRE", bG_ProBasiPubPay.OBRE),
					new SqlParameter("@PBAE", bG_ProBasiPubPay.PBAE),
					new SqlParameter("@LUMD", bG_ProBasiPubPay.LUMD),
					new SqlParameter("@PBWE", bG_ProBasiPubPay.PBWE),
					new SqlParameter("@PBOCE", bG_ProBasiPubPay.PBOCE),
					new SqlParameter("@OOPE", bG_ProBasiPubPay.OOPE),
					new SqlParameter("@OCASE", bG_ProBasiPubPay.OCASE),
					new SqlParameter("@PBIDTitol", bG_ProBasiPubPay.PBIDTitol)
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


        public static DataTable GetAllBG_ProBasiPubPay()
        {
            string sqlAll = "SELECT * FROM BG_ProBasiPubPay";
			return GetBG_ProBasiPubPayBySql( sqlAll );
        }
		

        public static BG_ProBasiPubPay GetBG_ProBasiPubPayByPBID(int pBID)
        {
            string sql = "SELECT * FROM BG_ProBasiPubPay WHERE PBID = @PBID";

            try
            {
                SqlParameter para = new SqlParameter("@PBID", pBID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ProBasiPubPay bG_ProBasiPubPay = new BG_ProBasiPubPay();

                    bG_ProBasiPubPay.PBID = dt.Rows[0]["PBID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PBID"];
                    bG_ProBasiPubPay.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_ProBasiPubPay.PBYear = dt.Rows[0]["PBYear"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["PBYear"];
                    bG_ProBasiPubPay.PBOE = dt.Rows[0]["PBOE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBOE"];
                    bG_ProBasiPubPay.PBUtilities = dt.Rows[0]["PBUtilities"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBUtilities"];
                    bG_ProBasiPubPay.PBPF = dt.Rows[0]["PBPF"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBPF"];
                    bG_ProBasiPubPay.OBCFE = dt.Rows[0]["OBCFE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OBCFE"];
                    bG_ProBasiPubPay.PBTravelE = dt.Rows[0]["PBTravelE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBTravelE"];
                    bG_ProBasiPubPay.PBRE = dt.Rows[0]["PBRE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBRE"];
                    bG_ProBasiPubPay.PBME = dt.Rows[0]["PBME"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBME"];
                    bG_ProBasiPubPay.PBTrainE = dt.Rows[0]["PBTrainE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBTrainE"];
                    bG_ProBasiPubPay.OBRE = dt.Rows[0]["OBRE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OBRE"];
                    bG_ProBasiPubPay.PBAE = dt.Rows[0]["PBAE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBAE"];
                    bG_ProBasiPubPay.LUMD = dt.Rows[0]["LUMD"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["LUMD"];
                    bG_ProBasiPubPay.PBWE = dt.Rows[0]["PBWE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBWE"];
                    bG_ProBasiPubPay.PBOCE = dt.Rows[0]["PBOCE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBOCE"];
                    bG_ProBasiPubPay.OOPE = dt.Rows[0]["OOPE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OOPE"];
                    bG_ProBasiPubPay.OCASE = dt.Rows[0]["OCASE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OCASE"];
                    bG_ProBasiPubPay.PBIDTitol = dt.Rows[0]["PBIDTitol"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PBIDTitol"];
                    
                    return bG_ProBasiPubPay;
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
	

      

        private static DataTable GetBG_ProBasiPubPayBySql(string safeSql)
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
		
        private static DataTable GetBG_ProBasiPubPayBySql(string sql, params SqlParameter[] values)
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
