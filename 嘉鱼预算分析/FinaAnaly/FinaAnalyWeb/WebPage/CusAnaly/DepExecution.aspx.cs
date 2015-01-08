using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_CusAnaly_DepExecution : System.Web.UI.Page
{
    int uselim = 0;
    int dePid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
            DepartListBind();

            if (Request.QueryString["depid"] != null && Request.QueryString["time"] != null && Request.QueryString["type"] != null && Request.QueryString["depnameAll"] != null)
            {
                int depid = common.IntSafeConvert(Request.QueryString["depid"].ToString());
                tbDate.Text = Convert.ToDateTime(Request.QueryString["time"]).Year + "-" + "0" + Convert.ToDateTime(Request.QueryString["time"]).Month;
                ddlType.SelectedValue = Request.QueryString["type"].ToString();
                ddlDep.SelectedItem.Text = Request.QueryString["depnameAll"].ToString();
                if (ddlDep.SelectedItem.Text == "全局")
                {
                    TotalOne.Visible = true;
                    TotalTwo.Visible = true;
                    DepAllBind();
                }
                else
                {
                    //depid = common.IntSafeConvert(ddlDep.SelectedItem.Value);
                    //FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
                    //if (fa != null)
                    //{
                    //    ddlDep.SelectedItem.Text = fa.DepName;
                    //}
                    ddlDep.SelectedItem.Value = depid.ToString();
                    TotalOne.Visible = false;
                    TotalTwo.Visible = false;
                    GetDataBind();
                    DepartListBind();
                }
            }
        }
        if (Request.QueryString["depid"] != null && Request.QueryString["uselim"] != null)
        {
            dePid = common.IntSafeConvert(Request.QueryString["depid"].ToString());
            FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(dePid);
            if (fa != null)
            {
                ddlDep.SelectedItem.Text = fa.DepName;
            }
            uselim = common.IntSafeConvert(Request.QueryString["uselim"]);
            if (tbDate.Text != "")
            {
                GetDataBind();
            }
        }
    }

    /// <summary>
    /// 绑定部门列表
    /// </summary>
    private void DepartListBind()
    {
        DataTable dt = FA_DepartmentManager.GetAllFA_Department();
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlDep.DataSource = dt;
            ddlDep.DataTextField = "DepName";
            ddlDep.DataValueField = "DepID";
            ddlDep.DataBind();
        }
        //ddlDep.Items.Add(new ListItem("全部", "0"));
        ddlDep.Items.Insert(0, new ListItem("全局", "0"));
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

    private void DepAllBind()
    {       
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("DepID");

        GetRows1(dt);
        repDepExecut.DataSource = dt;
        repDepExecut.DataBind();


    }

    private void GetRows1(DataTable dt)
    {
        DataTable dt2 = FA_DepartmentManager.GetAllFA_Department();
        int year = Convert.ToDateTime(tbDate.Text.Trim()).Year;
        int mon = Convert.ToDateTime(tbDate.Text.Trim()).Month;
        DateTime time = Convert.ToDateTime(tbDate.Text.Trim());
        int lyear = year - 1;
        DateTime timel = Convert.ToDateTime(lyear.ToString() + "-" + mon.ToString());
        decimal dclastTotal = 0;
        decimal dclastTotalTotal = 0;
        decimal dcThisTotal = 0;
        decimal dcThisTotalTotal = 0;
        decimal StartMonTotal = 0;
        if (ddlType.Text == "1")
        {
            TbOne.Visible = true;
            TbTwo.Visible = false;
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int depid = common.IntSafeConvert(dt2.Rows[i]["DepID"]);
                    DataTable dt1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(time, depid);
                    DataTable dt3 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(timel, depid);
                    decimal dclast = 0;
                    decimal dcThis = 0;
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()))
                        {
                            dcThis = ToDec(dt1.Rows[0]["ODCkZeroMon"]);
                        }
                    }
                    dcThisTotal = dcThisTotal + dcThis;
                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()))
                        {
                            dclast = ToDec(dt3.Rows[0]["ODCkZeroMon"]);
                        }
                    }
                    dclastTotal += dclast;
                    decimal StartMon = FA_DepBudAllocatManager.GetDepMonBydepidYear(depid, year);
                    StartMonTotal += StartMon;
                    DataRow dr = dt.NewRow();
                    dr["column1"] = dt2.Rows[i]["DepName"].ToString();
                    dr["DepID"] = dt2.Rows[i]["DepID"].ToString();
                    if (StartMon != 0)
                    {
                        dr["column2"] = (StartMon).ToString("f2");
                    }
                    if (dcThis != 0)
                    {
                        dr["column3"] = (dcThis).ToString("f2");
                    }
                    if (GetTatol(year, mon, depid) != 0)
                    {
                        dr["column4"] = (GetTatol(year, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0)
                    {
                        dr["column5"] = (dclast).ToString("f2");
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column6"] = (GetTatol(lyear, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0 && (dcThis - dclast) / dclast != 0)
                    {
                        dr["column7"] = (((dcThis - dclast) / dclast) * 100).ToString("f2") + "%";
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column8"] = (((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)) * 100).ToString("f2") + "%";
                    }
                    dt.Rows.Add(dr);
                    dcThisTotalTotal += GetTatol(year, mon, depid);
                    dclastTotalTotal += GetTatol(lyear, mon, depid);
                }
                txtStartMon.Text = (StartMonTotal).ToString("f2");
                TextBox1.Text = (dcThisTotal).ToString("f2");
                TextBox2.Text = (dcThisTotalTotal).ToString("f2");
                TextBox3.Text = (dclastTotal).ToString("f2");
                TextBox4.Text = (dclastTotalTotal).ToString("f2");
                if (dclastTotal != 0)
                {
                    TextBox5.Text = ((dcThisTotal - dclastTotal) / dclastTotal).ToString("f2");
                }
                if (dclastTotalTotal != 0)
                {
                    TextBox6.Text = ((dcThisTotalTotal - dclastTotalTotal) / dclastTotalTotal).ToString("f2");
                }
            }
            RepBugetTarget.DataSource = dt;
            RepBugetTarget.DataBind();
        }
        else if (ddlType.Text == "0")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int depid = common.IntSafeConvert(dt2.Rows[i]["DepID"]);
                    DataTable dt1 = null;
                    DataTable dt3 = null;
                    dt1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(time, depid);
                    dt3 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(timel, depid);
                    decimal dclast = 0;
                    decimal dcThis = 0;
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()))
                        {
                            dcThis = ToDec(dt1.Rows[0]["ODCkZeroMon"]) + ToDec(dt1.Rows[0]["ODCkAreaMon"]);
                        }
                    }
                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                        {
                            dclast = ToDec(dt3.Rows[0]["ODCkZeroMon"]) + ToDec(dt3.Rows[0]["ODCkAreaMon"]);
                        }
                    }
                    dcThisTotal += dcThis;
                    dclastTotal += dclast;
                    dcThisTotalTotal += GetTatol(year, mon, depid);
                    dclastTotalTotal += GetTatol(lyear, mon, depid);
                    DataRow dr = dt.NewRow();
                    dr["column1"] = dt2.Rows[i]["DepName"].ToString();
                    dr["DepID"] = dt2.Rows[i]["DepID"].ToString();
                    if (dcThis != 0)
                    {
                        dr["column2"] = (dcThis).ToString("f2");
                    }
                    if (GetTatol(year, mon, depid) != 0)
                    {
                        dr["column3"] = (GetTatol(year, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0)
                    {
                        dr["column4"] = (dclast).ToString("f2");
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column5"] = (GetTatol(lyear, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0 && (dcThis - dclast) / dclast != 0)
                    {
                        dr["column6"] = (((dcThis - dclast) / dclast) * 100).ToString("f2") + "%";
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column7"] = (((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)) * 100).ToString("f2") + "%";
                    }
                    dt.Rows.Add(dr);
                }
                txtThisThis.Text = (dcThisTotal).ToString("f2");
                txtThisTotal.Text = (dcThisTotalTotal).ToString("f2");
                txtLastThis.Text = (dclastTotal).ToString("f2");
                txtLastTotal.Text = (dclastTotalTotal).ToString("f2");
                if (dclastTotal != 0)
                {
                    txtDifThis.Text = ((dcThisTotal - dclastTotal) / dclastTotal).ToString("f2");
                }
                if (dclastTotalTotal != 0)
                {
                    txtDifTotal.Text = ((dcThisTotalTotal - dclastTotalTotal) / dclastTotalTotal).ToString("f2");
                }
            }
            repDepExecut.DataSource = dt;
            repDepExecut.DataBind();
        }
        else if (ddlType.Text == "2")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int depid = common.IntSafeConvert(dt2.Rows[i]["DepID"]);
                    DataTable dt1 = null;
                    DataTable dt3 = null;
                    dt1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(time, depid);
                    dt3 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(timel, depid);
                    decimal dclast = 0;
                    decimal dcThis = 0;
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()))
                        {
                            dcThis = ToDec(dt1.Rows[0]["ODCkAreaMon"]);
                        }
                    }
                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                        {
                            dclast = ToDec(dt3.Rows[0]["ODCkAreaMon"]);
                        }
                    }
                    dcThisTotal += dcThis;
                    dclastTotal += dclast;
                    dcThisTotalTotal += GetTatol(year, mon, depid);
                    dclastTotalTotal += GetTatol(lyear, mon, depid);
                    DataRow dr = dt.NewRow();
                    dr["column1"] = dt2.Rows[i]["DepName"].ToString();
                    dr["DepID"] = dt2.Rows[i]["DepID"].ToString();
                    if (dcThis != 0)
                    {
                        dr["column2"] = (dcThis).ToString("f2");
                    }
                    if (GetTatol(year, mon, depid) != 0)
                    {
                        dr["column3"] = (GetTatol(year, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0)
                    {
                        dr["column4"] = (dclast).ToString("f2");
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column5"] = (GetTatol(lyear, mon, depid)).ToString("f2");
                    }
                    if (dclast != 0 && (dcThis - dclast) / dclast != 0)
                    {
                        dr["column6"] = (((dcThis - dclast) / dclast) * 100).ToString("f2") + "%";
                    }
                    if (GetTatol(lyear, mon, depid) != 0)
                    {
                        dr["column7"] = (((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)) * 100).ToString("f2") + "%";
                    }
                    dt.Rows.Add(dr);

                }
                txtThisThis.Text = (dcThisTotal).ToString("f2");
                txtThisTotal.Text = (dcThisTotalTotal).ToString("f2");
                txtLastThis.Text = (dclastTotal).ToString("f2");
                txtLastTotal.Text = (dclastTotalTotal).ToString("f2");
                if (dclastTotal != 0)
                {
                    txtDifThis.Text = ((dcThisTotal - dclastTotal) / dclastTotal).ToString("f2");
                }
                if (dclastTotalTotal != 0)
                {
                    txtDifTotal.Text = ((dcThisTotalTotal - dclastTotalTotal) / dclastTotalTotal).ToString("f2");
                }
            }
        }
    }

    private decimal GetTatol(int year, int mon, int depid)
    {
        decimal dcTatol = 0;
        for (int i = mon; i > 0; i--)
        {
            DateTime time = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
            DataTable dt1 = null;
            //if (year < 2014)
            //{
            //    dt1 = FA_OutlayDepCKManager.GetOutlayDepCKByTimedepid(time, depid);
            //}
            //else
            //{
            dt1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(time, depid);
            //}
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()))
                {
                    if (ddlType.Text == "1")
                    {
                        dcTatol = dcTatol + ToDec(dt1.Rows[0]["ODCkZeroMon"]);
                    }
                    if (ddlType.Text == "0")
                    {
                        dcTatol = dcTatol + ToDec(dt1.Rows[0]["ODCkZeroMon"]) + ToDec(dt1.Rows[0]["ODCkAreaMon"]);
                    }
                    if (ddlType.Text == "2")
                    {
                        dcTatol = dcTatol + ToDec(dt1.Rows[0]["ODCkAreaMon"]);
                    }
                }
            }
        }
        return dcTatol;
    }

    private void GetDataBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("DepID");

        GetRows2(dt);
        repDepExecut.DataSource = dt;
        repDepExecut.DataBind();

    }

    private void GetRows2(DataTable dt)
    {
        int depid = 0;
        if (uselim == 1001)
        {
            depid = dePid;
        }
        else
        {
            depid = common.IntSafeConvert(ddlDep.SelectedValue);
        }
        int year = Convert.ToDateTime(tbDate.Text.Trim()).Year;
        int mon = Convert.ToDateTime(tbDate.Text.Trim()).Month;
        DateTime time = Convert.ToDateTime(tbDate.Text.Trim());
        int lyear = year - 1;
        DateTime timel = Convert.ToDateTime(lyear.ToString() + "-" + mon.ToString());
        decimal StartMon = FA_DepBudAllocatManager.GetDepMonBydepidYear(depid, year);
        DataTable dt1 = null;
        DataTable dt3 = null;
        dt1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(time, depid);
        dt3 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimedepid(timel, depid);
        //}
        decimal dclast = 0;
        decimal dcThis = 0;

        if (ddlType.Text == "1")
        {
            TbOne.Visible = true;
            TbTwo.Visible = false;
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                dcThis = ToDec(dt1.Rows[0]["ODCkZeroMon"]);
            }
            DataRow dr = dt.NewRow();
            dr["column1"] = ddlDep.SelectedItem.Text;
            dr["DepID"] = depid;
            if (StartMon != 0)
            {
                dr["column2"] = (StartMon).ToString("f2");
            }
            if (dcThis != 0)
            {
                dr["column3"] = (dcThis).ToString("f2");
            }
            if (GetTatol(year, mon, depid) != 0)
            {
                dr["column4"] = (GetTatol(year, mon, depid)).ToString("f2");
            }
            if (dclast != 0)
            {
                dr["column5"] = (dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column6"] = (GetTatol(lyear, mon, depid)).ToString("f2");
            }
            if (dclast != 0 && (dcThis - dclast) / dclast != 0)
            {
                dr["column7"] = ((dcThis - dclast) / dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column8"] = ((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)).ToString("f2");
            }
            dt.Rows.Add(dr);
            RepBugetTarget.DataSource = dt;
            RepBugetTarget.DataBind();
        }
        else if (ddlType.Text == "0")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()))
                {
                    dcThis = ToDec(dt1.Rows[0]["ODCkAreaMon"]) + ToDec(dt1.Rows[0]["ODCkZeroMon"]);
                }
            }
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                {
                    dclast = ToDec(dt3.Rows[0]["ODCkAreaMon"]) + ToDec(dt3.Rows[0]["ODCkZeroMon"]);
                }

            }
            DataRow dr = dt.NewRow();
            dr["column1"] = ddlDep.SelectedItem.Text;
            dr["DepID"] = depid;
            if (dcThis != 0)
            {
                dr["column2"] = (dcThis).ToString("f2");
            }
            if (GetTatol(year, mon, depid) != 0)
            {
                dr["column3"] = (GetTatol(year, mon, depid)).ToString("f2");
            }
            if (dclast != 0)
            {
                dr["column4"] = (dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column5"] = (GetTatol(lyear, mon, depid)).ToString("f2");
            }
            if (dclast != 0 && (dcThis - dclast) / dclast != 0)
            {
                dr["column6"] = ((dcThis - dclast) / dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column7"] = ((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)).ToString("f2");
            }
            dt.Rows.Add(dr);
            repDepExecut.DataSource = dt;
            repDepExecut.DataBind();
        }
        else if (ddlType.Text == "2")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()))
                {
                    dcThis = ToDec(dt1.Rows[0]["ODCkAreaMon"]);
                }
            }
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                {
                    dclast = ToDec(dt3.Rows[0]["ODCkAreaMon"]);
                }
            }
            DataRow dr = dt.NewRow();
            dr["column1"] = ddlDep.SelectedItem.Text;
            dr["DepID"] = depid;
            if (dcThis != 0)
            {
                dr["column2"] = (dcThis).ToString("f2");
            }
            if (GetTatol(year, mon, depid) != 0)
            {
                dr["column3"] = (GetTatol(year, mon, depid)).ToString("f2");
            }
            if (dclast != 0)
            {
                dr["column4"] = (dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column5"] = (GetTatol(lyear, mon, depid)).ToString("f2");
            }
            if (dclast != 0 && (dcThis - dclast) / dclast != 0)
            {
                dr["column6"] = ((dcThis - dclast) / dclast).ToString("f2");
            }
            if (GetTatol(lyear, mon, depid) != 0)
            {
                dr["column7"] = ((GetTatol(year, mon, depid) - GetTatol(lyear, mon, depid)) / GetTatol(lyear, mon, depid)).ToString("f2");
            }
            dt.Rows.Add(dr);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlDep.SelectedItem.Text != "全局")
        {
            TotalOne.Visible = false;
            TotalTwo.Visible = false;
            HidSearchFlag.Value = "0";
            GetDataBind();
            HidSearchFlag.Value = "1";
        }
        else
        {
            TotalOne.Visible = true;
            TotalTwo.Visible = true;
            HidSearchFlag.Value = "0";
            DepAllBind();
            HidSearchFlag.Value = "1";
        }
    }


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selVal = ddlType.SelectedValue;
        if (selVal == "0")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
        }
        if (selVal == "1")
        {
            TbOne.Visible = true;
            TbTwo.Visible = false;
        }
        if (selVal == "2")
        {
            TbOne.Visible = false;
            TbTwo.Visible = true;
        }
    }

    protected void RepBugetTarget_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int depid = common.IntSafeConvert(e.CommandArgument);
        if (e.CommandName == "PostToDetails")
        {
            int year = Convert.ToDateTime(tbDate.Text.Trim()).Year;
            int mon = Convert.ToDateTime(tbDate.Text.Trim()).Month;
            DateTime time = Convert.ToDateTime(tbDate.Text.Trim());
            int lyear = year - 1;
            DateTime timel = Convert.ToDateTime(lyear.ToString() + "-" + mon.ToString());
            string type = ddlType.SelectedValue;
            string depnameAll = ddlDep.SelectedItem.Text;
            Response.Redirect("EcoMon.aspx?depid=" + depid + "&time=" + time + "&time1=" + timel + "&type=" + type + "&depnameAll=" + depnameAll, true);

        }
    }

    protected void repDepExecut_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int depid = common.IntSafeConvert(e.CommandArgument);
        if (e.CommandName == "PostToDetails")
        {
            int year = Convert.ToDateTime(tbDate.Text.Trim()).Year;
            int mon = Convert.ToDateTime(tbDate.Text.Trim()).Month;
            DateTime time = Convert.ToDateTime(tbDate.Text.Trim());
            int lyear = year - 1;
            DateTime timel = Convert.ToDateTime(lyear.ToString() + "-" + mon.ToString());
            string type = ddlType.SelectedValue;

            string depnameAll = ddlDep.SelectedItem.Text;
            Response.Redirect("EcoMon.aspx?depid=" + depid + "&time=" + time + "&time1=" + timel + "&type=" + type + "&depnameAll=" + depnameAll, true);

        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbDate.Text + ")部门经费一览表.xls";
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("DepID");
        if (ddlDep.SelectedItem.Text != "全局")
        {
            GetRows2(dt);

            TableCell[] header = new TableCell[13];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = new TableHeaderCell();
            }
            header[0].Text = "部门执行情况表</th></tr><tr>";
            header[0].ColumnSpan = 5;
            header[1].Text = "单位:元";
            header[1].ColumnSpan = 2;

            header[2].Text = "部门名称";
            header[2].RowSpan = 2;
            header[3].Text = "本期数";
            header[3].ColumnSpan = 2;
            header[4].Text = "同期数";
            header[4].ColumnSpan = 2;
            header[5].Text = "差额比";
            header[5].ColumnSpan = 2;
            header[6].Text = "部门ID</th></tr><tr>";
            header[6].RowSpan = 2;

            header[7].Text = "本月";
            header[8].Text = "累计";
            header[9].Text = "本月";
            header[10].Text = "累计";
            header[11].Text = "本月";
            header[12].Text = "累计</th>";


            Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mergeCellNums.Add(i, 0);
            }
            common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
        }
        else
        {
            GetRows1(dt);

            TableCell[] header = new TableCell[13];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = new TableHeaderCell();
            }
            header[0].Text = "部门执行情况表</th></tr><tr>";
            header[0].ColumnSpan = 10;

            header[1].Text = "部门名称";
            header[1].RowSpan = 2;
            header[2].Text = "年初预算(万元)";
            header[2].RowSpan = 2;
            header[3].Text = "本期数(元)";
            header[3].ColumnSpan = 2;
            header[4].Text = "同期数(元)"; 
            header[4].ColumnSpan = 2;
            header[5].Text = "差额比";
            header[5].ColumnSpan = 2;
            header[6].Text = "部门ID</th></tr><tr>";
            header[6].RowSpan = 2;

            header[7].Text = "本月";
            header[8].Text = "累计";
            header[9].Text = "本月";
            header[10].Text = "累计";
            header[11].Text = "本月";
            header[12].Text = "累计</th>";


            Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mergeCellNums.Add(i, 0);
            }
            common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
        }
        
    }
}