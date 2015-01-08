using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using Common;

public partial class WebPage_SysSetting_PUCIssNumTb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            lblYear.Text = ss.SSYear.ToString();
        }
        if (!IsPostBack)
        {
            repDataBind();
        }
    }

    private void repDataBind()
    {
        DataTable dt = FA_PUCIssNumManager.GetAllFA_PUCIssNum();
        if (dt != null)
        {
            repDepartMon.DataSource = dt;
            repDepartMon.DataBind();
        }
        else
        {
            repDepartMon.DataSource = null;
            repDepartMon.DataBind();
        }
    }

    private Decimal ToDec(object obj)
    {
        Decimal decTmp = 0;
        if (obj != null)
        {
            string objStr = obj.ToString();
            if (!string.IsNullOrEmpty(objStr))
            {
                decTmp = ParseUtil.ToDecimal(objStr, decTmp);
            }
        }
        return decTmp;
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        int yearInt = common.IntSafeConvert(lblYear.Text);
        string depidStrs = HidDepidStrs.Value.TrimEnd(',');
        string monStrs = HidMonStrs.Value.TrimEnd(',');
        string[] depidArr = depidStrs.Split(',');
        string[] monArr = monStrs.Split(',');
        if (depidArr.Length == monArr.Length)
        {
            for (int i = 0; i < depidArr.Length; i++)
            {
                int pudid = common.IntSafeConvert(depidArr[i]);
                FA_PUCIssNum fa = FA_PUCIssNumManager.GetFA_PUCIssNumByPUCID(pudid);
                if (fa != null)
                {
                    fa.PUCMon = ToDec(monArr[i]);
                    FA_PUCIssNumManager.ModifyFA_PUCIssNum(fa);
                }
            }
            repDataBind();
        }
    }
}