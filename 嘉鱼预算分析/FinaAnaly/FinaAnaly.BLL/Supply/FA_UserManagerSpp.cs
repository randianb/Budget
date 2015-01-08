using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;

namespace FinaAnaly.BLL
{
    public static partial  class FA_UserManager
    {
         /// <summary>
        /// 查询指定部门下所有人员
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDtUserByDepid(int depid)
        {
            return FA_UserService.GetDtUserByDepid(depid);
        }

        public static DataTable GetDtUserBynamepwd(string name, string pwd)
        {
            return FA_UserService.GetDtUserBynamepwd(name, pwd);
        }
    }
}
