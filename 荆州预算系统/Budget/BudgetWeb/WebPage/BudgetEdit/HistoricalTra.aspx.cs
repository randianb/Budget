using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BudgetWeb.BLL;
using Common;

public partial class BudgetPage_mainPages_HistoricalTra : System.Web.UI.Page
{
    int budid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null)
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            hidBudID.Value = budid.ToString();
        }
        else
        {
            Response.Redirect("History.aspx",true);
        }
        if (!IsPostBack)
        {
            repTraBind(budid,0);
        }
    }

    private void repTraBind(int budid,int pageIndex)
    {
        int RecordCount = 0;
        int PageSize = TraPager.PageSize;
        DataTable dt = BGBudItemHisManage.GetDtBIHisByBudid(budid, PageSize, pageIndex, out RecordCount);
        TraPager.RecordCount = RecordCount;
        TraPager.CurrentPageIndex = pageIndex + 1;
        repTra.DataSource = dt;
        repTra.DataBind();
    }

    protected void repTra_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string BudHisID = e.CommandArgument.ToString();
        if (e.CommandName == "Look")
        {
            Response.Redirect("HislTraDetails.aspx?BudHisID=" + BudHisID, true);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("History.aspx", true);
    }
    protected void TraPager_PageChanged(object sender, EventArgs e)
    {
        int pageIndex = TraPager.CurrentPageIndex - 1;

        repTraBind(common.IntSafeConvert(hidBudID.Value), pageIndex);
    }
}