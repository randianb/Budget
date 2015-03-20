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
        List<object> strlist = GetListStr();
       // DivideStore.DataSource = strlist;
       DivideStore.DataSource = GetNewList(strlist);
        DivideStore.DataBind();
    }

    private List<object> GetListStr()
    {
        txtshow.Text = "";
        int depid = common.IntSafeConvert(cmbDep.SelectedItem.Value);
        List<object> strlist = new List<object>();
        int piidflag = 0;
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
                    piidflag = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                    depname = BG_DepartmentManager.GetBG_DepartmentByDepID(common.IntSafeConvert(dt.Rows[i]["DepID"])).DepName;
                    name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt.Rows[i]["PIID"])).PIEcoSubName;
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString());
                    supp = ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
                    strlist.Add(new { piidflag = piidflag, depname = depname, name = name, mon = mon, supp = supp });
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
                        strlist.Add(new { piidflag = piid, depname = depname, name = name, mon = mon, supp = supp });
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
                    piidflag = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                    name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piidflag).PIEcoSubName;
                    mon = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString());
                    supp = ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
                    strlist.Add(new {piidflag=piidflag, depname = depname, name = name, mon = mon, supp = supp });
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
                strlist.Add(new { piidflag = common.IntSafeConvert(slist[0]), depname = depname, name = name, mon = mon, supp = supp });
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
        strlist.Add(new {piidflag=0, depname = "总计", name = "", mon = summon, supp = sumsupp });
        return strlist;
    }
    private List<object> GetNewList(List<object> strlist) 
    { 
        List<object> Listtmp=new List<object>();
        int psub = 0;
        decimal t1 = 0, t2 = 0, t3 = 0, t4 = 0;
        decimal s1 = 0, s2 = 0, s3 = 0, s4 = 0;
        for (int i = 0; i < strlist.Count-1; i++)
        {
            DataTable dttmp = BG_PayIncomeLogic.GetBG_PayIncomeByname(strlist[i].ToString().Split(',')[2].Substring(7).Replace(" ", ""));
            BG_PayIncome pi = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dttmp.Rows[0]["PIID"]));
            psub = pi.PIEcoSubParID;
            if (psub == 0)
            {
                if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("工资福利支出"))
                {
                    t1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "工资福利支出", mon = t1, supp = s1 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("商品和服务支出"))
                {
                    t2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "商品和服务支出", mon = t2, supp = s2 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("对个人和家庭补助支出"))
                {
                    t3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "对个人和家庭补助支出", mon = t3, supp = s3 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("其他资本性支出"))
                {
                    t4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "其他资本性支出", mon = t4, supp = s4 });
                }
            }
            else
            {

                if (psub == 1000 || psub == 1015 || psub == 1051 || psub == 1065)
                {

                    if (psub == 1000)
                    {
                        t1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1015)
                    {
                        t2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1051)
                    {
                        t3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1065)
                    {
                        t4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                }

            }
        }
        Listtmp.Add(new {piidflag=1000, depname = "", name = "工资福利支出", mon = t1, supp = s1 });
        Listtmp.Add(new {piidflag = 1015, depname = "", name = "商品和服务支出", mon = t2, supp = s2 });
        Listtmp.Add(new {piidflag = 1051, depname = "", name = "对个人和家庭补助支出", mon = t3, supp = s3 });
        Listtmp.Add(new {piidflag = 1065, depname = "", name = "其他资本性支出", mon = t4, supp = s4 });
        Listtmp.Add(strlist[strlist.Count-1]);
        return Listtmp;
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



    [DirectMethod]
    public void GetRowexpand(string pisub)
    {
        //DataTable dttmp = BG_PayIncomeLogic.GetBG_PayIncomeByname(pisubName.Replace(" ", ""));
        int psub = common.IntSafeConvert(pisub);
        if (psub == 1000 || psub == 1015 || psub == 1051 || psub == 1065)
        {
            if (psub == 1000)
            {
                if (common.IntSafeConvert(Session["1000"]) == 1)
                {
                    Session["1000"] = 0;
                }
                else
                { Session["1000"] = 1; }
            }
            if (psub == 1015)
            {
                if (common.IntSafeConvert(Session["1015"]) == 1)
                {
                    Session["1015"] = 0;
                }
                else
                { Session["1015"] = 1; }
            }
            if (psub == 1051)
            {
                if (common.IntSafeConvert(Session["1051"]) == 1)
                {
                    Session["1051"] = 0;
                }
                else
                { Session["1051"] = 1; }
            }
            if (psub == 1065)
            {
                if (common.IntSafeConvert(Session["1065"]) == 1)
                {
                    Session["1065"] = 0;
                }
                else
                { Session["1065"] = 1; }
            }

            if (common.IntSafeConvert(Session[pisub]) == 0)
            {
                List<object> strlist = GetListStr();
                DivideStore.DataSource = GetNewList(strlist);
                DivideStore.DataBind();
            }
            else
            {
                List<object> strlist = GetListStr();
                DivideStore.DataSource = GetNewList(strlist,psub);
                DivideStore.DataBind();
            }
           
        }
        else
        {
            return;
        }
    }

    private object GetNewList(List<object> strlist,int piid)
    {
        List<object> Listtmp = new List<object>();
        int psub = 0;
        decimal t1 = 0, t2 = 0, t3 = 0, t4 = 0;
        decimal s1 = 0, s2 = 0, s3 = 0, s4 = 0;
        for (int i = 0; i < strlist.Count - 1; i++)
        {
            DataTable dttmp = BG_PayIncomeLogic.GetBG_PayIncomeByname(strlist[i].ToString().Split(',')[2].Substring(7).Replace(" ", ""));
            BG_PayIncome pi = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dttmp.Rows[0]["PIID"]));
            psub = pi.PIEcoSubParID;
            if (psub == 0)
            {
                if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("工资福利支出"))
                {
                    t1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "工资福利支出", mon = t1, supp = s1 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("商品和服务支出"))
                {
                    t2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "商品和服务支出", mon = t2, supp = s2 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("对个人和家庭补助支出"))
                {
                    t3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "对个人和家庭补助支出", mon = t3, supp = s3 });

                }
                else if (strlist[i].ToString().Split(',')[2].Substring(7).Contains("其他资本性支出"))
                {
                    t4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                    s4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    //Listtmp.Add(new { depname = "", name = "其他资本性支出", mon = t4, supp = s4 });
                }
            }
            else
            {

                if (psub == 1000 || psub == 1015 || psub == 1051 || psub == 1065)
                {

                    if (psub == 1000)
                    {
                        t1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s1 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1015)
                    {
                        t2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s2 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1051)
                    {
                        t3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s3 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                    if (psub == 1065)
                    {
                        t4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[3].Substring(6));
                        s4 += ParToDecimal.ParToDel(strlist[i].ToString().Split(',')[4].Substring(7).Replace("}", ""));
                    }
                }

            }
        }
        Listtmp.Add(new { piidflag = 1000, depname = "", name = "工资福利支出", mon = t1, supp = s1 });
        Listtmp.Add(new { piidflag = 1015, depname = "", name = "商品和服务支出", mon = t2, supp = s2 });
        Listtmp.Add(new { piidflag = 1051, depname = "", name = "对个人和家庭补助支出", mon = t3, supp = s3 });
        Listtmp.Add(new { piidflag = 1065, depname = "", name = "其他资本性支出", mon = t4, supp = s4 });
        List<object> getleaf = GetLeafList(strlist, piid);
        if (piid==1000)
        {
            for (int i = 0; i < getleaf.Count; i++)
            {
                Listtmp.Insert(1+i, getleaf[i]);
            }
        }
        if (piid==1015)
        {
            for (int i = 0; i < getleaf.Count; i++)
            {
                Listtmp.Insert(2+i, getleaf[i]);
            }
            
        }
        if (piid==1051)
        {
            for (int i = 0; i < getleaf.Count; i++)
            {
                Listtmp.Insert(3 + i, getleaf[i]);
            }
        }
        if (piid==1065)
        {
            for (int i = 0; i < getleaf.Count; i++)
            {
                Listtmp.Insert(4 + i, getleaf[i]);
            }
        }
        Listtmp.Add(strlist[strlist.Count - 1]);
        return Listtmp;
    }

    private static List<object> GetLeafList(List<object> strlist, int piid)
    {
        List<object> getleaf = new List<object>();
        for (int i = 0; i < strlist.Count - 1; i++)
        {
            DataTable dttmp = BG_PayIncomeLogic.GetBG_PayIncomeByname(strlist[i].ToString().Split(',')[2].Substring(7).Replace(" ", ""));
            BG_PayIncome pi = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dttmp.Rows[0]["PIID"]));
            int psubtmp = pi.PIEcoSubParID;
            if (psubtmp == piid)
            {
                getleaf.Add(strlist[i]);
            }
        }
        return getleaf;
    }
}