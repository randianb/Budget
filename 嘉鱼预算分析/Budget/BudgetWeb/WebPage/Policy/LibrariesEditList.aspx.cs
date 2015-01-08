using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;

public partial class WebPage_Policy_LibrariesEditList : System.Web.UI.Page
{
    //int depId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void Bind()
    {
        DataTable dt = BGBudItemsLibrariesManager.GetAllBG_BudItemsLibrariesDept();
        stBudget.DataSource = dt;
        stBudget.DataBind();
    }


    //添加
    protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        Response.Redirect("ItemsLibraries.aspx", true);
    }

    //修改88888888888888888888888888888
    [DirectMethod]
    public void Modify_Handler(int budId)
    {
        Response.Redirect("ItemsLibraries.aspx?budid=" + budId, true);
    }


    //删除
    [DirectMethod]
    public void Delete_Handler(int budId)
    {
        if (BG_BudItemsLibrariesManager.DeleteBG_BudItemsLibrariesByID(budId))
        {
            Bind();
        }
    }

}