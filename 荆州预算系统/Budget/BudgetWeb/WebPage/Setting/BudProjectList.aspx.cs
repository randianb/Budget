using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;

public partial class WebPage_Setting_BudProjectList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BudgetConDataBind();
        }
    }

    private void BudgetConDataBind()
    {
        DataTable dt = BGBudgetConManager.GetAllBudgetCon();
        repBudPro.DataSource = dt;
        repBudPro.DataBind();
    }


    protected void repBudPro_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string piid = e.CommandArgument.ToString();

        if (e.CommandName == "AltPro")
        {
            //修改
            Response.Redirect("BudProjectAlter.aspx?piid=" + piid, true);
        }
        else if (e.CommandName == "DelPro")
        {
            //删除
            BGBudgetConManager.DelAppPIIDConCell(piid);
            BGBudgetConCellManager.DelAppPIIDConCell(piid);
            BudgetConDataBind();
        }

    } 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudProjectAdd.aspx", true);
    }
}