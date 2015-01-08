//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_UserService
	{
        public static FA_User AddFA_User(FA_User fA_User)
		{
            string sql =
				"INSERT FA_User (UserName, UserNum, UserIDNum, UserPwd, UserLim, UserSta, DepID, UserRem, UserPurStr)" +
				"VALUES (@UserName, @UserNum, @UserIDNum, @UserPwd, @UserLim, @UserSta, @DepID, @UserRem, @UserPurStr)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", fA_User.UserName),
					new SqlParameter("@UserNum", fA_User.UserNum),
					new SqlParameter("@UserIDNum", fA_User.UserIDNum),
					new SqlParameter("@UserPwd", fA_User.UserPwd),
					new SqlParameter("@UserLim", fA_User.UserLim),
					new SqlParameter("@UserSta", fA_User.UserSta),
					new SqlParameter("@DepID", fA_User.DepID),
					new SqlParameter("@UserRem", fA_User.UserRem),
					new SqlParameter("@UserPurStr", fA_User.UserPurStr)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_UserByUserID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_User(FA_User fA_User)
		{
			return DeleteFA_UserByUserID( fA_User.UserID );
		}

        public static bool DeleteFA_UserByUserID(int userID)
		{
            string sql = "DELETE FA_User WHERE UserID = @UserID";

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
					


        public static bool ModifyFA_User(FA_User fA_User)
        {
            string sql =
                "UPDATE FA_User " +
                "SET " +
	                "UserName = @UserName, " +
	                "UserNum = @UserNum, " +
	                "UserIDNum = @UserIDNum, " +
	                "UserPwd = @UserPwd, " +
	                "UserLim = @UserLim, " +
	                "UserSta = @UserSta, " +
	                "DepID = @DepID, " +
	                "UserRem = @UserRem, " +
	                "UserPurStr = @UserPurStr " +
                "WHERE UserID = @UserID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", fA_User.UserID),
					new SqlParameter("@UserName", fA_User.UserName),
					new SqlParameter("@UserNum", fA_User.UserNum),
					new SqlParameter("@UserIDNum", fA_User.UserIDNum),
					new SqlParameter("@UserPwd", fA_User.UserPwd),
					new SqlParameter("@UserLim", fA_User.UserLim),
					new SqlParameter("@UserSta", fA_User.UserSta),
					new SqlParameter("@DepID", fA_User.DepID),
					new SqlParameter("@UserRem", fA_User.UserRem),
					new SqlParameter("@UserPurStr", fA_User.UserPurStr)
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


        public static DataTable GetAllFA_User()
        {
            string sqlAll = "SELECT * FROM FA_User";
			return GetFA_UserBySql( sqlAll );
        }
		

        public static FA_User GetFA_UserByUserID(int userID)
        {
            string sql = "SELECT * FROM FA_User WHERE UserID = @UserID";

            try
            {
                SqlParameter para = new SqlParameter("@UserID", userID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_User fA_User = new FA_User();

                    fA_User.UserID = dt.Rows[0]["UserID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserID"];
                    fA_User.UserName = dt.Rows[0]["UserName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserName"];
                    fA_User.UserNum = dt.Rows[0]["UserNum"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserNum"];
                    fA_User.UserIDNum = dt.Rows[0]["UserIDNum"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserIDNum"];
                    fA_User.UserPwd = dt.Rows[0]["UserPwd"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserPwd"];
                    fA_User.UserLim = dt.Rows[0]["UserLim"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserLim"];
                    fA_User.UserSta = dt.Rows[0]["UserSta"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserSta"];
                    fA_User.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_User.UserRem = dt.Rows[0]["UserRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserRem"];
                    fA_User.UserPurStr = dt.Rows[0]["UserPurStr"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserPurStr"];
                    
                    return fA_User;
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
	

      

        private static DataTable GetFA_UserBySql(string safeSql)
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
		
        private static DataTable GetFA_UserBySql(string sql, params SqlParameter[] values)
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
