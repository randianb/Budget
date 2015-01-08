using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.DAL;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using Common;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

    //2014年部门零户
    private void LHDataBind()
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
    private void QJDataBind()
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

    //2013零户
    private void LHDataBindyear()
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jalh2013;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                string piecoName = dt.Rows[i]["l_SubjectDescription"].ToString();
                int piid = 0;

                string sqlstr = "SELECT * FROM FA_XPayIncome WHERE PIEcoSubName = '{0}'";
                sqlstr = string.Format(sqlstr, piecoName);
                DataTable dt1 = DBUnity.AdapterToTab(sqlstr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string str1 = dt1.Rows[j]["PIEcoSubCoding"].ToString();
                        string str2 = str1.Substring(0, 8);
                        if (piecosub.Substring(0, 6) == "501001")
                        {
                            if (str2 == "50010101")
                            {
                                piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                            }
                        }
                        if (piecosub.Substring(0, 6) == "501002")
                        {
                            if (str2 == "50010102")
                            {
                                piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                            }
                        }
                    }
                    DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                    string depname = dt.Rows[i]["l_Name"].ToString();
                    int depid = 0;
                    FA_Department dep = FA_DepartmentManager.GetXPayIncomeByDepName(depname);
                    if (dep != null)
                    {
                        depid = dep.DepID;

                        string sqlStr = "select * from FA_XOutlayDepCK where PIID={0} and ODCKTime='{1}' and DepID={2}";
                        sqlStr = string.Format(sqlStr, piid, time, depid);
                        DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                        if (dt2 != null && dt2.Rows.Count > 0)
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
                            {
                                lblResutle.Text = "添加成功";
                            }
                            else
                            {
                                lblResutle.Text = "操作失败";
                            }
                        }
                    }
                }
            }
        }
    }

    //2013年区级
    private void QJDataBindyear()
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.124;database=jaqj2013;User ID=sa;Password=123", sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string piecosub = dt.Rows[i]["l_SubjectCode"].ToString();
                string piecoName = dt.Rows[i]["l_SubjectDescription"].ToString();
                int piid = 0;

                string sqlstr = "SELECT * FROM FA_XPayIncome WHERE PIEcoSubName = '{0}'";
                sqlstr = string.Format(sqlstr, piecoName);
                DataTable dt1 = DBUnity.AdapterToTab(sqlstr);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string str1 = dt1.Rows[j]["PIEcoSubCoding"].ToString();
                        string str2 = str1.Substring(0, 8);
                        if (piecosub.Substring(0, 6) == "501001")
                        {
                            if (str2 == "50010101")
                            {
                                piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                            }
                        }
                        if (piecosub.Substring(0, 6) == "501002")
                        {
                            if (str2 == "50010102")
                            {
                                piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                            }
                        }
                    }
                    DateTime time = Convert.ToDateTime(dt.Rows[i]["l_Year"].ToString() + "-" + dt.Rows[i]["l_Period"].ToString());
                    string depname = dt.Rows[i]["l_Name"].ToString();
                    int depid = 0;
                    FA_Department dep = FA_DepartmentManager.GetXPayIncomeByDepName(depname);
                    if (dep != null)
                    {
                        depid = dep.DepID;

                        string sqlStr = "select * from FA_XOutlayDepCK where PIID={0} and ODCKTime='{1}' and DepID={2}";
                        sqlStr = string.Format(sqlStr, piid, time, depid);
                        DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                        if (dt2 != null && dt2.Rows.Count > 0)
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
                            {
                                lblResutle.Text = "添加成功";
                            }
                            else
                            {
                                lblResutle.Text = "操作失败";
                            }
                        }

                    }
                }
            }
        }
    }

    protected void btnlh_Click(object sender, EventArgs e)
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=192.168.0.66;database=qqq;User ID=sa;Password=123", sql);
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


    protected void btnqj_Click(object sender, EventArgs e)
    {
        string sql = string.Format("select SUM(a.l_Currency) AS Expr1,b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name from TA_VoucherAttachInformation as a  left join dbo.TA_Subject  as b on a.l_SubjectID=b.l_SubjectID left join dbo.TA_Voucher as c on a.l_VoucherID=c.l_VoucherID left join dbo.TA_Department as d on a.l_DepartmentID=d.l_DepartmentID  where  (b.l_SubjectType LIKE '%5%')  group by b.l_SubjectCode,b.l_SubjectDescription,c.l_Year,c.l_Period,d.l_Name");
        DataTable dt = DBUnity.AdapterToTab("server=148.20.158.3;database=jlsoft00032014;User ID=sa;Password=", sql);
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
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}