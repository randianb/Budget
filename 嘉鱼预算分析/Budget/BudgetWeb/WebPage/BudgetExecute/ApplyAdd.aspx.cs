using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Configuration;
using System.Data;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;

public partial class WebPage_BudgetExecute_ApplyAdd : BudgetBasePage
{
    protected string arid = string.Empty;
    int depid = 1138;
    public string listallocationstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listallocationstr = Listallocationstr;
        }
        catch (Exception)
        {
            Listallocationstr = "";
        }
        depid = DepID;
        //arid = "1003";//测试时使用

        if (!IsPostBack)
        {
            txtARReiSinNum.Text = ConfigurationManager.AppSettings["AreaCode"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000);
            btnAddDoc.Enabled = false;
            string yearmonth = Request["yearmonth"];
            txtBITime.Text = yearmonth;
            //ddlARExpSub.Enabled = false;  
            //ARExpSubDataBind();
            ARRepDepDataBind();
            ddlARRepDep.RawValue = depid.ToString();
        }
    }

    //private void ARExpSubDataBind()
    //{
    //    DataTable dt = BG_PayIncomeLogic.GetAllBG_PayIncome();
    //    System.Data.DataView dv = dt.DefaultView;
    //    // dv.RowFilter = "sort ID asc";
    //    dt = dv.ToTable(true, "PIEcoSubName");
    //    storeddlARExpSub.DataSource = dt;
    //    storeddlARExpSub.DataBind();
    //    ddlARExpSub.Items.Insert(0, new Ext.Net.ListItem("--请选择--"));
    //}

    private void ARRepDepDataBind()
    {
        DataTable dt = new DataTable(); //BGDepartmentManager.GetDepByfadepid(depid);
        if (depid == AreaDepID)
        {
            dt = BGDepartmentManager.GetDepByfadepid(depid);
        }
        else
        {
            dt = BGDepartmentManager.GetDepByDepid(depid);
        }
        System.Data.DataView dv = dt.DefaultView;
        dt = dv.ToTable(true, "DepID", "DepName");
        storeddlARRepDep.DataSource = dt;
        storeddlARRepDep.DataBind();
    }
    //private void cbPayProjectBind()
    //{
    //    DataTable dt = BG_PayProjectManager.GetAllBG_PayProject();
    //    ddlARExpPro.DataTextField = "PayPrjName";
    //    ddlARExpPro.DataValueField = "PPID";
    //    ddlARExpPro.DataSource = dt;
    //    ddlARExpPro.DataBind();
    //}

    protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
    {
        if (ddlARExpSub.Text == "--请选择--")
        {
            ddlARExpSub.IndicatorText = "请选择一项具体的经济科目！";
            return;
        }

        BG_ApplyReimbur bt = new BG_ApplyReimbur();
        bt.ARAgent = txtARAgent.Text.Trim();                              //经办人
        bt.ARExcu = txtARExcu.Text.Trim();                               //事由
        //bt.ARExpPro = ddlARExpPro.SelectedItem.Value;                    //支出项目
        DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(ddlARExpSub.Text);
        bt.PPID = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
        //bt.ARExpType = ddlARExpType.Text.Trim();                        //支出类型
        bt.ARListSta = "未提交";                        //申请表状态
        bt.ARMon = decimal.Parse(txtARMon.Text.Trim())/10000;                 //金额 
        bt.ARReiSinNum = txtARReiSinNum.Text.Trim();         //报销单号
        bt.ARRepDep = ddlARRepDep.SelectedItem.Text.Trim();                          //上报部门
        bt.ARTime = DateTime.Parse(txtBITime.Text.Trim());                                       //申请时间
        bt.DepID = DepID;       //部门
        string msg = "";
        decimal armon = 0;
        if (!string.IsNullOrEmpty(Session["txtARMon"].ToString()))
        {
            armon = ParseUtil.ToDecimal(Session["txtARMon"].ToString(), 2);
        }
        if (decimal.Parse(txtARMon.Text.Trim()) > armon*10000)
        {
            msg = "报销金额大于当月所剩金额，不允许报销！";
            //btnAdd.Enabled = false;
            X.Msg.Alert("提示", msg).Show();
            return;
        }
        int iden = BGApplyReimburManager.AddApplyReimbur(bt);
        if (iden > 0)
        {
            msg = "添加报销单已完成，如果需要添加报销单据，可选择添加报销类型然后点击添加报销单。";
            X.Msg.Alert("提示", msg).Show();
            //Response.Write("<script language='javascript'>if(confirm('是否继续添加?')){window.location.reload();}else{$(#'btnAddDoc').Enable=true;}</script>");
            Session["ARID"] = iden.ToString();
            btnAddDoc.Enable(true);
            Session["content"] = bt.ARRepDep + "*" + bt.ARTime + "*" + bt.ARMon.ToString() + "*" + bt.ARAgent;
            Session["content1"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon + "*" + bt.ARAgent + "*" + bt.ARExcu;
            Session["content2"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon + "*" + bt.ARAgent + "*" + bt.ARExcu + "*" + bt.ARListSta;
            Session["content3"] = bt.ARRepDep + "*" + bt.ARTime.ToString() + "*" + bt.ARMon;
        }
        else
        {
            msg = "添加失败，请重新添加";
            X.Msg.Alert("提示", msg).Show();
        }
        btnAdd.Disabled=true;
    }

    protected void btnexit_DirectClick(object sender, DirectEventArgs e)
    {
        Response.Redirect("ApplyList.aspx", true);
    }

    protected void btnAddDoc_DirectClick(object sender, DirectEventArgs e)
    {
        if (Session["ARID"] != null)
        {
            arid = Session["ARID"].ToString();
        }
        string strcontent = Session["content"].ToString();
        string strcontent1 = Session["content1"].ToString();
        string strcontent2 = Session["content2"].ToString();
        string strcontent3 = Session["content3"].ToString();
        if (arid == "0")
            return;

        if (radMed.Checked)
        {
            Response.Redirect("ApplyMediCost.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent1, true);
        }
        else if (radPur.Checked)
        {
            Response.Redirect("OfficeSupplies.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radTrain.Checked)
        {
            Response.Redirect("Train.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radMeet.Checked)
        {
            Response.Redirect("ConferenceFees.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent3, true);
        }
        else if (radPrint.Checked)
        {
            Response.Redirect("InformationPrinted.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent, true);
        }
        else if (radOth.Checked)
        {
            Response.Redirect("Expense.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent1, true);
        }
        else if (radTra.Checked)
        {
            Response.Redirect("BusinessTrip.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radCar.Checked)
        {
            Response.Redirect("CarRecordSheet.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radMaintenance.Checked)
        {
            Response.Redirect("Maintenance.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }
        else if (radUnion.Checked)
        {
            Response.Redirect("GuildActivity.aspx?arid=" + arid + "&oper=1" + "&strcontent=" + strcontent2, true);
        }

    }


    //protected void ddlARExpType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlARExpType.Text.ToString() == "基本支出")
    //    {
    //        ARExpSubDataBind();
    //        ddlARExpPro.Enabled = false;
    //    }
    //    if (ddlARExpType.Text.ToString() == "项目支出")
    //    {
    //        cbPayProjectBind();
    //        cbPayIncomeBind();
    //        ddlARExpPro.Enabled = true;
    //    }
    //}
    [DirectMethod]
    public void SelectChange()
    {
        Session["txtARMon"] = "";
        txtBITime.IndicatorText = "";
        txtARMon.IndicatorText = "";
        txtARAgent.IndicatorText = "";
        if (ddlARExpSub.Text.Contains("--请选择--"))
        {
            return;
        }
        btnAdd.Enabled = true;
        if (txtBITime.Text == "0001/1/1 0:00:00")
        {
            txtBITime.IndicatorText = "请先选择报销时间";
            return;
        }
        if (ddlARExpSub.Text.Contains("差旅费"))
        {
            radTra.Hidden = false;
            radTra.Checked = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("医疗费"))
        {
            radMed.Hidden = false;
            radMed.Checked = true;
            radTra.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("办公设备购置费"))
        {
            radPur.Hidden = false;
            radPur.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("培训费"))
        {
            radTrain.Hidden = false;
            radTrain.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("会议费"))
        {
            radMeet.Hidden = false;
            radMeet.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("印刷费"))
        {
            radPrint.Hidden = false;
            radPrint.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("维修（护）费"))
        {
            radMaintenance.Hidden = false;
            radMaintenance.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("工会经费"))
        {
            radUnion.Hidden = false;
            radUnion.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radMaintenance.Hidden = true;
            radCar.Hidden = true;
        }
        else if (ddlARExpSub.Text.Contains("公务用车运行维护费"))
        {
            radCar.Hidden = false;
            radCar.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radPrint.Hidden = true;
            radUnion.Hidden = true;
            radMaintenance.Hidden = true;
        }
        else
        {
            radOth.Hidden = false;
            radOth.Checked = true;
            radTra.Hidden = true;
            radMed.Hidden = true;
            radPur.Hidden = true;
            radTrain.Hidden = true;
            radMeet.Hidden = true;
            radMaintenance.Hidden = true;
            radUnion.Hidden = true;
            radCar.Hidden = true;
        }

        if (ddlARExpSub.Text == "0")
        {
            return;
        }
        DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(ddlARExpSub.Text);
        int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
        string ARTime = Convert.ToDateTime(txtBITime.Text.Trim()).ToString("yyyy-MM");
        if (!BG_ApplyReimburLogic.ISApplyBackMon(piid,ARTime, DepID))// BG_ApplyReimburLogic.GetARMon(ppid, DepID, ARTime);
        {
            //DataTable dt = BG_ApplyReimburLogic.GetARMon(piid, DepID, ARTime);
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) - BG_ApplyReimburLogic.GetARMon(ddlARExpSub.Text, ARTime, DepID);
                HidtxtARMon.Text = balance.ToString();
                txtARMon.IndicatorText = "余额为" + (balance*10000).ToString() + "元";
                Session["txtARMon"] = balance;
                if (balance == 0)
                {
                    btnAdd.Enabled = false;
                }
            }
//            else if (BG_ApplyReimburLogic.GetARMon(ddlARExpSub.Text, ARTime, DepID)>0)
//            {
//                decimal balance = BG_ApplyReimburLogic.GetARMon(ddlARExpSub.Text, ARTime, DepID);
//                HidtxtARMon.Text = balance.ToString();
//                txtARMon.IndicatorText = "余额为" + (balance*10000).ToString()  + "元";
//                Session["txtARMon"] = balance; 
//            }
            else
            {
                txtARMon.IndicatorText = "余额为" + "0.00" + "元";
                Session["txtARMon"] = 0;
                btnAdd.Enabled = false;

            }
        }
        else
        {
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) * 10000 -  BG_ApplyReimburLogic.GetARMon(ddlARExpSub.Text, ARTime, DepID) +BG_ApplyReimburLogic.ApplyBackMon(ARTime, DepID);
                HidtxtARMon.Value = balance.ToString();
                txtARMon.IndicatorText = "余额为" + (balance * 10000).ToString() + "元";
                Session["txtARMon"] = balance;
                if (balance == 0)
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                txtARMon.IndicatorText = "余额为" + "0.00" + "元";
                Session["txtARMon"] = 0;
                btnAdd.Enabled = false;

            }

        }
    }
    private decimal getMon(string arexpsub) 
    {
        decimal mon=0;
        DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(arexpsub);
        int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
        string ARTime = Convert.ToDateTime(txtBITime.Text.Trim()).ToString("yyyy-MM");
        if (!BG_ApplyReimburLogic.ISApplyBackMon(piid, ARTime, DepID))// BG_ApplyReimburLogic.GetARMon(ppid, DepID, ARTime);
        {
            //DataTable dt = BG_ApplyReimburLogic.GetARMon(piid, DepID, ARTime);
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) - BG_ApplyReimburLogic.GetARMon(arexpsub, ARTime, DepID);
                mon = balance * 10000; 
            }
            //            else if (BG_ApplyReimburLogic.GetARMon(arexpsub, ARTime, DepID)>0)
            //            {
            //                decimal balance = BG_ApplyReimburLogic.GetARMon(arexpsub, ARTime, DepID);
            //                HidtxtARMon.Text = balance.ToString();
            //                txtARMon.IndicatorText = "余额为" + (balance*10000).ToString()  + "元";
            //                Session["txtARMon"] = balance; 
            //            }
            else
            {
                mon = 0; 

            }
        }
        else
        {
            DataTable dt1 = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, ARTime);
            if (dt1.Rows.Count > 0)
            {
                //lbBalance.Text = (Utils.IntSafeConvert(dt1.Rows[0]["MPFunding"]) - Utils.IntSafeConvert(dt.Rows[0]["ARMon"])).ToString();
                decimal balance = Tdecimal(dt1.Rows[0]["MPFunding"].ToString()) * 10000 - BG_ApplyReimburLogic.GetARMon(arexpsub, ARTime, DepID) + BG_ApplyReimburLogic.ApplyBackMon(ARTime, DepID);
             
                mon = balance * 10000; 
            }
            else
            {
                mon = 0; 
            }

        }
        return mon;
    }
    private decimal Tdecimal(string str)
    {
        decimal sss = 0;
        if (string.IsNullOrEmpty(str))
        {
            sss = 0;
        }
        else
        {
            sss = Convert.ToDecimal(str);
        }
        return sss;
    }

    //protected void CheckField(object sender, RemoteValidationEventArgs e)
    //{
    //    //TextField field = (TextField)sender;

    //    //if (field.Text == "Valid")
    //    //{
    //    //    e.Success = true;
    //    //}
    //    //if (field.Text == "Valid")
    //    //{
    //    //    e.Success = true;
    //    //}
    //    //if (field.Text == "Valid")
    //    //{
    //    //    e.Success = true;
    //    //} 
    //    //else
    //    //{
    //    //    e.Success = false;
    //    //    e.ErrorMessage = "验证不通过";
    //    //}

    //    //System.Threading.Thread.Sleep(1000);
    //}

    //protected void CheckCombo(object sender, RemoteValidationEventArgs e)
    //{
    //    //ComboBox combo = (ComboBox)sender;

    //    //if (combo.SelectedItem.Value == "2")
    //    //{
    //    //    e.Success = true;
    //    //}
    //    //else
    //    //{
    //    //    e.Success = false;
    //    //    e.ErrorMessage = "'Valid' is valid value only";
    //    //}

    //    //System.Threading.Thread.Sleep(1000);
    //}  

    protected void SetValueClick(object sender, DirectEventArgs e)
    {
        //this.ddlARExpSub.SetValue("Item11,Item12", "[Go jogging,Take a nap]");
    }


    private bool ISNode(string NodeID)
    {
        bool valid = false;
        string PIEcoSubName = "";
        if (common.IntSafeConvert(NodeID) == 0)
        {
            valid = true;
        }
        else
        {
            if (BG_PayIncomeLogic.GetLeverByPIID(2))
            {
                return true;
            }
            //if (BG_PayIncomeLogic.GetBoolByPiid(common.IntSafeConvert(NodeID)))
            //{
            //    return true;
            //}
            PIEcoSubName = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(NodeID)).PIEcoSubName;
            string va = "";
            string temstr = Listallocationstr;
            string[] liststr = temstr.Split('*');
            for (int i = 0; i < liststr.Length; i++)
            {
                string[] temtt = liststr[i].Split(',');
                for (int j = 0; j < temtt.Length; j++)
                {
                    va = temtt[j];
                    if (PIEcoSubName == va.Trim())
                    {
                        valid = true;
                    }
                }
            }
        }
        return valid;
    }

    private int SingleNode(string NodeID)
    {
        int t = 0;
        string tem;
        if (common.IntSafeConvert(NodeID) == 0)
        {
            if (NodeID == "PA")
            {
                if (Listallocationstr.Contains("财政拨款") && !Listallocationstr.Contains("其他资金"))
                {
                    t = 2;
                }
                else if (Listallocationstr.Contains("其他资金") && !Listallocationstr.Contains("财政拨款"))
                {
                    t = 1;
                }
                else
                {
                    t = 3;
                }
            }
            if (NodeID == "nodeF")
            {
                if (Listallocationstr.Contains("基本支出") && !Listallocationstr.Contains("项目支出"))
                {
                    t = 21;
                }
                else if (Listallocationstr.Contains("项目支出") && !Listallocationstr.Contains("基本支出"))
                {
                    t = 22;
                }
                else
                {
                    t = 23;
                }
            }
            if (NodeID == "nodeO")
            {
                if (Listallocationstr.Contains("基本支出") && !Listallocationstr.Contains("项目支出"))
                {
                    t = 11;
                }
                else if (Listallocationstr.Contains("项目支出") && !Listallocationstr.Contains("基本支出"))
                {
                    t = 12;
                }
                else
                {
                    t = 13;
                }
            }
        }
        else
        {
            string name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(NodeID)).PIEcoSubName;
            if (Listallocationstr.Contains(name))
            {
                t = 1000;
            }
        }
        return t;
    }
    [DirectMethod]
    public string NodeLoad(string NodeID)
    {
        if (!ISNode(NodeID))
        {
            return "failure";
        }
        NodeCollection nodes = new NodeCollection();
        int tem = 1;
        int nodeID = common.IntSafeConvert(NodeID);
        string Financial_allocation = "财政拨款";
        string BasicIncome = "基本支出";
        SetNode(tem, Financial_allocation, BasicIncome, nodes);
        return nodes.ToJson();
    }

    private void SetNode(int tem, string ftype, string incomeinfo, NodeCollection node)
    {
        string YearMonth = txtBITime.Text.Substring(0, 7);
        decimal total = 0;
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        for (int i = 0; i < dtpay.Rows.Count; i++)
        {
            total += ParToDecimal.ParToDel(dtpay.Rows[i][1].ToString()) + ParToDecimal.ParToDel(dtpay.Rows[i][2].ToString());
        }
        Session["total"] = total;
        DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID);
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(incomeinfo, ftype, tem);
        int year = common.IntSafeConvert(CurrentYear);
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                Node nodeN = new Node();
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                decimal Mon = ParseUtil.ToDecimal(getMon(nodeN.Text).ToString(), 0);
                if (!BG_PayIncomeLogic.GetBoolPayIncome(incomeinfo, ftype, piid))
                {
                    nodeN.Icon = Icon.Anchor;
                    node.Add(nodeN);
                    nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                    nodeN.Leaf = true;
                }
                else
                {
                    if (SingleNode(piid.ToString()) == 0)
                    {
                        break;
                    }
                    else if (BG_PayIncomeLogic.ISSign(piid))
                    {

                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                    }
                    else
                    {
                        nodeN.Icon = Icon.Folder;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                        SetNode(piid, nodeN);
                    }
                }

            }

        }
    }

    private void SetNode(int tem, Node node)
    {
        string YearMonth = txtBITime.Text.Substring(0, 7);
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID);
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncomeByPIID(tem);
        int year = common.IntSafeConvert(CurrentYear);
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                Node nodeN = new Node();
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                decimal Mon=ParseUtil.ToDecimal(getMon(nodeN.Text).ToString(),0);
                if (BG_PayIncomeLogic.GetBoolPayIncomeByPIID(tem))
                {

                    if (!BG_PayIncomeLogic.GetBoolPayIncomeByPIID(common.IntSafeConvert(piid)))
                    {
                        nodeN.Icon = Icon.Anchor;
                        node.Children.Add(nodeN);
                        nodeN.Leaf = true;
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                    }
                    else
                    {
                        if (BG_PayIncomeLogic.GetLever(3))
                        {
                            nodeN.Icon = Icon.Anchor;
                            node.Children.Add(nodeN);
                            nodeN.Leaf = true;
                            nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                        }
                        else
                        {
                            nodeN.Icon = Icon.Folder;
                            node.Children.Add(nodeN);
                            nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                            //SetNode(piid, nodes);
                        }
                    }
                }
                else
                {
                    if (SingleNode(piid.ToString()) == 0)
                    {
                        break;
                    }
                    else if (BG_PayIncomeLogic.ISSign(piid))
                    {
                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Children.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                    }
                    else
                    {
                        nodeN.Icon = Icon.Folder;
                        node.Children.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", Mon.ToString(), ParameterMode.Value));
                        //SetNode(piid, nodes);
                    }
                }
            }
        }
    }
}