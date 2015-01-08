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

public partial class BudgetPage_mainPages_ImportProBudControl : BudgetBasePage
{
    int ID ; decimal Field ; string OldValue ; string NewValue ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            PreviewDataBind();
            cmbData();
        }
    }

    protected void btnAdd_Click(object sender, DirectEventArgs e)
    {

    }

    protected void btnAdd4_Click(object sender, DirectEventArgs e)
    {
        BG_ProPay pp = new BG_ProPay();
        pp.DepID = AreaDepID;
        pp.ProPYear = DateTime.Now;
        pp.PPID = ID.ToString();
        pp.ProPA0M = Field;
        BG_ProPayManager.AddBG_ProPay(pp);
        //PreviewDataBind();
    }

    private void cmbData()
    {
        List<object> strlist = new List<object>();
        DataTable dtPay = BG_PayProjectManager.GetAllBG_PayProject();
        for (int i = 0; i < dtPay.Rows.Count; i++)
        {
            string name = dtPay.Rows[i]["PayPrjName"].ToString();
            strlist.Add(new { PayPrjName = name });
        }
        cmbName.DataSource = strlist;
        cmbName.DataBind();

        //DataTable dt = new DataTable();
        //dt.Columns.Add("name");
        //DataTable dtPay = BG_PayProjectManager.GetAllBG_PayProject();
        //for (int i = 0; i < dtPay.Rows.Count; i++)
        //{
        //    dt.Rows.Add();
        //    dt.Rows[i]["name"] = dtPay.Rows[i]["PayPrjName"];
        //}
        //cmbName.DataSource = dt;
        //cmbName.DataBind();

    }

    [DirectMethod(Namespace = "Company4")]
    public void Edit(int id, string field, string oldValue, string newValue, object customer)
    {
        //string message = "<b>编号:</b> {0}<br /><b>科目:</b> {1}<br /><b>原经费:</b> {2}<br /><b>更改经费:</b> {3}";

        // Send Message...
        //X.Msg.Notify(new NotificationConfig()
        //{
        //    Title = "Edit Record #" + id.ToString(),
        //    Html = string.Format(message, id, field, oldValue, newValue),
        //    Width = 250
        //}).Show();

        ID = id;
        Field = Convert.ToDecimal(field);
        OldValue = oldValue;
        NewValue = newValue;
        //BG_ProPay pp = new BG_ProPay();
        //pp.DepID = 1083;
        //pp.ProPYear = DateTime.Now;
        //pp.PPID = id;
        //pp.ProPA0M = Convert.ToDecimal(field);
        //BG_ProPayManager.AddBG_ProPay(pp);
        //PreviewDataBind();

    }

    private void PreviewDataBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PSName");
        dt.Columns.Add("rjs1");
        dt.Columns.Add("rjs2");
        dt.Columns.Add("rjs3");
        dt.Columns.Add("rjs4");
        dt.Columns.Add("rjs5");
        dt.Columns.Add("rjs6");
        dt.Columns.Add("rjs7");
        for (int i = 0; i < 5; i++)
        {
            dt.Rows.Add();
            dt.Rows[i]["PSName"] = "";
            dt.Rows[i]["rjs1"] = "";
            dt.Rows[i]["rjs2"] = "";
            dt.Rows[i]["rjs3"] = "";
            dt.Rows[i]["rjs4"] = "";
            dt.Rows[i]["rjs5"] = "";
            dt.Rows[i]["rjs6"] = "";
            dt.Rows[i]["rjs7"] = "";
        }
        Store1.DataSource = dt;
        Store1.DataBind();

        DataTable dt2 = new DataTable();
        dt2.Columns.Add("PSName");
        dt2.Columns.Add("rjs1");
        dt2.Columns.Add("rjs2");
        dt2.Columns.Add("rjs3");
        dt2.Columns.Add("rjs4");
        dt2.Columns.Add("rjs5");
        dt2.Columns.Add("rjs6");
        dt2.Columns.Add("rjs7");
        dt2.Columns.Add("rjs8");
        dt2.Columns.Add("rjs9");
        for (int i = 0; i < 5; i++)
        {
            dt2.Rows.Add();
            dt2.Rows[i]["PSName"] = "";
            dt2.Rows[i]["rjs1"] = "";
            dt2.Rows[i]["rjs2"] = "";
            dt2.Rows[i]["rjs3"] = "";
            dt2.Rows[i]["rjs4"] = "";
            dt2.Rows[i]["rjs5"] = "";
            dt2.Rows[i]["rjs6"] = "";
            dt2.Rows[i]["rjs7"] = "";
            dt2.Rows[i]["rjs8"] = "";
            dt2.Rows[i]["rjs9"] = "";
        }
        Store2.DataSource = dt2;
        Store2.DataBind();

        DataTable dt3 = new DataTable();
        dt3.Columns.Add("PSName");
        dt3.Columns.Add("rjs1");
        dt3.Columns.Add("rjs2");
        dt3.Columns.Add("rjs3");
        dt3.Columns.Add("rjs4");
        dt3.Columns.Add("rjs5");
        dt3.Columns.Add("rjs6");
        dt3.Columns.Add("rjs7");
        dt3.Columns.Add("rjs8");
        dt3.Columns.Add("rjs9");
        dt3.Columns.Add("rjs10");
        dt3.Columns.Add("rjs11");
        dt3.Columns.Add("rjs12");
        dt3.Columns.Add("rjs13");
        dt3.Columns.Add("rjs14");
        for (int i = 0; i < 5; i++)
        {
            dt3.Rows.Add();
            dt3.Rows[i]["PSName"] = "";
            dt3.Rows[i]["rjs1"] = "";
            dt3.Rows[i]["rjs2"] = "";
            dt3.Rows[i]["rjs3"] = "";
            dt3.Rows[i]["rjs4"] = "";
            dt3.Rows[i]["rjs5"] = "";
            dt3.Rows[i]["rjs6"] = "";
            dt3.Rows[i]["rjs7"] = "";
            dt3.Rows[i]["rjs8"] = "";
            dt3.Rows[i]["rjs9"] = "";
            dt3.Rows[i]["rjs10"] = "";
            dt3.Rows[i]["rjs11"] = "";
            dt3.Rows[i]["rjs12"] = "";
            dt3.Rows[i]["rjs13"] = "";
            dt3.Rows[i]["rjs14"] = "";
        }
        Store3.DataSource = dt3;
        Store3.DataBind();

        DataTable dt4 = BG_PayProjectManager.GetAllBG_PayProject();
        dt4.Columns.Add("rjs1");
        dt4.Columns.Add("rjs2");
        dt4.Columns.Add("rjs3");
        dt4.Columns.Add("rjs4");
        dt4.Columns.Add("rjs5");
        dt4.Columns.Add("rjs6");
        dt4.Columns.Add("rjs7");
        dt4.Columns.Add("rjs8");
        dt4.Columns.Add("rjs9");
        dt4.Columns.Add("rjs10");
        dt4.Columns.Add("rjs11");
        dt4.Columns.Add("rjs12");
        dt4.Columns.Add("rjs13");
        for (int i = 0; i < 5; i++)
        {
            dt4.Rows[i]["rjs1"] = "0";
            dt4.Rows[i]["rjs2"] = "0";
            dt4.Rows[i]["rjs3"] = "0";
            dt4.Rows[i]["rjs4"] = "0";
            dt4.Rows[i]["rjs5"] = "0";
            dt4.Rows[i]["rjs6"] = "0";
            dt4.Rows[i]["rjs7"] = "0";
            dt4.Rows[i]["rjs8"] = "0";
            dt4.Rows[i]["rjs9"] = "0";
            dt4.Rows[i]["rjs10"] = "0";
            dt4.Rows[i]["rjs11"] = "0";
            dt4.Rows[i]["rjs12"] = "0";
            dt4.Rows[i]["rjs13"] = "0";

        }
        Store4.DataSource = dt4;
        Store4.DataBind();

    }
}