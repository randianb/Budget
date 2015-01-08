//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/5 14:58:22
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudItemsService
	{
        public static BG_BudItems AddBG_BudItems(BG_BudItems bG_BudItems)
		{
            string sql =
				"INSERT BG_BudItems (BIProType, BIFunSub, BICode, PPID, PIID, BIPlanHz, BIStaTime, BIEndTime, BICharger, BIAttr, BIAppReaCon, BIExpGistExp, BILongGoal, BIYearGoal, BIMon, BIAppConMon, BIMonSou, BIFinAllo, BILastYearCarry, BIOthFun, BIOthExpProb, BIBudSta, BudSta, BICause, DepID, BIProName, BIReportTime, BIConNum, BIProDescrip, BIProCategory, BIYear)" +
				"VALUES (@BIProType, @BIFunSub, @BICode, @PPID, @PIID, @BIPlanHz, @BIStaTime, @BIEndTime, @BICharger, @BIAttr, @BIAppReaCon, @BIExpGistExp, @BILongGoal, @BIYearGoal, @BIMon, @BIAppConMon, @BIMonSou, @BIFinAllo, @BILastYearCarry, @BIOthFun, @BIOthExpProb, @BIBudSta, @BudSta, @BICause, @DepID, @BIProName, @BIReportTime, @BIConNum, @BIProDescrip, @BIProCategory, @BIYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BIProType", bG_BudItems.BIProType),
					new SqlParameter("@BIFunSub", bG_BudItems.BIFunSub),
					new SqlParameter("@BICode", bG_BudItems.BICode),
					new SqlParameter("@PPID", bG_BudItems.PPID),
					new SqlParameter("@PIID", bG_BudItems.PIID),
					new SqlParameter("@BIPlanHz", bG_BudItems.BIPlanHz),
					new SqlParameter("@BIStaTime", bG_BudItems.BIStaTime),
					new SqlParameter("@BIEndTime", bG_BudItems.BIEndTime),
					new SqlParameter("@BICharger", bG_BudItems.BICharger),
					new SqlParameter("@BIAttr", bG_BudItems.BIAttr),
					new SqlParameter("@BIAppReaCon", bG_BudItems.BIAppReaCon),
					new SqlParameter("@BIExpGistExp", bG_BudItems.BIExpGistExp),
					new SqlParameter("@BILongGoal", bG_BudItems.BILongGoal),
					new SqlParameter("@BIYearGoal", bG_BudItems.BIYearGoal),
					new SqlParameter("@BIMon", bG_BudItems.BIMon),
					new SqlParameter("@BIAppConMon", bG_BudItems.BIAppConMon),
					new SqlParameter("@BIMonSou", bG_BudItems.BIMonSou),
					new SqlParameter("@BIFinAllo", bG_BudItems.BIFinAllo),
					new SqlParameter("@BILastYearCarry", bG_BudItems.BILastYearCarry),
					new SqlParameter("@BIOthFun", bG_BudItems.BIOthFun),
					new SqlParameter("@BIOthExpProb", bG_BudItems.BIOthExpProb),
					new SqlParameter("@BIBudSta", bG_BudItems.BIBudSta),
					new SqlParameter("@BudSta", bG_BudItems.BudSta),
					new SqlParameter("@BICause", bG_BudItems.BICause),
					new SqlParameter("@DepID", bG_BudItems.DepID),
					new SqlParameter("@BIProName", bG_BudItems.BIProName),
					new SqlParameter("@BIReportTime", bG_BudItems.BIReportTime),
					new SqlParameter("@BIConNum", bG_BudItems.BIConNum),
					new SqlParameter("@BIProDescrip", bG_BudItems.BIProDescrip),
					new SqlParameter("@BIProCategory", bG_BudItems.BIProCategory),
					new SqlParameter("@BIYear", bG_BudItems.BIYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudItemsByBudID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudItems(BG_BudItems bG_BudItems)
		{
			return DeleteBG_BudItemsByBudID( bG_BudItems.BudID );
		}

        public static bool DeleteBG_BudItemsByBudID(int budID)
		{
            string sql = "DELETE BG_BudItems WHERE BudID = @BudID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", budID)
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
					


        public static bool ModifyBG_BudItems(BG_BudItems bG_BudItems)
        {
            string sql =
                "UPDATE BG_BudItems " +
                "SET " +
	                "BIProType = @BIProType, " +
	                "BIFunSub = @BIFunSub, " +
	                "BICode = @BICode, " +
	                "PPID = @PPID, " +
	                "PIID = @PIID, " +
	                "BIPlanHz = @BIPlanHz, " +
	                "BIStaTime = @BIStaTime, " +
	                "BIEndTime = @BIEndTime, " +
	                "BICharger = @BICharger, " +
	                "BIAttr = @BIAttr, " +
	                "BIAppReaCon = @BIAppReaCon, " +
	                "BIExpGistExp = @BIExpGistExp, " +
	                "BILongGoal = @BILongGoal, " +
	                "BIYearGoal = @BIYearGoal, " +
	                "BIMon = @BIMon, " +
	                "BIAppConMon = @BIAppConMon, " +
	                "BIMonSou = @BIMonSou, " +
	                "BIFinAllo = @BIFinAllo, " +
	                "BILastYearCarry = @BILastYearCarry, " +
	                "BIOthFun = @BIOthFun, " +
	                "BIOthExpProb = @BIOthExpProb, " +
	                "BIBudSta = @BIBudSta, " +
	                "BudSta = @BudSta, " +
	                "BICause = @BICause, " +
	                "DepID = @DepID, " +
	                "BIProName = @BIProName, " +
	                "BIReportTime = @BIReportTime, " +
	                "BIConNum = @BIConNum, " +
	                "BIProDescrip = @BIProDescrip, " +
	                "BIProCategory = @BIProCategory, " +
	                "BIYear = @BIYear " +
                "WHERE BudID = @BudID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", bG_BudItems.BudID),
					new SqlParameter("@BIProType", bG_BudItems.BIProType),
					new SqlParameter("@BIFunSub", bG_BudItems.BIFunSub),
					new SqlParameter("@BICode", bG_BudItems.BICode),
					new SqlParameter("@PPID", bG_BudItems.PPID),
					new SqlParameter("@PIID", bG_BudItems.PIID),
					new SqlParameter("@BIPlanHz", bG_BudItems.BIPlanHz),
					new SqlParameter("@BIStaTime", bG_BudItems.BIStaTime),
					new SqlParameter("@BIEndTime", bG_BudItems.BIEndTime),
					new SqlParameter("@BICharger", bG_BudItems.BICharger),
					new SqlParameter("@BIAttr", bG_BudItems.BIAttr),
					new SqlParameter("@BIAppReaCon", bG_BudItems.BIAppReaCon),
					new SqlParameter("@BIExpGistExp", bG_BudItems.BIExpGistExp),
					new SqlParameter("@BILongGoal", bG_BudItems.BILongGoal),
					new SqlParameter("@BIYearGoal", bG_BudItems.BIYearGoal),
					new SqlParameter("@BIMon", bG_BudItems.BIMon),
					new SqlParameter("@BIAppConMon", bG_BudItems.BIAppConMon),
					new SqlParameter("@BIMonSou", bG_BudItems.BIMonSou),
					new SqlParameter("@BIFinAllo", bG_BudItems.BIFinAllo),
					new SqlParameter("@BILastYearCarry", bG_BudItems.BILastYearCarry),
					new SqlParameter("@BIOthFun", bG_BudItems.BIOthFun),
					new SqlParameter("@BIOthExpProb", bG_BudItems.BIOthExpProb),
					new SqlParameter("@BIBudSta", bG_BudItems.BIBudSta),
					new SqlParameter("@BudSta", bG_BudItems.BudSta),
					new SqlParameter("@BICause", bG_BudItems.BICause),
					new SqlParameter("@DepID", bG_BudItems.DepID),
					new SqlParameter("@BIProName", bG_BudItems.BIProName),
					new SqlParameter("@BIReportTime", bG_BudItems.BIReportTime),
					new SqlParameter("@BIConNum", bG_BudItems.BIConNum),
					new SqlParameter("@BIProDescrip", bG_BudItems.BIProDescrip),
					new SqlParameter("@BIProCategory", bG_BudItems.BIProCategory),
					new SqlParameter("@BIYear", bG_BudItems.BIYear)
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


        public static DataTable GetAllBG_BudItems()
        {
            string sqlAll = "SELECT * FROM BG_BudItems";
			return GetBG_BudItemsBySql( sqlAll );
        }
		

        public static BG_BudItems GetBG_BudItemsByBudID(int budID)
        {
            string sql = "SELECT * FROM BG_BudItems WHERE BudID = @BudID";

            try
            {
                SqlParameter para = new SqlParameter("@BudID", budID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudItems bG_BudItems = new BG_BudItems();

                    bG_BudItems.BudID = dt.Rows[0]["BudID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudID"];
                    bG_BudItems.BIProType = dt.Rows[0]["BIProType"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProType"];
                    bG_BudItems.BIFunSub = dt.Rows[0]["BIFunSub"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIFunSub"];
                    bG_BudItems.BICode = dt.Rows[0]["BICode"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICode"];
                    bG_BudItems.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_BudItems.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudItems.BIPlanHz = dt.Rows[0]["BIPlanHz"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIPlanHz"];
                    bG_BudItems.BIStaTime = dt.Rows[0]["BIStaTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIStaTime"];
                    bG_BudItems.BIEndTime = dt.Rows[0]["BIEndTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIEndTime"];
                    bG_BudItems.BICharger = dt.Rows[0]["BICharger"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICharger"];
                    bG_BudItems.BIAttr = dt.Rows[0]["BIAttr"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIAttr"];
                    bG_BudItems.BIAppReaCon = dt.Rows[0]["BIAppReaCon"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIAppReaCon"];
                    bG_BudItems.BIExpGistExp = dt.Rows[0]["BIExpGistExp"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIExpGistExp"];
                    bG_BudItems.BILongGoal = dt.Rows[0]["BILongGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILongGoal"];
                    bG_BudItems.BIYearGoal = dt.Rows[0]["BIYearGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIYearGoal"];
                    bG_BudItems.BIMon = dt.Rows[0]["BIMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIMon"];
                    bG_BudItems.BIAppConMon = dt.Rows[0]["BIAppConMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIAppConMon"];
                    bG_BudItems.BIMonSou = dt.Rows[0]["BIMonSou"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIMonSou"];
                    bG_BudItems.BIFinAllo = dt.Rows[0]["BIFinAllo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIFinAllo"];
                    bG_BudItems.BILastYearCarry = dt.Rows[0]["BILastYearCarry"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILastYearCarry"];
                    bG_BudItems.BIOthFun = dt.Rows[0]["BIOthFun"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIOthFun"];
                    bG_BudItems.BIOthExpProb = dt.Rows[0]["BIOthExpProb"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIOthExpProb"];
                    bG_BudItems.BIBudSta = dt.Rows[0]["BIBudSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIBudSta"];
                    bG_BudItems.BudSta = dt.Rows[0]["BudSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["BudSta"];
                    bG_BudItems.BICause = dt.Rows[0]["BICause"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICause"];
                    bG_BudItems.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudItems.BIProName = dt.Rows[0]["BIProName"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProName"];
                    bG_BudItems.BIReportTime = dt.Rows[0]["BIReportTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIReportTime"];
                    bG_BudItems.BIConNum = dt.Rows[0]["BIConNum"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIConNum"];
                    bG_BudItems.BIProDescrip = dt.Rows[0]["BIProDescrip"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProDescrip"];
                    bG_BudItems.BIProCategory = dt.Rows[0]["BIProCategory"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProCategory"];
                    bG_BudItems.BIYear = dt.Rows[0]["BIYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BIYear"];
                    
                    return bG_BudItems;
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
	

      

        private static DataTable GetBG_BudItemsBySql(string safeSql)
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
		
        private static DataTable GetBG_BudItemsBySql(string sql, params SqlParameter[] values)
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
