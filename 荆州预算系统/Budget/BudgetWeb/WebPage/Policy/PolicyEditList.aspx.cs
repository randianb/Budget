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

public partial class WebPage_Policy_PolicyEditList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            PolicyDataBind();
        }

    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void PolicyDataBind()
    {
        DataTable dt = BG_PolicyLogic.GetAllPolicy();
        Store store = this.gridpanel1.GetStore();
        store.DataSource = dt;
        store.DataBind();
    }



    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="plid"></param>
    [DirectMethod]
    public void DelPolicy(string plid)
    {
        int PLID = Convert.ToInt32(plid);
        BG_PolicyManager.DeleteBG_PolicyByID(PLID);
        PolicyDataBind();
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="plid"></param>
    [DirectMethod]
    public void ModifyPolicy(string plid)
    {
        int PLID = Convert.ToInt32(plid);
        BG_Policy bg_policy = BG_PolicyManager.GetBG_PolicyByPLID(PLID);
        TFPTitle.Text = bg_policy.PTitle.ToString();
        TFID.Text = plid;
        TFPOrder.Text = bg_policy.POrder.ToString();
        TFPTime.Text = Convert.ToDateTime(bg_policy.PTime).ToString("yyyy-MM-dd HH:mm:ss");
        TFPFrom.Text = bg_policy.PFrom;
        ADPcmb.Text= bg_policy.PType;
        TFcmb.SelectedItem.Value = bg_policy.PTitle.ToString();
        HEdit.Text = bg_policy.PContent;
        WinEdit.Show();
    }

    /// <summary>
    /// 发布
    /// </summary>
    /// <param name="plid"></param>
    [DirectMethod]
    public void PublishPolicy(string plid)
    {
        int PLID = Convert.ToInt32(plid);
        bool flag = BG_PolicyLogic.PublishAppointPolicy(PLID);
        PolicyDataBind();
    }
    /// <summary>
    /// win弹窗的修改更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnMod_DirectClick(object sender, DirectEventArgs e)
    {
        BG_Policy bg_policy = BG_PolicyManager.GetBG_PolicyByPLID(Convert.ToInt32(TFID.Text));
        bg_policy.POrder = Convert.ToInt32(TFPOrder.Text);
        bg_policy.PTime = Convert.ToDateTime(TFPTime.Text);
        bg_policy.PFrom = TFPFrom.Text;
        bg_policy.PType = TFcmb.SelectedItem.Value.ToString();
        bg_policy.PTitle = TFPTitle.Text;
        bg_policy.PContent = HEdit.Text;
        bg_policy.PStatus = "未发布";
        BG_PolicyManager.ModifyBG_Policy(bg_policy);
        PolicyDataBind();
        WinEdit.Hide();
        TFPOrder.Clear();
        TFPTime.Clear();
        TFPFrom.Clear();
        TFPTitle.Clear();
        //HEdit.Clear();
        //TFPOrder.Text = " ";
        //TFPTime.Text = " ";
        //TFPFrom.Text = " ";
        //TFPType.Text = " ";
        //TFPTitle.Text = " ";
        //HEdit.Text = " "; 
    }
    /// <summary>
    /// win弹窗取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnCanc_DirectClick(object sender, DirectEventArgs e)
    {
        WinEdit.Hide();
    }
    protected void btnAdditemCanc_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Hide();
    }
    /// <summary>
    /// topbtn的添加一条数据，弹出窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Show();
    }
    /// <summary>
    /// 弹窗的添加一条数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdditem_DirectClick(object sender, DirectEventArgs e)
    {
        BG_Policy bg_policy = new BG_Policy();
        try
        {
            bg_policy.POrder = Convert.ToInt32(ADPOrder.Text);
            bg_policy.PTime = Convert.ToDateTime(ADPTime.Text);
            bg_policy.PFrom = ADPFrom.Text;
            bg_policy.PType = ADPcmb.SelectedItem.Value.ToString();
            bg_policy.PTitle = ADPTitle.Text;
            bg_policy.PContent = ADHEdit.Text;
            bg_policy.PStatus = "未发布";
            BG_PolicyManager.AddBG_Policy(bg_policy);
            PolicyDataBind();
            resetform.Reset();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("提示", ex);
        }
        //ADPOrder.Clear();
        //ADPTime.Clear();
        //ADPFrom.Clear();
        //ADPTitle.Clear();
        //ADHEdit.Clear(); 
        //HEdit.Clear();
    }
}