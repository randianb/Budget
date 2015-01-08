using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using  Ext.Net;

public partial class WebPage_BudgetControl_HisAllocation : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Store1Bind();
    }

    private void Store1Bind()
    {
        DataTable dtTable = BG_ChangePwdManager.GetAllBG_ChangePwd();
        Store1.DataSource = dtTable;
        Store1.DataBind();
    } 
}