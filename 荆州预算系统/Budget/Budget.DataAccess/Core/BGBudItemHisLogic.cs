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
    public class BGBudItemHisLogic
    {
        public static DataTable GetBGBudItemHislastByBudID(int budid)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("SELECT * FROM BG_BudItemHis WHERE BudID = @BudID and BudSta='未提交' order by BudHisID desc", budid);
                dt=DBUnity.AdapterToTab(sql);
            }
            catch
            {
                dt = null;
            }
            return dt;
        } 
    }
}
