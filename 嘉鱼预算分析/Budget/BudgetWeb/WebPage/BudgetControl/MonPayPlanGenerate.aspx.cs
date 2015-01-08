using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWeb.BLL;
using Common;
using BudgetWeb.DAL;
using Ext.Net;
using BudgetWeb.Model;

public partial class BudgetPage_mainPages_MonPayPlanGenerate : BudgetBasePage
{
    int depid = 1106;
    decimal bal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Incomebalance.Style.Add("color", "red");
        depid = DepID;
        if (!X.IsAjaxRequest && !IsPostBack)
        {

            //Getmonth();
            cmbmon.SelectedItem.Index = 0;
            MonPlanBind(depid);
        }
        Getmonth(); 
    }

    private void Getmonth()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("month");
        int mon = BG_MonPayPlanLogic.GetmonthbyMonPayPlan(depid) + 1;

        if (mon < 11)
        {
            for (int i = mon; i > 0; i--)
            {
                DataRow dr = dt.NewRow();
                dr["month"] = "0" + i.ToString();
                dt.Rows.Add(dr);
            }
        }
        else
        {
            for (int i = mon; i > 0; i--)
            {
                DataRow dr = dt.NewRow();
                dr["month"] = i.ToString();
                dt.Rows.Add(dr);
            }
        }
        cmbmonstore.DataSource = dt;
        cmbmonstore.DataBind();
    }

    private void MonPlanBind(int depid)
    {
        //if (string.IsNullOrEmpty(cmbmon.SelectedItem.Value))
        //    return; 
        string YearMonth = "";
        if (cmbmon.SelectedItem.Value == null)
        {
            YearMonth = CurrentYear + "-" + cmbmon.Text;
        }
        else
        {
            YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        }

        DataTable dtmp = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), depid);
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        DataTable dtpayincome = BG_PayIncomeManager.GetAllBG_PayIncome();
        Session["Month"] = cmbmon.SelectedItem.Value;
        bool flag = BG_MonPayPlanGenerateLogic.ISMonlatePay(YearMonth, depid);
        DataTable dt2 = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, depid);
        dt.Columns.Add("BAAMon");
        dt.Columns.Add("SuppMon");
        dt.Columns.Add("PIEcoSubParID");
        dt.Columns.Add("PIID");
        dt.Columns.Add("PIEd");
        DataColumn myDataColumn = new DataColumn();
        myDataColumn.DataType = System.Type.GetType("System.Double");
        myDataColumn.ColumnName = "Balance";
        dt.Columns.Add(myDataColumn);
        dt.Columns.Add("CPID");
        dt.Columns.Add("Mon", typeof(decimal)); 
        if (dtmp.Rows.Count > 0)
        {
            GetNewDT(dtmp, dt, dtpayincome);
        }
        else
        {
            X.Msg.Alert("提示", "本年度未分配金额,请在分配后再填写.").Show();
            gridpanel1.Hidden = true; 
            return;
        }

        if (dt2.Rows.Count == 0)
        {
            MonPlanStoreTable(dt, 1);
        }
        else
        { 
            if (flag)
            {
                MonPlanStoreTable(dt, dt2);
            }
        }
    }
    private void MonPlanStoreTable(DataTable dt, DataTable dt2)
    {
        MonPlanStoreTable(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt2.Rows.Count > 0)
            {
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    string piidname = dt.Rows[i]["PIEcoSubName"].ToString();
                    string ppidname = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt2.Rows[j]["PIID"])).PIEcoSubName.ToString();
                    if (ppidname == piidname)
                    {
                        dt.Rows[i]["PIEd"] = dt2.Rows[j]["MPFunding"].ToString();

                        dt.Rows[i]["CPID"] = dt2.Rows[j]["CPID"].ToString();

                        //dt.Rows[i]["Balance"] = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString()) - ParToDecimal.ParToDel(dt.Rows[i]["PIEd"].ToString());
                        break;
                    }
                    else
                    {
                        dt.Rows[i]["PIEd"] = "";
                        dt.Rows[i]["CPID"] = 0;
                    }
                }
            }
            //dt.Rows[i]["Balance"] = dt.Rows[i]["Mon"].ToString();
        }
        StoreBind(dt);
    }

    private static void GetNewDT(DataTable dtmp, DataTable dt, DataTable dtpayincome)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string drselect = string.Format("PIEcoSubName='{0}'", dt.Rows[i]["PIEcoSubName"].ToString());
            DataRow[] drpay = dtmp.Select(drselect);
            DataRow[] payincome = dtpayincome.Select(drselect);
            if (payincome.Length > 0)
            {
                dt.Rows[i]["PIEcoSubParID"] = payincome[0]["PIEcoSubParID"];
                dt.Rows[i]["PIID"] = payincome[0]["PIID"];
            }
            if (drpay.Length > 0)
            {
                dt.Rows[i]["BAAMon"] = drpay[0]["BAAMon"];
                dt.Rows[i]["SuppMon"] = drpay[0]["SuppMon"];
            }
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Mon"] = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString()) + ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
        }
    }
    private void MonPlanStoreTable(DataTable dt, int t)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Balance"] = dt.Rows[i]["Mon"];
        }
        StoreBind(dt);
    }
    private void MonPlanStoreTable(DataTable dt)
    {

        //decimal balance = 0;
        //if (dt1.Rows.Count == 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dt.Rows[i]["Balance"] = dt.Rows[i]["Mon"];
        //        //////////////////////////////////////////////////////////////////////////
        //        //if (dt2.Rows.Count > 0)
        //        //{
        //        //    for (int j = 0; j < dt2.Rows.Count; j++)
        //        //    {
        //        //        string piidname = dt.Rows[i]["PIEcoSubName"].ToString();
        //        //        string ppidname = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt2.Rows[j]["PIID"])).PIEcoSubName.ToString();
        //        //        if (ppidname == piidname)
        //        //        {
        //        //            dt.Rows[i]["PIEd"] = dt2.Rows[j]["MPFunding"].ToString();

        //        //            dt.Rows[i]["CPID"] = dt2.Rows[j]["CPID"].ToString();
        //        //            break;
        //        //        }
        //        //        else
        //        //        {
        //        //            dt.Rows[i]["PIEd"] = "";
        //        //            dt.Rows[i]["CPID"] = 0;
        //        //        }
        //        //    }
        //        //}
        //    }
        //    //for (int i = 0; i < dt.Rows.Count; i++)
        //    //{
        //    //    dt.Rows[i]["Balance"] = dt.Rows[i]["Mon"];
        //    //    DataRow[] arr = dt2.Select("PIEcoSubName=" + dt.Rows[i]["PIEcoSubName"].ToString());
        //    //    if (arr.Length > 0)
        //    //    {
        //    //        dt.Rows[i]["PIEd"] = arr[0]["MPFunding"].ToString();

        //    //        dt.Rows[i]["CPID"] = arr[0]["CPID"].ToString();
        //    //    }
        //    //    else
        //    //    {
        //    //        dt.Rows[i]["PIEd"] = "";
        //    //        dt.Rows[i]["CPID"] = 0;
        //    //    }

        //    //}
        //}
        //else
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows[i]["Mon"].ToString().Length <= 0)
        //        {
        //            balance = 0;
        //            dt.Rows[i]["PIEd"] = "";
        //            dt.Rows[i]["CPID"] = 0;
        //        }
        //        else
        //        {
        //            string piidname = dt.Rows[i]["PIEcoSubName"].ToString();
        //            if (dt1.Rows.Count > 0)
        //            {
        //                for (int j = 0; j < dt1.Rows.Count; j++)
        //                {
        //                    string ppidname = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt1.Rows[j]["PPID"])).PIEcoSubName.ToString();
        //                    if (ppidname == piidname)
        //                    {
        //                        balance = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString()) - ParToDecimal.ParToDel(dt1.Rows[j]["Armon"].ToString()) / 10000;
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        balance = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString());
        //                    }
        //                }

        //                //BG_PayIncome bgpi = BG_BudItemsLogic.GetBG_PayIncomeByname(name);
        //                //int piid = bgpi.PIID;
        //                //string sname = string.Format("ppid="+ piid);
        //                //DataRow[] arr = dt1.Select(sname);
        //                //if (arr.Length > 0)
        //                //{
        //                //    if (arr[0]["Armon"].ToString().Length <= 0)
        //                //    {
        //                //        balance = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString());
        //                //    }
        //                //    else
        //                //    {
        //                //        balance = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString()) - ParToDecimal.ParToDel(arr[0]["Armon"].ToString())/10000;
        //                //    }

        //                //}
        //                //else
        //                //{
        //                //    balance = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString());
        //                //}
        //                //////////////////////////////////////////////////////////////////////////
        //                //if (dt2.Rows.Count > 0)
        //                //{
        //                //    for (int j = 0; j < dt2.Rows.Count; j++)
        //                //    {
        //                //        string ppidname = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(dt2.Rows[j]["PIID"])).PIEcoSubName.ToString();
        //                //        if (ppidname == piidname)
        //                //        {
        //                //            dt.Rows[i]["PIEd"] = dt2.Rows[j]["MPFunding"].ToString();

        //                //            dt.Rows[i]["CPID"] = dt2.Rows[j]["CPID"].ToString();
        //                //            break;
        //                //        }
        //                //        else
        //                //        {
        //                //            dt.Rows[i]["PIEd"] = "";
        //                //            dt.Rows[i]["CPID"] = 0;
        //                //        }
        //                //    }
        //                //}
        //            }
        //            //if (arr.Length > 0)
        //            //{
        //            //    dt.Rows[i]["PIEd"] = arr[0]["MPFunding"].ToString();

        //            //    dt.Rows[i]["CPID"] = arr[0]["CPID"].ToString();
        //            //}
        //            //else
        //            //{
        //            //    dt.Rows[i]["PIEd"] = "";
        //            //    dt.Rows[i]["CPID"] = 0;
        //            //}

        //        }
        //        dt.Rows[i]["Balance"] = balance;
        //    }
        //}
        ////List<int> IDList = new List<int>();
        ////for (int i = 0; i < dt.Rows.Count; i++)
        ////{ 
        ////    int piid = common.IntSafeConvert(dt.Rows[i]["PIID"]);
        ////    DataRow[] dr = dt.Select("PIEcoSubParID = " + piid);
        ////    if (dr.Length > 0)
        ////    {
        ////        dt.Rows[i].Delete();
        ////    }
        ////}
        ////dt.AcceptChanges(); 
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Balance"] = dt.Rows[i]["Mon"];
        }

    }

    private void StoreBind(DataTable dt)
    {
        GetLeverPIEcoSubName(dt);

        //List<Project> prjList = new List<Project>();
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    Project prj = new Project();
        //    prj.PIEcoSubName = dt.Rows[i]["PIEcoSubName"].ToString();
        //    prj.BAAMon = ParToDecimal.ParToDel(dt.Rows[i]["BAAMon"].ToString());
        //    prj.SuppMon = ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
        //    prj.PIEcoSubParID = common.IntSafeConvert(dt.Rows[i]["PIEcoSubParID"] );
        //    prj.PIID = common.IntSafeConvert(dt.Rows[i]["PIID"].ToString());
        //    prj.PIEd = ParToDecimal.ParToDel(dt.Rows[i]["PIEd"].ToString());
        //    prj.Balance = ParToDecimal.ParToDel(dt.Rows[i]["Balance"].ToString());
        //    prj.CPID = common.IntSafeConvert(dt.Rows[i]["CPID"].ToString());
        //    prj.Mon = ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString());
        //    prj.FullName = dt.Rows[i]["FullName"].ToString();
        //    prj.FirstName = dt.Rows[i]["FirstName"].ToString();
        //    prj.LastName = dt.Rows[i]["LastName"].ToString();
        //    prjList.Add(prj);
        //}
        MonPlanStore.DataSource = GetSortDT(dt); ;
        MonPlanStore.DataBind();
    }


    public class Project
    {
        public Project()
        {
        }

        public Project(string pIEcoSubName, decimal bAAMon, decimal suppMon, int pIEcoSubParID, int pIID, decimal pIEd, decimal balance, int cPID, decimal mon, string fullName, string firstName, string lastName)
        {
            this.PIEcoSubName = pIEcoSubName;
            this.BAAMon = bAAMon;
            this.SuppMon = suppMon;
            this.PIEcoSubParID = pIEcoSubParID;
            this.PIID = pIID;
            this.PIEd = pIEd;
            this.Balance = balance;
            this.CPID = cPID;
            this.Mon = mon;
            this.FullName = fullName;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string PIEcoSubName { get; set; }
        public decimal BAAMon { get; set; }
        public decimal SuppMon { get; set; }
        public int PIEcoSubParID { get; set; }
        public int PIID { get; set; }
        public decimal PIEd { get; set; }
        public decimal Balance { get; set; }
        public int CPID { get; set; }
        public decimal Mon { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    private void GetLeverPIEcoSubName(DataTable dt)
    {
        List<int> IDList = new List<int>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int piid = common.IntSafeConvert(dt.Rows[i]["PIID"]);
            DataRow[] dr = dt.Select("PIEcoSubParID = " + piid);
            if (dr.Length > 0)
            {
                dt.Rows[i].Delete();
            }
        }
        dt.AcceptChanges();
        dt.Columns.Add("FullName");
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            int piecoSubParID = common.IntSafeConvert(dt.Rows[j]["PIEcoSubParID"]);
            if (piecoSubParID == 0)
            {
                break;
            }
            list.Clear();
            getgen(piecoSubParID);
            string genlist = "";
            for (int k = 0; k < list.Count; k++)
            {
                genlist += list[list.Count - k - 1].ToString() + "/";
                dt.Rows[j]["FirstName"] = list[list.Count - 1].ToString();
            }
            genlist += dt.Rows[j]["PIEcoSubName"];
            dt.Rows[j]["LastName"] = genlist.Replace(dt.Rows[j]["FirstName"].ToString() + "/", "");
            dt.Rows[j]["FullName"] = genlist;
            //dt.Rows[j]["PIEcoSubName"] = genlist;
        }
    }
    private DataTable GetSortDT(DataTable dt)
    {
        DataTable dm = BG_PayIncomeLogic.GetDtPayIncome();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string tm = dt.Rows[i]["FullName"].ToString();
            string pn = "";
            decimal dd = 0;
            for (int j = 0; j < dm.Rows.Count; j++)
            {
                pn = dm.Rows[j]["PIEcoSubName"].ToString();
                if (tm.Contains(pn) && common.IntSafeConvert(dm.Rows[j]["ISSign"]) == 1)
                {
                    decimal mon = BG_BudgetAllocationLogic.GetMon(common.IntSafeConvert(CurrentYear), common.IntSafeConvert(dm.Rows[j]["PIID"]), depid);
                    dd += mon;
                    if (pn == "商品和服务支出")
                    {
                        Session["商品和服务支出"] = dd;
                    }
                    else if (pn == "其他资本性支出")
                    {
                        Session["其他资本性支出"] = dd;
                    }
                    else if (pn == "工资福利支出")
                    {
                        Session["工资福利支出"] = dd;
                    }
                    else
                    {
                        Session["对个人和家庭补助支出"] = dd;
                    }

                }
                if (tm.Contains(pn))
                {
                    if (pn == "商品和服务支出")
                    {
                        if (common.IntSafeConvert(dm.Rows[j]["ISSign"]) == 0)
                        {
                            string sqldr = string.Format("FirstName='{0}'", pn);
                            DataRow[] dr = dt.Select(sqldr);
                            decimal tb = 0;
                            for (int o = 0; o < dr.Length; o++)
                            {
                                tb += ParToDecimal.ParToDel(dr[o]["Mon"].ToString());
                            }
                            HidLS.Value = tb.ToString();
                            Session[pn] = tb;
                        }
                        else
                        {
                            HidLS.Value = "flag";
                        }
                    }
                    else if (pn == "其他资本性支出")
                    {
                        if (common.IntSafeConvert(dm.Rows[j]["ISSign"]) == 0)
                        {
                            string sqldr = string.Format("FirstName='{0}'", pn);
                            DataRow[] dr = dt.Select(sqldr);
                            decimal tb = 0;
                            for (int o = 0; o < dr.Length; o++)
                            {
                                tb += ParToDecimal.ParToDel(dr[o]["Mon"].ToString());
                            }
                            //HidTotalq.Value = tb.ToString();
                            Session[pn] = tb;
                            HidLQ.Value = tb.ToString();
                        }
                        else
                        {
                            HidLQ.Value = "flag";
                        }
                    }
                    else if (pn == "工资福利支出")
                    {
                        if (common.IntSafeConvert(dm.Rows[j]["ISSign"]) == 0)
                        {
                            string sqldr = string.Format("FirstName='{0}'", pn);
                            DataRow[] dr = dt.Select(sqldr);
                            decimal tb = 0;
                            for (int o = 0; o < dr.Length; o++)
                            {
                                tb += ParToDecimal.ParToDel(dr[o]["Mon"].ToString());
                            }
                            //HidTotalq.Value = tb.ToString();
                            HidLG.Value = tb.ToString();
                            Session[pn] = tb;
                        }
                        else
                        {
                            HidLG.Value = "flag";
                        }
                    }
                    else
                    {
                        if (common.IntSafeConvert(dm.Rows[j]["ISSign"]) == 0)
                        {
                            string sqldr = string.Format("FirstName='{0}'", pn);
                            DataRow[] dr = dt.Select(sqldr);
                            decimal tb = 0;
                            for (int o = 0; o < dr.Length; o++)
                            {
                                tb += ParToDecimal.ParToDel(dr[o]["Mon"].ToString());
                            }
                            //HidTotalq.Value = tb.ToString();
                            Session[pn] = tb;
                            HidLD.Value = tb.ToString();
                        }
                        else
                        {
                            HidLD.Value = "flag";
                        }
                    }
                }
            }
            if (dd > 0)
            {
                dt.Rows[i]["Mon"] = dd;
                dt.Rows[i]["Balance"] = dd;
                //Incomebalance.Text = bal.ToString() + " 万元";
            }
            if (tm.Contains("/"))
            {
                int t = tm.LastIndexOf('/');
                tm = tm.Substring(t + 1, tm.Length - t - 1);
                DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(tm);
                dt.Rows[i]["Balance"] = (ParToDecimal.ParToDel(dt.Rows[i]["Mon"].ToString()) * 10000 - BG_ApplyReimburLogic.GetARMon(dtpiid.Rows[0]["PIEcoSubName"].ToString(), common.IntSafeConvert(DepID), common.IntSafeConvert(CurrentYear), common.IntSafeConvert(cmbmon.SelectedItem.Value))) / 10000;
            }

        }
        //Incomebalance.Text = bal.ToString() + "万元";
        System.Data.DataView dw = dt.DefaultView;
        dw.Sort = "PIID ASC";
        DataTable dt2 = dw.ToTable(true);
        return dt2;
    }
   

    IList<string> list = new List<string>();
    private void getgen(int PIID)
    {
        if (PIID == 0)
        {
            return;
        }
        DataTable dt = BG_MonPayPlanGenerateLogic.GetPIEName(PIID);
        int piid = common.IntSafeConvert(dt.Rows[0]["PIEcoSubName"].ToString());
        int fatherid = common.IntSafeConvert(dt.Rows[0]["PIEcoSubParID"].ToString());
        string name = dt.Rows[0]["PIEcoSubName"].ToString();
        if (fatherid != 0)
        {
            list.Add(name);
            getgen(fatherid);
        }
        else
        {
            list.Add(name);
        }

    }
    protected void btnsubmit_DirectClick(object sender, DirectEventArgs e)
    {
        if (hidflag.Text != "2")
        {
            X.Msg.Alert("申请月度用款计划", "请先添加完数据，再提交！").Show();
            return;
        }
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        BG_MonPayPlanRemark mppr = new BG_MonPayPlanRemark();
        mppr.DeptID = depid;
        mppr.MACause = "";
        mppr.MASta = "未提交";
        mppr.MATime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
        mppr.MAUser = UserName;
        if (BG_MonPayPlanGenerateLogic.IsnotSubmitMonPay(yearMonth, depid))
        {
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
            X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Text + "月份用款计划已提交给财务科，请等待审核").Show();
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            Getmonth();
        }
        else
        {
            BG_MonPayPlanRemarkManager.AddBG_MonPayPlanRemark(mppr);
            X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Text + "月份用款计划已提交财务科，请等待审核").Show();
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            Getmonth();
        }



        //DataTable dtyear = BG_SysSettingManager.GetAllBG_SysSetting();
        //int count = dtyear.Rows.Count;
        //int year = Convert.ToInt32(dtyear.Rows[count - 1]["DefaultYear"]);
        //BG_MonPayPlanArmon Armon = BG_MonPayPlanGenerateLogic.GetMonPayPlanArmonByyeardepid(year, depid);
    }
    //protected void btnfind_DirectClick(object sender, DirectEventArgs e)
    //{

    //}

    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(string tm, int CPID, int PIID, string oldValue, decimal newValue, decimal balance, string PIEcoSubName)
    {
        decimal dd = 0;
        try
        {
            if (tm.Contains("/"))
            {
                int t = tm.IndexOf('/');
                tm = tm.Substring(0, t);
            }

            if (tm == "商品和服务支出")
            {
                dd = (decimal)Session["商品和服务支出"];
            }
            else if (tm == "其他资本性支出")
            {
                dd = (decimal)Session["其他资本性支出"];
            }
            else if (tm == "工资福利支出")
            {
                dd = (decimal)Session["工资福利支出"];
            }
            else
            {
                dd = (decimal)Session["对个人和家庭补助支出"];
            }
            Session[tm] = (dd*10000 - newValue)/10000;
            if ((decimal)Session[tm] < 0)
            {
                X.Msg.Alert("提示", "经费必须少于一级科目的总经费").Show();
                Session[tm] = dd;
                return;
            }
        }
        catch (System.Exception ex)
        {

        }
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        if (hidflag.Text == "3")
        {
            //X.Msg.Alert("提示", "修改提交或审核通过的经费必须大于现经费").Show();
            if (ParToDecimal.ParToDel(oldValue) > newValue)
            {
                X.Msg.Alert("提示", "修改提交或审核通过的经费必须大于现经费").Show();
                return;
            }
            else
            {
                BG_MonPayPlan mppalert = new BG_MonPayPlan();
                mppalert = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
                mppalert.MPFunding = newValue;
                BG_MonPayPlanManager.ModifyBG_MonPayPlan(mppalert);
                return;
            }
        }
        if (hidflag.Text == "1")
        {
            X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，不允许修改").Show();

            return;
        }
        string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";

        // Send Message...


        if (newValue > balance)
        {
            X.Msg.Alert("申请月度用款计划", "科目：" + PIEcoSubName + ",经费不足，请调整经费").Show();
            return;
        }


        BG_MonPayPlan mpp = new BG_MonPayPlan();
        CPID = common.IntSafeConvert(BG_MonPayPlanGenerateLogic.IsMonplanByPIIDDepID(PIID, depid, yearMonth));
        if (CPID > 0)
        {
            mpp = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
            mpp.MPFunding = newValue;
            BG_MonPayPlanManager.ModifyBG_MonPayPlan(mpp);
        }
        else
        {
            mpp = new BG_MonPayPlan();
            mpp.DeptID = depid;
            mpp.PIID = PIID;
            mpp.MPFunding = newValue;
            mpp.MPTime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
            BG_MonPayPlanManager.AddBG_MonPayPlan(mpp);

        }
        hidflag.Text = "2";
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "申请月度用款计划",
            Html = string.Format(message, PIEcoSubName, oldValue, newValue),
            Width = 250
        }).Show();

        //BG_MonPayPlan mpp = new BG_MonPayPlan();


        //pd.Armon = Convert.ToDouble(newValue);
        //BG_MonPayPlanArmon.ModifyBG_PreviewData(pd);
        //PreviewDataBind();

        //this.GridPanel1.GetStore().GetById(id).Commit();
    }
    protected void cmbmon_DirectChange(object sender, DirectEventArgs e)
    {
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        if (BG_MonPayPlanRemarkLogic.IsRemark(depid, yearMonth))
        {
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            TFclPIEd.Disable(true);
            if (BG_MonPayPlanGenerateLogic.IsAuditMonPay(yearMonth, depid))
            {

                //X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改").Show();
                X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoYes()",
                        Text = "是"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoNo()",
                        Text = "否"
                    }
                }).Show();
                return;
            }
            else if (BG_MonPayPlanGenerateLogic.IsSubmitMonPay(yearMonth, depid))
            {

                //X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，是否确定要修改").Show();
                X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经提交给局领导，是否确定要修改?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoYes()",
                        Text = "是"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoNo()",
                        Text = "否"
                    }
                }).Show();
                return;
            }
            else if (BG_MonPayPlanGenerateLogic.ISMonlatePay(yearMonth, depid))
            {

                //X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，是否确定要修改").Show();
                string msg = string.Format("月已经被财务室退回（{0}），请核实数据后修改?", BG_MonPayPlanGenerateLogic.MonlatePayCause(yearMonth, depid));
                X.Msg.Confirm("申请月度用款计划", yearMonth + msg, new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "SS.DoYesSSS()",
                        Text = "确定"
                    }
                }).Show();
            }
        }
        else
        {
            TFclPIEd.Enable(true);
            btnsubmit.Hidden = false;
            Getmonth();
            MonPlanBind(depid);
        }
    }
    [DirectMethod(Namespace = "XX")]
    public void DoYes()
    {
        hidflag.Text = "3";
        TFclPIEd.Enable(true);
        Getmonth();
        MonPlanBind(depid);
        btnsubmit.Show();
    }

    [DirectMethod(Namespace = "SS")]
    public void DoYesSSS()
    {
        hidflag.Text = "2";
        TFclPIEd.Enable(true);
        MonPlanBind(depid);
        btnsubmit.Show();
    }
    [DirectMethod(Namespace = "XX")]
    public void DoNo()
    {
        Getmonth();
        MonPlanBind(depid);
    }
}
#region  注释代码
//private void repBudConDataBind(int mAMonth)
//{
//    DataTable dt = VMonPayPlanIncomeManager.GetvMonPayPlanIncomeByMAMonth(mAMonth);
//    if (dt.Rows.Count > 0)
//    {
//        string content = dt.Rows[0]["PIEcoSubName"].ToString();
//        setTextBox(content, '☆');
//    }

//}
//private void setTextBox(string str, char c)
//{

//    string[] strs = str.Split(c);
//    for (int i = 1; i <= strs.Length; i++)
//    {

//        TextBox txt = this.FindControl("TextBox" + i.ToString()) as TextBox;
//        if (txt != null)
//        {
//            txt.Text = strs[i - 1].ToString();
//        }

//    }
//}
//protected void btnSubmit_Click(object sender, EventArgs e)
//{
//    int month = Utils.IntSafeConvert(ddlmonth.SelectedValue);
//    int year = 2013;
//    int deptid = 1104;
//    bool br = BGMonPayPlanRemarkManager.Querylog(deptid, year, month);
//    if (br)
//    {
//       RegisterStartupScript("ky", @"<script>alert('该月用款计划已提交，不能重复提交！')</script>");
//    }
//    else
//    {
//        //信息添加
//        string sqlAll = string.Empty;
//        Random r = new Random();
//        for (int i = 1022; i <= 1101; i++)
//        {
//          string sqlTmp = "insert into BG_MonPayPlanA(CPID,MABasicExp,MAProExp,MATotal,MAMonth)values({0},{1},{2},{3},{4});";
//            int cpid = i;
//            int MABasicExp = r.Next(1000,10000);
//            int MAProExp = r.Next(1000, 10000);
//            int MATotal = r.Next(1000, 10000);
//            sqlTmp = string.Format(sqlTmp, cpid, MABasicExp, MAProExp, MATotal, month);
//            sqlAll += sqlTmp;
//        }

//        string ssql = "insert into BG_MonPayPlanRemark(DeptID,MAYear,MAMonth,MASta,MACause,MAUser) values (1104,2013,{0},'未提交','无','王五');";
//        ssql = string.Format(ssql, month);
//        sqlAll += ssql;
//        if (DBUnity.ExecuteNonQuery(CommandType.Text, sqlAll, null) > 0)
//        {

//            Response.Redirect("SelMonPayPlan.aspx", true);
//        }
//        else
//        {
//            RegisterStartupScript("ky", @"<script>alert('提交数据有误')</script>");
//        }
//        //Response.Redirect("SelMonPayPlan.aspx", true);
//    }
//} 
#endregion