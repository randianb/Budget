using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BudgetWeb.BLL;
using Common;
public partial class BudgetPage_mainPages_ApplyList : BudgetBasePage
{
    private int depID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        depID = DepID;

        if (!IsPostBack)
        {

            ddlTimeDataBind();
            //int arid = common.IntSafeConvert(.SelectedValue);
            //BGApplyReimburDataBind(1083);
        }

    }

    private void ddlTimeDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Year");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add("");
            dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        }
        ddlYear.DataTextField = "Year";
        ddlYear.DataValueField = "Year";
        ddlYear.DataSource = dt1;
        ddlYear.DataBind();
    }

    private void BGApplyReimburDataBind(int depID, string yearmonth)
    {
        lbshow.Text = "";
        DataTable dt = BGApplyReimburManager.GetByDepID(depID, yearmonth);
        if (dt.Rows.Count == 0)
        {
            lbshow.Text = "该月没查询到数据。"; 
        }
        repReiStaQue.DataSource = dt;
        repReiStaQue.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim()+"-01";
        Response.Redirect("ApplyAdd.aspx?yearmonth=" + yearmonth, true);
    }
    protected void repReiStaQue_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string arid = e.CommandArgument.ToString();

        if (e.CommandName == "AltPro")
        {
            //修改
            Response.Redirect("ApplyAlter.aspx?arid=" + arid, true);
        }
        else if (e.CommandName == "DelPro")
        {
            //删除
            BGApplyReimburManager.DelApplyReimbur(arid);
            string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim();
            BGApplyReimburDataBind(depID, yearmonth);
        }
        else if (e.CommandName == "lbtnTJ")
        {
            ////提交
            //if (BGApplyReimburManager.UpdApplication("退回", txtReason.Text, idStrs))
            //{
            //    int year = Utils.IntSafeConvert(ddlYear.SelectedValue);
            //    BGApplyReimburDataBind(depID, year);
            //}
            if (BGApplyReimburManager.UpdApplicationStatus("提交", arid))
            {
                string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim();
                BGApplyReimburDataBind(depID, yearmonth);
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim();
        BGApplyReimburDataBind(depID, yearmonth);

    }
}