using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BudgetWeb.Model;
using BudgetWeb.DAL; 
using Common;

namespace BudgetWeb.BLL
{
    public class BG_UserLogic
    {

        /// <summary>
        /// 用户Login
        /// </summary>
        /// <param name="uid">帐号</param>
        /// <param name="pwd">密码</param>
        /// <returns>BGUser</returns>
        public static BG_User UserLogin(string uid, string pwd)
        {
            BG_User user = null;

            string sqlStr = "select * from BG_User where UserNum = '{0}' and UserPwd= '{1}'";
            sqlStr = string.Format(sqlStr, uid, pwd);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            if (dt.Rows.Count > 0)
            {
                user = new BG_User();
                user.UserID = (int)dt.Rows[0]["UserID"];
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.UserIDNum = dt.Rows[0]["UserIDNum"].ToString();
                user.UserNum = dt.Rows[0]["UserNum"].ToString();
                user.UserPwd = dt.Rows[0]["UserPwd"].ToString();
                user.UserLim = dt.Rows[0]["UserLim"].ToString();
                user.UserSta = (int)dt.Rows[0]["UserSta"];
                user.DepID = (int)dt.Rows[0]["DepID"];
                user.UserRem = dt.Rows[0]["UserRem"].ToString();
            }

            return user;
        }

        /// <summary>
        /// 通过部门ID获取该部门下面所有用户
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDtUserByDepid(string depid)
        {
            DataTable dt = null;
            try
            {
                string sqlStr = string.Format("SELECT  *  FROM BG_User WHERE DepID = {0}", depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
                dt = null;

            }
            return dt;
        }

        public static bool IsUser(string UserName)
        {
            bool flag  = false;
            try
            {
                string sqlStr = string.Format("SELECT  count(*)  FROM BG_User WHERE UserName = '{0}'", UserName);
                //flag = 

                int t=common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
                if (t>0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;

            }
            return flag;
        }

    }
}
