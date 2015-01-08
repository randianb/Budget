using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

public partial class Top : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            lbDep.Text = DepName;
            if (UserName.Length > 4)
            {
                lbUser.Text = UserName.Substring(0, 4);
            }
            else
            {
                lbUser.Text = UserName;
            }
        }
    }

    protected void lkbtn_DirectClick(object sender, DirectEventArgs e)
    {
        //

        
    }

    protected void lkBtn_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ScriptManager.RegisterStartupScript(this, GetType(), "lgout", "window.top.location.href='login.aspx'", true);

    }
    //protected void CloseAllPages_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("WebPage\\Policy\\PLNavigate.aspx", true);
    //}
    //protected void ClosePage_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("WebPage\\Policy\\PLNavigate.aspx", true);
    //}
}