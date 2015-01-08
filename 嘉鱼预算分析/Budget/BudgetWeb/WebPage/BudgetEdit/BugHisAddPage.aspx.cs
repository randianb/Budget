using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_BudgetEdit_BugHisAddPage : BudgetBasePage
{
    int buid = 0;
    int pPID = 0;
    int depid = 0;
    //string decodeuse = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 获取添加预算的部门
        //if (Request.QueryString["htruse"] != null)
        //{
        //    decodeuse = HttpUtility.UrlDecode(Request.QueryString["htruse"]);
        //    Editbind();
        //}  
        
        if (Request.QueryString["budid"] != null)
        {
            buid = common.IntSafeConvert(Request.QueryString["budid"]);
            Hidbuid.Value = buid.ToString();
        }
        else
        {
            if (!string.IsNullOrEmpty(Hidbuid.Value))
            {
                buid = common.IntSafeConvert(Hidbuid.Value);
            }
            else
            {
                Response.Redirect("BudgetEditList.aspx", true);
            }
        }
        #endregion
        cmbPayProTypeBind();
        ddlPayProTypeBind();//支出项目 
        //ddlIncomeBind();//经济科目 
        txtBind(buid);

        //txt2.Text = DateTime.Now.Year.ToString();//年度（未来要替换）
        txtItemNumber.Text = BGBudItemsManager.GetBICode(CurrentYear);//yj
        txtItemNumber1.Text = BGBudItemsManager.GetBICode(CurrentYear);//yj


        //depid = common.IntSafeConvert(Request["depid"]);
        ddlDepBind();
        //cbPayProjectBind();
        cbPayIncomeBind();
        ddlIncomeBind();
    }


    private void txtBind(int buid)
    {
        BG_BudItems bi = BGBudItemsManager.GetBudItemsByBudid(buid);
        if (bi != null)
        {
            txtBIAppReaCon.Text = bi.BIAppReaCon;
            // txtProName.Text = bi
            ddlProProper.SelectedValue = bi.BIAttr;
            txtBICharger.Text = bi.BICharger;
            txtItemNumber.Text = bi.BICode.ToString();
            txtBIExpGistExp.Text = bi.BIExpGistExp;
            ddlFunSub.SelectedValue = bi.BIFunSub;
            txtBILongGoal.Text = bi.BILongGoal;
            txtBIOthExpProb.Text = bi.BIOthExpProb;
            ddlBIPlanHz.Text = bi.BIPlanHz.ToString();
            //ddlPayProType.SelectedValue = bi.BIProType;
            txtBIStaTime.Text = bi.BIStaTime.ToString("yyyy-MM-dd");
            txtBIEndTime.Text = bi.BIEndTime.ToString("yyyy-MM-dd");
            txtBITime.Text = bi.BIReportTime.ToString("yyyy-MM-dd");
            txtBIYearGoal.Text = bi.BIYearGoal;
            ddlPayProType.SelectedValue = bi.PPID.ToString();
            //hidPPID.Value = bi.PPID.ToString();
            txtProName.Text = bi.BIProName.ToString();
            txtProDesc.Text = bi.BIProDescrip.ToString();
            //txtBIMon.Text = bi.BIMon.ToString();
            //txtBackReason.Text = bi.BICause;
            txtBudConNumber.Text = bi.BIConNum.ToString();
            HidRowCount.Value = BGBudCostProManager.GetBudCostProCountByBudid(buid).ToString();
            Hiddepid.Value = bi.DepID.ToString();
            ddlProType.SelectedValue = bi.BIProCategory;
        }
    }
    //private void Editbind()
    //{
    //    string[] strlist = decodeuse.Value.ToString().Split('*');
    //    for (int i = 0; i < strlist.Count(); i++)
    //    {
    //        TFBIProDescrip.Text = strlist[0];
    //        TFBILAppReaCon.Text = strlist[1];
    //        TFBILExpGistExp.Text = strlist[2];
    //        TFBILLongGoal.Text = strlist[3];
    //        TFBILYearGoal.Text = strlist[4];
    //        TFBILOthExpProb.Text = strlist[5];
    //    }

    //}
    //绑定部门
    private void ddlDepBind()
    {
        DataTable depTable = null;
        //if (depid == 0)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        //{
        depTable = BGDepartmentManager.GetDepByfadepid(1083);
        //}
        //else
        //{
        //    depTable = BGDepartmentManager.GetDepByDepid(depid);
        //}
        for (int i = 0; i < depTable.Rows.Count; i++)
        {
            cb2.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["DepName"].ToString(), depTable.Rows[i]["DepID"].ToString()));
        }
    }



    private void cbPayProjectBind()
    {
        DataTable dt = BG_PayProjectManager.GetAllBG_PayProject();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            cb3.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["PayPrjName"].ToString(), dt.Rows[i]["PPID"].ToString()));
            cmbPayProType.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["PayPrjName"].ToString(), dt.Rows[i]["PPID"].ToString()));
        }
    }

    private void cbPayIncomeBind()
    {

        DataTable dt = BGPayIncomeManager.GetPayIncome();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            cb4.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["PIEcoSubName"].ToString(), dt.Rows[i]["PIID"].ToString()));
        }
    }

    [DirectMethod]
    public void GetSelect1()
    {
        cb2.Hidden = false;
        Button1.Hidden = false;
        cb3.Hidden = true;
        cb4.Hidden = true;
        //tf.Hidden = true;

    }

    [DirectMethod]
    public void GetSelect2()
    {
        cb2.Hidden = true;
        Button1.Hidden = false;
        cb3.Hidden = false;
        cb4.Hidden = true;
        //tf.Hidden = true;
    }

    [DirectMethod]
    public void GetSelect3()
    {
        cb2.Hidden = true;
        cb3.Hidden = true;
        cb4.Hidden = false;
        Button1.Hidden = false;
        //tf.Hidden = true;

    }

    [DirectMethod]
    public void GetSelect4()
    {
        cb2.Hidden = true;
        cb3.Hidden = true;
        cb4.Hidden = true;
        //tf.Hidden = false;
        Button1.Hidden = false;
    }
    [DirectMethod]
    public void ModifyPolicy(string Budid)
    {
        Window1.Show();
        int budid = common.IntSafeConvert(Budid);
        BudItID.Value = Budid;
        cmbPayProTypeBind();
        ItemsLibBind(budid);

    }
    /// <summary>
    /// 支出项目
    /// </summary>
    private void cmbPayProTypeBind()
    {
        DataTable dt = BGPayProjectManager.GetAllPayProject();//yj
        if (dt != null && dt.Rows.Count > 0)
        {
            StorePayProType.DataSource = dt;
            StorePayProType.DataBind();
        }
        else
        {
            X.Msg.Alert("提示", "数据为空").Show();
        }
    }
    private void ItemsLibBind(int budid)
    {
        //GetBGBudItemsLibrariesbudID
        DataTable bi = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesBybudID(budid);
        if (bi != null)
        {
            cmbProProper.SelectedItem.Text = bi.Rows[0]["BILAttr"].ToString();
            cmbFunSub.SelectedItem.Text = bi.Rows[0]["BILFunSub"].ToString();
            //TFBICode.Text = budid.ToString();//bi.Rows[0]["BICode"].ToString();
            TFProName.Text = bi.Rows[0]["BILProName"].ToString();
            //TFBIPlanHz.Text = bi.Rows[0]["BILPlanHz"].ToString();
            //TFStartTime.Text = bi.Rows[0]["BILStaTime"].ToString();
            //TFEndTime.Text = bi.Rows[0]["BILEndTime"].ToString();
            //TFBICharger.Text = bi.Rows[0]["BILCharger"].ToString();
            cmbBIProType.SelectedItem.Text = bi.Rows[0]["BILProType"].ToString();
            //cmbPayProType.SelectedItem.Value = bi.Rows[0]["PIID"].ToString();
            TFConNum.Text = bi.Rows[0]["BILMon"].ToString();
            //TFReportTime.Text = bi.Rows[0]["BIReportTime"].ToString();
            TFBIProDescrip.Text = bi.Rows[0]["BILProDescrip"].ToString();
            TFBILAppReaCon.Text = bi.Rows[0]["BILAppReaCon"].ToString();
            TFBILExpGistExp.Text = bi.Rows[0]["BILExpGistExp"].ToString();
            TFBILLongGoal.Text = bi.Rows[0]["BILLongGoal"].ToString();
            TFBILOthExpProb.Text = bi.Rows[0]["BILOthExpProb"].ToString();
            TFBILYearGoal.Text = bi.Rows[0]["BILYearGoal"].ToString();
        }
    }

    private void Bind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("BICode");
        dt.Columns.Add("BIProName");
        dt.Columns.Add("BIProType");
        dt.Columns.Add("BIFunSub");
        dt.Columns.Add("BIMon");
        dt.Columns.Add("BICon");
        dt.Columns.Add("BudSta");
        DataRow dr = dt.NewRow();
        dr["BICode"] = "1";
        dr["BIProName"] = "财务部";
        dr["BIProType"] = "名称1";
        dr["BIFunSub"] = "类型1";
        dr["BIMon"] = "100.00";
        dr["BICon"] = "无";
        dr["BudSta"] = "无";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["BICode"] = "2";
        dr["BIProName"] = "会计部";
        dr["BIProType"] = "名称2";
        dr["BIFunSub"] = "类型2";
        dr["BIMon"] = "200.00";
        dr["BICon"] = "无";
        dr["BudSta"] = "无";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["BICode"] = "3";
        dr["BIProName"] = "技术部";
        dr["BIProType"] = "名称3";
        dr["BIFunSub"] = "类型3";
        dr["BIMon"] = "300.00";
        dr["BICon"] = "无";
        dr["BudSta"] = "无";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["BICode"] = "4";
        dr["BIProName"] = "工程部";
        dr["BIProType"] = "名称4";
        dr["BIFunSub"] = "类型4";
        dr["BIMon"] = "400.00";
        dr["BICon"] = "无";
        dr["BudSta"] = "无";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["BICode"] = "5";
        dr["BIProName"] = "财务部";
        dr["BIProType"] = "名称5";
        dr["BIFunSub"] = "类型5";
        dr["BIMon"] = "500.00";
        dr["BICon"] = "无";
        dr["BudSta"] = "无";
        dt.Rows.Add(dr);

        stBudget.DataSource = dt;
        stBudget.DataBind();
    }

    //选择支出项目
    protected void ddlPayProType_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlIncomeBind();
    }
    /// <summary>
    /// 支出项目
    /// </summary>
    private void ddlPayProTypeBind()
    {


        DataTable dt = BGPayProjectManager.GetAllPayProject();//yj
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlPayProType.DataSource = dt;
            ddlPayProType.DataTextField = "PayPrjName";
            ddlPayProType.DataValueField = "PPID";
            ddlPayProType.DataBind();
            ddlPayProType1.DataSource = dt;
            ddlPayProType1.DataTextField = "PayPrjName";
            ddlPayProType1.DataValueField = "PPID";
            ddlPayProType1.DataBind();
            if (HidPPID.Value.Length > 0)
            {
                ddlPayProType.SelectedValue = HidPPID.Value;
                ddlPayProType1.SelectedValue = HidPPID.Value;
            }
            else
            {
                ddlPayProType.SelectedIndex = 0;
                ddlPayProType1.SelectedIndex = 0;
            }
        }

    }
    ///// <summary>
    ///// 绑定经济科目
    ///// </summary>
    ///// <param name="PPID"></param>
    //private void ddlIncomeBind()
    //{
    //    DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(ddlPayProType.SelectedValue));//yj
    //    if (dt.Rows.Count > 0)
    //    {
    //        ddlIncome.DataSource = dt;
    //        ddlIncome.DataTextField = "PIEcoSubName";
    //        ddlIncome.DataValueField = "PIID";
    //        ddlIncome.DataBind();
    //    }
    //}
    private void ddlIncomeBind()
    {
        //DataTable dt = BGPayIncomeManager.GetPayIncomeByPPID(common.IntSafeConvert(ddlPayProType.SelectedValue));//yj
        //if (dt.Rows.Count > 0)
        //{
        //    ddlIncome.DataSource = dt;
        //    ddlIncome.DataTextField = "PIEcoSubName";
        //    ddlIncome.DataValueField = "PIEcoSubName";
        //    ddlIncome.DataBind();
        //}
        DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
        ddlIncome.DataSource = dt;
        ddlIncome.DataTextField = "PIEcoSubName";
        ddlIncome.DataValueField = "PIEcoSubName";
        ddlIncome.DataBind();
    }
    //返回
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetEditList.aspx", true);
    }


    /// <summary>
    /// 统计预算金额
    /// </summary>
    /// <param name="mon"></param>
    /// <returns></returns>
    private decimal GetBIMon(string[] mon)
    {
        decimal bimon = 0;
        if (mon.Length > 0)
        {
            for (int i = 0; i < mon.Length; i++)
            {
                bimon += ParseUtil.ToDecimal(mon[i], 0);
            }
        }
        return bimon;
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {

        BG_BudItems bi = new BG_BudItems();
        bi.BIAppConMon = 0;// decimal.Parse(txtBudConNumber.Text.Trim());审批控制金额，应该是预算控制数
        bi.BIAppReaCon = txtBIAppReaCon1.Text.Trim();
        bi.BIAttr = ddlProProper1.SelectedValue;
        bi.BIBudSta = "等下对接"; //Session[Constant.UserName].ToString();  
        bi.BICause = "";//退回原因
        bi.BICharger = txtBICharger1.Text.Trim();
        bi.BICode = txtItemNumber1.Text.Trim(); //项目编号
        bi.BIEndTime = DateTime.Parse(txtBIEndTime1.Text.Trim());
        bi.BIExpGistExp = txtBIExpGistExp1.Text.Trim();
        bi.BIFinAllo = 0;// decimal.Parse(txtBudConNumber.Text.Trim());财政拨款
        bi.BIFunSub = ddlFunSub1.Text.Trim();
        bi.BILastYearCarry = 0;// decimal.Parse(txtBudConNumber.Text.Trim());上年结账
        bi.BILongGoal = txtBILongGoal1.Text.Trim();
        bi.BIMon = common.IntSafeConvert(HidMonTotal.Value);      //GetBIMon(coll.GetValues("txt4"));
        bi.BIMonSou = "";//资金来源
        bi.BIOthExpProb = txtBIOthExpProb1.Text.Trim();
        bi.BIOthFun = 0;// decimal.Parse(txtBudConNumber.Text.Trim());其他资金
        bi.BIPlanHz = ddlBIPlanHz1.SelectedValue; //项目频度
        bi.BIProType = ddlPayProType1.SelectedItem.Text;
        bi.BIStaTime = DateTime.Parse(txtBIStaTime1.Text.Trim());
        bi.BIYearGoal = txtBIYearGoal1.Text.Trim();
        bi.PPID = common.IntSafeConvert(ddlPayProType1.SelectedValue);//
        bi.BudSta = "未提交";//
        bi.PIID = BG_PayProjectManager.GetBG_PayProjectByPPID(bi.PPID).PIID; ;//common.IntSafeConvert(ddlFunSub.SelectedValue);//yj
        bi.BIProName = txtProName1.Text.Trim();
        bi.BIReportTime = ParseUtil.ToDateTime(txtBITime1.Text.Trim(), DateTime.Now);
        bi.BIConNum = 0;//预算控制数
        bi.BIProDescrip = txtProDesc1.Text.Trim();
        bi.DepID = common.IntSafeConvert(Hiddepid.Value);
        bi.BIProCategory = ddlProType1.SelectedItem.Text;
        int buid = BGBudItemsManager.AddBudItemsBackbuid(bi);//yj
        if (buid > 0)
        {

            BG_BudItemHis hisbi = new BG_BudItemHis();
            hisbi.BudID = buid;
            hisbi.BIAppConMon = 0;// decimal.Parse(txtBudConNumber.Text.Trim());审批控制金额，应该是预算控制数
            hisbi.BIAppReaCon = txtBIAppReaCon.Text.Trim();
            hisbi.BIAttr = ddlProProper.SelectedValue;
            hisbi.BIBudSta = "等下对接"; //Session[Constant.UserName].ToString();  
            hisbi.BICause = "";//退回原因
            hisbi.BICharger = txtBICharger.Text.Trim();
            hisbi.BICode = txtItemNumber.Text.Trim(); //项目编号
            hisbi.BIEndTime = DateTime.Parse(txtBIEndTime.Text.Trim());
            hisbi.BIExpGistExp = txtBIExpGistExp.Text.Trim();
            hisbi.BIFinAllo = 0;// decimal.Parse(txtBudConNumber.Text.Trim());财政拨款
            hisbi.BIFunSub = ddlFunSub.Text.Trim();
            hisbi.BILastYearCarry = 0;// decimal.Parse(txtBudConNumber.Text.Trim());上年结账
            hisbi.BILongGoal = txtBILongGoal.Text.Trim();
            hisbi.BIMon = common.IntSafeConvert(HidMonTotal.Value);      //GetBIMon(coll.GetValues("txt4"));
            hisbi.BIMonSou = "";//资金来源
            hisbi.BIOthExpProb = txtBIOthExpProb.Text.Trim();
            hisbi.BIOthFun = 0;// decimal.Parse(txtBudConNumber.Text.Trim());其他资金
            hisbi.BIPlanHz = ddlBIPlanHz.SelectedValue; //项目频度
            hisbi.BIProType = ddlPayProType.SelectedItem.Text;
            hisbi.BIStaTime = DateTime.Parse(txtBIStaTime.Text.Trim());
            hisbi.BIYearGoal = txtBIYearGoal.Text.Trim();
            hisbi.PPID = common.IntSafeConvert(ddlPayProType.SelectedValue);//
            hisbi.BudSta = "未提交";//
            hisbi.PIID = BG_PayProjectManager.GetBG_PayProjectByPPID(bi.PPID).PIID; ;//common.IntSafeConvert(ddlFunSub.SelectedValue);//yj
            hisbi.BIProName = txtProName.Text.Trim();
            hisbi.BIReportTime = ParseUtil.ToDateTime(txtBITime.Text.Trim(), DateTime.Now);
            hisbi.BIConNum = 0;//预算控制数
            hisbi.BIProDescrip = txtProDesc.Text.Trim();
            hisbi.DepID = common.IntSafeConvert(Hiddepid.Value);
            hisbi.BIProCategory = ddlProType.SelectedItem.Text;
            int flaid = BG_BudItemHisManager.AddBG_BudItemHis(hisbi).BudHisID;




            NameValueCollection coll = Request.Form;
            string[] txt1 = coll.GetValues("txt1"); //行号
            string[] txt2 = coll.GetValues("txt2"); //当前年度
            string[] txt3 = coll.GetValues("ddlIncome"); //经济科目
            string[] txt4 = coll.GetValues("txt4"); //总计
            string[] txt5 = coll.GetValues("txt5"); //小计(财政拨款)
            string[] txt6 = coll.GetValues("txt6"); //小计(经费)
            string[] txt7 = coll.GetValues("txt7"); //内部开支(经费)	 
            string[] txt8 = coll.GetValues("txt8"); //外部拨款(经费)
            int rowCount = common.IntSafeConvert(HidRowCount.Value);
            bool flag = false;
            if (rowCount > 0 && flaid > 0)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    BG_BudCostPro bcp = new BG_BudCostPro();
                    bcp.BudID = buid;
                    bcp.BCPCurrYear = common.IntSafeConvert(txt2[j]);
                    bcp.BCPRemark = "";
                    DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(txt3[j]);
                    int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]);
                    bcp.PIID = piid;
                    bcp.BCPTotal = ParseUtil.ToDecimal(txt4[j], 0);
                    bcp.BCPSubtFinAllo = ParseUtil.ToDecimal(txt5[j], 0);
                    bcp.BCPSubtExp = ParseUtil.ToDecimal(txt6[j], 0);
                    bcp.BCInExpenses = ParseUtil.ToDecimal(txt7[j], 0);
                    bcp.BCOutFunding = ParseUtil.ToDecimal(txt8[j], 0);
                    flag = BGBudCostProManager.AddBGBudCostPro(bcp);//yj
                }
            }
            if (flag)
            {
                lblShowResult.Text = "添加成功";
                BGBudItemHisManage.InsertBudItemHis(bi);
                string PostUrl = "BudgetEditList.aspx?depid=" + Hiddepid.Value;
                Response.Write("<script language='javascript'>if(confirm('是否继续添加?')){window.location.reload();}else{window.location.href='" + PostUrl + "';}</script>");
            }
            else
            {
                lblShowResult.Text = "操作失败、请检查数据后重试";
            }
        }
        else
        {
            lblShowResult.Text = "操作失败、请检查数据后重试";
        }
    }

    protected void btnSure1_Click(object sender, EventArgs e)
    {
        WinAdd.Show();
    }
    private void GetItemsList()
    {
        string StrPz = cb3.SelectedItem.Text;
        DataTable dt = BGBudItemsLibrariesLogic.GetBudItemsByPz(StrPz);
        stBudget.DataSource = GetDepName(dt);
        stBudget.DataBind();
    }
    private void DepBind()
    {
        depid = common.IntSafeConvert(cb2.SelectedItem.Value);
        DataTable dt = BGBudItemsLibrariesManager.GetBGBudItemsLibraries(depid);
        stBudget.DataSource = dt;
        stBudget.DataBind();
    }

    private void PayProjectBind()
    {
        pPID = common.IntSafeConvert(cb3.SelectedItem.Value);
        DataTable dt = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesProject(pPID);
        stBudget.DataSource = dt;
        stBudget.DataBind();
    }

    private void PayIncomeBind()
    {
        int pIID = common.IntSafeConvert(cb4.SelectedItem.Value);
        DataTable dt = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesProject(pIID);
        stBudget.DataSource = dt;
        stBudget.DataBind();
    }

    //private void PayProjectNameBind()
    //{
    //    string bILProName = tf.Text.ToString();
    //    DataTable dt = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesProjectName(bILProName);
    //    stBudget.DataSource = new DataTable();
    //    stBudget.DataSource = dt;
    //    stBudget.DataBind();
    //}
    //protected void Button1_DirectClick(object sender, DirectEventArgs e)
    //{
    //    GetItemsList();
    //}

    private DataTable GetDepName(DataTable dt)
    {
        if (dt == null && dt.Rows.Count <= 0)
        {
            X.Msg.Alert("提示", "数据为空").Show();
            return dt;
        }

        else
        {
            dt.Columns.Add("DepName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["DepName"] = BGDepartmentManager.GetDepNameBydepid(common.IntSafeConvert(dt.Rows[i]["DepID"]));
            }
            return dt;
        }
    }

    protected void Button1_DirectClick(object sender, DirectEventArgs e)
    {
        if (cb1.SelectedItem.Value == "1")
        {
            DepBind();
        }
        else if (cb1.SelectedItem.Value == "2")
        {
            GetItemsList();
        }
        else if (cb1.SelectedItem.Value == "3")
        {
            PayIncomeBind();
        } 
    }
    //protected void btnuse_DirectClick(object sender, DirectEventArgs e)
    //{
    //    Window1.Hidden = true;
    //    WinAdd.Hidden = true;
    //    DataTable bi = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesBybudID(common.IntSafeConvert(BudItID.Value));
    //    if (bi != null && bi.Rows.Count >= 0)
    //    {
    //        string readuse = "";
    //        //txtBIAppReaCon.Text = bi.Rows[0]["BILAppReaCon"].ToString();
    //        //txtBIExpGistExp.Text = bi.Rows[0]["BILExpGistExp"].ToString();
    //        //txtBILongGoal.Text = bi.Rows[0]["BILongGoal"].ToString();
    //        //txtBIOthExpProb.Text = bi.Rows[0]["BILOthExpProb"].ToString();
    //        //txtBIYearGoal.Text = bi.Rows[0]["BILYearGoal"].ToString();
    //        //txtProDesc.Text = bi.Rows[0]["BILProDescrip"].ToString(); 
    //        readuse += bi.Rows[0]["BILProDescrip"].ToString() + "*";
    //        readuse += bi.Rows[0]["BILAppReaCon"].ToString() + "*";
    //        readuse += bi.Rows[0]["BILExpGistExp"].ToString() + "*";
    //        readuse += bi.Rows[0]["BILLongGoal"].ToString() + "*";
    //        readuse += bi.Rows[0]["BILYearGoal"].ToString() + "*";
    //        readuse += bi.Rows[0]["BILOthExpProb"].ToString();
    //        string htruse = HttpUtility.UrlEncode(readuse);
    //        Response.Redirect("BudgetEditAddPage.aspx?htruse=" + htruse, true);
    //        //TFBIProDescrip.Text  
    //        //TFBILAppReaCon.Text  
    //        //TFBILExpGistExp.Text 
    //        //TFBILLongGoal.Text   
    //        //TFBILYearGoal.Text   
    //        //TFBILOthExpProb.Text 
    //    }
    //}
    protected void btnuse_Click(object sender, EventArgs e)
    {
        DataTable bi = BGBudItemsLibrariesManager.GetBGBudItemsLibrariesBybudID(common.IntSafeConvert(BudItID.Value));
        if (bi != null && bi.Rows.Count >= 0)
        {
            //string readuse = "";
            txtBIAppReaCon1.Text = bi.Rows[0]["BILAppReaCon"].ToString();
            txtBIExpGistExp1.Text = bi.Rows[0]["BILExpGistExp"].ToString();
            txtBILongGoal1.Text = bi.Rows[0]["BILLongGoal"].ToString();
            txtBIOthExpProb1.Text = bi.Rows[0]["BILOthExpProb"].ToString();
            txtBIYearGoal1.Text = bi.Rows[0]["BILYearGoal"].ToString();
            txtProDesc1.Text = bi.Rows[0]["BILProDescrip"].ToString();
            //readuse += bi.Rows[0]["BILProDescrip"].ToString() + "*";
            //readuse += bi.Rows[0]["BILAppReaCon"].ToString() + "*";
            //readuse += bi.Rows[0]["BILExpGistExp"].ToString() + "*";
            //readuse += bi.Rows[0]["BILLongGoal"].ToString() + "*";
            //readuse += bi.Rows[0]["BILYearGoal"].ToString() + "*";
            //readuse += bi.Rows[0]["BILOthExpProb"].ToString();
            //string htruse = HttpUtility.UrlEncode(readuse);
            //Response.Redirect("BudgetEditAddPage.aspx?htruse=" + htruse, true);
            //TFBIProDescrip.Text  
            //TFBILAppReaCon.Text  
            //TFBILExpGistExp.Text 
            //TFBILLongGoal.Text   
            //TFBILYearGoal.Text   
            //TFBILOthExpProb.Text 
        }
    }
}



