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
        public static DataTable GetMonPayPlan(int dept,int year,int month,int pici)
        {
            string sqlStr = "select * from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2} and MPFundingAddTimes={3}";
            sqlStr = string.Format(sqlStr, dept, year, month, pici);
            if (pici==0)
            {
                sqlStr =
                    "select * from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2} ";
                sqlStr = string.Format(sqlStr, dept, year, month);
            }
            
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static DataTable GetMonPayPlanTotal(int depId, string yearMonth)
        {
            string sqlStr = "select cast(MPFundingAddTimes AS varchar(2)) as MPFundingAddTimes, sum(MPFunding) as MPFunding,MPTime,case when MASta='未提交' then '1' else '0' end as weitijiao,case when MASta='提交' then '1' else '0' end as tijiao,case when MASta='审核通过' then '1' else '0' end as shenhetongguo,case when MASta='退回' then '1' else '0' end as tuihui,case when MASta='审核不通过' then '1' else '0' end as shenhebutongguo from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and Convert(varchar(7),MPTime,120)='{1}'  group by MPFundingAddTimes,MPTime,MASta";
            sqlStr = string.Format(sqlStr, depId, yearMonth); 
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
        public static DataTable GetMonPayPlanTotalAudit(int t)
        {
            string sqlStr =
                "select DepName ,sum(MPFundingAdd)*10000 as MPFunding,MASta ,MATimes ,DeptID, MATime from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID  group by DepName ,DeptID,MASta,MATimes,MATime";
            if (t==0)
            {
                 sqlStr =
                "select DepName ,sum(MPFundingAdd)*10000 as MPFunding,MASta ,MATimes ,DeptID, MATime from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where MASta='未提交'  group by DepName ,DeptID,MASta,MATimes,MATime";
            }
            else
            {
                sqlStr =
                "select DepName ,sum(MPFundingAdd)*10000 as MPFunding,MASta ,MATimes ,DeptID, MATime from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where MASta='提交'  group by DepName ,DeptID,MASta,MATimes,MATime";
                
            }
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
//        public static DataTable GetMonPayPlanTotalAudit(int depid, string yearMonth, int pici)
//        {
//            string sqlStr =
//                "select DepName ,sum(MPFundingAdd)*10000 as MPFunding,MASta ,MATimes ,DeptID, MATime from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where Convert(varchar(7),MATime,120)={1} group by DepName ,DeptID,MASta,MATimes,MATime";
//            sqlStr = string.Format(sqlStr, depid, yearMonth, pici);
//            DataTable dt = DBUnity.AdapterToTab(sqlStr);
//            return dt;
//        }
    }
}
