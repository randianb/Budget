using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using Common;

public partial class WebPage_SysSetting_UnitBaseInfoSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBind();
        }
    }

    private void txtBind()
    {
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            txtUnitName.Text = ss.UnitName;
            txtUnitCode.Text = ss.UnitCode;
            txtYear.Text = ss.SSYear.ToString();
            txtStaffNum.Text = ss.StaffNum.ToString();
        }
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        int ssyear = common.IntSafeConvert(txtYear.Text.Trim());
        int sscout = FA_SysSettingManager.GetSysSettingCountByYear(ssyear);
        if (sscout == 0)
        {
            FA_SysSetting fa = new FA_SysSetting();
            fa.UnitName = txtUnitName.Text.ToString();
            fa.UnitCode = txtUnitCode.Text.ToString();
            fa.SSYear = common.IntSafeConvert(txtYear.Text.Trim());
            fa.StaffNum = common.IntSafeConvert(txtStaffNum.Text.Trim());
            if (FA_SysSettingManager.AddFA_SysSetting(fa).SSID > 0)
            {
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
        else
        {
            FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByYear(ssyear);
            ss.UnitName = txtUnitName.Text.ToString();
            ss.UnitCode = txtUnitCode.Text.ToString();
            ss.SSYear = ssyear;
            ss.StaffNum = common.IntSafeConvert(txtStaffNum.Text.Trim());
            if (FA_SysSettingManager.ModifyFA_SysSetting(ss))
            {
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblShowResult.Text = string.Empty;
         txtBind();
    }
}