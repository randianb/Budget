using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.Model;
using BudgetWeb.BLL;
using System.Data;
using Common;
using System.Configuration;

public partial class BudgetPage_mainPages_ApplyAddOld : BudgetBasePage
{
    protected string arid = string.Empty;
    int depid = 1138;
    protected void Page_Load(object sender, EventArgs e)
    {
        depid = DepID;
        //arid = "1003";//测试时使用
        if (!IsPostBack)
        {
            ViewState["ARID"] = "0";
            txtARReiSinNum.Text = ConfigurationManager.AppSettings["AreaCode"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000);
            btnAddDoc.Enabled = false;
            string yearmonth = Request["yearmonth"];
            txtBITime.Text = yearmonth;
            //ddlARExpSub.Enabled = false;  
            ARExpSubDataBind();
            ARRepDepDataBind();
        }

        // ARExpProDataBind();//绑定支出项目名称
    }

    private void ARExpProDataBind()
    {
        //string sql = "select * from BG_PayProject";
        //DataTable dt = BudgetWeb.DAL.DBUnity.AdapterToTab(sql);
        //ddlARExpPro.DataTextField = "PayPrjName";
        //ddlARExpPro.DataValueField = "PPID";
        //ddlARExpPro.DataSource = dt;
        //ddlARExpPro.DataBind(); 
    }

    private void ARExpSubDataBind()
    {
        //DataTable dtmp = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), depid);
        //DataTable dt = BG_NPayIncomeLogic.GetAllBG_NPayIncome();
        //dt.Columns.Add("Balance");
        //dt.Columns.Add("PIID");
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    dt.Rows[i]["PIID"] = 0;
        //    string drselect = string.Format("PIEcoSubName='{0}'", dt.Rows[i]["PIEcoSubName"].ToString());
        //    DataRow[] drpay = dtmp.Select(drselect);
        //    if (drpay.Length > 0)
        //    {
        //        dt.Rows[i]["Balance"] = ParToDecimal.ParToDel(drpay[0]["SuppMon"].ToString()) + ParToDecimal.ParToDel(drpay[0]["BAAMon"].ToString());
        //        dt.Rows[i]["PIID"] = drpay[0]["PIID"];
        //    }
        //}


        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        ddlARExpSub.DataTextField = "PIEcoSubName";
        ddlARExpSub.DataValueField = "PIEcoSubName";
        ddlARExpSub.DataSource = dt;
        ddlARExpSub.DataBind();
        ddlARExpSub.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--请选择--", "0"));

    }

    private void ARRepDepDataBind()
    {
        DataTable dt = new DataTable(); //BGDepartmentManager.GetDepByfadepid(depid);
        if (depid == AreaDepID)
        {
            dt = BGDepartmentManager.GetDepByfadepid(depid);
        }
        else
        {
            dt = BGDepartmentManager.GetDepByDepid(depid);
        }
        ddlARRepDep.DataTextField = "DepName";
        ddlARRepDep.DataValueField = "DepID";
        ddlARRepDep.DataSource = dt;
        ddlARRepDep.DataBind();
        ddlARRepDep.SelectedItem.Value = depid.ToString();
    }
    //private void cbPayProjectBind()
    //{
    //    DataTable dt = BG_PayProjectManager.GetAllBG_PayProject();
    //    ddlARExpPro.DataTextField = "PayPrjName";
    //    ddlARExpPro.DataValueField = "PPID";
    //    ddlARExpPro.DataSource = dt;
    //    ddlARExpPro.DataBind();
    //}

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlARExpSub.SelectedValue == "0")
        {
            lbResult.Text = "请选择一项具体的经济科目！";
            return;
        }

        BG_ApplyReimbur bt = new BG_ApplyReimbur();
        bt.ARAgent = txtARAgent.Text.Trim();                              //经办人
        bt.ARExcu = txtARExcu.Text.Trim();                               //事由
        //bt.ARExpPro = ddlARExpPro.SelectedItem.Value;                    //支出项目
        DataTable dtpiid= BG_PayIncomeLogic.GetBG_PayIncomeByname(ddlARExpSub.SelectedItem.Value.ToString());
        bt.PPID = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
        //bt.ARExpType = ddlARExpType.Text.Trim();                        //支出类型
        bt.ARListSta = "未提交";                        //申请表状态
        bt.ARMon = decimal.Parse(txtARMon.Text.Trim());                 //金额 
        bt.ARReiSinNum = txtARReiSinNum.Text.Trim();         //报销单号
        bt.ARRepDep = ddlARRepDep.SelectedItem.Text.Trim();                          //上报部门
        bt.ARTime = DateTime.Parse(txtBITime.Text.Trim());                                       //申请时间
        bt.DepID = DepID;       //部门
        if (decimal.Parse(txtARMon.Text.Trim()) > decimal.Parse(lbBalance.Text.Substring(3, lbBalance.Text.Length-4)))
        {
            lbResult.Text = "报销金额大于当月所剩金额，不允许报销！";
            //btnAdd.Enabled = false;
            return;
        }
        int iden = BGApplyReimburManager.AddApplyReimbur(bt);
        if (iden > 0)
        {
            lbResult.Text = "添加报销单已完成，如果需要添加报销单据，可选择添加报销类型然后点击添加报销单。";
            //Response.Write("<script language='javascript'>if(confirm('是否继续添加?')){window.location.reload();}else{$(#'btnAddDoc').Enable=true;}</script>");
            ViewState["ARID"] = iden.ToString();
            btnAddDoc.Enabled = true;
            Session["content"] = bt.ARRepDep + "*" + bt.ARTime + "*" + bt.ARMon.ToString() + "*" + bt.ARAgent;
            Session["content1"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon + "*" + bt.ARAgent + "*" + bt.ARExcu;
            Session["content2"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon + "*" + bt.ARAgent + "*" + bt.ARExcu + "*" + bt.ARListSta;
            Session["content3"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon;
        }
        else
        {
            lbResult.Text = "添加失败，请重新添加";
        }
    }
 
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyList.aspx", true);
    }

    protected void btnAddDoc_Click(object sender, EventArgs e)
    {
        arid = ViewState["ARID"].ToString();
        string strcontent = Session["content"].ToString();
        string strcontent1 = Session["content1"].ToString();
        string strcontent2 = Session["content2"].ToString();
        string strcontent3 = Session["content3"].ToString();
        if (arid == "0")
            return;

        if (radMed.Checked)
        {
            Response.Redirect("ApplyMediCost.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent1, true);
        }
        else if (radPur.Checked)
        {
            Response.Redirect("OfficeSupplies.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radTrain.Checked)
        {
            Response.Redirect("Train.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radMeet.Checked)
        {
            Response.Redirect("ConferenceFees.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent3, true);
        }
        else if (radPrint.Checked)
        {
            Response.Redirect("InformationPrinted.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radOth.Checked)
        {
            Response.Redirect("Expense.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent1, true);
        }
        else if (radTra.Checked)
        {
            Response.Redirect("BusinessTrip.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radCar.Checked)
        {
            Response.Redirect("CarRecordSheet.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radMaintenance.Checked)
        {
            Response.Redirect("Maintenance.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radUnion.Checked)
        {
            Response.Redirect("GuildActivity.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }

    }


    //protected void ddlARExpType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlARExpType.Text.ToString() == "基本支出")
    //    {
    //        ARExpSubDataBind();
    //        ddlARExpPro.Enabled = false;
    //    }
    //    if (ddlARExpType.Text.ToString() == "项目支出")
    //    {
    //        cbPayProjectBind();
    //        cbPayIncomeBind();
    //        ddlARExpPro.Enabled = true;
    //    }
    //}
    protected void ddlARExpSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        latt.Visible = false;
        btnAdd.Enabled = true;
        if (txtBITime.Text.Length <= 0)
        {
            latt.Visible = true;
            latt.Text = "请先选择报销时间";
            return;
        }
        if (ddlARExpSub.SelectedItem.Text.ToString() == "差旅费")
        {
            radTra.Visible = true;
            radTra.Checked = true;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "医疗费")
        {
            radMed.Visible = true;
            radMed.Checked = true;
            radTra.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "办公设备购置费")
        {
            radPur.Visible = true; 
            radPur.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "培训费")
        {
            radTrain.Visible = true; 
            radTrain.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "会议费")
        {
            radMeet.Visible = true; 
            radMeet.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "印刷费")
        {
            radPrint.Visible = true; 
            radPrint.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "维修（护）费")
        {
            radMaintenance.Visible = true;
            radMaintenance.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "工会经费")
        {
            radUnion.Visible = true;
            radUnion.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radMaintenance.Visible = false;
            radCar.Visible = false;
        }
        else if (ddlARExpSub.SelectedItem.Text.ToString() == "公务用车运行维护费")
        {
            radCar.Visible = true;
            radCar.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radPrint.Visible = false;
            radUnion.Visible = false;
            radMaintenance.Visible = false;
        }
        else
        {
            radOth.Visible = true; 
            radOth.Checked = true;
            radTra.Visible = false;
            radMed.Visible = false;
            radPur.Visible = false;
            radTrain.Visible = false;
            radMeet.Visible = false;
            radMaintenance.Visible = false;
            radUnion.Visible = false;
            radCar.Visible = false;
        }

        if (ddlARExpSub.SelectedValue == "0")
        {
            lbdes.Visible = false;
            lbBalance.Visible = false;
            return;
        }

        string pname = ddlARExpSub.SelectedItem.Value.ToString();
        DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(pname);
        int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
        string ARTime = Convert.ToDateTime(txtBITime.Text.Trim()).ToString("yyyy-MM");
        if (!BG_ApplyReimburLogic.ISApplyBackMon(piid,ARTime, DepID))// BG_ApplyReimburLogic.GetARMon(ppid, DepID, ARTime);
        {
            //DataTable dt = BG_ApplyReimburLogic.GetARMon(piid, DepID, ARTime);
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) - BG_ApplyReimburLogic.GetARMon(
                    pname, ARTime, DepID);
                HidtxtARMon.Value = balance.ToString();
                lbBalance.Text = "余额为" + balance.ToString() + "元";

                if (balance == 0)
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                lbBalance.Text = "余额为" + "0.00" + "元";
                btnAdd.Enabled = false;

            }
        }
        else
        {
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) * 10000 - BG_ApplyReimburLogic.GetARMon(
                    pname, ARTime, DepID) +BG_ApplyReimburLogic.ApplyBackMon(ARTime, DepID);
                HidtxtARMon.Value = balance.ToString();
                lbBalance.Text = "余额为" + balance.ToString() + "元";

                if (balance == 0)
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                lbBalance.Text = "余额为" + "0.00" + "元";
                btnAdd.Enabled = false;

            }

        }
    }

    private decimal Tdecimal(string str)
    {
        decimal sss = 0;
        if (string.IsNullOrEmpty(str))
        {
            sss = 0;
        }
        else
        {
            sss = Convert.ToDecimal(str);
        }
        return sss;
    }
    //protected void ddlARExpPro_SelectedIndexChange(ARTime ,ppid ,DepID );d(object sender, EventArgs e)
    //{
    //    if (ddlARExpType.Text.ToString() == "项目支出")
    //    {

    //        if (ddlARExpPro.Text.ToString() == "培训费")
    //        {
    //            radTrain.Visible = true;
    //            radPur.Visible = false;
    //            radMeet.Visible = false;
    //            radOth.Visible = false;
    //        }
    //        else
    //        if (ddlARExpPro.Text.ToString() == "会议费")
    //        {
    //            radMeet.Visible = true;
    //            radPur.Visible = false;
    //            radTrain.Visible = false;
    //            radOth.Visible = false;
    //        }  
    //        else
    //        {
    //            radOth.Visible = true;
    //            radPur.Visible = false;
    //            radTrain.Visible = false;
    //            radMeet.Visible = false;
    //        }

    //    }

    //}  
}