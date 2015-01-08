using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using BudgetWeb.Model;
using Common;
using Ext.Net;

public partial class BudgetPage_mainPages_ChaSecAudit : BudgetBasePage
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
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
            cmbdept.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
        }

    }
    private void AuditStoreBind()
    {
        int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        AuditStore.DataSource = Getnew(dt);
        AuditStore.DataBind();
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    }
    private DataTable Getnew(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["MASta"] = "未审核";
        }
        return dt;
    }
    protected void submit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        AuditStoreBind();
    }
    protected void btnSel_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有可选数据").Show();
           
        }
        else
        {
            BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
            mppr.MASta = "审核不通过";
            mppr.MACause = txtReason.Text;
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr); 
        }
        DepDataBind();
        MonthDataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value);
        int month = common.IntSafeConvert(cmbmonth.SelectedItem.Value);
        if (year <= 0 || month <= 0)
        {
            X.Msg.Alert("提示", "请先选择年度").Show();
            return;
        }
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有可选数据").Show(); 
        }
        else
        {

            BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
            mppr.MASta = "审核通过";
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);

        }
        DepDataBind();
        MonthDataBind(); 
    }

}
//private void repBudConSuDataBind(int maMonth)
//{
//    DataTable dt = VMonPayPlanIncomeManager.GetvMonPayPlanIncomeTBySta(maMonth);
//    //if (dt.Rows.Count > 0)
//    //{
//    repBudConAudit.DataSource = dt;
//    repBudConAudit.DataBind();
//    //}
//}

//protected void btnSel_Click1(object sender, EventArgs e)
//{

//}
//protected void btnSearch_Click(object sender, EventArgs e)
//{
//    repBudConSuDataBind(common.IntSafeConvert(ddlMon.SelectedValue));
//}

//protected void btnApp_Click(object sender, EventArgs e)
//{
//    if (BGMonPayPlanRemarkManager.UpdApplicationStatus("审核通过",common .IntSafeConvert (ddlMon .SelectedValue )))
//    {


//        repBudConSuDataBind(1);
//        repBudConAudit.DataBind();


// }
//    else
//    {

//    }
//}
//protected void btnNoApp_Click(object sender, EventArgs e)
//{
//    string reason = txtReason.Text.Trim();
//    int month = common.IntSafeConvert(ddlMon.SelectedValue);
//    bool falg = BGMonPayPlanRemarkManager.UpdApplicationStatus("退回", month);
//    repBudConSuDataBind(common.IntSafeConvert(ddlMon.SelectedValue));
//}