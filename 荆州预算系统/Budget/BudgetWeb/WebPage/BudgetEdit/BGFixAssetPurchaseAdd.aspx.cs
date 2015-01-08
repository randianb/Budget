using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;

public partial class BudgetPage_mainPages_BGFixAssetPurchaseAdd : System.Web.UI.Page
{
    int budid;
    int depid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null && Request.QueryString["depid"] != null)
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
            HidBudid.Value = budid.ToString();
        }
        else
        {
            Response.Redirect("FixAssetPurchase.aspx", true);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BG_FixAssetPurchase bp = new BG_FixAssetPurchase();
        bp.FAName = txtSort.Text.Trim();
        bp.FAModel = txtModel.Text.Trim();
        bp.FABrand = txtBrand.Text.Trim();
        bp.FAPrice =decimal.Parse(txtPrice.Text.Trim());
        bp.FANum=int.Parse(txtNum.Text.Trim());
        bp.FAMon = ParseUtil.ToDecimal(HidTotal.Value, 0);
        bp.FAIsGovPur = ddlIsGovper.SelectedValue;
        bp.FAConfig = txtConfig.Text.Trim();
        bp.FARemark = txtRemark.Text.Trim();
        bp.FATime = DateTime.Parse(txtTime.Text.Trim());
        bp.BudID = common.IntSafeConvert(HidBudid.Value);
        if (BGFixAssetPurchaseManager.AddFix(bp))
        {
            lbResult.Text = "申请添加成功";
        }
        else
        {
            lbResult.Text = "添加失败，请重新添加";
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixAssetPurchase.aspx?budid=" + budid + "&depid=" + depid, true);
    }
}