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
	public static partial class BG_MonPayPlanRemarkService
	{
        public static BG_MonPayPlanRemark AddBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
		{
            string sql =
				"INSERT BG_MonPayPlanRemark (DeptID, MATime, MASta, MACause, MAUser)" +
				"VALUES (@DeptID, @MATime, @MASta, @MACause, @MAUser)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DeptID", bG_MonPayPlanRemark.DeptID),
					new SqlParameter("@MATime", bG_MonPayPlanRemark.MATime),
					new SqlParameter("@MASta", bG_MonPayPlanRemark.MASta),
					new SqlParameter("@MACause", bG_MonPayPlanRemark.MACause),
					new SqlParameter("@MAUser", bG_MonPayPlanRemark.MAUser)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_MonPayPlanRemarkByPRID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
		{
			return DeleteBG_MonPayPlanRemarkByPRID( bG_MonPayPlanRemark.PRID );
		}

        public static bool DeleteBG_MonPayPlanRemarkByPRID(int pRID)
		{
            string sql = "DELETE BG_MonPayPlanRemark WHERE PRID = @PRID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PRID", pRID)
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
					


        public static bool ModifyBG_MonPayPlanRemark(BG_MonPayPlanRemark bG_MonPayPlanRemark)
        {
            string sql =
                "UPDATE BG_MonPayPlanRemark " +
                "SET " +
	                "DeptID = @DeptID, " +
	                "MATime = @MATime, " +
	                "MASta = @MASta, " +
	                "MACause = @MACause, " +
	                "MAUser = @MAUser " +
                "WHERE PRID = @PRID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PRID", bG_MonPayPlanRemark.PRID),
					new SqlParameter("@DeptID", bG_MonPayPlanRemark.DeptID),
					new SqlParameter("@MATime", bG_MonPayPlanRemark.MATime),
					new SqlParameter("@MASta", bG_MonPayPlanRemark.MASta),
					new SqlParameter("@MACause", bG_MonPayPlanRemark.MACause),
					new SqlParameter("@MAUser", bG_MonPayPlanRemark.MAUser)
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


        public static DataTable GetAllBG_MonPayPlanRemark()
        {
            string sqlAll = "SELECT * FROM BG_MonPayPlanRemark";
			return GetBG_MonPayPlanRemarkBySql( sqlAll );
        }
		

        public static BG_MonPayPlanRemark GetBG_MonPayPlanRemarkByPRID(int pRID)
        {
            string sql = "SELECT * FROM BG_MonPayPlanRemark WHERE PRID = @PRID";

            try
            {
                SqlParameter para = new SqlParameter("@PRID", pRID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_MonPayPlanRemark bG_MonPayPlanRemark = new BG_MonPayPlanRemark();

                    bG_MonPayPlanRemark.PRID = dt.Rows[0]["PRID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PRID"];
                    bG_MonPayPlanRemark.DeptID = dt.Rows[0]["DeptID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DeptID"];
                    bG_MonPayPlanRemark.MATime = dt.Rows[0]["MATime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["MATime"];
                    bG_MonPayPlanRemark.MASta = dt.Rows[0]["MASta"] == DBNull.Value ? "" : (string)dt.Rows[0]["MASta"];
                    bG_MonPayPlanRemark.MACause = dt.Rows[0]["MACause"] == DBNull.Value ? "" : (string)dt.Rows[0]["MACause"];
                    bG_MonPayPlanRemark.MAUser = dt.Rows[0]["MAUser"] == DBNull.Value ? "" : (string)dt.Rows[0]["MAUser"];
                    
                    return bG_MonPayPlanRemark;
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
	

      

        private static DataTable GetBG_MonPayPlanRemarkBySql(string safeSql)
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
		
        private static DataTable GetBG_MonPayPlanRemarkBySql(string sql, params SqlParameter[] values)
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
