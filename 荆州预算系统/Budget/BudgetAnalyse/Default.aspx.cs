using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

public partial class _Default : AnalyseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 左侧菜单

    #region 定制分析
    /// <summary>
    /// 定制分析
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes1(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodePL1";
        //node1.Text = "人均系数";
        //node1.Href = "WebPage\\CusAnaly\\PerCoefficient.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;

        //nodes.Add(node1);

        //Node node2 = new Node();
        //node2.NodeID = "NodePL2";
        //node2.Text = "人员支出";
        //node2.Href = "WebPage\\CusAnaly\\PerSpend.aspx";
        //node2.Icon = Icon.Folder;
        //node2.Leaf = true;
        //nodes.Add(node2);

        //Node node3 = new Node();
        //node3.NodeID = "Nodend3";
        //node3.Text = "公用支出";
        //node3.Href = "WebPage\\CusAnaly\\PubSpend.aspx";
        //node3.Icon = Icon.Folder;
        //node3.Leaf = true;
        //nodes.Add(node3);

        //Node node4 = new Node();
        //node4.NodeID = "Nodend4";
        //node4.Text = "项目支出";
        //node4.Href = "WebPage\\CusAnaly\\ProSpend.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        Node node5 = new Node();
        node5.NodeID = "NodeEx5";
        node5.Text = "年度收入分析";
        node5.Href = "WebPage\\CusAnaly\\AnnIncomAnaly.aspx";
        node5.Icon = Icon.Folder;
        node5.Leaf = true;
        nodes.Add(node5);

        Node node6 = new Node();
        node6.NodeID = "NodeEx6";
        node6.Text = "年度支出分析";
        node6.Href = "WebPage\\CusAnaly\\AnnSpendAnaly.aspx";
      
        
        node6.Icon = Icon.Folder;
        node6.Leaf = true;
        nodes.Add(node6);

        Node node7 = new Node();
        node7.NodeID = "NodeEx7";
        node7.Text = "月度收入分析";
        node7.Href = "WebPage\\CusAnaly\\MonIncomAnaly.aspx";
        node7.Icon = Icon.Folder;
        node7.Leaf = true;
        nodes.Add(node7);

        Node node8 = new Node();
        node8.NodeID = "NodeEx8";
        node8.Text = "月度支出分析";
        node8.Href = "WebPage\\CusAnaly\\MonSpendAnaly.aspx";
        node8.Icon = Icon.Folder;
        node8.Leaf = true;
        nodes.Add(node8);

        //Node node9 = new Node();
        //node9.NodeID = "Nodend9";
        //node9.Text = "固定资产";
        //node9.Href = "WebPage\\CusAnaly\\FixAssets.aspx";
        //node9.Icon = Icon.Folder;
        //node9.Leaf = true;
        //nodes.Add(node9);

        e.Nodes = nodes;
    }
    #endregion

    #region 自选分析
    /// <summary>
    /// 自选分析
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes2(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();

        //Node node1 = new Node();
        //node1.NodeID = "NodeST1";
        //node1.Text = "导入核算数据";
        //node1.Href = "WebPage\\OptAnaly\\ImportCkData.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;
        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodeST2";
        node2.Text = "月度收支分析";
        node2.Href = "WebPage\\OptAnaly\\OAAnnIncomAnaly.aspx";
        node2.Icon = Icon.Folder;
        node2.Leaf = true;
        nodes.Add(node2);

        Node node3 = new Node();
        node3.NodeID = "NodeST3";
        node3.Text = "年度收支分析";
        node3.Href = "WebPage\\OptAnaly\\AssignDataQuery.aspx";
        node3.Icon = Icon.Folder;
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

    #region 信息公开
    /// <summary>
    /// 信息公开
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes3(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        Node node1 = new Node();
        node1.NodeID = "NodePb1";
        node1.Text = "信息公开详细";
        node1.Href = "WebPage\\InfoPublic\\InfoPubDetail.aspx";
        node1.Icon = Icon.Folder;
        node1.Leaf = true;

        nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodePb2";
        node2.Text = "信息公开图表";
        node2.Href = "WebPage\\InfoPublic\\InfoPubChart.aspx";
        node2.Icon = Icon.Folder;
        node2.Leaf = true;
        nodes.Add(node2);

        Node node3 = new Node();
        node3.NodeID = "NodePb3";
        node3.Text = "信息公开统计";
        node3.Href = "WebPage\\InfoPublic\\InfoPubStat.aspx";
        node3.Icon = Icon.Folder;
        node3.Leaf = true;
        nodes.Add(node3);

        e.Nodes = nodes;
    }
    #endregion

    #endregion
}