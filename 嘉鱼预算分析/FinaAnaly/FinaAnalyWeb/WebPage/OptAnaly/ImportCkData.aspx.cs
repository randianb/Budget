using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_OptAnaly_ImportCkData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnImport_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConChk"].ToString();





    }
}