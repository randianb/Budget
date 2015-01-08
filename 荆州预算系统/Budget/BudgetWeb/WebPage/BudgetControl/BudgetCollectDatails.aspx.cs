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

public partial class BudgetPage_mainPages_BudgetCollectDatails : System.Web.UI.Page
{
    public int budid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null)
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            Hidbuid.Value = budid.ToString();
        }
        else
        {
            Response.Redirect("BudgetCollect.aspx", true);
        }
        if (!IsPostBack)
        {
            ddlPayProTypeBind();
            txtBind(budid);
            repBudExamBind(budid);
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
            hidSta.Value = bi.BudSta;
        }
    }

    protected void repBudExam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList ddl = e.Item.FindControl("ddlIncome") as DropDownList;
        //HiddenField hidid = e.Item.FindControl("HidPIID") as HiddenField;
        DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(hidPPID.Value));// BGPayIncomeManager.GetPayIncomeListByPIID(piid);
        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "PIEcoSubName";
            ddl.DataValueField = "PIID";
            ddl.SelectedValue = hidPPID.Value;
            ddl.DataBind();
        }
    }

    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetCollect.aspx?depid=" + Hiddepid.Value+"&sta="+hidSta.Value, true);
       // this.RegisterClientScriptBlock("BudCollDateils", "<script language=javascript>history.go(-2);</script>");
    }
}