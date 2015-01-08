using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using Ext.Net;
using DataView = System.Data.DataView;

public partial class BudgetPage_mainPages_SelMonPayPlan : BudgetBasePage
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            DepDataBind();
            MonthDataBind();
            getpici();
            cmbmonth.SelectedItem.Text = DateTime.Now.Month.ToString();
        }
    }
    private void getpici()
    {
        cmbpici.Items.Add(new Ext.Net.ListItem("全部", "0"));
        for (int i = 0; i < 10; i++)
        {
            cmbpici.Items.Add(new Ext.Net.ListItem((i+1).ToString(), (i+1).ToString()));
        }
        
    }
    private void MonthDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Year");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add("");
            dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        }
        cmbyearstore.DataSource = dt1;
        cmbyearstore.DataBind(); 
    }

    private void DepDataBind()
    {
        DataTable dt = new DataTable(); //BGDepartmentManager.GetDepByfadepid(depid);
        if (DepID == AreaDepID)
        {
            dt = BGDepartmentManager.GetDepByfadepid(DepID);
        }
        else
        {
            dt = BGDepartmentManager.GetDepByDepid(DepID);
        }
        cmbdeptstore.DataSource = dt;
        cmbdeptstore.DataBind();
        cmbdept.SelectedItem.Index = 0;
    }
    private void AuditStoreBind()
    {
        int year= Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month=Convert.ToInt32(cmbmonth.SelectedItem.Value);
        DataTable dt = BG_SelMonPayPlanLogic.GetMonPayPlan(DepID, year, month,common.IntSafeConvert(cmbpici.SelectedItem.Text));
        DataView dvView = dt.DefaultView;
        dvView.RowFilter = "MPFunding >0";
        dt = dvView.ToTable(true);
        AuditStore.DataSource =Getewdt(dt);
        AuditStore.DataBind();
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    }

    private DataTable Getewdt(DataTable dt)
    {
        decimal mon = 0;
        decimal p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0,p6 = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["MPFunding"] = ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString()) * 10000;
            if (dt.Rows[i]["MASta"].ToString() == "未提交")
            {
                p1 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
                dt.Rows[i]["MASta"] = "财务室待审核";
            }
            if (dt.Rows[i]["MASta"].ToString() == "提交")
            {
                p2 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
                dt.Rows[i]["MASta"] = "局领导待审核";
            }
            if (dt.Rows[i]["MASta"].ToString() == "审核通过")
            {
                p3 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
            }
            if (dt.Rows[i]["MASta"].ToString() == "退回")
            {
                p4 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
            }
            if (dt.Rows[i]["MASta"].ToString() == "审核不通过")
            {
                p5 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
            }
            if (dt.Rows[i]["MASta"].ToString() == "")
            {
                p6 += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
                dt.Rows[i]["MASta"] = "未提交";
            }
            mon += ParToDecimal.ParToDel(dt.Rows[i]["MPFunding"].ToString());
        }
        if (p1>0)
        {
            DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "财务室待审核总金额";
            dr1["MPFunding"] = p1;
            dt.Rows.Add(dr1);  
        }
        if (p2 > 0)
        {
            DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "局领导待审核总金额";
            dr1["MPFunding"] = p2;
            dt.Rows.Add(dr1);  
        }
        if (p3 > 0)
        {
            DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "审核通过总金额";
            dr1["MPFunding"] = p3;
            dt.Rows.Add(dr1);  
        }
        if (p4 > 0)
        {
            DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "退回总金额";
            dr1["MPFunding"] = p4;
            dt.Rows.Add(dr1);  
        }
        if (p5 > 0)
        {
            DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "审核不通过总金额";
            dr1["MPFunding"] = p5;
            dt.Rows.Add(dr1);   
        }
        if (p6>0)
        {
             DataRow dr1 = dt.NewRow();
            dr1["DepName"] = "未提交总金额";
            dr1["MPFunding"] = p6;
            dt.Rows.Add(dr1);  
        }
        if (mon>0)
        {
            DataRow dr = dt.NewRow();
            dr["DepName"] = "总计";
            dr["MPFunding"] = mon;
            dt.Rows.Add(dr);   
        }
       
        return dt;
    } 

    protected void submit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    { 
        AuditStoreBind();
    }
}

////protected void btnSearch_Click(object sender, EventArgs e)
//{

//    repBudConDataBind(common.IntSafeConvert(ddlMon.SelectedValue));
//}

//private void repBudConDataBind(int mAMonth)
//{
//    DataTable dt = VMonPayPlanIncomeManager.GetvMonPayPlanIncomeByMAMonth(mAMonth);
//    //if (dt.Rows.Count > 0)
//    //{
//        repBudCon.DataSource = dt;
//        repBudCon.DataBind();
//    //}
//}



//protected void repBudCon_ItemCommand(object source, RepeaterCommandEventArgs e)
//{
//    string caid = e.CommandArgument.ToString();
//    if (e.CommandName == "UpdBI")
//    {
//        Response.Redirect("AlterMonPayPlan.aspx?caid=" + caid, true);
//    }

//}