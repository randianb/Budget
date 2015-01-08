<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyLimit.aspx.cs" Inherits="WebPage_BudgetExecute_ApplyLimit" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Viewport ID="ViewPort1" runat="server" Layout="FitLayout">
            <Items>
                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server" Layout="ColumnLayout" AutoScroll="true" DefaultAnchor="100%"
                    Title="申请额度查询">

                    <Store>
                        <ext:Store ID="ApplyLimit" runat="server" PageSize="17">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="depName" Type="string" />
                                         <ext:ModelField Name="totalBG" Type="float" />
                                        <ext:ModelField Name="LastmonthBalance" Type="float" />
                                        <ext:ModelField Name="Application" Type="float" />
                                        <ext:ModelField Name="CurrentAvailable" Type="float" />
                                         <ext:ModelField Name="Execute" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                             <ext:Column Align="center" ID="Deptname" runat="server" Text="部门名称" Flex="1" DataIndex="depName" />
                             <ext:Column Align="center" Sortable="true" ID="Column1"  runat="server" Text="全年预算(元)" Flex="1" DataIndex="totalBG" />
                             <ext:Column Align="center" ID="Application" runat="server" Text="本期申请(元)" Flex="1" DataIndex="Application" />
                            <ext:Column Align="center" Sortable="true" ID="LastmonthBalance"  runat="server" Text="全年预算计划剩余(元)" Flex="1" DataIndex="LastmonthBalance" />　
                             <ext:Column Align="center" ID="Execute" Hidden="True" runat="server" Text="预算执行(元)" Flex="1" DataIndex="Execute"  />
                            <ext:Column Align="center" ID="CurrentAvailable" runat="server" Text="可用余额(元)" Flex="1" DataIndex="CurrentAvailable" />
                        </Columns>
                    </ColumnModel>

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Layout="AnchorLayout" BaseCls="background:transparent">
                            <Items>
                                <ext:Panel ID="Panel1" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="年　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbyear" Editable="false" runat="server" ColumnWidth="0.2 " DisplayField="Year">
                                            <Store>
                                                <ext:Store ID="cmbyearstore" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model2" runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="Year"></ext:ModelField>
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel2" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" MarginSpec="5 5 0 5" Text="月　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" Editable="false" ID="cmbmonth" runat="server" ColumnWidth="0.2">
                                            <Items>
                                                <ext:ListItem Text="1" Value="01" />
                                                <ext:ListItem Text="2" Value="02" />
                                                <ext:ListItem Text="3" Value="03" />
                                                <ext:ListItem Text="4" Value="04" />
                                                <ext:ListItem Text="5" Value="05" />
                                                <ext:ListItem Text="6" Value="06" />
                                                <ext:ListItem Text="7" Value="07" />
                                                <ext:ListItem Text="8" Value="08" />
                                                <ext:ListItem Text="9" Value="09" />
                                                <ext:ListItem Text="10" Value="10" />
                                                <ext:ListItem Text="11" Value="11" />
                                                <ext:ListItem Text="12" Value="12" />
                                            </Items>
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel4" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0">
                                    <Items>
                                        <ext:Label ID="Label3" runat="server" MarginSpec="5 5 0 5" Text="部　　门：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbDep"  Disabled="True" runat="server" ColumnWidth="0.2 " DisplayField="DepName">
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel3" runat="Server" Border="false" BaseCls="background:transparent">
                                    <Items>
                                        <ext:Button runat="Server" ID="btnsure" Icon="Accept" Text="确定" OnDirectClick="btnsure_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="Server" Border="false" Title="申请额度列表"></ext:Panel>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:GridPanel>

            </Items>

        </ext:Viewport>
    </form>
</body>
</html>
