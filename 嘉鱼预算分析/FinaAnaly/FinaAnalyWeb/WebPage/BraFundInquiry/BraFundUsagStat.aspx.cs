using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.Model;
using FinaAnaly.BLL;
using Common;
using Ext.Net;
using FinaAnaly.DAL;

public partial class WebPage_BraFundInquiry_BraFundUsagStat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Column3.Text = DateTime.Now.Year.ToString() + "年额度";
        if (!IsPostBack)
        {
            ImpDataBind();
        }
    }


    private void ImpDataBind()
    {
        DataTable dt = FA_FundsAccountUDetailManager.GetAllFA_FundsAccountUDetail();
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetRow(dt);
            Store1.DataBind();
        }
        else
        {
            dt = new DataTable();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "flagred", "flagred();", true);
    }

    private decimal GetED(string name)
    {
        decimal ed = 0;
        DataTable dt = FA_FundsAccountManager.GetFundsAccountByName(name);
        if (dt != null && dt.Rows.Count > 0)
        {
            ed = ToDec(dt.Rows[0]["LIMIT"]);
        }
        return ed;
    }

    private decimal GetCash(string name)
    {
        decimal mon = 0;
        string sql = string.Empty;
        if (name == "区局合计")
        {
            sql = string.Format("select SUM(JE) AS JE from FA_FundsAccountJournal where BM IN (SELECT DEPARTMENT FROM FA_FundsAccountUDetail WHERE DEPARTMENT!='区局合计')  AND ZFLX='现金' group by ZFLX");
           
        }
        else
        {
            sql = string.Format("  select sum(JE)AS JE from FA_FundsAccountJournal where BM='{0}' AND ZFLX='现金' GROUP BY ZFLX", name);
        }
        DataTable dt = DBUnity.AdapterToTab(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            mon = ToDec(dt.Rows[0]["JE"]);
        }
        return mon;
    }

    private decimal GetAllCash(string name)
    {
        decimal mon = 0;
        string sql = string.Empty;
        if (name == "区局合计")
        {
            sql = string.Format("select SUM(JE) AS JE from FA_FundsAccountJournal where BM IN (SELECT DEPARTMENT FROM FA_FundsAccountUDetail WHERE DEPARTMENT!='区局合计')  group by ZFLX", name);
            DataTable dt = DBUnity.AdapterToTab(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                mon = ToDec(dt.Rows[0]["JE"]) + ToDec(dt.Rows[1]["JE"]);
            }
        }
        else
        {
            sql = string.Format("  select sum(JE)AS JE from FA_FundsAccountJournal where BM='{0}' GROUP BY BM", name);
            DataTable dt = DBUnity.AdapterToTab(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                mon = ToDec(dt.Rows[0]["JE"]);
            }
        }
        
        return mon;
    }

    private DataTable GetRow(DataTable dt)
    {
        dt.Columns.Add("data1");
        dt.Columns.Add("data2");
        dt.Columns.Add("data3");
        dt.Columns.Add("data4");
        dt.Columns.Add("data5");
        dt.Columns.Add("data6");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string name = dt.Rows[i]["DEPARTMENT"].ToString();
            dt.Rows[i]["data1"] = GetED(name);
            dt.Rows[i]["data2"] = GetAllCash(name);
            dt.Rows[i]["data3"] = GetCash(name);
            dt.Rows[i]["data4"] = ToDec(dt.Rows[i]["XJJH"]) - GetCash(name);
            dt.Rows[i]["data5"] = GetED(name) - GetAllCash(name);
            if (GetED(name) != 0)
            {
                dt.Rows[i]["data6"] = ((GetAllCash(name) / GetED(name)) * 100).ToString("f2") + "%";
            }
        }
        return dt;
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

    protected void btnImport_Click(object sender, EventArgs e)
    {
        DataTable dt = null;
        if (FileUpload1.HasFile)
        {
            byte[] fileBytes = FileUpload1.FileBytes;
            if (ExcelRender.HasData(new MemoryStream(fileBytes)))
            {
                dt = ExcelRender.RenderFromExcel(new MemoryStream(fileBytes), 1, 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 3; i < dt.Rows.Count; i++)
                    {
                        DataTable dt1 = FA_FundsAccountUDetailManager.GetFundsAccountUDetailByName(dt.Rows[i][0].ToString());
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            int id = common.IntSafeConvert(dt1.Rows[0]["FAUDID"].ToString(), 0);
                            FA_FundsAccountUDetail faut = FA_FundsAccountUDetailManager.GetFA_FundsAccountUDetailByFAUDID(id);
                            faut.DEPARTMENT = dt.Rows[i][0].ToString();
                            faut.ED = ToDec(dt.Rows[i][1].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            faut.TZ = ToDec(dt.Rows[i][2].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            faut.QZXJ = ToDec(dt.Rows[i][3].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            faut.XJJH = ToDec(dt.Rows[i][4].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            faut.XJKYED = ToDec(dt.Rows[i][5].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            faut.KYYE = ToDec(dt.Rows[i][6].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            if (FA_FundsAccountUDetailManager.ModifyFA_FundsAccountUDetail(faut))
                            {
                                ImpDataBind();
                                lblShowResult.Text = "导入成功";
                            }
                            else
                            {
                                lblShowResult.Text = "操作失败，请重试";
                            }
                        }
                        else
                        {
                            FA_FundsAccountUDetail fa = new FA_FundsAccountUDetail();
                            fa.DEPARTMENT = dt.Rows[i][0].ToString();
                            fa.ED = ToDec(dt.Rows[i][1].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            fa.TZ = ToDec(dt.Rows[i][2].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            fa.QZXJ = ToDec(dt.Rows[i][3].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            fa.XJJH = ToDec(dt.Rows[i][4].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            fa.XJKYED = ToDec(dt.Rows[i][5].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            fa.KYYE = ToDec(dt.Rows[i][6].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            //fa.ZEDB = ToDec(dt.Rows[i][8]);
                            //fa.BZ = dt.Rows[i][8].ToString();
                            if (FA_FundsAccountUDetailManager.AddFA_FundsAccountUDetail(fa).FAUDID > 0)
                            {
                                ImpDataBind();
                                lblShowResult.Text = "导入成功";
                            }
                            else
                            {
                                lblShowResult.Text = "操作失败，请重试";
                            }
                        }
                    }
                }
            }
        }
    }

    [DirectMethod]
    public void clicksave(string idstrs)
    {
        string[] arrstr = idstrs.Trim().TrimEnd('#').Split('#');
        for (int i = 0; i < arrstr.Length; i++)
        {
            string[] arr = arrstr[i].Split('*');
            int id = common.IntSafeConvert(arr[0], 0);
            FA_FundsAccountUDetail fa = FA_FundsAccountUDetailManager.GetFA_FundsAccountUDetailByFAUDID(id);
            if (fa != null)
            {
                fa.XJJH = ToDec(arr[1]);
                if (FA_FundsAccountUDetailManager.ModifyFA_FundsAccountUDetail(fa))
                {
                    X.MessageBox.Alert("操作提示", "保存成功").Show();
                }
                else
                {
                    X.MessageBox.Alert("操作提示", "保存失败").Show();
                }
            }
        }
        ImpDataBind();
    }

    protected void btnGetData_DirectClick(object sender, DirectEventArgs e)
    {
        ImpDataBind();
    }
}