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

public partial class WebPage_Policy_UniformRulesaMod : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //BindHtml = Session["PLURHtml"].ToString();
        //if (Request.QueryString["ctext"].ToString() != "123")
        //{
        //   Response.Redirect("PLUniformRules.aspx", true);
        //}
        if (!IsPostBack)
        {
            btnBack.Hidden = true;
            UniformRulesDataBind();
        }
    }
    private void UniformRulesDataBind()
    {
        DataTable dt = BG_PolicyLogic.GetUniformRulesDT();
        if (dt.Rows.Count > 0)
        {
            string str = dt.Rows[0]["PContent"].ToString();
            HEdit.Text = str; 
        }
    }
    protected void btnMod_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        DataTable dt = BG_PolicyLogic.GetUniformRulesDT();
        string idStr = dt.Rows[0]["PLID"].ToString();
        int PLID = Convert.ToInt32(idStr);
        string str = HEdit.Text;
        BG_Policy bg_Policy = BG_PolicyManager.GetBG_PolicyByPLID(PLID);
        bg_Policy.PContent = str;
        //KJEditor.Html = str;  
        bg_Policy.PTime = DateTime.Now;
        //消息提示 
        BG_PolicyManager.ModifyBG_Policy(bg_Policy);
        UniformRulesDataBind();
        X.Msg.Alert("提示", "修改成功").Show();
        Response.Redirect("PLUniformRules.aspx", true);

    }
    protected void btnBack_DirectClick(object sender, DirectEventArgs e)
    {
        Response.Redirect("PLUniformRules.aspx", true);
    }
}