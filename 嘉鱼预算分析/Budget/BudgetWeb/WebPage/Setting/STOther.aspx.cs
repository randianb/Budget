using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.Model;
using BudgetWeb.BLL;

public partial class WebPage_Setting_STOther : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            STDataBind();
        }
    }

    private void STDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        int count = dt.Rows.Count;
        if (count > 0)
        {
            hidID.Value = dt.Rows[count - 1]["SSID"].ToString();
            TFSysName.Text = dt.Rows[count - 1]["SysName"].ToString();
            TFDefaultYear.Text = dt.Rows[count - 1]["DefaultYear"].ToString();
            TFPopNum.Text = dt.Rows[count - 1]["PepNum"].ToString();
        }
    }
    protected void btnSure_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        int count = dt.Rows.Count;
        int curtime = Convert.ToInt32(dt.Rows[count - 1]["DefaultYear"].ToString());
        if (Convert.ToInt32(TFDefaultYear.Text.Trim()) > curtime)
        {
            BG_SysSetting bg_sys = new BG_SysSetting();
            bg_sys.SSID = Convert.ToInt32(hidID.Value);
            bg_sys.SysName = TFSysName.Text.Trim();
            bg_sys.DefaultYear = Convert.ToInt32(TFDefaultYear.Text.Trim());
            bg_sys.PepNum = Convert.ToInt32(TFPopNum.Text.Trim());
            BG_SysSettingManager.AddBG_SysSetting(bg_sys);
            X.Msg.Alert("提示", "添加成功!").Show();
        }
        else
        { 
            BG_SysSetting bg_sys = new BG_SysSetting();
            bg_sys.SSID = Convert.ToInt32(hidID.Value);
            bg_sys.SysName = TFSysName.Text.Trim();
            bg_sys.DefaultYear = Convert.ToInt32(TFDefaultYear.Text.Trim());
            bg_sys.PepNum = Convert.ToInt32(TFPopNum.Text.Trim());
            bool flag = BG_SysSettingManager.ModifyBG_SysSetting(bg_sys);
            if (flag)
            {
                X.Msg.Alert("提示", "修改成功!").Show();
            }
            else
            {
                X.Msg.Alert("提示", "修改失败，请与管理员联系!").Show();
            }
        }
    }
}