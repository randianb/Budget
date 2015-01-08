using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
    public class BG_PreviewDevideLogic
    {
        /// <summary>
        /// 获取指定科目的所有分配
        /// </summary>
        /// <param name="psid"></param>
        /// <returns></returns>
        public static DataTable GetDevideDataByPSID(int psid)
        {
            string sqlStr = "  select a.*, b.DepName from BG_PreviewDevide as a left join BG_Department as b on a.DepID = b.DepID  where a.PSID='{0}'";
            sqlStr = string.Format(sqlStr, psid);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
    }
}
