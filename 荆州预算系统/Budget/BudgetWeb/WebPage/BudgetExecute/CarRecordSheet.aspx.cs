using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_BudgetExecute_CarRecordSheet : System.Web.UI.Page
{
    string arid = "0";
    string oper = "1";//1添加，2修改，3按返回时退回审批页面
    string strcontent = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        arid = Request.QueryString["arid"];
        oper = Request.QueryString["oper"];
        strcontent = Request.QueryString["strcontent"];
        if (oper == "1")
        {
            btnAdd.Visible = true;
            btnAlter.Visible = false;
            AddBind(strcontent);
        }
        else if (oper == "3")
        {

            btnAdd.Visible = false;
            btnAlter.Visible = false;
            for (int i = 1; i <= 21; i++)
            {
                TextBox txt = this.FindControl("TextBox" + i.ToString()) as TextBox;
                txt.Enabled = false;
            }
        }
        else
        {
            btnAdd.Visible = false;
            btnAlter.Visible = true;

        }
        if (!IsPostBack)
        {
            if (oper != "1")
            {
                informbind(arid);
            }
        }
    }
    protected void btnunit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Expense.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
    }
    private List<string> Getlist(string content)
    {
        List<string> slist = new List<string>();
        string[] str = content.Split('*');
        for (int i = 0; i < str.Length; i++)
        {
            slist.Add(str[i]);
        }
        return slist;
    }

    private void AddBind(string strcon)
    {
        string Depname = Getlist(strcon)[0];
        string time = Getlist(strcon)[1];
        string money = Getlist(strcon)[2];
        string Agent = Getlist(strcon)[3];
        TextBox1.Text = Depname;
        char cr;
        if (time.Contains("/"))
        {
            cr = '/';
        }
        else
        {
            cr = '-';
        }
        ////////TextBox33.Text = ConvertSum.ConvertToSum(money);
        TextBox2.Text = time.Split(cr)[0];
        TextBox3.Text = time.Split(cr)[1];
        TextBox4.Text = time.Split(cr)[2].Substring(0, 2);
        //TextBox34.Text = Agent;
        Session["money"] = (ParToDecimal.ParToDel(money) * 10000).ToString(); Session["time"] = time;
    }
    private void informbind(string arid)
    {
        DataTable dt = BGReimAppendixManager.GetAccessories(arid);
        if (dt.Rows.Count > 0)
        {
            string content = dt.Rows[0]["ARContent"].ToString();
            setTextBox(content, '☆');
        }

    }

    private void setTextBox(string str, char c)
    {

        string[] strs = str.Split(c);
        for (int i = 1; i <= strs.Length; i++)
        {

            TextBox txt = this.FindControl("TextBox" + i.ToString()) as TextBox;
            if (txt != null)
            {
                txt.Text = strs[i - 1].ToString();
            }

        }
    }

    private string getCbCatalog()
    {
        string content = "";
        for (int i = 1; i <= 21; i++)
        {
            TextBox txt = this.FindControl("TextBox" + i.ToString()) as TextBox;
            if (txt != null)
            {
                content += txt.Text.Trim();
            }
            if (i != 21)
            {
                content += "☆";
            }
        }
        return content;
    }

    protected void btnAlter_Click(object sender, EventArgs e)
    {
        BG_ReimAppendix ra = BGReimAppendixManager.GetAcc(arid);
        ra.ARContent = getCbCatalog();
        ra.ARTime = Convert.ToDateTime(Session["time"]);
        if (BGReimAppendixManager.UpdAccessories(ra))
        {
            lblMResult.Text = "* 修改成功";
            Response.Redirect("ApplyAlter.aspx?arid=" + arid, true);
        }
        else
        {
            lblMResult.Text = "* 操作失败、请检查数据后重试";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BG_ReimAppendix ra = new BG_ReimAppendix();
        ra.ARID = common.IntSafeConvert(arid);
        ra.ARContent = getCbCatalog();
        ra.ARType = "长途出车记录";
        string[] str = ra.ARContent.Split('☆');
        ra.ARTime = Convert.ToDateTime(Session["time"]);
        decimal total = ParToDecimal.ParToDel(Session["money"].ToString());
        if (BGReimAppendixManager.AddAccessories(ra))
        {
            lblMResult.Text = "* 添加成功";

        }
        else
        {
            lblMResult.Text = "* 操作失败、请检查数据后重试";
        }
        //if (total > Convert.ToDecimal(str[32]))
        //{
        //    lblMResult.Text = "* 所填金额不能大于分配金额";
        //    return;
        //}
        //else
        //{
        //    if (BGReimAppendixManager.AddAccessories(ra))
        //    {
        //        lblMResult.Text = "* 添加成功";

        //    }
        //    else
        //    {
        //        lblMResult.Text = "* 操作失败、请检查数据后重试";
        //    }
        //}
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        if (oper == "1")
        {
            Response.Redirect("ApplyList.aspx", true); string PostUrl = "ApplyAdd.aspx"; string PostUrl1 = "ApplyList.aspx"; Response.Write("<script language='javascript'>if(confirm('是否继续添加报销单?')){window.location.href='" + PostUrl + "';}else{window.location.href='" + PostUrl1 + "';}</script>");
        }
        else if (oper == "3")
        {
            Response.Redirect("ApplyQuery.aspx?arid=" + arid, true);
        }
        else if (oper == "4")
        {
            Response.Redirect("ApprovalList.aspx?arid=" + arid, true);
        }
        else
        {
            Response.Redirect("ApplyAlter.aspx?arid=" + arid, true);
        }
    }
}