using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using System.IO;

public partial class mainPages_AuditorQuery : BudgetBasePage
{
    private int depID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnexport.Enabled = false;
        //depID = 1104;
        if (!IsPostBack)
        {
            ddlDepDataBind();
            //AuditorDataBind(1083);
            ddlTimeDataBind();
        }

    }

    private void ddlDepDataBind()
    {
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        ddlDep.DataTextField = "DepName";
        ddlDep.DataValueField = "DepID";
        ddlDep.DataSource = dt;
        ddlDep.DataBind();
        ddlDep.Items.Insert(0, new ListItem("全局", "0"));

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
        DataTable dt = null;
        if (depID == 0)
        {
            dt = BGApplyReimburManager.GetApplyReimburAll(yearmonth);
        }
        else
        {
            dt = BGApplyReimburManager.GetApplyReimburSByDepID(depID, yearmonth);
        }
        if (dt.Rows.Count > 0)
        {
            btnexport.Enabled = true;
        }
        else
        {
            string message = "没有查询到数据";
            Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
            btnexport.Enabled = false;
        }
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
    private DataTable getnewdt(DataTable dt)
    {
        DataView dv = new DataView(dt);
        DataTable dtnew = dv.ToTable(true);
        dtnew.Columns.Remove("ARTime");
        dtnew.Columns.Add("ARTime", typeof(string));
        for (int i = 0; i < dtnew.Rows.Count; i++)
        {
            dtnew.Rows[i]["ARTime"] = Convert.ToDateTime(dt.Rows[i]["ARTime"]).ToString("yyyy-MM-dd");
        }
        return dtnew;
    }
    protected void btnInq_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlyear.Text.Trim() + "-" + ddlmonth.Text.Trim();
        depID = Utils.IntSafeConvert(ddlDep.SelectedValue);
        AuditorDataBind(depID, yearmonth);
      
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlyear.Text.Trim() + "-" + ddlmonth.Text.Trim();
        depID = Utils.IntSafeConvert(ddlDep.SelectedValue);
        DataTable dt;
        if (depID == 0)
        {
            dt = BGApplyReimburManager.GetApplyReimburAllExport(yearmonth);
        }
        else
        {
            dt = BGApplyReimburManager.GetApplyReimburSByDepID(depID, yearmonth);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            MemoryStream ms = ExcelRender.RenderToExcelSetHead(getnewdt(dt), "报销单号#上报单位#经办人#金额#事由#申请单状态#申请时间");
            Response.ContentType = "application/xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("报销单历史查询.xls", System.Text.Encoding.UTF8));
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        else
        {
            this.Response.Write("<script>alert('无数据不允许导出')</script>");
        }
    }
}
