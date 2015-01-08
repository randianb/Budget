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

public partial class Default2 : System.Web.UI.Page
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

    //2013零户
    private void LHDataBindyear()
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode ");
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
                    string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                    sqlStr = string.Format(sqlStr, piid, time);
                    DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                    if (dt2 != null && dt2.Rows.Count > 0)
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

    //2013年区级
    private void QJDataBindyear()
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode");
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
                    string sqlStr = "select * from FA_XOutlayIncomeCK where PIID={0} and ODCKTime='{1}'";
                    sqlStr = string.Format(sqlStr, piid, time);
                    DataTable dt2 = DBUnity.AdapterToTab(sqlStr);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        FA_XOutlayIncomeCK fa = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                        fa.PIID = piid;
                        fa.ODCKAreaMon = ToDec(dt.Rows[i]["l_Currency"]);
                        fa.ODCKZeroMon = fa.ODCKZeroMon;
                        fa.ODCKTime = time;
                        if (FA_XOutlayIncomeCKManager.ModifyFA_XOutlayIncomeCK(fa))
                        {
                            //lblResutle.Text = "添加成功";
                        }
                        else
                        {
                            //lblResutle.Text = "操作失败";
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

    protected void btnlh_Click(object sender, EventArgs e)
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode");
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

    protected void btnqj_Click(object sender, EventArgs e)
    {
        string sql = string.Format("SELECT   SUM(l_Currency) AS l_Currency, l_Year, l_Period, l_SubjectDescription, l_SubjectCode FROM  payUnion GROUP BY l_Year, l_Period, l_SubjectDescription, l_SubjectCode");
        DataTable dt = DBUnity.AdapterToTab("server=148.20.158.3;database=jaqj2014-5;User ID=sa;Password=", sql);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt1 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string piecosuball = dt1.Rows[j]["PIEcoSubCoding"].ToString();
            int piid  = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
            DateTime time = new DateTime();
            DateTime time1 = new DateTime();
            decimal monTotal = 0;
            string sqlstr = string.Format("SELECT   a.PIID, a.ODCKAreaMon, a.ODCKZeroMon, a.ODCKTime, b.PIEcoSubCoding, b.PIEcoSubParID, b.PIEcoSubName FROM  dbo.FA_XOutlayIncomeCK AS a INNER JOIN dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE   (YEAR(a.ODCKTime) = 2014)");
            DataTable dt = DBUnity.AdapterToTab(sqlstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piEcoSubParID = common.IntSafeConvert(dt.Rows[i]["PIEcoSubParID"]);
                time = Convert.ToDateTime(dt.Rows[i]["ODCKTime"].ToString());
                time1 = Convert.ToDateTime(DateTime.Now.Year + "-" + "09");
                if (piid == piEcoSubParID && time == time1)
                {
                    monTotal += ToDec(dt.Rows[i]["ODCKZeroMon"]);
                }       
            }
            if (piid != 0 && monTotal!=0)
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt1 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string piecosuball = dt1.Rows[j]["PIEcoSubCoding"].ToString();
            int piid  = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
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



}