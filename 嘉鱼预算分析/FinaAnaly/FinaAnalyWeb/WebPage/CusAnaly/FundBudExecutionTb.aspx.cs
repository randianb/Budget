using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_CusAnaly_FundBudExecutionTb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 预算总金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal BudMonData(string str,string type)
    {
        decimal BudMon = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int piid = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    FA_XIncomeBudAllocat fa = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(piid, year);
                    if (fa != null)
                    {
                        BudMon += fa.IBAMon;
                    }
                }
            }
        }
        return BudMon;
    }

    private decimal BudAddMonData(string str)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal mon = 0;
        FA_AddBudConNum fa = FA_AddBudConNumManager.GetFA_AddBudConNumByYear(year);
        if (fa != null)
        {
            if (str == "工资福利支出")
            {
                mon = fa.AddUserMon;
            }
            if (str == "商品和服务支出")
            {
                mon = fa.AddPubMon;
            }
            if (str == "对个人和家庭补助支出")
            {
                mon = fa.AddFamMon;
            }
        }
        return mon;
    }

    private decimal BudTMonData(string str)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal mon = 0;
        FA_AddBudConNum fa = FA_AddBudConNumManager.GetFA_AddBudConNumByYear(year);
        if (fa != null)
        {
            if (str == "工资福利支出")
            {
                mon = fa.TUserMon;
            }
            if (str == "商品和服务支出")
            {
                mon = fa.TPubMon;
            }
            if (str == "对个人和家庭补助支出")
            {
                mon = fa.TFamMon;
            }
        }
        return mon;
    }

    /// <summary>
    /// 本月金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ThisMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dcZero = 0;
        DateTime time = Convert.ToDateTime(tbDate.Text);
        int piid = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    if (oick1 != null)
                    {
                        if (ddlType.SelectedValue == "0")
                        {
                            dcZero = dcZero + oick1.ODCKZeroMon + oick1.ODCKAreaMon;
                        }
                        if (ddlType.SelectedValue == "1")
                        {
                            dcZero = dcZero + oick1.ODCKZeroMon;
                        }
                        if (ddlType.SelectedValue == "2")
                        {
                            dcZero = dcZero + oick1.ODCKAreaMon;
                        }
                    }
                }
            }
        }
        return dcZero;
    }

    /// <summary>
    /// 项目支出本月金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ProThisMonData(string str)
    {
        DateTime time = Convert.ToDateTime(tbDate.Text);
        string type = ddlType.SelectedItem.Value;
        decimal ThisMon = 0;
        DataTable dt3 = FA_XPayIncomeManager.GetXPayIncomeByXPItype("项目支出");
        if (dt3 != null && dt3.Rows.Count > 0)
        {
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int piid = common.IntSafeConvert(dt3.Rows[i]["PIID"]);
                FA_XOutlayIncomeCK outlay = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (outlay != null)
                {
                    if (type == "0")
                    {
                        ThisMon += outlay.ODCKZeroMon + outlay.ODCKAreaMon;
                    }
                    if (type == "1")
                    {
                        ThisMon += outlay.ODCKZeroMon;
                    }
                    if (type == "2")
                    {
                        ThisMon += outlay.ODCKAreaMon;
                    }
                }
            }
        }
        return ThisMon;
    }

    /// <summary>
    /// 项目支出累计金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ProTatolMonData(string str)
    {
        DateTime time = Convert.ToDateTime(tbDate.Text);
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        string type = ddlType.SelectedItem.Value;
        decimal dclTatol=0;
        DataTable dt3 = FA_XPayIncomeManager.GetXPayIncomeByXPItype("项目支出");
        if (dt3 != null && dt3.Rows.Count > 0)
        {
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                decimal ThisMon = 0;
                int piid = common.IntSafeConvert(dt3.Rows[i]["PIID"]);
                for (int j = mon; j > 0; j--)
                {
                    DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + j.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        if (type == "0")
                        {
                            ThisMon += oick11.ODCKZeroMon + oick11.ODCKAreaMon;
                        }
                        if (type == "1")
                        {
                            ThisMon += oick11.ODCKZeroMon;
                        }
                        if (type == "2")
                        {
                            ThisMon += oick11.ODCKAreaMon;
                        }
                    }
                }
                dclTatol = dclTatol + ThisMon;
            }
        }
        return dclTatol;
    }

    /// <summary>
    /// 累计金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal TatolMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;        
        decimal dclTatol = 0;        
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                decimal dclBudTatol = 0;
                int piid = 0;
                if (dt.Rows[j]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            if (ddlType.SelectedValue == "0")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKZeroMon + oick11.ODCKAreaMon;
                            }
                            if (ddlType.SelectedValue == "1")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                            }
                            if (ddlType.SelectedValue == "2")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                            }
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        //}
        return dclTatol;
    }

    private void AddDataRow(DataTable dt, string name1, string name2, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (BudTMonData(name2) + BudAddMonData(name2) != 0)
        {
            dr["column2"] = (BudTMonData(name2) + BudAddMonData(name2)).ToString("f2");
        }
        if (BudTMonData(name2) != 0)
        {
            dr["column3"] = (BudTMonData(name2)).ToString("f2");
        }
        if (BudAddMonData(name2) != 0)
        {
            dr["column4"] = (BudAddMonData(name2)).ToString("f2");
        }
        if (ThisMonData(name2,type) != 0)
        {
            dr["column5"] = (ThisMonData(name2, type) / 10000).ToString("f2");
        }
        if (TatolMonData(name2, type) != 0)
        {
            dr["column6"] = (TatolMonData(name2, type) / 10000).ToString("f2");
        }
        if (ToDec(dr["column2"]) != 0 && ToDec(dr["column6"]) != 0)
        {
            dr["column7"] = ((ToDec(dr["column6"]) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column2"]) - ToDec(dr["column6"]) != 0)
        {
            dr["column8"] = (ToDec(dr["column2"]) - ToDec(dr["column6"])).ToString("f2");
        }
        dt.Rows.Add(dr);
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

    private void FunExpendBind()
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
        GetRows(dt);
        RepLeaderQuery.DataSource = dt;
        RepLeaderQuery.DataBind();
    }

    private void GetRows(DataTable dt)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal ProBudMon = 0;
        decimal thisProBudMon = 0;
        decimal AddProBudMon = 0;
        FA_BudConNum fa = FA_BudConNumManager.GetBudConNumByYear(year);
        if (fa != null)
        {
            thisProBudMon = fa.BCNProExpBudMon;
            AddProBudMon = fa.BCNProAddBudMon;
            ProBudMon = fa.BCNProExpBudMon + fa.BCNProAddBudMon;
        }


        DataRow dr1 = dt.NewRow();
        dr1["column1"] = "　　　　　合计";
        if (ProBudMon + BudTMonData("工资福利支出") + BudTMonData("商品和服务支出") + BudTMonData("对个人和家庭补助支出") + BudAddMonData("工资福利支出") + BudAddMonData("商品和服务支出") + BudAddMonData("对个人和家庭补助支出") != 0)
        {
            dr1["column2"] = (ProBudMon + BudTMonData("工资福利支出") + BudTMonData("商品和服务支出") + BudTMonData("对个人和家庭补助支出") + BudAddMonData("工资福利支出") + BudAddMonData("商品和服务支出") + BudAddMonData("对个人和家庭补助支出")).ToString("f2");
        }
        if (thisProBudMon + BudTMonData("工资福利支出") + BudTMonData("商品和服务支出") + BudTMonData("对个人和家庭补助支出") != 0)
        {
            dr1["column3"] = (thisProBudMon + BudTMonData("工资福利支出") + BudTMonData("商品和服务支出") + BudTMonData("对个人和家庭补助支出")).ToString("f2");
        }
        if (AddProBudMon + BudAddMonData("工资福利支出") + BudAddMonData("商品和服务支出") + BudAddMonData("对个人和家庭补助支出") != 0)
        {
            dr1["column4"] = (AddProBudMon + BudAddMonData("工资福利支出") + BudAddMonData("商品和服务支出") + BudAddMonData("对个人和家庭补助支出")).ToString("f2");
        }
        if (((ThisMonData("工资福利支出", "项目支出") + ThisMonData("其他商品和服务支出", "项目支出") + ThisMonData("其他资本性支出", "项目支出")) + ThisMonData("工资福利支出", "基本支出") + ThisMonData("商品和服务支出", "基本支出") + ThisMonData("对个人和家庭补助支出", "基本支出")) / 10000 != 0)
        {
            dr1["column5"] = ((ThisMonData("工资福利支出", "项目支出") + ThisMonData("其他商品和服务支出", "项目支出") + ThisMonData("其他资本性支出", "项目支出") + ThisMonData("工资福利支出", "基本支出") + ThisMonData("商品和服务支出", "基本支出") + ThisMonData("对个人和家庭补助支出", "基本支出")) / 10000).ToString("f2");
        }
        if ((TatolMonData("工资福利支出", "项目支出") + TatolMonData("其他商品和服务支出", "项目支出") + TatolMonData("其他资本性支出", "项目支出")) / 10000 + TatolMonData("工资福利支出", "基本支出") + TatolMonData("商品和服务支出", "基本支出") + TatolMonData("对个人和家庭补助支出", "基本支出") != 0)
        {
            dr1["column6"] = ((TatolMonData("工资福利支出", "项目支出") + TatolMonData("其他商品和服务支出", "项目支出") + TatolMonData("其他资本性支出", "项目支出") + TatolMonData("工资福利支出", "基本支出") + TatolMonData("商品和服务支出", "基本支出") + TatolMonData("对个人和家庭补助支出", "基本支出")) / 10000).ToString("f2");
        }
        if (ToDec(dr1["column2"]) != 0 && ToDec(dr1["column6"]) != 0)
        {
            dr1["column7"] = ((ToDec(dr1["column6"]) / ToDec(dr1["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr1["column2"]) - ToDec(dr1["column6"]) != 0)
        {
            dr1["column8"] = (ToDec(dr1["column2"]) - ToDec(dr1["column6"])).ToString("f2");
        }
        dt.Rows.Add(dr1);
        AddDataRow(dt, "　　　一、人员经费", "工资福利支出", "基本支出");
        AddDataRow(dt, "　　　二、公用经费", "商品和服务支出", "基本支出");
        AddDataRow(dt, "　　　三、对个人和家庭补助支出", "对个人和家庭补助支出", "基本支出");
        DataRow dr2 = dt.NewRow();
        dr2["column1"] = "　　　四、项目支出";
        if (ProBudMon != 0)
        {
            dr2["column2"] = (ProBudMon).ToString("f2");
        }
        if (thisProBudMon != 0)
        {
            dr2["column3"] = (thisProBudMon).ToString("f2");
        }
        if (AddProBudMon != 0)
        {
            dr2["column4"] = (AddProBudMon).ToString("f2");
        }
        if ((ThisMonData("工资福利支出", "项目支出") + ThisMonData("其他商品和服务支出", "项目支出") + ThisMonData("其他资本性支出", "项目支出")) != 0)
        {
            dr2["column5"] = ((ThisMonData("工资福利支出", "项目支出") + ThisMonData("其他商品和服务支出", "项目支出") + ThisMonData("其他资本性支出", "项目支出")) / 10000).ToString("f2");
        }
        if ((TatolMonData("工资福利支出", "项目支出") + TatolMonData("其他商品和服务支出", "项目支出") + TatolMonData("其他资本性支出", "项目支出")) != 0)
        {
            dr2["column6"] = ((TatolMonData("工资福利支出", "项目支出") + TatolMonData("其他商品和服务支出", "项目支出") + TatolMonData("其他资本性支出", "项目支出")) / 10000).ToString("f2");
        }
        if (ToDec(dr2["column2"]) != 0 && ToDec(dr2["column6"]) != 0)
        {
            dr2["column7"] = ((ToDec(dr2["column6"]) / ToDec(dr2["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr2["column2"]) - ToDec(dr2["column6"]) != 0)
        {
            dr2["column8"] = (ToDec(dr2["column2"]) - ToDec(dr2["column6"])).ToString("f2");
        }
        dt.Rows.Add(dr2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HidSearchFlag.Value = "0";
        FunExpendBind();
        HidSearchFlag.Value = "1";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbDate.Text + ")经费预算执行情况.xls";
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
        GetRows(dt);
        TableCell[] header = new TableCell[11];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "经费预算执行情况表";
        header[0].ColumnSpan = 7;
        header[1].Text = "单位:万元</th></tr><tr>";
        header[1].ColumnSpan = 2;
        header[2].Text = "项目分类";
        header[3].Text = "合计";
        header[4].Text = "本年预算指标";
        header[5].Text = "增拨预算指标";
        header[6].Text = "本月实际支出";
        header[7].Text = "累计实际支出";
        header[8].Text = "占预算比例";
        header[9].Text = "结余预算指标";
        header[10].Text = "备注</th>";

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            mergeCellNums.Add(i, 0);
        }
        
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
        
    }
}