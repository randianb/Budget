using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;

public partial class WebPage_CusAnaly_AnnIncomAnaly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lashow.Style.Add("Color", "red");
    }

    private void repBind(int year)
    { 
        DataTable dt = BG_IncomeAnaLogic.GetAnalyseIncDataYearByYear(year);
        dt.Columns.Add("TQiackmon");
        dt.Columns.Add("iabmRatio");
        dt.Columns.Add("iaamRatio");
        DataTable dtAfter = BG_IncomeAnaLogic.GetAnalyseIncDataYearByYear(year - 1);
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
                decimal iabudmon = ToDec(dt.Rows[i]["IABudMon"].ToString());
                decimal iaaudmon = ToDec(dt.Rows[i]["IAAudMon"].ToString()); 
                dt.Rows[i]["iabmRatio"] = DealVal(iackmon, iabudmon);
                dt.Rows[i]["iaamRatio"] = DealVal(iackmon, iaaudmon);
                for (int j = 0; j < dtAfter.Rows.Count; j++)
                {
                    if (dt.Rows[i]["EICoding"].ToString() == dtAfter.Rows[j]["EICoding"].ToString())
                    {
                        dt.Rows[i]["TQiackmon"] = dtAfter.Rows[j]["IACkMon"];
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
        repBind(year);
    }
}