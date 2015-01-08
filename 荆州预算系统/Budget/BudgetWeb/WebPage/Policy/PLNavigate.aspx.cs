using System;
using BudgetWeb.BLL;

public partial class WebPage_Policy_PLNavigate : BudgetBasePage
{
    public int Sjsbsh = 0;
    public int Sjsbtj, Sjsh;
    public int Sjtj;

    //public string  Zt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hidtj.Visible = false;
        hidsh.Visible = false;
        hidsbtj.Visible = false;
        hidsbsh.Visible = false;
        if (UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "局领导")
        {
            Sjtj = BG_MonPayPlanRemarkLogic.GetCountremark("未提交");
            Sjsh = BG_MonPayPlanRemarkLogic.GetCountremark("提交");
            Sjsbtj = BG_MonPayPlanRemarkLogic.GetCountReimbur("未提交");
            Sjsbsh = BG_MonPayPlanRemarkLogic.GetCountReimbur("提交");
            if (Sjtj > 0)
            {
                hidtj.Visible = true;
            }
            if (Sjsh > 0)
            {
                hidsh.Visible = true;
            }
            if (Sjsbtj > 0)
            {
                hidsbtj.Visible = true;
            }
            if (Sjsbsh > 0)
            {
                hidsbsh.Visible = true;
            }
        }
    }
}