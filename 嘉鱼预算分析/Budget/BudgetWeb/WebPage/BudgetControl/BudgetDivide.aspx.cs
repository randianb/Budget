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
public partial class WebPage_BudgetControl_BudgetDivide : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtshow.Style.Add("color", "red");
        cmbPPAData();
        DepDataBind();
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
    private void cmbPPAData()
    {
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        cmbPPAstore.DataSource = getnewpi(dt);
        cmbPPAstore.DataBind();
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
        decimal supp = 0;
        if (depid == 0 && cmbPPA.SelectedItem.Value == "全部")
        {
            DataTable dt = BG_BudgetAllocationLogic.GetALLAAMon(common.IntSafeConvert(CurrentYear));
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
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString());
                    supp = ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
                    strlist.Add(new { depname = depname, name = name, mon = mon, supp = supp });
                }
            }
        }
        else if (depid == 0 && cmbPPA.SelectedItem.Value != "全部")
        {
            name = cmbPPA.SelectedItem.Value;
            DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
            string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
            string[] slist = bgpi.Split(',');
            DataTable dt1 = new DataTable();
            for (int i = 0; i < slist.Count(); i++)
            {
                int piid = common.IntSafeConvert(slist[i]);
                dt1 = BG_BudgetAllocationLogic.GetAAMonDTbyPIID(common.IntSafeConvert(CurrentYear), piid);
                if (dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        depname = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt1.Rows[j]["DepID"])).DepName;
                        mon += ParToDecimal.ParToDel(dt1.Rows[j]["BAAMon"].ToString());
                        supp += ParToDecimal.ParToDel(dt1.Rows[j]["SuppMon"].ToString());
                        strlist.Add(new { depname = depname, name = name, mon = mon, supp = supp });
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
            DataTable dt = BG_BudgetAllocationLogic.GetAAMonDTbyDepID(common.IntSafeConvert(CurrentYear), common.IntSafeConvert(cmbDep.SelectedItem.Value));
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
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString());
                    supp = ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
                    strlist.Add(new { depname = depname, name = name, mon = mon, supp = supp });
                }
            }
        }
        else
        {
            name = cmbPPA.SelectedItem.Value;
            string bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
            string[] slist = bgpi.Split(',');
            DataTable dt = new DataTable();
            for (int i = 0; i < slist.Count(); i++)
            {
                int piid = common.IntSafeConvert(slist[i]);
                dt = BG_BudgetAllocationLogic.GetAAMon(depid, piid, common.IntSafeConvert(CurrentYear));
                mon += ParToDecimal.ParToDel(dt.Rows[0]["BAAMon"].ToString());
                supp += ParToDecimal.ParToDel(dt.Rows[0]["SuppMon"].ToString());
            }

            if (dt.Rows.Count <= 0)
            {
                strlist.Clear();
                string message = "没有查询到数据";
                txtshow.Text = message;
            }
            else
            {
                depname = cmbDep.SelectedItem.Text;
                strlist.Add(new { depname = depname, name = name, mon = mon, supp = supp });
            }
        }
        string str = "";
        decimal summon = 0;
        decimal sumsupp = 0;
        for (int i = 0; i < strlist.Count; i++)
        {
            str = strlist[i].ToString();
            summon += Getmon(str, "mon");
            sumsupp += Getmon(str, "supp");
        }
        strlist.Add(new { depname = "总计", name = "", mon = summon, supp = sumsupp });
        DivideStore.DataSource = strlist;
        DivideStore.DataBind();
    }
    private decimal Getmon(string str, string mm)
    { 
        int monend = 0;
        decimal montmp = 0;
        int monindex = str.IndexOf(mm);

        if (mm == "supp")
        {
            monend = str.IndexOf("}", monindex);
            montmp = ParToDecimal.ParToDel(str.Substring(monindex + 6, monend - monindex - 6));
        }
        else if (mm == "mon")
        {
            monend = str.IndexOf(",", monindex);
            montmp = ParToDecimal.ParToDel(str.Substring(monindex + 5, monend - monindex - 5));
        }
        return montmp;
    }
}