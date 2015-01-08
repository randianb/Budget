<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoPubDetail.aspx.cs" Inherits="WebPage_InfoPublic_InfoPubDetail" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>信息公开详细</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Panel ID="Panel1" runat="server" Height="80" Title="引用预算数据" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox ID="cmbYear" runat="server" FieldLabel="时间" Width="300px" Margin="10">
                    <Items>
                        <ext:ListItem Text="2011" Value="2011" />
                        <ext:ListItem Text="2012" Value="2012" />
                        <ext:ListItem Text="2013" Value="2013" />
                        <ext:ListItem Text="2014" Value="2014" />
                    </Items>
                    <SelectedItems>
                        <ext:ListItem Value="2014"></ext:ListItem>
                    </SelectedItems>
                </ext:ComboBox>
                <ext:Button ID="btnSearch" runat="server" Text="搜索" Icon="ArrowRefresh" Margin="10" OnDirectClick="btnSearch_DirectClick">
                </ext:Button>
            </Items>
        </ext:Panel>


        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            Title="信息公开列表显示"
            Icon="ApplicationViewColumns"
            Layout="Column"
            AutoScroll="true"
            AutoHeight="false"
            BodyStyle="width:100%"
            AutoWidth="true"
            Border="false">

            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Model>
                        <ext:Model ID="Model1" runat="server" Name="aaaa">
                            <Fields>
                                <ext:ModelField Name="EICoding" Type="String" />
                                <ext:ModelField Name="EIName" Type="String" />
                                <ext:ModelField Name="IABudMon" Type="String" />
                                <ext:ModelField Name="IAAudMon" Type="String" />
                                <ext:ModelField Name="IACkMon" Type="String" />
                                <ext:ModelField Name="TQiackmon" Type="String" />
                                <ext:ModelField Name="iabmRatio" Type="String" />
                                <ext:ModelField Name="iaamRatio" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>

            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1" runat="server" Align="Center" Text="分析项目名称" Width="150" DataIndex="EICoding" />
                    <ext:Column ID="Column2" runat="server" Align="Center" Text="预算数" Flex="1" DataIndex="EIName" />
                    <ext:Column ID="Column3" runat="server" Align="Center" Text="本期数">
                        <Columns>
                            <ext:SummaryColumn ID="SummaryColumn1" runat="server" Align="Center" Text="小计">
                                <Columns>
                                    <ext:SummaryColumn ID="SummaryColumn7" runat="server" Align="Center" Text="金额" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn8" runat="server" Align="Center" Text="平均值" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                                </Columns>
                            </ext:SummaryColumn>

                            <ext:SummaryColumn ID="SummaryColumn2" runat="server" Align="Center" Text="基本支出" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn3" runat="server" Align="Center" Text="项目支出" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                        </Columns>
                    </ext:Column>
                    <ext:Column ID="Column4" runat="server" Align="Center" Text="同期数">
                        <Columns>
                            <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="小计">
                                <Columns>
                                    <ext:SummaryColumn ID="SummaryColumn9" runat="server" Align="Center" Text="金额" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn10" runat="server" Align="Center" Text="平均值" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                                </Columns>
                            </ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="基本支出" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn6" runat="server" Align="Center" Text="项目支出" Width="80" DataIndex="TQiackmon"></ext:SummaryColumn>
                        </Columns>
                    </ext:Column>
                    <ext:Column ID="Column5" runat="server" Align="Center" Text="预算比" Flex="1" />
                    <ext:Column ID="Column6" runat="server" Align="Center" Text="同期比" Flex="1" DataIndex="iabmRatio" />
                </Columns>
            </ColumnModel>


        </ext:GridPanel>
    </form>
</body>
</html>
