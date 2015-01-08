using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;

public partial class mainPages_ReimStaffQuery : BudgetBasePage
{
    private int depID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        depID = DepID;
        if (!IsPostBack)
        {
            //AuditorDataBind(1083);
            ddlTimeDataBind();
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
        ddlyear.DataTextField = "Year";
        ddlyear.DataValueField = "Year";
        ddlyear.DataSource = dt1;
        ddlyear.DataBind();
    }

    private void AuditorDataBind(int depID, string yearmonth)
    {

        DataTable dt = BGApplyReimburManager.GetApplyReimburSByDepID(depID, yearmonth);
        if (dt.Rows.Count <= 0)
        {
            string message = "没有查询到数据";
            Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
        }
        else
        {
            repReiStaQue.DataSource = dt;
            repReiStaQue.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string ARTime = ddlyear.Text.Trim() + "-" + ddlmonth.Text.Trim();
        AuditorDataBind(depID, ARTime);
    }
}
