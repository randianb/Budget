using BudgetWeb.DAL;
using BudgetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace BudgetWeb.BLL
{
    public  class BG_MonPayPlanLogic
    {
        public static DataTable GetMpFunding(int ppid, int DepID, string ARTime, int pici)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_MonPayPlan where piid={0} and DeptId={1} and  convert(varchar(7),MPTime,120)='{2}' and MPFundingAddTimes={3}", ppid, DepID, ARTime,pici);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        public static int GetmonthbyMonPayPlan (int depID)
        {
            
            int month = 0;
            string sql = string.Format("select max(Month(MATime)) as mon from BG_MonPayPlanRemark where MASta='审核通过' and DeptID={0}", depID);
            month = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            return month;
        }

        public static DataTable GetMpFunding(int depId, string yearMonth)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_MonPayPlan where  DeptId={0} and  convert(varchar(7),MPTime,120)='{1}'", depId, yearMonth);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetPIETotal(int Year, int depId)
        {
            string sql =
                string.Format(
                    "select PIEcoSubParID ,sum(PIRtotal)as PIRtotal from( select case when PIEcoSubParID=0 then e.PIID else PIEcoSubParID end as PIEcoSubParID ,sum(totalmon)as PIRtotal from (select a.PIID,sum (b.BAAMon)  + sum(b.SuppMon) as totalmon from dbo.BG_PayIncome as a right join dbo.BG_BudgetAllocation as b on a.PIID=b.PIID  Where b.BAAYear={0} and b.DepID={1} group by a.PIID ) as e left join BG_PayIncome as f on e.PIID=f.PIID group by PIEcoSubName,PIEcoSubParID,e.PIID) as j group by PIEcoSubParID", Year, depId);
            DataTable dtTable = DBUnity.AdapterToTab(sql);
            return dtTable;
        }
     public static DataTable GetEiditeTotal(string YearMon, int depId,int pici)
        {
            string sql =
                string.Format(
                    " select sum(a.MPFundingAdd)as MPFundingAdd, f.PIEcoSubParID from ( select *   from [dbo].[BG_MonPayPlan] where Convert(varchar(7),MPTime,120)='{0}' and DeptID={1} and MPFundingAddTimes={2}) as a left join BG_PayIncome as f on a.PIID=f.PIID group by f.PIEcoSubParID", YearMon, depId, pici);
            DataTable dtTable = DBUnity.AdapterToTab(sql);
            return dtTable;
        }
        public static DataTable GetMpFundingTotal(int depId, string yearMonth)
        {
             string sql =
                string.Format(
                    " select PIEcoSubParID,sum(Mon)as Mon from ( select case when f.PIEcoSubParID=0 then a.PIID else f.PIEcoSubParID end as PIEcoSubParID , sum(a.MPFunding)as Mon from ( select *   from [dbo].[BG_MonPayPlan] where Convert(varchar(7),MPTime,120)='{0}' and DeptID={1}) as a left join BG_PayIncome as f on a.PIID=f.PIID group by f.PIEcoSubParID,a.PIID) as u group by PIEcoSubParID", yearMonth, depId);
            DataTable dtTable = DBUnity.AdapterToTab(sql);
            return dtTable;
        }

        public static DataTable GetMpFundingPPIEName(int depId, string yearMonth ,int pici)
        {
            string sql =
                string.Format(
                   " select isnull(ParentPIEcoSubName,a.PIID)as ParentPIEcoSubName ,isnull(f.PIEcoSubName,a.PIID) as PIEcoSubName,MPFundingAdd*10000 as MPFundingAdd1,MPPHisTime,MPRemark  from  ( select *   from [dbo].[BG_MonPayPlan_His] where Convert(varchar(7),MPTime,120)='{0}' and DeptID={1} and MPFundingAddTimes={2}) as a left join(select b.*,c.PIEcoSubName as ParentPIEcoSubName  from BG_PayIncome as b inner join BG_PayIncome as c on b.PIEcoSubParID=c.PIID and c.PIEcoSubParID=0) as f on a.PIID=f.PIID order by MPPHisTime desc", yearMonth, depId, pici);
            DataTable dtTable = DBUnity.AdapterToTab(sql);
            return dtTable;
        }

        public static int GetTimes(int depId, int piid, string yearMonth)
        {
            string sqlStr =
                string.Format(
                    "select *  from BG_MonPayPlan where DEPTID={0} and  PIID={1} and  Convert(varchar(7),MPTime,120)='{2}'",
                    depId, piid, yearMonth);
            int t =common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        }
    }
}
