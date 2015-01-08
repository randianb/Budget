using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Ext.Net;
using BudgetWeb.BLL;

public partial class WebPage_BudgetControl_ControlAudit : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             DataTable dt=new DataTable( );
            if ( Request["Audit"]!=null&&Request["Audit"].ToString() == "0")
            {
                hidsta.Value = 0;
                dt= BG_SelMonPayPlanLogic.GetMonPayPlanTotalAudit(0);
               
            }
            else if (Request["Audit"]!=null&&Request["Audit"].ToString() == "1")
            {
                hidsta.Value = 1;
                dt=BG_SelMonPayPlanLogic.GetMonPayPlanTotalAudit(1);
            }
            GTPdbsxStore.DataSource = dt;
            GTPdbsxStore.DataBind();

        }
    }

    [DirectMethod]
    public void DB(string depid,string time,string pici)
    {
//        string YearMonth = Convert.ToDateTime(time).ToString("yyyy-MM"); 
        if (hidsta.Value.ToString()=="0")
        {
            string str1 = "FinAudit.aspx?depid={0}&&time={1}&&pici={2}";
            string url = string.Format(str1, depid, time, pici);
            Response.Redirect(url,true);
        }
        if (hidsta.Value.ToString()=="1")
        {
            string str2 = "ChaSecAudit.aspx?depid={0}&&time={1}&&pici={2}";
            string url = string.Format(str2, depid, time, pici);
            Response.Redirect(url,true);
        } 
    }
}