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

public partial class WebPage_BudgetEstimate_BEPersonExpenseBudget : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            PreviewDataBind();
        }
    }

    private void PreviewDataBind()
    {
        int year = common.IntSafeConvert(CurrentYear);
        DataTable dt = BG_PreviewDataLogic.GetPersonPart();
        dt.Columns.Add("rsold");
        dt.Columns.Add("rsnew");
        dt.Columns.Add("rjsold");
        dt.Columns.Add("rjsnew");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string pnumold = "";
            string pnumnew = "";
            DataTable dt1 = BG_SysSettingManager.GetAllBG_SysSetting();
            if (dt1.Rows.Count > 0)
            {
                pnumold = BG_SysSettingLogic.GetPerByYear(year - 1);
                pnumnew = BG_SysSettingLogic.GetPerByYear(year);
                hidbn.Value = pnumnew;
            }
            else
            {
                pnumold = "0";
                pnumnew = "0";
                hidbn.Value = pnumnew;
            }
            dt.Rows[i]["rsold"] = pnumold;
            dt.Rows[i]["rsnew"] = pnumnew;
            int Pepold = common.IntSafeConvert(pnumold);
            int Pepnew = common.IntSafeConvert(pnumnew);
            dt.Rows[i]["rjsold"] = (Convert.ToDouble(dt.Rows[i]["PDBaseLYData"]) / (Pepold * 1.0f)).ToString("f2");
            dt.Rows[i]["rjsnew"] = (Convert.ToDouble(dt.Rows[i]["PDBaseData"]) / (Pepnew * 1.0f)).ToString("f2");
        }

        Store1.DataSource = Getquota(dt);
        Store1.DataBind();
    }
    private DataTable Getquota(DataTable dt)
    {
        int pepnum = common.IntSafeConvert(hidbn.Value.ToString());
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
                string[] slist = bgpi.Split(',');
                for (int j = 0; j < slist.Count(); j++)
                {
                    piid = common.IntSafeConvert(slist[j]);
                    qt += BGQuotaLogic.GetBGQuotaByPIID(piid, common.IntSafeConvert(CurrentYear));
                }
                dt.Rows[i]["StandardQuota"] = qt;
                dt.Rows[i]["StandardQuotacount"] = qt * pepnum;
            }
        }
        return dt;
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
        pd.PDBaseData = Convert.ToDecimal(newValue);
        BG_PreviewDataManager.ModifyBG_PreviewData(pd);
        PreviewDataBind();

        //this.GridPanel1.GetStore().GetById(id).Commit();
    }

}