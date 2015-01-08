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
	public static partial class BG_ChangePwdService
	{
        public static BG_ChangePwd AddBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
		{
            string sql =
				"INSERT BG_ChangePwd (UserID, OldPwd, NewPwd, CrTime, UserName, DepName)" +
				"VALUES (@UserID, @OldPwd, @NewPwd, @CrTime, @UserName, @DepName)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", bG_ChangePwd.UserID),
					new SqlParameter("@OldPwd", bG_ChangePwd.OldPwd),
					new SqlParameter("@NewPwd", bG_ChangePwd.NewPwd),
					new SqlParameter("@CrTime", bG_ChangePwd.CrTime),
					new SqlParameter("@UserName", bG_ChangePwd.UserName),
					new SqlParameter("@DepName", bG_ChangePwd.DepName)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ChangePwdByPwdID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
		{
			return DeleteBG_ChangePwdByPwdID( bG_ChangePwd.PwdID );
		}

        public static bool DeleteBG_ChangePwdByPwdID(int pwdID)
		{
            string sql = "DELETE BG_ChangePwd WHERE PwdID = @PwdID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PwdID", pwdID)
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
					


        public static bool ModifyBG_ChangePwd(BG_ChangePwd bG_ChangePwd)
        {
            string sql =
                "UPDATE BG_ChangePwd " +
                "SET " +
	                "UserID = @UserID, " +
	                "OldPwd = @OldPwd, " +
	                "NewPwd = @NewPwd, " +
	                "CrTime = @CrTime, " +
	                "UserName = @UserName, " +
	                "DepName = @DepName " +
                "WHERE PwdID = @PwdID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PwdID", bG_ChangePwd.PwdID),
					new SqlParameter("@UserID", bG_ChangePwd.UserID),
					new SqlParameter("@OldPwd", bG_ChangePwd.OldPwd),
					new SqlParameter("@NewPwd", bG_ChangePwd.NewPwd),
					new SqlParameter("@CrTime", bG_ChangePwd.CrTime),
					new SqlParameter("@UserName", bG_ChangePwd.UserName),
					new SqlParameter("@DepName", bG_ChangePwd.DepName)
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


        public static DataTable GetAllBG_ChangePwd()
        {
            string sqlAll = "SELECT * FROM BG_ChangePwd";
			return GetBG_ChangePwdBySql( sqlAll );
        }
		

        public static BG_ChangePwd GetBG_ChangePwdByPwdID(int pwdID)
        {
            string sql = "SELECT * FROM BG_ChangePwd WHERE PwdID = @PwdID";

            try
            {
                SqlParameter para = new SqlParameter("@PwdID", pwdID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ChangePwd bG_ChangePwd = new BG_ChangePwd();

                    bG_ChangePwd.PwdID = dt.Rows[0]["PwdID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PwdID"];
                    bG_ChangePwd.UserID = dt.Rows[0]["UserID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UserID"];
                    bG_ChangePwd.OldPwd = dt.Rows[0]["OldPwd"] == DBNull.Value ? "" : (string)dt.Rows[0]["OldPwd"];
                    bG_ChangePwd.NewPwd = dt.Rows[0]["NewPwd"] == DBNull.Value ? "" : (string)dt.Rows[0]["NewPwd"];
                    bG_ChangePwd.CrTime = dt.Rows[0]["CrTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["CrTime"];
                    bG_ChangePwd.UserName = dt.Rows[0]["UserName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserName"];
                    bG_ChangePwd.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                    
                    return bG_ChangePwd;
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
	

      

        private static DataTable GetBG_ChangePwdBySql(string safeSql)
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
		
        private static DataTable GetBG_ChangePwdBySql(string sql, params SqlParameter[] values)
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
