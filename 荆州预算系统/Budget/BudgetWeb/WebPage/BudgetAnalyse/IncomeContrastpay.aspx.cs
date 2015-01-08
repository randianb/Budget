using System;
using System.Data;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;
using Ext.Net;
using NPOI.HSSF.Record.Formula.Functions;

public partial class WebPage_BudgetControl_IncomeContrastpay : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !ExtNet.IsAjaxRequest)
        {　
            Getmonth();
            DepDataBind();
            cmbmon.SelectedItem.Text = DateTime.Now.Month.ToString();
           // cmbdept.SelectedItem.Text = "财务装备科";
            //cmbdept.SelectedItem.Value = "1003";
           //
        }
        if ( common.IntSafeConvert(cmbmon.SelectedItem.Value)>0)
        {
            Store1Bind();
        }
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(int id, string InComeSouce, string DepName, string oldValue, string newValue,int DepID)
    {
        string message = "";
        BG_IncomeCPay bgIncomeCPay = BG_IncomeCPayManager.GetBG_IncomeCPayByICPID(id);
        if (bgIncomeCPay!=null)
        {
            message = "<b>部门</b> {0}<br /><b>资金来源</b> {1}<br /><b>原金额:</b> {2}<br /><b>设置金额:</b> {3}";
//            bgIncomeCPay.DepID = DepID;
//            bgIncomeCPay.ICPTime= Convert.ToDateTime(CurrentYear+"-" +cmbmon.SelectedItem.Text+"-01");
            bgIncomeCPay.InComeMon = ParseUtil.ToDecimal(newValue,0);
//            bgIncomeCPay.InComeSouce = InComeSouce;
            BG_IncomeCPayManager.ModifyBG_IncomeCPay(bgIncomeCPay);
        }
        else
        {
            message = "<b>部门</b> {0}<br /><b>资金来源</b> {1}<br /><b>原金额:</b> {2}<br /><b>更改金额:</b> {3}"; 
            bgIncomeCPay=new BG_IncomeCPay();
            bgIncomeCPay.DepID =  common.IntSafeConvert(cmbdept.SelectedItem.Value);
            bgIncomeCPay.ICPTime= Convert.ToDateTime(CurrentYear+"-" +cmbmon.SelectedItem.Text+"-01");
            bgIncomeCPay.InComeMon = ParseUtil.ToDecimal(newValue, 0);
            bgIncomeCPay.InComeSouce = InComeSouce;
            BG_IncomeCPayManager.AddBG_IncomeCPay(bgIncomeCPay);
        }
        // Send Message... 
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "收入金额：",
            Html = string.Format(message, DepName, InComeSouce, oldValue, newValue),
            Width = 250
        }).Show();
    }
    private void Getmonth()
    {
        var dt = new DataTable();
        dt.Columns.Add("month");
        for (int i = 1; i < 13; i++)
        {
            string t = i.ToString();
            if (i < 10)
            {
                t = "0" + i;
            }
            DataRow dr = dt.NewRow();
            dr["month"] = t;
            dt.Rows.Add(dr);
        }
        cmbmonstore.DataSource = dt;
        cmbmonstore.DataBind();
    }

    private void Store1Bind()
    {
        int depid =common.IntSafeConvert(cmbdept.SelectedItem.Value);
        int Month =common.IntSafeConvert(cmbmon.SelectedItem.Value);
        DataTable dtTable = IncomeContrastpayLogic.GetICPDTByDepID_Time(depid, Month);
        dtTable.Columns.Add("PayMon"); 
        for (int i = 0; i < dtTable.Rows.Count; i++)
        {
            if (dtTable.Rows[i]["InComeSouce"].ToString()=="财政拨款")
            {
                dtTable.Rows[i]["PayMon"] = dtTable.Rows[i]["GKZC"];
            }
            else if (dtTable.Rows[i]["InComeSouce"].ToString() == "地方财政")
            {
                dtTable.Rows[i]["PayMon"] = dtTable.Rows[i]["QTZJ"];
            }
            else if (dtTable.Rows[i]["InComeSouce"].ToString() == "其他")
            {
                dtTable.Rows[i]["PayMon"] = dtTable.Rows[i]["XJZC"];
            }
        }
        if (dtTable.Rows.Count==0)
        {
            if (InComeSouce==null)
            {
                return; 
            }
            foreach (var inComeSouce in InComeSouce)
            {
                DataRow dr = dtTable.NewRow();
                dr["InComeSouce"] = inComeSouce;
                dr["InComeMon"] = 0;
                dr["PayMon"] = 0;
                //dr["BalanceMon"] = 0;
                dr["ICPTime"] = Convert.ToDateTime(CurrentYear+"-" +cmbmon.SelectedItem.Text+"-01");
                dr["DepID"] = depid;
                dr["DepName"] = cmbdept.SelectedItem.Text;
                dtTable.Rows.Add(dr);
            }
        }
        Store1.DataSource = GetNewdt(dtTable);
        Store1.DataBind();
    }
    private DataTable GetNewdt(DataTable dt)
    {
        dt.Columns.Add("BalanceMon");
        decimal t1 = 0, t2 = 0, t3 = 0; 
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["BalanceMon"] = ParToDecimal.ParToDel(dt.Rows[i]["InComeMon"].ToString()) - ParToDecimal.ParToDel(dt.Rows[i]["PayMon"].ToString());
            t1 += ParToDecimal.ParToDel(dt.Rows[i]["InComeMon"].ToString());
            t2 += ParToDecimal.ParToDel(dt.Rows[i]["PayMon"].ToString());
            t3 +=ParToDecimal.ParToDel(dt.Rows[i]["BalanceMon"].ToString());
        }
        DataRow dr = dt.NewRow();
        dr["DepName"] = "总计";
        dr["InComeMon"] = t1;
        dr["PayMon"] = t2;
        dr["BalanceMon"] = t3;
        dt.Rows.Add(dr);
        return dt;


    }
    protected void cmbmon_DirectChange(object sender, DirectEventArgs e)
    {
    }

    private void DepDataBind()
    {
        DataTable dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        for (int i = 0; i < dt.Rows.Count; i++)
        { 
            cmbdept.Items.Add(new ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
        }
    }

    protected void BtnsureDirectEvents(object sender, DirectEventArgs e)
    {
        Store1Bind();
    }
}