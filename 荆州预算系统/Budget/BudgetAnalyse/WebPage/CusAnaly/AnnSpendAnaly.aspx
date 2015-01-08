<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnSpendAnaly.aspx.cs" Inherits="WebPage_CusAnaly_AnnSpendAnaly" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>定制分析-年度支出分析</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Panel ID="Panel1" runat="server" Height="80" Title="定制分析-选择年度数据" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox ID="cmbYear" runat="server" FieldLabel="年度数据" Width="300px" Margin="10">
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
                <ext:Label runat="server" ID="lashow" Text="" Margin="10"></ext:Label>
            </Items>
        </ext:Panel>


        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            Title="年度支出分析表"
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
                                <ext:ModelField Name="PIEcoSubCoding" Type="String" />
                                <ext:ModelField Name="PIEcoSubLev" Type="String" />
                                <ext:ModelField Name="PIEcoSubName" Type="String" />
                                <ext:ModelField Name="OABudMon" Type="String" />
                                <ext:ModelField Name="OAAudMon" Type="String" />
                                <ext:ModelField Name="OACkMon" Type="String" />
                                <ext:ModelField Name="TQoackmon" Type="String" />
                                <ext:ModelField Name="oabmRatio" Type="String" />
                                <ext:ModelField Name="oaamRatio" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>

            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1" runat="server" Align="Center" Text="科目编码" Flex="1" DataIndex="PIEcoSubCoding" />
                    <ext:Column ID="Column8" runat="server" Align="Center" Text="级数" Flex="1" DataIndex="PIEcoSubLev" />
                    <ext:Column ID="Column2" runat="server" Align="Center" Text="科目名称" Flex="1" DataIndex="PIEcoSubName" />
                    <ext:Column ID="Column3" runat="server" Align="Center" Text="预算金额" Flex="1" DataIndex="OABudMon" />
                    <ext:Column ID="Column4" runat="server" Align="Center" Text="决算金额" Flex="1" DataIndex="OAAudMon" />
                    <ext:Column ID="Column5" runat="server" Align="Center" Text="核算金额">
                        <Columns>
                            <ext:SummaryColumn ID="SummaryColumn1" runat="server" Align="Center" Text="本期数" Width="150" DataIndex="OACkMon"></ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn2" runat="server" Align="Center" Text="同期数" Width="150" DataIndex="TQoackmon"></ext:SummaryColumn>
                        </Columns>
                    </ext:Column>
                    <ext:Column ID="Column6" runat="server" Align="Center" Text="与预算比" Flex="1" DataIndex="oabmRatio" />
                    <ext:Column ID="Column7" runat="server" Align="Center" Text="与决算比" Flex="1" DataIndex="oaamRatio" />
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
    </form>
</body>
</html>
