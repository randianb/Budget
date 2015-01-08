using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.Model;
using BudgetWeb.BLL;
using Ext.Net;

public partial class WebPage_Policy_PolicyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            DataTable dt = BG_PolicyLogic.GetAllPolicy();
            Store store = this.GridPanel1.GetStore();
            store.DataSource = dt;
            store.DataBind();
            //if (dt.Rows.Count > 0)
            //{
            //    string PTitle = dt.Rows[0]["PTitle"].ToString();
            //    string PContent = dt.Rows[0]["PContent"].ToString();
            //}
        }
    }
}