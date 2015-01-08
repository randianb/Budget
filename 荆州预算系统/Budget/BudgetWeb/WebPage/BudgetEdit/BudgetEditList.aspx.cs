using System;
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

public partial class WebPage_BudgetEdit_BudgetEditList : BudgetBasePage
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
    //private void ddlDepBind()
    //{
    //    DataTable depTable = null;
    //    if (DepID == 1083)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
    //    {
    //        depTable = BGDepartmentManager.GetDepByfadepid(DepID);
    //    }
    //    else
    //    {
    //        depTable = BGDepartmentManager.GetDepByDepid(DepID);
    //    }
    //    for (int i = 0; i < depTable.Rows.Count; i++)
    //    {
    //        cbDepment.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
    //    }  
    //    cbDepment.DataBind(); 
    //    if (DepID == 1083)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
    //    {
    //        string value="0";
    //        cbDepment.Items.Insert(0, new Ext.Net.ListItem("全局", value));
    //        cbDepment.SelectedItems.Count();
    //    } 

    //    if (!string.IsNullOrEmpty(Request.QueryString["depid"]))
    //    {
    //        cbDepment.SelectedItem.Value = Request.QueryString["depid"];
    //    }

    //}

    public void ddlDepBind()
    {
        System.Data.DataTable depTable = null;
        List<object> data = new List<object>();
        if (DepID == AreaDepID)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            depTable = BudgetWeb.BLL.BGDepartmentManager.GetDepByfadepid(DepID);
        }
        else
        {
            depTable = BudgetWeb.BLL.BGDepartmentManager.GetDepByDepid(DepID);
        }
        for (int i = 0; i < depTable.Rows.Count; i++)
        {
            string id = depTable.Rows[i]["depID"].ToString();
            string name = depTable.Rows[i]["depName"].ToString();
            data.Add(new { depid = id, depname = name });
        }
        this.DepStore.DataSource = data;
        this.DepStore.DataBind();
        if (DepID == AreaDepID)
        {
            this.cbDepment.Items.Insert(0, new Ext.Net.ListItem("全局", "0"));
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
        DataTable dt = new DataTable();
      　if (UserLimStr == "录入员")
      　{
      　    depId = DepID;
      　}
      　else
        {
           depId = common.IntSafeConvert(cbDepment.SelectedItem.Value); 
      　}
       int year= common.IntSafeConvert(cmbyear.SelectedItem.Value); 
        dt = BGBudItemsManager.GetBudItemsListByDepid(depId,year);
        stBudget.DataSource = dt;
        stBudget.DataBind();
        return dt;
    }


    //添加
    protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        if (depId > 0)
        {
            Response.Redirect("BudgetEditAddPage.aspx?depid=" + depId, true);
        }
        else
        {
            lbDes.Text = "*请选择需要添加预算的部门！";
        }
    }
    [DirectMethod]
    public void Subfield_Handler(int budId)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        Response.Redirect("BugHisAddPage.aspx?budid=" + budId + "&depid=" + depId, true);
    }
    //提交
    [DirectMethod]
    public void SubMit_Handler(int budId)
    {
        if (BGBudItemsManager.UpdBudSta(budId, "提交"))
        {
            Bind();
            BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(budId);
            BG_BudItemHis hisbi = new BG_BudItemHis();
            hisbi.BudID = budId;
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
            hisbi.BIYear = bi.BIYear;
            BG_BudItemHisManager.AddBG_BudItemHis(hisbi);
        }
    }

    //修改
    [DirectMethod]
    public void Modify_Handler(int budId)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        Response.Redirect("BudgetEditAlter.aspx?budid=" + budId + "&depid=" + depId, true);
    }

    //删除
    [DirectMethod]
    public void Delete_Handler(int budId)
    {
        if (BGBudItemsManager.DelBud(budId))
        {
            Bind();
        }
    }

    //附件
    [DirectMethod]
    public void ReimAppendix_Handler(int budId)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        Response.Redirect("UplodeAttach.aspx?budid=" + budId + "&depid=" + depId, true);
    }

    //固定资产
    [DirectMethod]
    public void FixAssetPurchase_Handler(int budId)
    {
        depId = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        Response.Redirect("FixAssetPurchase.aspx?budid=" + budId + "&depid=" + depId, true);
    }
    protected void HisBug_DirectClick(object sender, DirectEventArgs e)
    {
        WinHisBug.Show();
        HisBugBind();
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void HisBugBind()
    {
        int depid = common.IntSafeConvert(cbDepment.SelectedItem.Value);
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value);
        DataTable dt = BGBudItemsLibrariesManager.GetExamineBG_BudItemsLibrariesByDept(depid,year);
        StoreHisBug.DataSource = dt;
        StoreHisBug.DataBind();
    }
    //private DataTable GetDeptname(DataTable dt)
    //{
    //    if (dt.Rows.Count<=0)
    //    {
    //        return dt;
    //    }
    //    dt.Columns.Add("DepName");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        dt.Rows[i]["DepName"] = BGDepartmentManager.GetDepNameBydepid(common.IntSafeConvert(dt.Rows[i]["DepID"]));
    //    }
    //    return dt;
    //}
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