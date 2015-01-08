<%@ Page Language="C#" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="WebPage_BudgetEdit_History" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script type="text/javascript">
         var gridCommand = function (sender, command, record) {
             switch (command) {
                 case "Look":
                     App.direct.Look_Handler(record.data.BudID);
                     break;
            
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:Panel
                    ID="GridPanel2"
                    runat="server"  
                    Title="预算轨迹"  
                    Border="false"> 
                </ext:Panel>
                <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>

                        <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label1" runat="server" Text="部门名称："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:ComboBox ID="cbDepment"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Style="margin-top: 8px"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"
                            PaddingSpec="0 0 0 8">
                            <SelectedItems>
                                <ext:ListItem index="0"></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                        <ext:Container ID="Container3" runat="server" PaddingSpec="6 0 0 20" >
                            <Items >
                                 <ext:Button ID="btnInquiry" runat="server" Text="查 询" Height="24" Width="40" OnDirectClick="btnInquiry_DirectClick"   >
                                </ext:Button>
                            </Items>
                        </ext:Container> 
                    </Items>
                </ext:Toolbar>

                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server" AutoHeight="false" Layout="FitLayout" AutoScroll="true"
                    Title="历史轨迹列表">
                    <Store>
                        <ext:Store ID="stBudget" runat="server" PageSize="12">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="BICode" Type="string" />
                                        <ext:ModelField Name="BIProName" Type="string" />
                                        <ext:ModelField Name="BIProType" Type="string" />
                                        <ext:ModelField Name="BIFunSub" Type="string" />
                                        <ext:ModelField Name="BIMon" Type="string" />
                                        <ext:ModelField Name="BIMon" Type="string" />
                                        <ext:ModelField Name="BudSta" Type="string" />
                                         <ext:ModelField Name="BudID" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:SummaryColumn Sortable="true" ID="Column1" runat="server" Text="项目编号" Flex="1" DataIndex="BICode" />
                            <ext:SummaryColumn Sortable="true" ID="Column2" runat="server" Text="项目名称" Flex="1" DataIndex="BIProName" />
                            <ext:SummaryColumn Sortable="true" ID="Column3" runat="server" Text="项目类型" Flex="1" DataIndex="BIProType" />
                            <ext:SummaryColumn Sortable="true" ID="Column5" runat="server" Text="功能科目" Flex="1" DataIndex="BIFunSub" />
                            <ext:SummaryColumn Sortable="true" ID="Column6" runat="server" Text="预算金额" Flex="1" DataIndex="BIMon" />
                            <ext:SummaryColumn Sortable="true" ID="Column7" runat="server" Text="预算控制数" Flex="1" DataIndex="BIMon" />
                            <ext:SummaryColumn Sortable="true" ID="Column9" runat="server" Text="项目状态" Flex="1" DataIndex="BudSta" />
                            <ext:CommandColumn ID="CommandColumn3" runat="server" Header="历史轨迹" Flex="1" DataIndex="">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Look" Text="历史轨迹" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <DockedItems>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true" Dock="Bottom">
                        </ext:PagingToolbar>
                    </DockedItems>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>

        
    </form>
</body>
</html>


