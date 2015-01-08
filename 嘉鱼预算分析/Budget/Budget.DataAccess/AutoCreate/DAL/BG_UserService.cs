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
	public static partial class BG_UserService
	{
        public static BG_User AddBG_User(BG_User bG_User)
		{
            string sql =
				"INSERT BG_User (UserName, UserNum, UserIDNum, UserPwd, UserLim, UserSta, DepID, UserRem)" +
				"VALUES (@UserName, @UserNum, @UserIDNum, @UserPwd, @UserLim, @UserSta, @DepID, @UserRem)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", bG_User.UserName),
					new SqlParameter("@UserNum", bG_User.UserNum),
					new SqlParameter("@UserIDNum", bG_User.UserIDNum),
					new SqlParameter("@UserPwd", bG_User.UserPwd),
					new SqlParameter("@UserLim", bG_User.UserLim),
					new SqlParameter("@UserSta", bG_User.UserSta),
					new SqlParameter("@DepID", bG_User.DepID),
					new SqlParameter("@UserRem", bG_User.UserRem)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_UserByUserID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_User(BG_User bG_User)
		{
			return DeleteBG_UserByUserID( bG_User.UserID );
		}

        public static bool DeleteBG_UserByUserID(int userID)
		{
            string sql = "DELETE BG_User WHERE UserID = @UserID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID)
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
					


        public static bool ModifyBG_User(BG_User bG_User)
        {
            string sql =
                "UPDATE BG_User " +
                "SET " +
	                "UserName = @UserName, " +
	                "UserNum = @UserNum, " +
	                "UserIDNum = @UserIDNum, " +
	                "UserPwd = @UserPwd, " +
	                "UserLim = @UserLim, " +
	                "UserSta = @UserSta, " +
	                "DepID = @DepID, " +
	                "UserRem = @UserRem " +
                "WHERE UserID = @UserID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", bG_User.UserID),
					new SqlParameter("@UserName", bG_User.UserName),
					new SqlParameter("@UserNum", bG_User.UserNum),
					new SqlParameter("@UserIDNum", bG_User.UserIDNum),
					new SqlParameter("@UserPwd", bG_User.UserPwd),
					new SqlParameter("@UserLim", bG_User.UserLim),
					new SqlParameter("@UserSta", bG_User.UserSta),
					new SqlParameter("@DepID", bG_User.DepID),
					new SqlParameter("@UserRem", bG_User.UserRem)
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


        public static DataTable GetAllBG_User()
        {
            string sqlAll = "SELECT * FROM BG_User";
			return GetBG_UserBySql( sqlAll );
        }
		

        public static BG_User GetBG_UserByUserID(int userID)
        {
            string sql = "SELECT * FROM BG_User WHERE UserID = @UserID";

            try
            {
                SqlParameter para = new SqlParameter("@UserID", userID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_User bG_User = new BG_User();

                    bG_User.UserID = dt.Rows[0]["UserID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserID"];
                    bG_User.UserName = dt.Rows[0]["UserName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserName"];
                    bG_User.UserNum = dt.Rows[0]["UserNum"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserNum"];
                    bG_User.UserIDNum = dt.Rows[0]["UserIDNum"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserIDNum"];
                    bG_User.UserPwd = dt.Rows[0]["UserPwd"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserPwd"];
                    bG_User.UserLim = dt.Rows[0]["UserLim"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserLim"];
                    bG_User.UserSta = dt.Rows[0]["UserSta"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserSta"];
                    bG_User.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_User.UserRem = dt.Rows[0]["UserRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserRem"];
                    
                    return bG_User;
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
	

      

        private static DataTable GetBG_UserBySql(string safeSql)
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
		
        private static DataTable GetBG_UserBySql(string sql, params SqlParameter[] values)
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
