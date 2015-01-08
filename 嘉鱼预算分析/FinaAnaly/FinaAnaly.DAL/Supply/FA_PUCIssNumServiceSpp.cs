using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.DAL
{
    public static partial class FA_PUCIssNumService
    {
        public static DataTable GetPUCIssNumByYearName(string name, int year)
        {
            DataTable dt=null;           
            try
            {
                string sql = "select * from FA_PUCIssNum where PIEcoSubName='{0}' and PUCYear={1}";
                sql = string.Format(sql, name, year);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_PUCIssNumService--GetPUCIssNumByYearName");
            }
            return dt;
        }
    }
}
