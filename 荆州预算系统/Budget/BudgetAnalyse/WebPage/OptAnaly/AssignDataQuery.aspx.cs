using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;

public partial class WebPage_OptAnaly_AssignDataQuery : System.Web.UI.Page
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
        if (Request.QueryString["year"] != null)
        {
            string yearStr = Request.QueryString["year"].ToString();
            cboStartYear.SelectedItem.Value = yearStr;
            hid1Str = Request.QueryString["hid1"];
            hid2Str = Request.QueryString["hid2"];
            hid3Str = Request.QueryString["hid3"];

            btnExpand.Show();
            FieldSet1.Hide();
            ShowDtBind(yearStr);
            ShowFiledCoum(hid3Str);
        }
    }


    private void ShowFiledCoum(string str3)
    {
        if (str3.Length>0)
        {
            if (!str3.Contains("预算数"))
            {
                GridPanel1.ColumnModel.Columns[2].Visible = false;
            }
            if (!str3.Contains("决算数"))
            {
                GridPanel1.ColumnModel.Columns[3].Visible = false;
            }
            if (!str3.Contains("核算本期数"))
            {
                GridPanel1.ColumnModel.Columns[4].Visible = false;
            }
            if (!str3.Contains("核算同期数"))
            {
                GridPanel1.ColumnModel.Columns[5].Visible = false;
            }
            if (!str3.Contains("与预算比"))
            {
                GridPanel1.ColumnModel.Columns[6].Visible = false;
            }
            if (!str3.Contains("与决算比"))
            {
                GridPanel1.ColumnModel.Columns[7].Visible = false;
            }
            if (!str3.Contains("人均系数"))
            {
                GridPanel1.ColumnModel.Columns[8].Visible = false;
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
        //核算本期数
        dt.Columns.Add("HSBQMon");
        //核算同期数
        dt.Columns.Add("HSTQMon");
        //与预算比
        dt.Columns.Add("YYSBit");
        //与决算比
        dt.Columns.Add("YJSBit");
        //人均系数
        dt.Columns.Add("RJXS");
        return dt;
    }
    #endregion

    //年度收支情况
    private void ShowDtBind(string yearStr)
    {
            DataTable dt = GetMiddleChangeDt();
            //List<string> eiList = Session["EICodingList"] as List<string>;
            //List<string> piList = Session["PICodingList"] as List<string>;
            DataTable dtIncome = new DataTable();
            //if ((piList == null && eiList == null) || eiList.Count>0)
            //{
            if ((hid1Str.Length <= 0 && hid2Str.Length <= 0) || hid1Str.Length > 0)
                dtIncome = BG_IncomeAnaLogic.GetIncomeDtByYeat(Int32.Parse(yearStr), hid1Str, 100);
            //}
            DataTable dtOutlay = new DataTable();
            //if ((piList == null && eiList == null) || piList.Count > 0)
            //{
            if ((hid1Str.Length <= 0 && hid2Str.Length <= 0) || hid2Str.Length > 0)
                dtOutlay = BG_OutlayAnaLogic.GetOutDtByYeat(Int32.Parse(yearStr), hid2Str, 100);
            //}
            dt = BG_IncomeAnaLogic.IncFilterDt(dt, dtIncome);
            dt = BG_OutlayAnaLogic.OutlayFilterDt(dt, dtOutlay);
            this.Store1.DataSource = dt;
            this.Store1.DataBind();
    }



    protected void btnSearch_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        string yearStr = cboStartYear.RawValue.ToString();
        Response.Redirect("AssignDataQuery.aspx?year=" + yearStr+"&hid1="+hid1.Value+"&hid2="+hid2.Value+"&hid3="+hid3.Value, true);

        //cboStartYear.SelectedItem.Value = yearStr;
        //btnExpand.Show();
        //FieldSet1.Hide();
        //ShowDtBind(yearStr);
        //ShowFiledCoum();

        //GridPanel1.ColumnModel.Columns[2].Visible = false;

        ////支出经济科目选择项大于0【有选择项】收入经济科目选择项小于0【无选择项】
        //if (EICodingList.Count <= 0 && PICodingList.Count > 0)
        //{

        //}
        ////收入经济科目选择项大于0【有选择项】支出经济科目选择项小于0【无选择项】
        //if (PICodingList.Count <= 0 && EICodingList.Count > 0)
        //{

        //}
        ////收入经济科目选择项大于0【有选择项】支出经济科目选择项大于0【有选择项】
        //if (PICodingList.Count > 0 && EICodingList.Count > 0)
        //{

        //}
        ////收入经济科目选择项小于0【无选择项】支出经济科目选择项小于0【无选择项】
        //if (PICodingList.Count <= 0 && EICodingList.Count <= 0)
        //{

        //}

    }

    [DirectMethod]
    public void GetSelectionData(string allselect1, string allselect2, string allselect3)
    {

        ViewState["hid1"] = allselect1;
        ViewState["hid2"] = allselect2;
        ViewState["hid3"] = allselect3;
        this.Store1.DataSource = GetMiddleChangeDt();
        this.Store1.DataBind();
        //Session["EICodingList"] = null;
        //Session["PICodingList"] = null;
        //Session["OCNameList"] = null;

        //string[] codingStrA = allselect1.Split(',');
        //string[] codingStrB = allselect2.Split(',');
        //string[] codingStrC = allselect3.Split(',');
        //for (int i = 0; i < codingStrA.Length; i++)
        //{
        //    string tmpA = codingStrA[i];
        //    if (!EICodingList.Contains(tmpA) && !string.IsNullOrEmpty(tmpA))
        //    {
        //        EICodingList.Add(tmpA);
        //    }
        //}
        //Session["EICodingList"] = EICodingList;
        //for (int j = 0; j < codingStrB.Length; j++)
        //{
        //    string tmpB = codingStrB[j];
        //    if (!PICodingList.Contains(tmpB) && !string.IsNullOrEmpty(tmpB))
        //    {
        //        PICodingList.Add(tmpB);
        //    }
        //}
        //Session["PICodingList"] = PICodingList;
        //for (int m = 0; m < codingStrC.Length; m++)
        //{
        //    string tmpC = codingStrC[m];
        //    if (!OCNameList.Contains(tmpC) && !string.IsNullOrEmpty(tmpC))
        //    {
        //        OCNameList.Add(tmpC);
        //    }
        //}
        //Session["OCNameList"] = OCNameList;
    }
    protected void btnExpand_DirectClick(object sender, DirectEventArgs e)
    {
        FieldSet1.Show();
    }
}