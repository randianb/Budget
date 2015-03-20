using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using BudgetWeb.Model;
using Ext.Net;
using Common;
using Ext.Net;

public partial class BudgetPage_mainPages_FinAudit : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepDataBind();
            MonthDataBind();
            //getpici();
            cmbmonth.SelectedItem.Text = DateTime.Now.Month.ToString();
            if (Request["depid"]!= null&&Request["pici"]!= null&&Request["time"]!= null)
            {
                string time = "";
                int depid = 0, pici=0, Year=0, Month=0;
                if (Request["depid"]!= null)
                {
                    depid = common.IntSafeConvert(Request["depid"]);
                }
                if (Request["pici"]!= null)
                {
                    pici = common.IntSafeConvert(Request["pici"]);
                }
                if (Request["time"]!= null)
                {
                    time = Request["time"].ToString();
                }
                DateTime mydate=new DateTime();
                try
                {
                    mydate = Convert.ToDateTime(time);
                }
                catch
                {
                    mydate = DateTime.Now;
                }
                Year = mydate.Year;
                Month = mydate.Month;
                AuditStoreBind1(depid, Year, Month, pici);

              
            }
            DataTable dt = BG_SelMonPayPlanLogic.GetMonPayPlanTotalAudit(0);
            GTPdbsxStore.DataSource = dt;
            GTPdbsxStore.DataBind();
        }

    }
    [DirectMethod]
    public void DB(string depid, string time, string pici)
    {
        string str1 = "FinAudit.aspx?depid={0}&&time={1}&&pici={2}";
        string url = string.Format(str1, depid, time, pici);
        Response.Redirect(url, true); 
        //        string YearMonth = Convert.ToDateTime(time).ToString("yyyy-MM"); 
        //if (hidsta.Value.ToString() == "0")
        //{
        //    string str1 = "FinAudit.aspx?depid={0}&&time={1}&&pici={2}";
        //    string url = string.Format(str1, depid, time, pici);
        //    Response.Redirect(url, true);
        //}
        //if (hidsta.Value.ToString() == "1")
        //{
        //    string str2 = "ChaSecAudit.aspx?depid={0}&&time={1}&&pici={2}";
        //    string url = string.Format(str2, depid, time, pici);
        //    Response.Redirect(url, true);
        //}
    }
    private void AuditStoreBind1(int depid, int year, int month, int pici)
    {
        cmbdept.SelectedItem.Value = depid.ToString();
        cmbyear.SelectedItem.Value = year.ToString();
        cmbmonth.SelectedItem.Value = month.ToString();
        cmbpici.SelectedItem.Value = pici.ToString();
        DataTable dt = BG_FinAuditLogic.GetFinAudit1(depid, year, month, pici);
        AuditStore.DataSource = Getnew1(dt);
        AuditStore.DataBind();
        if (dt.Rows.Count <= 1)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    }
    //private void getpici()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        cmbpici.Items.Add(new Ext.Net.ListItem((i+1).ToString(), (i+1).ToString()));
    //    }
    //}
    private void MonthDataBind()
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

    private void DepDataBind()
    {
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
            cmbdept.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
        }
    }
    private void AuditStoreBind()
    {
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value.ToString());
        int month = common.IntSafeConvert(cmbmonth.SelectedItem.Value.ToString());
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_FinAuditLogic.GetFinAudit(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
        AuditStore.DataSource = Getnew(dt);
        AuditStore.DataBind();
        if (dt.Rows.Count <= 1)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    }
    private void getBind()
    {
        if (hidflag.Text == "1")
        {
            AuditStoreBind();
        }
        else
        {
            AuditStoreBind1();
        }
    }
    private void AuditStoreBind1()
    {
        int year = common.IntSafeConvert(cmbyear.SelectedItem.Value.ToString());
        int month = common.IntSafeConvert(cmbmonth.SelectedItem.Value.ToString());
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_FinAuditLogic.GetFinAudit1(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
        AuditStore.DataSource = Getnew1(dt);
        AuditStore.DataBind();
        if (dt.Rows.Count <= 1)
        {
            X.Msg.Alert("提示", "没有查询到数据").Show();
        }
    }
    private DataTable Getnew1(DataTable dt)
    {
        decimal mon = 0;
        string  str="";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["MASta"] = "未审核";
            str=dt.Rows[i]["PIEcoSubName"].ToString() ;
            if (str == "工资福利支出" || str == "商品和服务支出" || str == "对个人和家庭补助支出" || str == "其他资本性支出")
            {
                mon += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
            }
        }
        DataRow drRow = dt.NewRow();
        drRow["DepName"] = "总计";
        drRow["MPFunding"] = mon;
        dt.Rows.Add(drRow);
        return dt;
    }
    [DirectMethod]
    public void GetRowexpand(string pisubid)
    {
        int psub = common.IntSafeConvert(pisubid);
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
            int year = common.IntSafeConvert(cmbyear.SelectedItem.Value.ToString());
            int month = common.IntSafeConvert(cmbmonth.SelectedItem.Value.ToString());
            int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
            DataTable dt = BG_FinAuditLogic.GetFinAudit(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
            DataRow[] drlist = dt.Select(" PIEcoSubParID=" + pisubid + " ");
            DataTable dtbase = BG_FinAuditLogic.GetFinAudit1(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
            if (common.IntSafeConvert(Session[pisubid]) == 0)
            {
                AuditStore.DataSource = Getnew1(dtbase);
                AuditStore.DataBind();
            }
            else
            {
                int t = 0;
                for (int j = 0; j < dtbase.Rows.Count; j++)
                {
                    if (common.IntSafeConvert(dtbase.Rows[j]["PIEcoSubParID"]) == psub)
                    {
                        t = j + 1;
                    }
                }
                for (int i = 0; i < drlist.Length; i++)
                {
                    DataRow row = dtbase.NewRow();
                    //设定行中的值
                    row["PIEcoSubParID"] = drlist[i]["PIEcoSubParID"];
                    row["DepName"] = drlist[i]["DepName"];
                    row["PIEcoSubName"] = drlist[i]["PIEcoSubName"];
                    row["MPFunding"] = drlist[i]["MPFunding"];
                    row["MASta"] = drlist[i]["MASta"];
                    dtbase.Rows.InsertAt(row, t++);
                }
                AuditStore.DataSource = Getnew1(dtbase);
                AuditStore.DataBind();
            }
        }
        else
        {
            return;
        }
    }
    private DataTable Getnew(DataTable dt)
    {
        decimal mon = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            mon += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
            if (dt.Rows[i]["PIEcoSubParID"].ToString().Contains("1000"))
            {
                dt.Rows[i]["PIEcoSubName"] = "工资福利支出/" + dt.Rows[i]["PIEcoSubName"].ToString();
            }
            if (dt.Rows[i]["PIEcoSubParID"].ToString().Contains("1015"))
            {
                dt.Rows[i]["PIEcoSubName"] = "商品和服务支出/" + dt.Rows[i]["PIEcoSubName"].ToString();
            }
            if (dt.Rows[i]["PIEcoSubParID"].ToString().Contains("1051"))
            {
                dt.Rows[i]["PIEcoSubName"] = "对个人和家庭补助支出/" + dt.Rows[i]["PIEcoSubName"].ToString();
            }
            if (dt.Rows[i]["PIEcoSubParID"].ToString().Contains("1065"))
            {
                dt.Rows[i]["PIEcoSubName"] = "其他资本性支出/" + dt.Rows[i]["PIEcoSubName"].ToString();
            }
        }
        DataRow drRow = dt.NewRow();
        drRow["DepName"] = "总计";
        drRow["MPFunding"] = mon;
        dt.Rows.Add(drRow);
        return dt;
    }
    protected void submit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        getBind();
    }
    protected void btnSel_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        string Month= month> 9 ? month.ToString() :"0" + month.ToString();
        string YearMonth = year.ToString() + "-" + Month;
        DataTable dt = BG_FinAuditLogic.GetFinAudit(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有可选数据").Show();

        }
        else
        {
            BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
            mppr.MASta = "退回";
            mppr.MACause = txtReason.Text;
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
            DataTable paydt= BG_MonPayPlanGenerateLogic.GetMonPayTimepici(YearMonth, depid, common.IntSafeConvert(cmbpici.SelectedItem.Text));
            for (int i = 0; i < paydt.Rows.Count; i++)
            {
                BG_MonPayPlan_His bgMonPayPlanHis = new BG_MonPayPlan_His();
                bgMonPayPlanHis.CPID = common.IntSafeConvert(paydt.Rows[i]["CPID"]);
                bgMonPayPlanHis.DeptID =depid;
                bgMonPayPlanHis.MPFunding =ParseUtil.ToDecimal(paydt.Rows[i]["MPFunding"].ToString(),0);
                bgMonPayPlanHis.MPPHisTime = DateTime.Now;
                bgMonPayPlanHis.PIID = common.IntSafeConvert(paydt.Rows[i]["PIID"]);
                bgMonPayPlanHis.MPRemark = "退回";
                bgMonPayPlanHis.MPFundingAdd = ParseUtil.ToDecimal(paydt.Rows[i]["MPFundingAdd"].ToString(),0);
                bgMonPayPlanHis.MPTime = Convert.ToDateTime(paydt.Rows[i]["MPTime"]);
                bgMonPayPlanHis.MPFundingAddTimes =common.IntSafeConvert(paydt.Rows[i]["MPFundingAddTimes"]);
                BG_MonPayPlan_HisManager.AddBG_MonPayPlan_His(bgMonPayPlanHis);
            }
           
        }
        DepDataBind();
        MonthDataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(cmbyear.SelectedItem.Value);
        int month = Convert.ToInt32(cmbmonth.SelectedItem.Value);
        int depid = common.IntSafeConvert(cmbdept.SelectedItem.Value.ToString());
        DataTable dt = BG_FinAuditLogic.GetFinAudit(depid, year, month, common.IntSafeConvert(cmbpici.SelectedItem.Text));
        if (dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "没有可选数据").Show();
        }
        else
        {
            BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(Convert.ToInt32(dt.Rows[0]["PRID"]));
            mppr.MASta = "提交";
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
        }
        DepDataBind();
        MonthDataBind();
    }

    protected void qh_DirectClick(object sender, DirectEventArgs e)
    {
        if (hidflag.Text == "1")
        {
            hidflag.Text = "2";
        }
        else
        {
            hidflag.Text = "1";
        }
    }
}

//    private void repBudConSuDataBind(int maMonth)
//    {
//        DataTable dt = VMonPayPlanIncomeManager.GetvMonPayPlanIncomeWBySta(maMonth);
//        //if (dt.Rows.Count > 0)
//        //{
//        repBudConSu.DataSource = dt;
//        repBudConSu.DataBind();
//        //}
//    } 

//    private void repReimAppListBind()
//    {
//        repBudConSu.DataBind();
//    }
//    protected void btnSearch_Click(object sender, EventArgs e)
//    {
//        repBudConSuDataBind(common.IntSafeConvert(ddlMon.SelectedValue));
//    }
//}