using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
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

public partial class mainPages_BudProjectAlter : System.Web.UI.Page
{
    protected string piid = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        piid = Request["piid"];

        if (!IsPostBack)
        {
            BudgetConDataBind();
        }
    }


    private void BudgetConDataBind()
    {
        DataTable dt = BGPayIncomeManager.GetPayIncomeListByPIID(piid);
        if(dt.Rows.Count > 0)
        {
            string PiName = dt.Rows[0]["PIEcoSubName"].ToString();
            txtPro.Text = PiName;
        } 
        DataTable dtCell = BGBudgetConCellManager.GetBudgetConCellListByPIID(piid);
        for (int i = 0; i < dtCell.Rows.Count; i++)
        {
            if (i == 0)
            { 
                ckA.Checked = true;
                tbA.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrA.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
            else if (i == 1)
            {
                ckB.Checked = true;
                tbB.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrB.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
            else if (i == 2)
            {
                ckC.Checked = true;
                tbC.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrC.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
            else if (i == 3)
            {
                ckD.Checked = true;
                tbD.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrD.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
            else if (i == 4)
            {
                ckE.Checked = true;
                tbE.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrE.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
            else if (i == 5)
            {
                ckF.Checked = true;
                tbF.Text = dtCell.Rows[i]["BCCName"].ToString();
                tbCtrF.Text = dtCell.Rows[i]["BCCStan"].ToString();
            }
        }
    }




    protected void btnMod_Click(object sender, EventArgs e)
    {
        //添加-->
        BG_BudgetConCell cell = null;
        List<BG_BudgetConCell> list = new List<BG_BudgetConCell>();

        int piidInt = common.IntSafeConvert(piid);
        if (ckA.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbA.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrA.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);

        }

        if (ckB.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbB.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrB.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckC.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbC.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrC.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckD.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbD.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrD.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckE.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbE.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrE.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }
        if (ckF.Checked)
        {
            //启用
            cell = new BG_BudgetConCell();
            cell.PIID = piidInt;
            cell.BCCName = common.RemoveUnsafeHtml(tbF.Text.Trim());
            cell.BCCStan = ParseUtil.ToDecimal(tbCtrF.Text.Trim(), 0);
            cell.BCCUseSta = "启用";
            list.Add(cell);
        }

        bool flag = BGBudgetConCellManager.UpdateBantch(list, piid);
        if (flag)
        {
            Response.Redirect("BudProjectList.aspx", true);
        }

    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        //取消
        Response.Redirect("BudProjectList.aspx", true);
    }
}
