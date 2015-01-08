using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using BudgetWeb.Model;

public partial class BudgetPage_mainPages_BudgetReviewDetails : System.Web.UI.Page
{
    public int budid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null && !string.IsNullOrEmpty(Request.QueryString["depid"]))
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            Hidbuid.Value = budid.ToString();
        }
        else
        {
            Response.Redirect("BudgetReview.aspx", true);
        }
        if (!IsPostBack)
        {
            ddlPayProTypeBind();
            txtBind(budid);
            repBudExamBind(budid);
        }
        
    }
    //private void ddlIncomeBind()
    //{
    //    //DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(ddlPayProType.SelectedValue));//yj
    //    //if (dt.Rows.Count > 0)
    //    //{
    //    //    ddlIncome.DataSource = dt;
    //    //    ddlIncome.DataTextField = "PIEcoSubName";
    //    //    ddlIncome.DataValueField = "PIEcoSubName";
    //    //    ddlIncome.DataBind();
    //    //}
    //    DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
    //    ddlIncome.DataSource = dt;
    //    ddlIncome.DataTextField = "PIEcoSubName";
    //    ddlIncome.DataValueField = "PIEcoSubName";
    //    ddlIncome.DataBind();
    //}
    private void ddlPayProTypeBind()
    {
        DataTable dt = BGPayProjectManager.GetAllPayProject();
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlPayProType.DataSource = dt;
            ddlPayProType.DataTextField = "PayPrjName";
            ddlPayProType.DataValueField = "PPID";
            ddlPayProType.DataBind();
        }
    }

    private void repBudExamBind(int budid)
    {
        DataTable dt = BGBudCostProManager.GetDtBcpByBudid(budid);
        if (dt.Rows.Count > 0)
        {
            repBudExam.DataSource = dt;
            repBudExam.DataBind();
        }
    }

    private void txtBind(int buid)
    {
        BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(buid);
        if (bi != null)
        {
            txtBIAppReaCon.Text = bi.BIAppReaCon;
            // txtProName.Text = bi
            ddlProProper.SelectedValue = bi.BIAttr;
            txtBICharger.Text = bi.BICharger;
            txtItemNumber.Text = bi.BICode.ToString();
            txtBIExpGistExp.Text = bi.BIExpGistExp;
            ddlFunSub.SelectedValue = bi.BIFunSub;
            txtBILongGoal.Text = bi.BILongGoal;
            txtBIOthExpProb.Text = bi.BIOthExpProb;
            ddlBIPlanHz.Text = bi.BIPlanHz.ToString();
            //ddlPayProType.SelectedValue = bi.BIProType;
            txtBIStaTime.Text = bi.BIStaTime.ToString("yyyy-MM-dd");
            txtBIEndTime.Text = bi.BIEndTime.ToString("yyyy-MM-dd");
            txtBITime.Text = bi.BIReportTime.ToString("yyyy-MM-dd");
            txtBIYearGoal.Text = bi.BIYearGoal;
            ddlPayProType.SelectedValue = bi.PPID.ToString();
            hidPPID.Value = bi.PPID.ToString();
            txtProName.Text = bi.BIProName.ToString();
            txtProDesc.Text = bi.BIProDescrip.ToString();
            txtBIMon.Text = bi.BIMon.ToString();
            txtBackReason.Text = bi.BICause;
            txtBudConNumber.Text = bi.BIConNum.ToString();
            Hiddepid.Value = bi.DepID.ToString();
            ddlProType.SelectedValue = bi.BIProCategory;
        }
    }

    protected void repBudExam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList ddl = e.Item.FindControl("ddlIncome") as DropDownList;
        HiddenField hidid = e.Item.FindControl("HidPIID") as HiddenField;
        DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(hidid.Value));// BGPayIncomeManager.GetPayIncomeListByPIID(piid);
        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "PIEcoSubName";
            ddl.DataValueField = "PIID";
            ddl.SelectedValue = hidid.Value;
            ddl.DataBind();
        }
        //DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        //ddl.DataSource = dt;
        //ddl.DataTextField = "PIEcoSubName";
        //ddl.DataValueField = "PIEcoSubName";
        //ddl.DataBind(); 
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(budid);
        bi.BudSta = "退回";
        bi.BIConNum = ParseUtil.ToDecimal(txtBudConNumber.Text.Trim(), 0);
        bi.BICause = txtBackReason.Text.Trim();

        BG_BudItemHis hisbi = new BG_BudItemHis();
        hisbi.BudID =budid ;
        hisbi.BIAppConMon = 0;// decimal.Parse(txtBudConNumber.Text.Trim());审批控制金额，应该是预算控制数
        hisbi.BIAppReaCon = txtBIAppReaCon.Text.Trim();
        hisbi.BIAttr = ddlProProper.SelectedValue;
        hisbi.BIBudSta = "等下对接"; //Session[Constant.UserName].ToString();  
        hisbi.BICause = txtBackReason.Text.Trim();//退回原因
        hisbi.BICharger = txtBICharger.Text.Trim();
        hisbi.BICode = txtItemNumber.Text.Trim(); //项目编号
        hisbi.BIEndTime = DateTime.Parse(txtBIEndTime.Text.Trim());
        hisbi.BIExpGistExp = txtBIExpGistExp.Text.Trim();
        hisbi.BIConNum = ParseUtil.ToDecimal( txtBudConNumber.Text,0);
        hisbi.BIFinAllo = 0;// decimal.Parse(txtBudConNumber.Text.Trim());财政拨款
        hisbi.BIFunSub = ddlFunSub.Text.Trim();
        hisbi.BILastYearCarry = 0;// decimal.Parse(txtBudConNumber.Text.Trim());上年结账
        hisbi.BILongGoal = txtBILongGoal.Text.Trim();
        hisbi.BIMon = common.IntSafeConvert(txtBIMon.Text);      //GetBIMon(coll.GetValues("txt4"));
        hisbi.BIMonSou = "";//资金来源
        hisbi.BIOthExpProb = txtBIOthExpProb.Text.Trim();
        hisbi.BIOthFun = 0;// decimal.Parse(txtBudConNumber.Text.Trim());其他资金
        hisbi.BIPlanHz = ddlBIPlanHz.SelectedValue; //项目频度
        hisbi.BIProType = ddlPayProType.SelectedItem.Text;
        hisbi.BIStaTime = DateTime.Parse(txtBIStaTime.Text.Trim());
        hisbi.BIYearGoal = txtBIYearGoal.Text.Trim();
        hisbi.PPID = common.IntSafeConvert(ddlPayProType.SelectedValue);//
        hisbi.BudSta = "退回";//
        hisbi.PIID = BG_PayProjectManager.GetBG_PayProjectByPPID(bi.PPID).PIID; ;//common.IntSafeConvert(ddlFunSub.SelectedValue);//yj
        hisbi.BIProName = txtProName.Text.Trim();
        hisbi.BIReportTime = ParseUtil.ToDateTime(txtBITime.Text.Trim(), DateTime.Now);
        //hisbi.BIConNum = 0;//预算控制数 
        hisbi.BIProDescrip = txtProDesc.Text.Trim();
        hisbi.DepID = common.IntSafeConvert(Hiddepid.Value);
        hisbi.BIProCategory = ddlProType.SelectedItem.Text;
        int flaid = BG_BudItemHisManager.AddBG_BudItemHis(hisbi).BudHisID; 
        if (BGBudItemsManager.UpdBudItems(bi)&&flaid>0)
        { 
            btnAppo.ForeColor = Color.Gray;
            btnAppo.Enabled = false;
            btnElimin.ForeColor = Color.Gray;
            btnElimin.Enabled = false;
            lblShowResult.Text = "项目已退回";
        }
        else
        {
            lblShowResult.Text = "操作失败、请重试";
        }
    }
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetReview.aspx?depid=" + Request.QueryString["depid"], true);
    }
    protected void btnAppo_Click(object sender, EventArgs e)
    {
        bool flag = BGBudItemsManager.UpdBudSta(budid, "审核通过");
        if (flag)
        {
            BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(budid);
            BG_BudItemHis hisbi = new BG_BudItemHis();
            hisbi.BudID = budid;
            hisbi.BIAppConMon = bi.BIAppConMon;
            hisbi.BIAppReaCon = bi.BIAppReaCon;
            hisbi.BIAttr = bi.BIAttr;
            hisbi.BIBudSta = bi.BIBudSta;
            hisbi.BICause = bi.BICause;
            hisbi.BICharger = bi.BICharger;
            hisbi.BICode = bi.BICode;
            hisbi.BIEndTime = bi.BIEndTime;
            hisbi.BIExpGistExp = bi.BIExpGistExp;
            hisbi.BIFinAllo = bi.BIFinAllo;
            hisbi.BIFunSub = bi.BIFunSub;
            hisbi.BILastYearCarry = bi.BILastYearCarry;
            hisbi.BILongGoal = bi.BILongGoal;
            hisbi.BIMon = bi.BIMon;
            hisbi.BIConNum = ParseUtil.ToDecimal(txtBudConNumber.Text, 0);
            hisbi.BIMonSou = bi.BIMonSou;
            hisbi.BIOthExpProb = bi.BIOthExpProb;
            hisbi.BIOthFun = bi.BIOthFun;
            hisbi.BIPlanHz = bi.BIPlanHz;
            hisbi.BIProType = bi.BIProType;
            hisbi.BIStaTime = bi.BIStaTime;
            hisbi.BIYearGoal = bi.BIYearGoal;
            hisbi.PPID = bi.PPID;
            hisbi.BudSta = bi.BudSta;
            hisbi.PIID = bi.PIID;
            hisbi.BIProName = bi.BIProName;
            hisbi.BIReportTime = bi.BIReportTime; 
            hisbi.BIProDescrip = bi.BIProDescrip;
            hisbi.DepID = bi.DepID;
            hisbi.BIProCategory = bi.BIProCategory;
            BG_BudItemHisManager.AddBG_BudItemHis(hisbi);
            btnElimin.ForeColor = Color.Gray;
            btnElimin.Enabled = false;
            btnReturn.ForeColor = Color.Gray;
            btnReturn.Enabled = false;
            lblShowResult.Text = "项目上报成功";
        }
        else
        {
            lblShowResult.Text = "操作失败、请重试";
        }
    }
    protected void btnElimin_Click(object sender, EventArgs e)
    {
        string message = "被淘汰的项目不可以恢复，是否淘汰?";
        Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
        BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(budid);
        bi.BudSta = "淘汰";
        bi.BIConNum = ParseUtil.ToDecimal(txtBudConNumber.Text.Trim(), 0);
        bi.BICause = txtBackReason.Text.Trim();
        if (BGBudItemsManager.UpdBudItems(bi))
        { 
            BG_BudItemHis hisbi = new BG_BudItemHis();
            hisbi.BudID = budid;
            hisbi.BIAppConMon = bi.BIAppConMon;
            hisbi.BIAppReaCon = bi.BIAppReaCon;
            hisbi.BIAttr = bi.BIAttr;
            hisbi.BIBudSta = bi.BIBudSta;
            hisbi.BICause = bi.BICause;
            hisbi.BICharger = bi.BICharger;
            hisbi.BICode = bi.BICode;
            hisbi.BIEndTime = bi.BIEndTime;
            hisbi.BIExpGistExp = bi.BIExpGistExp;
            hisbi.BIFinAllo = bi.BIFinAllo;
            hisbi.BIFunSub = bi.BIFunSub;
            hisbi.BILastYearCarry = bi.BILastYearCarry;
            hisbi.BILongGoal = bi.BILongGoal;
            hisbi.BIMon = bi.BIMon;
            hisbi.BIMonSou = bi.BIMonSou;
            hisbi.BIOthExpProb = bi.BIOthExpProb;
            hisbi.BIOthFun = bi.BIOthFun;
            hisbi.BIPlanHz = bi.BIPlanHz;
            hisbi.BIProType = bi.BIProType;
            hisbi.BIStaTime = bi.BIStaTime;
            hisbi.BIYearGoal = bi.BIYearGoal;
            hisbi.PPID = bi.PPID;
            hisbi.BudSta = bi.BudSta;
            hisbi.PIID = bi.PIID;
            hisbi.BIProName = bi.BIProName;
            hisbi.BIReportTime = bi.BIReportTime;
            hisbi.BIConNum = bi.BIConNum;
            hisbi.BIProDescrip = bi.BIProDescrip;
            hisbi.DepID = bi.DepID;
            hisbi.BIProCategory = bi.BIProCategory;
            BG_BudItemHisManager.AddBG_BudItemHis(hisbi);
            btnAppo.ForeColor = Color.Gray;
            btnAppo.Enabled = false;
            btnReturn.ForeColor = Color.Gray;
            btnReturn.Enabled = false;
            lblShowResult.Text = "项目已淘汰";
        }
        else
        {
            lblShowResult.Text = "操作失败、请重试";
        }
    }
}