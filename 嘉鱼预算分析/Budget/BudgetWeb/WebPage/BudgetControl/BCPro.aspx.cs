using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Ext.Net;
using BudgetWeb.Model;

public partial class WebPage_BudgetControl_BCPro : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProData();
        }
       
    }
    private void ProData()
    {
        //DataTable dt = BGQuotaLogic.GetBGQuota(year);
        DataTable dt = BG_ProjectManager.GetAllBG_Project();
        PayStore.DataSource =dt;
        PayStore.DataBind();
    }
   
    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(int id, string proname, string oldValue, string newValue, object customer)
    {
        string message = "<b>编号:</b> {0}<br /><b>科目:</b> {1}<br /><b>原定额:</b> {2}<br /><b>更改定额:</b> {3}";

        // Send Message...
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "Edit Record #" + id.ToString(),
            Html = string.Format(message, id, proname, oldValue, newValue),
            Width = 250
        }).Show();
        BG_Project pj = BG_ProjectManager.GetBG_ProjectByPJID(id);
        pj.PJName = newValue;
        BG_ProjectManager.ModifyBG_Project(pj);
    }
    protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Show();
    }
    protected void btnWinAdd_DirectClick(object sender, DirectEventArgs e)
    {
        BG_Project pj =new BG_Project();
        pj.PJName = AdName.Text;
        string sqlstr = string.Format("select count(*) from BG_Project where PJName='{0}' ", AdName.Text.Trim());
        if (common.IntSafeConvert(BudgetWeb.DAL.DBUnity.ExecuteScalar(CommandType.Text, sqlstr,null)) > 0)
        {
            X.Msg.Alert("提示","已存在该名称，请修改!").Show();
        }
        BG_ProjectManager.AddBG_Project(pj);
        ProData();
    }
    protected void btnWinCancel_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Hide();
    }
}