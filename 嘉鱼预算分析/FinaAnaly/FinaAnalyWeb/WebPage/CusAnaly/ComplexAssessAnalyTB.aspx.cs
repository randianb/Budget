using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_CusAnaly_ComplexAssessAnalyTB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPubFundExpendEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("PubFundExpendEvaForm.aspx", true);
    }
    protected void btnBalanceEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("BalanceEvaForm.aspx", true);
    }
    protected void btnFundIncEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundIncEvaForm.aspx", true);
    }

    private decimal GetCurTotal(string str)
    {
        decimal dcCurTotal = 0;

        return dcCurTotal;
    }


    private void AddDataRow(DataTable dt, string name)
    {
        DataRow dr = dt.NewRow();
        dr["column2"] = name;
        dr["column3"] = name;
        dr["column4"] = name;
        dr["column5"] = name;
        dr["column6"] = name;
        dr["column7"] = name;
        dr["column8"] = name;
        dr["column9"] = name;
        dr["column10"] = name;
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

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}