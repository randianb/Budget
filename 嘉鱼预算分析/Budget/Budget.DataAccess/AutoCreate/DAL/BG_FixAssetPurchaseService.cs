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
	public static partial class BG_FixAssetPurchaseService
	{
        public static BG_FixAssetPurchase AddBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
		{
            string sql =
				"INSERT BG_FixAssetPurchase (BudID, FAName, FAModel, FABrand, FAPrice, FANum, FAMon, FAIsGovPur, FAConfig, FARemark, FATime)" +
				"VALUES (@BudID, @FAName, @FAModel, @FABrand, @FAPrice, @FANum, @FAMon, @FAIsGovPur, @FAConfig, @FARemark, @FATime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", bG_FixAssetPurchase.BudID),
					new SqlParameter("@FAName", bG_FixAssetPurchase.FAName),
					new SqlParameter("@FAModel", bG_FixAssetPurchase.FAModel),
					new SqlParameter("@FABrand", bG_FixAssetPurchase.FABrand),
					new SqlParameter("@FAPrice", bG_FixAssetPurchase.FAPrice),
					new SqlParameter("@FANum", bG_FixAssetPurchase.FANum),
					new SqlParameter("@FAMon", bG_FixAssetPurchase.FAMon),
					new SqlParameter("@FAIsGovPur", bG_FixAssetPurchase.FAIsGovPur),
					new SqlParameter("@FAConfig", bG_FixAssetPurchase.FAConfig),
					new SqlParameter("@FARemark", bG_FixAssetPurchase.FARemark),
					new SqlParameter("@FATime", bG_FixAssetPurchase.FATime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_FixAssetPurchaseByFAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
		{
			return DeleteBG_FixAssetPurchaseByFAID( bG_FixAssetPurchase.FAID );
		}

        public static bool DeleteBG_FixAssetPurchaseByFAID(int fAID)
		{
            string sql = "DELETE BG_FixAssetPurchase WHERE FAID = @FAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", fAID)
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
					


        public static bool ModifyBG_FixAssetPurchase(BG_FixAssetPurchase bG_FixAssetPurchase)
        {
            string sql =
                "UPDATE BG_FixAssetPurchase " +
                "SET " +
	                "BudID = @BudID, " +
	                "FAName = @FAName, " +
	                "FAModel = @FAModel, " +
	                "FABrand = @FABrand, " +
	                "FAPrice = @FAPrice, " +
	                "FANum = @FANum, " +
	                "FAMon = @FAMon, " +
	                "FAIsGovPur = @FAIsGovPur, " +
	                "FAConfig = @FAConfig, " +
	                "FARemark = @FARemark, " +
	                "FATime = @FATime " +
                "WHERE FAID = @FAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAID", bG_FixAssetPurchase.FAID),
					new SqlParameter("@BudID", bG_FixAssetPurchase.BudID),
					new SqlParameter("@FAName", bG_FixAssetPurchase.FAName),
					new SqlParameter("@FAModel", bG_FixAssetPurchase.FAModel),
					new SqlParameter("@FABrand", bG_FixAssetPurchase.FABrand),
					new SqlParameter("@FAPrice", bG_FixAssetPurchase.FAPrice),
					new SqlParameter("@FANum", bG_FixAssetPurchase.FANum),
					new SqlParameter("@FAMon", bG_FixAssetPurchase.FAMon),
					new SqlParameter("@FAIsGovPur", bG_FixAssetPurchase.FAIsGovPur),
					new SqlParameter("@FAConfig", bG_FixAssetPurchase.FAConfig),
					new SqlParameter("@FARemark", bG_FixAssetPurchase.FARemark),
					new SqlParameter("@FATime", bG_FixAssetPurchase.FATime)
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


        public static DataTable GetAllBG_FixAssetPurchase()
        {
            string sqlAll = "SELECT * FROM BG_FixAssetPurchase";
			return GetBG_FixAssetPurchaseBySql( sqlAll );
        }
		

        public static BG_FixAssetPurchase GetBG_FixAssetPurchaseByFAID(int fAID)
        {
            string sql = "SELECT * FROM BG_FixAssetPurchase WHERE FAID = @FAID";

            try
            {
                SqlParameter para = new SqlParameter("@FAID", fAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_FixAssetPurchase bG_FixAssetPurchase = new BG_FixAssetPurchase();

                    bG_FixAssetPurchase.FAID = dt.Rows[0]["FAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAID"];
                    bG_FixAssetPurchase.BudID = dt.Rows[0]["BudID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudID"];
                    bG_FixAssetPurchase.FAName = dt.Rows[0]["FAName"] == DBNull.Value ? "" : (string)dt.Rows[0]["FAName"];
                    bG_FixAssetPurchase.FAModel = dt.Rows[0]["FAModel"] == DBNull.Value ? "" : (string)dt.Rows[0]["FAModel"];
                    bG_FixAssetPurchase.FABrand = dt.Rows[0]["FABrand"] == DBNull.Value ? "" : (string)dt.Rows[0]["FABrand"];
                    bG_FixAssetPurchase.FAPrice = dt.Rows[0]["FAPrice"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["FAPrice"];
                    bG_FixAssetPurchase.FANum = dt.Rows[0]["FANum"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FANum"];
                    bG_FixAssetPurchase.FAMon = dt.Rows[0]["FAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["FAMon"];
                    bG_FixAssetPurchase.FAIsGovPur = dt.Rows[0]["FAIsGovPur"] == DBNull.Value ? "" : (string)dt.Rows[0]["FAIsGovPur"];
                    bG_FixAssetPurchase.FAConfig = dt.Rows[0]["FAConfig"] == DBNull.Value ? "" : (string)dt.Rows[0]["FAConfig"];
                    bG_FixAssetPurchase.FARemark = dt.Rows[0]["FARemark"] == DBNull.Value ? "" : (string)dt.Rows[0]["FARemark"];
                    bG_FixAssetPurchase.FATime = dt.Rows[0]["FATime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["FATime"];
                    
                    return bG_FixAssetPurchase;
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
	

      

        private static DataTable GetBG_FixAssetPurchaseBySql(string safeSql)
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
		
        private static DataTable GetBG_FixAssetPurchaseBySql(string sql, params SqlParameter[] values)
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
