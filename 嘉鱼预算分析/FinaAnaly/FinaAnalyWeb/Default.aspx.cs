using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Common;
using FinaAnaly.Model;
using FinaAnaly.BLL;

public partial class _Default : System.Web.UI.Page
{
    int uselim = 0;
    int depid = 0;
    string pur = string.Empty;
    string username = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["userlim"] != null)
        {
            uselim = common.IntSafeConvert(Request.QueryString["userlim"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
            pur = Request.QueryString["pur"].ToString();
            username = Request.QueryString["UserName"].ToString();
            lbUser.Text = username;
            FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
            if (fa != null)
            {
                lbDep.Text = fa.DepName;
            }
        }
        if (uselim == 1000)
        {
            plSysSetting.Visible = true;
            plAccInquiry.Visible = false;
            plCusAnaly.Visible = false;
            plDataAnaly.Visible = false;
            plOptAnaly.Visible = false;
            Panel1.Visible = false;
        }
        if (uselim == 1001)
        {
            if (pur.Substring(2, 1) == "1")
            {
                plCusAnaly.Visible = true;
            }
            else
            {
                plCusAnaly.Visible = false;
            }
            if (pur.Substring(5, 1) == "1")
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
            plSysSetting.Visible = false;
            plAccInquiry.Visible = false;
            plDataAnaly.Visible = false;
            plOptAnaly.Visible = false;
        }
        if (uselim == 1002)
        {
            plSysSetting.Visible = false;
            if (pur.Substring(1, 1) == "1")
            {
                plAccInquiry.Visible = true;
            }
            else
            {
                plAccInquiry.Visible = false;
            }
            if (pur.Substring(2, 1) == "1")
            {
                plCusAnaly.Visible = true;
            }
            else
            {
                plCusAnaly.Visible = false;

            }
            if (pur.Substring(3, 1) == "1")
            {
                plDataAnaly.Visible = true;
            }
            else
            {
                plDataAnaly.Visible = false;
            }
            if (pur.Substring(4, 1) == "1")
            {
                plOptAnaly.Visible = true;
            }
            else
            {
                plOptAnaly.Visible = false;
            }
            if (pur.Substring(5, 1) == "1")
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
        }
    }

    #region 左侧菜单

    #region 系统设置
    /// <summary>
    /// 系统设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes1(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        Node node1 = new Node();
        node1.NodeID = "NodePL1";
        node1.Text = "单位基本信息";
        node1.Href = "WebPage\\SysSetting\\UnitBaseInfoSetting.aspx";
        node1.Icon = Icon.World;
        node1.Leaf = true;
        nodes.Add(node1);

//        Node node3 = new Node();
//        node3.NodeID = "NodePL3";
//        node3.Text = "部门设置";
//        node3.Href = "WebPage\\SysSetting\\DepartManage.aspx";
//        node3.Icon = Icon.UserHome;
//        node3.Leaf = true;
//        nodes.Add(node3);

//        Node node4 = new Node();
//        node4.NodeID = "NodePL4";
//        node4.Text = "人员设置";
//        node4.Href = "WebPage\\SysSetting\\MemberManage.aspx";
//        node4.Icon = Icon.Computer;
//        node4.Leaf = true;
//        nodes.Add(node4);

        Node node2 = new Node();
        node2.NodeID = "NodePL2";
        node2.Text = "权限设置";
        node2.Href = "WebPage\\SysSetting\\LismitManage.aspx";
        node2.Icon = Icon.Key;
        node2.Leaf = true;
        nodes.Add(node2);

        Node node5 = new Node();
        node5.NodeID = "NodePL5";
        node5.Text = "预算控制数";
        node5.Href = "WebPage\\SysSetting\\BudConNum.aspx";
        node5.Icon = Icon.Connect;
        node5.Leaf = true;
        nodes.Add(node5);

        Node node6 = new Node();
        node6.NodeID = "NodePL6";
        node6.Text = "部门预算分配";
        node6.Href = "WebPage\\SysSetting\\DepBudAllocation.aspx";
        node6.Icon = Icon.StatusOnline;
        node6.Leaf = true;
        nodes.Add(node6);


        Node node7 = new Node();
        node7.NodeID = "NodePL7";
        node7.Text = "经济科目预算分配";
        node7.Href = "WebPage\\SysSetting\\IncomeBudAllocat.aspx";
        node7.Icon = Icon.Book;
        node7.Leaf = true;
        nodes.Add(node7);

        Node node8 = new Node();
        node8.NodeID = "NodePL8";
        node8.Text = "导入决算数据";
        node8.Href = "WebPage\\SysSetting\\ImpAccData.aspx";
        node8.Icon = Icon.FlowerDaisy;
        node8.Leaf = true;
        nodes.Add(node8);

        Node node9 = new Node();
        node9.NodeID = "NodePL9";
        node9.Text = "三公经费下达数";
        node9.Href = "WebPage\\SysSetting\\PUCIssNumTb.aspx";
        node9.Icon = Icon.WeatherSun;
        node9.Leaf = true;
        nodes.Add(node9);

        e.Nodes = nodes;

    }
    #endregion

    #region 预算执行情况分析
    /// <summary>
    /// 预算执行情况分析
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes2(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();

        Node node1 = new Node();
        node1.NodeID = "NodeEx1";
        node1.Text = "经费预算指标";
        node1.Href = "WebPage\\CusAnaly\\BudgetTargetAnaly.aspx";
        node1.Icon = Icon.PageGo;
        node1.Leaf = true;
        nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodeEx2";
        node2.Text = "经费预算执行情况表";
        node2.Href = "WebPage\\CusAnaly\\FundBudExecutionTb.aspx";
        node2.Icon = Icon.ComputerGo;
        node2.Leaf = true;
        nodes.Add(node2);

        e.Nodes = nodes;
    }
    #endregion

    #region 部门经费支出明细表
    /// <summary>
    /// 部门经费支出明细表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes3(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();

        if (uselim == 1001)
        {
            Node node1 = new Node();
            node1.NodeID = "NodePL1";
            node1.Text = "基层单位日常公用支出明细表";
            node1.Href = "WebPage\\CusAnaly\\GrassrootUnitDayPubSpendScheduleAnaly.aspx?uselim=" + uselim + "&depid=" + depid;
            node1.Icon = Icon.PageAdd;
            node1.Leaf = true;
            nodes.Add(node1);

            Node node2 = new Node();
            node2.NodeID = "NodePL2";
            node2.Text = "部门经费一览表";
            node2.Href = "WebPage\\CusAnaly\\DepExecution.aspx?uselim=" + uselim + "&depid=" + depid;
            node2.Icon = Icon.PageCode;
            node2.Leaf = true;
            nodes.Add(node2);
        }
        else
        {

            Node node1 = new Node();
            node1.NodeID = "NodePL1";
            node1.Text = "基层单位日常公用支出明细表";
            node1.Href = "WebPage\\CusAnaly\\GrassrootUnitDayPubSpendScheduleAnaly.aspx";
            node1.Icon = Icon.PageAdd;
            node1.Leaf = true;
            nodes.Add(node1);

            Node node2 = new Node();
            node2.NodeID = "NodePL2";
            node2.Text = "部门经费一览表";
            node2.Href = "WebPage\\CusAnaly\\DepExecution.aspx";
            node2.Icon = Icon.PageCode;
            node2.Leaf = true;
            nodes.Add(node2);
        }

        e.Nodes = nodes;
    }
    #endregion

    #region 经费支出分析明细表
    /// <summary>
    /// 经费支出分析明细表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes5(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        Node node7 = new Node();
        node7.NodeID = "NodeEP7";
        node7.Text = "经费支出对比分析表 ";
        node7.Href = "WebPage\\CusAnaly\\FundExpendContrastAnalyTB.aspx";
        node7.Icon = Icon.PageFind;
        node7.Leaf = true;
        nodes.Add(node7);

        Node node8 = new Node();
        node8.NodeID = "NodeEP8";
        node8.Text = "日常公用经费支出评估表";
        node8.Href = "WebPage\\CusAnaly\\PubFundExpendEvaForm.aspx";
        node8.Icon = Icon.PageBreakInsert;
        node8.Leaf = true;
        nodes.Add(node8);

        Node node9 = new Node();
        node9.NodeID = "NodeEP9";
        node9.Text = "三公经费支出情况表";
        node9.Href = "WebPage\\CusAnaly\\ExceExpendTb.aspx";
        node9.Icon = Icon.ShapesManySelect;
        node9.Leaf = true;
        nodes.Add(node9);


        e.Nodes = nodes;
    }
    #endregion

    #region 自选分析
    /// <summary>
    /// 自选分析
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes4(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();

        Node node2 = new Node();
        node2.NodeID = "NodeOA2";
        node2.Text = "月度支出分析";
        node2.Href = "WebPage\\OptAnaly\\MonOutlyAnaly.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);

        Node node3 = new Node();
        node3.NodeID = "NodeOA3";
        node3.Text = "年度支出分析";
        node3.Href = "WebPage\\OptAnaly\\YearOutlyAnaly.aspx";
        node3.Icon = Icon.PageAdd;
        node3.Leaf = true;
        nodes.Add(node3);

        //Node node3 = new Node();
        //node3.NodeID = "Nodend3";
        //node3.Text = "月度收入分析";
        //node3.Href = "WebPage\\OptAnaly\\OAMonIncomAnaly.aspx";
        //node3.Icon = Icon.Folder;
        //node3.Leaf = true;
        //nodes.Add(node3);

        //Node node4 = new Node();
        //node4.NodeID = "Nodend4";
        //node4.Text = "月度支出分析";
        //node4.Href = "WebPage\\OptAnaly\\OAMonSpendAnaly.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        e.Nodes = nodes;
    }
    #endregion

    #region 科、所经费查询
    /// <summary>
    /// 科、所经费查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes6(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        if (uselim == 1001)
        {
            Node node4 = new Node();
            node4.NodeID = "NodeOA4";
            node4.Text = "科所经费日记帐";
            node4.Href = "WebPage\\BraFundInquiry\\BraFundJournal.aspx?uselim=" + uselim + "&depid=" + depid;
            node4.Icon = Icon.Bookmark;
            node4.Leaf = true;
            nodes.Add(node4);
        }
        else
        {
            Node node2 = new Node();
            node2.NodeID = "NodeOA2";
            node2.Text = "科所经费额度表";
            node2.Href = "WebPage\\BraFundInquiry\\BraFundLimitTB.aspx";
            node2.Icon = Icon.Photos;
            node2.Leaf = true;
            nodes.Add(node2);

            Node node3 = new Node();
            node3.NodeID = "NodeOA3";
            node3.Text = "科所经费使用情况统计表";
            node3.Href = "WebPage\\BraFundInquiry\\BraFundUsagStat.aspx";
            node3.Icon = Icon.WeatherSun;
            node3.Leaf = true;
            nodes.Add(node3);

            Node node5 = new Node();
            node5.NodeID = "NodeOA5";
            node5.Text = "科所经费日记帐";
            node5.Href = "WebPage\\BraFundInquiry\\BraFundJournal.aspx";
            node5.Icon = Icon.Bookmark;
            node5.Leaf = true;
            nodes.Add(node5);
        }
        e.Nodes = nodes;
    }
    #endregion

    #endregion

    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx", true);
    }
}