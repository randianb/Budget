using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_MonLogic
    {
        public static int  GEtIDisEditMon(int year)
        { 
            string sql = string.Format("select BGID from BG_Mon where BGYear ={0}", year);
            int t=
            common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            return t;
        }
    }
}
