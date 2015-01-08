using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_DepartAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        FA_Department dep = new FA_Department();
        dep.DepName = txtDepName.Text.Trim();
        dep.DepRem = txtDepRemark.Text.Trim();
        if (FA_DepartmentManager.AddFA_Department(dep).DepID > 0)
        {
            lblShowResult.Text = "添加成功";
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