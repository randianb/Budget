using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using System.Data;
using Common;
using System.Configuration;
public partial class BudgetPage_mainPages_ApplyQuery : BudgetBasePage
{
    protected string arid = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        arid = Request["arid"];

        if (!IsPostBack)
        {
            txtARReiSinNum.Text = ConfigurationManager.AppSettings["AreaCode"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000); ;
            txtARReiSinNum.ReadOnly = true;
            ARExpSubDataBind();
            ApplyDataBind();
            //ddlARExpPro.Enabled = false; 
        } 
    }

 
    private void ApplyDataBind()
    {
        DataTable dt = BGApplyReimburManager.GetApplyReimbur(arid); //BGPayIncomeManager.GetPayIncomeListByPIID(arid)

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["ARListSta"].ToString() == "退回")
            {
                txtBITime.Text = dt.Rows[0]["ARTime"].ToString();
                txtARRepDep.Text = dt.Rows[0]["ARRepDep"].ToString();
                txtARAgent.Text = dt.Rows[0]["ARAgent"].ToString();
                txtARMon.Text = dt.Rows[0]["ARMon"].ToString();
                txtARExcu.Text = dt.Rows[0]["ARExcu"].ToString(); 
                string name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[0]["PPID"].ToString())).PIEcoSubName;
                ddlARExpSub.SelectedItem.Text = name;
                ddlARExpSub.Enabled = false;
                txtBITime.Enabled = false;
                txtBITime.ReadOnly = true;
                txtARRepDep.ReadOnly = true;
                txtARAgent.ReadOnly = true;
                txtARMon.ReadOnly = true;
                txtARExcu.ReadOnly = true;


                DataTable dt1 = BGReimDocumentsManager.GetReimDocuments(arid);
                string RDType = string.Empty;
                if (dt1.Rows.Count > 0)
                {
                    RDType = dt1.Rows[0]["RDType"].ToString();
                    lbRDType.Text = RDType;
                }
            }
            else
            {
                //string PiName = dt.Rows[0]["PIEcoSubName"].ToString();
                //txtPro.Text = PiName;
                //ddlDepart.Text = dt.Rows[0]["DepID"].ToString();
                //txtARReiSinNum.Text = dt.Rows[0]["ARReiSinNum"].ToString();
                //ddlARExpType.Text = dt.Rows[0]["ARExpType"].ToString();
                //ddlARExpPro.SelectedItem.Value = dt.Rows[0]["ARExpPro"].ToString();
                txtBITime.Text = dt.Rows[0]["ARTime"].ToString();
                txtARRepDep.Text = dt.Rows[0]["ARRepDep"].ToString();
                txtARAgent.Text = dt.Rows[0]["ARAgent"].ToString();
                txtARMon.Text = dt.Rows[0]["ARMon"].ToString();
                txtARExcu.Text = dt.Rows[0]["ARExcu"].ToString();
                string name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[0]["PPID"].ToString())).PIEcoSubName;
                ddlARExpSub.SelectedItem.Text = name;
                ddlARExpSub.Enabled = false;
                txtBITime.Enabled = false;
                txtBITime.ReadOnly = true;
                txtARRepDep.ReadOnly = true;
                txtARAgent.ReadOnly = true;
                txtARMon.ReadOnly = true;
                txtARExcu.ReadOnly = true;


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
    }

    private void ARExpSubDataBind()
    {
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        ddlARExpSub.DataTextField = "PIEcoSubName";
        ddlARExpSub.DataValueField = "PIEcoSubName";
        ddlARExpSub.DataSource = dt;
        ddlARExpSub.DataBind();

    } 

    //protected void ddlARExpType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //if (ddlARExpType.Text.ToString() == "基本支出")
    //    //{
    //    //    ARExpSubDataBind();
    //    //    ddlARExpPro.Enabled = false;
    //    //}
    //    //if (ddlARExpType.Text.ToString() == "项目支出")
    //    //{
    //    //    ARExpProDataBind();
    //    //    cbPayIncomeBind();
    //    //    ddlARExpPro.Enabled = true;
    //    //}
    //}

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryApplystateList.aspx", true);
    }



    //protected void btnAlter_Click(object sender, EventArgs e)
    //{
    //    BG_ApplyReimbur bt = new BG_ApplyReimbur();
    //    bt.ARID = Utils.IntSafeConvert(arid);
    //    bt.ARAgent = txtARAgent.Text.Trim();                            //经办人
    //    bt.ARExcu = txtARExcu.Text.Trim();                              //事由
    //    //bt.PPID = Utils.IntSafeConvert(ddlARExpPro.SelectedItem.Value); //支出项目ID
    //    //bt.ARExpType = ddlARExpType.SelectedValue;                      //支出类型
    //    bt.ARListSta = "未提交";                                         //申请表状态
    //    bt.ARMon = decimal.Parse(txtARMon.Text.Trim());                  //金额
    //    bt.ARReiSinNum = txtARReiSinNum.Text.Trim();          //报销单号
    //    bt.ARRepDep = txtARRepDep.Text.Trim();                           //上报部门
    //    bt.ARTime = DateTime.Parse(txtBITime.Text.Trim());                                        //申请时间
    //    bt.DepID =DepID;        //部门

    //    BGApplyReimburManager.UpdApplyReimbur(bt);
    //    Response.Redirect("ApplyList.aspx", true);

    //}
    protected void btnQue_Click(object sender, EventArgs e)
    {
        int Arid = Convert.ToInt32(arid);
        DataTable dt1 = BGReimAppendixManager.GetAccessories(arid);
        string ARType = string.Empty;
        if (dt1.Rows.Count <= 0)
        {
            Label1.Text = "该申请单没有添加附件，无法执行操作"; 
        }
        else 
        {
            ARType = dt1.Rows[0]["ARType"].ToString();
            lbRDType.Text = ARType.ToString();

            if (lbRDType.Text == "公差旅")
            {
                Response.Redirect("BusinessTrip.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "医疗")
            {
                Response.Redirect("ApplyMediCost.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "办公室用品")
            {
                Response.Redirect("OfficeSupplies.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "培训")
            {
                Response.Redirect("Train.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "工作会议")
            {
                Response.Redirect("ConferenceFees.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "资料印制")
            {
                Response.Redirect("GuildActivity.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "公会活动")
            {
                Response.Redirect("InformationPrinted.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "长途出车记录")
            {
                Response.Redirect("CarRecordSheet.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "维修")
            {
                Response.Redirect("Maintenance.aspx?arid=" + arid + "&oper=3", true);
            }
            else if (lbRDType.Text == "其它费用")
            {
                Response.Redirect("Expense.aspx?arid=" + arid + "&oper=3", true);
            }
        } 
       
    }

}