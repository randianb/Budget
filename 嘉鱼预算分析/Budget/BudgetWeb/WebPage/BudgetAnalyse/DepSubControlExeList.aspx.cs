using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;

public partial class mainPages_DepSubControlExeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void repBudConDataBind(string depname)
    {
        DataTable dt = VApplyPayDepartManager.SelVApplyPayDepartByDepName(depname);
        repDepSubConExeList.DataSource = dt;
        repDepSubConExeList.DataBind();
    }
    protected void btnSel_Click(object sender, EventArgs e)
    {
        repBudConDataBind(DropDownList1 .SelectedValue );
    }
}
