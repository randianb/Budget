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

public partial class WebPage_Policy_PLUniformRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UniformRulesDataBind();
        }
    }
    public string ctext = "";
    private void UniformRulesDataBind()
    {
        DataTable dt = BG_PolicyLogic.GetUniformRulesDT();
        if (dt.Rows.Count > 0)
        {
            string str = dt.Rows[0]["PContent"].ToString();
            //plContent.Html = str;
            //KJEditor.Html = str;
            ctext = str; 
        }
    }


    protected void btnModUR_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        //显示编辑窗
        //WinEdit.Show();
        Response.Redirect("UniformRulesaMod.aspx",true);
    }

    //protected void btnMod_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    //{
    //    DataTable dt = BG_PolicyLogic.GetUniformRulesDT();
    //    string idStr = dt.Rows[0]["PLID"].ToString();
    //    int PLID = Convert.ToInt32(idStr);

    //    string str = HEdit.Text;
    //    BG_Policy bg_Policy = BG_PolicyManager.GetBG_PolicyByPLID(PLID);
    //    //bg_Policy.PContent = str;
    //    //KJEditor.Html = str; 
    //    ctext = str;
    //    bg_Policy.PTime = DateTime.Now;
    //    bool flag = BG_PolicyManager.ModifyBG_Policy(bg_Policy);
    //    if (flag)
    //    {
    //        //消息提示 
    //        UniformRulesDataBind();
    //        WinEdit.Hidden = true;
    //    }
    //}
}