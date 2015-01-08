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

public partial class BudgetPage_mainPages_MonPayPlan : BudgetBasePage
{
    int depid = 1106;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        }
    }
    private void MonthDataBind()
    {
        //DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        //DataTable dt1 = new DataTable();
        //dt1.Columns.Add("Year");
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    dt1.Rows.Add("");
        //    dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        //}
        //cmbyearstore.DataSource = dt1;
        //cmbyearstore.DataBind();
    }

    private void DepDataBind()
    {
        //DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        //cmbdeptstore.DataSource = dt;
        //cmbdeptstore.DataBind();

    }
    private void AuditStoreBind()
    {
        //int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        //int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        //DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        //AuditStore.DataSource = dt;
        //AuditStore.DataBind();
        //if (dt.Rows.Count <= 0)
        //{
        //    X.Msg.Alert("提示", "没有查询到数据").Show();
        //}
    }
    protected void submit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        //AuditStoreBind();
    }
    protected void btnSel_Click(object sender, EventArgs e)
    {
        //int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        //int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        //DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        //if (dt.Rows.Count <= 0)
        //{
        //    X.Msg.Alert("提示", "没有可选数据").Show();
        //}
        //else
        //{
        //    BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
        //    mppr.MASta = "审核不通过";
        //    mppr.MACause = txtReason.Text;
        //    BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        //int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        //DataTable dt = BG_ChaSecAuditLogic.GetChaSecAudit(depid, year, month);
        //if (dt.Rows.Count <= 0)
        //{
        //    X.Msg.Alert("提示", "没有可选数据").Show();
        //}
        //else
        //{
        //    BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
        //    mppr.MASta = "审核通过";
        //    BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
        //}

    }

}