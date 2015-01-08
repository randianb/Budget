using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using Common;

public partial class WebPage_OptAnaly_MonOutlyAnaly : System.Web.UI.Page
{

    /// <summary>
    /// 已选择的收入经济科目选择项List
    /// </summary>
    List<string> EICodingList = new List<string>();
    /// <summary>
    /// 已选择的支出经济科目选择项List
    /// </summary>
    List<string> PICodingList = new List<string>();
    /// <summary>
    /// 已选择的自选控制项选择项List
    /// </summary>
    List<string> OCNameList = new List<string>();


    private string hid1Str = string.Empty;
    private string hid2Str = string.Empty;
    private string hid3Str = string.Empty;
    string moneyType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        lblClick.Style.Add("color", "red");
        if (!X.IsAjaxRequest)
        {
            btnExpand.Hide();
            AnalyDataBind(); 
        }
        if (!IsPostBack)
        {
            cboTypeBind();
        }
        if (Request.QueryString["stime"] != null && Request.QueryString["etime"] != null)
        {
            string stimeStr = Request.QueryString["stime"].ToString();
            string etimeStr = Request.QueryString["etime"].ToString();
            string[] stArr = stimeStr.Split('-');
            string[] etArr = etimeStr.Split('-');
            cboStartYear.SelectedItem.Value = stArr[0];
            cboStartMon.SelectedItem.Value = stArr[1];
            cboEndYear.SelectedItem.Value = etArr[0];
            cboEndMon.SelectedItem.Value = etArr[1];

            hid1Str = Request.QueryString["hid1"];
            hid2Str = Request.QueryString["hid2"];
            hid3Str = Request.QueryString["hid3"];
            hid2Str = hid2Str.TrimEnd(',');
            hid2Str = hid2Str.TrimStart(',');
            moneyType = Request.QueryString["type"];
            btnExpand.Show();
            FieldSet1.Hide();
            ShowDtBind(stimeStr, etimeStr);
            ShowFiledCoum(hid3Str); 
        } 
    }

    private void cboTypeBind()
    {
        cboType.Items.Add(new Ext.Net.ListItem("所有","1"));
        cboType.Items.Add(new Ext.Net.ListItem("区级", "2"));
        cboType.Items.Add(new Ext.Net.ListItem("零户", "3"));
        cboType.SelectedItem.Index=0;
        try
        {
             cboType.SelectedItem.Value =Session["type"].ToString();
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
            if (!str3.Contains("核算本期数"))
            {
                GridPanel1.ColumnModel.Columns[2].Visible = false;
            }
            if (!str3.Contains("核算同期数"))
            {
                GridPanel1.ColumnModel.Columns[3].Visible = false;
            }
            if (!str3.Contains("人均系数"))
            {
                GridPanel1.ColumnModel.Columns[4].Visible = false;
            }
        }
    }

    #region 加载自选控制项数据
    // 获取自选控制项数据
    /// </summary>
    /// <returns>DataTable</returns>
    private DataTable GetOptionControlData()
    {
        DataTable dtOc = new DataTable();
        dtOc.Columns.Add("OCName");
        dtOc.Columns.Add("OCVal");
        DataRow dr3 = dtOc.NewRow();
        dr3["OCName"] = "核算本期数";
        dr3["OCVal"] = "核算本期数";
        dtOc.Rows.Add(dr3);
        DataRow dr4 = dtOc.NewRow();
        dr4["OCName"] = "核算同期数";
        dr4["OCVal"] = "核算同期数";
        dtOc.Rows.Add(dr4);
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
        //DataTable dtEcoInc = BG_EcoIncomeLogic.GetEcoIncomeDt();
        //DataTable dt1 = AllotEIDt(dtEcoInc, "999", "1022");
        //DataTable dt2 = AllotEIDt(dtEcoInc, "1021", "1032");

        // DataTable dtPayInc = BG_PayIncomeLogic.DtDeal();

        //DataTable dt3 = FA_PayIncomeManager.GetAllFA_PayIncome();
        //DataTable dt3 = FA_XPayIncomeManager.GetAllFA_XPayIncome();
        DataTable dt4 = FA_PayIncomeManager.GetPayIncomeByPItype("项目支出");

        DataTable dt3 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010101");
        DataTable dt5 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010102");
        DataTable dt6 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010201");
        DataTable dt7 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubcod("50010202");

        //Store Store2 = this.GridPanel2.GetStore();
        //Store2.DataSource = dt1;
        //Store2.DataBind();

        //Store Store3 = this.GridPanel3.GetStore();
        //Store3.DataSource = dt2;
        //Store3.DataBind();

        Store Store4 = this.GridPanel4.GetStore();
        Store4.DataSource = dt3;
        Store4.DataBind();

        Store Store2 = this.GridPanel2.GetStore();
        Store2.DataSource = dt5;
        Store2.DataBind();

        Store Store3 = this.GridPanel3.GetStore();
        Store3.DataSource = dt6;
        Store3.DataBind();

        Store Store5 = this.GridPanel5.GetStore();
        Store5.DataSource = dt7;
        Store5.DataBind();

    }
    #endregion

    #region 分配收/支经济科目列表
    /// <summary>
    /// 分配收入经济科目列表
    /// </summary>
    /// <param name="dtAll"></param>
    /// <param name="startid"></param>
    /// <param name="endid"></param>
    /// <returns>DataTable</returns>
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

    /// <summary>
    /// 分配支出经济科目列表
    /// </summary>
    /// <param name="dtAll"></param>
    /// <param name="startid"></param>
    /// <param name="endid"></param>
    /// <returns>DataTable</returns>
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

    private decimal GetLast(string sltime, string eltime, string PIEcoSubName, string moneyType)
    {
        decimal dcLast = 0;
        string hidStr=string.Empty;
        DataTable dt1 = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(PIEcoSubName);
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            hidStr += "," + dt1.Rows[i]["PIID"].ToString();
        }
        hidStr = hidStr.TrimStart(',');
        //DataTable dt = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTimeRangeType(sltime, eltime, hidStr);
        DataTable dt = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimeRangeType(sltime, eltime, hidStr);
        //DataTable dt = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimePIEcoSubName(time1, time2, PIEcoSubName);
        if (dt.Rows.Count > 0 && dt!=null)
        {
            if (moneyType == "所有")
            {
                dcLast = ToDec(dt.Rows[0]["ODCkAreaMon"]) + ToDec(dt.Rows[0]["ODCkZeroMon"]);
            }
            else if (moneyType == "零户")
            {
                dcLast = ToDec(dt.Rows[0]["ODCkZeroMon"]);
            }
            else
            {
                dcLast = ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
        }
        return dcLast;
    }

    private void ShowDtBind(string stime, string etime)
    { 
        int syear = Convert.ToDateTime(stime).Year - 1;
        int eyear = Convert.ToDateTime(etime).Year - 1;
        int smon = Convert.ToDateTime(stime).Month;
        int emon = Convert.ToDateTime(etime).Month;
        string sltime = Convert.ToDateTime(syear.ToString() + "-" + smon.ToString()).ToString("yyyy-MM-dd");
        string eltime = Convert.ToDateTime(eyear.ToString() + "-" + emon.ToString()).ToString("yyyy-MM-dd");
        stime = Convert.ToDateTime(stime).ToString("yyyy-MM-dd");
        etime = Convert.ToDateTime(etime).ToString("yyyy-MM-dd");
        Dictionary<string, string> dic = new Dictionary<string, string>();
        decimal HSBQMonTotal = 0;
        decimal HSBQMonQJTotal = 0;
        decimal HSBQMonLHTotal = 0;
        decimal HSTQMonTotal = 0;
        decimal RJXSTotal = 0;
        DataTable dt2 = FA_SysSettingManager.GetAllFA_SysSetting();
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            string year = dt2.Rows[i]["SSYear"].ToString();
            if (!dic.ContainsKey(year))
            {
                dic.Add(year, dt2.Rows[i]["StaffNum"].ToString());
            }
        }
        DataTable dt = GetMiddleChangeDt();
        //DataTable dt1 =FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTimeRangeType(stime, etime,hid2Str);
        DataTable dt1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTimeRangeType(stime, etime, hid2Str);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            if (syear == eyear)
            {
                int year = syear + 1;
                if (moneyType == "所有")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                        {
                            dr["HSBQMonQJ"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                            HSBQMonQJTotal += ToDec(dr["HSBQMonQJ"]);
                        }
                        if (ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMonLH"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonLHTotal += ToDec(dr["HSBQMonLH"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        if (ToDec(dic[year.ToString()]) != 0 && ToDec(dr["HSBQMon"]) != 0)
                        {
                            dr["RJXS"] = (ToDec(dr["HSBQMon"]) / ToDec(dic[year.ToString()])).ToString("f2");
                            RJXSTotal += ToDec(dr["RJXS"]);
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
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
                    if (RJXSTotal != 0)
                    {
                        dr1["RJXS"] = (RJXSTotal).ToString("f2");
                    }
                    dt.Rows.Add(dr1);

                }
                else if (moneyType == "零户")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        if (ToDec(dic[year.ToString()]) != 0 && ToDec(dr["HSBQMon"]) != 0)
                        {
                            dr["RJXS"] = (ToDec(dr["HSBQMon"]) / ToDec(dic[year.ToString()])).ToString("f2");
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
                    if (HSBQMonTotal != 0)
                    {
                        dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                    }
                    if (HSTQMonTotal != 0)
                    {
                        dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                    }
                    if (RJXSTotal != 0)
                    {
                        dr1["RJXS"] = (RJXSTotal).ToString("f2");
                    }
                    dt.Rows.Add(dr1);
                }
                else
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        if (ToDec(dic[year.ToString()]) != 0 && ToDec(dr["HSBQMon"]) != 0)
                        {
                            dr["RJXS"] = (ToDec(dr["HSBQMon"]) / ToDec(dic[year.ToString()])).ToString("f2");
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
                    if (HSBQMonTotal != 0)
                    {
                        dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                    }
                    if (HSTQMonTotal != 0)
                    {
                        dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                    }
                    if (RJXSTotal != 0)
                    {
                        dr1["RJXS"] = (RJXSTotal).ToString("f2");
                    }
                    dt.Rows.Add(dr1);
                }
            }
            else
            {
                GridPanel1.ColumnModel.Columns[5].Visible = false;
                if (moneyType == "所有")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                        {
                            dr["HSBQMonQJ"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                            HSBQMonQJTotal += ToDec(dr["HSBQMonQJ"]);
                        }
                        if (ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMonLH"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonLHTotal += ToDec(dr["HSBQMonLH"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
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
                    dt.Rows.Add(dr1);

                }
                else if (moneyType == "零户")
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkZeroMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkZeroMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
                    if (HSBQMonTotal != 0)
                    {
                        dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                    }
                    if (HSTQMonTotal != 0)
                    {
                        dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                    }
                    dt.Rows.Add(dr1);
                }
                else
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string PIEcoSubName = dt1.Rows[i]["PIEcoSubName"].ToString();
                        dr["KMName"] = PIEcoSubName;
                        if (ToDec(dt1.Rows[i]["ODCkAreaMon"]) != 0)
                        {
                            dr["HSBQMon"] = (ToDec(dt1.Rows[i]["ODCkAreaMon"])).ToString("f2");
                            HSBQMonTotal += ToDec(dr["HSBQMon"]);
                        }
                        if (GetLast(sltime, eltime, PIEcoSubName, moneyType) != 0)
                        {
                            dr["HSTQMon"] = (GetLast(sltime, eltime, PIEcoSubName, moneyType)).ToString("f2");
                            HSTQMonTotal += ToDec(dr["HSTQMon"]);
                        }
                        dt.Rows.Add(dr);
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["KMName"] = "合计";
                    if (HSBQMonTotal != 0)
                    {
                        dr1["HSBQMon"] = (HSBQMonTotal).ToString("f2");
                    }
                    if (HSTQMonTotal != 0)
                    {
                        dr1["HSTQMon"] = (HSTQMonTotal).ToString("f2");
                    }
                    dt.Rows.Add(dr1);
                }
            }
        }
        this.Store1.DataSource = dt;
        this.Store1.DataBind();
        cboType.SelectedItem.Value =Session["type"].ToString();
    }

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

        ////预算金额
        //dt.Columns.Add("YSMon");
        ////决算金额
        //dt.Columns.Add("JSMon");

        //核算本期数
        dt.Columns.Add("HSBQMon");
        //核算本期数（区级）
        dt.Columns.Add("HSBQMonQJ");
        //核算本期数（零户）
        dt.Columns.Add("HSBQMonLH");
        //核算同期数
        dt.Columns.Add("HSTQMon");

        ////与预算比
        //dt.Columns.Add("YYSBit");
        ////与决算比
        //dt.Columns.Add("YJSBit");

        //人均系数
        dt.Columns.Add("RJXS");

        return dt;
    }
    #endregion

    private string DealVal(decimal d1, decimal d2)
    {
        string reStr = string.Empty;
        if ((int)d1 == 0 || (int)d2 == 0)
        {
            reStr = "--";
        }
        else
        {
            reStr = Decimal.Round((d1 / d2) * 100, 2).ToString() + "%";
        }
        return reStr;
    }

    private DataTable OutlayFilterDt(DataTable dtSum, List<string> lstTmp, DataTable dtfilter)
    {
        if (dtfilter.Rows.Count > 0)
        {
            for (int i = 0; i < dtfilter.Rows.Count; i++)
            {
                if (lstTmp.Contains(dtfilter.Rows[i]["PIEcoSubCoding"].ToString().Trim()))
                {
                    DataRow dr = dtSum.NewRow();
                    //科目编码
                    dr["KMCodeing"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    //科目名称
                    dr["KMName"] = dtfilter.Rows[i]["PIEcoSubName"].ToString();
                    ////预算金额
                    //dr["YSMon"] = dtfilter.Rows[i]["OABudMon"].ToString();
                    ////决算金额
                    //dr["JSMon"] = dtfilter.Rows[i]["OAAudMon"].ToString();
                    //核算本期数
                    dr["HSBQMon"] = dtfilter.Rows[i]["OACkMon"].ToString();
                    //核算同期数
                    dr["HSTQMon"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    ////与预算比
                    //dr["YYSBit"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    ////与决算比
                    //dr["YJSBit"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    //人均系数
                    dr["RJXS"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    dtSum.ImportRow(dr);
                }
            }
        }
        return dtSum;
    }



    protected void btnSearch_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        string StartYear = cboStartYear.RawValue.ToString();
        string StartMon = cboStartMon.RawValue.ToString();
        string EndYear = cboEndYear.RawValue.ToString();
        string EndMon = cboEndMon.RawValue.ToString();
        string startTime = StartYear + "-" + StartMon;
        string emdTime = EndYear + "-" + EndMon;
        string type = cboType.SelectedItem.Text.ToString();
        if (Int32.Parse(StartYear) > Int32.Parse(EndYear))
        {
            return;
        }
        if (Int32.Parse(StartYear) == Int32.Parse(EndYear) && Int32.Parse(StartMon) > Int32.Parse(EndMon))
        {
            return;
        }
        Response.Redirect("MonOutlyAnaly.aspx?stime=" + startTime + "&etime=" + emdTime + "&hid1=" + hid1.Value + "&hid2=" + hid2.Value + "&hid3=" + hid3.Value + "&type=" + type, true);
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
            GridPanel5.Hidden = true;
        }
        if (cboType.SelectedItem.Value == "1")
        {
            GridPanel3.Hidden = false;
            GridPanel5.Hidden = false;
        }
        if (cboType.SelectedItem.Value == "2")
        {
            GridPanel3.Hidden = false;
            GridPanel5.Hidden = false;
        }
    }

    [DirectMethod]
    public void GetSelectType(string str)
    {
        Session["type"]= str;
        if (str=="3")
        {
            GridPanel3.Hidden = true;
            GridPanel5.Hidden = true;
        }
        if (str == "1")
        {
            GridPanel3.Hidden = false;
            GridPanel5.Hidden = false;
        }
        if (str == "2")
        {
            GridPanel3.Hidden = false;
            GridPanel5.Hidden = false;
        }
    }
    
}
