using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using Ext.Net;
using DataView = System.Data.DataView;

public partial class BudgetPage_mainPages_SelMonPayPlan : BudgetBasePage
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            DepDataBind();
            MonthDataBind(); 
        }
    }
    private void MonthDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Year");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add("");
            dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        }
        cmbyearstore.DataSource = dt1;
        cmbyearstore.DataBind(); 
    }

    private void DepDataBind()
    {
        DataTable dt = new DataTable(); //BGDepartmentManager.GetDepByfadepid(depid);
        if (DepID == AreaDepID)
        {
            dt = BGDepartmentManager.GetDepByfadepid(DepID);
        }
        else
        {
            dt = BGDepartmentManager.GetDepByDepid(DepID);
        }
        cmbdeptstore.DataSource = dt;
        cmbdeptstore.DataBind();
        cmbdept.SelectedItem.Index = 0;
    }
    private void AuditStoreBind()
    {
        int year= Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month=Convert.ToInt32(cmbmonth.SelectedItem.Value);
        DataTable dt = BG_SelMonPayPlanLogic.GetMonPayPlan(DepID, year, month);
        DataView dvView = dt.DefaultView;
        dvView.RowFilter = "MPFunding >0";
        dt = dvView.ToTable(true);
        AuditStore.DataSource = dt;
        AuditStore.DataBind();
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    } 

    protected void submit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    { 
        AuditStoreBind();
    }
}

////protected void btnSearch_Click(object sender, EventArgs e)
//{

//    repBudConDataBind(common.IntSafeConvert(ddlMon.SelectedValue));
//}

//private void repBudConDataBind(int mAMonth)
//{
//    DataTable dt = VMonPayPlanIncomeManager.GetvMonPayPlanIncomeByMAMonth(mAMonth);
//    //if (dt.Rows.Count > 0)
//    //{
//        repBudCon.DataSource = dt;
//        repBudCon.DataBind();
//    //}
//}



//protected void repBudCon_ItemCommand(object source, RepeaterCommandEventArgs e)
//{
//    string caid = e.CommandArgument.ToString();
//    if (e.CommandName == "UpdBI")
//    {
//        Response.Redirect("AlterMonPayPlan.aspx?caid=" + caid, true);
//    }

//}