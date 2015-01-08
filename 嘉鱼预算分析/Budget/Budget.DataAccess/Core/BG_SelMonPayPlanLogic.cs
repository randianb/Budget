using BudgetWeb.DAL;
using BudgetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BudgetWeb.BLL
{
    public class BG_SelMonPayPlanLogic
    {
        public static DataTable GetMonPayPlan(int dept,int year,int month)
        {
            string sqlStr = "select * from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2}  ";
            sqlStr = string.Format(sqlStr, dept, year, month);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

    }
}
