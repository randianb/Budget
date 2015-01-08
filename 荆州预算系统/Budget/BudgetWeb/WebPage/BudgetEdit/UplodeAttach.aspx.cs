using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using System.IO;

public partial class BudgetPage_mainPages_UplodeAttach : System.Web.UI.Page
{
    int budid;
    int depid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["budid"] != null && Request.QueryString["depid"] != null)
        {
            budid = common.IntSafeConvert(Request.QueryString["budid"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
        else
        {
            Response.Redirect("BudgetEditList.aspx", true);
        }
        if (!IsPostBack)
        {
            repAnnexBind(budid);
        }
    }

    private void repAnnexBind(int budid)
    {
        DataTable dt = BGBudAppendixManager.GetBudAppListByBudid(budid);
        repAnnex.DataSource = dt;
        repAnnex.DataBind();
     
    }

    protected void btn_Click(object sender, EventArgs e)
    {

        //检查文件是否存在  
        if (fup.HasFile == false)//HasFile用来检查FileUpload是否有指定文件  
        {
            lbl.Text = "* 文件不存在或者已移动、请您重新选择Doc文件 ";
            return;
        }
        lbl.Text = string.Empty;
        string fileName ="\\"+ fup.FileName;
        string savePath =Server.MapPath("~\\upload\\" + budid.ToString());
        if (!Directory.Exists(savePath))//判断是否存在
        {
            Directory.CreateDirectory(savePath);
        }
        savePath += common.SafeSql(fileName);
    
        fup.SaveAs(savePath);

        BG_BudAppendix bam = new BG_BudAppendix();
        bam.BudID = budid;
        bam.ApTime = BGBudItemsManager.GetBudItemsByBudid(budid).BIStaTime;
        bam.ApName = common.SafeSql(Path.GetFileNameWithoutExtension(fup.FileName));
        bam.APPath = savePath;
        if (BGBudAppendixManager.AddBudAppendix(bam))
        {
            lbl.Text = "*添加成功";
            repAnnexBind(budid);
        }
        else
        {
            lbl.Text = "*操作失败、请检查数据后重试";
        }
    }
    protected void repAnnex_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = common.IntSafeConvert(e.CommandArgument);
        if (e.CommandName == "Del")
        {
            if (BGBudAppendixManager.DelBudAppendix(id))
            {
                repAnnexBind(budid);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetEditList.aspx?depid=" + depid, true);
    }
}