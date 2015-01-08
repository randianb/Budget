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

public partial class WebPage_CusAnaly_ExceExpendTb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 本月金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ThisMonData(string str)
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
        return dcZero;
    }

    /// <summary>
    /// 累计金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal TatolMonData(string str)
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
        //}
        return dclTatol;
    }

    /// <summary>
    /// 市局下达数
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal PUCMonData(string str)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dclBudTatol = 0;
        DataTable dt = FA_PUCIssNumManager.GetPUCIssNumByYearName(str, year);
        if (dt != null && dt.Rows.Count > 0)
        {
            dclBudTatol = ToDec(dt.Rows[0]["PUCMon"]);
        }
        return dclBudTatol;
    }


    private void AddDataRow(DataTable dt, string name1, string name2)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (PUCMonData(name2) != 0)
        {
            dr["column2"] = (PUCMonData(name2)).ToString("f2");
        }
        if (ThisMonData(name2) != 0)
        {
            dr["column3"] = (ThisMonData(name2)).ToString("f2");
        }
        if (TatolMonData(name2) != 0)
        {
            dr["column4"] = (TatolMonData(name2)).ToString("f2");
        }
        if (PUCMonData(name2) != 0 && TatolMonData(name2)!=0)
        {
            dr["column5"] = ((TatolMonData(name2) / PUCMonData(name2)) * 100).ToString("f2") + "%";
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

        GetRows(dt);
        
        RepLeaderQuery.DataSource = dt;
        RepLeaderQuery.DataBind();
    }

    private void GetRows(DataTable dt)
    {
        AddDataRow(dt, "一、公务接待费", "公务接待费");
        AddDataRow(dt, "二、因公出国（境）费用", "因公出国（境）费用");
        AddDataRow(dt, "三、公务用车运行维护费", "公务用车运行维护费");

        DataRow dr = dt.NewRow();
        dr["column1"] = "总  计";
        if (PUCMonData("公务接待费") + PUCMonData("因公出国（境）费用") + PUCMonData("公务用车运行维护费") != 0)
        {
            dr["column2"] = (PUCMonData("公务接待费") + PUCMonData("因公出国（境）费用") + PUCMonData("公务用车运行维护费")).ToString("f2");
        }
        if (ThisMonData("公务接待费") + ThisMonData("因公出国（境）费用") + ThisMonData("公务用车运行维护费") != 0)
        {
            dr["column3"] = (ThisMonData("公务接待费") + ThisMonData("因公出国（境）费用") + ThisMonData("公务用车运行维护费")).ToString("f2");
        }
        if (TatolMonData("公务接待费") + TatolMonData("因公出国（境）费用") + TatolMonData("公务用车运行维护费") != 0)
        {
            dr["column4"] = (TatolMonData("公务接待费") + TatolMonData("因公出国（境）费用") + TatolMonData("公务用车运行维护费")).ToString("f2");
        }
        if (ToDec(dr["column4"]) != 0 && ToDec(dr["column2"]) != 0)
        {
            dr["column5"] = ((ToDec(dr["column4"]) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        dt.Rows.Add(dr);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HidSearchFlag.Value = "0";
        FunExpendBind();
        HidSearchFlag.Value = "1";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbDate.Text + ")三公经费支出情况表.xls";
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        GetRows(dt);
        TableCell[] header = new TableCell[7];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "三公经费支出情况表";
        header[0].ColumnSpan = 4;
        header[1].Text = "单位:元</th></tr><tr>";
        header[1].ColumnSpan = 1;
        header[2].Text = "项目分类";
        header[3].Text = "市局下达数";
        header[4].Text = "本月实际支出";
        header[5].Text = "累计实际支出";
        header[6].Text = "占下达数比例</th>";

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            mergeCellNums.Add(i, 0);
        }        
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
        
    }
}