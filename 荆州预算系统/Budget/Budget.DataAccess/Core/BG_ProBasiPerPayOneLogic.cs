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
    public class BG_ProBasiPerPayOneLogic
    {
        public static bool IsBG_ProBasiPerPayOneByyear(int year)
        {
            string sqlStr = "select count(*) from dbo.BG_ProBasiPerPayOne where year(POYear)={0}";
            sqlStr = string.Format(sqlStr, year);
            int t =common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr));

            if (t > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
