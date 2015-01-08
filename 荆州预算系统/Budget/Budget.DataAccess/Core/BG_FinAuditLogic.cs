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
    public class BG_FinAuditLogic
    {
        public static DataTable GetFinAudit(int dept, int year, int month,int pici)
        {
            string sqlStr = "select PRID,PIEcoSubParID,DepName,PIEcoSubName,MPFundingAdd*10000 as MPFunding,MASta,MACause ,CPID,BG_PayIncome.PIID,DeptID,MPFundingAdd,MPTime from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2} and MATimes={3} and MASta='未提交'";
            sqlStr = string.Format(sqlStr, dept, year, month, pici);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static DataTable GetFinAudit1(int depid, int year, int month,int pici)
        {
            string sqlStr = "SELECT   PIEcoSubParID, DepName, PIEcoSubName, SUM(MPFunding) AS MPFunding, MASta, MACause FROM      (select  a.PIEcoSubParID,DepName,isnull(b.PIEcoSubName,a.PIEcoSubName) as PIEcoSubName,sum(MPFundingAdd)*10000 as MPFunding,MASta,null as MACause from  (select  BG_PayIncome.PIID,DepName,PIEcoSubName,MPFundingAdd,MPFunding,MASta,MACause,BG_PayIncome.PIEcoSubParID from vMonPlayRemark left join BG_PayIncome on vMonPlayRemark.PIID=BG_PayIncome.PIID left join  dbo.BG_Department on vMonPlayRemark.deptid=BG_Department.DepID where deptid={0} and  year(MPTime)={1} and month(MPTime)={2}and MATimes={3} and MASta='未提交' ) as a left join[dbo].[BG_PayIncome] as b on a.PIEcoSubParID=b.PIID group by a.PIEcoSubParID,DepName,b.PIEcoSubName,MASta,a.PIEcoSubName) AS z GROUP BY PIEcoSubParID, DepName, PIEcoSubName, MASta, MACause";
            sqlStr = string.Format(sqlStr, depid, year, month,pici);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static int GetAllTimes(int cpid)
        {
            string sqlStr = string.Format("select COUNT(*)  from  [dbo].[BG_MonPayPlan_Attach] where CPID={0}",cpid);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        }
    }
}
