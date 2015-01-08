﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearOutlyAnaly.aspx.cs" Inherits="WebPage_OptAnaly_YearOutlyAnaly" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>年度支出分析</title>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        var CountrySelector = {
            add: function () {
                //source = source || (App.GridPanel2 && App.GridPanel3 && App.GridPanel4 && App.GridPanel5 && App.GridPanel6);
                var allselect2 = "";
                var allselect3 = "";
                var allselect4 = "";
                var allselect5 = "";
                var allselect6 = "";
                var allselect = "";
                source = App.GridPanel4;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    for (var k = 0; k < records.length; k++) {
                        if (k == records.length - 1) {
                            allselect2 += records[k].data.PIID
                        }
                        else {
                            allselect2 += records[k].data.PIID + ",";
                        }
                    }
                }
                source = App.GridPanel2;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    for (var k = 0; k < records.length; k++) {
                        if (k == records.length - 1) {
                            allselect4 += records[k].data.PIID
                        }
                        else {
                            allselect4 += records[k].data.PIID + ",";
                        }
                    }
                }
                source = App.GridPanel3;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    for (var k = 0; k < records.length; k++) {
                        if (k == records.length - 1) {
                            allselect5 += records[k].data.PIID
                        }
                        else {
                            allselect5 += records[k].data.PIID + ",";
                        }
                    }
                }
                source = App.GridPanel6;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    for (var k = 0; k < records.length; k++) {
                        if (k == records.length - 1) {
                            allselect6 += records[k].data.PIID
                        }
                        else {
                            allselect6 += records[k].data.PIID + ",";
                        }
                    }
                }
                if (allselect4 != "" && allselect5 != "") {
                    allselect2 += "," + allselect4 + "," + allselect5 + "," + allselect6;
                }
                if (allselect4 == "" && allselect5 != "") {
                    allselect2 += "," + allselect5 + "," + allselect6;
                }
                if (allselect4 != "" && allselect5 == "") {
                    allselect2 += "," + allselect4 + "," + allselect6;
                }
                if (allselect4 == "" && allselect5 == "") {
                    allselect2 += "," + allselect6;
                }
                source = App.GridPanel5;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    for (var l = 0; l < records.length; l++) {
                        if (l == records.length - 1) {
                            allselect3 += records[l].data.PIID
                        }
                        else {
                            allselect3 += records[l].data.PIID + ",";
                        }
                    }
                }
                $("#hid2").val(allselect2);
                $("#hid3").val(allselect3);
                Ext.Msg.alert("操作提示", "保存选项成功，请点击“搜索”按钮进行查询操作!");
            }
        }

        var selecttype = function (sender, command, record) {
            App.direct.GetSelectType(sender.value);
        }
   
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="HidSelect"></asp:HiddenField>
        <asp:HiddenField ID="hid1" runat="server" />
        <asp:HiddenField ID="hid2" runat="server" />
        <asp:HiddenField ID="hid3" runat="server" />

        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Panel ID="Panel1" runat="server" Title="自选分析-选择年度数据" Layout="HBoxLayout" AnchorVertical="10%">
            <Items>
                <ext:ComboBox ID="cboStartYear" runat="server" LabelWidth="100" FieldLabel="选择日期　　年" Width="180px" Margin="10">
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

                <%--                  <ext:ComboBox ID="cboStartMon" runat="server" LabelWidth="30" FieldLabel="月:" Width="100px" Margin="10">
                            <Items>
                                <ext:ListItem Text="全年" Value="0" />
                                <ext:ListItem Text="1" Value="1" />
                                <ext:ListItem Text="2" Value="2" />
                                <ext:ListItem Text="3" Value="3" />
                                <ext:ListItem Text="4" Value="4" />
                                <ext:ListItem Text="5" Value="5" />
                                <ext:ListItem Text="6" Value="6" />
                                <ext:ListItem Text="7" Value="7" />
                                <ext:ListItem Text="8" Value="8" />
                                <ext:ListItem Text="9" Value="9" />
                                <ext:ListItem Text="10" Value="10" />
                                <ext:ListItem Text="11" Value="11" />
                                <ext:ListItem Text="12" Value="12" />

                            </Items>
                            <SelectedItems>
                                <ext:ListItem Value="0"></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>--%>

                <ext:ComboBox ID="cboType" runat="server" LabelWidth="60" FieldLabel="经费类型" Width="150px" Margin="10">
                    <%--<Items>
                        <ext:ListItem Text="所有" Value="1" />
                        <ext:ListItem Text="区级" Value="2" />
                        <ext:ListItem Text="零户" Value="3" />
                    </Items>--%>
                    <Listeners>
                        <Select Fn="selecttype"> </Select>
                    </Listeners>
                    <SelectedItems>
                        <ext:ListItem Value="1"></ext:ListItem>
                    </SelectedItems>
                </ext:ComboBox>
                <ext:Toolbar ID="Toolbar1" runat="server" PaddingSpec="3 0 0 0" BaseCls="background:Transparent ">
                    <Items>

                        <ext:Panel ID="Panel4" runat="server" Border="false">
                            <Items>
                                <ext:Button ID="btnSearch" runat="server" Text="搜索" Icon="ArrowRefresh" Margin="10" OnClientClick="return chkTime()" OnDirectClick="btnSearch_DirectClick">
                                </ext:Button>
                                <%--<ext:Label ID="Label1" runat="server" Text="请先点击保存选项，再搜索"></ext:Label>--%>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>
                <ext:Label ID="lblClick" runat="server" Text="请先点击保存选择项，再搜索" Margin="10"></ext:Label>
                <ext:Button ID="btnExpand" runat="server" Text="展开选择项" Icon="VectorKey" Margin="10" OnDirectClick="btnExpand_DirectClick"><%-- OnDirectClick="btnExpand_DirectClick"--%>
                </ext:Button>
            </Items>
        </ext:Panel>

        <ext:Panel ID="pl1"
            Border="false"
            runat="server"
            AnchorVertical="30%">
            <Items>
                <%-- Margins="10 300 10 300"--%>
                <ext:FieldSet ID="FieldSet1"
                    runat="server"
                    Title="展开查询内容"
                    Collapsible="true"
                    DefaultAnchor="100%"
                    PaddingSpec="10 10 10 10"
                    Layout="AnchorLayout">
                    <%--                           <Defaults>
                                <ext:Parameter Name="labelWidth" Value="0" Mode="Raw" />
                            </Defaults>
                            <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Middle" Pack="Start" />
                            </LayoutConfig>--%>
                    <Items>

                        <ext:Panel ID="Panel2" runat="server" Layout="ColumnLayout" AnchorVertical="100%" BodyStyle="background-color:transparent">
                            <Items>
                                <ext:GridPanel
                                    ID="GridPanel4"
                                    runat="server"
                                    Title="财政拨款[基本支出]"
                                    Margins="0 5 0 0"
                                    PaddingSpec="0 5 0 0"
                                    Collapsible="true"
                                    Width="200" Height="265"
                                    BorderSpec="1 1 0 1"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store4" runat="server" PageSize="17">
                                            <Model>
                                                <ext:Model ID="Model4" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                                        <ext:ModelField Name="PIID" Type="string" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel4" runat="server">
                                        <Columns>
                                            <%--<ext:Column ID="Column13"
                                                        runat="server"
                                                        DataIndex="PIEcoSubCoding"
                                                        Text="全选"
                                                        Resizable="false"
                                                        MenuDisabled="true"
                                                        Flex="1" />--%>
                                            <ext:Column ID="Column10"
                                                Text="全选"
                                                runat="server"
                                                DataIndex="PIEcoSubName"
                                                Resizable="false"
                                                MenuDisabled="true"
                                                Flex="1" />
                                        </Columns>

                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel3" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                    <Features>
                                        <ext:GridFilters ID="GridFilters3" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="PIID" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Features>
                                </ext:GridPanel>

                                <ext:GridPanel
                                    ID="GridPanel2"
                                    runat="server"
                                    Title="财政拨款[项目支出]"
                                    Margins="0 5 0 0"
                                    PaddingSpec="0 5 0 0"
                                    Collapsible="true"
                                    Width="200" Height="265"
                                    BorderSpec="1 1 0 1"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store2" runat="server" PageSize="17">
                                            <Model>
                                                <ext:Model ID="Model2" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                                        <ext:ModelField Name="PIID" Type="string" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <%--<ext:Column ID="Column13"
                                                        runat="server"
                                                        DataIndex="PIEcoSubCoding"
                                                        Text="全选"
                                                        Resizable="false"
                                                        MenuDisabled="true"
                                                        Flex="1" />--%>
                                            <ext:Column ID="Column9"
                                                Text="全选"
                                                runat="server"
                                                DataIndex="PIEcoSubName"
                                                Resizable="false"
                                                MenuDisabled="true"
                                                Flex="1" />
                                        </Columns>

                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                    <Features>
                                        <ext:GridFilters ID="GridFilters1" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="PIID" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Features>
                                </ext:GridPanel>

                                <ext:GridPanel
                                    ID="GridPanel3"
                                    runat="server"
                                    Title="其他资金[基本支出]"
                                    Margins="0 5 0 0"
                                    PaddingSpec="0 5 0 0"
                                    Collapsible="true"
                                    Width="200" Height="265"
                                    BorderSpec="1 1 0 1"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store3" runat="server" PageSize="17">
                                            <Model>
                                                <ext:Model ID="Model3" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                                        <ext:ModelField Name="PIID" Type="string" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel3" runat="server">
                                        <Columns>
                                            <%--<ext:Column ID="Column13"
                                                        runat="server"
                                                        DataIndex="PIEcoSubCoding"
                                                        Text="全选"
                                                        Resizable="false"
                                                        MenuDisabled="true"
                                                        Flex="1" />--%>
                                            <ext:Column ID="Column12"
                                                Text="全选"
                                                runat="server"
                                                DataIndex="PIEcoSubName"
                                                Resizable="false"
                                                MenuDisabled="true"
                                                Flex="1" />
                                        </Columns>

                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                    <Features>
                                        <ext:GridFilters ID="GridFilters2" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="PIID" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Features>
                                </ext:GridPanel>

                                <ext:GridPanel
                                    ID="GridPanel6"
                                    runat="server"
                                    Title="其他资金[项目支出]"
                                    Margins="0 5 0 0"
                                    PaddingSpec="0 5 0 0"
                                    Collapsible="true"
                                    Width="200" Height="265"
                                    BorderSpec="1 1 0 1"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store6" runat="server" PageSize="17">
                                            <Model>
                                                <ext:Model ID="Model6" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                                        <ext:ModelField Name="PIID" Type="string" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel6" runat="server">
                                        <Columns>
                                            <%--<ext:Column ID="Column13"
                                                        runat="server"
                                                        DataIndex="PIEcoSubCoding"
                                                        Text="全选"
                                                        Resizable="false"
                                                        MenuDisabled="true"
                                                        Flex="1" />--%>
                                            <ext:Column ID="Column15"
                                                Text="全选"
                                                runat="server"
                                                DataIndex="PIEcoSubName"
                                                Resizable="false"
                                                MenuDisabled="true"
                                                Flex="1" />
                                        </Columns>

                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel5" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                    <Features>
                                        <ext:GridFilters ID="GridFilters5" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="PIID" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Features>
                                </ext:GridPanel>

                                <ext:GridPanel
                                    ID="GridPanel5"
                                    runat="server"
                                    Title=""
                                    Margins="0 5 0 0"
                                    PaddingSpec="0 5 0 0"
                                    Collapsible="true"
                                    Width="200" Height="265"
                                    BorderSpec="1 1 0 1"
                                    AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store5" runat="server" PageSize="17">
                                            <Model>
                                                <ext:Model ID="Model5" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                                        <ext:ModelField Name="PIID" Type="string" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel5" runat="server">
                                        <Columns>
                                            <%--<ext:Column ID="Column14"
                                                        runat="server"
                                                        Text="全选"
                                                        DataIndex="PIEcoSubCoding"
                                                        Resizable="false"
                                                        MenuDisabled="true"
                                                        Flex="1" />--%>
                                            <ext:Column ID="Column11"
                                                Text="全选"
                                                runat="server"
                                                DataIndex="PIEcoSubName"
                                                Resizable="false"
                                                MenuDisabled="true"
                                                Flex="1" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel4" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                    <Features>
                                        <ext:GridFilters ID="GridFilters4" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="PIID" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Features>
                                </ext:GridPanel>

                            </Items>
                            <DockedItems>
                                <ext:Panel ID="Panel3" runat="server" Border="false" BodyStyle="background-color: transparent;" BodyPadding="5" Dock="Bottom">
                                    <Items>
                                        <ext:Button ID="Button1" runat="server" Icon="ChartLineAdd" Text="保存选择项">
                                            <Listeners>
                                                <Click Handler="CountrySelector.add();" />
                                            </Listeners>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1" runat="server" Html="保存选择项" />                                               
                                            </ToolTips>
                                       </ext:Button>
                                        <%--<ext:Button ID="Button2" runat="server" Icon="ChartLineAdd" Text="保存选择项" PaddingSpec="3 0 0 0" OnDirectClick="Button2_DirectClick">
                                        </ext:Button>--%>
                                    </Items>
                                </ext:Panel>
                            </DockedItems>
                        </ext:Panel>
                    </Items>
                </ext:FieldSet>
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
            Border="false"
            AnchorVertical="60%">

            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Model>
                        <ext:Model ID="Model1" runat="server" Name="aaaa">
                            <Fields>
                                <ext:ModelField Name="KMName" Type="String" />
                                <ext:ModelField Name="YSMon" Type="String" />
                                <ext:ModelField Name="JSMon" Type="String" />
                                <ext:ModelField Name="HSBQMon" Type="String" />
                                <ext:ModelField Name="HSBQMonQJ" Type="String" />
                                <ext:ModelField Name="HSBQMonLH" Type="String" />
                                <ext:ModelField Name="HSTQMon" Type="String" />
                                <ext:ModelField Name="YYSBit" Type="String" />
                                <ext:ModelField Name="YJSBit" Type="String" />
                                <ext:ModelField Name="RJXS" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>

            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column2" runat="server" Align="Center" Text="科目名称" Flex="1" DataIndex="KMName" />
                    <ext:Column ID="Column3" runat="server" Align="Right" Text="预算金额（万元）" Flex="1" DataIndex="YSMon" />
                    <ext:Column ID="Column1" runat="server" Align="Right" Text="决算金额（元）" Flex="1" DataIndex="JSMon" />
                    <ext:Column ID="Column5" runat="server" Align="Right" Text="核算本期数（元）" Flex="1" DataIndex="HSBQMon"></ext:Column>
                    <ext:Column ID="Column7" runat="server" Align="Right" Text="核算本期数(区级)（元）" Flex="1" DataIndex="HSBQMonQJ" Visible="false" />
                    <ext:Column ID="Column8" runat="server" Align="Right" Text="核算本期数（零户）（元）" Flex="1" DataIndex="HSBQMonLH"  Visible="false"/>
                    <ext:Column ID="Column14" runat="server" Align="Right" Text="核算同期数（元）" Flex="1" DataIndex="HSTQMon"></ext:Column>
                    <ext:Column ID="Column6" runat="server" Align="Right" Text="与预算比" Flex="1" DataIndex="YYSBit" />
                    <ext:Column ID="Column4" runat="server" Align="Right" Text="与决算比" Flex="1" DataIndex="YJSBit" />
                    <ext:Column ID="Column13" runat="server" Align="Center" Text="人均系数（元）" Flex="1" DataIndex="RJXS" />
                </Columns>
            </ColumnModel>

        </ext:GridPanel>

        <%--<ext:Window ID="WinSave" runat="server"
            Title="保存文件"
            Width="400"
            Height="130"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="FitLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:FormPanel runat="server" ID="resetform">
                    <%--<Items>
                        <ext:TextField ID="AdName" runat="server" Name="AdName" FieldLabel="部门名称" AllowBlank="false" LabelWidth="80" Width="300" MarginSpec="10 0 0 30">
                        </ext:TextField>
                        <ext:TextField ID="AdDes" runat="server" Name="AdDes" FieldLabel="部门备注" LabelWidth="80" AllowBlank="true" Width="300" MarginSpec="10 0 0 30"></ext:TextField>
                    </Items>--%>

                    <%--<DockedItems>
                        <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnWinAdd" MarginSpec="0 0 0 0" runat="server" Text="保存" Icon="Add" >
                                    <Listeners>
                                        <Click Handler="
                            if (!#{AdName}.validate() ) {
                                Ext.Msg.alert('提示','部门是必填项!'); 
                                            return false; 
                            }" />
                                    </Listeners> 
                                </ext:Button>
                                <ext:Button ID="btnWinCancel" runat="server" Text="取消" Icon="ApplicationEdit" ></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:FormPanel>
            </Items>
        </ext:Window>--%>

    </form>
    <script type="text/javascript">

        function changeTdCss() {
            $("#gridview-1036 table tr:last td:first").css("color", "#6CCEA5").css("font-size", "120%");
        }

        $(function () {
            setTimeout(changeTdCss,2000);
        });
    </script>
</body>
</html>
