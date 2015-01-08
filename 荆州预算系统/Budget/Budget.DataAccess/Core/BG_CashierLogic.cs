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
    public class BG_CashierLogic
    { 
        public static DataTable GetCashierAudit_Remark(int depid, string yearMon)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("SELECT   a.CPID, a.PIID, a.MPFunding, a.DeptID, a.MPTime, a.PRID, a.Expr1, a.MATime, a.MASta, a.MACause, a.MAUser, a.Expr2, a.PIEcoSubCoding, a.PIEcoSubLev, a.PIEcoSubParID, a.PIEcoSubName, a.PIType, a.ISSign, a.DepID, a.DepLev, a.FaDepID, a.DepCode, a.DepName, a.DepQua, a.DepSta, a.DepRem, b.Cashierid, b.Piid AS Expr3, ISNULL(b.BgMon,0) as BgMon, ISNULL(b.CZMon,0) as CZMon, ISNULL(b.QTMon,0) as QTMon, ISNULL(b.BQMon,0) as BQMon, b.Ctime FROM      (SELECT   dbo.vMonPlayRemark.CPID, dbo.vMonPlayRemark.PIID, dbo.vMonPlayRemark.MPFunding, dbo.vMonPlayRemark.DeptID, dbo.vMonPlayRemark.MPTime, dbo.vMonPlayRemark.PRID, dbo.vMonPlayRemark.Expr1, dbo.vMonPlayRemark.MATime, dbo.vMonPlayRemark.MASta, dbo.vMonPlayRemark.MACause, dbo.vMonPlayRemark.MAUser, dbo.BG_PayIncome.PIID AS Expr2, dbo.BG_PayIncome.PIEcoSubCoding, dbo.BG_PayIncome.PIEcoSubLev, dbo.BG_PayIncome.PIEcoSubParID, dbo.BG_PayIncome.PIEcoSubName, dbo.BG_PayIncome.PIType, dbo.BG_PayIncome.ISSign, dbo.BG_Department.DepID, dbo.BG_Department.DepLev, dbo.BG_Department.FaDepID, dbo.BG_Department.DepCode, dbo.BG_Department.DepName, dbo.BG_Department.DepQua, dbo.BG_Department.DepSta, dbo.BG_Department.DepRem FROM      dbo.vMonPlayRemark LEFT OUTER JOIN dbo.BG_PayIncome ON dbo.vMonPlayRemark.PIID = dbo.BG_PayIncome.PIID LEFT OUTER JOIN dbo.BG_Department ON dbo.vMonPlayRemark.DeptID = dbo.BG_Department.DepID WHERE   (dbo.vMonPlayRemark.DeptID = {0}) AND (CONVERT(varchar(7), dbo.vMonPlayRemark.MATime, 120) = '{1}') AND (dbo.vMonPlayRemark.MASta = '审核通过')) AS a LEFT OUTER JOIN (SELECT   Cashierid, Piid, BgMon, CZMon, QTMon, BQMon, DepID, Ctime FROM      dbo.BG_Cashier where CONVERT(varchar(7),Ctime, 120) = '{1}') AS b ON a.PIID = b.Piid and a.DepID=b.DepID ", depid, yearMon);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
 

        public static int GetCashierIDAudit_RemarkByPiid(int depid, string yearMon, int piid)
        {
            int t = 0;
            try
            {
                string sql = string.Format("select CashierID from dbo.BG_Cashier where Depid={0} and convert(varchar(7), Ctime, 120) = '{1}' and PIID={2}", depid, yearMon, piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text,sql,null));
                return t;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
