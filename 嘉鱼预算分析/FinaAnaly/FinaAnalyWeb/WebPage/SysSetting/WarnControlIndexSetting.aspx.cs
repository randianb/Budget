using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_WarnControlIndexSetting : System.Web.UI.Page
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
        FA_WarningQuota wq = FA_WarningQuotaManager.GetWarningQuotaByYear(DateTime.Now .Year);
        if (wq != null)
        {
            txtYear.Text = wq.WQYear.ToString();
            tbName.Text = wq.YellowWarning.ToString();
            tbOrgan.Text = wq.RedWarning.ToString();
        }
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        int ssyear = common.IntSafeConvert(txtYear.Text.Trim());
        int sscout = FA_WarningQuotaManager.GetWarningQuotaCountByYear(ssyear);
        if (sscout == 0)
        {
            FA_WarningQuota wq = new FA_WarningQuota();
            wq.WQYear = ssyear;
            wq.YellowWarning = tbName.Text;
            wq.RedWarning = tbOrgan.Text;
            if (FA_WarningQuotaManager.AddFA_WarningQuota(wq).WQID > 0)
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
            FA_WarningQuota wq = FA_WarningQuotaManager.GetWarningQuotaByYear(ssyear);
            wq.WQYear = ssyear;
            wq.YellowWarning = tbName.Text;
            wq.RedWarning = tbOrgan.Text;
            if (FA_WarningQuotaManager.ModifyFA_WarningQuota(wq))
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