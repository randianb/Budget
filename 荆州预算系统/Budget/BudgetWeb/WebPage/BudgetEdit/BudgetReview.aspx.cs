﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;
using ListItem = Ext.Net.ListItem;

public partial class WebPage_BudgetEdit_BudgetReview : BudgetBasePage
{
    int depId = 0;//用来选中
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepBind();
            Bind();

        }
    }

    //绑定部门
    private void ddlDepBind()
    {
        DataTable depTable = null;
        if (DepID == AreaDepID || UserLimStr=="审核员")//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            depTable = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        }
        else
        {
            depTable = BGDepartmentManager.GetDepByDepid(DepID);
        }
        for (int i = 0; i < depTable.Rows.Count; i++)
        {
            cbDepment.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
        }

        if (DepID == AreaDepID || UserLimStr=="审核员")//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            cbDepment.Items.Insert(0, new Ext.Net.ListItem("全局", "0"));
            //cbDepment.SelectedItem.Index = 0;
        }


        if (!string.IsNullOrEmpty(Request.QueryString["depid"]))
        {
            cbDepment.SelectedItem.Value = Request.QueryString["depid"];
        }

    }

    //查询
    protected void btnInquiry_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        DataTable dt = Bind();
        if (dt.Rows.Count == 0)
        {
            X.Msg.Alert("提示", "所查询部门没有数据，请添加数据").Show();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private DataTable Bind()
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value);
        DataTable dt = BGBudItemsManager.GetApplyReimburByDepID(depId,year, "已上报");
        stBudget.DataSource = getnew(dt);
        stBudget.DataBind();
        return dt;
    }
    private DataTable getnew(DataTable dt)
    {
        dt.Columns.Add("DepName");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["DepName"] = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt.Rows[i]["DepID"])).DepName;
        }
        return dt;
    }
    //审核通过
    [DirectMethod]
    public void Audit_Handler(int budId)
    {
        if (BGBudItemsManager.UpdBudSta(budId, "审核通过"))
        { 
            Bind();
            BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(budId);
            BG_BudItemHis hisbi = new BG_BudItemHis();
            hisbi.BudID = budId ;
            hisbi.BIAppConMon = bi.BIAppConMon;
            hisbi.BIAppReaCon = bi.BIAppReaCon;
            hisbi.BIAttr = bi.BIAttr;
            hisbi.BIBudSta = bi.BIBudSta;
            hisbi.BICause = bi.BICause;
            hisbi.BICharger = bi.BICharger;
            hisbi.BICode = bi.BICode;
            hisbi.BIEndTime = bi.BIEndTime;
            hisbi.BIExpGistExp = bi.BIExpGistExp;
            hisbi.BIFinAllo = bi.BIFinAllo;
            hisbi.BIFunSub = bi.BIFunSub;
            hisbi.BILastYearCarry = bi.BILastYearCarry;
            hisbi.BILongGoal = bi.BILongGoal;
            hisbi.BIMon = bi.BIMon;
            hisbi.BIMonSou = bi.BIMonSou;
            hisbi.BIOthExpProb = bi.BIOthExpProb;
            hisbi.BIOthFun = bi.BIOthFun;
            hisbi.BIPlanHz = bi.BIPlanHz;
            hisbi.BIProType = bi.BIProType;
            hisbi.BIStaTime = bi.BIStaTime;
            hisbi.BIYearGoal = bi.BIYearGoal;
            hisbi.PPID = bi.PPID;
            hisbi.BudSta = bi.BudSta;
            hisbi.PIID = bi.PIID;
            hisbi.BIProName = bi.BIProName;
            hisbi.BIReportTime = bi.BIReportTime;
            hisbi.BIConNum = bi.BIConNum;
            hisbi.BIProDescrip = bi.BIProDescrip;
            hisbi.DepID = bi.DepID;
            hisbi.BIProCategory = bi.BIProCategory;
            BG_BudItemHisManager.AddBG_BudItemHis(hisbi);
        }
    }

    //批复
    [DirectMethod]
    public void Reply_Handler(int budId)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        Response.Redirect("BudgetReviewDetails.aspx?budid=" + budId + "&depid=" + depId, true);
    }

    protected void YearBind(object sender, EventArgs e)
    {
        int year = common.IntSafeConvert(CurrentYear);
        string str = "";
        for (int i = year; i >2000; i--)
        {
            str = i.ToString();
            cmbyear.Items.Add(new ListItem(str, str));
        }
    }
}