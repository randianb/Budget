using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_EcoSubFinAccountDis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBind();
            int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
            GetDepMon(piid);
            repDataBind();
        }
    }

    protected void txtBind()
    {
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            lblYear.Text = ss.SSYear.ToString();
        }
        //显示总金额
        int year = ss.SSYear;
        FA_AccConNum bcn = FA_AccConNumManager.GetAccConNumByYear(year); FA_BudConNumManager.GetBudConNumByYear(year);
        lblTotalMon.Text = (bcn.ACNBasExpBudMon  + bcn.ACNProExpBudMon ).ToString();

        //显示余额
        //decimal dba = FA_DepBudAllocatManager.GetDepBudAllocat();
        decimal iba = FA_IncomeAccAllocatManager.GetIncomeAccAllocat();
        lblBalance.Text = (bcn.ACNBasExpBudMon + bcn.ACNProExpBudMon - iba).ToString();
        RangeValidator2.MaximumValue =( ParseUtil.ToDecimal(lblBalance.Text,0) + ParseUtil.ToDecimal(txtMon.Text,0)).ToString();

        if (rbtnBasePay.Checked)
        {
            DataTable dt = FA_PayIncomeManager.GetPayIncomeByPItype(rbtnBasePay.Text.Trim());
            DDLBind(dt);
            ddlIncome.SelectedValue = dt.Rows[0]["PIID"].ToString();
        }
    }

    private void repDataBind()
    {
        decimal baseDec = 0;
        decimal projDec = 0;
        DataTable dt = FA_IncomeAccAllocatManager.GetIncomeMonAll();
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PIType"].ToString() == "基本支出")
                {
                    baseDec += ParseUtil.ToDecimal(dt.Rows[i]["IAAMon"].ToString(), 0);
                }
                if (dt.Rows[i]["PIType"].ToString() == "项目支出")
                {
                    projDec += ParseUtil.ToDecimal(dt.Rows[i]["IAAMon"].ToString(), 0);
                }
            }
            lblBaseMonTotal.Text = baseDec.ToString("f2");
            lblProjMonTotal.Text = projDec.ToString("f2");
            repIncomeMon.DataSource = dt;
            repIncomeMon.DataBind();
        }
        else
        {
            repIncomeMon.DataSource = null;
            repIncomeMon.DataBind();
        }
    }


    private void DDLBind(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PIEcoSubParID"].ToString() == "0" && dt.Rows[i]["PIType"].ToString() != "项目支出")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
            ddlIncome.DataSource = dt;
            ddlIncome.DataValueField = "PIID";
            ddlIncome.DataTextField = "PIEcoSubName";
            ddlIncome.DataBind();
        }
        else
        {
            ddlIncome.DataSource = null;
            ddlIncome.DataBind();
        }
    }

    protected void btnCon_Click(object sender, EventArgs e)
    {

        int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
        if (FA_IncomeAccAllocatManager.GetIncomeAccAllocatBypiid(piid))
        {
            FA_IncomeAccAllocat fa = FA_IncomeAccAllocatManager.GetIncomeAccAllocatByIncome(piid);
            fa.IAAMon = ToDec(txtMon.Text.Trim());
            if (FA_IncomeAccAllocatManager.ModifyFA_IncomeAccAllocat(fa))
            {
                txtBind();
                repDataBind();
                lblShowResult.Text = "* 修改成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请重试";
            }
        }
        else
        {
            FA_IncomeAccAllocat fa = new FA_IncomeAccAllocat();
            fa.PIID = piid;
            fa.IAAMon = ToDec(txtMon.Text.Trim());
            fa.IAAYear = common.IntSafeConvert(lblYear.Text.Trim());
            if (FA_IncomeAccAllocatManager.AddFA_IncomeAccAllocat(fa).IAAID > 0)
            {
                txtBind();
                repDataBind();
                lblShowResult.Text = "* 添加成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请重试";
            }
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        lblShowResult.Text = string.Empty;
        txtBind();
    }


    protected void ddlIncome_SelectedIndexChanged(object sender, EventArgs e)
    {
        int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
        FA_IncomeAccAllocat icc = FA_IncomeAccAllocatManager.GetIncomeAccAllocatByIncome(piid);
        if (icc != null)
        {
            txtMon.Text = icc.IAAMon.ToString();
        }
        else
        {
            txtMon.Text = string.Empty;
        }

    }
    protected void rbtnBasePay_CheckedChanged(object sender, EventArgs e)
    {
        DataTable dt = FA_PayIncomeManager.GetPayIncomeByPItype(rbtnBasePay.Text.Trim());
        DDLBind(dt);
        int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
        GetDepMon(piid);
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

    protected void rbtnProPay_CheckedChanged(object sender, EventArgs e)
    {
        DataTable dt = FA_PayIncomeManager.GetPayIncomeByPItype(rbtnProPay.Text.Trim());
        DDLBind(dt);
        int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
        GetDepMon(piid);
    }

    private void GetDepMon(int piid)
    {
        FA_IncomeAccAllocat fa = FA_IncomeAccAllocatManager.GetIncomeAccAllocatByIncome(piid);
        if (fa != null)
        {
            txtMon.Text = fa.IAAMon.ToString();
        }
        else
        {
            txtMon.Text = string.Empty;
        }
    }
}
