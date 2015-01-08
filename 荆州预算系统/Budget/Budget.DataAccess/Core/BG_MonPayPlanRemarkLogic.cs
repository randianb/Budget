using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_MonPayPlanRemarkLogic
    {

        public static bool IsRemark(int DepID, string ARTime,int pici)
        {
            bool flag = false;
            string str = string.Format("select * from  dbo.BG_MonPayPlanRemark where DeptID={0} and MATimes={2}  and convert(varchar(7),MATime,120)=" + "'{1}" + "' ", DepID, ARTime,pici);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, str, null));
            if (t > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static DataTable auditRemark(string yearMonth)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select DeptID from  dbo.BG_MonPayPlanRemark where convert(varchar(7),MATime,120)=" + "'{0}" + "' ", yearMonth);
                dt = DBUnity.AdapterToTab(str);
            }
            catch (System.Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public static int GetCountremark(string sta)
        {
            string str = string.Format("select count(*) from  dbo.BG_MonPayPlanRemark where MASta='{0}' ",sta);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, str, null));
            return t;
        }

        public static int GetCountReimbur(string sta)
        {
            string str = string.Format("select count(*) from  dbo.BG_ApplyReimbur where ARListSta='{0}' ", sta);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, str, null));
            return t;
        }
    }
}
