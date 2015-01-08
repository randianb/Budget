using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;

public partial class WebPage_BudgetExecute_ApplyLimit : BudgetBasePage
{
    public int depid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        depid = DepID;
        if (!IsPostBack)
        {
            YearDataBind();
            DepDataBind();
            cmbmonth.SelectedItem.Text = DateTime.Now.Month.ToString();
        }
    }

    private void YearDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Year");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add("");
            dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        }
        cmbyearstore.DataSource = dt1;
        cmbyearstore.DataBind();
    }

    protected void btnsure_DirectClick(object sender, DirectEventArgs e)
    {
        ApplyLimitStoreBind();
    }

    private void DepDataBind()
    {
        DataTable dt = new DataTable(); //BGDepartmentManager.GetDepByfadepid(depid);
        if (UserLimStr == "录入员")
        {
            cmbDep.Text = BG_DepartmentManager.GetBG_DepartmentByDepID(depid).DepName;
            Execute.Hidden = false;
        }
        else
        {
            cmbDep.Enable(true);
            dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
            cmbDep.Items.Add(new Ext.Net.ListItem("全局", "0"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
                cmbDep.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
            }
        }
    }


    private void ApplyLimitStoreBind()
    {
        int month = common.IntSafeConvert(cmbmonth.SelectedItem.Value);
        string months = "";
//        if (month == 1)
//        {
//            X.Msg.Alert("提示", "一月无法查询").Show();
//        }
//        else 
        if (month - 1 < 10)
        {
            months = "0" + (month - 1).ToString();
        }
        else
        {
            months = (month - 1).ToString();
        }
        string yearMonth = cmbyear.SelectedItem.Value + "-" + months;
        string now = cmbyear.SelectedItem.Value + "-" + cmbmonth.SelectedItem.Value;
        decimal total = 0;
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        for (int i = 0; i < dtpay.Rows.Count; i++)
        {
            total += ParToDecimal.ParToDel(dtpay.Rows[i][1].ToString()) + ParToDecimal.ParToDel(dtpay.Rows[i][2].ToString());
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("depName"); 
        dt.Columns.Add("totalBG");
        dt.Columns.Add("LastmonthBalance");
        dt.Columns.Add("Application");
        dt.Columns.Add("CurrentAvailable");
        dt.Columns.Add("Execute");
        if ((UserLimStr == "录入员"))
        {
            Execute.Hidden = false;
            DataRow dr = dt.NewRow();
            dr["depName"] =
                BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(depid)).DepName;
            dr["totalBG"] = total*10000;
            decimal sq = BG_MonPayPlanGenerateLogic.GetsqMont(now,
                depid);
           //decimal sx = BG_MonPayPlanGenerateLogic.GetbxMon(now,depid);
            dr["LastmonthBalance"] = (total-sq)*10000;
            decimal s_q = BG_MonPayPlanGenerateLogic.GetsqMon(now, depid);
            dr["Application"] = s_q * 10000;
            decimal extdc = 0;
            if (!BG_ApplyReimburLogic.ISApplyBackMon(yearMonth, DepID))
            {
                extdc = BG_ApplyReimburLogic.ApplyMon(now, DepID);
            }
            else
            {
                extdc =BG_ApplyReimburLogic.ApplyMon(now, DepID) -
                        BG_ApplyReimburLogic.ApplyBackMon(yearMonth, DepID);
            }
            dr["Execute"] = extdc * 10000;
            dr["CurrentAvailable"] = (sq - extdc) * 10000;
                                     
            dt.Rows.Add(dr);
        }
        else
        {
            int deptid = 0;
            deptid = common.IntSafeConvert(cmbDep.SelectedItem.Value);

            if (deptid > 0)
            {
                DataRow dr = dt.NewRow();
                dr["depName"] =
                    BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(deptid)).DepName;
                dr["totalBG"] = total*10000;
                decimal sq = BG_MonPayPlanGenerateLogic.GetsqMont(yearMonth, deptid);
               //decimal sx = BG_MonPayPlanGenerateLogic.GetbxMon(yearMonth,deptid);
                dr["LastmonthBalance"] =  (total-sq)*10000;
                decimal s_q = BG_MonPayPlanGenerateLogic.GetsqMon(now, deptid);
                dr["Application"] = s_q * 10000;
                dr["CurrentAvailable"] =( sq)*10000;
                dt.Rows.Add(dr);
            }
            else
            {
                DataTable dtdep = BG_MonPayPlanGenerateLogic.GetMonByTime(yearMonth);
                if (dtdep == null)
                {
                }
                else
                {
                    for (int i = 0; i < dtdep.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["depName"] =
                            BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dtdep.Rows[i]["Deptid"]))
                                .DepName;
                        dr["totalBG"] = total*10000;
                        decimal sq = BG_MonPayPlanGenerateLogic.GetsqMont(yearMonth,
                            common.IntSafeConvert(dtdep.Rows[i]["Deptid"]));
                       //decimal sx = BG_MonPayPlanGenerateLogic.GetbxMon(yearMonth, common.IntSafeConvert(dtdep.Rows[i]["Deptid"]));
                        dr["LastmonthBalance"] = (total - sq) * 10000;
                        decimal s_q = BG_MonPayPlanGenerateLogic.GetsqMon(now,
                            common.IntSafeConvert(dtdep.Rows[i]["Deptid"]));
                        dr["Application"] = s_q * 10000;
                        dr["CurrentAvailable"] =( sq)*10000;
                        dt.Rows.Add(dr);
                    }
                }
            }
        }
        if (dt.Rows.Count == 0)
        {
            X.Msg.Alert("提示", yearMonth + "没有查询到数据！").Show();
        }
        ApplyLimit.DataSource = dt;
        ApplyLimit.DataBind();
    }
}