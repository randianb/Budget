using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using Common;
using System.Xml;
using Ext.Net.Utilities;

public partial class WebPage_BudgetControl_PayIncomeAllocation : BudgetBasePage
{
    int depid = 0;
    public string listallocationstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listallocationstr =Listallocationstr;
        }
        catch (Exception)
        {
            Listallocationstr = "";
        }
        depid = common.IntSafeConvert(Request.QueryString["Depid"]);
        HidDepid.Value = depid.ToString();
        BAA.Style.Add("color", "red");
        SUPP.Style.Add("color", "red");
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            DtDataBind();
        }
    }

    //public string GetXML()
    //{
    //    string str = "";
    //    string xmlPath = Server.MapPath("~/Settings/") + "Settings.xml";
    //    List<string> list = new List<string>();
    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.Load(xmlPath);
    //    XmlNode xmlNode = xmlDoc.SelectSingleNode("UserInfo");
    //    foreach (XmlNode node in xmlNode)
    //    {

    //        //验证是否登录通过
    //        if (UserName.ToLower() == node.ChildNodes[1].InnerText.ToLower() && UserID.ToString().ToLower() == node.ChildNodes[0].InnerText.ToLower())
    //        {
    //            str = node.ChildNodes[2].InnerText.ToLower();
    //        }
    //    }
    //    return str;
    //} 
    private void DtDataBind()
    {
        decimal txt = 0;

        int year = common.IntSafeConvert(CurrentYear);
        DataTable dt1 = BG_BudItemsLogic.GetPayOne(year);
        if (dt1.Rows.Count > 0)
        {
            txt += ParToDecimal.ParToDel(dt1.Rows[0]["POTitol"].ToString());
        }
        DataTable dt2 = BG_BudItemsLogic.GetPayTwo(year);
        if (dt1.Rows.Count > 0)
        {
            if (dt2.Rows.Count > 0) { txt += ParToDecimal.ParToDel(dt2.Rows[0]["PTTitol"].ToString()); }
        }
        DataTable dt3 = BG_BudItemsLogic.GetPubPay(year);
        if (dt1.Rows.Count > 0)
        {
            if (dt3.Rows.Count > 0) { txt += ParToDecimal.ParToDel(dt3.Rows[0]["PBIDTitol"].ToString()); }

        }
        DataTable dt4 = BG_BudItemsLogic.GetProPay(year);
        if (dt4.Rows.Count > 0)
        {
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                txt += Convert.ToDecimal(dt4.Rows[i]["ProPA0M"]);
            }
        }
        DataTable dt5 = BG_BudItemsLogic.GetBudgetAllocation(year);
        if (dt5.Rows.Count > 0)
        {
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                txt -= ParToDecimal.ParToDel(dt5.Rows[i]["BAAMon"].ToString());
            }
        }
        //tatal.Value = txt.ToString();
        //BAA.Text = txt.ToString();
        DataTable dtpre = BG_PreLogic.GetBG_PreByyear(common.IntSafeConvert(CurrentYear));
        decimal premon = 0;
        if (dtpre == null || dtpre.Rows.Count == 0)
        {
            premon = 0;
        }
        else { premon = ParToDecimal.ParToDel(dtpre.Rows[0]["PreMon"].ToString()); }
        BAA.Text = (txt + premon).ToString();
        DataTable dt = BG_DepartmentLogic.GetAllBG_DepartmentMon(year, DepID);
        DataTable dt6 = BG_SupplementaryLogic.GetBG_SupplementaryByyear(year);
        decimal sutxt = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sutxt += ParToDecimal.ParToDel(dt.Rows[i]["SuppMon"].ToString());
            }
        }
        if (dt6.Rows.Count <= 0)
        {
            SUPP.Text = "0.00";
        }
        else
        {
            SUPP.Text = (ParToDecimal.ParToDel(dt6.Rows[0]["SuppMon"].ToString()) - sutxt).ToString();
        }
        HidBAA.Text = BAA.Text;
        HidSupp.Text = SUPP.Text;
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
//    [DirectMethod]
//    public string NodeLoad(string NodeID)
//    {
//        if (!ISNode(NodeID))
//        {
//            return "failure";
//        }
//        NodeCollection nodes = new NodeCollection();
//        int tem = 1;
//        int nodeID = common.IntSafeConvert(NodeID);
//        string Financial_allocation = "财政拨款";
//        string Other_funds = "其他资金";
//        string BasicIncome = "基本支出";
//        string ProjectIncome = "项目支出";
//        Node rootNode = new Node();
//        Node nodeO = new Node();
//        Node nodeF = new Node();
//        Node nodeFB = new Node();
//        Node nodeFP = new Node();
//        Node nodeOB = new Node();
//        Node nodeOP = new Node();
//        if (NodeID == "root")
//        {
//            rootNode.Text = "经济科目";
//            rootNode.NodeID = "PA";
//            rootNode.Icon = Icon.Folder;
//            nodes.Add(rootNode);
//            rootNode.Expanded = true;
//        }
//        else if (NodeID == "PA")
//        {
//            if (SingleNode(NodeID) == 2)
//            {
//                nodeF.NodeID = "nodeF";
//                nodeF.Text = Financial_allocation;
//                nodeF.Icon = Icon.Folder;
//                nodes.Add(nodeF);
//                nodeF.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 1)
//            {
//                nodeO.NodeID = "nodeO";
//                nodeO.Text = Other_funds;
//                nodeO.Icon = Icon.Folder;
//                nodes.Add(nodeO);
//                nodeO.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 3)
//            {
//                nodeF.NodeID = "nodeF";
//                nodeF.Text = Financial_allocation;
//                nodeF.Icon = Icon.Folder;
//                nodes.Add(nodeF);
//                nodeO.NodeID = "nodeO";
//                nodeO.Text = Other_funds;
//                nodeO.Icon = Icon.Folder;
//                nodes.Add(nodeO);
//                nodeO.Expanded = true;
//                nodeF.Expanded = true;
//            }
//        }
//        else if (NodeID == "nodeF")
//        {
//            if (SingleNode(NodeID) == 21)
//            {
//                nodeFB.NodeID = "nodeFB";
//                nodeFB.Text = BasicIncome;
//                nodeFB.Icon = Icon.Folder;
//                nodes.Add(nodeFB);
//                nodeFB.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 22)
//            {
//                nodeFP.NodeID = "nodeFP";
//                nodeFP.Text = ProjectIncome;
//                nodeFP.Icon = Icon.Folder;
//                nodes.Add(nodeFP);
//                nodeFP.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 23)
//            {
//                nodeFB.NodeID = "nodeFB";
//                nodeFB.Text = BasicIncome;
//                nodeFB.Icon = Icon.Folder;
//                nodes.Add(nodeFB);
//
//                nodeFP.NodeID = "nodeFP";
//                nodeFP.Text = ProjectIncome;
//                nodeFP.Icon = Icon.Folder;
//                nodes.Add(nodeFP);
//                nodeFB.Expanded = true;
//                nodeFP.Expanded = true;
//            }
//        }
//        else if (NodeID == "nodeO")
//        {
//            if (SingleNode(NodeID) == 11)
//            {
//                nodeOB.NodeID = "nodeOB";
//                nodeOB.Text = BasicIncome;
//                nodeOB.Icon = Icon.Folder;
//                nodes.Add(nodeOB);
//                nodeOB.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 12)
//            {
//                nodeOP.NodeID = "nodeOP";
//                nodeOP.Text = ProjectIncome;
//                nodeOP.Icon = Icon.Folder;
//                nodes.Add(nodeOP);
//                nodeOP.Expanded = true;
//            }
//            else if (SingleNode(NodeID) == 13)
//            {
//                nodeOB.NodeID = "nodeOB";
//                nodeOB.Text = BasicIncome;
//                nodeOB.Icon = Icon.Folder;
//                nodes.Add(nodeOB);
//                nodeOP.NodeID = "nodeOP";
//                nodeOP.Text = ProjectIncome;
//                nodeOP.Icon = Icon.Folder;
//                nodes.Add(nodeOP);
//                nodeOB.Expanded = true;
//                nodeOP.Expanded = true;
//            }
//        }
//        else if (NodeID == "nodeFB")
//        {
//            SetNode(tem, Financial_allocation, BasicIncome, nodes);
//        }
//        else if (NodeID == "nodeFP")
//        {
//            SetNode(tem, Financial_allocation, ProjectIncome, nodes);
//        }
//        else if (NodeID == "nodeOB")
//        {
//            SetNode(tem, Other_funds, BasicIncome, nodes);
//        }
//        else if (NodeID == "nodeOP")
//        {
//            SetNode(tem, Other_funds, ProjectIncome, nodes);
//        }
//        if (nodeID >= 1000)
//        {
//            SetNode(nodeID, nodes);
//        }
//        Session["Slist"] = HidSlist.Text;
//        return nodes.ToJson();
//    }
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
    private void SetNode(int tem, string ftype, string incomeinfo, NodeCollection node)
    {
        if (Session["Slist"] != null && Session["Slist"].ToString() != "")
        {
            HidSlist.Text = Session["Slist"].ToString();
        }
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(incomeinfo, ftype, tem);
        int year = common.IntSafeConvert(CurrentYear);
        int depid = common.IntSafeConvert(HidDepid.Value);
        DataTable dti = BG_BudItemsLogic.GetBAA(depid, year);
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
                decimal Baamon = 0;
                decimal Suppmon = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        Baamon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString());
                        Suppmon += ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
                    }
                }
                if (!BG_PayIncomeLogic.GetBoolPayIncome(incomeinfo, ftype, piid))
                {
                    nodeN.Icon = Icon.Anchor;
                    node.Add(nodeN);
                    nodeN.Leaf = true;
                    nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", Baamon.ToString(), ParameterMode.Value));
                    nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", Suppmon.ToString(), ParameterMode.Value));
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

                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", Baamon.ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", Suppmon.ToString(), ParameterMode.Value));
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
        NodeCollection nodes = new NodeCollection();
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncomeByPIID(tem);
        int year = common.IntSafeConvert(CurrentYear);
        int depid = common.IntSafeConvert(HidDepid.Value);
        DataTable dti = BG_BudItemsLogic.GetBAA(depid, year);
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
                decimal Baamon = 0;
                decimal Suppmon = 0;
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        Baamon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString());
                        Suppmon += ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
                    }
                }
                if (BG_PayIncomeLogic.GetBoolPayIncomeByPIID(tem))
                {

                    if (!BG_PayIncomeLogic.GetBoolPayIncomeByPIID(common.IntSafeConvert(piid)))
                    {
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.Leaf = true;
                        nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", Baamon.ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", Suppmon.ToString(), ParameterMode.Value));
                        listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                        SaveListIdStrs(listpiid);
                    }
                    else
                    {
                        if (BG_PayIncomeLogic.GetLever(3))
                        {
                            nodeN.Icon = Icon.Anchor;
                            node.Add(nodeN);
                            nodeN.Leaf = true;
                            nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", Baamon.ToString(), ParameterMode.Value));
                            nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", Suppmon.ToString(), ParameterMode.Value));
                            listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                            SaveListIdStrs(listpiid);
                        }
                        else
                        {
                            nodeN.Icon = Icon.Folder;
                            node.Add(nodeN);
                            listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
                            SaveListIdStrs(listpiid);
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

                        nodeN.Leaf = true;
                        nodeN.Icon = Icon.Anchor;
                        node.Add(nodeN);
                        nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", Baamon.ToString(), ParameterMode.Value));
                        nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", Suppmon.ToString(), ParameterMode.Value));
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
        foreach (int idTmp in lstTmp)
        {
            HidSlist.Text += idTmp.ToString() + "&";
        }
    }

    //protected void GetSelect_DirectClick(object sender, DirectEventArgs e)
    //{
    //    string Strincome = Hidselector.Value.ToString();
    //    string[] income = Strincome.Split(',');
    //    DataTable dt = null;
    //    dt.Columns.Add();
    //    for (int i = 0; i < income.Count(); i++)
    //    {

    //    }
    //}

    protected void RemoteEdit(object sender, RemoteEditEventArgs e)
    {
        if (ParToDecimal.ParToDel(HidSupp.Text.ToString()) < 0 || ParToDecimal.ParToDel(HidBAA.Text.ToString()) < 0)
        {
            if (ParToDecimal.ParToDel(HidSupp.Text) < 0)
            {
                X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
            }
            else
            {
                X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
            }
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
            X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
            return;
        }
        else
        {
            int year = common.IntSafeConvert(CurrentYear);
            decimal baamon = 0;
            decimal suppmon = 0;
            BG_BudgetAllocation bg = BG_BudgetAllocationLogic.GetMonDT(year, piid, depid);
            if (bg == null)
            {
                BG_BudgetAllocation bgadd = new BG_BudgetAllocation();
                foreach (RowChanges change in e.Changes)
                {
                    if (change.Field == "BAAMon" && change.IsDirty<float>())
                    {
                        bgadd.BAAMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                        baamon = ParToDecimal.ParToDel(HidBAA.Text.ToString()) - bgadd.BAAMon;
                        if (baamon < 0)
                        {
                            X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                            rc.SetValue(rc.OldValue<float>());
                            return;
                        } 

                    }
                    else if (change.Field == "SuppMon" && change.IsDirty<float>())
                    {
                        bgadd.SuppMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                        suppmon = ParToDecimal.ParToDel(SUPP.Text) - bgadd.SuppMon;
                        if (suppmon < 0 || baamon < 0)
                        {
                            if (suppmon < 0)
                            {
                                X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
                                rc.SetValue(rc.OldValue<float>());
                                return;
                            }
                            else
                            {
                                X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                                rc.SetValue(rc.OldValue<float>());
                                return;
                            }
                        }
                    }
                }
                decimal QuotaMon = BG_QuotaLogic.GetQuotaMoney(piid, year);
                if (QuotaMon>0&&QuotaMon-(bgadd.BAAMon+bgadd.SuppMon)<0)
                {
                    X.Msg.Alert("提示", "该科目设置总金额超过年度设置的定额标准，请核实后修改数据！").Show();
                    rc.SetValue(rc.OldValue<float>());
                    return;
                }
                bgadd.PIID = piid;
                bgadd.BAAYear = year;
                bgadd.DepID = depid;
                BG_BudgetAllocationManager.AddBG_BudgetAllocation(bgadd);
                DtDataBind();

                //if (baamon < 0 || suppmon < 0)
                //{
                //    if (baamon > 0)
                //    {
                //        X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }
                //    else if (suppmon > 0)
                //    {
                //        X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }
                //    else
                //    {
                //        X.Msg.Alert("提示", "追加余额或总余额不足，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }

                //}
                //else
                //{
                //    BG_BudgetAllocationManager.AddBG_BudgetAllocation(bgadd);
                //    DtDataBind();
                //}
            }
            else
            {
                
                decimal Mon = BG_MonPayPlanGenerateLogic.GetMonPayYear(piid, depid, year);
                decimal UseMon = BG_ApplyReimburLogic.GetARUseMon(piid, depid, year);
                if (ParToDecimal.ParToDel(rc.OldValue<float>().ToString()) - ParToDecimal.ParToDel(rc.Value<float>().ToString())-(Mon - UseMon) < 0)
                {
                    if (Mon>0)
                    {
                        X.Msg.Alert("提示", "分配金额小于期初分配金额，会影响月度用款申请及预算执行！").Show(); 
                    } 
                    foreach (RowChanges change in e.Changes)
                    {
                        if (change.Field == "BAAMon" && change.IsDirty<float>())
                        {
                            bg.BAAMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                            baamon = ParToDecimal.ParToDel(HidBAA.Text.ToString()) + ParToDecimal.ParToDel(change.OldValue<float>().ToString()) - bg.BAAMon;
                            if (baamon < 0)
                            {
                                X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                                rc.SetValue(rc.OldValue<float>());
                                return;
                            }
                        }
                        else if (change.Field == "SuppMon" && change.IsDirty<float>())
                        {
                            bg.SuppMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                            suppmon = ParToDecimal.ParToDel(HidSupp.Text.ToString()) + ParToDecimal.ParToDel(change.OldValue<float>().ToString()) - bg.SuppMon;
                            if (suppmon < 0 || baamon < 0)
                            {
                                if (suppmon < 0)
                                {
                                    X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
                                    rc.SetValue(rc.OldValue<float>());
                                    return;
                                }
                                else
                                {
                                    X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                                    rc.SetValue(rc.OldValue<float>());
                                    return;
                                }

                            }
                        }
                    }
                }
                decimal QuotaMon = BG_QuotaLogic.GetQuotaMoney(piid, year);
                if (QuotaMon>0&&QuotaMon-(bg.BAAMon+bg.SuppMon)<0)
                {
                    X.Msg.Alert("提示", "该科目设置总金额超过年度设置的定额标准，请核实后修改数据！").Show();
                    rc.SetValue(rc.OldValue<float>());
                    return;
                }
                BG_BudgetAllocationManager.ModifyBG_BudgetAllocation(bg);
                DtDataBind();
                //if (baamon < 0 || suppmon < 0)
                //{
                //    if (baamon > 0)
                //    {
                //        X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }
                //    else if (suppmon > 0)
                //    {
                //        X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }
                //    else
                //    {
                //        X.Msg.Alert("提示", "追加余额或总余额不足，请核实后修改数据！").Show();
                //        rc.SetValue(rc.OldValue<float>());
                //    }

                //}
                //else
                //{
                //    BG_BudgetAllocationManager.ModifyBG_BudgetAllocation(bg);
                //    DtDataBind();
                //}

                #region 8-8   修改后总分配额不能少于已经审核通过的金额
                //if (Mon - ParToDecimal.ParToDel(rc.OldValue<float>().ToString()) + ParToDecimal.ParToDel(rc.Value<float>().ToString()) - UseMon < 0)
                //{
                //    X.Msg.Alert("提示", "修改后总分配额不能少于已经审核通过的金额").Show();
                //    rc.SetValue(rc.OldValue<float>());
                //}
                //else
                //{
                //    foreach (RowChanges change in e.Changes)
                //    {
                //        if (change.Field == "BAAMon" && change.IsDirty<float>())
                //        {
                //            bg.BAAMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                //            baamon = ParToDecimal.ParToDel(HidBAA.Text.ToString()) + ParToDecimal.ParToDel(change.OldValue<float>().ToString()) - bg.BAAMon;

                //        }
                //        else if (change.Field == "SuppMon" && change.IsDirty<float>())
                //        {
                //            bg.SuppMon = ParToDecimal.ParToDel(change.Value<float>().ToString());
                //            suppmon = ParToDecimal.ParToDel(HidSupp.Text.ToString()) + ParToDecimal.ParToDel(change.OldValue<float>().ToString()) - bg.SuppMon;

                //        }
                //    }
                //    if (baamon < 0 || suppmon < 0)
                //    {
                //        if (baamon > 0)
                //        {
                //            X.Msg.Alert("提示", "超过追加余额，请核实后修改数据！").Show();
                //            rc.SetValue(rc.OldValue<float>());
                //        }
                //        else if (suppmon > 0)
                //        {
                //            X.Msg.Alert("提示", "超过总余额，请核实后修改数据！").Show();
                //            rc.SetValue(rc.OldValue<float>());
                //        }
                //        else
                //        {
                //            X.Msg.Alert("提示", "追加余额或总余额不足，请核实后修改数据！").Show();
                //            rc.SetValue(rc.OldValue<float>());
                //        }

                //    }
                //    else
                //    {
                //        BG_BudgetAllocationManager.ModifyBG_BudgetAllocation(bg);
                //        DtDataBind();
                //    }
                //}
                #endregion
            }
        }
    }
    protected void GetBack_DirectClick(object sender, DirectEventArgs e)
    {
        Response.Redirect(@"BudgetAllocation.aspx", true);
    }
}

