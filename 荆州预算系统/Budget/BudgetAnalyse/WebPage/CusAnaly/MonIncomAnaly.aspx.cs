using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;

//月度收入分析
public partial class WebPage_CusAnaly_MonIncomAnaly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lashow.Style.Add("Color", "red");
    }

    private void repBind(int year, int month)
    {
        DataTable dt = BG_IncomeAnaLogic.GetAnalyIncCkDataMonth(year, month);
        dt.Columns.Add("TQiackmon");
        dt.Columns.Add("TQiRatio");
        DataTable dtAfter = BG_IncomeAnaLogic.GetAnalyIncCkDataMonth(year - 1, month);
        lashow.Text = "";
        if (dt.Rows.Count < 1)
        {
            lashow.Text = "没查询到数据，请先添加后再查询。";
        }
        else if (dt.Rows.Count > 0 && dtAfter.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal iackmon = ToDec(dt.Rows[i]["IACkMon"].ToString());
                for (int j = 0; j < dtAfter.Rows.Count; j++)
                {
                    if (dt.Rows[i]["EICoding"].ToString() == dtAfter.Rows[j]["EICoding"].ToString())
                    {
                        dt.Rows[i]["TQiackmon"] = dtAfter.Rows[j]["IACkMon"];
                        decimal iackmonAfter = ToDec(dtAfter.Rows[j]["IACkMon"].ToString());
                        dt.Rows[i]["TQiRatio"] = DealVal(iackmon, iackmonAfter);
                    }
                }

            } 
        }
        Store1.DataSource = dt;
        Store1.DataBind();
    }
    private decimal ToDec(string str)
    {
        decimal tmp = 0;
        if (!string.IsNullOrEmpty(str))
        {
            tmp = decimal.Parse(str);
        }
        return tmp;
    }
    private string DealVal(decimal d1, decimal d2)
    {
        string reStr = string.Empty;
        if ((int)d1 == 0 || (int)d2 == 0)
        {
            reStr = "--";
        }
        else
        {
            reStr = Decimal.Round((d1 / d2) * 100, 2).ToString() + "%";
        }
        return reStr;
    }


    protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
    {
        int year = Convert.ToInt32(cmbYear.SelectedItem.Value);
        int month = Convert.ToInt32(cmbMonth.SelectedItem.Value);
        repBind(year, month);
    }
}