using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;

public partial class mainPages_BudConExeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlTimeDataBind();
        }
    }

    private void ddlTimeDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Year");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add("");
            dt1.Rows[i]["Year"] = dt.Rows[dt.Rows.Count - i - 1]["DefaultYear"];
        }
        ddlyear.DataTextField = "Year";
        ddlyear.DataValueField = "Year";
        ddlyear.DataSource = dt1;
        ddlyear.DataBind();
    }

    private void repBudConDataBind(string depname)
    {
        DataTable dt = VApplyPayDepartManager.GetVApplyPayDepartByDepName(depname);
        repBudCon.DataSource = dt;
        repBudCon.DataBind();
    }
    protected void btnInq_Click(object sender, EventArgs e)
    {
        lanotice.Text = "";
        string ARTime = ddlyear.Text.Trim() + "-" + DropDownList1.Text.Trim();
        string BAAYear = ddlyear.Text.Trim();
        DataTable dt2 = BG_BudgetAllocationLogic.GetARMonByBAAYear(BAAYear);
        if (dt2.Rows.Count < 1)
        {
            lanotice.Text = "该时间不存在数据，请添加后再查询！";
            repBudCon.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepName");
            dt.Columns.Add("ARMon");
            dt.Columns.Add("ChangeMon");
            dt.Columns.Add("UserMon");
            dt.Columns.Add("Pecent");
            //dt.Columns.Add("");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt.Rows.Add("");
                dt.Rows[i]["DepName"] = BGDepartmentManager.GetDepBydepid(dt2.Rows[i]["DepID"].ToString()).DepName.ToString();
                dt.Rows[i]["ARMon"] = dt2.Rows[i]["BAAMon"].ToString();
                int depid = common.IntSafeConvert(dt2.Rows[i]["DepID"]);
                DataTable dtsupp = BG_SupplementaryLogic.GetBG_SupplementaryDivide(depid, common.IntSafeConvert(ddlyear.Text.Trim()));
                dt.Rows[i]["ChangeMon"] = Convert.ToDecimal(dtsupp.Rows[0]["SuppMon"]).ToString("f2"); ;
                DataTable dt1 = BG_ApplyReimburLogic.GetARMonByARTime(ARTime, int.Parse(dt2.Rows[i]["DepID"].ToString()));
                if (dt1.Rows.Count > 0 && dt1.Rows[0]["ARMon"].ToString() != "")
                {
                    //dt.Rows[i]["Balance"] = (Convert.ToInt32(dt2.Rows[0]["BAAMon"]) - Convert.ToInt32(dt1.Rows[0]["ARMon"])).ToString();
                    dt.Rows[i]["UserMon"] = Convert.ToInt32(dt1.Rows[0]["ARMon"]).ToString("0.00");
                }
                else
                {
                    //dt.Rows[i]["Balance"] = dt2.Rows[i]["BAAMon"].ToString();
                    dt.Rows[i]["UserMon"] = "0.00";
                }
                if (ParseUtil.ToDecimal(dt.Rows[i]["ARMon"].ToString(), 0) == 0)
                {
                    decimal usermon = ParseUtil.ToDecimal(dt.Rows[i]["UserMon"].ToString(), 0);
                    decimal armon = ParseUtil.ToDecimal(dt.Rows[i]["ARMon"].ToString(), 0); 
                    dt.Rows[i]["Pecent"] = ((usermon / armon) * 100).ToString("f2") + "%"; 
                }
                else
                {
                    dt.Rows[i]["Pecent"] = "0%";
                }
            }
            repBudCon.DataSource = dt;
            repBudCon.DataBind();
        }

    }
}
