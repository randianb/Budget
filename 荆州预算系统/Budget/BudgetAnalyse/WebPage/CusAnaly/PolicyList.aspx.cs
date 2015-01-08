using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;

public partial class WebPage_CusAnaly_PolicyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            Kv k=new Kv();
            DataTable dt = BG_PolicyLogic.GetAllPolicy();
            for (int i = 0; i < 100; i++)
            {                
                  dt.Rows[0]["PTitle"]= k.Key + i;
                  dt.Rows[0]["PTitle"] = k.Val + i;
                 
            }

            Store store = this.GridPanel1.GetStore();
            store.DataSource = dt;
            store.DataBind();
        }

    }
}