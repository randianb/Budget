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

public partial class WebPage_SysSetting_DepBudAllocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBind();
            //int depid = common.IntSafeConvert(ddlDep.SelectedValue);
            //GetDepMon(depid);
            repDataBind();
        }
    }

    private void txtBind()
    {
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            lblYear.Text = ss.SSYear.ToString();
        }
        //显示总金额
        int year = ss.SSYear;
        FA_BudConNum bcn = FA_BudConNumManager.GetBudConNumByYear(year);
        if (bcn != null)
        {
            lblTotalMon.Text = (bcn.BCNBasExpBudMon + bcn.BCNProExpBudMon).ToString();
            lblAddMon.Text = (bcn.BCNBasAddBudMon + bcn.BCNProAddBudMon).ToString();
        }

        //显示余额
        decimal dba = FA_DepBudAllocatManager.GetDepBudAllocatByYear(year);
        // decimal iba = FA_IncomeBudAllocatManager.GetIncomeBudAllocat();
        if (bcn != null)
        {
            lblBalance.Text = (bcn.BCNBasExpBudMon + bcn.BCNProExpBudMon + bcn.BCNBasAddBudMon + bcn.BCNProAddBudMon - dba).ToString();
            //RangeValidator2.MaximumValue = (ParseUtil.ToDecimal(lblBalance.Text, 0) + ParseUtil.ToDecimal(txtMon.Text, 0)).ToString();
        }
    }


    private void repDataBind()
    {
        int year = common.IntSafeConvert(lblYear.Text);
        //DataTable dt = FA_DepBudAllocatManager.GetDepMonAll(year);
        DataTable dt = new DataTable();
        dt.Columns.Add("DepName");
        dt.Columns.Add("DepID");
        dt.Columns.Add("DBAMon");
        DataTable dt1 = FA_DepartmentManager.GetAllFA_Department();
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                int depid = common.IntSafeConvert(dt1.Rows[i]["DepID"]);
                FA_DepBudAllocat fa = FA_DepBudAllocatManager.GetDepMonBydepiddbayear(depid, year);
                decimal dbaMon = 0;
                if (fa != null )
                {
                    dbaMon = fa.DBAMon;
                }
                DataRow dr = dt.NewRow();
                dr["DepID"] = dt1.Rows[i]["DepID"].ToString();
                dr["DepName"] = dt1.Rows[i]["DepName"].ToString();
                if (dbaMon != 0)
                {
                    dr["DBAMon"] = dbaMon;
                }
                dt.Rows.Add(dr);
            }
        }
        if (dt != null && dt.Rows.Count > 0)
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

    //private void  GetDepMon(int depid)
    //{
    //    FA_DepBudAllocat fa = FA_DepBudAllocatManager.GetDepMonByDepid(depid);
    //    if (fa != null)
    //    {
    //        txtMon.Text = fa.DBAMon.ToString();
    //    }
    //    else
    //    {
    //        txtMon.Text = string.Empty;
    //    }
    //}


    //protected void btnCon_Click(object sender, EventArgs e)
    //{
    //    int depid = common.IntSafeConvert(ddlDep.SelectedValue);
    //    if ( FA_DepBudAllocatManager.GetDepBudAllocatByDepid(depid))
    //    {
    //        FA_DepBudAllocat fa = FA_DepBudAllocatManager.GetDepMonByDepid(depid);
    //        fa.DBAMon = ToDec(txtMon.Text);
    //        if (FA_DepBudAllocatManager.ModifyFA_DepBudAllocat(fa))
    //        {
    //            repDataBind();
    //            txtBind();
    //            lblShowResult.Text = "* 修改成功";
    //        }
    //        else
    //        {
    //            lblShowResult.Text = "* 操作失败，请重试";
    //        }
    //    }
    //    else
    //    {
    //        FA_DepBudAllocat fa = new FA_DepBudAllocat();
    //        fa.DepID = depid;
    //        fa.DBAMon = ToDec(txtMon.Text);
    //        fa.DBAYear = common.IntSafeConvert(lblYear.Text.Trim());
    //        if (FA_DepBudAllocatManager.AddFA_DepBudAllocat(fa).DBAID > 0)
    //        {
    //            txtBind();
    //            repDataBind();
    //            lblShowResult.Text = "* 添加成功";
    //        }
    //        else
    //        {
    //            lblShowResult.Text = "* 操作失败，请重试";
    //        }
    //    }
    //}

    //protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int depid = common.IntSafeConvert(ddlDep.SelectedValue);
    //    GetDepMon(depid);
    //}

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

    //protected void btnCan_Click(object sender, EventArgs e)
    //{
    //    lblShowResult.Text = string.Empty;
    //    txtBind();
    //}

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
                int depid = common.IntSafeConvert(depidArr[i]);
                Decimal monTmp = ToDec(monArr[i]);
                FA_DepBudAllocat dbaUpd = FA_DepBudAllocatManager.GetDepMonBydepiddbayear(depid, yearInt);
                if (dbaUpd != null)
                {
                    dbaUpd.DBAMon = monTmp;
                    FA_DepBudAllocatManager.ModifyFA_DepBudAllocat(dbaUpd);
                }
                else
                {
                    FA_DepBudAllocat dbaAdd = new FA_DepBudAllocat();
                    dbaAdd.DBAYear = yearInt;
                    dbaAdd.DepID = depid;
                    dbaAdd.DBAMon = monTmp;
                    FA_DepBudAllocatManager.AddFA_DepBudAllocat(dbaAdd);
                }
            }
            repDataBind();
            txtBind();
        }
    }
    protected void repDepartMon_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "PostToMon")
        {
            int depid = common.IntSafeConvert(e.CommandArgument);

        }
    }
}
