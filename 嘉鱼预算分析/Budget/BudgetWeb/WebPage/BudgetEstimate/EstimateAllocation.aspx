<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EstimateAllocation.aspx.cs" Inherits="WebPage_BudgetControl_EstimateAllocation" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">

        var gridCommand = function (sender, command, record) {

            if (command == "Divide") {
                App.direct.DivideData(record.data.DepID);
            }
        }
    </script>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport runat="server" ID="vwpLayout" Layout="fit">
            <Items>
                <ext:Hidden runat="server" ID="HidYear"></ext:Hidden>
                <ext:GridPanel ID="GridPanel1" ColumnLines="true"
                    runat="server"
                    Title="预算分配">
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="DepID" />
                                        <ext:ModelField Name="DepNum" />
                                        <ext:ModelField Name="BEAMon" Type="Float" />
                                        <ext:ModelField Name="DepName" />

                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1"
                                runat="server"
                                Text="编号"
                                Width="100" Align="Center"
                                DataIndex="DepNum" />

                            <ext:Column ID="Column2"
                                runat="server"
                                Text="部门名称"
                                DataIndex="DepName"
                                Flex="1" />
                            <ext:Column ID="Column3"
                                runat="server"
                                Text="分配金额"
                                DataIndex="BEAMon"
                                EmptyCellText="0.00"
                                Flex="1" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Header="用户操作" Width="200">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Divide" Text="分配" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="25">
                            <Items>
                                <%--<ext:Button ID="btnAdd"
                                    Icon="ApplicationAdd"
                                    runat="server" Text="增加" OnDirectClick="btnAdd_DirectClick" />--%>
                                <ext:Label ID="Label6" runat="server" Text=""></ext:Label>
                                <ext:Label ID="Label3" runat="server" Text="年度省级下发余额"></ext:Label>
                                <ext:Label ID="Label4" runat="server" Text=""></ext:Label>
                            </Items>
                        </ext:Toolbar>

                    </TopBar>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>

        <ext:Window ID="WinAdd" runat="server"
            Title="分配"
            Width="460"
            Height="280"
            Icon="UserAdd"
            AnimCollapse="false"
            HideMode="Offsets"
            Resizable="false"
            CloseAction="Hide"
            Hidden="true"
            Layout="FitLayout">
            <Items>

                <ext:Hidden ID="HidDepid" runat="server"></ext:Hidden>
                <ext:GridPanel  ColumnLines="true" ID="gridpanel2" runat="server" AutoScroll="true" Border="false">
                    <Store>
                        <ext:Store ID="Store2" runat="server" PageSize="5">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Name" Type="string" />
                                        <ext:ModelField Name="BEAMon" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:SummaryColumn Sortable="true" ID="SummaryColumn1" runat="server" Text="经济科目名称" Flex="1" DataIndex="Name" />
                            <ext:SummaryColumn Sortable="true" ID="SummaryColumn2" runat="server" Text="经费" Flex="1" DataIndex="BEAMon" />
                        </Columns>
                    </ColumnModel>
                    <DockedItems>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true" Dock="Bottom">
                            <Items>
                                <ext:Button runat="server" ID="btnSearch" Text="添加" OnDirectClick="btnSearch_DirectClick" Icon="Add" Width="60" Height="24"></ext:Button>
                            </Items>
                        </ext:PagingToolbar>
                    </DockedItems>

                </ext:GridPanel>
            </Items>
        </ext:Window>

        <ext:Window ID="Window1" runat="server"
            Title="添加"
            Width="300"
            Height="180"
            Icon="UserAdd"
            AnimCollapse="false"
            HideMode="Offsets"
            Resizable="false"
            CloseAction="Hide"
            Hidden="true">
            <Items>

                <ext:Container ID="Container1" runat="server" Layout="ColumnLayout" PaddingSpec="10 0 0 10">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="选择经济科目名称："></ext:Label>
                        <ext:ComboBox ID="ComboBox1" runat="server" DisplayField="PIEcoSubName" PaddingSpec="0 0 0 ０">
                            <Store>
                                <ext:Store ID="cmbName" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="PIEcoSubName" Type="String">
                                                </ext:ModelField> 
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <SelectedItems>
                                <ext:ListItem Index="0" >
                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container2" runat="server" Layout="ColumnLayout" PaddingSpec="20 0 0 10">
                    <Items>
                        <ext:Label ID="Label2" runat="server" Text="经　　　　　　费："></ext:Label>
                        <ext:TextField runat="server" PaddingSpec="0 0 0 ０" ID="tfMon"></ext:TextField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container3" runat="server" Layout="ColumnLayout" PaddingSpec="20 0 0 130">

                    <Items>
                        <ext:Button ID="btnSure" runat="server" Text="确定" OnDirectClick="btnSure_DirectClick" Width="50" Height="24"></ext:Button>
                    </Items>
                </ext:Container>
                <ext:Hidden runat="server" ID="tatal"></ext:Hidden>
            </Items>
        </ext:Window>

    </form>
</body>
</html>

