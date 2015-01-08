using BudgetWeb.DAL;
using BudgetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_SupplementaryLogic
    {
        public static DataTable GetBG_SupplementaryByyear(int year)
        {
            string sqlStr = "select * from dbo.BG_Supplementary where Year={0}";
            sqlStr = string.Format(sqlStr, year);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static DataTable GetBG_SupplementaryDivide(int depid, int year)
        {
            string sqlStr = "select DepID , sum(SuppMon) as SuppMon from dbo.BG_BudgetAllocation where BAAYear={0} and DepID={1} group by DepID ";
            sqlStr = string.Format(sqlStr, year, depid);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static bool IsSuppByYear(int year)
        {
            bool flag = false;
            string sqlStr = "select count(*) from dbo.BG_Supplementary where Year={0}";
            sqlStr = string.Format(sqlStr, year);
            try
            {
                int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
                if (    t>0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (System.Exception ex)
            {
                flag = false;
            }
            
            return flag;
        }
    }

}
