using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_OptAnaly_YearOutlyAnaly : System.Web.UI.Page
{

    ///<summary>
    ///已选择的收入经济科目选择项List
    ///</summary>
    List<string> EICodingList = new List<string>();
    ///<summary>
    ///已选择的支出经济科目选择项List
    ///</summary>
    List<string> PICodingList = new List<string>();
    ///<summary>
    ///已选择的自选控制项选择项List
    ///</summary>
    List<string> OCNameList = new List<string>();
    private string hidStr = string.Empty;
    private string hid1Str = string.Empty;
    private string hid2Str = string.Empty;
    private string hid3Str = string.Empty;
    private string hid4Str = string.Empty;
    private string hid5Str = string.Empty;
    private string hid6Str = string.Empty;
    string moneyType = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblClick.Style.Add("color", "red");
        GridPanel1.ColumnModel.Columns[0].Visible = true;
        GridPanel1.ColumnModel.Columns[1].Visible = false;
        GridPanel1.ColumnModel.Columns[2].Visible = false;
        GridPanel1.ColumnModel.Columns[3].Visible = true;
        GridPanel1.ColumnModel.Columns[6].Visible = false;
        GridPanel1.ColumnModel.Columns[7].Visible = false;
        GridPanel1.ColumnModel.Columns[8].Visible = false;
        GridPanel1.ColumnModel.Columns[9].Visible = false;
        if (!X.IsAjaxRequest)
        {
            btnExpand.Hide();
            AnalyDataBind();
        }
        if (!IsPostBack)
        {
            cboTypeBind();
        }
        if (Request.QueryString["year"] != null && Request.QueryString["hid2"] != null && Request.QueryString["type"] != null)
        {
            string yearStr = Request.QueryString["year"].ToString();
            cboStartYear.SelectedItem.Value = yearStr;
            hid1Str = Request.QueryString["hid1"];
            hid2Str = Request.QueryString["hid2"];
            hid3Str = Request.QueryString["hid3"];
            hid2Str = hid2Str.TrimEnd(',');
            hid2Str = hid2Str.TrimStart(',');
            moneyType = Request.QueryString["type"];
            cboType.SelectedItem.Value = moneyType;
            btnExpand.Show();
            FieldSet1.Hide();
            ShowDtBind(yearStr);
            ShowFiledCoum(hid3Str);
        }
    }
    private void cboTypeBind()
    {
        cboType.Items.Add(new Ext.Net.ListItem("所有", "1"));
        cboType.Items.Add(new Ext.Net.ListItem("区级", "2"));
        cboType.Items.Add(new Ext.Net.ListItem("零户", "3"));
        cboType.SelectedItem.Index = 0;
        try
        {
            cboType.SelectedItem.Value = Session["type"].ToString();
        }
        catch
        {

            Session["type"] = "1";
        }
    }
    private void ShowFiledCoum(string str3)
    {
        if (str3.Length > 0)
        {
            if (str3.Contains("1"))
            {
                GridPanel1.ColumnModel.Columns[1].Visible = true;
                GridPanel1.ColumnModel.Columns[7].Visible = true;
            }
            if (str3.Contains("2"))
            {
                GridPanel1.ColumnModel.Columns[2].Visible = true;
                GridPanel1.ColumnModel.Columns[8].Visible = true;
            }
            if (str3.Contains("3"))
            {
                GridPanel1.ColumnModel.Columns[6].Visible = true;
            }
            if (str3.Contains("4"))
            {
                GridPanel1.ColumnModel.Columns[9].Visible = true;
            }
        }
    }


    #region 加载自选控制项数据
    ///获取自选控制项数据
    ///</summary>
    ///<returns>DataTable</returns>
    private DataTable GetOptionControlData()
    {
        DataTable dtOc = new DataTable();
        dtOc.Columns.Add("OCName");
        dtOc.Columns.Add("OCVal");
        DataRow dr1 = dtOc.NewRow();
        dr1["OCName"] = "预算数";
        dr1["OCVal"] = "预算数";
        dtOc.Rows.Add(dr1);
        DataRow dr2 = dtOc.NewRow();
        dr2["OCName"] = "决算数";
        dr2["OCVal"] = "决算数";
        dtOc.Rows.Add(dr2);
        DataRow dr3 = dtOc.NewRow();
        dr3["OCName"] = "核算本期数";
        dr3["OCVal"] = "核算本期数";
        dtOc.Rows.Add(dr3);
        DataRow dr4 = dtOc.NewRow();
        dr4["OCName"] = "核算同期数";
        dr4["OCVal"] = "核算同期数";
        dtOc.Rows.Add(dr4);
        DataRow dr5 = dtOc.NewRow();
        dr5["OCName"] = "与预算比";
        dr5["OCVal"] = "与预算比";
        dtOc.Rows.Add(dr5);
        DataRow dr6 = dtOc.NewRow();
        dr6["OCName"] = "与决算比";
        dr6["OCVal"] = "与决算比";
        dtOc.Rows.Add(dr6);
        DataRow dr7 = dtOc.NewRow();
        dr7["OCName"] = "人均系数";
        dr7["OCVal"] = "人均系数";
        dtOc.Rows.Add(dr7);
        return dtOc;
    }
    #endregion


    #region 绑定收/支经济科目选择项
    private void AnalyDataBind()
    {
        DataTable dt3 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010101");
        DataTable dt5 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010102");
        DataTable dt6 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010201");
        DataTable dt7 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010202");
        int year = common.IntSafeConvert(cboStartYear.SelectedItem.Value);
        //if (year < 2014)
        //{
        //    dt3 = FA_PayIncomeManager.GetAllFA_PayIncome();           
        //}
        //else
        //{
        //dt3 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        //}
        DataTable dt4 = new DataTable();
        dt4.Columns.Add("PIEcoSubName");
        dt4.Columns.Add("PIID");
        DataRow dr1 = dt4.NewRow();
        dr1["PIEcoSubName"] = "与预算比";
        dr1["PIID"] = 1;
        dt4.Rows.Add(dr1);
        DataRow dr2 = dt4.NewRow();
        dr2["PIEcoSubName"] = "与决算比";
        dr2["PIID"] = 2;
        dt4.Rows.Add(dr2);
        DataRow dr3 = dt4.NewRow();
        dr3["PIEcoSubName"] = "核算同期数";
        dr3["PIID"] = 3;
        dt4.Rows.Add(dr3);
        DataRow dr4 = dt4.NewRow();
        dr4["PIEcoSubName"] = "人均系数";
        dr4["PIID"] = 4;
        dt4.Rows.Add(dr4);

        Store Store2 = this.GridPanel2.GetStore();
        Store2.DataSource = dt5;
        Store2.DataBind();

        Store Store3 = this.GridPanel3.GetStore();
        Store3.DataSource = dt6;
        Store3.DataBind();

        Store Store6 = this.GridPanel6.GetStore();
        Store6.DataSource = dt7;
        Store6.DataBind();

        Store Store4 = this.GridPanel4.GetStore();
        Store4.DataSource = dt3;
        Store4.DataBind();

        Store Store5 = this.GridPanel5.GetStore();
        Store5.DataSource = dt4;
        Store5.DataBind();
    }
    #endregion

    #region 分配收/支经济科目列表
    ///<summary>
    ///分配收入经济科目列表
    ///</summary>
    ///<param name="dtAll"></param>
    ///<param name="startid"></param>
    ///<param name="endid"></param>
    ///<returns>DataTable</returns>
    private DataTable AllotEIDt(DataTable dtAll, string startid, string endid)
    {
        DataTable dtSon = dtAll.Clone();
        if (dtAll != null && dtAll.Rows.Count > 0)
        {
            DataRow[] drArr = dtAll.Select("EIID >" + startid + " and EIID <" + endid);
            if (drArr.Length > 0)
            {
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtSon.ImportRow(drArr[i]);
                }
            }
        }
        return dtSon;
    }

    ///<summary>
    ///分配支出经济科目列表
    ///</summary>
    ///<param name="dtAll"></param>
    ///<param name="startid"></param>
    ///<param name="endid"></param>
    ///<returns>DataTable</returns>
    private DataTable AllotPIDt(DataTable dtAll, string startid, string endid)
    {
        DataTable dtSon = dtAll.Clone();
        if (dtAll != null && dtAll.Rows.Count > 0)
        {
            DataRow[] drArr = dtAll.Select("PIID >" + startid + " and PIID <" + endid);
            if (drArr.Length > 0)
            {
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtSon.ImportRow(drArr[i]);
                }
            }
        }
        return dtSon;
    }
    #endregion

    #region 界面显示数据与后台查询数据的中间转换结构
    /// <summary>
    /// 界面显示数据与后台查询数据的中间转换结构
    /// </summary>
    /// <returns>DataTable</returns>
    private DataTable GetMiddleChangeDt()
    {
        DataTable dt = new DataTable();
        //科目编码
        dt.Columns.Add("KMCodeing");
        //科目名称
        dt.Columns.Add("KMName");
        //预算金额
        dt.Columns.Add("YSMon");
        //决算金额
        dt.Columns.Add("JSMon");
        // 核算本期数
        dt.Columns.Add("HSBQMon");
        // 核算本期数(区级)
        dt.Columns.Add("HSBQMonQJ");
        // 核算本期数(零户)
        dt.Columns.Add("HSBQMonLH");
        // 核算同期数
        dt.Columns.Add("HSTQMon");
        // 与预算比
        dt.Columns.Add("YYSBit");
        // 与决算比
        dt.Columns.Add("YJSBit");
        //人均系数
        dt.Columns.Add("RJXS");
        return dt;
    }
    #endregion

    // 年度收支情况
    private void ShowDtBind(string yearStr)
    {
        DataTable dt = GetMiddleChangeDt();
        int year = common.IntSafeConvert(cboStartYear.SelectedItem.Value);
        int lyear = year - 1;
        //DataTable dt1 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTimePIID(year, hid2Str);
        //DataTable dt2 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTimePIID(lyear, hid2Str);
        DataTable dt1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimePIID(year, hid2Str);
        //DataTable dt2 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimePIID(lyear, hid2Str);
        //DataTable dt1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimesPIID(year, lyear, hid2Str);
        FA_SysSetting fa4 = FA_SysSettingManager.GetSysSettingByYear(year);
        decimal YSMonTotal = 0;
        decimal JSMonTotal = 0;
        decimal HSBQMonTotal = 0;
        decimal HSBQMonQJTotal = 0;
        decimal HSBQMonLHTotal = 0;
        decimal HSTQMonTotal = 0;
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            if (moneyType == "1")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int piid = common.IntSafeConvert(dt1.Rows[i]["PIID"]);
                    FA_XPayIncome fa1 = FA_XPayIncomeManager.GetFA_XPayIncomeByPIID(piid);
                    FA_XIncomeBudAllocat fa2 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByIncome(piid, year);
                    FA_XIncomeAccAllocat fa3 = FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatByIncome(piid, year);
                    DataTable dt2 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByYearPIID(year, piid);
                    DataRow dr = dt.NewRow();
                    if (fa1 != null)
                    {
                        dr["KMName"] = fa1.PIEcoSubName;
                    }
                    if (fa2 != null && fa2.IBAMon != 0)
                    {
                        dr["YSMon"] = (fa2.IBAMon).ToString("f2");
                        YSMonTotal += fa2.IBAMon;
                    }
                    if (fa3 != null && fa3.IAAMon != 0)
                    {
                        dr["JSMon"] = (fa3.IAAMon).ToString("f2");
                        JSMonTotal += fa3.IAAMon;
                    }
                    if (dt1 != null && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()) && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()))
                    {

                        dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");

                        HSBQMonTotal += ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"]);

                    }
                    if (dt1 != null && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()) && ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                    {
                        dr["HSBQMonQJ"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                        HSBQMonQJTotal += ToDec(dt1.Rows[i]["ODCkAreaMon"]);
                    }
                    if (dt1 != null && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()) && ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                    {
                        dr["HSBQMonLH"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                        HSBQMonLHTotal += ToDec(dt1.Rows[i]["ODCkZeroMon"]);
                    }
                    if (dt2 != null && !string.IsNullOrEmpty(dt2.Rows[0]["ODCkAreaMon"].ToString()) && !string.IsNullOrEmpty(dt2.Rows[0]["ODCkZeroMon"].ToString()))
                    {

                        dr["HSTQMon"] = (ToDec(dt2.Rows[0]["ODCkAreaMon"]) + ToDec(dt2.Rows[0]["ODCkZeroMon"])).ToString("f2");
                        HSTQMonTotal += ToDec(dt2.Rows[0]["ODCkAreaMon"]) + ToDec(dt2.Rows[0]["ODCkZeroMon"]);
                    }
                    if (fa2 != null && fa2.IBAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YYSBit"] = ((ToDec(dr["HSBQMon"]) / (fa2.IBAMon * 10000)) * 100).ToString("f2") + "%";
                    }
                    if (fa3 != null && fa3.IAAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YJSBit"] = ((ToDec(dr["HSBQMon"]) / fa3.IAAMon) * 100).ToString("f2") + "%";
                    }
                    if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["RJXS"] = (ToDec(dr["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                    }
                    dt.Rows.Add(dr);
                    //}
                }
                DataRow dr1 = dt.NewRow();
                dr1["KMName"] = "本年累计";
                if (YSMonTotal != 0)
                {
                    dr1["YSMon"] = (YSMonTotal).ToString("f2");
                }
                if (JSMonTotal != 0)
                {
                    dr1["JSMon"] = (JSMonTotal).ToString("f2");
                }
                if (HSBQMonTotal != 0)
                {
                    dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                }
                if (HSBQMonQJTotal != 0)
                {
                    dr1["HSBQMonQJ"] = (HSBQMonQJTotal).ToString("f2");
                }
                if (HSBQMonLHTotal != 0)
                {
                    dr1["HSBQMonLH"] = (HSBQMonLHTotal).ToString("f2");
                }
                if (HSTQMonTotal != 0)
                {
                    dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                }
                if (YSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YYSBit"] = (ToDec(dr1["HSBQMon"]) / (YSMonTotal * 10000)).ToString("f2");
                }
                if (JSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YJSBit"] = ((ToDec(dr1["HSBQMon"]) / JSMonTotal) * 100).ToString("f2") + "%";
                }
                if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["RJXS"] = (ToDec(dr1["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                }
                dt.Rows.Add(dr1);

            }
            else if (moneyType == "3")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int piid = common.IntSafeConvert(dt1.Rows[i]["PIID"]);
                    FA_XPayIncome fa1 = FA_XPayIncomeManager.GetFA_XPayIncomeByPIID(piid);
                    FA_XIncomeBudAllocat fa2 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByIncome(piid, year);
                    FA_XIncomeAccAllocat fa3 = FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatByIncome(piid, year);
                    DataTable dt2 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByYearPIID(year, piid);
                    DataRow dr = dt.NewRow();
                    if (fa1 != null)
                    {
                        dr["KMName"] = fa1.PIEcoSubName;
                    }
                    if (fa2 != null && fa2.IBAMon != 0)
                    {
                        dr["YSMon"] = (fa2.IBAMon).ToString("f2");
                        YSMonTotal += fa2.IBAMon;
                    }
                    if (fa3 != null && fa3.IAAMon != 0)
                    {
                        dr["JSMon"] = (fa3.IAAMon).ToString("f2");
                        JSMonTotal += fa3.IAAMon;
                    }
                    if (dt1 != null && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkZeroMon"].ToString()) && ToDec(dt1.Rows[i]["ODCkZeroMon"]) > 0)
                    {
                        dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                        HSBQMonTotal += ToDec(dt1.Rows[i]["ODCkZeroMon"]);
                    }
                    if (dt2 != null && dt2.Rows.Count > 0 && ToDec(dt2.Rows[0]["ODCkZeroMon"]) > 0)
                    {
                        dr["HSTQMon"] = (ToDec(dt2.Rows[0]["ODCkZeroMon"])).ToString("f2");
                        HSTQMonTotal += ToDec(dt2.Rows[0]["ODCkZeroMon"]);
                    }
                    if (fa2 != null && fa2.IBAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YYSBit"] = ((ToDec(dr["HSBQMon"]) / (fa2.IBAMon * 10000)) * 100).ToString("f2") + "%";
                    }
                    if (fa3 != null && fa3.IAAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YJSBit"] = ((ToDec(dr["HSBQMon"]) / fa3.IAAMon) * 100).ToString("f2") + "%";
                    }
                    if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["RJXS"] = (ToDec(dr["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                    }
                    dt.Rows.Add(dr);
                }
                DataRow dr1 = dt.NewRow();
                dr1["KMName"] = "本年累计";
                if (YSMonTotal != 0)
                {
                    dr1["YSMon"] = (YSMonTotal).ToString("f2");
                }
                if (JSMonTotal != 0)
                {
                    dr1["JSMon"] = (JSMonTotal).ToString("f2");
                }
                if (HSBQMonTotal != 0)
                {
                    dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                }
                if (HSTQMonTotal != 0)
                {
                    dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                }
                if (YSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YYSBit"] = ((ToDec(dr1["HSBQMon"]) / (YSMonTotal * 10000)) * 100).ToString("f2") + "%";
                }
                if (JSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YJSBit"] = ((ToDec(dr1["HSBQMon"]) / JSMonTotal) * 100).ToString("f2") + "%";
                }
                if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["RJXS"] = (ToDec(dr1["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                }
                dt.Rows.Add(dr1);
            }
            else if (moneyType == "2")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int piid = common.IntSafeConvert(dt1.Rows[i]["PIID"]);
                    FA_XPayIncome fa1 = FA_XPayIncomeManager.GetFA_XPayIncomeByPIID(piid);
                    FA_XIncomeBudAllocat fa2 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByIncome(piid, year);
                    FA_XIncomeAccAllocat fa3 = FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatByIncome(piid, year);
                    DataTable dt2 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByYearPIID(year, piid);
                    DataRow dr = dt.NewRow();
                    if (fa1 != null)
                    {
                        dr["KMName"] = fa1.PIEcoSubName;
                    }
                    if (fa2 != null && fa2.IBAMon != 0)
                    {
                        dr["YSMon"] = (fa2.IBAMon).ToString("f2");
                        YSMonTotal += fa2.IBAMon;
                    }
                    if (fa3 != null && fa3.IAAMon != 0)
                    {
                        dr["JSMon"] = (fa3.IAAMon).ToString("f2");
                        JSMonTotal += fa3.IAAMon;
                    }
                    if (dt1 != null && !string.IsNullOrEmpty(dt1.Rows[0]["ODCkAreaMon"].ToString()) && ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                    {
                        dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                        HSBQMonTotal += ToDec(dt1.Rows[i]["ODCkAreaMon"]);
                    }
                    if (dt2 != null && dt2.Rows.Count > 0 && ToDec(dt2.Rows[0]["ODCkAreaMon"]) != 0)
                    {
                        dr["HSTQMon"] = (ToDec(dt2.Rows[0]["ODCkAreaMon"])).ToString("f2");
                        HSTQMonTotal += ToDec(dt2.Rows[0]["ODCkAreaMon"]);
                    }
                    if (fa2 != null && fa2.IBAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YYSBit"] = ((ToDec(dr["HSBQMon"]) / (fa2.IBAMon * 10000)) * 100).ToString("f2") + "%";
                    }
                    if (fa3 != null && fa3.IAAMon > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["YJSBit"] = ((ToDec(dr["HSBQMon"]) / fa3.IAAMon) * 100).ToString("f2") + "%";
                    }
                    if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr["HSBQMon"]) != 0)
                    {
                        dr["RJXS"] = (ToDec(dr["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                    }
                    dt.Rows.Add(dr);
                }
                DataRow dr1 = dt.NewRow();
                dr1["KMName"] = "本年累计";
                if (YSMonTotal != 0)
                {
                    dr1["YSMon"] = (YSMonTotal).ToString("f2");
                }
                if (JSMonTotal != 0)
                {
                    dr1["JSMon"] = (JSMonTotal).ToString("f2");
                }
                if (HSBQMonTotal != 0)
                {
                    dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                }
                if (HSTQMonTotal != 0)
                {
                    dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                }
                if (YSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YYSBit"] = ((ToDec(dr1["HSBQMon"]) / (YSMonTotal * 10000)) * 100).ToString("f2") + "%";
                }
                if (JSMonTotal > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["YJSBit"] = ((ToDec(dr1["HSBQMon"]) / JSMonTotal) * 100).ToString("f2") + "%";
                }
                if (fa4 != null && fa4.StaffNum > 0 && ToDec(dr1["HSBQMon"]) != 0)
                {
                    dr1["RJXS"] = (ToDec(dr1["HSBQMon"]) / fa4.StaffNum).ToString("f2");
                }
                dt.Rows.Add(dr1);
            }
        }
        this.Store1.DataSource = dt;
        this.Store1.DataBind();
        cboType.SelectedItem.Value = Session["type"].ToString();
    }



    protected void btnSearch_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        string yearStr = cboStartYear.RawValue.ToString();
        string type = cboType.SelectedItem.Value;

        Response.Redirect("YearOutlyAnaly.aspx?year=" + yearStr + "&hid1=" + hid1.Value + "&hid2=" + hid2.Value + "&hid3=" + hid3.Value + "&type=" + type, true);

        cboStartYear.SelectedItem.Value = yearStr;
        btnExpand.Show();
        FieldSet1.Hide();
        ShowDtBind(yearStr);

        GridPanel1.ColumnModel.Columns[2].Visible = false;

        //支出经济科目选择项大于0【有选择项】收入经济科目选择项小于0【无选择项】
        if (EICodingList.Count <= 0 && PICodingList.Count > 0)
        {

        }
        //收入经济科目选择项大于0【有选择项】支出经济科目选择项小于0【无选择项】
        if (PICodingList.Count <= 0 && EICodingList.Count > 0)
        {

        }
        //收入经济科目选择项大于0【有选择项】支出经济科目选择项大于0【有选择项】
        if (PICodingList.Count > 0 && EICodingList.Count > 0)
        {

        }
        //收入经济科目选择项小于0【无选择项】支出经济科目选择项小于0【无选择项】
        if (PICodingList.Count <= 0 && EICodingList.Count <= 0)
        {

        }

    }

    private Decimal ToDec(object obj)
    {
        Decimal decTmp = 0;
        if (obj != null)
        {
            string objStr = obj.ToString();
            if (!string.IsNullOrEmpty(objStr))
            {
                decTmp = ParseUtil.ToDecimal(objStr, decTmp);
            }
        }
        return decTmp;
    }

    [DirectMethod]
    public void GetSelectionData(string allselect1, string allselect2, string allselect3)
    {

        ViewState["hid1"] = allselect1;
        ViewState["hid2"] = allselect2;
        ViewState["hid3"] = allselect3;
        this.Store1.DataSource = GetMiddleChangeDt();
        this.Store1.DataBind();
        Session["EICodingList"] = null;
        Session["PICodingList"] = null;
        Session["OCNameList"] = null;

        string[] codingStrA = allselect1.Split(',');
        string[] codingStrB = allselect2.Split(',');
        string[] codingStrC = allselect3.Split(',');
        for (int i = 0; i < codingStrA.Length; i++)
        {
            string tmpA = codingStrA[i];
            if (!EICodingList.Contains(tmpA) && !string.IsNullOrEmpty(tmpA))
            {
                EICodingList.Add(tmpA);
            }
        }
        Session["EICodingList"] = EICodingList;
        for (int j = 0; j < codingStrB.Length; j++)
        {
            string tmpB = codingStrB[j];
            if (!PICodingList.Contains(tmpB) && !string.IsNullOrEmpty(tmpB))
            {
                PICodingList.Add(tmpB);
            }
        }
        Session["PICodingList"] = PICodingList;
        for (int m = 0; m < codingStrC.Length; m++)
        {
            string tmpC = codingStrC[m];
            if (!OCNameList.Contains(tmpC) && !string.IsNullOrEmpty(tmpC))
            {
                OCNameList.Add(tmpC);
            }
        }
        Session["OCNameList"] = OCNameList;
    }

    protected void btnExpand_DirectClick(object sender, DirectEventArgs e)
    {
        FieldSet1.Show();
        if (cboType.SelectedItem.Value == "3")
        {
            GridPanel3.Hidden = true;
            GridPanel6.Hidden = true;
        }
        if (cboType.SelectedItem.Value == "1")
        {
            GridPanel3.Hidden = false;
            GridPanel6.Hidden = false;
        }
        if (cboType.SelectedItem.Value == "2")
        {
            GridPanel3.Hidden = false;
            GridPanel6.Hidden = false;
        }
    }
    //protected void Button2_DirectClick(object sender, DirectEventArgs e)
    //{
    //    WinSave.Show();
    //}

    [DirectMethod]
    public void GetSelectType(string str)
    {
        Session["type"] = str;
        if (str == "3")
        {
            GridPanel3.Hidden = true;
            GridPanel6.Hidden = true;
        }
        if (str == "1")
        {
            GridPanel3.Hidden = false;
            GridPanel6.Hidden = false;
        }
        if (str == "2")
        {
            GridPanel3.Hidden = false;
            GridPanel6.Hidden = false;
        }
    }
}
