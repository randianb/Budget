<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BEBudgetSubject.aspx.cs" Inherits="WebPage_BudgetEstimate_BEBudgetSubject" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="AnchorLayout">
        <Items>
            <ext:Panel Border="false" ID="Panel2" runat="server" Layout="AnchorLayout" AnchorHorizontal="100%">
                <%--<LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>--%>
                <Items>
                    <ext:Panel ID="Panel1" Border="false" runat="server" Layout="ColumnLayout">
                        <Items>
                            <ext:GridPanel ColumnLines="true"
                                ID="GridPanel1"
                                runat="server"
                                Title="人员部分"
                                Collapsible="true"
                                Width="300" Height="265"
                                BorderSpec="1 1 0 1"
                                Padding="5"
                                AutoScroll="true">
                                <Store>
                                    <ext:Store ID="Store1" runat="server" PageSize="17">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="PSID" Type="int" />
                                                    <ext:ModelField Name="PSName" Type="string" />
                                                    <ext:ModelField Name="PDBaseData" Type="Float" />
                                                    <ext:ModelField Name="PDProjectData" Type="Float" />
                                                    <ext:ModelField Name="count" Type="Float" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column12"
                                            runat="server"
                                            Text="科目"
                                            DataIndex="PSName"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column5"
                                            runat="server"
                                            Text="基本经费"
                                            DataIndex="PDBaseData"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column9"
                                            runat="server"
                                            Text="项目经费"
                                            DataIndex="PDProjectData"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column10"
                                            runat="server"
                                            Text="合计"
                                            DataIndex="count"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>

                            <ext:GridPanel ColumnLines="true"
                                ID="GridPanel2"
                                runat="server"
                                Title="公用部分"
                                Collapsible="true"
                                Width="300" Height="265"
                                BorderSpec="1 1 0 1"
                                Padding="5"
                                AutoScroll="true">
                                <Store>
                                    <ext:Store ID="Store2" runat="server" PageSize="17">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="PSID" Type="int" />
                                                    <ext:ModelField Name="PSName" Type="string" />
                                                    <ext:ModelField Name="PDBaseData" Type="Float" />
                                                    <ext:ModelField Name="PDProjectData" Type="Float" />
                                                    <ext:ModelField Name="count" Type="Float" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column1"
                                            runat="server"
                                            Text="科目"
                                            DataIndex="PSName"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column4"
                                            runat="server"
                                            Text="基本经费"
                                            DataIndex="PDBaseData"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column11"
                                            runat="server"
                                            Text="项目经费"
                                            DataIndex="PDProjectData"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column13"
                                            runat="server"
                                            Text="合计"
                                            DataIndex="count"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>

                            <ext:GridPanel ColumnLines="true"
                                ID="GridPanel3"
                                runat="server"
                                Title="其他资本性支出"
                                Collapsible="true"
                                Width="300" Height="265"
                                BorderSpec="1 1 0 1"
                                Padding="5"
                                AutoScroll="true">
                                <Store>
                                    <ext:Store ID="Store3" runat="server" PageSize="17">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="PSID" Type="int" />
                                                    <ext:ModelField Name="PSName" Type="string" />
                                                    <ext:ModelField Name="PDProjectData" Type="Float" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column2"
                                            runat="server"
                                            Text="科目"
                                            DataIndex="PSName"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                        <ext:Column ID="Column3"
                                            runat="server"
                                            Text="经费"
                                            DataIndex="PDProjectData"
                                            Resizable="false"
                                            MenuDisabled="true"
                                            Flex="1" />
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>


            <%--RootVisible="false"--%>
           <ext:TreePanel
                ID="tpBgSub"
                runat="server"
                Title="其他资本性支出"
                Height="500"
                Collapsible="true"
                UseArrows="true"
                MultiSelect="true"
                SingleExpand="true"
                FolderSort="true">
                <Fields>
                    <ext:ModelField Name="PSID" Type="int" />
                    <ext:ModelField Name="PSType2" Type="string" />
                    <ext:ModelField Name="PSName" Type="string" />
                    <ext:ModelField Name="PDData" Type="Float" />
                </Fields>
                 <ColumnModel>
                    <Columns>
                        <ext:TreeColumn ID="TreeColumn1"
                            runat="server"
                            Text="支出科目类型"
                            Flex="1"
                            Sortable="true"
                            DataIndex="PSType2" />
                        <ext:Column ID="Column6"
                            runat="server"
                            Text="支出科目"
                            Flex="1"
                            Sortable="true"
                            DataIndex="PSName" />
                        <ext:Column ID="clPDData"
                            runat="server"
                            Text="经费"
                            Flex="1"
                            Sortable="true"
                            DataIndex="PDData" />
                    </Columns>

                </ColumnModel>
               <Root>
                </Root>
            </ext:TreePanel>
        </Items>
    </ext:Viewport>
</body>
</html>
