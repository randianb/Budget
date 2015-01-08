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
using ListItem = Ext.Net.ListItem;

public partial class WebPage_BudgetEdit_History : BudgetBasePage
{
    int depId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            depId = common.IntSafeConvert(DepID);
            ddlDepBind(depId);
            if (UserLimStr != "审核员")
                //if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
            {
                cbDepment.SelectedItem.Value = DepID.ToString();
            }
           
            int yeartmp = DateTime.Now.Year;
            bind(yeartmp);
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
    private void bind(int yeartmp)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        int year=  DateTime.Now.Year;
        if (yeartmp==0)
        {
            yeartmp = year;
        }
        DataTable dt = BGBudItemsManager.GetApplyReimburByDepID(depId, yeartmp);
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
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value);
        bind(year);
    }

    //修改
    [DirectMethod]
    public void Look_Handler(int budId)
    {
        Response.Redirect("HistoricalTra.aspx?budid=" + budId, true);
    }

    protected void YearBind(object sender, EventArgs e)
    {
        int year = common.IntSafeConvert(CurrentYear);
        string str = "";
        for (int i = year; i >2000; i--)
        {
            str = i.ToString();
            cmbyear.Items.Add(new ListItem(str, str));
        }
    }
}