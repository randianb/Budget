using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;
using System.IO;
using Microsoft.Win32;

public partial class WebPage_OptAnaly_OAAnnIncomAnaly : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!X.IsAjaxRequest)
        {
            btnExpand.Hide();
            AnalyDataBind();
            OptionControlBind();
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

            btnExpand.Show();
            FieldSet1.Hide();
            ShowDtBind(stimeStr, etimeStr);
            ShowFiledCoum(hid3Str);
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

    #region 绑定自选控制项
    ///<summary>
    ///绑定自选控制项
    ///</summary>
    private void OptionControlBind()
    {
        DataTable dt = GetOptionControlData();
        this.Store6.DataSource = dt;
        this.Store6.DataBind();
    }
    #endregion

    #region 绑定收/支经济科目选择项
    private void AnalyDataBind()
    {
        DataTable dtEcoInc = BG_EcoIncomeLogic.GetEcoIncomeDt();
        DataTable dt1 = AllotEIDt(dtEcoInc, "999", "1022");
        DataTable dt2 = AllotEIDt(dtEcoInc, "1021", "1032");

        DataTable dtPayInc = BG_PayIncomeLogic.DtDeal();
        DataTable dt3 = AllotPIDt(dtPayInc, "999", "1022");
        DataTable dt4 = AllotPIDt(dtPayInc, "1021", "1102");
        Store Store2 = this.GridPanel2.GetStore();
        Store2.DataSource = dt1;
        Store2.DataBind();

        Store Store3 = this.GridPanel3.GetStore();
        Store3.DataSource = dt2;
        Store3.DataBind();

        Store Store4 = this.GridPanel4.GetStore();
        Store4.DataSource = dt3;
        Store4.DataBind();

        Store Store5 = this.GridPanel5.GetStore();
        Store5.DataSource = dt4;
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

    private void ShowDtBind(string stime, string etime)
    {
        stime = Convert.ToDateTime(stime).ToString("yyyy-MM-dd");
        etime = Convert.ToDateTime(etime).ToString("yyyy-MM-dd");
        DataTable dt = GetMiddleChangeDt();
        DataTable dtIncome = new DataTable();
        if ((hid1Str.Length <= 0 && hid2Str.Length <= 0) || hid1Str.Length > 0)
        {
            dtIncome = BG_IncomeCKLogic.GetIncomeCKDtByInterval(stime, etime, hid1Str, 100);
        }
        DataTable dtOutlay = new DataTable();
        if ((hid1Str.Length <= 0 && hid2Str.Length <= 0) || hid2Str.Length > 0)
        {
            dtOutlay = BG_OutlayCKLogic.GetOutlayCKDtByInterval(stime, etime, hid2Str, 100);
        }
        dt = BG_IncomeCKLogic.IncFilterDt(dt, dtIncome);
        dt = BG_OutlayCKLogic.OutFilterDt(dt, dtOutlay);
        this.Store1.DataSource = dt;
        this.Store1.DataBind();
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
        if (Int32.Parse(StartYear) > Int32.Parse(EndYear))
        {
            return;
        }
        if (Int32.Parse(StartYear) == Int32.Parse(EndYear) && Int32.Parse(StartMon) > Int32.Parse(EndMon))
        {
            return;
        }
        Response.Redirect("OAAnnIncomAnaly.aspx?stime=" + startTime + "&etime=" + emdTime + "&hid1=" + hid1.Value + "&hid2=" + hid2.Value + "&hid3=" + hid3.Value, true);
    }

    [DirectMethod]
    public void GetSelectionData(string allselect1, string allselect2, string allselect3)
    {
        ViewState["hid1"] = allselect1;
        ViewState["hid2"] = allselect2;
        ViewState["hid3"] = allselect3;
        this.Store1.DataSource = GetMiddleChangeDt();
        this.Store1.DataBind();
    }

    protected void btnExpand_DirectClick(object sender, DirectEventArgs e)
    {
        FieldSet1.Show();
    }

    [DirectMethod]
    public void XMLDownLoad()
    {
        
    }
}
