using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;

namespace BudgetWeb.DAL
{
    public class BGPreviewDevideLogic
    {
        /// <summary>
        /// 获取指定科目的所有分配
        /// </summary>
        /// <param name="psid"></param>
        /// <returns></returns>
        public static DataTable GetDevideDataByPSID(int psid)
        {
            string sqlStr = "select sum(a.DevMon) as DevMon ,b.DepName from BG_PreviewDevide as a " +
                                "left join BG_Department as b on a.DepID = b.DepID  " +
                                "where a.PSID={0} group by DepName";
            sqlStr = string.Format(sqlStr, psid);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static int Isba(int PSID, int depid)
        {
            string sqlStr = string.Format("select PDID from  BG_PreviewDevide where PSID={0} and DepID={1}", PSID, depid);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        }

        public static DataTable getDevMon(int PSID)
        {
            string sqlStr = string.Format("select DevMon from  BG_PreviewDevide where PSID={0}", PSID);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
    }
}
