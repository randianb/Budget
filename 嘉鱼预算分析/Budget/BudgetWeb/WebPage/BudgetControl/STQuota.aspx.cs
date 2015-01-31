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

public partial class WebPage_Setting_STQuota : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QuotaData();
        }
    }

    private void QuotaData()
    {
        //DataTable dt = BGQuotaLogic.GetBGQuota(year);
        DataTable dt = BG_QuotaManager.GetAllBG_Quota();
        PayStore.DataSource = GetPayname(dt);
        PayStore.DataBind();
    }

    private DataTable GetPayname(DataTable dtnew)
    {
        int year = common.IntSafeConvert(CurrentYear);
        System.Data.DataView dv = dtnew.DefaultView;
        string filter = string.Format(" Year={0}", year);
        dv.RowFilter = filter;
        DataTable dt = dv.ToTable(true);
        if (dt == null && dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "数据为空").Show();
            return dt;
        }
        else
        {
            dt.Columns.Add("PayPrjName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = common.IntSafeConvert(dt.Rows[i]["PIID"].ToString());
                dt.Rows[i]["PayPrjName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
            }
            return dt;
        }
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(int id, string PayPrjName, string oldValue, string newValue, object customer)
    {
        string message = "<b>编号:</b> {0}<br /><b>科目:</b> {1}<br /><b>原定额:</b> {2}<br /><b>更改定额:</b> {3}";

        // Send Message...
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "Edit Record #" + id.ToString(),
            Html = string.Format(message, id, PayPrjName, oldValue, newValue),
            Width = 250
        }).Show();
        BG_Quota qt = BG_QuotaManager.GetBG_QuotaByQtID(id);
        qt.Money = ParToDecimal.ParToDel(newValue);
        BG_QuotaManager.ModifyBG_Quota(qt);
    }

    
}