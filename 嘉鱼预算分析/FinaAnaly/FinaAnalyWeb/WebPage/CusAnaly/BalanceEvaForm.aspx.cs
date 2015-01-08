using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_CusAnaly_BalanceEvaForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnComplexAssessAnalyTB_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComplexAssessAnalyTB.aspx", true);
    }
    protected void btnPubFundExpendEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("PubFundExpendEvaForm.aspx", true);
    }
    protected void btnFundIncEvaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundIncEvaForm.aspx", true);
    }
}