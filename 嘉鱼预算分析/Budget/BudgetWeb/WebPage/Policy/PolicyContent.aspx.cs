using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using BudgetWeb.Model;

public partial class WebPage_Policy_PolicyContent : System.Web.UI.Page
{
    private string plid = string.Empty;
    protected string str = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["plid"] != null)
            {
                plid = Request["plid"];
                int PLID = Convert.ToInt32(plid);
                BG_Policy bg_policy = BG_PolicyManager.GetBG_PolicyByPLID(PLID);
                str = bg_policy.PContent;
            }
        }
    }
}