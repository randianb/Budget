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
	public static partial class BG_BudItemsLibrariesService
	{
        public static BG_BudItemsLibraries AddBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
		{
            string sql =
				"INSERT BG_BudItemsLibraries (BILProType, BILFunSub, PPID, PIID, BILAttr, BILAppReaCon, BILExpGistExp, BILLongGoal, BILYearGoal, BILMon, BILMonSou, BILFinAllo, BILLastYearCarry, BILOthFun, BILOthExpProb, DepID, BILProName, BILProDescrip, BILProCategory)" +
				"VALUES (@BILProType, @BILFunSub, @PPID, @PIID, @BILAttr, @BILAppReaCon, @BILExpGistExp, @BILLongGoal, @BILYearGoal, @BILMon, @BILMonSou, @BILFinAllo, @BILLastYearCarry, @BILOthFun, @BILOthExpProb, @DepID, @BILProName, @BILProDescrip, @BILProCategory)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BILProType", bG_BudItemsLibraries.BILProType),
					new SqlParameter("@BILFunSub", bG_BudItemsLibraries.BILFunSub),
					new SqlParameter("@PPID", bG_BudItemsLibraries.PPID),
					new SqlParameter("@PIID", bG_BudItemsLibraries.PIID),
					new SqlParameter("@BILAttr", bG_BudItemsLibraries.BILAttr),
					new SqlParameter("@BILAppReaCon", bG_BudItemsLibraries.BILAppReaCon),
					new SqlParameter("@BILExpGistExp", bG_BudItemsLibraries.BILExpGistExp),
					new SqlParameter("@BILLongGoal", bG_BudItemsLibraries.BILLongGoal),
					new SqlParameter("@BILYearGoal", bG_BudItemsLibraries.BILYearGoal),
					new SqlParameter("@BILMon", bG_BudItemsLibraries.BILMon),
					new SqlParameter("@BILMonSou", bG_BudItemsLibraries.BILMonSou),
					new SqlParameter("@BILFinAllo", bG_BudItemsLibraries.BILFinAllo),
					new SqlParameter("@BILLastYearCarry", bG_BudItemsLibraries.BILLastYearCarry),
					new SqlParameter("@BILOthFun", bG_BudItemsLibraries.BILOthFun),
					new SqlParameter("@BILOthExpProb", bG_BudItemsLibraries.BILOthExpProb),
					new SqlParameter("@DepID", bG_BudItemsLibraries.DepID),
					new SqlParameter("@BILProName", bG_BudItemsLibraries.BILProName),
					new SqlParameter("@BILProDescrip", bG_BudItemsLibraries.BILProDescrip),
					new SqlParameter("@BILProCategory", bG_BudItemsLibraries.BILProCategory)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudItemsLibrariesByBudItID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
		{
			return DeleteBG_BudItemsLibrariesByBudItID( bG_BudItemsLibraries.BudItID );
		}

        public static bool DeleteBG_BudItemsLibrariesByBudItID(int budItID)
		{
            string sql = "DELETE BG_BudItemsLibraries WHERE BudItID = @BudItID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudItID", budItID)
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
					


        public static bool ModifyBG_BudItemsLibraries(BG_BudItemsLibraries bG_BudItemsLibraries)
        {
            string sql =
                "UPDATE BG_BudItemsLibraries " +
                "SET " +
	                "BILProType = @BILProType, " +
	                "BILFunSub = @BILFunSub, " +
	                "PPID = @PPID, " +
	                "PIID = @PIID, " +
	                "BILAttr = @BILAttr, " +
	                "BILAppReaCon = @BILAppReaCon, " +
	                "BILExpGistExp = @BILExpGistExp, " +
	                "BILLongGoal = @BILLongGoal, " +
	                "BILYearGoal = @BILYearGoal, " +
	                "BILMon = @BILMon, " +
	                "BILMonSou = @BILMonSou, " +
	                "BILFinAllo = @BILFinAllo, " +
	                "BILLastYearCarry = @BILLastYearCarry, " +
	                "BILOthFun = @BILOthFun, " +
	                "BILOthExpProb = @BILOthExpProb, " +
	                "DepID = @DepID, " +
	                "BILProName = @BILProName, " +
	                "BILProDescrip = @BILProDescrip, " +
	                "BILProCategory = @BILProCategory " +
                "WHERE BudItID = @BudItID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudItID", bG_BudItemsLibraries.BudItID),
					new SqlParameter("@BILProType", bG_BudItemsLibraries.BILProType),
					new SqlParameter("@BILFunSub", bG_BudItemsLibraries.BILFunSub),
					new SqlParameter("@PPID", bG_BudItemsLibraries.PPID),
					new SqlParameter("@PIID", bG_BudItemsLibraries.PIID),
					new SqlParameter("@BILAttr", bG_BudItemsLibraries.BILAttr),
					new SqlParameter("@BILAppReaCon", bG_BudItemsLibraries.BILAppReaCon),
					new SqlParameter("@BILExpGistExp", bG_BudItemsLibraries.BILExpGistExp),
					new SqlParameter("@BILLongGoal", bG_BudItemsLibraries.BILLongGoal),
					new SqlParameter("@BILYearGoal", bG_BudItemsLibraries.BILYearGoal),
					new SqlParameter("@BILMon", bG_BudItemsLibraries.BILMon),
					new SqlParameter("@BILMonSou", bG_BudItemsLibraries.BILMonSou),
					new SqlParameter("@BILFinAllo", bG_BudItemsLibraries.BILFinAllo),
					new SqlParameter("@BILLastYearCarry", bG_BudItemsLibraries.BILLastYearCarry),
					new SqlParameter("@BILOthFun", bG_BudItemsLibraries.BILOthFun),
					new SqlParameter("@BILOthExpProb", bG_BudItemsLibraries.BILOthExpProb),
					new SqlParameter("@DepID", bG_BudItemsLibraries.DepID),
					new SqlParameter("@BILProName", bG_BudItemsLibraries.BILProName),
					new SqlParameter("@BILProDescrip", bG_BudItemsLibraries.BILProDescrip),
					new SqlParameter("@BILProCategory", bG_BudItemsLibraries.BILProCategory)
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


        public static DataTable GetAllBG_BudItemsLibraries()
        {
            string sqlAll = "SELECT * FROM BG_BudItemsLibraries";
			return GetBG_BudItemsLibrariesBySql( sqlAll );
        }
		

        public static BG_BudItemsLibraries GetBG_BudItemsLibrariesByBudItID(int budItID)
        {
            string sql = "SELECT * FROM BG_BudItemsLibraries WHERE BudItID = @BudItID";

            try
            {
                SqlParameter para = new SqlParameter("@BudItID", budItID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudItemsLibraries bG_BudItemsLibraries = new BG_BudItemsLibraries();

                    bG_BudItemsLibraries.BudItID = dt.Rows[0]["BudItID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudItID"];
                    bG_BudItemsLibraries.BILProType = dt.Rows[0]["BILProType"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILProType"];
                    bG_BudItemsLibraries.BILFunSub = dt.Rows[0]["BILFunSub"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILFunSub"];
                    bG_BudItemsLibraries.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_BudItemsLibraries.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudItemsLibraries.BILAttr = dt.Rows[0]["BILAttr"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILAttr"];
                    bG_BudItemsLibraries.BILAppReaCon = dt.Rows[0]["BILAppReaCon"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILAppReaCon"];
                    bG_BudItemsLibraries.BILExpGistExp = dt.Rows[0]["BILExpGistExp"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILExpGistExp"];
                    bG_BudItemsLibraries.BILLongGoal = dt.Rows[0]["BILLongGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILLongGoal"];
                    bG_BudItemsLibraries.BILYearGoal = dt.Rows[0]["BILYearGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILYearGoal"];
                    bG_BudItemsLibraries.BILMon = dt.Rows[0]["BILMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILMon"];
                    bG_BudItemsLibraries.BILMonSou = dt.Rows[0]["BILMonSou"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILMonSou"];
                    bG_BudItemsLibraries.BILFinAllo = dt.Rows[0]["BILFinAllo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILFinAllo"];
                    bG_BudItemsLibraries.BILLastYearCarry = dt.Rows[0]["BILLastYearCarry"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILLastYearCarry"];
                    bG_BudItemsLibraries.BILOthFun = dt.Rows[0]["BILOthFun"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILOthFun"];
                    bG_BudItemsLibraries.BILOthExpProb = dt.Rows[0]["BILOthExpProb"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILOthExpProb"];
                    bG_BudItemsLibraries.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudItemsLibraries.BILProName = dt.Rows[0]["BILProName"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILProName"];
                    bG_BudItemsLibraries.BILProDescrip = dt.Rows[0]["BILProDescrip"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILProDescrip"];
                    bG_BudItemsLibraries.BILProCategory = dt.Rows[0]["BILProCategory"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILProCategory"];
                    
                    return bG_BudItemsLibraries;
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
	

      

        private static DataTable GetBG_BudItemsLibrariesBySql(string safeSql)
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
		
        private static DataTable GetBG_BudItemsLibrariesBySql(string sql, params SqlParameter[] values)
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
