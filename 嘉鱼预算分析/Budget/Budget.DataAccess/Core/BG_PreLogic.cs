using Common;
using BudgetWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BudgetWeb.BLL
{
    public class BG_PreLogic
    {
        public static DataTable GetBG_PreByyear(int curtime)
        {
            string sqlStr = "select * from dbo.BG_Pre where Year={0}";
            sqlStr = string.Format(sqlStr, curtime);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
        public static bool IsPreByYear(int year)
        {
            bool flag = false;
            string sqlStr = "select count(*) from dbo.BG_Pre where Year={0}";
            sqlStr = string.Format(sqlStr, year);
            try
            {
                int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
                if (t > 0)
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