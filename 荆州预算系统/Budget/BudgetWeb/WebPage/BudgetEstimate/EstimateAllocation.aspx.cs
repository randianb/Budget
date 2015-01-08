using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using Common;

public partial class WebPage_BudgetControl_EstimateAllocation : BudgetBasePage
{
    private int depID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        depID = DepID;
        if (!X.IsAjaxRequest && !IsPostBack)
        {
            GetYear();
            DtDataBind();
        }
    }

    private void GetYear()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int a = Convert.ToInt32(dt.Rows.Count) - 1;
                HidYear.Value = dt.Rows[a]["DefaultYear"].ToString();
            }
        }
        Label6.Text = HidYear.Value.ToString();

    } 
  
    private void cmbData()
    {
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome(); 
        cmbName.DataSource = dt;
        cmbName.DataBind();

    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void DtDataBind()
    {
        decimal txt = 0;
        int year = Convert.ToInt32(HidYear.Value);

        //DataTable dt1 = BG_BudItemsLogic.GetPayOne(year);
        //if (dt1.Rows.Count > 0)
        //{
        //    txt += Convert.ToDecimal(dt1.Rows[0]["POTitol"]);
        //}
        //DataTable dt2 = BG_BudItemsLogic.GetPayTwo(year);
        //if (dt1.Rows.Count > 0)
        //{
        //    txt += Convert.ToDecimal(dt2.Rows[0]["PTTitol"]);
        //}
        //DataTable dt3 = BG_BudItemsLogic.GetPubPay(year);
        //if (dt1.Rows.Count > 0)
        //{
        //    txt += Convert.ToDecimal(dt3.Rows[0]["PBIDTitol"]);
        //}
        //DataTable dt4 = BG_BudItemsLogic.GetProPay(year);
        //txt += Convert.ToDecimal(dt4.Rows[0]["ProPA0M"]);
        //if (dt4.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt4.Rows.Count; i++)
        //    {
        //        txt += Convert.ToDecimal(dt4.Rows[i]["ProPA0M"]);
        //    }
        //}
        //DataTable dt5 = BG_BudItemsLogic.GetBudgetAllocation(year);
        //if (dt5.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt5.Rows.Count; i++)
        //    {
        //        txt -= Convert.ToDecimal(dt5.Rows[i]["BAAMon"]);
        //    }
        //}
        DataTable dt1 = BG_PreviewDataLogic.GetPersonPart();
        DataTable dt2 = BG_PreviewDataLogic.GetPublicPart();
        DataTable dt3 = BG_PreviewDataLogic.GetCapitalPart();
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                txt += ParToDecimal.ParToDel(dt1.Rows[i]["PDBaseData"].ToString()) + ParToDecimal.ParToDel(dt1.Rows[i]["PDProjectData"].ToString());
            }
        }
        if (dt2.Rows.Count > 0)
        {
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                txt += ParToDecimal.ParToDel(dt2.Rows[i]["PDBaseData"].ToString()) + ParToDecimal.ParToDel(dt2.Rows[i]["PDProjectData"].ToString());
            }
        }
        if (dt3.Rows.Count > 0)
        {
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                txt += ParToDecimal.ParToDel(dt3.Rows[i]["PDBaseData"].ToString());
            }
        }
        tatal.Value = txt;
        Label4.Text = txt.ToString();
        DataTable dt = BG_DepartmentLogic.GetAllBG_EstimateDepartmentMon(year, depID);
        dt.Columns.Add("DepNum");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["DepNum"] = (i + 1).ToString();
            }
            this.Store1.DataSource = dt;
            this.Store1.DataBind();
        }
        else
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "提示",
                Message = "本年度还没有添加预算，请先添加预算。",
                Width = 300,
                Buttons = Ext.Net.MessageBox.Button.OK,
                //Multiline = true,
                //AnimEl = this.Button3.ClientID,
                //Fn = new JFunction { Fn = "showResultText" }
            });

        }


    }

    private void AddDataBind()
    {
        int year = Convert.ToInt32(HidYear.Value);
        int depid = Convert.ToInt32(HidDepid.Value);
        DataTable dt = BG_BudItemsLogic.GetBEA(depid, year);
        dt.Columns.Add("Name");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = (int)dt.Rows[i]["PIID"];
                BG_PayIncome pi = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid);
                dt.Rows[i]["Name"] = pi.PIEcoSubName;
            }
        }
        Store2.DataSource = dt;
        Store2.DataBind();
    }

    [DirectMethod]
    public void DivideData(string depid)
    {
        HidDepid.Value = depid;

        AddDataBind();

        WinAdd.Show();

    }
    protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
    {
        cmbData();
        Window1.Show();
    }
    protected void btnSure_DirectClick(object sender, DirectEventArgs e)
    {
        string name = ComboBox1.SelectedItem.Value;
        string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
        int piid = common.IntSafeConvert(bgpi.Split(',')[0]);
        int year = Convert.ToInt32(HidYear.Value);
        int depid = Convert.ToInt32(HidDepid.Value);
        BG_EstimatesAllocation ba = new BG_EstimatesAllocation();
        ba.DepID = depid;
        ba.PIID = piid;
        ba.BEAYear = year;
        ba.BEAMon = ParToDecimal.ParToDel(tfMon.Text);
        if (Convert.ToDecimal(tatal.Value) - ba.BEAMon > 0)
        {
            if (BGBudItemsService.Isba(year, piid, depid) > 0)
            {
                ba.BEAID = BGBudItemsService.IsBEAba(year, piid, depid);
                BG_EstimatesAllocationManager.ModifyBG_EstimatesAllocation(ba);
            }
            else
            {
                BG_EstimatesAllocationManager.AddBG_EstimatesAllocation(ba);
            }
            Window1.Hidden = true;
            AddDataBind();
            DtDataBind();
        }
        else
        {
            X.Msg.Alert("提示", "预算金额不足，无法分配！").Show();
        }
    }
}