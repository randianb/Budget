<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetEditAdd.aspx.cs" Inherits="WebPage_BudgetEdit_BudgetEditAdd" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:GridPanel ColumnLines="true"
                    ID="GridPanel2"
                    runat="server" RenderTo="Ext.getbody()"
                    Title="导入财政数据" Frame="true"
                    Icon="ApplicationViewColumns" Layout="Column" AutoScroll="true"
                    AutoHeight="false" BodyStyle="width:100%" AutoWidth="true"
                    PageSize="10"
                    Border="false">
                    <Items>
                    </Items>
                </ext:GridPanel>
                <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label1" runat="server" Text="项目类别："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel1" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:ComboBox ID="ComboBox20"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar5" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label3" runat="server" Text="功能科目："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:ComboBox ID="ComboBox1"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar ID="Toolbar1" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar4" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label2" runat="server" Text="项目编号："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel2" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TFID"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar6" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label4" runat="server" Text="项目名称："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel3" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField4"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar7" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar8" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label5" runat="server" Text="行政成本类别："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel4" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:ComboBox ID="ComboBox2"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar9" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label6" runat="server" Text="项目安排频度："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel5" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:ComboBox ID="ComboBox3"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar10" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar11" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label7" runat="server" Text="项目起始时间："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel6" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField5"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar12" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label8" runat="server" Text="项目终止时间："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel7" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField6"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar13" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar14" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label9" runat="server" Text="项目负责人："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel8" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField7"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar15" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label10" runat="server" Text="项目属性："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel9" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                 <ext:ComboBox ID="ComboBox4"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar16" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar17" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label11" runat="server" Text="项目类型："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel10" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                               <ext:ComboBox ID="ComboBox5"
                            runat="server"
                            DisplayField="DepName"
                            ValueField="DepID"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"  PaddingSpec="5 0 0 15" >
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar18" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label12" runat="server" Text="预算控制数："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel11" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField9"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar19" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar20" runat="server" Height="35" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label13" runat="server" Text="项目报进日期："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel12" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                <ext:TextField ID="TextField8"  runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar21" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label14" runat="server" ></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel13" runat="server" ColumnWidth="0.3" Height="35"   >
                            <Items >
                                
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar ID="Toolbar22" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar23" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label15" runat="server" Text="项目简介："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel14" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField10"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar24" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar25" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label16" runat="server" Text="项目申请理由和主要内容："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel15" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField11"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar26" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar27" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label17" runat="server" Text="项目支出测算依据及说明："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel16" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField12"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar28" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar29" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label18" runat="server" Text="项目绩效长期目标："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel17" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField13"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar30" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar31" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label19" runat="server" Text="项目绩效年度目标："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel18" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField14"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar32" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar33" runat="server" Height="50" Border="false"  ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label20" runat="server" Text="其他说明的问题："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel19" runat="server" ColumnWidth="0.8" Height="50"   >
                            <Items >
                                <ext:TextField ID="TextField15"  runat="server" PaddingSpec="0 0 0 15" Height ="50"  Width ="800"/>
                            </Items>
                        </ext:Panel>                                              
                    </Items>
                </ext:Toolbar>
                <ext:GridPanel ColumnLines="true"
                    ID="GridPanel1"
                    runat="server" RenderTo="Ext.getbody()"
                    Title="公用经费测算" Frame="true"
                    Icon="ApplicationViewColumns" Layout="Column" AutoScroll="true"
                    AutoHeight="false" BodyStyle="width:100%" AutoWidth="true"
                    PageSize="10"
                    Border="false">

                    <Store>
                        <ext:Store ID="Store1" runat="server" PageSize="10">
                            <Model>
                                <ext:Model ID="Model1" runat="server" Name="aaaa">
                                    <Fields>
                                        <ext:ModelField Name="Pro" Type="String" />
                                        <ext:ModelField Name="BNumPeo" Type="Int" />
                                        <ext:ModelField Name="Brenjun" Type="Float" />
                                        <ext:ModelField Name="LNumPeo" Type="Int" />
                                        <ext:ModelField Name="Lrenjun" Type="Float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column5" runat="server" Flex="1" Text="行号" Margins="0 0 0 80"></ext:Column>
                            <ext:Column ID="Column6" runat="server" Flex="1" Text="当前年度" Margins="0 0 0 80"></ext:Column>
                            <ext:Column ID="Column7" runat="server" Flex="1" Text="经济科目" Margins="0 0 0 80"></ext:Column>
                            <ext:Column ID="Column8" runat="server" Flex="1" Text="总计" Margins="0 0 0 80"></ext:Column>
                            <ext:Column ID="Column2" runat="server" >
                                <Columns>
                                    <ext:Column ID="Column1" runat="server" ColumnWidth=".2" Text="小计(财政拨款)" DataIndex="Pro" />
                                    <%-- Schedule--%>
                                    <ext:Column ID="Column3" runat="server" Text="经济拨款（补助)">
                                        <Columns>
                                            <%--  Due Date   --%>
                                            <ext:SummaryColumn ID="SummaryColumn1"
                                                runat="server" ColumnWidth="1"
                                                Text="小计(经费)"
                                                Sortable="true"
                                                DataIndex="BNumPeo" Flex="1">
                                                <Editor>
                                                    <ext:TextField ID="TextField1" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>

                                            <%--Estimate --%>
                                            <ext:SummaryColumn ID="SummaryColumn2"
                                                runat="server"
                                                Text="内部开支(经费)"
                                                Sortable="true"
                                                DataIndex="Brenjun"
                                                SummaryType="Sum" ColumnWidth="1" Flex="1">
                                                <Editor>
                                                    <ext:TextField ID="TextField2" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>

                                            <ext:SummaryColumn ID="SummaryColumn3"
                                                runat="server"
                                                Text="外部拨款(经费)"
                                                Sortable="true"
                                                DataIndex="Brenjun"
                                                SummaryType="Sum" ColumnWidth="1" Flex="1">
                                                <Editor>
                                                    <ext:TextField ID="TextField3" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                </Columns>
                            </ext:Column>
                            <ext:ImageCommandColumn ID="ImageCommandColumn1" Flex="1" Text="删除" ColumnWidth=".2" runat="server" Sortable="false" Margins="0 0 0 80">
                                <Commands>
                                    <ext:ImageCommand Icon="Decline" ToolTip-Text="Delete Plant" Text="删除" CommandName="delete">
                                    </ext:ImageCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="this.up('gridpanel').store.removeAt(recordIndex);" />
                                </Listeners>
                            </ext:ImageCommandColumn>
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
                <ext:Toolbar ID="Toolbar34" runat="server" Height="40" >
                    <Items>
                        <ext:Container runat="server"  Margins="10 0 0 600"  Height="40"  >
                            <Items>
                                <ext:Button ID="btnAdd" runat="server" Text="添加"  PaddingSpec="0 10 0 10"  Height="25"   >
                                </ext:Button>
                                <ext:Button ID="Button2" runat="server" Text="确定" PaddingSpec="0 10 0 10"  Height="25">
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Text="取消" PaddingSpec="0 10 0 10" Height="25" >
                                </ext:Button>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Toolbar>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
