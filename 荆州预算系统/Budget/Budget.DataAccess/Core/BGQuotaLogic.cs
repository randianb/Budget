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
    public class BGQuotaLogic
    {
        public static DataTable GetBGQuota(int year)
       {
           DataTable dt = null;
           try
           {
               string sql = string.Format("SELECT * FROM BG_Quota WHERE Year=@year ", year);
               dt = DBUnity.AdapterToTab(sql);
           }
           catch
           {
               dt = null;
           }
           return dt;
       }


        public static Decimal GetBGQuotaByPIID(int PIID, int year)
        {
            Decimal qt = 0;
            try
            {
                string sql = string.Format("SELECT Money FROM BG_Quota WHERE PIID={0} and Year={1} ", PIID, year);
                qt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text,sql,null));
            }
            catch
            {
                qt = 0;
            }
            return qt;
        }
    }
}
