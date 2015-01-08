using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;

public partial class WebPage_SysSetting_DepartManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repDepartBind(0);
        }
    }

    private void repDepartBind(int pageIndex)
    {
        int RecordCount = 0;
        int PageSize = pagerDepart.PageSize;
        DataTable dt = FA_DepartmentManager.GetDepartPager(PageSize, pageIndex, out RecordCount);
        pagerDepart.RecordCount = RecordCount;
        pagerDepart.CurrentPageIndex = pageIndex + 1;
        repDepart.DataSource = dt;
        repDepart.DataBind();
    }



    protected void repDepart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int depid = common.IntSafeConvert(e.CommandArgument);
        if (e.CommandName == "UpdDep")
        {
            Response.Redirect("DepartUpd.aspx?depid=" + depid,true);
        }
        if (e.CommandName == "DelDep")
        {
            if (FA_DepartmentManager.DeleteFA_DepartmentByID(depid))
            {
                repDepartBind(0);
            }
        }
    }
    protected void pagerDepart_PageChanged(object sender, EventArgs e)
    {
        int pageIndex = pagerDepart.CurrentPageIndex - 1;
        repDepartBind(pageIndex);
    }
    protected void btnAddDepart_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepartAdd.aspx", true);
    }
}