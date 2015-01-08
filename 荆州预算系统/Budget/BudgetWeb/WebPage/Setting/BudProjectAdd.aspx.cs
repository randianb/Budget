using System;
using System.Collections;
using System.Collections.Generic;
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
using BudgetWeb.Model;
using BudgetWeb.BLL;
using Common;
using Ext.Net;

public partial class mainPages_BudProjectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest && !IsPostBack)
        {
            cmbData();

        }
    } 
    private void cmbData()
    {
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome(); 
        cmbName.DataSource = dt;
        cmbName.DataBind(); 
    }
     


    protected void btnCan_Click(object sender, EventArgs e)
    {
        //退出-->列表   跳转到列表页面
        Response.Redirect("BudProjectList.aspx", true);

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //添加-->

        string piid = ddlPayIncome.SelectedItem.Value;
        int piidInt = common.IntSafeConvert(piid);
        BG_BudgetConCell cell = null;
        List<BG_BudgetConCell> list = new List<BG_BudgetConCell>();
        if (ckA.Checked)
        { 
            //A启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbA.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrA.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }

        if (ckB.Checked)
        {
            //B启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbB.Text .Trim ());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrB .Text .Trim (),0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckC.Checked)
        {
            //C启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbC.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrC.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckD.Checked)
        {
            //D启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbD.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrD.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckE.Checked)
        {
            //E启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbE.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrE.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckF.Checked)
        {
            //F启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbF.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrF.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }


        //添加项目预算控制记录
        BG_BudgetCon bgBudget = new BG_BudgetCon();
        bgBudget.PIID = piidInt;
        bgBudget.YNUse = "启用";
        bgBudget.BCRemark = "备注";
        BGBudgetConManager.AddBudgetCon(bgBudget);

        //批量添加项目预算控制单元记录
        BGBudgetConCellManager.AddBudgetConCell(list);
        Response.Redirect("BudProjectList.aspx", true);

    }


    
}


