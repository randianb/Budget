using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;

namespace BudgetWeb.BLL
{
    public class BG_ChaSecAuditLogic
    {
        public static DataTable GetChaSecAudit(int dept, int year, int month)
        {
            string sqlStr = "select * from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2} and MASta='提交'";
            sqlStr = string.Format(sqlStr, dept, year, month);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
    }
}
