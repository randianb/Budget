using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;

public partial class WebPage_BudgetEstimate_BEProjectExpenseBudget : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            PreviewDataBind();
        }
    }
    private DataTable Getquota(DataTable dt,string str)
    {
        int pepnum = common.IntSafeConvert(str);
        dt.Columns.Add("StandardQuota");
        dt.Columns.Add("StandardQuotacount");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int piid = 0;
            decimal qt = 0;
            string name = dt.Rows[i]["PSName"].ToString();
            string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
            if (bgpi == "")
            {
                qt = 0;
                dt.Rows[i]["StandardQuota"] = 0;
                dt.Rows[i]["StandardQuotacount"] = 0;
            }
            else
            {
                string[]slist= bgpi.Split(',');
                for (int j = 0; j < slist.Count(); j++)
                {
                    piid =common.IntSafeConvert(slist[j]);
                    qt += BGQuotaLogic.GetBGQuotaByPIID(piid, common.IntSafeConvert(CurrentYear));
                } 
                dt.Rows[i]["StandardQuota"] = qt;
                dt.Rows[i]["StandardQuotacount"] = qt * pepnum;
            }
        }
        return dt;
    }
    private void PreviewDataBind()
    {
        int year = common.IntSafeConvert(CurrentYear);
        DataTable dt1 = BG_PreviewDataLogic.GetPersonPart();
        dt1.Columns.Add("rsold");
        dt1.Columns.Add("rsnew");
        dt1.Columns.Add("rjsold");
        dt1.Columns.Add("rjsnew");
        DataTable dt2 = BG_PreviewDataLogic.GetPublicPart();
        dt2.Columns.Add("rsold");
        dt2.Columns.Add("rsnew");
        dt2.Columns.Add("rjsold");
        dt2.Columns.Add("rjsnew");
        DataTable dt3 = BG_PreviewDataLogic.GetCapitalPart();
        dt3.Columns.Add("rsold");
        dt3.Columns.Add("rsnew");
        dt3.Columns.Add("rjsold");
        dt3.Columns.Add("rjsnew");

        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            string pnumold = "";
            string pnumnew = "";
            DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
            if (dt.Rows.Count > 0)
            {
                pnumold = BG_SysSettingLogic.GetPerByYear(year - 1);
                pnumnew = BG_SysSettingLogic.GetPerByYear(year);
                hidbn1.Value = pnumnew;
            }
            else
            {
                pnumold = "0";
                pnumnew = "0";
                hidbn1.Value = pnumnew;
            }

            dt1.Rows[j]["rsold"] = pnumold;
            dt1.Rows[j]["rsnew"] = pnumnew;
            int Pepold = common.IntSafeConvert(pnumold);
            int Pepnew = common.IntSafeConvert(pnumnew);
            dt1.Rows[j]["rjsold"] = (Convert.ToDouble(dt1.Rows[j]["PDProjectLYData"]) / (Pepold * 1.0f)).ToString("f2");
            dt1.Rows[j]["rjsnew"] = (Convert.ToDouble(dt1.Rows[j]["PDProjectData"]) / (Pepnew * 1.0f)).ToString("f2");

        }
        for (int k = 0; k < dt2.Rows.Count; k++)
        {
            string pnumold = ""; string pnumnew = "";
            DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
            if (dt.Rows.Count > 0)
            {
                pnumold = BG_SysSettingLogic.GetPerByYear(year - 1);
                pnumnew = BG_SysSettingLogic.GetPerByYear(year);
                hidbn2.Value = pnumnew;
            }
            else
            {
                pnumold = "0";
                pnumnew = "0";
                hidbn2.Value = pnumnew;
            }

            dt2.Rows[k]["rsold"] = pnumold;
            dt2.Rows[k]["rsnew"] = pnumnew;
            int Pepold = common.IntSafeConvert(pnumold);
            int Pepnew = common.IntSafeConvert(pnumnew);
            dt2.Rows[k]["rjsold"] = (Convert.ToDouble(dt2.Rows[k]["PDProjectLYData"]) / (Pepold * 1.0f)).ToString("f2");
            dt2.Rows[k]["rjsnew"] = (Convert.ToDouble(dt2.Rows[k]["PDProjectData"]) / (Pepnew * 1.0f)).ToString("f2");

        }

        for (int i = 0; i < dt3.Rows.Count; i++)
        {
            string pnumold = ""; string pnumnew = "";
            DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
            if (dt.Rows.Count > 0)
            {
                pnumold = BG_SysSettingLogic.GetPerByYear(year - 1);
                pnumnew = BG_SysSettingLogic.GetPerByYear(year);
                hidbn3.Value = pnumnew;
            }
            else
            {
                pnumold = "0";
                pnumnew = "0";
                hidbn3.Value = pnumnew;
            }

            dt3.Rows[i]["rsold"] = pnumold;
            dt3.Rows[i]["rsnew"] = pnumnew;
            int Pepold = common.IntSafeConvert(pnumold);
            int Pepnew = common.IntSafeConvert(pnumnew);
            dt3.Rows[i]["rjsold"] = (Convert.ToDouble(dt3.Rows[i]["PDProjectLYData"]) / (Pepold * 1.0f)).ToString("f2");
            dt3.Rows[i]["rjsnew"] = (Convert.ToDouble(dt3.Rows[i]["PDProjectData"]) / (Pepnew * 1.0f)).ToString("f2");
        }
        Store2.DataSource = Getquota(dt1,hidbn1.Value.ToString());
        Store2.DataBind();
        Store3.DataSource = Getquota(dt2, hidbn2.Value.ToString());
        Store3.DataBind();
        Store1.DataSource = Getquota(dt3, hidbn3.Value.ToString());
        Store1.DataBind();
    }


    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(int id, string field, string oldValue, string newValue, object customer)
    {
        string message = "<b>编号:</b> {0}<br /><b>科目:</b> {1}<br /><b>原经费:</b> {2}<br /><b>更改经费:</b> {3}";

        // Send Message...
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "Edit Record #" + id.ToString(),
            Html = string.Format(message, id, field, oldValue, newValue),
            Width = 250
        }).Show();

        BG_PreviewData pd = BG_PreviewDataManager.GetBG_PreviewDataByPSID(id);
        pd.PDProjectData = Convert.ToDecimal(newValue);
        BG_PreviewDataManager.ModifyBG_PreviewData(pd);
        PreviewDataBind();
    }
}