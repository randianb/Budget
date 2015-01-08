using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_FinAccountConNum : System.Web.UI.Page
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
            lblYear.Text = ss.SSYear.ToString();
        }
        int bcnyear = common.IntSafeConvert(lblYear.Text.Trim());
        FA_AccConNum bcn = FA_AccConNumManager.GetAccConNumByYear(bcnyear);
        HidBBM.Value = bcn.ACNBasExpBudMon .ToString();
        HidPBM.Value = bcn.ACNProExpBudMon .ToString();
        txtBasic.Text = HidBBM.Value;
        txtProject.Text = HidPBM.Value;
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

    protected void btnCon_Click(object sender, EventArgs e)
    {
        int fayear = common.IntSafeConvert(lblYear.Text.Trim());
        int facout = FA_AccConNumManager.GetAccConNumCountByYear(fayear);
        if (facout == 0)
        {
            FA_AccConNum fa = new FA_AccConNum();
            fa.ACNYear = fayear;
            fa.ACNBasExpBudMon = ToDec(txtBasic.Text);
            fa.ACNProExpBudMon = ToDec(txtProject.Text);
            if (FA_AccConNumManager.AddFA_AccConNum(fa).ACID > 0)
            {
                txtBind();
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
        else
        {
            FA_AccConNum fa = FA_AccConNumManager.GetAccConNumByYear(fayear);
            fa.ACNYear = fayear;
            fa.ACNBasExpBudMon = ToDec(txtBasic.Text);
            fa.ACNProExpBudMon = ToDec(txtProject.Text);
            if (FA_AccConNumManager.ModifyFA_AccConNum(fa))
            {
                txtBind();
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        lblShowResult.Text = string.Empty;
        txtBind();
    }
}