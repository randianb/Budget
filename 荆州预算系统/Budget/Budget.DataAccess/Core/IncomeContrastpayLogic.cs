using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
     public class IncomeContrastpayLogic
    {
         public static DataTable GetICPDTByDepID_Time(int DepID , int Month)
         {
             string sqlStr = " select *  from ( select *  from (SELECT   dbo.BG_IncomeCPay.ICPID, dbo.BG_IncomeCPay.DepID, dbo.BG_IncomeCPay.InComeSouce, dbo.BG_IncomeCPay.InComeMon, dbo.BG_IncomeCPay.ICPTime, dbo.BG_Department.DepName FROM      dbo.BG_IncomeCPay LEFT OUTER JOIN dbo.BG_Department ON dbo.BG_IncomeCPay.DepID = dbo.BG_Department.DepID) as a where DepID={0} and month(ICPTime)={1}) as x left join   (select RPDep,sum(GKZC) as GKZC ,sum(QTZJ) as QTZJ, sum(XJZC) as XJZC   from baoxiao.[dbo].[RM_Receipts]  group by RPDep )as z on  x.DepName=z.RPDep";
             sqlStr = string.Format(sqlStr, DepID, Month);
             DataTable dt = DBUnity.AdapterToTab(sqlStr);
             return dt;
         }

         public static DataTable GetICPStDTByDepID_Time(int DepID, int Month)
         {
             string sqlStr = "select *  from (SELECT   dbo.BG_IncomeCPay.ICPID, dbo.BG_IncomeCPay.DepID, dbo.BG_IncomeCPay.InComeSouce, dbo.BG_IncomeCPay.InComeMon, dbo.BG_IncomeCPay.ICPTime, dbo.BG_Department.DepName FROM      dbo.BG_IncomeCPay LEFT OUTER JOIN dbo.BG_Department ON dbo.BG_IncomeCPay.DepID = dbo.BG_Department.DepID) as a where DepID={0} and month(ICPTime)={1}";
             sqlStr = string.Format(sqlStr, DepID, Month);
             DataTable dt = DBUnity.AdapterToTab(sqlStr);
             return dt;
         }
    }
}
