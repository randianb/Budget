using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;
using System.Data;

public partial class WebPage_OptAnaly_ImportCkData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack && !X.IsAjaxRequest)
        {
            IFDYearDataBind();
        }
    }

    protected void btnImport_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        if (FUFEXC.HasFile)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConChk"].ToString();
        }
        else
        {
            X.Msg.Alert("提示","请先选择！");
        }
    }

    private void IFDYearDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        int count = dt.Rows.Count;
        if (count > 0)
        {
            txtYear1.Text = dt.Rows[count - 1]["DefaultYear"].ToString();
        }
    }
}