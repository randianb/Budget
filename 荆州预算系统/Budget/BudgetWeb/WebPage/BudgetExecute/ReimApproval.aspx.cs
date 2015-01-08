using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BudgetWeb.BLL;
using Common;

public partial class mainPages_ReimApproval :BudgetBasePage
{
    private int depID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //depID = 1104;
        if (!IsPostBack)
        {
            ddlDepDataBind();
            //BGApplyReimburDataBind(1083);
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

    private void ddlDepDataBind()
    {
         DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        ddlDep.DataTextField = "DepName";
        ddlDep.DataValueField = "DepID";
        ddlDep.DataSource = dt;
        ddlDep.DataBind();
        ddlDep.Items.Insert(0, new ListItem("全局", "0"));

    }
    private DataTable GetSortDT(DataTable dt)
    {
        System.Data.DataView dw = dt.DefaultView;
        dw.Sort = "ARID desc";
        DataTable dt2 = dw.ToTable(true);
        return dt2;
    }

    private void BGApplyReimburDataBind(int depID, string yearmonth)
    {
        DataTable dt = null;
        if (depID == 0)
        {
            dt = BGApplyReimburManager.GetApplyReimburByAll(yearmonth);
        }
        else
        {
            dt = BGApplyReimburManager.GetApplyReimburTByDepID(depID, yearmonth);
        }
        if (dt.Rows.Count <= 0)
        {
            string message = "没有查询到数据";
            Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
        }
        else
        {
            repReimAppList.DataSource = GetSortDT(dt);
            repReimAppList.DataBind();
        }
    }

    private void repReimAppListBind()
    {
        repReimAppList.DataBind();
    }


    #region 获取所有选中checkBoxID
    /// <summary>
    /// 获取选中checkBoxID
    /// </summary>
    /// <param name="rep"></param>
    /// <param name="ChkBoxID"></param>
    /// <returns></returns>
    public string GetDelIDList(Repeater rep, string ChkBoxID)
    {
        string idList = string.Empty;
        foreach (RepeaterItem item in rep.Items)
        {
            CheckBox chkItem = (CheckBox)item.FindControl(ChkBoxID);
            if (chkItem.Checked)
            {
                //被勾选
                if (idList.Length <= 0)
                {
                    idList = chkItem.ToolTip;
                }
                else
                {
                    idList += "," + chkItem.ToolTip;
                }
            }
        }
        return idList;

    }
    #endregion

    protected void btnApp_Click(object sender, EventArgs e)
    {

        string idStrs = GetDelIDList(repReimAppList, "chkArid");
        if (BGApplyReimburManager.UpdApplicationStatus("审核通过", idStrs))
        {
            //int year = Utils.IntSafeConvert(ddlyear.SelectedValue);
            repReimAppListBind();
            //BGApplyReimburDataBind(depID,year);




        }
        else
        {
            
        }
    }

    protected void btnInq_Click(object sender, EventArgs e)
    {
        string yearmonth = ddlyear.Text.Trim() + "-" + ddlmonth.Text.Trim();
        depID = Utils.IntSafeConvert(ddlDep.SelectedValue);
        BGApplyReimburDataBind(depID, yearmonth);

    }


    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //string idStrs = GetDelIDList(repReimAppList, "chkArid");
        //if (BGApplyReimburManager.UpdApplication("退回",txtReason.Text,idStrs))
        //{
          
        //    repReimAppListBind();
           
        //}
        //else
        //{

        //}

    }
    protected void repReimAppList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string arid = e.CommandArgument.ToString();

        if (e.CommandName == "lbtnTJ")
        {
            //审批
            Response.Redirect("ApprovalList.aspx?arid=" + arid, true);
        }
    }
}
