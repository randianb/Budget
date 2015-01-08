<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportProBudControl.aspx.cs"
    Inherits="BudgetPage_mainPages_ImportProBudControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
    <script type="text/javascript">

        var edit = function (editor, e) {
            
            if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                Company4.Edit(e.record.data.PPID, e.record.data.PDBaseData, e.originalValue, e.value, e.record.data);
            }
        };
 
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HidGridDate7" runat="server" />
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server">
            <Items>
                <ext:Panel runat="server" Layout="AnchorLayout" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Text=" " OnDirectClick="btnAdd_Click" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:GridPanel
                            ColumnLines="true"
                            ID="GridPanel1"
                            runat="server"
                            Title="基本支出—人员经费预算表—工资福利支出"
                            Icon="ApplicationViewColumns"
                            Layout="Column" Collapsible="true"
                            Width="800px" Height="200px"
                            AutoWidth="true"
                            Border="false">

                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PSID" Type="int" />
                                                <ext:ModelField Name="PSName" Type="String" />
                                                <ext:ModelField Name="PDBaseData" Type="float" />
                                                <ext:ModelField Name="rjs1" Type="String" />
                                                <ext:ModelField Name="rjs2" Type="String" />
                                                <ext:ModelField Name="rjs3" Type="String" />
                                                <ext:ModelField Name="rjs4" Type="String" />
                                                <ext:ModelField Name="rjs5" Type="String" />
                                                <ext:ModelField Name="rjs6" Type="String" />
                                                <ext:ModelField Name="rjs7" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>

                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ID="Column1" runat="server" Align="Center" Text="单位名称科目" DataIndex="PSName" />
                                    <ext:Column ID="Column2" runat="server" Align="Center" Text="工资福利支出">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn1" runat="server" Align="Center" Text="小计" DataIndex="rjs1"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn2" runat="server" Align="Center" Text="基本工资" DataIndex="rjs2"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn3" runat="server" Align="Center" Text="津贴补贴" DataIndex="rjs3"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="奖金" DataIndex="rjs4"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="绩效工资" DataIndex="rjs5"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn6" runat="server" Align="Center" Text="社会保障缴费" DataIndex="rjs6"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn7" runat="server" Align="Center" Text="其他" DataIndex="rjs7"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                    <%-- <ext:Column ID="Column3" runat="server" Align="Center" Text="下年度">
                        <Columns>
                            <ext:SummaryColumn ID="Column4" runat="server" Text="测算数" Align="Center" Width="150" DataIndex="PDBaseData">
                                <Editor>
                                    <ext:NumberField ID="NumberField1" runat="server" />
                                </Editor>
                            </ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="人数" Width="150" DataIndex="rs2"></ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="人均数（万元）" Width="150" DataIndex="rjs2"></ext:SummaryColumn>
                        </Columns>
                    </ext:Column>--%>
                                </Columns>

                            </ColumnModel>
                            <%--    <SelectionModel>
                                <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                    <SelectedCell ColIndex="4"></SelectedCell>
                                </ext:CellSelectionModel>
                            </SelectionModel>--%>
                            <%--    <Plugins>
                                <ext:CellEditing ID="CellEditing1" runat="server">
                                    <Listeners>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>--%>
                        </ext:GridPanel>



                    </Items>



                </ext:Panel>

                <ext:Panel ID="Panel1" runat="server" Layout="AnchorLayout" AutoScroll="true">
                     <TopBar>
                        <ext:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <ext:Button ID="Button2" runat="server" Text=" " OnDirectClick="btnAdd_Click" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:GridPanel
                            ColumnLines="true"
                            ID="GridPanel6"
                            runat="server"
                            Title="基本支出—人员经费预算表—对个人和家庭的补助支出"
                            Icon="ApplicationViewColumns"
                            Layout="Column" Collapsible="true"
                            AutoScroll="true"
                            Width="1000px" Height="220px"
                            AutoWidth="true"
                            Border="false">

                            <Store>
                                <ext:Store ID="Store2" runat="server">
                                    <Model>
                                        <ext:Model ID="Model6" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PSID" Type="int" />
                                                <ext:ModelField Name="PSName" Type="String" />
                                                <ext:ModelField Name="PDBaseData" Type="float" />
                                                <ext:ModelField Name="rjs1" Type="String" />
                                                <ext:ModelField Name="rjs2" Type="String" />
                                                <ext:ModelField Name="rjs3" Type="String" />
                                                <ext:ModelField Name="rjs4" Type="String" />
                                                <ext:ModelField Name="rjs5" Type="String" />
                                                <ext:ModelField Name="rjs6" Type="String" />
                                                <ext:ModelField Name="rjs7" Type="String" />
                                                <ext:ModelField Name="rjs8" Type="String" />
                                                <ext:ModelField Name="rjs9" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>

                            <ColumnModel ID="ColumnModel6" runat="server">
                                <Columns>
                                    <ext:Column ID="Column17" runat="server" Align="Center" Text="单位名称(科目)" DataIndex="PSName" />
                                    <ext:Column ID="Column18" runat="server" Align="Center" Text="对个人和家庭的补助支出">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn55" runat="server" Align="Center" Text="合计" DataIndex="rjs1"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn56" runat="server" Align="Center" Text="离休费" DataIndex="rjs66">
                                                <Columns>
                                                    <ext:SummaryColumn ID="SummaryColumn57" runat="server" Align="Center" Text="小计" DataIndex="rjs2"></ext:SummaryColumn>
                                                    <ext:SummaryColumn ID="SummaryColumn58" runat="server" Align="Center" Text="个人部分" DataIndex="rjs3"></ext:SummaryColumn>
                                                    <ext:SummaryColumn ID="SummaryColumn59" runat="server" Align="Center" Text="共用部分" DataIndex="rjs4"></ext:SummaryColumn>
                                                </Columns>
                                            </ext:SummaryColumn>

                                            <ext:SummaryColumn ID="SummaryColumn60" runat="server" Align="Center" Text="退休费" DataIndex="rjs66">
                                                <Columns>
                                                    <ext:SummaryColumn ID="SummaryColumn61" runat="server" Align="Center" Text="小计" DataIndex="rjs5"></ext:SummaryColumn>
                                                    <ext:SummaryColumn ID="SummaryColumn62" runat="server" Align="Center" Text="个人部分" DataIndex="rjs6"></ext:SummaryColumn>
                                                    <ext:SummaryColumn ID="SummaryColumn63" runat="server" Align="Center" Text="共用部分" DataIndex="rjs7"></ext:SummaryColumn>
                                                </Columns>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn64" runat="server" Align="Center" Text="住房公积金" DataIndex="rjs8"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn65" runat="server" Align="Center" Text="其他" DataIndex="rjs9"></ext:SummaryColumn>

                                        </Columns>
                                    </ext:Column>
                                    <%-- <ext:Column ID="Column3" runat="server" Align="Center" Text="下年度">
                        <Columns>
                            <ext:SummaryColumn ID="Column4" runat="server" Text="测算数" Align="Center" Width="150" DataIndex="PDBaseData">
                                <Editor>
                                    <ext:NumberField ID="NumberField1" runat="server" />
                                </Editor>
                            </ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="人数" Width="150" DataIndex="rs2"></ext:SummaryColumn>
                            <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="人均数（万元）" Width="150" DataIndex="rjs2"></ext:SummaryColumn>
                        </Columns>
                    </ext:Column>--%>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                    <SelectedCell ColIndex="4"></SelectedCell>
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing ID="CellEditing1" runat="server">
                                    <Listeners>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>


                    </Items>


                </ext:Panel>

                <ext:Panel ID="Panel2" runat="server" Layout="AnchorLayout" AutoScroll="true">

                     <TopBar>
                        <ext:Toolbar ID="Toolbar3" runat="server">
                            <Items>
                                <ext:Button ID="Button3" runat="server" Text=" " OnDirectClick="btnAdd_Click" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:GridPanel
                            ColumnLines="true"
                            ID="GridPanel4"
                            runat="server"
                            Title="基本支出—人员经费预算表—日常公用支出预算表"
                            Icon="ApplicationViewColumns"
                            Layout="Column" Collapsible="true"
                            AutoScroll="true"
                            Width="2000px" Height="190px"
                            AutoWidth="true"
                            Border="false">

                            <Store>
                                <ext:Store ID="Store3" runat="server">
                                    <Model>
                                        <ext:Model ID="Model4" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PSID" Type="int" />
                                                <ext:ModelField Name="PSName" Type="String" />
                                                <ext:ModelField Name="PDBaseData" Type="float" />
                                                <ext:ModelField Name="rjs1" Type="String" />
                                                <ext:ModelField Name="rjs2" Type="String" />
                                                <ext:ModelField Name="rjs3" Type="String" />
                                                <ext:ModelField Name="rjs4" Type="String" />
                                                <ext:ModelField Name="rjs5" Type="String" />
                                                <ext:ModelField Name="rjs6" Type="String" />
                                                <ext:ModelField Name="rjs7" Type="String" />
                                                <ext:ModelField Name="rjs8" Type="String" />
                                                <ext:ModelField Name="rjs9" Type="String" />
                                                <ext:ModelField Name="rjs10" Type="String" />
                                                <ext:ModelField Name="rjs11" Type="String" />
                                                <ext:ModelField Name="rjs12" Type="String" />
                                                <ext:ModelField Name="rjs13" Type="String" />
                                                <ext:ModelField Name="rjs14" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>

                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:Column ID="Column7" runat="server" Align="Center" Text="单位名称(科目)" DataIndex="PSName" />
                                    <ext:Column ID="Column8" runat="server" Align="Center" Text="合计" DataIndex="PSName" />
                                    <ext:Column ID="Column9" runat="server" Align="Center" Text="商品和服务支出">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn26" runat="server" Align="Center" Text="小计" DataIndex="rjs1"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn27" runat="server" Align="Center" Text="办公费" DataIndex="rjs2"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn28" runat="server" Align="Center" Text="水电费" DataIndex="rjs3"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn29" runat="server" Align="Center" Text="邮电费" DataIndex="rjs4"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn30" runat="server" Align="Center" Text="公务用车运行费" DataIndex="rjs5"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn31" runat="server" Align="Center" Text="差旅费" DataIndex="rjs6"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn32" runat="server" Align="Center" Text="维修费" DataIndex="rjs7"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn33" runat="server" Align="Center" Text="会议费" DataIndex="rjs8"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn34" runat="server" Align="Center" Text="培训费" DataIndex="rjs9"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn35" runat="server" Align="Center" Text="公务接待费" DataIndex="rjs10"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn36" runat="server" Align="Center" Text="出国费" DataIndex="rjs11"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn37" runat="server" Align="Center" Text="工会会费" DataIndex="rjs12"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn38" runat="server" Align="Center" Text="福利费" DataIndex="rjs13"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn39" runat="server" Align="Center" Text="其他" DataIndex="rjs14"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column13" runat="server" Flex="1" Align="Center" Text="资本性支出">
                                        <Columns>
                                            <ext:SummaryColumn ID="Column41" runat="server" Text="测算数" Align="Center" DataIndex="PDBaseData">
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn42" runat="server" Align="Center" Text="小计" DataIndex="rs2"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn51" runat="server" Align="Center" Text="办公设备购置费" DataIndex="rjs2"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn40" runat="server" Align="Center" Text="其他" DataIndex="rjs2"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel ID="CellSelectionModel3" runat="server">
                                    <SelectedCell ColIndex="4"></SelectedCell>
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing ID="CellEditing3" runat="server">
                                    <Listeners>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                    </Items>

                </ext:Panel>

                <ext:Panel ID="Panel3" runat="server" Layout="AnchorLayout" AutoScroll="true">

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="Button1" runat="server" Text=" " OnDirectClick="btnAdd4_Click" />
                                <%--onClientClick="getGridSevenDate()"--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        <ext:GridPanel
                            ColumnLines="true"
                            ID="GridPanel7"
                            runat="server"
                            Title="项目支出预算表"
                            Icon="ApplicationViewColumns"
                            AutoScroll="true"
                            Layout="Column" Collapsible="true"
                            AutoWidth="true"
                            Width="1600px"
                            Height="400px"
                            Border="false">

                            <Store>
                                <ext:Store ID="Store4" runat="server">
                                    <Model>
                                        <ext:Model ID="Model7" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PPID" Type="int" />
                                                <ext:ModelField Name="PayPrjName" Type="String" />
                                                <ext:ModelField Name="PDBaseData" Type="float" />
                                                <ext:ModelField Name="aaaa" Type="String" />
                                                <ext:ModelField Name="rjs1" Type="String" />
                                                <ext:ModelField Name="rjs2" Type="String" />
                                                <ext:ModelField Name="rjs3" Type="String" />
                                                <ext:ModelField Name="rjs4" Type="String" />
                                                <ext:ModelField Name="rjs5" Type="String" />
                                                <ext:ModelField Name="rjs6" Type="String" />
                                                <ext:ModelField Name="rjs7" Type="String" />
                                                <ext:ModelField Name="rjs8" Type="String" />
                                                <ext:ModelField Name="rjs9" Type="String" />
                                                <ext:ModelField Name="rjs10" Type="String" />
                                                <ext:ModelField Name="rjs11" Type="String" />
                                                <ext:ModelField Name="rjs12" Type="String" />
                                                <ext:ModelField Name="rjs13" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>

                            <ColumnModel ID="ColumnModel7" runat="server">
                                <Columns>
                                    <%-- <ext:Column ID="Column15" runat="server" Align="Center" Text="项目名称" DataIndex="PSName" />--%>
                                    <ext:ComponentColumn ID="ComponentColumn1"
                                        runat="server"
                                        Editor="true" DataIndex="aaaa"
                                        Text="项目名称">
                                        <Component>
                                            <ext:ComboBox ID="ComboBox1" runat="server" DisplayField="PayPrjName">
                                                <Store>
                                                    <ext:Store ID="cmbName" runat="server">
                                                        <Model>
                                                            <ext:Model runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="PayPrjName" Type="String">
                                                                    </ext:ModelField>
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
                                        </Component>
                                    </ext:ComponentColumn>

                                    <ext:ComponentColumn ID="ComponentColumn2"
                                        runat="server"
                                        Editor="true"
                                        OverOnly="true"
                                        DataIndex="PSName"
                                        Text="项目编码">
                                        <Component>
                                            <ext:TextField ID="TextField1" runat="server" />
                                        </Component>
                                    </ext:ComponentColumn>


                                    <ext:SummaryColumn ID="Column4" runat="server" Text="合计" Align="Center" Width="150" DataIndex="PDBaseData">
                                        <Editor>
                                            <ext:NumberField ID="NumberField1" runat="server" />
                                        </Editor>
                                    </ext:SummaryColumn>
                                    <%--<ext:ComponentColumn ID="ComponentColumn3"
                                        runat="server"
                                        Editor="true"
                                        OverOnly="true"
                                        DataIndex="rjs1"
                                        Text="合计">
                                        <Component>
                                            <ext:TextField ID="TextField2" runat="server" />
                                        </Component>
                                    </ext:ComponentColumn>--%>
                                    <ext:Column ID="Column20" runat="server" Align="Center" Text="按项目性质分类">
                                        <Columns>

                                            <ext:ComponentColumn ID="ComponentColumn4"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs2"
                                                Text="常年性项目">
                                                <Component>
                                                    <ext:TextField ID="TextField3" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn5"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs3"
                                                Text="延续性项目">
                                                <Component>
                                                    <ext:TextField ID="TextField4" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn6"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs4"
                                                Text="一次性项目">
                                                <Component>
                                                    <ext:TextField ID="TextField5" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column21" runat="server" Align="Center" Text="按经济科目分类">
                                        <Columns>

                                            <ext:ComponentColumn ID="ComponentColumn7"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs5"
                                                Text="工资福利性支出">
                                                <Component>
                                                    <ext:TextField ID="TextField6" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn8"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs6"
                                                Text="商品和服务支出">
                                                <Component>
                                                    <ext:TextField ID="TextField7" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn9"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs7"
                                                Text="对个人和家庭的补助支出">
                                                <Component>
                                                    <ext:TextField ID="TextField8" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn10"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs8"
                                                Text="对企事业单位的补贴">
                                                <Component>
                                                    <ext:TextField ID="TextField9" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn11"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs9"
                                                Text="基本建设支出">
                                                <Component>
                                                    <ext:TextField ID="TextField10" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn12"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs10"
                                                Text="其他资本性支出">
                                                <Component>
                                                    <ext:TextField ID="TextField11" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn15"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs11"
                                                Text="其他支出">
                                                <Component>
                                                    <ext:TextField ID="TextField14" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>
                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column22" runat="server" Align="Center" Text="按使用方式分类">
                                        <Columns>

                                            <ext:ComponentColumn ID="ComponentColumn13"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs12"
                                                Text="内部开支">
                                                <Component>
                                                    <ext:TextField ID="TextField12" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>

                                            <ext:ComponentColumn ID="ComponentColumn14"
                                                runat="server"
                                                Editor="true"
                                                OverOnly="true"
                                                DataIndex="rjs13"
                                                Text="外部划拨">
                                                <Component>
                                                    <ext:TextField ID="TextField13" runat="server" />
                                                </Component>
                                            </ext:ComponentColumn>


                                        </Columns>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel ID="CellSelectionModel5" runat="server">
                                    <SelectedCell ColIndex="4"></SelectedCell>
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing ID="CellEditing2" runat="server">
                                    <Listeners>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

