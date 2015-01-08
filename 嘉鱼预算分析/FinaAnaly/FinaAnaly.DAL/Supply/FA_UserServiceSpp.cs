using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.Model;
using Common;

namespace FinaAnaly.DAL
{
    public static partial class FA_UserService
    {
        /// <summary>
        /// 查询指定部门下所有人员
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDtUserByDepid(int depid)
        {
            DataTable dt = null;
            try
            {

                string sql = string.Format("select * from FA_User where DepID={0}", depid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_UserService--GetDtUserByDepid");
            }
            return dt;
        }

        public static DataTable GetDtUserBynamepwd(string name,string pwd)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("select * from FA_User where UserNum='{0}' and UserPwd='{1}'", name,pwd);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_UserService--GetDtUserBynamepwd");
            }
            return dt;
        }
    }
}
