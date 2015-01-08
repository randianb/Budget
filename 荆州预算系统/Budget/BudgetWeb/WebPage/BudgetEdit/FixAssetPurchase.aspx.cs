using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;

public partial class BudgetPage_mainPages_FixAssetPurchase : System.Web.UI.Page
{
    int budid;
    int depid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null && Request.QueryString["depid"] != null)
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
        else
        {
            Response.Redirect("BudgetEditList.aspx", true);
        }
        if (!IsPostBack)
        {
            RepFixBind(budid);
        }
    }

    public void RepFixBind(int budid)
    {
        DataTable dt = BGFixAssetPurchaseManager.GetFix(budid);

            repFix.DataSource = dt;
            repFix.DataBind();
     
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("BGFixAssetPurchaseAdd.aspx?budid=" + budid + "&depid=" + depid, true);
    }
    protected void repFix_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int faid = common.IntSafeConvert(e.CommandArgument);
        if (e.CommandName == "DelFix")
        {
            if (BGFixAssetPurchaseManager.DelFix(faid))
            {
                RepFixBind(budid);
            }
        }
        if (e.CommandName == "UpdFix")
        {
            string postUrl = "FixAssetPurchaseUpd.aspx?faid=" + faid + "&depid=" + depid;
            Response.Redirect(postUrl, true);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetEditList.aspx?depid="+depid, true);
    }
}