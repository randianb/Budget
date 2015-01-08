using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BudgetWeb.BLL;
using Common;
using BudgetWeb.Model;

public partial class mainPages_BudgetEditAlter : System.Web.UI.Page
{
    public int buid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null && !string.IsNullOrEmpty(Request.QueryString["depid"]))
        {
            buid = common.IntSafeConvert(Request.QueryString["budid"]);
            Hidbuid.Value = buid.ToString();
        }
        else
        {
            Response.Redirect("BudgetEditList.aspx", true);
        }
        if (!IsPostBack)
        {
            ddlPayProTypeBind();
            txtBind(buid);
            repPayProjectBind(buid);
        }
    }

    private void repPayProjectBind(int budid)
    {
        DataTable dt = BGBudCostProManager.GetDtBcpByBudid(budid);
        if (dt.Rows.Count > 0)
        {
            HidRowCount.Value = dt.Rows.Count.ToString();
            repPayProject.DataSource = dt;
            repPayProject.DataBind();
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
            HidRowCount.Value = BGBudCostProManager.GetBudCostProCountByBudid(buid).ToString();
            Hiddepid.Value = bi.DepID.ToString();
            ddlProType.SelectedValue = bi.BIProCategory;
        }
    }

    protected void btnUpd_Click(object sender, EventArgs e)
    {
      
        int bid = common.IntSafeConvert(Hidbuid.Value);
        BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(bid);
        bi.BIAppReaCon = txtBIAppReaCon.Text.Trim();
        bi.BIAttr = ddlProProper.SelectedValue;
        bi.BIBudSta = ""; //Session[Constant.UserName].ToString();
        bi.BudSta = "未提交";
        bi.BICharger = txtBICharger.Text.Trim();
        //bi.BICode =txtItemNumber.Text.Trim();
        bi.BIEndTime = DateTime.Parse(txtBIEndTime.Text.Trim());
        bi.BIExpGistExp = txtBIExpGistExp.Text.Trim();
        bi.BIFunSub = ddlFunSub.SelectedValue;
        bi.BILongGoal = txtBILongGoal.Text.Trim();
        bi.BIOthExpProb = txtBIOthExpProb.Text.Trim();
        bi.BIPlanHz = ddlBIPlanHz.SelectedValue;
        bi.BIProType = ddlPayProType.SelectedItem.Text;
        bi.BIStaTime = DateTime.Parse(txtBIStaTime.Text.Trim());
        bi.BIYearGoal = txtBIYearGoal.Text.Trim();
        bi.PPID = common.IntSafeConvert(ddlPayProType.SelectedValue);
        bi.BIProName = txtProName.Text.Trim();
        bi.BIReportTime = ParseUtil.ToDateTime(txtBITime.Text.Trim(),DateTime.Now);
        // bi.BIConNum = 0;
        bi.BIProDescrip = txtProDesc.Text.Trim();
        bi.BIProCategory = ddlProType.SelectedValue;
        decimal bimon = ParseUtil.ToDecimal(HidMonTotal.Value, 0); //GetBIMon(coll.GetValues("txt4"));
        bi.BIMon = bimon;
        int buid = bi.BudID;
        int depid = bi.DepID;
        int bcn =(int)ParseUtil.ToDecimal(txtBudConNumber.Text,0);
        if (bcn != 0)
        {
            decimal bunconnum = bi.BIConNum;
            if (bunconnum < bimon)
            {
                lblShowResult.Text = "*预算金额超标！";
                return;
            }
        }
        if (BGBudItemsManager.UpdBudItems(bi))
        {
            string idStrs = BGBudCostProManager.GetDelIdsStr(buid);
            bool delFlag = BGBudCostProManager.DelBCPByIdStrs(idStrs);
             
            if (delFlag)
            {
                NameValueCollection coll = Request.Form;
                string selectVal = HidSelectVal.Value.TrimEnd(',');
                string[] arrs = selectVal.Split(',');
                string[] txt1 = coll.GetValues("txt1"); //行号
                string[] txt2 = coll.GetValues("txt2"); //当前年度
                string[] txt3 = arrs; //经济科目
                string[] txt4 = coll.GetValues("txt4"); //总计
                string[] txt5 = coll.GetValues("txt5"); //小计(财政拨款)
                string[] txt6 = coll.GetValues("txt6"); //小计(经费)
                string[] txt7 = coll.GetValues("txt7"); //内部开支(经费)	 
                string[] txt8 = coll.GetValues("txt8"); //外部拨款(经费)
                int rowCount = common.IntSafeConvert(HidRowCount.Value);
                bool flag = false;
                if (rowCount > 0)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        BG_BudCostPro bcp = new BG_BudCostPro();
                        bcp.BudID = buid;
                        bcp.BCPCurrYear =common.IntSafeConvert(txt2[j]);
                        bcp.BCPRemark = "";
                        bcp.PIID = common.IntSafeConvert(txt3[j]);
                        bcp.BCPTotal = ParseUtil.ToDecimal(txt4[j],0);
                        bcp.BCPSubtFinAllo = ParseUtil.ToDecimal(txt5[j],0);
                        bcp.BCPSubtExp = ParseUtil.ToDecimal(txt6[j],0);
                        bcp.BCInExpenses = ParseUtil.ToDecimal(txt7[j],0);
                        bcp.BCOutFunding = ParseUtil.ToDecimal(txt8[j],0);
                        flag = BGBudCostProManager.AddBGBudCostPro(bcp);
                    }
                }
                if (flag)
                {
                    txtBind(buid);
                    repPayProjectBind(buid);
                    lblShowResult.Text = "修改成功";
                    //string PostUrl = "BudgetEditList.aspx?depid=" + depid;
                   // Response.Write("<script language='javascript'>alert('修改成功！');window.location.href='" + PostUrl + "';</script>");
                }
                else
                {
                    lblShowResult.Text = "操作失败、请检查数据后重试";
                }
            }
            else
            {
                lblShowResult.Text = "操作失败、请检查数据后重试";
            }
        }
        else
        {
            lblShowResult.Text = "操作失败、请检查数据后重试";
        }
    }

    #region 统计预算金额
    /// <summary>
    /// 统计预算金额
    /// </summary>
    /// <param name="mon"></param>
    /// <returns></returns>
    private decimal GetBIMon(string[] mon)
    {
        decimal bimon = 0;
        if (mon.Length > 0)
        {
            for (int i = 0; i < mon.Length; i++)
            {
                bimon += ParseUtil.ToDecimal(mon[i], 0);
            }
        }
        return bimon;
    }
    #endregion

    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetEditList.aspx?depid=" + Request.QueryString["depid"], true);
    }
    protected void repPayProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList ddl = e.Item.FindControl("ddlIncome") as DropDownList;
        HiddenField hidid = e.Item.FindControl("HidPIID") as HiddenField;

        DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(hidPPID.Value));// BGPayIncomeManager.GetPayIncomeListByPIID(piid);
        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "PIEcoSubName";
            ddl.DataValueField = "PIID";
            ddl.DataBind();
        }
        if (ddl.Items.FindByValue(hidid.Value)!=null)
        {
            ddl.SelectedValue = hidid.Value;
        }
    }
    protected void ddlPayProType_SelectedIndexChanged(object sender, EventArgs e)
    {
        hidPPID.Value = ddlPayProType.SelectedValue;
        repPayProjectBind(common.IntSafeConvert(Hidbuid.Value));
       
    }
}
