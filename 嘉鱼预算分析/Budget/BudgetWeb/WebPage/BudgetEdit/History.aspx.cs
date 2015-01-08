using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using Ext.Net;

public partial class WebPage_BudgetEdit_History : BudgetBasePage
{
    int depId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            depId = common.IntSafeConvert(DepID);
            ddlDepBind(depId);
            bind();
        }
    }



    //绑定部门
    private void ddlDepBind(int depid)
    {
        DataTable depTable = null;
        if (DepID == AreaDepID || UserLimStr == "审核员")//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            depTable = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        }
        else
        {
            depTable = BGDepartmentManager.GetDepByDepid(depid);
        }
        for (int i = 0; i < depTable.Rows.Count; i++)
        {
            cbDepment.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
        }

        if (DepID == AreaDepID || UserLimStr == "审核员")//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            cbDepment.Items.Insert(0, new Ext.Net.ListItem("全局", "0"));
            //cbDepment.SelectedItem.Index = 0;
        }
    }

    /// <summary>
    /// 绑定
    /// </summary>
    private void bind()
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        DataTable dt = BGBudItemsManager.GetApplyReimburByDepID(depId);
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "该部门数据为空！");
        }
        else
        {
            stBudget.DataSource = dt;
            stBudget.DataBind();
        }
    }

    //查询
    protected void btnInquiry_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        bind();
    }

    //修改
    [DirectMethod]
    public void Look_Handler(int budId)
    {
        Response.Redirect("HistoricalTra.aspx?budid=" + budId, true);
    }
}