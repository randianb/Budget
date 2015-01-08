<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonPayPlanGenerate.aspx.cs" Inherits="BudgetPage_mainPages_MonPayPlanGenerate" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加月度用款计划</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <link href="../ExtJs4.0/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="../ExtJs4.0/ext-all-debug.js" type="text/javascript"></script>
    <script src="../ExtJs4.0/locale/ext-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.min.js" type="text/javascript"></script>
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 160px;
            height: 55px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }

        .x-grid-body .x-grid-cell-Cost {
            background-color: #f1f2f4;
        }

        .x-grid-row-summary .x-grid-cell-Cost .x-grid-cell-inner {
            background-color: #e1e2e4;
        }

        .task .x-grid-cell-inner {
            padding-left: 15px;
        }

        .x-grid-row-summary .x-grid-cell-inner {
            font-weight: bold;
            font-size: 11px;
            background-color: #f1f2f4;
        }
    </style>
    <script type="text/javascript">

        var balance = function (records) {
            var i = 0,
                length = records.length,
                total = 0,
                record;

            for (i; i < length; ++i) {
                record = records[i];
                total += record.get('Balance') - record.get('PIEd');
            }
            return total;
        };
        var edit = function (editor, e) {
            /*
                "e" is an edit event with the following properties:

                    grid - The grid
                    record - The record that was edited
                    field - The field name that was edited
                    value - The value being set
                    originalValue - The original value for the field, before the edit.
                    row - The grid table row
                    column - The grid Column defining the column that was edited.
                    rowIdx - The row index that was edited
                    colIdx - The column index that was edited
            */

            // Call DirectMethod
            if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) { 
              CompanyX.Edit(e.record.data.FullName, e.record.data.CPID, e.record.data.PIID, e.originalValue, e.value, e.record.data.Balance, e.record.data.PIEcoSubName);
            }
        };

        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return Ext.String.format(template, (value > 0) ? "green" : "red", value);
        };
        var total ="";
        function renderTitle(value, p, record) {
            var rtvalue = 0;
            if (value == "商品和服务支出") {
                if ($("#HidLS").val() == "flag") {
                    rtvalue = record.data.Mon;
                }
                else {
                    rtvalue = $("#HidLS").val();
                }
            }
            else if (value == "其他资本性支出") {
                if ($("#HidLQ").val() == "flag") {
                    rtvalue = record.data.Mon;
                } else {
                    rtvalue = $("#HidLQ").val();
                }
            }
            else if (value == "工资福利支出") {
                if ($("#HidLG").val() == "flag") {
                    rtvalue = record.data.Mon;
                } else {
                    rtvalue = $("#HidLG").val();
                }
            } else {
                if ($("#HidLD").val() == "flag") {
                    rtvalue = record.data.Mon;
                } else {
                    rtvalue = $("#HidLD").val();
                }
            } 
            return value ? Ext.String.format(value + "余额为" + rtvalue + "万元") : "没有数据！";
        }

        var Getttt= function () {
            var tt = "";
            tt = $("x-grid-group-title").attr("class").innerHTML;
            alert(tt);
        };
        
        //var monnum = 0;
        //function MonTotal(record) {
        //    var moncolls = record.data.Mon;
        //    monnum += parseFloat(moncolls);
        //}

        ////验证文本框
        //function msgTips(id, msg, guideInt) {
        //    layer.tips(msg, $(id), {
        //        guide: guideInt,
        //        time: 1000,
        //        closeBtn:[0, true],
        //        style: ['background-color:#FF0000; color:#fff', '#FF0000'],
        //        maxWidth: 240
        //    });
        //} 

        //function Tips() {
        //    var msg = "aaaaaaaaaaaaa"+$("#HidLS").val();
        //    msgTips($(".x-grid-group-title:first"),msg,0);
        //}

        //$(function() {
        //    setTimeout("Tips()", 5000);
        //    Getttt();
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HidLQ" runat="server" />
        <asp:HiddenField ID="HidLD" runat="server" />
        <asp:HiddenField ID="HidLG" runat="server" />
        <asp:HiddenField ID="HidLS" runat="server" />

         <asp:HiddenField ID="HiddenField1" runat="server" />
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="ViewPort1" runat="server" Layout="FitLayout">
            <Items>

                <ext:Hidden runat="server" ID="HidTotalq"></ext:Hidden>
                <ext:Hidden runat="server" ID="HidTotald"></ext:Hidden>
                <ext:Hidden runat="server" ID="HidTotalg"></ext:Hidden>
                <ext:Hidden runat="server" ID="HidTotals"></ext:Hidden>
                <ext:GridPanel  ID="gridpanel1" ColumnLines="true" runat="server" Layout="FitLayout" AutoScroll="true" Frame="true"
                    Collapsible="true"
                    AnimCollapse="false"
                    Icon="ApplicationViewColumns"
                    Title="添加月度用款计划">

                    <Store>

                        <ext:Store ID="MonPlanStore" runat="server" GroupField="FirstName">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="CPID" Type="int" />
                                        <ext:ModelField Name="PIID" Type="int" />
                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                        <ext:ModelField Name="FullName" Type="string" />
                                        <ext:ModelField Name="FirstName" Type="string" />
                                        <ext:ModelField Name="LastName" Type="string" />
                                        <ext:ModelField Name="Mon" Type="float" />
                                        <ext:ModelField Name="Balance" Type="float" />
                                        <ext:ModelField Name="PIEd" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <%-- <Loader runat="Server"  > 
                        <LoadMask Msg="Loading..." ShowMask="true" ></LoadMask>
                    </Loader>--%>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <%-- <ext:Column Sortable="true" ID="Column1" runat="server" Text="支出经济科目ID" Flex="1" DataIndex="PIID" />--%>
                            <ext:SummaryColumn ID="SummaryColumn1"
                                runat="server"
                                TdCls="task"
                                Text="经济科目"
                                Sortable="false"
                                DataIndex="FirstName"
                                Hideable="false"
                                Flex="1">
                                <Renderer Fn="renderTitle"></Renderer> 
                                <%-- <SummaryRenderer Handler="MonTotal(record);"></SummaryRenderer>--%>
                                <%-- <Renderer Handler="return value+'  总金额为  '+(record.data.Mon)+' 万元';" />
                                <SummaryRenderer Handler="return value+'  总金额为  '+(record.data.Mon)+' 万元';" />--%>
                                <%--  <Renderer Handler="if(value === '商品和服务支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotals').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '其他资本性支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotalq').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '工资福利支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotalg').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '对个人和家庭补助支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotald').val()})+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';};" /> 
                                <SummaryRenderer Handler="if(value === '商品和服务支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotals').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '其他资本性支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotalq').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '工资福利支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotalg').val())+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';}; if(value === '对个人和家庭补助支出'&& record.data.Mon >0){return value+'  总金额为  '+($('#HidTotald').val()})+' 万元';}; else{return value+'  总金额为  '+record.data.Mon+' 万元';};" /> --%>
                                <%--   <Renderer Handler="return  '(' + value +' 条科目)';" />
                                <SummaryRenderer Handler="return  '(' + value +' 条科目)';" />--%>
                            </ext:SummaryColumn>
                            <ext:Column Align="left" ID="clPIEcoSubName" runat="server" Text="经济科目" Flex="1" DataIndex="LastName" />
                            <ext:SummaryColumn Align="center" ID="clBAAMon" runat="server" Text="年度预算指标(万元)" Flex="1" DataIndex="Mon" Sortable="true" SummaryType="sum">
                                <%--<Renderer Fn="change" />--%>
                                <Renderer Handler="return value" />
                                <SummaryRenderer Handler="return value" />
                            </ext:SummaryColumn>
                            <ext:SummaryColumn Groupable="false" Align="center" ID="clBalance" runat="server" Text="余额(万元)" Flex="1" DataIndex="Balance" Sortable="false" SummaryType="sum" CustomSummaryType="balance">
                                <Renderer Fn="change" Handler="return Ext.util.Format.number((record.data.Balance*10000 - record.data.PIEd)/10000);" />
                                <SummaryRenderer Fn="Ext.util.Format.number" />
                                <%--<Renderer Handler="return value +' 万元';" />
                                <SummaryRenderer Handler="return value +' 万元';" />--%>
                            </ext:SummaryColumn>
                            <ext:SummaryColumn ID="clPIEd" runat="server" Text="申请经费(元)" Align="Center" Flex="1" DataIndex="PIEd" Sortable="true" SummaryType="Sum">
                                <Editor>
                                    <ext:NumberField ID="TFclPIEd" runat="server" />
                                </Editor>
                                <Renderer Handler="return value" />
                                <SummaryRenderer Handler="return value" />
                            </ext:SummaryColumn>

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
                    <View>
                        <ext:GridView ID="GridView1" runat="server" StripeRows="false" />
                    </View>
                    <Listeners>
                        <AfterRender Handler="#{GroupingSummary1}.toggleSummaryRow(!#{GroupingSummary1}.showSummaryRow);#{GroupingSummary1}.view.refresh(); " />
                    </Listeners>
                    <Features>
                        <ext:GroupingSummary
                            ID="GroupingSummary1"
                            runat="server"
                            ShowSummaryRow="true"
                            ShowGroupsText="{LastName}"
                            HideGroupedHeader="true"
                            EnableGroupingMenu="true">
                        </ext:GroupingSummary>
                    </Features>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="40">
                            <Items>
                                <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="请选择月份：" ColumnWidth="0.1"></ext:Label>
                                <ext:ComboBox ID="cmbmon" Editable="false" runat="server" OnDirectChange="cmbmon_DirectChange" ValueField="month" DisplayField="month">
                                    <Store>
                                        <ext:Store runat="server" ID="cmbmonstore">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="month"></ext:ModelField>
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
                                <ext:Panel runat="server" Border="false" BodyStyle="background:transparent">
                                    <Items>
                                        <ext:Button ID="btnsubmit" runat="server" Text="提交" OnDirectClick="btnsubmit_DirectClick"></ext:Button>
                                        <ext:Button ID="Button1" runat="server" Text="展开/关闭展开" ToolTip="展开所有行">
                                            <Listeners>
                                                <Click Handler="#{GroupingSummary1}.toggleSummaryRow(!#{GroupingSummary1}.showSummaryRow);#{GroupingSummary1}.view.refresh();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Label runat="server" Text="本月度剩余余额为：" MarginSpec="0 5 0 20"></ext:Label>
                                        <ext:Label ID="Incomebalance" Hidden="true" runat="server" Text="" EmptyText="0"></ext:Label>

                                    </Items>
                                </ext:Panel>

                            </Items>

                        </ext:Toolbar>
                    </TopBar>
                </ext:GridPanel>
                <ext:Hidden runat="server" ID="hidflag"></ext:Hidden>


            </Items>
        </ext:Viewport>




    </form>
</body>
</html>
<%--  GroupHeaderTplString="{LastName}: {LastName} ({rows.length} Item{[values.rows.length > 1 ? 's' : '']})"--%>