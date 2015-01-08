using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_DepartUpd : System.Web.UI.Page
{
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["depid"] != null)
        {
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
        else
        {
            Response.Redirect("DepartManage.aspx", true);
        }
        if (!IsPostBack)
        {
            txtBind(depid);
        }
    }

    private void txtBind(int depid)
    {
        FA_Department dep = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
        txtDepName.Text = dep.DepName;
        txtDepRemark.Text = dep.DepRem;
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        FA_Department dep = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
        dep.DepName = txtDepName.Text.Trim();
        dep.DepRem = txtDepRemark.Text.Trim();
        if (FA_DepartmentManager.ModifyFA_Department(dep))
        {
            lblShowResult.Text = "* 修改成功";
        }
        else
        {
            lblShowResult.Text = "* 操作失败，请重试";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblShowResult.Text = string.Empty;
        txtDepName.Text = string.Empty;
        txtDepRemark.Text = string.Empty;
    }
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepartManage.aspx", true);
    }
}