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
    public  class BG_MonPayPlanLogic
    {
        public static DataTable GetMpFunding(int ppid, int DepID, string ARTime)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_MonPayPlan where piid={0} and DeptId={1} and  convert(varchar(7),MPTime,120)<='{2}'", ppid, DepID, ARTime);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        public static int GetmonthbyMonPayPlan (int depID)
        {
            
            int month = 0;
            string sql = string.Format("select max(Month(MATime)) as mon from BG_MonPayPlanRemark where MASta='审核通过' and DeptID={0}", depID);
            month = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            return month;
        }

        public static DataTable GetMpFunding(int depId, string yearMonth)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_MonPayPlan where  DeptId={0} and  convert(varchar(7),MPTime,120)='{1}'", depId, yearMonth);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
