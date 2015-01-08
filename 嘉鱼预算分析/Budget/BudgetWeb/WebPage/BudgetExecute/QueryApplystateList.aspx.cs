using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BudgetWeb.BLL;
using Common;
using System.IO;
public partial class BudgetPage_mainPages_ApplyList : BudgetBasePage
{
    private int depID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        depID = DepID;
        btnexport.Enabled = false;
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
        DataTable dt = BGApplyReimburManager.GetApplyStateByDepID(depID, yearmonth);
        if (dt.Rows.Count > 0)
        {
            btnexport.Enabled = true; 
        }
        else
        {
            btnexport.Enabled = false;
            string message = "没有查询到数据";
            Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
        } 
        repReiStaQue.DataSource =dt;
        repReiStaQue.DataBind();
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

    
    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ApplyAdd.aspx", true);
    //}
    //protected void repReiStaQue_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    string arid = e.CommandArgument.ToString();

    //    if (e.CommandName == "lbtnQr")
    //    {
    //        //查看
    //        Response.Redirect("ApplyAlter.aspx?arid=" + arid, true);
    //    } 
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim();
        BGApplyReimburDataBind(depID, yearmonth);
        btnexport.Enabled = true;
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlYear.Text.Trim() + "-" + ddlMonth.Text.Trim();
        DataTable dt = getnewdt(BGApplyReimburManager.GetApplyStateByDepIDExport(depID, yearmonth));
        if (dt != null && dt.Rows.Count > 0)
        {
            MemoryStream ms = ExcelRender.RenderToExcelSetHead(dt, "报销单号#上报单位#经办人#金额#事由#申请单状态#申请时间");
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