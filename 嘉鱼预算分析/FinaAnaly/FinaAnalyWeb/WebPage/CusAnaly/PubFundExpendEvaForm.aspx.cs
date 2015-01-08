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

public partial class WebPage_CusAnaly_PubFundExpendEvaForm : System.Web.UI.Page
{
    int uselim = 0;
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uselim"] != null && Request.QueryString["depid"] != null)
        {
            uselim = common.IntSafeConvert(Request.QueryString["uselim"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
    }
    protected void btnComplexAssessAnalyTB_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComplexAssessAnalyTB.aspx", true);
    }
    protected void btnBalanceEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("BalanceEvaForm.aspx", true);
    }
    protected void btnFundIncEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundIncEvaForm.aspx", true);
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

    //本期支出总数
    private decimal GetCurTotal(string name)
    {
        DateTime timeStart = Convert.ToDateTime(tbStartDate.Text);
        DateTime timeEnd = Convert.ToDateTime(tbEndDate.Text);
        int piid = 0;
        decimal tatol = 0;
        DataTable dt1 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(name);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                decimal dcCurTotal = 0;
                DataTable dt = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimeRange(timeStart, timeEnd, piid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ddlType.SelectedValue == "0")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkZeroMon"]) + ToDec(dt.Rows[i]["ODCkAreaMon"]);
                        }
                        if (ddlType.SelectedValue == "1")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkZeroMon"]);
                        }
                        if (ddlType.SelectedValue == "2")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkAreaMon"]);
                        }
                    }
                }
                tatol += dcCurTotal;
            }
        }
        return tatol;
    }

    //同期支出总数
    private decimal GetLastTotal(string name)
    {
        DateTime timeStart = Convert.ToDateTime((Convert.ToDateTime(tbStartDate.Text).Year - 1).ToString() + "-" + Convert.ToDateTime(tbStartDate.Text).Month.ToString());
        DateTime timeEnd = Convert.ToDateTime((Convert.ToDateTime(tbEndDate.Text).Year - 1).ToString() + "-" + Convert.ToDateTime(tbEndDate.Text).Month.ToString());
        decimal tatol = 0;
        DataTable dt1 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(name);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt1.Rows[j]["PIID"]);
                decimal dcCurTotal = 0;
                DataTable dt = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimeRange(timeStart, timeEnd, piid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ddlType.SelectedValue == "0")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkZeroMon"]) + ToDec(dt.Rows[i]["ODCkAreaMon"]);
                        }
                        if (ddlType.SelectedValue == "1")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkZeroMon"]);
                        }
                        if (ddlType.SelectedValue == "2")
                        {
                            dcCurTotal = dcCurTotal + ToDec(dt.Rows[i]["ODCkAreaMon"]);
                        }
                    }
                }
                tatol += dcCurTotal;
            }
        }
        return tatol;
    }
    //本期人平数
    private decimal GetCurNum(string name)
    {
        decimal CurNum = 0;
        int year = Convert.ToDateTime(tbStartDate.Text).Year;

        FA_SysSetting fa = FA_SysSettingManager.GetSysSettingByYear(year);
        if (fa != null && fa.StaffNum != 0)
        {
            CurNum = GetCurTotal(name) / ToDec(fa.StaffNum);
        }
        return CurNum;
    }

    //同期人平数
    private decimal GetLastNum(string name)
    {
        decimal CurNum = 0;
        int year = Convert.ToDateTime(tbStartDate.Text).Year - 1;
        FA_SysSetting fa = FA_SysSettingManager.GetSysSettingByYear(year);
        if (fa != null && fa.StaffNum != 0)
        {
            CurNum = GetLastTotal(name) / ToDec(fa.StaffNum);
        }
        return CurNum;
    }

    private void AddDataRow(DataTable dt, string name1, string name)
    {
        DataRow dr = dt.NewRow();
        dr["column2"] = name1;
        if (GetCurTotal(name) != 0)
        {
            dr["column3"] = (GetCurTotal(name)).ToString("f2");
        }
        if (GetLastTotal(name) != 0)
        {
            dr["column4"] = (GetLastTotal(name)).ToString("f2");
        }
        if (GetLastTotal(name) != 0)
        {
            dr["column5"] = ((Math.Abs(GetCurTotal(name) - GetLastTotal(name)) / GetLastTotal(name)) * 100).ToString("f2") + "%";

        }
        if (Math.Abs(GetCurTotal(name) - GetLastTotal(name)) != 0)
        {
            dr["column6"] = (Math.Abs(GetCurTotal(name) - GetLastTotal(name))).ToString("f2");
        }
        if (GetCurNum(name) != 0)
        {
            dr["column7"] = (GetCurNum(name)).ToString("f2");
        }
        if (GetLastNum(name) != 0)
        {
            dr["column8"] = (GetLastNum(name)).ToString("f2");
        }
        if (GetLastNum(name) != 0 && Math.Abs(GetCurNum(name) - GetLastNum(name)) / GetLastNum(name) != 0)
        {
            dr["column9"] = ((Math.Abs(GetCurNum(name) - GetLastNum(name)) / GetLastNum(name)) * 100).ToString("f2") + "%";

        }
        if (Math.Abs(GetCurNum(name) - GetLastNum(name)) != 0)
        {
            dr["column10"] = (Math.Abs(GetCurNum(name) - GetLastNum(name))).ToString("f2");
        }
        dt.Rows.Add(dr);
    }

    private void ComplexDataBind()
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
        dt.Columns.Add("column9");
        dt.Columns.Add("column10");
        dt.Columns.Add("column11");
        dt.Columns.Add("column12");
        dt.Columns.Add("column13");

        GetRows(dt);

        RepPubFund.DataSource = dt;
        RepPubFund.DataBind();

    }

    private void GetRows(DataTable dt)
    {
        AddDataRow(dt, "商品和服务支出", "商品和服务支出");
        AddDataRow(dt, "　　　办公费", "办公费");
        AddDataRow(dt, "　　　印刷费", "印刷费");
        AddDataRow(dt, "　　　咨询费", "咨询费");
        AddDataRow(dt, "　　　手续费", "手续费");
        AddDataRow(dt, "　　　水费", "水费");
        AddDataRow(dt, "　　　电费", "电费");
        AddDataRow(dt, "　　　邮电费", "邮电费");
        AddDataRow(dt, "　　　取暖费", "取暖费");
        AddDataRow(dt, "　　　物业管理费", "物业管理费");
        AddDataRow(dt, "　　　差旅费", "差旅费");
        AddDataRow(dt, "　　　因公出国（境）费用", "因公出国（境）费用");
        AddDataRow(dt, "　　　维修（护）费", "维修（护）费");
        AddDataRow(dt, "　　　租赁费", "租赁费");
        AddDataRow(dt, "　　　会议费", "会议费");
        AddDataRow(dt, "　　　培训费", "培训费");
        AddDataRow(dt, "　　　公务接待费", "公务接待费");
        AddDataRow(dt, "　　　被装购置费", "被装购置费");
        AddDataRow(dt, "　　　劳务费", "劳务费");
        AddDataRow(dt, "　　　委托业务费", "委托业务费");
        AddDataRow(dt, "　　　工会经费", "工会经费");
        AddDataRow(dt, "　　　福利费", "福利费");
        AddDataRow(dt, "　　　公务用车运行维护费", "公务用车运行维护费");
        AddDataRow(dt, "　　　　　　租用费", "租用费");
        AddDataRow(dt, "　　　　　　燃料费", "燃料费");
        AddDataRow(dt, "　　　　　　维护费", "维护费");
        AddDataRow(dt, "　　　　　　过桥过路费", "过桥过路费");
        AddDataRow(dt, "　　　　　　保险费", "保险费");
        AddDataRow(dt, "　　　　　　安全奖励费用", "安全奖励费用");
        AddDataRow(dt, "　　　　　　其他", "其他");
        AddDataRow(dt, "　　　其他交通费用", "其他交通费用");
        AddDataRow(dt, "　　　其他商品和服务支出", "其他商品和服务支出");

        AddDataRow(dt, "　　　　　　税法宣传费", "税法宣传费");
        AddDataRow(dt, "　　　　　　稽查办案费", "稽查办案费");
        AddDataRow(dt, "　　　　　　税务工作经费", "税务工作经费");
        AddDataRow(dt, "　　　　　　发票工作经费", "发票工作经费");
        AddDataRow(dt, "　　　　　　协税护税费", "协税护税费");
        AddDataRow(dt, "　　　　　　党团工会活动经费", "党团工会活动经费");
        AddDataRow(dt, "　　　　　　妇代会", "妇代会");
        AddDataRow(dt, "　　　　　　三代手续费", "三代手续费");
        AddDataRow(dt, "　　　　　　计算机应用经费", "计算机应用经费");
        AddDataRow(dt, "　　　　　　食堂经费", "食堂经费");
        AddDataRow(dt, "　　　　　　其他", "其他");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int year1 = Convert.ToDateTime(tbStartDate.Text).Year;
        int year2 = Convert.ToDateTime(tbEndDate.Text).Year;
        HidSearchFlag.Value = "0";
        ComplexDataBind();
        HidSearchFlag.Value = "1";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbStartDate.Text + "至" + tbEndDate.Text + ")日常公用经费支出评估表.xls";
        DataTable dt = new DataTable();
        //dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("column9");
        dt.Columns.Add("column10");
        dt.Columns.Add("column11");
        dt.Columns.Add("column12");
        dt.Columns.Add("column13");

        GetRows(dt);

        TableCell[] header = new TableCell[14];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "日常公用经费支出评估表";
        header[0].ColumnSpan = 10;
        header[1].Text = "单位:元</th></tr><tr>";
        header[1].ColumnSpan = 2;

        header[2].Text = "经济科目";
        header[3].Text = "本期支出总数";
        header[4].Text = "同期支出总数";
        header[5].Text = "同期±%";

        header[6].Text = "增减值";
        header[7].Text = "本期人平数";
        header[8].Text = "同期人平数";
        header[9].Text = "人平±%";
        header[10].Text = "增减值";
        header[11].Text = "本期区域人平数";
        header[12].Text = "人平区域±%";
        header[13].Text = "增减值</th>";
        

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            mergeCellNums.Add(i, 0);
        }
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
    }
}