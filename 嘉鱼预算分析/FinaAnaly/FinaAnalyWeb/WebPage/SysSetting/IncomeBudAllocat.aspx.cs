using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;
using Ext.Net;

public partial class WebPage_SysSetting_IncomeBudAllocat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblYear.Text = Getyear().ToString();
            txtBind();
            //int piid = common.IntSafeConvert(ddlIncome.SelectedValue);
            //GetDepMon(piid,year); 
        }
    }

    private int Getyear()
    {
        int year = 0;
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            year = common.IntSafeConvert(ss.SSYear.ToString());
        }
        Session["year"] = year;
        return year;

    }

    private void txtBind()
    {
        //显示总金额
        int year = (int)Session["year"];
        FA_BudConNum bcn = FA_BudConNumManager.GetBudConNumByYear(year);
        if (bcn != null)
        {
            //lblTotalMon.Text = (bcn.BCNBasExpBudMon + bcn.BCNProExpBudMon).ToString();
            lblTotalMonBasic.Text = bcn.BCNBasExpBudMon.ToString();
            lblTotalMonProject.Text = bcn.BCNProExpBudMon.ToString();
            //lblAddMon.Text = (bcn.BCNBasAddBudMon + bcn.BCNProAddBudMon).ToString();
            lblAddMonBasic.Text = bcn.BCNBasAddBudMon.ToString();
            lblAddMonProject.Text = bcn.BCNProAddBudMon.ToString();
        }

        //显示余额
        decimal iba = 0;
        decimal lblTotalMon = ToDec(lblTotalMonBasic.Text) + ToDec(lblTotalMonProject.Text);
        decimal lblAddMon = ToDec(lblAddMonBasic.Text) + ToDec(lblAddMonProject.Text);
        iba = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocat();
        //绑定经济科目
        ////if (rbtnBasePay.Checked)
        ////{
        ////    DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByXPItype(rbtnBasePay.Text.Trim());
        ////    DDLBind(dt);Text='<%# Eval("IBAMon") %>'
        ////}
        // }
        lblBalance.Text = (lblTotalMon + lblAddMon - iba).ToString();
        HidIBA.Value = lblBalance.Text;
        //RangeValidator2.MaximumValue = (ParseUtil.ToDecimal(lblBalance.Text, 0) + ParseUtil.ToDecimal(txtMon.Text, 0)).ToString();
    }

    //protected void GetNodes(object sender, NodeLoadEventArgs e)
    //{
    //    int tem = 1;
    //    string Financial_allocation = "财政拨款";
    //    string Other_funds = "其他资金";
    //    string BasicIncome = "基本支出";
    //    string ProjectIncome = "项目支出";
    //    Node rootNode = new Node();
    //    rootNode.Text = "经济科目";
    //    rootNode.Icon = Icon.Folder;
    //    e.Nodes.Add(rootNode);
    //    NodeCollection nodes = new NodeCollection();
    //    Node nodeF = new Node();
    //    nodeF.NodeID = "nodeF";
    //    nodeF.Text = Financial_allocation;
    //    nodeF.Icon = Icon.Folder;
    //    rootNode.Children.Add(nodeF);

    //    Node nodeO = new Node();
    //    nodeO.NodeID = "nodeO";
    //    nodeO.Text = Other_funds;
    //    nodeO.Icon = Icon.Folder;
    //    rootNode.Children.Add(nodeO);

    //    Node nodeFB = new Node();
    //    nodeFB.NodeID = "nodeFB";
    //    nodeFB.Text = BasicIncome;
    //    nodeFB.Icon = Icon.Folder;
    //    nodeF.Children.Add(nodeFB);

    //    Node nodeFP = new Node();
    //    nodeFP.NodeID = "nodeFP";
    //    nodeFP.Text = ProjectIncome;
    //    nodeFP.Icon = Icon.Folder;
    //    nodeF.Children.Add(nodeFP);

    //    Node nodeOB = new Node();
    //    nodeOB.NodeID = "nodeOB";
    //    nodeOB.Text = BasicIncome;
    //    nodeOB.Icon = Icon.Folder;
    //    nodeO.Children.Add(nodeOB);

    //    Node nodeOP = new Node();
    //    nodeOP.NodeID = "nodeOP";
    //    nodeOP.Text = ProjectIncome;
    //    nodeOP.Icon = Icon.Folder;
    //    nodeO.Children.Add(nodeOP);
    //    //Session["nodeFB"] = nodeFB;
    //    //Session["nodeFP"] = nodeFP;
    //    //Session["nodeOB"] = nodeOB;
    //    //Session["nodeOP"] = nodeOP;
    //    SetNode(tem, Financial_allocation, BasicIncome, nodeFB);
    //    SetNode(tem, Financial_allocation, ProjectIncome, nodeFP);
    //    SetNode(tem, Other_funds, BasicIncome, nodeOB);
    //    SetNode(tem, Other_funds, ProjectIncome, nodeOP);
    //    TPPayIncome.ExpandAll();
    //}
    //[DirectMethod]
    //public void setAllNode(string str)
    //{
    //    Node nodeFB = (Node)Session["nodeFB"];
    //    Node nodeFP = (Node)Session["nodeFP"];
    //    Node nodeOB = (Node)Session["nodeOB"];
    //    Node nodeOP = (Node)Session["nodeOP"];
    //    if (str == "财政拨款")
    //    {
    //        SetNode(1, "财政拨款", "基本支出", nodeFB);
    //        SetNode(1, "财政拨款", "项目支出", nodeFP);
    //    }
    //    else if (str == "其他资金")
    //    {
    //        SetNode(1, "其他资金", "基本支出", nodeFB);
    //        SetNode(1, "其他资金", "项目支出", nodeFP);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    List<int> listpiid = new List<int>();
    List<int> listrootpiid = new List<int>();
    private void SetNode(int tem, string ftype, string incomeinfo, NodeCollection node)
    {
        NodeCollection nodes = new NodeCollection();
        DataTable dt = FA_PayIncomeManager.GetGroupFA_PayIncome(incomeinfo, ftype, tem);
        int year = Getyear();
        DataTable dti = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByYear(year);
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                Node nodeN = new Node();
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                string sql = string.Format("PIID='{0}'", piid);
                DataRow[] dr = dti.Select(sql);
                decimal IBAMon = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        IBAMon += ToDec(dr[i]["IBAMon"].ToString());
                    }
                }
                if (!FA_PayIncomeManager.GetBoolPayIncome(incomeinfo, ftype, piid))
                {
                    //nodeN.Icon = Icon.Anchor;
                    nodeN.IconCls = "ss";
                    node.Add(nodeN);
                    nodeN.Leaf = true;
                    nodeN.CustomAttributes.Add(new ConfigItem("IBAMon", IBAMon.ToString(), ParameterMode.Value));
                    listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                    Session["slist"] = listpiid;
                }
                else
                {
                    //nodeN.Icon = Icon.Folder;
                    nodeN.IconCls = "ss";
                    node.Add(nodeN);
                    //DataTable dtpiid = FA_XIncomeBudAllocatManager.GetGroupPIID(piid, year);
                    decimal CountIBAMon = 0;
                    //if (dtpiid != null)
                    //{
                    //    if (dtpiid.Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < dtpiid.Rows.Count; i++)
                    //        {
                    //            int tempiid = common.IntSafeConvert(dtpiid.Rows[i]["PIID"]);
                    //            if (FA_PayIncomeManager.GetBoolPayIncome(tempiid))
                    //            {
                    //                CountIBAMon += FA_XIncomeBudAllocatManager.GetSumIBAMon(tempiid, year);
                    //            }
                    //            else
                    //            {
                    //                CountIBAMon += FA_XIncomeBudAllocatManager.GetIBAMonByPIID(tempiid, year);
                    //            }
                    //        }
                    //    }
                    //}
                    //nodeN.CustomAttributes.Add(new ConfigItem("IBAMon", CountIBAMon.ToString(), ParameterMode.Value));
                    listrootpiid.Add(piid);
                    Session["listrootpiid"] = listrootpiid;
                    DataTable dtnode = new DataTable();
                    dtnode.Columns.Add("Nodeid", typeof(int));
                    dtnode.Columns.Add("CountIBAMon", typeof(decimal));
                    DataRow drnode = dtnode.NewRow();
                    drnode["Nodeid"] = piid;
                    drnode["CountIBAMon"] = CountIBAMon;
                    dtnode.Rows.Add(drnode);
                    Session["dtnode"] = dtnode;

                    ////
                    //FA_XIncomeBudAllocat bgadd1 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(piid, year);

                    //if (bgadd1 != null)
                    //{
                    //    bgadd1.IBAMon = CountIBAMon;
                    //    FA_XIncomeBudAllocatManager.ModifyFA_XIncomeBudAllocat(bgadd1);
                    //}
                }
                //SetNode(piid, ftype, incomeinfo, nodeN);
                //NodeLoad(nodeN.NodeID);
            }
        }
    }

    private void SetNode(int tem, NodeCollection node)
    {
        NodeCollection nodes = new NodeCollection();
        DataTable dt = FA_PayIncomeManager.GetGroupFA_PayIncome(tem);
        int year = Getyear();
        DataTable dti = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByYear(year);
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
                Node nodeN = new Node();
                nodeN.NodeID = piid.ToString();
                nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
                string sql = string.Format("PIID='{0}'", piid);
                DataRow[] dr = dti.Select(sql);
                decimal IBAMon = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        IBAMon += ToDec(dr[i]["IBAMon"].ToString());
                    }
                }
                if (!FA_PayIncomeManager.GetBoolPayIncome(piid))
                {
                    //nodeN.Icon = Icon.Anchor;
                    nodeN.IconCls = "ss";
                    node.Add(nodeN);
                    nodeN.Leaf = true;
                    nodeN.CustomAttributes.Add(new ConfigItem("IBAMon", IBAMon.ToString(), ParameterMode.Value));
                    listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                    Session["slist"] = listpiid;
                }
                else
                {
                    //nodeN.Icon = Icon.Folder;
                    nodeN.IconCls = "ss";
                    node.Add(nodeN);
                    decimal CountIBAMon = 0;
                    //DataTable dtpiid = FA_XIncomeBudAllocatManager.GetGroupPIID(piid, year);
                    //if (dtpiid != null)
                    //{
                    //    if (dtpiid.Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < dtpiid.Rows.Count; i++)
                    //        {
                    //            int tempiid = common.IntSafeConvert(dtpiid.Rows[i]["PIID"]);
                    //            if (FA_PayIncomeManager.GetBoolPayIncome(tempiid))
                    //            {
                    //                CountIBAMon += FA_XIncomeBudAllocatManager.GetSumIBAMon(tempiid, year);
                    //            }
                    //            else
                    //            {
                    //                CountIBAMon += FA_XIncomeBudAllocatManager.GetIBAMonByPIID(tempiid, year);
                    //            }
                    //        }
                    //    }
                    //}
                    listrootpiid.Add(piid);
                    Session["listrootpiid"] = listrootpiid;
                    DataTable dtnode = (DataTable)Session["dtnode"];
                    DataRow drnode = dtnode.NewRow();
                    drnode["Nodeid"] = piid;
                    drnode["CountIBAMon"] = CountIBAMon;
                    dtnode.Rows.Add(drnode);
                    //nodeN.CustomAttributes.Add(new ConfigItem("IBAMon", CountIBAMon.ToString(), ParameterMode.Value));
                    Session["dtnode"] = dtnode;
                    ////
                    //FA_XIncomeBudAllocat bgadd1 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(piid, year);

                    //if (bgadd1 != null)
                    //{
                    //    bgadd1.IBAMon =CountIBAMon;
                    //    FA_XIncomeBudAllocatManager.ModifyFA_XIncomeBudAllocat(bgadd1);
                    //}
                }
                //SetNode(piid, ftype, incomeinfo, nodeN);
                //NodeLoad(nodeN.NodeID);
            }
        }
    }

    [DirectMethod]
    public string NodeLoad(string nodeID)
    {
        int tem = 1;
        NodeCollection nodes = new Ext.Net.NodeCollection();
        string Financial_allocation = "财政拨款";
        string Other_funds = "其他资金";
        string BasicIncome = "基本支出";
        string ProjectIncome = "项目支出";
        if (!string.IsNullOrEmpty(nodeID))
        {
            Node nodeF = new Node();
            Node nodeO = new Node();
            Node nodeOB = new Node();
            Node nodeOP = new Node();
            Node nodeFP = new Node();
            Node nodeFB = new Node();
            if (nodeID == "root")
            {
                nodeF.NodeID = "nodeF";
                nodeF.Text = Financial_allocation;
                //nodeF.Icon = Icon.Folder;
                nodeF.IconCls = "ss";
                nodes.Add(nodeF);


                nodeO.NodeID = "nodeO";
                nodeO.Text = Other_funds;
                //nodeO.Icon = Icon.Folder;
                nodeO.IconCls = "ss";
                nodes.Add(nodeO);
            }

            if (nodeID == "nodeF")
            {
                nodeFB.NodeID = "nodeFB";
                nodeFB.Text = BasicIncome;
                //nodeFB.Icon = Icon.Folder;
                nodeFB.IconCls = "ss";
                nodes.Add(nodeFB);
                nodeFP.NodeID = "nodeFP";
                nodeFP.Text = ProjectIncome;
                //nodeFP.Icon = Icon.Folder;
                nodeFP.IconCls = "ss";
                nodes.Add(nodeFP);
            }

            if (nodeID == "nodeO")
            {
                nodeOB.NodeID = "nodeOB";
                nodeOB.Text = BasicIncome;
                //nodeOB.Icon = Icon.Folder;
                nodeOB.IconCls = "ss";
                nodes.Add(nodeOB);

                nodeOP.NodeID = "nodeOP";
                nodeOP.Text = ProjectIncome;
                //nodeOP.Icon = Icon.Folder;
                nodeOP.IconCls = "ss";
                nodes.Add(nodeOP);
            }

            if (nodeID == "nodeFB")
            {
                SetNode(tem, Financial_allocation, BasicIncome, nodes);
            }
            else if (nodeID == "nodeFP")
            {
                SetNode(tem, Financial_allocation, ProjectIncome, nodes);
            }

            else if (nodeID == "nodeOB")
            {
                SetNode(tem, Other_funds, BasicIncome, nodes);
            }
            else if (nodeID == "nodeOP")
            {
                SetNode(tem, Other_funds, ProjectIncome, nodes);
            }
            else if (common.IntSafeConvert(nodeID) >= 1000)
            {
                SetNode(common.IntSafeConvert(nodeID), nodes);
            }
        }

        return nodes.ToJson();
    }

    protected void RemoteEdit(object sender, RemoteEditEventArgs e)
    {
        e.Accept = true;
        List<int> slist = (List<int>)Session["slist"];
        int piid = common.IntSafeConvert(e.NodeID);
        RowChanges rc = e.Changes[0];
        if (slist == null)
        {
            X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
            e.SetValue("");
        }
        else
        {
            if (!slist.Contains(piid))
            {
                if (piid == 0)
                {
                    X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
                    e.SetValue("");
                    return;
                }
                else
                {
                    X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
                    e.SetValue(e.OldValue<float>());
                    return;
                }
            }
            else
            {
                int year = (int)Session["year"];
                decimal IBAMon = 0;
                FA_XIncomeBudAllocat bg = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(piid, year);
                if (bg == null)
                {
                    decimal addmon = 0;
                    FA_XIncomeBudAllocat bgadd = new FA_XIncomeBudAllocat();
                    foreach (RowChanges change in e.Changes)
                    {
                        if (change.Field == "IBAMon" && change.IsDirty<float>())
                        {
                            bgadd.IBAMon = ToDec(change.Value<float>().ToString());
                            addmon = bgadd.IBAMon;
                            IBAMon = ToDec(HidIBA.Value.ToString()) - addmon;
                            HidIBA.Value = IBAMon;
                        }
                    }
                    bgadd.PIID = piid;
                    bgadd.IBAYear = year;
                    if (ToDec(HidIBA.Value.ToString()) < 0)
                    {
                        X.Msg.Alert("提示", "超过总余额，请核实后修改数据！");
                    }
                    else
                    {
                        FA_XIncomeBudAllocatManager.AddFA_XIncomeBudAllocat(bgadd);
                        int pisubid = FA_XPayIncomeManager.GetPIEcoSubParID(piid);
                        List<int> listrootpiid = (List<int>)Session["listrootpiid"];
                        if (listrootpiid.Contains(pisubid))
                        {
                            DataTable dtnode = (DataTable)Session["dtnode"];
                            if (dtnode.Rows.Count > 0)
                            {
                                string sqlselect = string.Format("Nodeid={0}", pisubid);
                                DataRow[] dr = dtnode.Select(sqlselect);
                                FA_XIncomeBudAllocat bgadd1 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(pisubid, year);
                                if (bgadd1 == null)
                                {
                                    bgadd1.PIID = pisubid;
                                    bgadd1.IBAYear = year;
                                    bgadd1.IBAMon = ToDec(dr[0]["CountIBAMon"]) + addmon;
                                    FA_XIncomeBudAllocatManager.AddFA_XIncomeBudAllocat(bgadd1);
                                }
                                else
                                {
                                    bgadd1.IBAMon = ToDec(dr[0]["CountIBAMon"]);
                                    FA_XIncomeBudAllocatManager.ModifyFA_XIncomeBudAllocat(bgadd1);
                                }

                            }
                        }
                        lblBalance.Text = IBAMon.ToString();
                    }
                }
                else
                {
                    decimal cha = 0;
                    foreach (RowChanges change in e.Changes)
                    {
                        if (change.Field == "IBAMon" && change.IsDirty<float>())
                        {
                            bg.IBAMon = ToDec(change.Value<float>().ToString());
                            cha = ToDec(change.OldValue<float>().ToString()) - bg.IBAMon;
                            IBAMon = ToDec(HidIBA.Value.ToString()) + cha;
                            HidIBA.Value = IBAMon;
                        }

                    }
                    if (ToDec(HidIBA.Value.ToString()) < 0)
                    {
                        X.Msg.Alert("提示", "超过总余额，请核实后修改数据！");
                    }
                    else
                    {
                        FA_XIncomeBudAllocatManager.ModifyFA_XIncomeBudAllocat(bg);
                        int pisubid = FA_XPayIncomeManager.GetPIEcoSubParID(piid);
                        List<int> listrootpiid = (List<int>)Session["listrootpiid"];
                        if (listrootpiid.Contains(pisubid))
                        {
                            DataTable dtnode = (DataTable)Session["dtnode"];
                            if (dtnode.Rows.Count > 0)
                            {
                                string sqlselect = string.Format("Nodeid={0}", pisubid);
                                DataRow[] dr = dtnode.Select(sqlselect);
                                FA_XIncomeBudAllocat bgadd1 = FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatBypiidyear(pisubid, year);
                                if (bgadd1 == null)
                                {
                                    bgadd1.PIID = pisubid;
                                    bgadd1.IBAYear = year;
                                    bgadd1.IBAMon = ToDec(dr[0]["CountIBAMon"]) + cha;
                                    FA_XIncomeBudAllocatManager.AddFA_XIncomeBudAllocat(bgadd1);
                                }
                                else
                                {
                                    bgadd1.IBAMon = ToDec(dr[0]["CountIBAMon"]) + cha;
                                    FA_XIncomeBudAllocatManager.ModifyFA_XIncomeBudAllocat(bgadd1);
                                }

                            }
                        }
                        lblBalance.Text = IBAMon.ToString();
                    }
                }
            }
        }
    }

    private Decimal ToDec(object obj)
    {
        Decimal decTmp = 0;
        if (obj != null)
        {
            string objStr = obj.ToString();
            if (!string.IsNullOrEmpty(objStr))
            {
                decTmp = ParseUtil.ToDecimal(objStr, decTmp);
            }
        }
        return decTmp;
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        // lblShowResult.Text = string.Empty;
        txtBind();
    }

}