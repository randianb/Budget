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

public partial class WebPage_BudgetEstimate_BudgetOverview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private int StrToInt(string str)
    {
        int tmp = 0;
        if (!string.IsNullOrEmpty(str))
        {
            if (Int32.TryParse(str, out tmp))
            {
                tmp = Convert.ToInt32(str);
            }
        }
        return tmp;
    }

    protected void gettext_Event(object sender, DirectEventArgs e)
    {
        int txt3 = StrToInt(para1.Text);
        int txt4 = StrToInt(para2.Text);
        int txt5 = StrToInt(para3.Text);
        int txt1 = StrToInt(para4.Text);
        int txt2 = StrToInt(para5.Text);
        val1.Html = (txt1 - txt2).ToString();
        val4.Html = ((txt1 - txt2) * txt3).ToString();
        val3.Html = ((txt1 - txt2) * txt3 / (0.2)).ToString();
        val2.Html = ((txt1 - txt2) * txt3 / 0.2 + txt3 * txt4 + txt3 * txt5).ToString();
        val5.Html = ((txt4 + txt5) * txt3).ToString();
    }

}