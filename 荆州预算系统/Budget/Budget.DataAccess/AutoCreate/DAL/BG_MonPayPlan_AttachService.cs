//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/8 17:48:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_MonPayPlan_AttachService
	{
        public static BG_MonPayPlan_Attach AddBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
		{
            string sql =
				"INSERT BG_MonPayPlan_Attach (PIID, MPFunding, DeptID, MPTime, MPRemark, MPFundingAdd, CPATimes, CPID)" +
				"VALUES (@PIID, @MPFunding, @DeptID, @MPTime, @MPRemark, @MPFundingAdd, @CPATimes, @CPID)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PIID", bG_MonPayPlan_Attach.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan_Attach.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan_Attach.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan_Attach.MPTime),
					new SqlParameter("@MPRemark", bG_MonPayPlan_Attach.MPRemark),
					new SqlParameter("@MPFundingAdd", bG_MonPayPlan_Attach.MPFundingAdd),
					new SqlParameter("@CPATimes", bG_MonPayPlan_Attach.CPATimes),
					new SqlParameter("@CPID", bG_MonPayPlan_Attach.CPID)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonPayPlan_AttachByCPAID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
		{
			return DeleteBG_MonPayPlan_AttachByCPAID( bG_MonPayPlan_Attach.CPAID );
		}

        public static bool DeleteBG_MonPayPlan_AttachByCPAID(int cPAID)
		{
            string sql = "DELETE BG_MonPayPlan_Attach WHERE CPAID = @CPAID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CPAID", cPAID)
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
					


        public static bool ModifyBG_MonPayPlan_Attach(BG_MonPayPlan_Attach bG_MonPayPlan_Attach)
        {
            string sql =
                "UPDATE BG_MonPayPlan_Attach " +
                "SET " +
	                "PIID = @PIID, " +
	                "MPFunding = @MPFunding, " +
	                "DeptID = @DeptID, " +
	                "MPTime = @MPTime, " +
	                "MPRemark = @MPRemark, " +
	                "MPFundingAdd = @MPFundingAdd, " +
	                "CPATimes = @CPATimes, " +
	                "CPID = @CPID " +
                "WHERE CPAID = @CPAID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CPAID", bG_MonPayPlan_Attach.CPAID),
					new SqlParameter("@PIID", bG_MonPayPlan_Attach.PIID),
					new SqlParameter("@MPFunding", bG_MonPayPlan_Attach.MPFunding),
					new SqlParameter("@DeptID", bG_MonPayPlan_Attach.DeptID),
					new SqlParameter("@MPTime", bG_MonPayPlan_Attach.MPTime),
					new SqlParameter("@MPRemark", bG_MonPayPlan_Attach.MPRemark),
					new SqlParameter("@MPFundingAdd", bG_MonPayPlan_Attach.MPFundingAdd),
					new SqlParameter("@CPATimes", bG_MonPayPlan_Attach.CPATimes),
					new SqlParameter("@CPID", bG_MonPayPlan_Attach.CPID)
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


        public static DataTable GetAllBG_MonPayPlan_Attach()
        {
            string sqlAll = "SELECT * FROM BG_MonPayPlan_Attach";
			return GetBG_MonPayPlan_AttachBySql( sqlAll );
        }
		

        public static BG_MonPayPlan_Attach GetBG_MonPayPlan_AttachByCPAID(int cPAID)
        {
            string sql = "SELECT * FROM BG_MonPayPlan_Attach WHERE CPAID = @CPAID";

            try
            {
                SqlParameter para = new SqlParameter("@CPAID", cPAID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_MonPayPlan_Attach bG_MonPayPlan_Attach = new BG_MonPayPlan_Attach();

                    bG_MonPayPlan_Attach.CPAID = dt.Rows[0]["CPAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPAID"];
                    bG_MonPayPlan_Attach.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_MonPayPlan_Attach.MPFunding = dt.Rows[0]["MPFunding"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MPFunding"];
                    bG_MonPayPlan_Attach.DeptID = dt.Rows[0]["DeptID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DeptID"];
                    bG_MonPayPlan_Attach.MPTime = dt.Rows[0]["MPTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MPTime"];
                    bG_MonPayPlan_Attach.MPRemark = dt.Rows[0]["MPRemark"] == DBNull.Value ? "" : (string)dt.Rows[0]["MPRemark"];
                    bG_MonPayPlan_Attach.MPFundingAdd = dt.Rows[0]["MPFundingAdd"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["MPFundingAdd"];
                    bG_MonPayPlan_Attach.CPATimes = dt.Rows[0]["CPATimes"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPATimes"];
                    bG_MonPayPlan_Attach.CPID = dt.Rows[0]["CPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CPID"];
                    
                    return bG_MonPayPlan_Attach;
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
	

      

        private static DataTable GetBG_MonPayPlan_AttachBySql(string safeSql)
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
		
        private static DataTable GetBG_MonPayPlan_AttachBySql(string sql, params SqlParameter[] values)
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
