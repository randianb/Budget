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
public partial class WebPage_BudgetEstimate_BEBudgetpayDivide : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cmbPPAData();
        DepDataBind();
        txtshow.Style.Add("color", "red");
    }

    private void cmbPPAData()
    {
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        cmbPPAstore.DataSource = getnewpi(dt);
        cmbPPAstore.DataBind();
    }

    private DataTable getnewpi(DataTable dt)
    {
        System.Data.DataView dv = dt.DefaultView;
        DataTable dtnew = dv.ToTable(true);
        DataRow dr = dtnew.NewRow();
        object[] objs = { "全部" };
        dr.ItemArray = objs;
        dtnew.Rows.InsertAt(dr, 0);
        return dtnew;
    }

    private void DepDataBind()
    {
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        cmbDep.Items.Add(new Ext.Net.ListItem("全局", "0"));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
            cmbDep.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
        }

    }
    protected void submit_DirectClick(object sender, DirectEventArgs e)
    {
        txtshow.Text = "";
        int depid = common.IntSafeConvert(cmbDep.SelectedItem.Value);
        List<object> strlist = new List<object>();
        string depname = "";
        string name = "";
        decimal mon = 0;
        if (depid == 0 && cmbPPA.SelectedItem.Value == "全部")
        {
            DataTable dt = BG_EstimatesAllocationLogic.GetALLEAMon(common.IntSafeConvert(CurrentYear));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    depname = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt.Rows[i]["depid"])).DepName;
            //    name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[i]["PIID"])).PIEcoSubName;
            //    strlist.Add(new { depname = depname, name = name, mon = mon });
            //}
            if (dt.Rows.Count <= 0)
            {
                strlist.Clear();
                string message = "没有查询到数据";
                txtshow.Text = message;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    depname = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt.Rows[i]["DepID"])).DepName;
                    name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[i]["PIID"])).PIEcoSubName;
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BEAMon"].ToString());
                    strlist.Add(new { depname = depname, name = name, mon = mon });
                }
            }
        }
        else if (depid == 0 && cmbPPA.SelectedItem.Value != "全部")
        {
            name = cmbPPA.SelectedItem.Value;
            string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
            string[] slist = bgpi.Split(',');
            DataTable dt1 = new DataTable();
            for (int i = 0; i < slist.Count(); i++)
            {
                int piid = common.IntSafeConvert(slist[i]);
                dt1 = BG_EstimatesAllocationLogic.GetEAMonDTbyPIID(common.IntSafeConvert(CurrentYear), piid);
                if (dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        depname = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt1.Rows[j]["DepID"])).DepName;
                        mon += ParToDecimal.ParToDel(dt1.Rows[j]["BEAMon"].ToString());
                        strlist.Add(new { depname = depname, name = name, mon = mon });
                    }
                }
            }
            if (strlist.Count <= 0)
            {
                strlist.Clear();
                string message = "没有查询到数据";
                txtshow.Text = message;
            }
        }
        else if (depid != 0 && cmbPPA.SelectedItem.Value == "全部")
        {
            depname = cmbDep.SelectedItem.Text;
            DataTable dt = BG_EstimatesAllocationLogic.GetEAMonDTbyDepID(common.IntSafeConvert(CurrentYear), common.IntSafeConvert(cmbDep.SelectedItem.Value));
            if (dt.Rows.Count <= 0)
            {
                strlist.Clear();
                string message = "没有查询到数据";
                txtshow.Text = message;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[i]["PIID"])).PIEcoSubName;
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BEAMon"].ToString());
                    strlist.Add(new { depname = depname, name = name, mon = mon });
                }
            }
        }
        else
        {
            name = cmbPPA.SelectedItem.Value;
            string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
            string[] slist = bgpi.Split(',');
            DataTable dt1 = new DataTable();
            for (int i = 0; i < slist.Count(); i++)
            {
                int piid = common.IntSafeConvert(slist[i]);
                mon += BG_EstimatesAllocationLogic.GetEAMon(depid, piid, common.IntSafeConvert(CurrentYear));
            }
            if (mon <= 0)
            {
                strlist.Clear();
                string message = "没有查询到数据";
                txtshow.Text = message;
            }
            else
            {
                depname = cmbDep.SelectedItem.Text;
                strlist.Add(new { depname = depname, name = name, mon = mon });
            }
        }
        DivideStore.DataSource = strlist;
        DivideStore.DataBind();
    }
}