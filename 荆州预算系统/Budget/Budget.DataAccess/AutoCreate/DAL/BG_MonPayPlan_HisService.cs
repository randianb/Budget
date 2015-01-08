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
	public static partial class BG_MonPayPlan_HisService
	{
        public static BG_MonPayPlan_His AddBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
		{
            string sql =
				"INSERT BG_MonPayPlan_His (PIID, MPFunding, DeptID, MPTime, MPRemark, CPID, MPPHisTime, MPFundingAdd, MPFundingAddTimes)" +
				"VALUES (@PIID, @MPFunding, @DeptID, @MPTime, @MPRemark, @CPID, @MPPHisTime, @MPFundingAdd, @MPFundingAddTimes)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_MonPayPlan_His.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan_His.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan_His.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan_His.MPTime),
					new SqlParameter("@MPRemark", bG_MonPayPlan_His.MPRemark),
					new SqlParameter("@CPID", bG_MonPayPlan_His.CPID),
					new SqlParameter("@MPPHisTime", bG_MonPayPlan_His.MPPHisTime),
					new SqlParameter("@MPFundingAdd", bG_MonPayPlan_His.MPFundingAdd),
					new SqlParameter("@MPFundingAddTimes", bG_MonPayPlan_His.MPFundingAddTimes)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonPayPlan_HisByMPPHis(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
		{
			return DeleteBG_MonPayPlan_HisByMPPHis( bG_MonPayPlan_His.MPPHis );
		}

        public static bool DeleteBG_MonPayPlan_HisByMPPHis(int mPPHis)
		{
            string sql = "DELETE BG_MonPayPlan_His WHERE MPPHis = @MPPHis";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@MPPHis", mPPHis)
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
					


        public static bool ModifyBG_MonPayPlan_His(BG_MonPayPlan_His bG_MonPayPlan_His)
        {
            string sql =
                "UPDATE BG_MonPayPlan_His " +
                "SET " +
	                "PIID = @PIID, " +
	                "MPFunding = @MPFunding, " +
	                "DeptID = @DeptID, " +
	                "MPTime = @MPTime, " +
	                "MPRemark = @MPRemark, " +
	                "CPID = @CPID, " +
	                "MPPHisTime = @MPPHisTime, " +
	                "MPFundingAdd = @MPFundingAdd, " +
	                "MPFundingAddTimes = @MPFundingAddTimes " +
                "WHERE MPPHis = @MPPHis";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@MPPHis", bG_MonPayPlan_His.MPPHis),
					new SqlParameter("@PIID", bG_MonPayPlan_His.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan_His.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan_His.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan_His.MPTime),
					new SqlParameter("@MPRemark", bG_MonPayPlan_His.MPRemark),
					new SqlParameter("@CPID", bG_MonPayPlan_His.CPID),
					new SqlParameter("@MPPHisTime", bG_MonPayPlan_His.MPPHisTime),
					new SqlParameter("@MPFundingAdd", bG_MonPayPlan_His.MPFundingAdd),
					new SqlParameter("@MPFundingAddTimes", bG_MonPayPlan_His.MPFundingAddTimes)
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


        public static DataTable GetAllBG_MonPayPlan_His()
        {
            string sqlAll = "SELECT * FROM BG_MonPayPlan_His";
			return GetBG_MonPayPlan_HisBySql( sqlAll );
        }
		

        public static BG_MonPayPlan_His GetBG_MonPayPlan_HisByMPPHis(int mPPHis)
        {
            string sql = "SELECT * FROM BG_MonPayPlan_His WHERE MPPHis = @MPPHis";

            try
            {
                SqlParameter para = new SqlParameter("@MPPHis", mPPHis);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_MonPayPlan_His bG_MonPayPlan_His = new BG_MonPayPlan_His();

                    bG_MonPayPlan_His.MPPHis = dt.Rows[0]["MPPHis"] == DBNull.Value ? 0 : (int)dt.Rows[0]["MPPHis"];
                    bG_MonPayPlan_His.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_MonPayPlan_His.MPFunding = dt.Rows[0]["MPFunding"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MPFunding"];
                    bG_MonPayPlan_His.DeptID = dt.Rows[0]["DeptID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DeptID"];
                    bG_MonPayPlan_His.MPTime = dt.Rows[0]["MPTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MPTime"];
                    bG_MonPayPlan_His.MPRemark = dt.Rows[0]["MPRemark"] == DBNull.Value ? "" : (string)dt.Rows[0]["MPRemark"];
                    bG_MonPayPlan_His.CPID = dt.Rows[0]["CPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPID"];
                    bG_MonPayPlan_His.MPPHisTime = dt.Rows[0]["MPPHisTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MPPHisTime"];
                    bG_MonPayPlan_His.MPFundingAdd = dt.Rows[0]["MPFundingAdd"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MPFundingAdd"];
                    bG_MonPayPlan_His.MPFundingAddTimes = dt.Rows[0]["MPFundingAddTimes"] == DBNull.Value ? 0 : (int)dt.Rows[0]["MPFundingAddTimes"];
                    
                    return bG_MonPayPlan_His;
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
	

      

        private static DataTable GetBG_MonPayPlan_HisBySql(string safeSql)
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
		
        private static DataTable GetBG_MonPayPlan_HisBySql(string sql, params SqlParameter[] values)
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
