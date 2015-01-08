using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public partial class WebPage_BudgetEdit_BudgetCollect : BudgetBasePage
{
    int depid = 0;
    decimal total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlDep.SelectedValue != "0")
        {
            cbBIProType.Enabled = false;
            cbBIProType.Checked = false;
        }
        if (!IsPostBack)
        {
            repBudget1.Visible = false;
            Div1.Visible = false;
            depid = DepID;
            ddlDepBind(depid);
            ddlyearBind();
            if (Request.QueryString["depid"] != null)
            {
                depid = common.IntSafeConvert(Request.QueryString["depid"]);
                int year = DateTime.Now.Year;
                ddlDep.SelectedValue = depid.ToString();
                if (Request.QueryString["sta"] == "审核通过")
                {
                    rbtnAudit.Checked = true;
                }
                else
                {
                    rbtnReported.Checked = true;
                }
                AuditorDataBind(Request.QueryString["sta"], depid,year, 0);
            }
            hidDepID.Value = depid.ToString();
        }
    }

    private void ddlyearBind()
    {
        int year = common.IntSafeConvert(CurrentYear);
        string str = "";
        for (int i = year; i >2000; i--)
        {
            str = i.ToString();
            ddlyear.Items.Add(new ListItem(str, str));
        } 
    }

    private void ddlDepBind(int depid)
    { 
        DataTable dt = new DataTable();//BGDepartmentManager.GetDepByfadepid(depid);
        if (DepID == AreaDepID || UserLimStr == "审核员")//(PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            dt = BGDepartmentManager.GetDepByfadepid(AreaDepID);
        }
        else
        {
            dt = BGDepartmentManager.GetDepByDepid(depid);
        }
        if (dt.Rows.Count > 0)
        {
            ddlDep.DataSource = dt;
            ddlDep.DataTextField = "DepName";
            ddlDep.DataValueField = "DepID";
            ddlDep.DataBind();
        }
        if (DepID == AreaDepID || UserLimStr == "审核员")//(PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        {
            ddlDep.Items.Insert(0, new ListItem("全局", "0"));
            cbBIProType.Enabled = true;
        }
    }

    /// <summary>
    /// 根据部门ID绑定
    /// </summary>
    /// <param name="depID"></param>
    private void AuditorDataBind(string chkType, int depID, int year,int pageIndex)
    {
        lashow.Text = "";
        topTb.Visible = true;
        int RecordCount = 0;
        DataTable dt = null; 
//        if (DateTime.Now>Convert.ToDateTime( CurrentYear+"-07"+"-01"))
//        {
//            year += 1;
//        }
        if (cbBIProType.Checked)//按项目类型汇总
        {
            Div1.Visible = false;
            topTb.Visible = true;
            repBudget.Visible = true;
            repBudget1.Visible = false;
            dt = BGBudItemsManager.GetSummaryBudInfoPager(chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt = GetProtypeDt(dt);
            hidtotal.Value = total.ToString();
        }
        else if (ddlDep.SelectedValue == "0")//按部门汇总
        {
            Div1.Visible = true;
            topTb.Visible = false;
            repBudget.Visible = false;
            repBudget1.Visible = true;
            dt = BGBudItemsManager.GetSummaryBudInfoPager(chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt = GetGroupByDeptDt(dt);
        }
        else//选择部门查询
        {
            Div1.Visible = false;
            topTb.Visible = true;
            repBudget.Visible = true;
            repBudget1.Visible = false;
            dt = BGBudItemsManager.GetApplyReimburByDepIDPager(depID, chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt.Columns.Add("IsRed");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["IsRed"] = "0";
            }
            dt = GetByDeptDt(dt);
        }

        if (dt.Rows.Count < 1)
        {
            lashow.Text = "没有查询到数据。";
            if (repBudget.Visible)
            {
                repBudget.DataSource = dt;
                repBudget.DataBind();
            }
            else
            {
                repBudget1.DataSource = dt;
                repBudget1.DataBind();
            }
        }
        else if (repBudget1.Visible)
        {
            BudgetPager.RecordCount = RecordCount;
            repBudget1.DataSource = dt;
            repBudget1.DataBind();
        }
        else
        {
            BudgetPager.RecordCount = RecordCount;
            repBudget.DataSource = dt;
            repBudget.DataBind();
        }
    }
    private DataTable GetDtAuditorDataBind(string chkType, int depID, int pageIndex)
    {
        int year = common.IntSafeConvert(CurrentYear);
        lashow.Text = "";
        topTb.Visible = true;
        int RecordCount = 0;
        DataTable dt = null;
        if (cbBIProType.Checked)//按项目类型汇总
        {
            Div1.Visible = false;
            topTb.Visible = true;
            repBudget.Visible = true;
            repBudget1.Visible = false;
            dt = BGBudItemsManager.GetSummaryBudInfoPager(chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt = GetProtypeDt(dt);
            hidtotal.Value = total.ToString();
        }
        else if (ddlDep.SelectedValue == "0")//按部门汇总
        {
            Div1.Visible = true;
            topTb.Visible = false;
            repBudget.Visible = false;
            repBudget1.Visible = true;
            dt = BGBudItemsManager.GetSummaryBudInfoPager(chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt.Columns.Add("IsRed");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["IsRed"] = "0";
            }
            dt = GetGroupByDeptDt(dt);
        }
        else//选择部门查询
        {
            Div1.Visible = false;
            topTb.Visible = true;
            repBudget.Visible = true;
            repBudget1.Visible = false;
            dt = BGBudItemsManager.GetApplyReimburByDepIDPager(depID, chkType, pageIndex, BudgetPager.PageSize, out RecordCount, year);
            dt.Columns.Add("IsRed");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["IsRed"] = "0";
            }
        }

        return GetByDeptDt(dt);
    }
    private DataTable GetByDeptDt(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            total += ParseUtil.ToDecimal(dt.Rows[i]["BIMon"].ToString(), 0);
        }
        hidtotal.Value = total.ToString();
        DataRow drNew1 = dt.NewRow();
        drNew1["BICode"] = "汇总统计";
        drNew1["BIStaTime"] = Convert.ToDateTime(CurrentYear + "-10-10");
        drNew1["BudSta"] = "合计";
        drNew1["BudID"] = "-2";
        dt.Rows.Add(drNew1);
        return dt;
    }
    private DataTable GetGroupByDeptDt(DataTable dt)
    {
        if (dt.Rows.Count <= 0)
        {
            return dt;
        }
        DataView dv = dt.DefaultView;
        dv.Sort = "BICode";
        DataTable dt2 = dv.ToTable(true);
        dt2.Columns.Add("DepName");
        for (int i = 0; i < dt2.Rows.Count; i++)
        {

            int depid = common.IntSafeConvert(dt2.Rows[i]["DepID"]);
            dt2.Rows[i]["DepName"] = BGDepartmentManager.GetDepNameBydepid(depid);
            total += ParseUtil.ToDecimal(dt2.Rows[i]["BIMon"].ToString(), 0);
        }
        hidtotal.Value = total.ToString();
        DataRow drNew1 = dt2.NewRow();
        drNew1["BICode"] = "汇总统计";
        drNew1["BIStaTime"] = DateTime.Now;// Convert.ToDateTime(CurrentYear + "-10-10");
        drNew1["BudSta"] = "合计";
        drNew1["BudID"] = "-2";
        dt2.Rows.Add(drNew1);
        return dt2;
    }


    public DataTable GetProtypeDt(DataTable dt)
    {
        decimal TotalMoney = 0;
        dt.Columns.Add("IsRed");

        List<string> listTmp = new List<string>();
        List<string> listIndexTmp = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow drNew = dt.NewRow();
            string year = dt.Rows[i]["StaYear"].ToString();
            string YearProType = year + dt.Rows[i]["BIProType"].ToString();
            dt.Rows[i]["BIFunSub"] = BGDepartmentManager.GetDepBydepid(dt.Rows[i]["DepID"].ToString()).DepName;

            DataRow[] dr = dt.Select("BIProType ='" + dt.Rows[i]["BIProType"].ToString() + "' and StaYear=" + year);


            if (dr.Length > 1)
            {
                TotalMoney = 0;
                for (int j = 0; j < dr.Length; j++)
                {
                    TotalMoney += ParseUtil.ToDecimal(dr[j]["BIMon"].ToString(), 0);

                }
                if (!listTmp.Contains(YearProType))
                {
                    drNew["BICode"] = "项目类型汇总";
                    drNew["BIProType"] = dt.Rows[i]["BIProType"].ToString();
                    drNew["BIProName"] = "";
                    drNew["BIFunSub"] = "";
                    drNew["BIMon"] = TotalMoney;
                    drNew["BIStaTime"] = dt.Rows[i]["BIStaTime"].ToString();
                    drNew["BudSta"] = dt.Rows[i]["BudSta"].ToString();
                    drNew["BudID"] = "-1";
                    drNew["IsRed"] = "-1";
                    dt.Rows.InsertAt(drNew, i);
                    listTmp.Add(YearProType);
                }
            }

            else
            {
                dt.Rows[i]["IsRed"] = "-1";
            }
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["IsRed"] == "-1")
            {
                total += ParseUtil.ToDecimal(dt.Rows[i]["BIMon"].ToString(), 0);
            }
        }
        DataRow drNew1 = dt.NewRow();
        drNew1["BICode"] = "汇总统计";
        drNew1["BIStaTime"] = Convert.ToDateTime(CurrentYear + "-10-10");
        drNew1["BudSta"] = "合计";
        drNew1["BudID"] = "-2";
        dt.Rows.Add(drNew1);
        return dt;
    }



    protected void repBudget_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string budid = e.CommandArgument.ToString();
        if (e.CommandName == "Review")
        {
            Response.Redirect("BudgetCollectDatails.aspx?budid=" + budid, true);

        }
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        depid = common.IntSafeConvert(ddlDep.SelectedValue);
        int year= common.IntSafeConvert(ddlyear.SelectedValue);
        hidDepID.Value = depid.ToString();
        string chkType = "审核通过";
        if (rbtnReported.Checked)
        {
            chkType = "已上报";
        }
        int t = BudgetPager.CurrentPageIndex > BudgetPager1.CurrentPageIndex
            ? BudgetPager.CurrentPageIndex
            : BudgetPager1.CurrentPageIndex;
        if (BudgetPager.CurrentPageIndex>0)
        {
            BudgetPager.CurrentPageIndex = 0;
        }
        else
        {
            BudgetPager1.CurrentPageIndex = 0;
        }
        AuditorDataBind(chkType, depid,year, 0);

    }
    protected void BudgetPager_PageChanged(object sender, EventArgs e)
    {
        int year =common.IntSafeConvert(ddlyear.SelectedValue);
        string chkType = "审核通过";
        if (rbtnReported.Checked)
        {
            chkType = "已上报";
        }
        int t = BudgetPager.CurrentPageIndex > BudgetPager1.CurrentPageIndex
            ? BudgetPager.CurrentPageIndex
            : BudgetPager1.CurrentPageIndex;
        AuditorDataBind(chkType, common.IntSafeConvert(hidDepID.Value),year, t - 1);
    }
    protected void repBudget_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("linkReview") as LinkButton;
        if (lbtn.CommandArgument == "-1")
        {
            lbtn.Text = "汇总统计行";
            lbtn.Enabled = false;
        }
        if (lbtn.CommandArgument == "-2")
        {
            lbtn.Text = hidtotal.Value;
            lbtn.Enabled = false;
        }
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        depid = common.IntSafeConvert(ddlDep.SelectedValue);
        hidDepID.Value = depid.ToString();
        string chkType = "审核通过";
        if (rbtnReported.Checked)
        {
            chkType = "已上报";
        }
        DataTable dt = GetDtAuditorDataBind(chkType, depid, 0);
        CreateSheetget(dt);         //Response.ContentType = "application/xls";
        //Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("报销单历史查询.xls", System.Text.Encoding.UTF8));
        //Response.BinaryWrite(ms.ToArray()); 
        //Response.End();

    }

    private DataTable getnewdt(DataTable dt)
    {
        DataTable datNew = dt.DefaultView.ToTable(false, new string[] { "DepName", "BIProType", "BIProName", "BIMon", "StaYear", "BudSta" });
        return datNew;
    }

    private DataTable getnewdt1(DataTable dt)
    {
        DataTable datNew = dt.DefaultView.ToTable();
        datNew.Columns.Add("ProProper");
        for (int i = 0; i < datNew.Rows.Count; i++)
        {
            DataTable dtbppjm = BGPayProjectManager.GetPayProjectByPPID(common.IntSafeConvert(datNew.Rows[i]["PPID"]));
            datNew.Rows[i]["ProProper"] = dtbppjm.Rows[0]["PayPrjName"].ToString();
            datNew.Rows[i]["BIFunSub"] = BGDepartmentManager.GetDepBydepid(dt.Rows[i]["DepID"].ToString()).DepName;
        }
        return datNew;
    }

    //创建sheet  
    public void CreateSheetget(DataTable dtold)
    {
        MemoryStream ms = new MemoryStream();
        DataTable dt = getnewdt1(dtold);
        DataTable dt0 = getnewdt(dtold);
        //MemoryStream ms = ExcelRender.RenderToExcelSetHead_bg_co(getnewdt(dt), "部门名称 #项目类型#项目名称#预算金额#年度#项目状态");
        HSSFWorkbook workbook = new HSSFWorkbook();
        // 新增試算表。 
        HSSFCellStyle style1 = (HSSFCellStyle)workbook.CreateCellStyle();
        style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_CORNFLOWER_BLUE.index;
        style1.FillPattern = FillPatternType.SOLID_FOREGROUND;
        for (int i = 0; i < dt.Rows.Count + 1; i++)
        {

            if (i < dt.Rows.Count)
            {
                ISheet sheet = workbook.CreateSheet(dt.Rows[i]["DepName"].ToString() + i);
                //ICell cell;
                //IRow row;
                //for (int k = 0; k < 14; k++)
                //{
                //    row = sheet.CreateRow(k);
                //    for (int j = 0; j < 4; j++)
                //    {
                //        cell = row.CreateCell(j); 
                //    }
                //}
                ////在工作表中：建立行，参数为行号，从0计cell = sheet.CreateRow(0).CreateCell(0); 
                //IRow row = sheet.CreateRow(0);
                ////在行中：建立单元格，参数为列号，从0计
                //ICell cell = cell;
                ////将新的样式赋给单元格  
                IRow row = sheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("项目类别：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIProType"].ToString());
                row.CreateCell(2).SetCellValue("功能科目：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIFunSub"].ToString());
                row = sheet.CreateRow(1);
                row.CreateCell(0).SetCellValue("项目编号：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BICode"].ToString());
                row.CreateCell(2).SetCellValue("项目名称：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIProName"].ToString());
                row = sheet.CreateRow(2);
                row.CreateCell(0).SetCellValue("行政成本类别：");
                row.CreateCell(1).SetCellValue("行政单位一般行政管理项目支出");
                row.CreateCell(2).SetCellValue("项目安排频度：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIPlanHz"].ToString());
                row = sheet.CreateRow(3);
                row.CreateCell(0).SetCellValue("项目起始时间：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIStaTime"].ToString());
                row.CreateCell(2).SetCellValue("项目终止时间：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIEndTime"].ToString());
                row = sheet.CreateRow(4);
                row.CreateCell(0).SetCellValue("项目负责人：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BICharger"].ToString());
                row.CreateCell(2).SetCellValue("项目属性：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["ProProper"].ToString());
                row = sheet.CreateRow(5);
                row.CreateCell(0).SetCellValue("项目类型：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIProType"].ToString());
                row.CreateCell(2).SetCellValue("预算控制数：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIConNum"].ToString());
                row = sheet.CreateRow(6);
                row.CreateCell(0).SetCellValue("项目报进日期：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIReportTime"].ToString());
                row.CreateCell(2).SetCellValue("预算金额：");
                row.CreateCell(3).SetCellValue(dt.Rows[i]["BIMon"].ToString());
                row = sheet.CreateRow(7);
                row.CreateCell(0).SetCellValue("项目简介：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIProDescrip"].ToString());
                row = sheet.CreateRow(8);
                row.CreateCell(0).SetCellValue("项目申请理由和主要内容：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIAppReaCon"].ToString());
                row = sheet.CreateRow(9);
                row.CreateCell(0).SetCellValue("项目支出测算依据及说明：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIExpGistExp"].ToString());
                row = sheet.CreateRow(10);
                row.CreateCell(0).SetCellValue("项目绩效长期目标：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BILongGoal"].ToString());
                row = sheet.CreateRow(11);
                row.CreateCell(0).SetCellValue("项目绩效年度目标：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIYearGoal"].ToString());
                row = sheet.CreateRow(12);
                row.CreateCell(0).SetCellValue("其他说明的问题：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BIOthExpProb"].ToString());
                row = sheet.CreateRow(13);
                row.CreateCell(0).SetCellValue("退回原因：");
                row.CreateCell(1).SetCellValue(dt.Rows[i]["BICause"].ToString());
                ExcelRender.AutoSizeColumns(sheet);
            }
            else
            {
                ISheet sheet = workbook.CreateSheet("预算汇总表");
                ExcelRender.RenderToExcelSetHead_bg_co(dt0, "部门名称 #项目类型#项目名称#预算金额#年度#项目状态", sheet);
            }
        }
        workbook.Write(ms);
        //Response.AddHeader("Content-Disposition", string.Format("attachment; filename=报销单历史查询.xls"));
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("预算汇总列表查询.xls", System.Text.Encoding.UTF8));
        Response.BinaryWrite(ms.ToArray());
        workbook = null;
        ms.Close();
        ms.Dispose();
    }
}