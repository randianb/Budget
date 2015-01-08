using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BudgetPage_mainPages_AlterMonPayPlan : System.Web.UI.Page
{
    protected string caid = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        caid = Request["caid"];
        if (!IsPostBack)
        {
 
        }
    }
    protected void btnAlter_Click(object sender, EventArgs e)
    {
       //_AlterMonPayPlan bt=new AlterMonPayPlan;
        Response.Redirect("SelMonPayPlan.aspx", true);
    }
}