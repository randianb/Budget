using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using FinaAnaly.BLL;
using System.Data;
using FinaAnaly.DAL;
using Common;
using FinaAnaly.Model;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtRequest_Click(object sender, EventArgs e)
    {
        //LHDataBind();
        //LHHigDataBind();
        //QJDataBind();
        //QJHigDataBind();
        //LHDepDataBind();
        //QJDepDataBind();
        string name = txtUser.Text;
        string power = txtPow.Text;

        DataTable dt= FA_UserManager.GetDtUserBynamepwd(name, power);
        if (dt != null && dt.Rows.Count > 0)
        {
            int userlim = common.IntSafeConvert(dt.Rows[0]["UserLim"]);
            int depid = common.IntSafeConvert(dt.Rows[0]["DepID"]);
            string pur = dt.Rows[0]["UserPurStr"].ToString();
            string UserName = dt.Rows[0]["UserName"].ToString();
            Response.Redirect("Default.aspx?userlim=" + userlim + "&depid=" + depid + "&pur=" + pur + "&UserName=" + UserName, true);
        }
    }

    //2014年零户
    private void LHDataBind()
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jalh2014;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                int piid = 0;
                FA_XPayIncome xpi = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcoding(piecosub);
                if (xpi != null)
                {
                    piid = xpi.PIID;
                }
                DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                sqlStr = string.Format(sqlStr, piid, time);
                DataTable dt1 = DBUnity.AdapterToTab(sqlStr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fa = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    fa.PIID = piid;
                    fa.ODCKAreaMon = fa.ODCKAreaMon;
                    fa.ODCKZeroMon = ToDec(dt.Rows[i]["l_Currency"]);
                    fa.ODCKTime = time;
                    if (FA_XOutlayIncomeCKManager.ModifyFA_XOutlayIncomeCK(fa))
                    {

                    }
                }
                else
                {
                    FA_XOutlayIncomeCK fa = new FA_XOutlayIncomeCK();
                    fa.PIID = piid;
                    fa.ODCKAreaMon = 0;
                    fa.ODCKZeroMon = ToDec(dt.Rows[i]["l_Currency"]);
                    fa.ODCKTime = time;
                    if (FA_XOutlayIncomeCKManager.AddFA_XOutlayIncomeCK(fa).ODID > 0)
                    {

                    }
                }
            }
        }
    }

    //2014年零户上级数据
    private void LHHigDataBind()
    {
        DataTable dt1 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string piecosuball = dt1.Rows[j]["PIEcoSubCoding"].ToString();
            int piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
            DateTime time = new DateTime();
            DateTime time1 = new DateTime();
            decimal monTotal = 0;
            string sqlstr = string.Format("SELECT   a.PIID, a.ODCKAreaMon, a.ODCKZeroMon, a.ODCKTime, b.PIEcoSubCoding, b.PIEcoSubParID, b.PIEcoSubName FROM  dbo.FA_XOutlayIncomeCK AS a INNER JOIN dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE   (YEAR(a.ODCKTime) = 2014)");
            DataTable dt = DBUnity.AdapterToTab(sqlstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piEcoSubParID = common.IntSafeConvert(dt.Rows[i]["PIEcoSubParID"]);
                time = Convert.ToDateTime(dt.Rows[i]["ODCKTime"].ToString());
                time1 = Convert.ToDateTime(DateTime.Now.Year + "-" + "06");
                if (piid == piEcoSubParID && time == time1)
                {
                    monTotal += ToDec(dt.Rows[i]["ODCKZeroMon"]);
                }
            }
            if (piid != 0 && monTotal != 0)
            {
                string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                sqlStr = string.Format(sqlStr, piid, time1);
                DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                if (dt2 != null & dt2.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fa = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    fa.PIID = piid;
                    fa.ODCKAreaMon = fa.ODCKAreaMon;
                    fa.ODCKZeroMon = monTotal;
                    fa.ODCKTime = time1;
                    if (FA_XOutlayIncomeCKManager.ModifyFA_XOutlayIncomeCK(fa))
                    {

                    }
                }
                else
                {
                    FA_XOutlayIncomeCK fa = new FA_XOutlayIncomeCK();
                    fa.PIID = piid;
                    fa.ODCKAreaMon = 0;
                    fa.ODCKZeroMon = monTotal;
                    fa.ODCKTime = time1;
                    if (FA_XOutlayIncomeCKManager.AddFA_XOutlayIncomeCK(fa).ODID > 0)
                    {

                    }
                }
            }
        }
    }

    //2014年区级
    private void QJDataBind()
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jaqj2014;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                int piid = 0;
                FA_XPayIncome xpi = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcoding(piecosub);
                if (xpi != null)
                {
                    piid = xpi.PIID;
                }
                DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                sqlStr = string.Format(sqlStr, piid, time);
                DataTable dt1 = DBUnity.AdapterToTab(sqlStr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fa = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    fa.PIID = piid;
                    fa.ODCKAreaMon = ToDec(dt.Rows[i]["l_Currency"]);
                    fa.ODCKZeroMon = fa.ODCKZeroMon;
                    fa.ODCKTime = time;
                    if (FA_XOutlayIncomeCKManager.ModifyFA_XOutlayIncomeCK(fa))
                    {

                    }
                }
                else
                {
                    FA_XOutlayIncomeCK fa = new FA_XOutlayIncomeCK();
                    fa.PIID = piid;
                    fa.ODCKAreaMon = ToDec(dt.Rows[i]["l_Currency"]);
                    fa.ODCKZeroMon = 0;
                    fa.ODCKTime = time;
                    if (FA_XOutlayIncomeCKManager.AddFA_XOutlayIncomeCK(fa).ODID > 0)
                    {

                    }
                }
            }

        }
    }

     //2014年区级上级数据
    private void QJHigDataBind()
    {
        DataTable dt1 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string piecosuball = dt1.Rows[j]["PIEcoSubCoding"].ToString();
            int piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
            DateTime time = new DateTime();
            DateTime time1 = new DateTime();
            decimal monTotal = 0;
            string sqlstr = string.Format("SELECT   a.PIID, a.ODCKAreaMon, a.ODCKZeroMon, a.ODCKTime, b.PIEcoSubCoding, b.PIEcoSubParID, b.PIEcoSubName FROM  dbo.FA_XOutlayIncomeCK AS a INNER JOIN dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE   (YEAR(a.ODCKTime) = 2014)");
            DataTable dt = DBUnity.AdapterToTab(sqlstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piEcoSubParID = common.IntSafeConvert(dt.Rows[i]["PIEcoSubParID"]);
                time = Convert.ToDateTime(dt.Rows[i]["ODCKTime"].ToString());
                time1 = Convert.ToDateTime(DateTime.Now.Year + "-" + "06");
                if (piid == piEcoSubParID && time == time1)
                {
                    monTotal += ToDec(dt.Rows[i]["ODCKAreaMon"]);
                }
            }
            if (piid != 0 && monTotal != 0)
            {
                string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                sqlStr = string.Format(sqlStr, piid, time1);
                DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                if (dt2 != null & dt2.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fa = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    fa.PIID = piid;
                    fa.ODCKAreaMon = monTotal;
                    fa.ODCKZeroMon = fa.ODCKZeroMon;
                    fa.ODCKTime = time1;
                    if (FA_XOutlayIncomeCKManager.ModifyFA_XOutlayIncomeCK(fa))
                    {

                    }
                }
                else
                {
                    FA_XOutlayIncomeCK fa = new FA_XOutlayIncomeCK();
                    fa.PIID = piid;
                    fa.ODCKAreaMon = monTotal;
                    fa.ODCKZeroMon = 0;
                    fa.ODCKTime = time1;
                    if (FA_XOutlayIncomeCKManager.AddFA_XOutlayIncomeCK(fa).ODID > 0)
                    {

                    }
                }
            }
        }
    }

    //2014年部门零户
    private void LHDepDataBind()
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jalh2014;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                int piid = 0;
                FA_XPayIncome xpi = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcoding(piecosub);
                if (xpi != null)
                {
                    piid = xpi.PIID;
                }
                DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                string depname = dt.Rows[i]["l_Name"].ToString();
                int depid = 0;
                FA_Department dep = FA_DepartmentManager.GetXPayIncomeByDepName(depname);
                if (dep != null)
                {
                    depid = dep.DepID;
                }
                string sqlStr = "select * from FA_XOutlayDepCK where PIID={0} and ODCKTime='{1}' and DepID={2}";
                sqlStr = string.Format(sqlStr, piid, time, depid);
                DataTable dt1 = DBUnity.AdapterToTab(sqlStr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    FA_XOutlayDepCK fa = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time, piid, depid);
                    fa.DepID = depid;
                    fa.ODCkTime = time;
                    fa.PIID = piid;
                    fa.ODCkAreaMon = fa.ODCkAreaMon;
                    fa.ODCkZeroMon = ToDec(dt.Rows[i]["Expr1"]);
                    if (FA_XOutlayDepCKManager.ModifyFA_XOutlayDepCK(fa))
                    { }
                }
                else
                {
                    FA_XOutlayDepCK fa = new FA_XOutlayDepCK();
                    fa.DepID = depid;
                    fa.ODCkTime = time;
                    fa.PIID = piid;
                    fa.ODCkAreaMon = 0;
                    fa.ODCkZeroMon = ToDec(dt.Rows[i]["Expr1"]);
                    if (FA_XOutlayDepCKManager.AddFA_XOutlayDepCK(fa).ODID > 0)
                    { }
                }
            }
        }
    }

    //2014年部门区级
    private void QJDepDataBind()
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jaqj2014;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                int piid = 0;
                FA_XPayIncome xpi = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcoding(piecosub);
                if (xpi != null)
                {
                    piid = xpi.PIID;
                }
                DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                string depname = dt.Rows[i]["l_Name"].ToString();
                int depid = 0;
                FA_Department dep = FA_DepartmentManager.GetXPayIncomeByDepName(depname);
                if (dep != null)
                {
                    depid = dep.DepID;
                }
                string sqlStr = "select * from FA_XOutlayDepCK where PIID={0} and ODCKTime='{1}' and DepID={2}";
                sqlStr = string.Format(sqlStr, piid, time, depid);
                DataTable dt1 = DBUnity.AdapterToTab(sqlStr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    FA_XOutlayDepCK fa = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time, piid, depid);
                    fa.DepID = depid;
                    fa.ODCkTime = time;
                    fa.PIID = piid;
                    fa.ODCkAreaMon = ToDec(dt.Rows[i]["Expr1"]);
                    fa.ODCkZeroMon = fa.ODCkZeroMon;
                    if (FA_XOutlayDepCKManager.ModifyFA_XOutlayDepCK(fa))
                    { }
                }
                else
                {
                    FA_XOutlayDepCK fa = new FA_XOutlayDepCK();
                    fa.DepID = depid;
                    fa.ODCkTime = time;
                    fa.PIID = piid;
                    fa.ODCkAreaMon = ToDec(dt.Rows[i]["Expr1"]);
                    fa.ODCkZeroMon = 0;
                    if (FA_XOutlayDepCKManager.AddFA_XOutlayDepCK(fa).ODID > 0)
                    { }
                }
            }
        }
    }


    private Decimal ToDec(object obj)
    {
        Decimal decTmp = 0;
        if (obj != null)
        {
            string objStr = obj.ToString();
            if (!string.IsNullOrEmpty(objStr))
            {
                decTmp = ParseUtil.ToDecimal(objStr, decTmp);
            }
        }
        return decTmp;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUser.Text = string.Empty;
        txtPow.Text = string.Empty;
    }
}