using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ext.Net.Panel panel = new Ext.Net.Panel
        {
            ID = "Home",
            Title = "首页",
            Closable = false,
            Border = false,
            Loader = new ComponentLoader
            {
                Mode = LoadMode.Frame,
                Url = @"WebPage\Policy\PLNavigate.aspx"
            }
        };
        plCenter.Add(panel);
        if (UserLimStr == "管理员")
        {
            plGuide.Hidden = false;
            plBaseSetting.Hidden = false;
            plBudgetPreview.Hidden = true;
            plBudgetEdit.Hidden = true;
            plBudgetControl.Hidden = true;
            plBudgetExecute.Hidden = true;
            plBudgetAnalyse.Hidden = true;

        }
        if (UserLimStr == "局领导")
        {
            plBaseSetting.Hidden = true;
            plBudgetPreview.Hidden = true;
        }
        if (UserLimStr == "审核员" || UserLimStr == "出纳员")
        {
            plBaseSetting.Hidden = true;

        }
        if (UserLimStr == "录入员")
        {
            plBaseSetting.Hidden = true;
            plBudgetPreview.Hidden = true;
            plBudgetAnalyse.Hidden = true;
        }

        if (UserLimStr == "查询员")
        {
            plGuide.Hidden = true;
            plBaseSetting.Hidden = true;
            plBudgetPreview.Hidden = true;
            plBudgetEdit.Hidden = true;
            plBudgetControl.Hidden = true;
            plBudgetExecute.Hidden = true;
        }
    }

    #region 左侧菜单

    #region 政策指导
    /// <summary>
    /// 政策指导
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes1(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodePL1";
        //node1.Text = "整站导航";
        //node1.Href = "WebPage\\Policy\\PLNavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;

        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodePL2";
        node2.Text = "操作说明";
        node2.Href = "WebPage\\Policy\\PLOperationDoc.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);

        Node node3 = new Node();
        node3.NodeID = "NodePL3";
        node3.Text = "预算编报口径";
        node3.Href = "WebPage\\Policy\\PLUniformRules.aspx";
        node3.Icon = Icon.PageEdit;
        node3.Leaf = true;
        nodes.Add(node3);

        if (UserLimStr == "管理员")
        {
            Node node4 = new Node();
            node4.NodeID = "NodePL4";
            node4.Text = "政策指导";
            node4.Href = "WebPage\\Policy\\PolicyEditList.aspx";
            node4.Icon = Icon.PageGo;
            node4.Leaf = true;
            nodes.Add(node4);

            Node node5 = new Node();
            node5.NodeID = "NodePL5";
            node5.Text = "预算项目类库";
            node5.Href = "WebPage\\Policy\\LibrariesEditList.aspx";
            node5.Icon = Icon.FolderPageWhite;
            node5.Leaf = true;
            nodes.Add(node5);
        }

        e.Nodes = nodes;
    }
    #endregion

    #region 基本设置
    /// <summary>
    /// 基本设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes2(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodeST1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\Setting\\STNavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;
        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodeST2";
        node2.Text = "操作说明";
        node2.Href = "WebPage\\Setting\\STOperationDoc.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);



        //Node node3 = new Node();
        //node3.NodeID = "Nodend3";
        //node3.Text = "部门设置";
        //node3.Href = "WebPage\\Setting\\a3.aspx";
        //node3.Icon = Icon.Folder;
        //node3.Leaf = true;
        //nodes.Add(node3);

        //Node node4 = new Node();
        //node4.NodeID = "Nodend4";
        //node4.Text = "人员设置";
        //node4.Href = "WebPage\\Setting\\a4.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        //Node node5 = new Node();
        //node5.NodeID = "Nodend5";
        //node5.Text = "控制单元";
        //node5.Href = "WebPage\\Setting\\a4.aspx";
        //node5.Icon = Icon.Folder;
        //node5.Leaf = true;
        //nodes.Add(node5);


        Node node3 = new Node();
        node3.NodeID = "NodeST3";
        node3.Text = "部门设置";
        node3.Href = "WebPage\\Setting\\STDepartment.aspx";
        node3.Icon = Icon.UserHome;
        node3.Leaf = true;
        nodes.Add(node3);

        Node node4 = new Node();
        node4.NodeID = "NodeST4";
        node4.Text = "人员设置";
        node4.Href = "WebPage\\Setting\\STMember.aspx";
        node4.Icon = Icon.User;
        node4.Leaf = true;
        nodes.Add(node4);

        //Node node5 = new Node();
        //node5.NodeID = "NodeST5";
        //node5.Text = "项目控制列表";
        //node5.Href = "WebPage\\Setting\\BudProjectList.aspx";
        //node5.Icon = Icon.Folder;
        //node5.Leaf = true;
        //nodes.Add(node5);
        Node node8 = new Node();
        node8.NodeID = "NodeST8";
        node8.Text = "密码修改记录";
        node8.Href = "WebPage\\Setting\\HisPassword.aspx";
        node8.Icon = Icon.ApplicationDouble;
        node8.Leaf = true;
        nodes.Add(node8); 

        Node node6 = new Node();
        node6.NodeID = "NodeST6";
        node6.Text = "其他设置";
        node6.Href = "WebPage\\Setting\\STOther.aspx";
        node6.Icon = Icon.Wand;
        node6.Leaf = true;
        nodes.Add(node6); 

        e.Nodes = nodes;
    }
    #endregion


    #region 预算测算


    /// <summary>
    /// 预算测算
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes3(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodePE1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\BudgetEstimate\\PENavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;
        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodePE2";
        node2.Text = "操作说明";
        node2.Href = "WebPage\\BudgetEstimate\\PEOperationDoc.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);


        //Node node3 = new Node();
        //node3.NodeID = "NodePE3";
        //node3.Text = "预算总览";
        //node3.Href = "WebPage\\BudgetEstimate\\BudgetOverview.aspx";
        //node3.Icon = Icon.PackageGo;
        //node3.Leaf = true;
        //nodes.Add(node3);

        Node node4 = new Node();
        node4.NodeID = "NodePE4";
        node4.Text = "人员经费预算";
        node4.Href = "WebPage\\BudgetEstimate\\BEPersonExpenseBudget.aspx";
        node4.Icon = Icon.UserComment;
        node4.Leaf = true;
        nodes.Add(node4);

        Node node5 = new Node();
        node5.NodeID = "NodePE5";
        node5.Text = "公用经费预算";
        node5.Href = "WebPage\\BudgetEstimate\\BEPublicExpenseBudget.aspx";
        node5.Icon = Icon.Brick;
        node5.Leaf = true;
        nodes.Add(node5);

        Node node6 = new Node();
        node6.NodeID = "NodePE6";
        node6.Text = "项目经费预算";
        node6.Href = "WebPage\\BudgetEstimate\\BEProjectExpenseBudget.aspx";
        node6.Icon = Icon.Calculator;
        node6.Leaf = true;
        nodes.Add(node6);

        Node node7 = new Node();
        node7.NodeID = "NodePE7";
        node7.Text = "预算科目汇总";
        node7.Href = "WebPage\\BudgetEstimate\\BEBudgetSubject.aspx";
        node7.Icon = Icon.PackageGreen;
        node7.Leaf = true;
        nodes.Add(node7);

        Node node9 = new Node();
        node9.NodeID = "NodePE9";
        node9.Text = "预算测算分配";
        node9.Href = "WebPage\\BudgetEstimate\\EstimateAllocation.aspx";
        node9.Icon = Icon.Book;
        node9.Leaf = true;
        nodes.Add(node9);

        Node node10 = new Node();
        node10.NodeID = "NodePE10";
        node10.Text = "测算分配情况";
        node10.Href = "WebPage\\BudgetEstimate\\BEBudgetPayDivide.aspx";
        node10.Icon = Icon.Bookmark;
        node10.Leaf = true;
        nodes.Add(node10);

        e.Nodes = nodes;
    }

    #endregion

    #region 预算编辑
    /// <summary>
    /// 预算编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes4(object sender, NodeLoadEventArgs e)
    {

        NodeCollection nodes = new NodeCollection();





        //Node node3 = new Node();
        //node3.NodeID = "BEPF";
        //node3.Text = "公用经费测算";
        //node3.Href = "WebPage\\BudgetEdit\\PublicFunding.aspx";
        //node3.Icon = Icon.Folder;
        //node3.Leaf = true;
        //nodes.Add(node3);

        //Node node4 = new Node();
        //node4.NodeID = "BECF";
        //node4.Text = "资本性经费测算";
        //node4.Href = "WebPage\\BudgetEdit\\CapitalEstimates.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        //Node node5 = new Node();
        //node5.NodeID = "BEPFD";
        //node5.Text = "人员经费测算";
        //node5.Href = "WebPage\\BudgetEdit\\PerFund.aspx";
        //node5.Icon = Icon.Folder;
        //node5.Leaf = true;
        //nodes.Add(node5);

        //Node node6 = new Node();
        //node6.NodeID = "BENAdd";
        //node6.Text = "添加数据";
        //node6.Href = "WebPage\\BudgetEdit\\Add.aspx";
        //node6.Icon = Icon.Folder;
        //node6.Leaf = true;
        //nodes.Add(node6);

        //Node node7 = new Node();
        //node7.NodeID = "BENPF";
        //node7.Text = "下年度项目经费测算";
        //node7.Href = "WebPage\\BudgetEdit\\NextProFunding.aspx";
        //node7.Icon = Icon.Folder;
        //node7.Leaf = true;
        //nodes.Add(node7);

        //Node node1 = new Node();
        //node1.NodeID = "NodeBE1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\BudgetEdit\\EBNavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;
        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodeBE2";
        node2.Text = "操作说明";
        node2.Href = "WebPage\\BudgetEdit\\BEOperationDoc.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);

        if (UserLimStr == "管理员" || UserLimStr == "录入员")
        {
            Node node3 = new Node();
            node3.NodeID = "NodeBE3";
            node3.Text = "预算编辑管理";
            node3.Href = "WebPage\\BudgetEdit\\BudgetEditList.aspx";
            node3.Icon = Icon.PageEdit;
            node3.Leaf = true;
            nodes.Add(node3);
        }

        //Node node4 = new Node();
        //node4.NodeID = "NodeBE4";
        //node4.Text = "导入财政数据";
        //node4.Href = "WebPage\\BudgetEdit\\ImportFinaData.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        {
            Node node5 = new Node();
            node5.NodeID = "NodeBE5";
            node5.Text = "预算上报";
            node5.Href = "WebPage\\BudgetEdit\\BudgetExamine.aspx";
            node5.Icon = Icon.PageGo;
            node5.Leaf = true;
            nodes.Add(node5);
        }

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        {
            Node node6 = new Node();
            node6.NodeID = "NodeBE6";
            node6.Text = "预算审核";
            node6.Href = "WebPage\\BudgetEdit\\BudgetReview.aspx";
            node6.Icon = Icon.PageMagnify;
            node6.Leaf = true;
            nodes.Add(node6);
        }

        if (UserLimStr == "管理员" || UserLimStr == "局领导" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "录入员")
        {
            Node node7 = new Node();
            node7.NodeID = "NodeBE7";
            node7.Text = "预算汇总";
            node7.Href = "WebPage\\BudgetEdit\\BudgetCollect.aspx";
            node7.Icon = Icon.PageLandscape;
            node7.Leaf = true;
            nodes.Add(node7);

            Node node8 = new Node();
            node8.NodeID = "NodeBE8";
            node8.Text = "历史轨迹";
            node8.Href = "WebPage\\BudgetEdit\\History.aspx";
            node8.Icon = Icon.Lightbulb;
            node8.Leaf = true;
            nodes.Add(node8);
        }
        e.Nodes = nodes;
    }
    #endregion

    #region 预算控制
    /// <summary>
    /// 预算控制
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes5(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodeBC1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\BudgetControl\\BCNavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;

        //nodes.Add(node1);

        Node node2 = new Node();
        node2.NodeID = "NodeBC2";
        node2.Text = "操作说明";
        node2.Href = "WebPage\\BudgetControl\\BCOperationDoc.aspx";
        node2.Icon = Icon.Page;
        node2.Leaf = true;
        nodes.Add(node2);

        //Node node3 = new Node();
        //node3.NodeID = "Nodend3";
        //node3.Text = "月度用款计划";
        //node3.Href = "WebPage\\Setting\\a3.aspx";
        //node3.Icon = Icon.Folder;
        //node3.Leaf = true;
        //nodes.Add(node3);

        //Node node4 = new Node();
        //node4.NodeID = "Nodend4";
        //node4.Text = "月度用款审核";
        //node4.Href = "WebPage\\Setting\\a4.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        {
            Node node3 = new Node();
            node3.NodeID = "NodeBC3";
            node3.Text = "导入财政数据";
            node3.Href = "WebPage\\BudgetControl\\ImportFinaData.aspx";
            node3.Icon = Icon.PageWhiteGet;
            node3.Leaf = true;
            nodes.Add(node3);
        }

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "局领导")
        {
            Node node4 = new Node();
            node4.NodeID = "NodeBC4";
            node4.Text = "预算控制列表";
            node4.Href = "WebPage\\BudgetControl\\BudConList.aspx";
            node4.Icon = Icon.ApplicationSideList;
            node4.Leaf = true;
            nodes.Add(node4);


            Node node9 = new Node();
            node9.NodeID = "NodeBC9";
            node9.Text = "预算分配";
            node9.Href = "WebPage\\BudgetControl\\BudgetAllocation.aspx";
            node9.Icon = Icon.PageAdd;
            node9.Leaf = true;
            nodes.Add(node9);

            Node node11 = new Node();
            node11.NodeID = "NodeBC11";
            node11.Text = "预算分配情况";
            node11.Href = "WebPage\\BudgetControl\\BudgetDivide.aspx";
            node11.Icon = Icon.PageAttach;
            node11.Leaf = true;
            nodes.Add(node11);

            Node node20 = new Node();
            node20.NodeID = "NodeBC20";
            node20.Text = "预算分配历史记录";
            node20.Href = "WebPage\\BudgetControl\\HisAllocation.aspx";
            node20.Icon = Icon.PageAttach;
            node20.Leaf = true;
            nodes.Add(node20);
            
        }
        if (UserLimStr == "管理员" || UserLimStr == "录入员")
        {
            Node node5 = new Node();
            node5.NodeID = "NodeBC5";
            node5.Text = "添加月度用款计划";
            node5.Href = "WebPage\\BudgetControl\\MonPayPlanNew.aspx";
            node5.Icon = Icon.PageGo;
            node5.Leaf = true;
            nodes.Add(node5);
        }
        //if (UserLimStr == "管理员" || UserLimStr == "录入员")
        //{
        //    Node node5 = new Node();
        //    node5.NodeID = "NodeBCn";
        //    node5.Text = "添加月度用款计划";
        //    node5.Href = "WebPage\\BudgetControl\\MonPayPlanGenerate.aspx";
        //    node5.Icon = Icon.Folder;
        //    node5.Leaf = true;
        //    nodes.Add(node5);
        //}
        if (UserLimStr == "管理员" || UserLimStr == "录入员" || UserLimStr == "查询员")
        {
            Node node6 = new Node();
            node6.NodeID = "NodeBC6";
            node6.Text = "查询月度用款计划";
            node6.Href = "WebPage\\BudgetControl\\SelMonPayPlan.aspx";
            node6.Icon = Icon.PageFind;
            node6.Leaf = true;
            nodes.Add(node6);
        }
        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        {
            Node node7 = new Node();
            node7.NodeID = "NodeBC7";
            node7.Text = "财务科审核";
            node7.Href = "WebPage\\BudgetControl\\FinAudit.aspx";
            node7.Icon = Icon.PageGreen;
            node7.Leaf = true;
            nodes.Add(node7);
        }

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "局领导")
        {
            Node node8 = new Node();
            node8.NodeID = "NodeBC8";
            node8.Text = "分管局长审核";
            node8.Href = "WebPage\\BudgetControl\\ChaSecAudit.aspx";
            node8.Icon = Icon.PackageGreen;
            node8.Leaf = true;
            nodes.Add(node8); 

            Node node12 = new Node();
            node12.NodeID = "NodeBC12";
            node12.Text = "收入与支出对比情况表";
            node12.Href = "WebPage\\BudgetControl\\IncomeContrastpaySituation.aspx";
            node12.Icon = Icon.PageLink;
            node12.Leaf = true;
            nodes.Add(node12);
//            Node node12 = new Node();
//            node12.NodeID = "NodeBC12";
//            node12.Text = "定额设置";
//            node12.Href = "WebPage\\BudgetControl\\STQuota.aspx";
//            node12.Icon = Icon.PageLink;
//            node12.Leaf = true;
//            nodes.Add(node12);
        }
//        if (UserLimStr == "出纳员")
//        {
//            Node nodec = new Node();
//            nodec.NodeID = "NodeBCC";
//            nodec.Text = "分管局长审核";
//            nodec.Href = "WebPage\\BudgetControl\\CashierAudit.aspx";
//            nodec.Icon = Icon.PagePortraitShot;
//            nodec.Leaf = true;
//            nodes.Add(nodec);
//        }

        //if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        //{
        //    Node node9 = new Node();
        //    node9.NodeID = "NodeBC9";
        //    node9.Text = "生成月度用款计划";
        //    node9.Href = "WebPage\\BudgetControl\\MonPayPlan.aspx";
        //    node9.Icon = Icon.Folder;
        //    node9.Leaf = true;
        //    nodes.Add(node9);
        //}

        //Node node10 = new Node();
        //node10.NodeID = "NodeBC10";
        //node10.Text = "导入财政数据";
        //node10.Href = "WebPage\\BudgetControl\\ImportFinaData.aspx";
        //node10.Icon = Icon.Folder;
        //node10.Leaf = true;
        //nodes.Add(node10);
       

        e.Nodes = nodes;
    }
    #endregion

    #region 预算执行
    /// <summary>
    /// 预算执行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes6(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "录入员")
        {
            Node node4 = new Node();
            node4.NodeID = UserID.ToString();
            node4.Text = "报销管理";
            // node4.AddScript("59.175.153.45:8082?UserID={0}", UserID);
            node4.Href = "http://59.175.153.45:8082?UserID=" + UserID;
            node4.Icon = Icon.BookEdit;
            node4.Leaf = true;
            nodes.Add(node4);
        }
        //Node node1 = new Node();
        //node1.NodeID = "NodeBX1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\BudgetExecute\\BXNavigate.aspx";
        //node1.Icon = Icon.Folder;
        //node1.Leaf = true;

        //nodes.Add(node1);

        //Node node2 = new Node();
        //node2.NodeID = "NodeBX2";
        //node2.Text = "操作说明";
        //node2.Href = "WebPage\\BudgetExecute\\BXOperationDoc.aspx";
        //node2.Icon = Icon.Folder;
        //node2.Leaf = true;
        //nodes.Add(node2);
        ////if (UserLimStr == "管理员" || UserLimStr == "录入员")
        ////{
        ////    Node node3 = new Node();
        ////    node3.NodeID = UserID.ToString();
        ////    node3.Text = "申请";
        ////   // node3.Href = "WebPage\\BudgetExecute\\ApplyList.aspx";
        ////    node3.Icon = Icon.BookAdd;
        ////    node3.Leaf = true;
        ////    //nodes.Add(node3);
        ////}
        ////if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        ////{
        ////    Node node4 = new Node();
        ////    node4.NodeID = "NodeBX4";
        ////    node4.Text = "审批";
        ////    node4.Href = "WebPage\\BudgetExecute\\ReimApproval.aspx";
        ////    node4.Icon = Icon.BookEdit;
        ////    node4.Leaf = true;
        ////    nodes.Add(node4);
        ////}
        ////if (UserLimStr == "管理员" || UserLimStr == "查询员")
        ////{
        ////    Node node5 = new Node();
        ////    node5.NodeID = "NodeBX5";
        ////    node5.Text = "报账员查询";
        ////    node5.Href = "WebPage\\BudgetExecute\\ReimStaffQuery.aspx";
        ////    node5.Icon = Icon.BookPrevious;
        ////    node5.Leaf = true;
        ////    nodes.Add(node5);
        ////}
        ////if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        ////{
        ////    Node node6 = new Node();
        ////    node6.NodeID = "NodeBX6";
        ////    node6.Text = "报销单历史查询";
        ////    node6.Href = "WebPage\\BudgetExecute\\AuditorQuery.aspx";
        ////    node6.Icon = Icon.BookOpen;
        ////    node6.Leaf = true;
        ////    nodes.Add(node6);
        ////}
        ////if (UserLimStr == "管理员" || UserLimStr == "局领导")
        ////{
        ////    Node node7 = new Node();
        ////    node7.NodeID = "NodeBX7";
        ////    node7.Text = "报销单历史查询";
        ////    node7.Href = "WebPage\\BudgetExecute\\LeaderQuery.aspx";
        ////    node7.Icon = Icon.ChartLine;
        ////    node7.Leaf = true;
        ////    nodes.Add(node7);
        ////}
        //if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员")
        //{
        //    Node node8 = new Node();
        //    node8.NodeID = "NodeBX8";
        //    node8.Text = "财务核算";
        //    node8.Href = "WebPage\\BudgetExecute\\FinAccounting.aspx";
        //    node8.Icon = Icon.Folder;
        //    node8.Leaf = true;
        //    nodes.Add(node8);
        //}

        ////if (UserLimStr == "管理员" || UserLimStr == "录入员")
        ////{
        ////    Node node9 = new Node();
        ////    node9.NodeID = "NodeBX9";
        ////    node9.Text = "报销单历史查询";
        ////    node9.Href = "WebPage\\BudgetExecute\\QueryApplystateList.aspx";
        ////    node9.Icon = Icon.ChartLine;
        ////    node9.Leaf = true;
        ////    nodes.Add(node9);
        ////}

        ////if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "录入员")
        ////{
        ////    Node node10 = new Node();
        ////    node10.NodeID = "NodeBX10";
        ////    node10.Text = "申请额度查询";
        ////    node10.Href = "WebPage\\BudgetExecute\\ApplyLimit.aspx";
        ////    node10.Icon = Icon.ChartLineLink;
        ////    node10.Leaf = true;
        ////    nodes.Add(node10);
        ////}

        //if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "录入员")
        //{
        //    Node node10 = new Node();
        //    node10.NodeID = "NodeBX100";
        //    node10.Text = "申请额度查询";
        //    node10.Href = "WebPage\\BudgetExecute\\ApplyAdd.aspx";
        //    node10.Icon = Icon.Folder;
        //    node10.Leaf = true;
        //    nodes.Add(node10);
        //}

        e.Nodes = nodes;
    }
    #endregion

    #region 预算分析
    /// <summary>
    /// 预算分析
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes7(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();
        //Node node1 = new Node();
        //node1.NodeID = "NodeBA1";
        //node1.Text = "导航";
        //node1.Href = "WebPage\\BudgetAnalyse\\BANavigate.aspx";
        //node1.Icon =  Icon.Folder;
        //node1.Leaf = true;

        //nodes.Add(node1);

        //Node node2 = new Node();
        //node2.NodeID = "NodeBA2";
        //node2.Text = "操作说明";
        //node2.Href = "WebPage\\BudgetAnalyse\\BAOperationDoc.aspx";
        //node2.Icon = Icon.Folder;
        //node2.Leaf = true;
        //nodes.Add(node2);

        if (UserLimStr == "管理员" || UserLimStr == "审核员" || UserLimStr == "出纳员" || UserLimStr == "局领导" || UserLimStr == "查询员")
        {
            Node node3 = new Node();
            node3.NodeID = "NodeBA3";
            node3.Text = "预算控制执行表";
            node3.Href = "WebPage\\BudgetAnalyse\\BudConExeList.aspx";
            node3.Icon = Icon.PageGear;
            node3.Leaf = true;
            nodes.Add(node3);

            Node node4 = new Node();
            node4.NodeID = "NodeBA4";
            node4.Text = "收入及支出对比分析表";
            node4.Href = "WebPage\\BudgetAnalyse\\IncomeContrastpay.aspx";
            node4.Icon = Icon.PageLink;
            node4.Leaf = true;
            nodes.Add(node4);
        }

        //Node node4 = new Node();
        //node4.NodeID = "NodeBA4";
        //node4.Text = "部门项目执行表";
        //node4.Href = "WebPage\\BudgetAnalyse\\DepSubControlExeList.aspx";
        //node4.Icon = Icon.Folder;
        //node4.Leaf = true;
        //nodes.Add(node4);

        e.Nodes = nodes;
    }
    #endregion

    #region 下载专区
    /// <summary>
    /// 下载专区
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetExNodes8(object sender, NodeLoadEventArgs e)
    {
        NodeCollection nodes = new NodeCollection();

        Node node1 = new Node();
        node1.NodeID = "NodeDd";
        node1.Text = "谷歌浏览器下载";
        node1.Href = "WebPage\\Download\\GoolgleDownload.aspx";
        node1.Icon = Icon.DiskDownload;
        node1.Leaf = true;
        nodes.Add(node1);

        e.Nodes = nodes;
    }
    #endregion

    #endregion

    protected void CloseAllPages_DirectClick(object sender, DirectEventArgs e)
    {
        //HidID.Value.TrimEnd('*'); 
        //string[] HID=HidID.Value.Split('*');
        //for (int i = 0; i < HID.Count()-1; i++)
        //{
        //    plCenter.Remove(HID[i]);
        //    plCenter.SetActiveTab("tabHome");
        //} 
        plCenter.RemoveAll();
        Ext.Net.Panel panel = new Ext.Net.Panel
        {
            ID = "tabHome",
            Title = "首页",
            Closable = false,
            Border = false,
            Loader = new ComponentLoader
            {
                Url = @"WebPage\Policy\PLNavigate.aspx"
            }
        };
        plCenter.Add(panel);
        panel.Render();

        //plCenter.ActiveTab.ID.ToString(); 
        //plCenter.SetActiveTab();
    }
    [DirectMethod]
    public void GetPayNewTab()
    {
        //plCenter.SetActiveTab(tab); 
        Session["NodeBC59"]=null;
    }
    [DirectMethod]
    public void GetNewTab(string url)
    {
        //HidUrl.Value.TrimEnd('*');
        //string[] HURL = HidUrl.Value.Split('*'); 
        string newurl = "";
        if (url == "")
        {
            return;
        }
        if (url.Contains("Navigate"))
        {
            string sname = url.Split('\\')[1];
            plCenter.SetActiveTab(sname);
            return;
        }
        if (url.Contains("BudgetAnalyse"))
        {
            newurl = @"WebPage\BudgetAnalyse\BANavigate.aspx";
        }
        else if (url.Contains("BudgetControl"))
        {
            newurl = @"WebPage\BudgetControl\BCNavigate.aspx";
        }
        else if (url.Contains("BudgetEdit"))
        {
            newurl = @"WebPage\BudgetEdit\BENavigate.aspx";
        }
        else if (url.Contains("BudgetEstimate"))
        {
            newurl = @"WebPage\BudgetEstimate\PENavigate.aspx";
        }
        else if (url.Contains("BudgetExecute"))
        {
            newurl = @"WebPage\BudgetExecute\BXNavigate.aspx";
        }
        //else if (url.Contains("Policy"))
        //{
        //    newurl = @"WebPage\Policy\PLNavigate.aspx";
        //}
        else if (url.Contains("Setting"))
        {
            newurl = @"WebPage\Policy\STNavigate.aspx";
        }
        else
        {
            return;
        }
        CreateTab(newurl);
        plCenter.SetLastTabAsActive();
    }
    [DirectMethod]
    public void Addlistitem(string addurl)
    {
        if (addurl.Contains("http"))
        {
            return;
        }
        string sname = addurl.Split('\\')[1];
        if (Hidstname.Value.ToString().Contains(sname))
        {
            return;
        }
        Hidstname.Value += sname + "*";
    }
    [DirectMethod]
    public void Dellistitem(string delurl)
    {
        if (delurl.Contains("http"))
        {
            return;
        }
        string sname = delurl.Split('\\')[1];
        Hidstname.Value.ToString().Replace(sname + "*", "");
    }
    private void CreateTab(string url)
    {
        string sname = url.Split('\\')[1];
        if (plCenter.ItemID == sname)
        {
            plCenter.SetActiveTab(sname);
        }
        else
        {
            Hidstname.Value += sname + "*";
            Ext.Net.Panel panel = new Ext.Net.Panel
            {
                ID = sname,
                Title = GetBudName(sname) + "导航",
                Closable = true,
                Border = false,
                Frame = true,
                Loader = new ComponentLoader
                {
                    Mode = LoadMode.Frame,
                    Url = url
                }
            };
            plCenter.Add(panel);
            //plCenter.SetActiveTab(panel);
            panel.Render();
        }
    }
    private string GetBudName(string sname)
    {
        string budname = "";
        switch (sname)
        {
            case "BudgetAnalyse":
                budname = "预算分析";
                break;
            case "BudgetControl":
                budname = "预算控制";
                break;
            case "BudgetEdit":
                budname = "预算编辑";
                break;
            case "BudgetEstimate":
                budname = "预算测算";
                break;
            case "BudgetExecute":
                budname = "预算执行";
                break;
            case "Download":
                budname = "下载";
                break;
            case "Policy":
                budname = "整体";
                break;
            case "Setting":
                budname = "设置";
                break;
            default:
                budname = "整体";
                break;
        }
        return budname;
    }

    protected void btnsure_OnDirectClick(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(PasswordField.Text.Trim()))
        {
            string pwd = "";
            BG_User bgUser= BG_UserManager.GetBG_UserByUserID(UserID);
            pwd = bgUser.UserPwd;
            if (bgUser.UserPwd == PasswordField.Text.Trim())
            {
                X.Msg.Alert("系统提示", "密码不能与原密码相同").Show();
                return;
            }
            bgUser.UserPwd = PasswordField.Text.Trim();
            if ( BG_UserManager.ModifyBG_User(bgUser))
            {
                X.Msg.Alert("系统提示", "密码修改成功").Show();
                Window1.Close();
            }
            BG_ChangePwd bgChangePwd=new BG_ChangePwd();
            bgChangePwd.UserName = UserName;
            bgChangePwd.CrTime = DateTime.Now;
            bgChangePwd.DepName = DepName;
            bgChangePwd.NewPwd = bgUser.UserPwd;
            bgChangePwd.UserID = bgUser.UserID;
            bgChangePwd.OldPwd = pwd;
            BG_ChangePwdManager.AddBG_ChangePwd(bgChangePwd);
        }
    }
    [DirectMethod]
    public void GetClosetabMsg()
    { 
        X.Msg.Confirm("系统提示", "Confirm?", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = "CompanyX.DoYes()",
                Text = "Yes Please"
            },
            No = new MessageBoxButtonConfig
            {
                Handler = "CompanyX.DoNo()",
                Text = "No Thanks"
            }
        }).Show(); 
    }

    protected void lkBtn_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ScriptManager.RegisterStartupScript(this, GetType(), "lgout", "window.top.location.href='login.aspx'", true);

    }
}