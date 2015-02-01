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
using BudgetWeb.DAL;
using Common;

public partial class WebPage_Setting_STQuota : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QuotaData();
        }
    }
    [DirectMethod]
    public void refresh()
    {
        Response.Redirect("STQuota.aspx");
    }
    private void QuotaData()
    {
        //DataTable dt = BGQuotaLogic.GetBGQuota(year);
        DataTable dt = BG_QuotaManager.GetAllBG_Quota();
        DataTable newtd = GetPayname(dt);
        PayStore.DataSource = newtd;
        PayStore.DataBind();
    }

    private DataTable GetPayname(DataTable dtnew)
    {
        int year = common.IntSafeConvert(CurrentYear);
        System.Data.DataView dv = dtnew.DefaultView;
        string filter = string.Format(" Year={0}", year);
        dv.RowFilter = filter;
        DataTable dt = dv.ToTable(true);
        if (dt.Rows.Count == 0)
        {
            //X.Msg.Alert("提示", "数据为空").Show();
            dt.Columns.Add("PayPrjName");
            DataTable dtpay = BudgetWeb.DAL.DBUnity.AdapterToTab("select * from dbo.BG_PayIncome where PIEcoSubName in(  select PIEcoSubName from dbo.BG_PayIncome  a where not exists(select 1 from dbo.BG_PayIncome where a.PIID= PIEcoSubParID) group by PIEcoSubName )");
            for (int i = 0; i < dtpay.Rows.Count; i++)
            {
                int piid = common.IntSafeConvert(dtpay.Rows[i]["PIID"]);
                string sqlstr=string.Format("PayPrjName='{0}'",dtpay.Rows[i]["PIEcoSubName"].ToString());
                DataRow[] drlist = dt.Select(sqlstr);
                if (drlist.Length==0)
                { 
                    DataRow dr = dt.NewRow();
                    dr["PIID"] = piid;
                    dr["PayPrjName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
                    dr["BaseMon"] = 0;
                    dr["ProMon"] = 0;
                    dr["Year"] = year;
                    dt.Rows.Add(dr);
                }
            }
            //System.Data.DataView dv2 = dt.DefaultView;
            //string filter2 = string.Format("PIID ASC");
            //dv2.RowFilter = filter2;
            //DataTable dtn = dv2.ToTable(true);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BG_Quota qt = new BG_Quota();
                qt.PIID = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                qt.Year = year;
                BG_QuotaManager.AddBG_Quota(qt);
			}
            DataRow dr0 = dt.NewRow();
            dr0["PayPrjName"] = "工资福利支出";
            dr0["BaseMon"] = 0;
            dr0["ProMon"] = 0;
            dr0["PIID"] = 1000;
            dt.Rows.Add(dr0);
            DataRow dr1 = dt.NewRow();
            dr1["PayPrjName"] = "商品和服务支出";
            dr1["BaseMon"] = 0;
            dr1["ProMon"] = 0;
            dr1["PIID"] = 1015;
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["PayPrjName"] = "对个人和家庭补助支出";
            dr2["BaseMon"] = 0;
            dr2["ProMon"] = 0;
            dr2["PIID"] = 1051;
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["PayPrjName"] = "其他资本性支出";
            dr3["BaseMon"] = 0;
            dr3["ProMon"] = 0;
            dr3["PIID"] = 1065;
            dt.Rows.Add(dr3);
            return dt;
        }
        else
        {
            dt.Columns.Add("PayPrjName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = common.IntSafeConvert(dt.Rows[i]["PIID"].ToString());
                dt.Rows[i]["PayPrjName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
                int fatherid= BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubParID;
                if (fatherid == 0)
                {
                    Hid1000_base.Text = (ParseUtil.ToDecimal(Hid1000_base.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["BaseMon"].ToString())).ToString();
                    Hid1000_pro.Text = (ParseUtil.ToDecimal(Hid1000_pro.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["ProMon"].ToString())).ToString();
                }
                if (fatherid == 1015)
                {
                    Hid1015_base.Text = (ParseUtil.ToDecimal(Hid1015_base.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["BaseMon"].ToString())).ToString();
                    Hid1015_pro.Text = (ParseUtil.ToDecimal(Hid1015_pro.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["ProMon"].ToString())).ToString();
                }
                if (fatherid == 1051)
                {
                    Hid1051_base.Text = (ParseUtil.ToDecimal(Hid1051_base.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["BaseMon"].ToString())).ToString();
                    Hid1051_pro.Text = (ParseUtil.ToDecimal(Hid1051_pro.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["ProMon"].ToString())).ToString();
                }
                if (fatherid == 1051)
                {
                    Hid1065_base.Text = (ParseUtil.ToDecimal(Hid1065_base.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["BaseMon"].ToString())).ToString();
                    Hid1065_pro.Text = (ParseUtil.ToDecimal(Hid1065_pro.Text, 0) + ParseUtil.ToDecimal(dt.Rows[i]["ProMon"].ToString())).ToString();
                }
            }
            DataRow dr = dt.NewRow();
            dr["PayPrjName"] = "工资福利支出";
            dr["BaseMon"] = ParseUtil.ToDecimal(Hid1000_base.Text, 0);
            dr["ProMon"] = ParseUtil.ToDecimal(Hid1000_pro.Text, 0);
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["PayPrjName"] = "商品和服务支出";
            dr1["BaseMon"] =ParseUtil.ToDecimal( Hid1015_base.Text,0);
            dr1["ProMon"] = ParseUtil.ToDecimal(Hid1015_pro.Text,0);
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["PayPrjName"] = "对个人和家庭补助支出";
            dr2["BaseMon"] = ParseUtil.ToDecimal(Hid1051_base.Text,0);
            dr2["ProMon"] =ParseUtil.ToDecimal( Hid1051_pro.Text,0);
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["PayPrjName"] = "其他资本性支出";
            dr3["BaseMon"] =ParseUtil.ToDecimal(Hid1065_base.Text,0) ;
            dr3["ProMon"] = ParseUtil.ToDecimal(Hid1065_pro.Text, 0);
            dt.Rows.Add(dr3);
            return dt;
        }
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void Edit(int id, string PayPrjName, string oldValue, string newValue, string type)
    {
        string message = "<b>编号:</b> {0}<br /><b>{4}科目:</b> {1}<br /><b>原定额:</b> {2}<br /><b>更改定额:</b> {3}";
        // Send Message...
        X.Msg.Notify(new NotificationConfig()
        {
            Title = "编号#" + id.ToString(),
            Html = string.Format(message, id, PayPrjName, oldValue, newValue,type),
            Width = 250
        }).Show();
        BG_Quota qt = BG_QuotaManager.GetBG_QuotaByQtID(id);
        if (type == "基本")
        {
            qt.BaseMon = ParToDecimal.ParToDel(newValue);
        }
        else
        { qt.ProMon = ParToDecimal.ParToDel(newValue); }
        BG_QuotaManager.ModifyBG_Quota(qt);
    }


}