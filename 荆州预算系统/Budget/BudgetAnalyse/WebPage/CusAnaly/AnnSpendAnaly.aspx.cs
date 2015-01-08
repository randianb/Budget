using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;

public partial class WebPage_CusAnaly_AnnSpendAnaly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lashow.Style.Add("Color", "red");
    }



    private void repBind(int year)
    {
        DataTable dt = BG_OutlayAnaLogic.GetAnalyseOutDataByYear(year);
        dt.Columns.Add("TQoackmon");
        dt.Columns.Add("oabmRatio");
        dt.Columns.Add("oaamRatio");
        DataTable dtAfter = BG_OutlayAnaLogic.GetAnalyseOutDataByYear(year - 1);        
        lashow.Text = "";
        if (dt.Rows.Count < 1 )
        {
            lashow.Text = "没查询到数据，请先添加后再查询。";
        }
        else if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal oackmon = ToDec(dt.Rows[i]["OACkMon"].ToString());
                decimal oabudmon = ToDec(dt.Rows[i]["OABudMon"].ToString());
                decimal oaaudmon = ToDec(dt.Rows[i]["OAAudMon"].ToString());
                dt.Rows[i]["oabmRatio"] = DealVal(oackmon, oabudmon);
                dt.Rows[i]["oaamRatio"] = DealVal(oackmon, oaaudmon);
                for (int j = 0; j < dtAfter.Rows.Count; j++)
                {
                    if (dt.Rows[i]["PIEcoSubCoding"].ToString() == dtAfter.Rows[j]["PIEcoSubCoding"].ToString())
                    {
                        dt.Rows[i]["TQoackmon"] = dtAfter.Rows[j]["OACkMon"];
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

    protected void btnSearch_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        int year = Convert.ToInt32(cmbYear.SelectedItem.Value);
        repBind(year);
    }
}