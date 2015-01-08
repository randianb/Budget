using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using FinaAnaly.DAL;
using FinaAnaly.BLL;
using FinaAnaly.Model;

public partial class WebPage_CusAnaly_EcoMon : System.Web.UI.Page
{
    int depid = 0;
    DateTime time;
    DateTime time1;
    string type = string.Empty;
    string depnameAll = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["depid"] != null && Request.QueryString["time"] != null && Request.QueryString["time1"] != null && Request.QueryString["type"] != null && Request.QueryString["depnameAll"] != null)
        {
            depid = common.IntSafeConvert(Request.QueryString["depid"].ToString());
            time = Convert.ToDateTime(Request.QueryString["time"].ToString());
            time1 = Convert.ToDateTime(Request.QueryString["time1"].ToString());
            type = Request.QueryString["type"].ToString();
            depnameAll = Request.QueryString["depnameAll"].ToString();
            txtBind(depid, time, time1, type);
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

    private void txtBind(int depid, DateTime time, DateTime time1, string type)
    {
        decimal dcThis = 0;
        decimal dcThisTatol = 0;
        decimal dclastTatol = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        string sqlStr1 = string.Format("SELECT  a.ODCkAreaMon, a.ODCkZeroMon, b.PIEcoSubName ,b.PIEcoSubParID,a.PIID, a.ODCkTime FROM  dbo.FA_XOutlayDepCK AS a INNER JOIN  dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE  (a.DepID = {0}) and (a.ODCkTime ='{1}')", depid, time);
        DataTable dt1 = DBUnity.AdapterToTab(sqlStr1);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                FA_XPayIncome fa= FA_XPayIncomeManager.GetFA_XPayIncomeByPIID(common.IntSafeConvert(dt1.Rows[i]["PIEcoSubParID"], 0));
                if (type == "0")
                {
                    decimal dclast = 0;
                    dcThis = ToDec(dt1.Rows[i]["ODCkAreaMon"]) + ToDec(dt1.Rows[i]["ODCkZeroMon"]);
                    dcThisTatol += dcThis;
                    string sqlStr2 = string.Format("SELECT  a.ODCkAreaMon, a.ODCkZeroMon, b.PIEcoSubName,a.PIID, a.ODCkTime FROM  dbo.FA_XOutlayDepCK AS a INNER JOIN  dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE  (a.DepID = {0}) and (a.ODCkTime ='{1}')", depid, time1);
                    DataTable dt2 = DBUnity.AdapterToTab(sqlStr2);
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        
                        if (common.IntSafeConvert( dt1.Rows[i]["PIID"]) == common.IntSafeConvert( dt2.Rows[j]["PIID"])&&dcThis!=0)
                        {
                            dclast = ToDec(dt2.Rows[j]["ODCkAreaMon"]) + ToDec(dt2.Rows[j]["ODCkZeroMon"]);
                            dclastTatol += dclast;
                        }
                    }
                    if (dcThis != 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["column1"] =fa.PIEcoSubName+"--"+ dt1.Rows[i]["PIEcoSubName"].ToString();
                        if (dcThis != 0)
                        {
                            dr["column2"] = dcThis;
                        }
                        if (dclast != 0)
                        {
                            dr["column3"] = dclast;
                        }
                        if (dclast != 0 && dcThis - dclast != 0)
                        {
                            dr["column4"] = (((dcThis - dclast) / dclast) * 100).ToString("f2") + "%";
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (type == "1")
                {
                    decimal dclast = 0;
                    dcThis = ToDec(ToDec(dt1.Rows[i]["ODCkZeroMon"]));
                    dcThisTatol += dcThis;
                    string sqlStr2 = string.Format("SELECT  a.ODCkAreaMon, a.ODCkZeroMon, b.PIEcoSubName,a.PIID, a.ODCkTime FROM  dbo.FA_XOutlayDepCK AS a INNER JOIN  dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE  (a.DepID = {0}) and (a.ODCkTime ='{1}')", depid, time1);
                    DataTable dt2 = DBUnity.AdapterToTab(sqlStr2);
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {

                        if (common.IntSafeConvert(dt1.Rows[i]["PIID"]) == common.IntSafeConvert(dt2.Rows[j]["PIID"])&&dcThis!=0)
                        {
                            dclast = ToDec(ToDec(dt2.Rows[j]["ODCkZeroMon"]));
                            dclastTatol += dclast;
                        }
                    }
                    if (dcThis != 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["column1"] = fa.PIEcoSubName + "--" + dt1.Rows[i]["PIEcoSubName"].ToString();
                        if (dcThis != 0)
                        {
                            dr["column2"] = dcThis;
                        }
                        if (dclast != 0)
                        {
                            dr["column3"] = dclast;
                        }
                        if (dclast != 0 && dcThis - dclast != 0)
                        {
                            dr["column4"] = (((dcThis - dclast) / dclast) * 100).ToString("f2") + "%";
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (type == "2")
                {
                    decimal dclast = 0;
                    dcThis = ToDec(dt1.Rows[i]["ODCkAreaMon"]);
                    dcThisTatol += dcThis;
                    string sqlStr2 = string.Format("SELECT  a.ODCkAreaMon, a.ODCkZeroMon, b.PIEcoSubName,a.PIID, a.ODCkTime FROM  dbo.FA_XOutlayDepCK AS a INNER JOIN  dbo.FA_XPayIncome AS b ON a.PIID = b.PIID WHERE  (a.DepID = {0}) and (a.ODCkTime ='{1}')", depid, time1);
                    DataTable dt2 = DBUnity.AdapterToTab(sqlStr2);
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {

                        if (common.IntSafeConvert(dt1.Rows[i]["PIID"]) == common.IntSafeConvert(dt2.Rows[j]["PIID"]) && dcThis!=0)
                        {
                            dclast = ToDec(dt2.Rows[j]["ODCkAreaMon"]);
                            dclastTatol += dclast;
                        }
                    }
                    if (dcThis != 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["column1"] = fa.PIEcoSubName + "--" + dt1.Rows[i]["PIEcoSubName"].ToString();
                        if (dcThis != 0)
                        {
                            dr["column2"] = dcThis;
                        }
                        if (dclast != 0)
                        {
                            dr["column3"] = dclast;
                        }
                        if (dclast != 0 && dcThis - dclast != 0)
                        {
                            dr["column4"] = (((dcThis - dclast) / dclast)*100).ToString("f2")+"%";
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (dcThisTatol != 0)
            {
                txtTMon.Text = (dcThisTatol).ToString("f2");
            }
            if (dclastTatol != 0)
            {
                txtLMon.Text = (dclastTatol).ToString("f2");
            }
            if (dclastTatol != 0 && dcThisTatol - dclastTatol != 0)
            {
                txtDifference.Text = (((dcThisTatol - dclastTatol) / dclastTatol) * 100).ToString("f2") + "%";
            }
        }
        repDepExecut.DataSource = dt;
        repDepExecut.DataBind();
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {

        Response.Redirect("DepExecution.aspx?depid=" + depid + "&time=" + time + "&type=" + type + "&depnameAll=" + depnameAll, true);
    }
}