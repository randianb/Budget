using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.DAL
{
    public static partial  class FA_FundsAccountService
    {
        public static DataTable GetFundsAccountByName(string name)
        {
            DataTable tmp = new DataTable();
            try
            {
                string sqlStr = "select * from FA_FundsAccount where DEPARTMENT='{0}'";
                sqlStr = string.Format(sqlStr, name);
                tmp = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_FundsAccountService.GetFundsAccountByName");
            }
            return tmp;
        }
    }
}
