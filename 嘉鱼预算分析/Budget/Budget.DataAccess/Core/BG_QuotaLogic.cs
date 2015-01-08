using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_QuotaLogic
    {
        public static decimal GetQuotaMoney(int PIID, int year)
        {
            decimal t = 0;
            string sqlStr = "select Money  from  BG_Quota where PIID={0} and Year={1}";
            sqlStr = string.Format(sqlStr, PIID, year);
            try
            {
                t = ParseUtil.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null), 0);
            }
            catch (Exception ex)
            {

                t=0;
            } 
            return t;
        }
    }
}
