using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Xml;
using BudgetWeb.BLL;
using System.Data;
using BudgetWeb.Model;

public partial class WebPage_BudgetControl_MonPayPlanNew : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Getmonth();
        if (Request.QueryString["Month"]!=null)
        {
            string str = Request.QueryString["Month"];
            cmbmon.SelectedItem.Value=str;
        }
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            Incomebalance.Style.Add("color", "red");
            cmbmon.SelectedItem.Index = 0;
        }
        gettotal();
    }
    private void Getmonth()
    {
        //DataTable dt = new DataTable();
        //dt.Columns.Add("month");
        //int mon = BG_MonPayPlanLogic.GetmonthbyMonPayPlan(DepID) + 1;

        //if (mon < 11)
        //{
        //    for (int i = mon; i > 0; i--)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["month"] = "0" + i.ToString();
        //        dt.Rows.Add(dr);
        //    }
        //}
        //else
        //{
        //    for (int i = mon; i > 0; i--)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["month"] = i.ToString();
        //        dt.Rows.Add(dr);
        //    }
        //}

        DataTable dt = new DataTable();
        dt.Columns.Add("month");
        for (int i = 1; i < 13; i++)
        {
            string t = i.ToString();
            if (i<10)
            {
                t = "0" + i;
            } 
            DataRow dr = dt.NewRow();
            dr["month"] = t;
            dt.Rows.Add(dr);
        }
        cmbmonstore.DataSource = dt;
        cmbmonstore.DataBind();
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
        string Other_funds = "其他资金";
        string BasicIncome = "基本支出";
        string ProjectIncome = "项目支出";
        Node rootNode = new Node();
        Node nodeO = new Node();
        Node nodeF = new Node();
        Node nodeFB = new Node();
        Node nodeFP = new Node();
        Node nodeOB = new Node();
        Node nodeOP = new Node();
        if (NodeID == "root")
        {
            rootNode.Text = "经济科目";
            rootNode.NodeID = "PA";
            rootNode.Icon = Icon.Folder;
            nodes.Add(rootNode);
            rootNode.Expanded = true;
        }
        else if (NodeID == "PA")
        {
            if (SingleNode(NodeID) == 2)
            {
                nodeF.NodeID = "nodeF";
                nodeF.Text = Financial_allocation;
                nodeF.Icon = Icon.Folder;
                nodes.Add(nodeF);
                nodeF.Expanded = true;
            }
            //else if (SingleNode(NodeID) == 1)
            //{
            //    nodeO.NodeID = "nodeO";
            //    nodeO.Text = Other_funds;
            //    nodeO.Icon = Icon.Folder;
            //    nodes.Add(nodeO);
            //    nodeO.Expanded = true;
            //}
            else if (SingleNode(NodeID) == 3)
            {
                nodeF.NodeID = "nodeF";
                nodeF.Text = Financial_allocation;
                nodeF.Icon = Icon.Folder;
                nodes.Add(nodeF);
                //nodeO.NodeID = "nodeO";
                //nodeO.Text = Other_funds;
                //nodeO.Icon = Icon.Folder;
                //nodes.Add(nodeO);
                //nodeO.Expanded = true;
                nodeF.Expanded = true;
            }
        }
        else if (NodeID == "nodeF")
        {
            //if (SingleNode(NodeID) == 21)
            //{
            //    nodeFB.NodeID = "nodeFB";
            //    nodeFB.Text = BasicIncome;
            //    nodeFB.Icon = Icon.Folder;
            //    nodes.Add(nodeFB);
            //    nodeFB.Expanded = true;
            //}
            //else if (SingleNode(NodeID) == 22)
            //{
            //    nodeFP.NodeID = "nodeFP";
            //    nodeFP.Text = ProjectIncome;
            //    nodeFP.Icon = Icon.Folder;
            //    nodes.Add(nodeFP);
            //    nodeFP.Expanded = true;
            //}
            //else if (SingleNode(NodeID) == 23)
            //{
            //    nodeFB.NodeID = "nodeFB";
            //    nodeFB.Text = BasicIncome;
            //    nodeFB.Icon = Icon.Folder;
            //    nodes.Add(nodeFB);

            //    nodeFP.NodeID = "nodeFP";
            //    nodeFP.Text = ProjectIncome;
            //    nodeFP.Icon = Icon.Folder;
            //    nodes.Add(nodeFP);
            //    nodeFB.Expanded = true;
            //    nodeFP.Expanded = true;
            //}
            nodeFB.NodeID = "nodeFB";
            nodeFB.Text = BasicIncome;
            nodeFB.Icon = Icon.Folder;
            nodes.Add(nodeFB);
            nodeFB.Expanded = true;
        }
        else if (NodeID == "nodeO")
        {
            if (SingleNode(NodeID) == 11)
            {
                nodeOB.NodeID = "nodeOB";
                nodeOB.Text = BasicIncome;
                nodeOB.Icon = Icon.Folder;
                nodes.Add(nodeOB);
                nodeOB.Expanded = true;
            }
            else if (SingleNode(NodeID) == 12)
            {
                nodeOP.NodeID = "nodeOP";
                nodeOP.Text = ProjectIncome;
                nodeOP.Icon = Icon.Folder;
                nodes.Add(nodeOP);
                nodeOP.Expanded = true;
            }
            else if (SingleNode(NodeID) == 13)
            {
                nodeOB.NodeID = "nodeOB";
                nodeOB.Text = BasicIncome;
                nodeOB.Icon = Icon.Folder;
                nodes.Add(nodeOB);
                nodeOP.NodeID = "nodeOP";
                nodeOP.Text = ProjectIncome;
                nodeOP.Icon = Icon.Folder;
                nodes.Add(nodeOP);
                nodeOB.Expanded = true;
                nodeOP.Expanded = true;
            }
        }
        else if (NodeID == "nodeFB")
        {
            SetNode(tem, Financial_allocation, BasicIncome, nodes);
        }
        //else if (NodeID == "nodeFP")
        //{
        //    SetNode(tem, Financial_allocation, ProjectIncome, nodes);
        //}
        //else if (NodeID == "nodeOB")
        //{
        //    SetNode(tem, Other_funds, BasicIncome, nodes);
        //}
        //else if (NodeID == "nodeOP")
        //{
        //    SetNode(tem, Other_funds, ProjectIncome, nodes);
        //}
        if (nodeID >= 1000)
        {
            SetNode(nodeID, nodes);
        }
        Session["Slist"] = HidSlist.Text;
        return nodes.ToJson();
    }
    List<int> listpiid = new List<int>();

    private void gettotal()
    {
        decimal total = 0;
        string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Text;
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        
        for (int i = 0; i < dtpay.Rows.Count; i++)
        {
            DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(dtpay.Rows[i][0].ToString() );
            int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID

            total += ParToDecimal.ParToDel(dtpay.Rows[i][1].ToString()) + ParToDecimal.ParToDel(dtpay.Rows[i][2].ToString()) - BG_ApplyReimburLogic.GetARMon(dtpay.Rows[i][0].ToString(), DepID, common.IntSafeConvert(CurrentYear), common.IntSafeConvert(cmbmon.SelectedItem.Text));
        }
        total -= BG_MonPayPlanGenerateLogic.getAllMon(DepID, YearMonth);
        Incomebalance.Text = total.ToString() + "　万元";
    }

    private void SetNode(int tem, string ftype, string incomeinfo, NodeCollection node)
    { 
        string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Text;
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID);
        if (Session["Slist"] != null && Session["Slist"].ToString() != "")
        {
            HidSlist.Text = Session["Slist"].ToString();
        }
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(incomeinfo, ftype, tem);
        int year = common.IntSafeConvert(CurrentYear);
        decimal balance = 0;
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                string pname = dt.Rows[j]["PIEcoSubName"].ToString();
                Node nodeN = new Node();
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                string sql = string.Format("PIEcoSubName='{0}'", nodeN.Text);
                DataRow[] dr = dtpay.Select(sql);
                decimal Mon = 0;
                decimal MPFunding = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        Mon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString()) + ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
                    }
                }
               
                sql = string.Format("PIID={0}", piid);
                DataRow[] drapply = dtapply.Select(sql);
                if (drapply.Length > 0)
                {
                    for (int i = 0; i < drapply.Length; i++)
                    {
                        MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
                    }
                }
                if (!BG_PayIncomeLogic.GetBoolPayIncome(incomeinfo, ftype, piid))
                {
                    balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(pname, DepID, year, common.IntSafeConvert(cmbmon.SelectedItem.Text));
                    nodeN.Icon = Icon.Anchor;
                    node.Add(nodeN);
                    nodeN.Leaf = true;
                    nodeN.CustomAttributes.Add(new ConfigItem("Mon", (Mon*10000).ToString(), ParameterMode.Value));
                    nodeN.CustomAttributes.Add(new ConfigItem("Balance", (balance*10000).ToString(), ParameterMode.Value));
                    nodeN.CustomAttributes.Add(new ConfigItem("MPFunding", (MPFunding*10000).ToString(), ParameterMode.Value));
                    listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                    SaveListIdStrs(listpiid);
                    //Session["slist"] = listpiid;
                    //node.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
                    //node.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
                    //nodeN.Checked = false; 
                }
                else
                {
                    if (SingleNode(piid.ToString()) == 0)
                    {
                        break;
                    }
                    else if (BG_PayIncomeLogic.ISSign(piid))
                    {
                        balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(pname, DepID, year, common.IntSafeConvert(cmbmon.SelectedItem.Text));
                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", (Mon*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("Balance", (balance*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("MPFunding", (MPFunding*10000).ToString(), ParameterMode.Value));
                        listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        SaveListIdStrs(listpiid);

                        //Session["slist"] = listpiid;
                    }
                    else
                    {
                        nodeN.Icon = Icon.Folder;
                        node.Add(nodeN);
                        //listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        //SaveListIdStrs(listpiid);
                    }
                    //11
                    //nodeN.Expanded = true;
                    //nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
                    //nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
                    //CountBaamon = 0;
                    //CountSuppmon = 0;
                }
                //SetNode(piid, ftype, incomeinfo, nodeN);
                //node.Children.Add(nodeN); 
                //SetNode(piid, ftype, incomeinfo, nodeN);
            }

        }
    }

 

    private void SetNode(int tem, NodeCollection node)
    {
        string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Text;
        DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
        DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID);
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncomeByPIID(tem);
        int year = common.IntSafeConvert(CurrentYear);  decimal balance =0;
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                string pname = dt.Rows[j]["PIEcoSubName"].ToString();
                Node nodeN = new Node(); 
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                string sql = string.Format("PIEcoSubName='{0}'", nodeN.Text);
                DataRow[] dr = dtpay.Select(sql);
                decimal Mon = 0;
                decimal MPFunding = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        Mon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString()) + ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
                    }
                }

                sql = string.Format("PIID={0}", piid);
                DataRow[] drapply = dtapply.Select(sql);
                if (drapply.Length > 0)
                {
                    for (int i = 0; i < drapply.Length; i++)
                    {
                        MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
                    }
                }
              
                if (BG_PayIncomeLogic.GetBoolPayIncomeByPIID(tem))
                {

                    if (!BG_PayIncomeLogic.GetBoolPayIncomeByPIID(common.IntSafeConvert(piid)))
                    {
                        balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(pname, DepID, year, common.IntSafeConvert(cmbmon.SelectedItem.Text));
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.Leaf = true;
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", (Mon*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("Balance", (balance*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("MPFunding", (MPFunding*10000).ToString(), ParameterMode.Value));
                        listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        SaveListIdStrs(listpiid);
                    }
                    else
                    {
                        if (BG_PayIncomeLogic.GetLever(3))
                        {
                            balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(pname, DepID, year, common.IntSafeConvert(cmbmon.SelectedItem.Text));
                            nodeN.Icon = Icon.Anchor;
                            node.Add(nodeN);
                            nodeN.Leaf = true;
                            nodeN.CustomAttributes.Add(new ConfigItem("Mon", (Mon*10000).ToString(), ParameterMode.Value));
                            nodeN.CustomAttributes.Add(new ConfigItem("Balance", (balance*10000).ToString(), ParameterMode.Value));
                            nodeN.CustomAttributes.Add(new ConfigItem("MPFunding", (MPFunding*10000).ToString(), ParameterMode.Value));
                            listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                            SaveListIdStrs(listpiid);
                        }
                        else
                        {
                            nodeN.Icon = Icon.Folder;
                            node.Add(nodeN);
                            //listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                            //SaveListIdStrs(listpiid);
                        }
                    }

                    // Session["slist"] = listpiid;
                    //node.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
                    //node.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
                    //nodeN.Checked = false; 
                }
                else
                {
                    if (SingleNode(piid.ToString()) == 0)
                    {
                        break;
                    }
                    else if (BG_PayIncomeLogic.ISSign(piid))
                    {
                        balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(pname, DepID, year, common.IntSafeConvert(cmbmon.SelectedItem.Text));
                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("Mon", (Mon*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("Balance", (balance*10000).ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("MPFunding", (MPFunding*10000).ToString(), ParameterMode.Value));
                        listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        SaveListIdStrs(listpiid);

                        //Session["slist"] = listpiid;
                    }
                    else
                    {
                        nodeN.Icon = Icon.Folder;
                        node.Add(nodeN);
                        listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        SaveListIdStrs(listpiid);
                    }


                    //nodeN.Expanded = true;
                    //nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
                    //nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
                    //CountBaamon = 0;
                    //CountSuppmon = 0;
                }
                //SetNode(piid, ftype, incomeinfo, nodeN);
                //node.Children.Add(nodeN); 
                //SetNode(piid, ftype, incomeinfo, nodeN);
            }
        }

    }

    private void SaveListIdStrs(List<int> lstTmp)
    {
        for (int i = 0; i < lstTmp.Count; i++)
        {
            HidSlist.Text += lstTmp[i].ToString() + "&";
        }
    }

    protected void RemoteEdit(object sender, RemoteEditEventArgs e)
    {
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        if (hidflag.Text == "1")
        {
            X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，不允许修改").Show();
            return;
        }
        e.Accept = true;
        string[] idStrArr = HidSlist.Text.ToString().TrimEnd('&').Split('&');
        List<int> slist = new List<int>();
        foreach (string item in idStrArr)
        {
            int IntId = common.IntSafeConvert(item);
            if (!slist.Contains(IntId))
            {
                slist.Add(IntId);
            }
        }
        int piid = common.IntSafeConvert(e.NodeID);
        RowChanges rc = e.Changes[0];
        //if (rc.Value<float>() <= 0 && rc.OldValue<float>() <= 0)
        //{
        //    X.Msg.Alert("提示", "填写数字不能为0").Show();
        //    return;
        //}
        if (e.Json == null)
        {
            return;
        }

        if (!slist.Contains(piid))
        {
            rc.SetValue(rc.OldValue<float>());
            X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
            return;
        }
        else
        {
            decimal newValue = 0;
            decimal oldValue = 0;
            decimal balance = 0;
            decimal MPFunding = 0;
            decimal Mon = 0;
            DataTable dt = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, yearMonth);
            DataTable dtdevide = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
            string PIEcoSubName = "";
            PIEcoSubName = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
            string sql = string.Format("PIEcoSubName='{0}'", PIEcoSubName);
            DataRow[] drdevide = dtdevide.Select(sql);
            if (drdevide.Length > 0)
            {
                for (int i = 0; i < drdevide.Length; i++)
                {
                    Mon += ParToDecimal.ParToDel(drdevide[i]["BAAMon"].ToString()) + ParToDecimal.ParToDel(drdevide[i]["SuppMon"].ToString());
                }
            }

            sql = string.Format("PIID={0}", piid);
            DataRow[] dr = dt.Select(sql);

            if (dr.Length > 0)
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    MPFunding += ParToDecimal.ParToDel(dr[i]["MPFunding"].ToString());
                }
            }
            newValue = ParseUtil.ToDecimal(rc.Value<float>().ToString(), 0);
            oldValue = ParseUtil.ToDecimal(rc.OldValue<float>().ToString(), 0);
            balance = Mon - MPFunding;
            if (dt.Rows.Count > 0)
            {
                int CPID = common.IntSafeConvert(dt.Rows[0][0]);
                BG_MonPayPlan mp = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
                foreach (RowChanges change in e.Changes)
                {
                    if (change.Field == "MPFunding" && change.IsDirty<float>())
                    {
                        mp.MPFunding = newValue;
                        if (newValue > Mon * 10000)
                        {
                            X.Msg.Alert("申请月度用款计划", "科目：" + PIEcoSubName + "经费不足，请调整经费").Show();
                            rc.SetValue(rc.OldValue<float>());
                            return;
                        }
                        if (hidflag.Text == "2" || hidflag.Text == "3")
                        {
                            string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
                            if (oldValue > newValue)
                            {
                                X.Msg.Alert("提示", "修改提交或审核通过的经费必须大于现经费").Show();
                                rc.SetValue(rc.OldValue<float>());
                                return;
                            }
                            else
                            {
                                BG_MonPayPlan mppalert = new BG_MonPayPlan();
                                mppalert = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
                                mppalert.MPFunding = newValue/10000;
                                BG_MonPayPlanManager.ModifyBG_MonPayPlan(mppalert);
                                X.Msg.Notify(new NotificationConfig()
                                {
                                    Title = "申请月度用款计划",
                                    Html = string.Format(message, PIEcoSubName, oldValue, newValue),
                                    Width = 250
                                }).Show(); 
                                return;
                            }

                        }
                        else if (hidflag.Text == "1")
                        {
                            X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，不允许修改").Show();
                            rc.SetValue(rc.OldValue<float>());
                            return;
                        } 
                    }
                }
            }
            else
            {
                if (newValue > Mon * 10000)
                {
                    X.Msg.Alert("申请月度用款计划", "科目：" + PIEcoSubName + "经费不足，请调整经费").Show();
                    rc.SetValue(rc.OldValue<float>());
                    return;
                }
                string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
                BG_MonPayPlan mpp = new BG_MonPayPlan();

                mpp = new BG_MonPayPlan();
                mpp.DeptID = DepID;
                mpp.PIID = piid;
                mpp.MPFunding = newValue/10000;
                mpp.MPTime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
                BG_MonPayPlanManager.AddBG_MonPayPlan(mpp); 
                hidflag.Text = "2";
                X.Msg.Notify(new NotificationConfig()
                {
                    Title = "申请月度用款计划",
                    Html = string.Format(message, PIEcoSubName, oldValue, newValue),
                    Width = 250
                }).Show();
                
            }
        }
        gettotal();
    }
    protected void cmbmon_DirectChange(object sender, DirectEventArgs e)
    { 
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        if (BG_MonPayPlanRemarkLogic.IsRemark(DepID, yearMonth))
        {
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            NFeditor.Disable(true);
            if (BG_MonPayPlanGenerateLogic.IsAuditMonPay(yearMonth, DepID))
            {

                //X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改").Show();
                X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoYes()",
                        Text = "是"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoNo()",
                        Text = "否"
                    }
                }).Show();
                return;
            }
            else if (BG_MonPayPlanGenerateLogic.IsSubmitMonPay(yearMonth, DepID))
            {

                //X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，是否确定要修改").Show();
                X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经提交给局领导，是否确定要修改?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoYes()",
                        Text = "是"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "XX.DoNo()",
                        Text = "否"
                    }
                }).Show();
                return;
            }
            else if (BG_MonPayPlanGenerateLogic.ISMonlatePay(yearMonth, DepID))
            {

                //X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，是否确定要修改").Show();
                string msg = string.Format("月已经被财务室退回（{0}），请核实数据后修改?", BG_MonPayPlanGenerateLogic.MonlatePayCause(yearMonth, DepID));
                X.Msg.Confirm("申请月度用款计划", yearMonth + msg, new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "SS.DoYesSSS()",
                        Text = "确定"
                    }
                }).Show();
            }
        }
        else
        {
            NFeditor.Enable(true);
            btnsubmit.Hidden = false;
            Getmonth();
        }
       
    }
    [DirectMethod]
    public void GetPagedirect()
    {
        string month = "";
//        month = common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1 < 10
//            ? "0" + (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1)
//            : (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1).ToString();
        month = cmbmon.SelectedItem.Text;
        Response.Redirect("MonPayPlanNew.aspx?Month=" + month, true);
    }

    [DirectMethod(Namespace = "XX")]
    public void DoYes()
    {
        hidflag.Text = "3";
        NFeditor.Enable(true);
        Getmonth(); 
        btnsubmit.Show();
    }

    [DirectMethod(Namespace = "SS")]
    public void DoYesSSS()
    {
        hidflag.Text = "2";
        NFeditor.Enable(true); 
        btnsubmit.Show();
    }
    [DirectMethod(Namespace = "XX")]
    public void DoNo()
    {
        Getmonth(); 
    }
    protected void btnsubmit_DirectClick(object sender, DirectEventArgs e)
    {
        if (hidflag.Text != "2")
        {
            decimal sq = BG_MonPayPlanGenerateLogic.GetsqMon(CurrentYear + "-" + cmbmon.SelectedItem.Value,
                 DepID);
            if (sq<=0)
            {
                return; 
            } 
            
        }
        string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
        BG_MonPayPlanRemark mppr = new BG_MonPayPlanRemark();
        mppr.DeptID = DepID;
        mppr.MACause = "";
        mppr.MASta = "未提交";
        mppr.MATime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
        mppr.MAUser = UserName;
        if (BG_MonPayPlanGenerateLogic.IsnotSubmitMonPay(yearMonth, DepID))
        {
            BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
            X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Text + "月份用款计划已提交给财务科，请等待审核").Show();
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            Getmonth();
        }
        else
        {
            BG_MonPayPlanRemarkManager.AddBG_MonPayPlanRemark(mppr);
            X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Text + "月份用款计划已提交财务科，请等待审核").Show();
            btnsubmit.Hidden = true;
            hidflag.Text = "1";
            Getmonth();
        }
    }
}