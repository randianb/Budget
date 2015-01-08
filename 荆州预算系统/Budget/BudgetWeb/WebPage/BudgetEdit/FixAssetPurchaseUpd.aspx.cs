using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using System.Data;

public partial class BudgetPage_mainPages_FixAssetPurchaseUpd : System.Web.UI.Page
{
    int faid;
    int depid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["faid"] != null && Request.QueryString["depid"] != null)
        {
            faid = common.IntSafeConvert(Request.QueryString["faid"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
        else
        {
            Response.Redirect("FixAssetPurchase.aspx", true);
        }
        if (!IsPostBack)
        {
            FixBind(faid);
        }
    }
    public void FixBind(int faid)
    {
        BG_FixAssetPurchase fap = BGFixAssetPurchaseManager.GetFAPByFaid(faid);
        if (fap != null)
        {
            txtSort.Text = fap.FAName;
            txtModel.Text = fap.FAModel;
            txtBrand.Text = fap.FABrand;
            txtNum.Text =   fap.FANum.ToString();
            txtTime.Text =  fap.FATime.ToString("yyyy-MM-dd");
            txtPrice.Text = fap.FAPrice.ToString();
            txtConfig.Text = fap.FAConfig;
            txtRemark.Text = fap.FARemark;
            ddlIsGovper.SelectedValue = fap.FAIsGovPur.ToString();
            txtMon.Text = fap.FAMon.ToString();
            HidBudid.Value = fap.BudID.ToString();
        }
    }

    protected void btnUpd_Click(object sender, EventArgs e)
    {

        BG_FixAssetPurchase bap = BGFixAssetPurchaseManager.GetFAPByFaid(faid);
        bap.FAName = txtSort.Text.Trim();
        bap.FAModel = txtModel.Text.Trim();
        bap.FABrand = txtBrand.Text.Trim();
        bap.FAPrice = decimal.Parse(txtPrice.Text.Trim());
        bap.FANum = int.Parse(txtNum.Text.Trim());
        bap.FAMon = ParseUtil.ToDecimal(HidTotal.Value, 0);
        bap.FAIsGovPur = ddlIsGovper.SelectedValue;
        bap.FAConfig = txtConfig.Text.Trim();
        bap.FARemark = txtRemark.Text.Trim();
        if (BGFixAssetPurchaseManager.UpdFix(bap))
        {
            lblShowResult.Text = "* 修改员工信息成功";
        }
        else
        {
            lblShowResult.Text = "* 操作失败、请重试";
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixAssetPurchase.aspx?budid=" + HidBudid.Value + "&depid=" + depid, true);
    }
}