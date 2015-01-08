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
            Getmonth();
            cmbmon.SelectedItem.Text = DateTime.Now.Month.ToString();
            cmbdept.SelectedItem.Index = 0;
            DepDataBind(); 
          //  QuotaData();
           
        }
     
    }
    private void Getmonth()
    {
        //DataTable dt = new DataTable();
        //dt.Columns.Add("month");
        //int mon = BG_MonPayPlanLogic.GetmonthbyMonPayPlan(DepID) + 1;

        //if (mon < 11)
        //{
        //    for (int i = mon; i > 0; i--)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["month"] = "0" + i.ToString();
        //        dt.Rows.Add(dr);
        //    }
        //}
        //else
        //{
        //    for (int i = mon; i > 0; i--)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["month"] = i.ToString();
        //        dt.Rows.Add(dr);
        //    }
        //}

        DataTable dt = new DataTable();
        dt.Columns.Add("month");
        for (int i = 1; i < 13; i++)
        {
            string t = i.ToString();
            if (i < 10)
            {
                t = "0" + i;
            }
            DataRow dr = dt.NewRow();
            dr["month"] = t;
            dt.Rows.Add(dr);
        }
        cmbmonstore.DataSource = dt;
        cmbmonstore.DataBind();
    }
    private void QuotaData()
    {
        //DataTable dt = BGQuotaLogic.GetBGQuota(year);
        DataTable dt = BG_QuotaManager.GetAllBG_Quota();
        PayStore.DataSource = GetPayname(dt);
        PayStore.DataBind();
    }
 
    private void DepDataBind()
    {
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
            cmbdept.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
        }

    }
    private DataTable GetPayname(DataTable dtnew)
    {
        string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Text;
        System.Data.DataView dv = dtnew.DefaultView;
        string filter = string.Format("Qtime='{0}' and DepID={1}", YearMonth + "-01", cmbdept.SelectedItem.Value);
        dv.RowFilter = filter;
        DataTable dt = dv.ToTable(true);
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add("PayPrjName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = common.IntSafeConvert(dt.Rows[i]["PIID"].ToString());
                dt.Rows[i]["PayPrjName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
            }
            return dt;
           
        }
        else
        {
            X.Msg.Alert("提示", "数据为空").Show();
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
        qt.Money =  newValue;
        BG_QuotaManager.ModifyBG_Quota(qt);
    }
 

    protected void btnSure_OnDirectClick(object sender, DirectEventArgs e)
    {
        QuotaData();
    }
}