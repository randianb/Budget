using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;

public partial class WebPage_SysSetting_STDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest && !IsPostBack)
        {
            DtDataBind();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void DtDataBind()
    {
        DataTable dt = new DataTable();// BG_DepartmentLogic.GetAllBG_Department();
        dt.Columns.Add("DepNum");

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["DepNum"] = (i + 1).ToString();
            }
            this.Store1.DataSource = dt;
            this.Store1.DataBind();
        }
        else
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "提示",
                Message = "没有查询到指定数据",
                Width = 300,
                Buttons = MessageBox.Button.OK,
                //Multiline = true,
                //AnimEl = this.Button3.ClientID,
                //Fn = new JFunction { Fn = "showResultText" }
            });

        }
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
    //-------------------------------------
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="plid"></param>
    [DirectMethod]
    public void DelDepartment(string depID)
    {
        int DepID = StrToInt(depID);
        //BG_DepartmentManager.DeleteBG_DepartmentByID(DepID);
        DtDataBind();

    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="plid"></param>
    [DirectMethod]
    public void ModifyDepartment(string depID)
    {
        //int DepID = StrToInt(depID);
        //BG_Department dp = BG_DepartmentManager.GetBG_DepartmentByDepID(DepID);
        //hiddepid.Text = DepID.ToString();
        //txtEDName.Text = dp.DepName.ToString();
        //if (dp.DepRem == null)
        //{
        //    txtEDDes.Text = null;
        //}
        //txtEDDes.Text = dp.DepRem.ToString();
        //WinEdit.Show();
    }

    /// <summary>
    /// 增加部门--弹出窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Show();
    }

    protected void btnWinAdd_DirectClick(object sender, DirectEventArgs e)
    {
        if (AdName.Text != null)
        {
            //BG_Department dp = new BG_Department();
            //dp.DepName = AdName.Text.ToString();
            //dp.DepRem = AdDes.Text.ToString();
            //dp.FaDepID = 1083;
            //dp.DepLev = 4;
            //BG_DepartmentManager.AddBG_Department(dp);
            //DtDataBind();
            //resetform.Reset();
        }
        else
        {
            X.Msg.Alert("提示", "部门为必填项").Show();
        }
    }
    protected void btnWinCancel_DirectClick(object sender, DirectEventArgs e)
    {
        Winadd.Close();
    }
    protected void btnMod_DirectClick(object sender, DirectEventArgs e)
    {
        //BG_Department dp = BG_DepartmentManager.GetBG_DepartmentByDepID(StrToInt(hiddepid.Text));
        //dp.DepName = txtEDName.Text.Trim().Replace(",", string.Empty).Replace("，", string.Empty);
        //dp.DepRem = txtEDDes.Text.Trim().Replace(",", string.Empty).Replace("，", string.Empty);
        //BG_DepartmentManager.ModifyBG_Department(dp);
        //txtEDName.Clear();
        //hiddepid.Clear();
        //txtEDDes.Clear();
        //DtDataBind();
        //reset.Reset();
        //WinEdit.Close();
    }
    protected void btnCan_DirectClick(object sender, DirectEventArgs e)
    {
        WinEdit.Close();
    }
}