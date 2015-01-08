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
	public static partial class BG_BudItemHisService
	{
        public static BG_BudItemHis AddBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
		{
            string sql =
				"INSERT BG_BudItemHis (BudID, BIProType, BIFunSub, BICode, PPID, PIID, BIPlanHz, BIStaTime, BIEndTime, BICharger, BIAttr, BIAppReaCon, BIExpGistExp, BILongGoal, BIYearGoal, BIMon, BIAppConMon, BIMonSou, BIFinAllo, BILastYearCarry, BIOthFun, BIOthExpProb, BIBudSta, BudSta, BICause, DepID, BIProName, BIReportTime, BIConNum, BIProDescrip, BIProCategory)" +
				"VALUES (@BudID, @BIProType, @BIFunSub, @BICode, @PPID, @PIID, @BIPlanHz, @BIStaTime, @BIEndTime, @BICharger, @BIAttr, @BIAppReaCon, @BIExpGistExp, @BILongGoal, @BIYearGoal, @BIMon, @BIAppConMon, @BIMonSou, @BIFinAllo, @BILastYearCarry, @BIOthFun, @BIOthExpProb, @BIBudSta, @BudSta, @BICause, @DepID, @BIProName, @BIReportTime, @BIConNum, @BIProDescrip, @BIProCategory)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", bG_BudItemHis.BudID),
					new SqlParameter("@BIProType", bG_BudItemHis.BIProType),
					new SqlParameter("@BIFunSub", bG_BudItemHis.BIFunSub),
					new SqlParameter("@BICode", bG_BudItemHis.BICode),
					new SqlParameter("@PPID", bG_BudItemHis.PPID),
					new SqlParameter("@PIID", bG_BudItemHis.PIID),
					new SqlParameter("@BIPlanHz", bG_BudItemHis.BIPlanHz),
					new SqlParameter("@BIStaTime", bG_BudItemHis.BIStaTime),
					new SqlParameter("@BIEndTime", bG_BudItemHis.BIEndTime),
					new SqlParameter("@BICharger", bG_BudItemHis.BICharger),
					new SqlParameter("@BIAttr", bG_BudItemHis.BIAttr),
					new SqlParameter("@BIAppReaCon", bG_BudItemHis.BIAppReaCon),
					new SqlParameter("@BIExpGistExp", bG_BudItemHis.BIExpGistExp),
					new SqlParameter("@BILongGoal", bG_BudItemHis.BILongGoal),
					new SqlParameter("@BIYearGoal", bG_BudItemHis.BIYearGoal),
					new SqlParameter("@BIMon", bG_BudItemHis.BIMon),
					new SqlParameter("@BIAppConMon", bG_BudItemHis.BIAppConMon),
					new SqlParameter("@BIMonSou", bG_BudItemHis.BIMonSou),
					new SqlParameter("@BIFinAllo", bG_BudItemHis.BIFinAllo),
					new SqlParameter("@BILastYearCarry", bG_BudItemHis.BILastYearCarry),
					new SqlParameter("@BIOthFun", bG_BudItemHis.BIOthFun),
					new SqlParameter("@BIOthExpProb", bG_BudItemHis.BIOthExpProb),
					new SqlParameter("@BIBudSta", bG_BudItemHis.BIBudSta),
					new SqlParameter("@BudSta", bG_BudItemHis.BudSta),
					new SqlParameter("@BICause", bG_BudItemHis.BICause),
					new SqlParameter("@DepID", bG_BudItemHis.DepID),
					new SqlParameter("@BIProName", bG_BudItemHis.BIProName),
					new SqlParameter("@BIReportTime", bG_BudItemHis.BIReportTime),
					new SqlParameter("@BIConNum", bG_BudItemHis.BIConNum),
					new SqlParameter("@BIProDescrip", bG_BudItemHis.BIProDescrip),
					new SqlParameter("@BIProCategory", bG_BudItemHis.BIProCategory)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudItemHisByBudHisID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
		{
			return DeleteBG_BudItemHisByBudHisID( bG_BudItemHis.BudHisID );
		}

        public static bool DeleteBG_BudItemHisByBudHisID(int budHisID)
		{
            string sql = "DELETE BG_BudItemHis WHERE BudHisID = @BudHisID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudHisID", budHisID)
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
					


        public static bool ModifyBG_BudItemHis(BG_BudItemHis bG_BudItemHis)
        {
            string sql =
                "UPDATE BG_BudItemHis " +
                "SET " +
	                "BudID = @BudID, " +
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
	                "BIProCategory = @BIProCategory " +
                "WHERE BudHisID = @BudHisID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudHisID", bG_BudItemHis.BudHisID),
					new SqlParameter("@BudID", bG_BudItemHis.BudID),
					new SqlParameter("@BIProType", bG_BudItemHis.BIProType),
					new SqlParameter("@BIFunSub", bG_BudItemHis.BIFunSub),
					new SqlParameter("@BICode", bG_BudItemHis.BICode),
					new SqlParameter("@PPID", bG_BudItemHis.PPID),
					new SqlParameter("@PIID", bG_BudItemHis.PIID),
					new SqlParameter("@BIPlanHz", bG_BudItemHis.BIPlanHz),
					new SqlParameter("@BIStaTime", bG_BudItemHis.BIStaTime),
					new SqlParameter("@BIEndTime", bG_BudItemHis.BIEndTime),
					new SqlParameter("@BICharger", bG_BudItemHis.BICharger),
					new SqlParameter("@BIAttr", bG_BudItemHis.BIAttr),
					new SqlParameter("@BIAppReaCon", bG_BudItemHis.BIAppReaCon),
					new SqlParameter("@BIExpGistExp", bG_BudItemHis.BIExpGistExp),
					new SqlParameter("@BILongGoal", bG_BudItemHis.BILongGoal),
					new SqlParameter("@BIYearGoal", bG_BudItemHis.BIYearGoal),
					new SqlParameter("@BIMon", bG_BudItemHis.BIMon),
					new SqlParameter("@BIAppConMon", bG_BudItemHis.BIAppConMon),
					new SqlParameter("@BIMonSou", bG_BudItemHis.BIMonSou),
					new SqlParameter("@BIFinAllo", bG_BudItemHis.BIFinAllo),
					new SqlParameter("@BILastYearCarry", bG_BudItemHis.BILastYearCarry),
					new SqlParameter("@BIOthFun", bG_BudItemHis.BIOthFun),
					new SqlParameter("@BIOthExpProb", bG_BudItemHis.BIOthExpProb),
					new SqlParameter("@BIBudSta", bG_BudItemHis.BIBudSta),
					new SqlParameter("@BudSta", bG_BudItemHis.BudSta),
					new SqlParameter("@BICause", bG_BudItemHis.BICause),
					new SqlParameter("@DepID", bG_BudItemHis.DepID),
					new SqlParameter("@BIProName", bG_BudItemHis.BIProName),
					new SqlParameter("@BIReportTime", bG_BudItemHis.BIReportTime),
					new SqlParameter("@BIConNum", bG_BudItemHis.BIConNum),
					new SqlParameter("@BIProDescrip", bG_BudItemHis.BIProDescrip),
					new SqlParameter("@BIProCategory", bG_BudItemHis.BIProCategory)
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


        public static DataTable GetAllBG_BudItemHis()
        {
            string sqlAll = "SELECT * FROM BG_BudItemHis";
			return GetBG_BudItemHisBySql( sqlAll );
        }
		

        public static BG_BudItemHis GetBG_BudItemHisByBudHisID(int budHisID)
        {
            string sql = "SELECT * FROM BG_BudItemHis WHERE BudHisID = @BudHisID";

            try
            {
                SqlParameter para = new SqlParameter("@BudHisID", budHisID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudItemHis bG_BudItemHis = new BG_BudItemHis();

                    bG_BudItemHis.BudHisID = dt.Rows[0]["BudHisID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudHisID"];
                    bG_BudItemHis.BudID = dt.Rows[0]["BudID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudID"];
                    bG_BudItemHis.BIProType = dt.Rows[0]["BIProType"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProType"];
                    bG_BudItemHis.BIFunSub = dt.Rows[0]["BIFunSub"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIFunSub"];
                    bG_BudItemHis.BICode = dt.Rows[0]["BICode"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICode"];
                    bG_BudItemHis.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
                    bG_BudItemHis.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudItemHis.BIPlanHz = dt.Rows[0]["BIPlanHz"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIPlanHz"];
                    bG_BudItemHis.BIStaTime = dt.Rows[0]["BIStaTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIStaTime"];
                    bG_BudItemHis.BIEndTime = dt.Rows[0]["BIEndTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIEndTime"];
                    bG_BudItemHis.BICharger = dt.Rows[0]["BICharger"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICharger"];
                    bG_BudItemHis.BIAttr = dt.Rows[0]["BIAttr"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIAttr"];
                    bG_BudItemHis.BIAppReaCon = dt.Rows[0]["BIAppReaCon"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIAppReaCon"];
                    bG_BudItemHis.BIExpGistExp = dt.Rows[0]["BIExpGistExp"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIExpGistExp"];
                    bG_BudItemHis.BILongGoal = dt.Rows[0]["BILongGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BILongGoal"];
                    bG_BudItemHis.BIYearGoal = dt.Rows[0]["BIYearGoal"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIYearGoal"];
                    bG_BudItemHis.BIMon = dt.Rows[0]["BIMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIMon"];
                    bG_BudItemHis.BIAppConMon = dt.Rows[0]["BIAppConMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIAppConMon"];
                    bG_BudItemHis.BIMonSou = dt.Rows[0]["BIMonSou"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIMonSou"];
                    bG_BudItemHis.BIFinAllo = dt.Rows[0]["BIFinAllo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIFinAllo"];
                    bG_BudItemHis.BILastYearCarry = dt.Rows[0]["BILastYearCarry"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BILastYearCarry"];
                    bG_BudItemHis.BIOthFun = dt.Rows[0]["BIOthFun"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIOthFun"];
                    bG_BudItemHis.BIOthExpProb = dt.Rows[0]["BIOthExpProb"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIOthExpProb"];
                    bG_BudItemHis.BIBudSta = dt.Rows[0]["BIBudSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIBudSta"];
                    bG_BudItemHis.BudSta = dt.Rows[0]["BudSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["BudSta"];
                    bG_BudItemHis.BICause = dt.Rows[0]["BICause"] == DBNull.Value ? "" : (string)dt.Rows[0]["BICause"];
                    bG_BudItemHis.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudItemHis.BIProName = dt.Rows[0]["BIProName"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProName"];
                    bG_BudItemHis.BIReportTime = dt.Rows[0]["BIReportTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BIReportTime"];
                    bG_BudItemHis.BIConNum = dt.Rows[0]["BIConNum"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BIConNum"];
                    bG_BudItemHis.BIProDescrip = dt.Rows[0]["BIProDescrip"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProDescrip"];
                    bG_BudItemHis.BIProCategory = dt.Rows[0]["BIProCategory"] == DBNull.Value ? "" : (string)dt.Rows[0]["BIProCategory"];
                    
                    return bG_BudItemHis;
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
	

      

        private static DataTable GetBG_BudItemHisBySql(string safeSql)
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
		
        private static DataTable GetBG_BudItemHisBySql(string sql, params SqlParameter[] values)
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
