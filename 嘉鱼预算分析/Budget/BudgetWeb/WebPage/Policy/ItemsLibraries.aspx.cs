using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;

public partial class WebPage_Policy_ItemsLibraries : System.Web.UI.Page
{
    int buditID = 0;
    string flag = "0";//0:表示添加进1表示修改
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            ddlPayProTypeBind();//支出项目
            ddlDepBind();

            if (string.IsNullOrEmpty(Request.QueryString["budid"]))
            {
                flag = "0";
                HidFlag.Value = flag;
                btnSure.Text = "添加";
            }
            else
            {
                buditID = common.IntSafeConvert(Request.QueryString["budid"]);
                Hidbuid.Value = buditID.ToString();
                flag = "1";
                HidFlag.Value = flag;
                txtBind(buditID);
                btnSure.Text = "修改";
            }

        }




    }
    private void txtBind(int buid)
    {
        BG_BudItemsLibraries bi = BG_BudItemsLibrariesManager.GetBG_BudItemsLibrariesByBudItID(buid);//
        if (bi != null)
        {

            txtBIAppReaCon.Text = bi.BILAppReaCon;
            ddlProProper.SelectedValue = bi.BILAttr;
            txtBIExpGistExp.Text = bi.BILExpGistExp;
            ddlFunSub.SelectedValue = bi.BILFunSub;
            txtBILMon.Text = bi.BILMon.ToString();
            ddlDeptName.SelectedValue = bi.DepID.ToString();
            txtBILongGoal.Text = bi.BILLongGoal;
            txtBIOthExpProb.Text = bi.BILOthExpProb;
            txtBIYearGoal.Text = bi.BILYearGoal;
            ddlPayProType.SelectedValue = bi.PPID.ToString();
            txtProName.Text = bi.BILProName.ToString();
            txtProDesc.Text = bi.BILProDescrip.ToString();
            ddlProType.SelectedValue = bi.BILProCategory;
        }
    }

    ///// <summary>
    ///// 部门
    ///// </summary>
    //private void ddlDeptNameBind()
    //{
    //    DataTable dt = BGBudItemsLibrariesManager.GetAllBG_BudItemsLibrariesDept();
    //    if (dt != null && dt.Rows.Count > 0)
    //    {
    //        ddlDeptName.DataSource = dt;
    //        ddlDeptName.DataTextField = "DepName";
    //        ddlDeptName.DataValueField = "DepID";  
    //        ddlDeptName.DataBind();
    //    }
    //}

    //绑定部门
    private void ddlDepBind()
    {
        DataTable dt = null;
        //if (depid == 0)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        //{
        dt = BGDepartmentManager.GetDepByfadepid(1083);
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlDeptName.DataSource = dt;
            ddlDeptName.DataTextField = "DepName";
            ddlDeptName.DataValueField = "DepID";
            ddlDeptName.DataBind();
        }
    }

    /// <summary>
    /// 支出项目
    /// </summary>
    private void ddlPayProTypeBind()
    {
        DataTable dt = BGPayProjectManager.GetAllPayProject();//yj
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlPayProType.DataSource = dt;
            ddlPayProType.DataTextField = "PayPrjName";
            ddlPayProType.DataValueField = "PPID";
            ddlPayProType.DataBind();
        }
    }

    //返回
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LibrariesEditList.aspx", true);
    }


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

    protected void btnSure_Click(object sender, EventArgs e)
    {
        int bid = common.IntSafeConvert(Hidbuid.Value);
        BG_BudItemsLibraries bi = new BG_BudItemsLibraries();
        if (HidFlag.Value == "1")
        {
            bi = BG_BudItemsLibrariesManager.GetBG_BudItemsLibrariesByBudItID(bid);
        }
        bi.BILAppReaCon = txtBIAppReaCon.Text.Trim();
        bi.BILAttr = ddlProProper.SelectedValue;
        bi.BILExpGistExp = txtBIExpGistExp.Text.Trim();
        bi.BILFunSub = ddlFunSub.SelectedValue;
        bi.BILMon = Convert.ToDecimal(txtBILMon.Text);
        bi.BILLongGoal = txtBILongGoal.Text.Trim();
        bi.BILOthExpProb = txtBIOthExpProb.Text.Trim();
        bi.BILProType = ddlPayProType.SelectedItem.Text;
        bi.BILYearGoal = txtBIYearGoal.Text.Trim();
        bi.DepID = common.IntSafeConvert(ddlDeptName.SelectedValue);
        bi.PPID = common.IntSafeConvert(ddlPayProType.SelectedValue);
        bi.BILProName = txtProName.Text.Trim();
        bi.BILProDescrip = txtProDesc.Text.Trim();
        bi.BILProCategory = ddlProType.SelectedValue;
        bi.PIID = BG_PayProjectManager.GetBG_PayProjectByPPID(bi.PPID).PIID;

        if (HidFlag.Value == "0")
        {
            BG_BudItemsLibrariesManager.AddBG_BudItemsLibraries(bi);
            txtBIAppReaCon.Text = "";
            txtBIExpGistExp.Text = "";
            txtBILongGoal.Text = "";
            txtBILMon.Text = "";
            txtBIOthExpProb.Text = "";
            txtBIYearGoal.Text = "";
            txtProDesc.Text = "";
            txtProName.Text = "";
            lblShowResult.Text = "添加成功";
        }
        else
        {
            BG_BudItemsLibrariesManager.ModifyBG_BudItemsLibraries(bi);
            txtBIAppReaCon.Text = "";
            txtBIExpGistExp.Text = "";
            txtBILongGoal.Text = "";
            txtBILMon.Text = "";
            txtBIOthExpProb.Text = "";
            txtBIYearGoal.Text = "";
            txtProDesc.Text = "";
            txtProName.Text = "";
            lblShowResult.Text = "修改成功";
            Response.Redirect("LibrariesEditList.aspx", true);
        }

    }
}