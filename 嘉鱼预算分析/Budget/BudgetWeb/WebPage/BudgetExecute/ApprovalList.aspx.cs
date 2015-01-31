using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using System.Configuration;
using Common;

public partial class WebPage_BudgetExecute_ApprovalList : System.Web.UI.Page
{
    protected string arid = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        arid = Request["arid"];
        if (!IsPostBack)
        {
            txtARReiSinNum.Text = ConfigurationManager.AppSettings["AreaCode"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000);
            ARExpSubDataBind();
            ApplyAlterDataBind();
           
        }
    }

    private void ARExpSubDataBind()
    {
       DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
       ddlARExpSub.DataTextField = "PIEcoSubName";
       ddlARExpSub.DataValueField = "PIEcoSubName";
       ddlARExpSub.DataSource = dt;
       ddlARExpSub.DataBind();  
    } 

    private void ApplyAlterDataBind()
    {
        DataTable dt = BGApplyReimburManager.GetApplyReimbur(arid); //BGPayIncomeManager.GetPayIncomeListByPIID(arid)

        if (dt.Rows.Count > 0)
        {


            //string PiName = dt.Rows[0]["PIEcoSubName"].ToString();
            //txtPro.Text = PiName;
            //ddlDepart.Text = dt.Rows[0]["DepID"].ToString();
            //txtARReiSinNum.Text = dt.Rows[0]["ARReiSinNum"].ToString();
            //ddlARExpType.Text = dt.Rows[0]["ARExpType"].ToString();
            //ddlARExpPro.SelectedItem.Value = dt.Rows[0]["ARExpPro"].ToString();
            txtBITime.Text = dt.Rows[0]["ARTime"].ToString();
            ddlARExpSub.SelectedValue =
                BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[0]["PPID"].ToString()))
                    .PIEcoSubName;
            txtARRepDep.Text = dt.Rows[0]["ARRepDep"].ToString();
            txtARAgent.Text = dt.Rows[0]["ARAgent"].ToString();
            txtARMon.Text = dt.Rows[0]["ARMon"].ToString();
            txtARExcu.Text = dt.Rows[0]["ARExcu"].ToString();
            lbDepName.Text = BG_DepartmentManager.GetBG_DepartmentByDepID(Convert.ToInt32(dt.Rows[0]["DepID"].ToString())).DepName;

            DataTable dt1 = BGReimDocumentsManager.GetReimDocuments(arid);
            string RDType = string.Empty;
            if (dt1.Rows.Count > 0)
            {
                RDType = dt1.Rows[0]["RDType"].ToString();
                lbRDType.Text = RDType;
            }

            //if (RDType == "")
            //{
            //    Response.Redirect("SearchTravelCost.aspx?arid=" + arid, true);
            //}
            //else if (RDType == "")
            //{
            //    Response.Redirect("SearchMediCost.aspx?arid=" + arid, true);
            //}
            //else if (RDType == "")
            //{
            //    Response.Redirect("SearchOtherCost.aspx?arid=" + arid, true);
            //}
        }
    }

    protected void btnAlt_Click(object sender, EventArgs e)
    {
        int Arid = Convert.ToInt32(arid);
        DataTable dt1 = BGReimAppendixManager.GetAccessories(arid);
        string ARType = string.Empty;
        if (dt1.Rows.Count > 0)
        {
            ARType = dt1.Rows[0]["ARType"].ToString();
            lbRDType.Text = ARType.ToString();
        }
        if (lbRDType.Text == "差旅")
        {
            Response.Redirect("ApplyTravelCost.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "医疗")
        {
            Response.Redirect("ApplyMediCost.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "办公室用品")
        {
            Response.Redirect("OfficeSupplies.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "培训")
        {
            Response.Redirect("Train.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "工作会议")
        {
            Response.Redirect("ConferenceFees.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "资料印制")
        {
            Response.Redirect("InformationPrinted.aspx?arid=" + arid + "&oper=4", true);
        }
        else if (lbRDType.Text == "其它费用")
        {
            Response.Redirect("Expense.aspx?arid=" + arid + "&oper=4", true);
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        txtReason.Enabled = true;
        //string idStrs = null;
        //if()
        if (BGApplyReimburManager.UpdApplication("退回", txtReason.Text, arid))
        {
            Response.Redirect("ReimApproval.aspx", true);
        }
        else
        {

        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReimApproval.aspx", true);
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        int Subcoding = 0;

        string artype = "";
        if (rdBase.Checked == true)
        {
            artype = "基本支出";
        }
        else
        {
            artype = "项目支出";
        }
        if (ddlType.SelectedItem.Value == "财政拨款")
        {
            if (artype == "基本支出")
            {
                Subcoding = 50010101;
            }
            else
            {
                Subcoding = 50010102;
            }
        }
        else if (ddlType.SelectedItem.Value == "其他资金")
        {
            if (artype == "基本支出")
            {
                Subcoding = 50010201;
            }
            else
            {
                Subcoding = 50010202;
            }
        }
        string ARExpSub = ddlARExpSub.SelectedItem.Text.ToString();
        int PIID = BG_PayIncomeLogic.GetPIIDbycoding(Subcoding, ARExpSub);

        if (BGApplyReimburManager.UpdApplicationStatus1(PIID, "审核通过", artype, arid))
        {
            Response.Redirect("ReimApproval.aspx", true);
        }
        else
        {

        }
    }
}