<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyEditList.aspx.cs" Inherits="WebPage_Policy_PolicyEditList" ValidateRequest="false" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        var gridCommand = function (sender, command, record) {
            if (command == "Publish") {
                Ext.Msg.confirm("提示", "确定修改当前状态？", function (btn) {
                    if (btn == "yes") {
                        App.direct.PublishPolicy(record.data.PLID);
                    }
                })
            }
            if (command == "Modify") {
                App.direct.ModifyPolicy(record.data.PLID);
            }
            if (command == "Delete") {
                Ext.Msg.confirm("提示", "确定删除？", function (btn) {
                    if (btn == "yes") {
                        App.direct.DelPolicy(record.data.PLID);
                    }
                })

            }
        }
        var prepare = function (grid, toolbar, rowIndex, record) {

            var firstButton = toolbar.items.get(0);

            if (record.data.PStatus == "已发布") {

                firstButton.setText("撤销发布");
            }
            else {
                firstButton.setText("发布");
            }
        };

    </script>

</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="fit">
            <Items>
                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server"
                    Title="政策指导编辑">
                    <Store>
                        <ext:Store ID="Store1" runat="server" PageSize="17">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="PLID" Type="int" />
                                        <ext:ModelField Name="PTitle" Type="string" />
                                        <%--<ext:ModelField Name="PContent" Type="string" />--%>
                                        <ext:ModelField Name="PTime" Type="date" />
                                        <ext:ModelField Name="PFrom" Type="string" />
                                        <ext:ModelField Name="POrder" Type="int" />
                                        <ext:ModelField Name="PType" Type="string" />
                                        <ext:ModelField Name="PStatus" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <%--<ext:Column ID="Column3" runat="server" Text="内容" Flex="1" DataIndex="PContent" />--%>
                            <ext:Column Sortable="true" Align="Center" ID="Column1" runat="server" Text="政策ID" Flex="1" DataIndex="PLID" />
                            <ext:Column Sortable="true" Align="Center" ID="Column2" runat="server" Text="标题" Flex="1" DataIndex="PTitle" />
                            <ext:DateColumn Sortable="true" Align="Center" ID="Column4" runat="server" Text="时间" Flex="1" DataIndex="PTime" Format="yyyy-MM-dd HH:mm:ss" />
                            <ext:Column Sortable="true" Align="Center" ID="Column5" runat="server" Text="来源" Flex="1" DataIndex="PFrom" />
                            <ext:Column Sortable="true" Align="Center" ID="Column6" runat="server" Text="排序" Flex="1" DataIndex="POrder" />
                            <ext:Column Sortable="true" Align="Center" ID="Column7" runat="server" Text="类型" Flex="1" DataIndex="PType" />
                            <ext:Column Sortable="true" Align="Center" ID="Column8" runat="server" Text="状态" Flex="1" DataIndex="PStatus" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Header="发布" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="Mail" CommandName="Publish" Text="发布"  />
                                </Commands>
                                <PrepareToolbar Fn="prepare" />
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn2" runat="server" Header="修改" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Modify" Text="修改" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn3" runat="server" Header="删除" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="Decline" CommandName="Delete" Text="删除" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd"
                                    Icon="ApplicationAdd"
                                    runat="server" Text="增加" OnDirectClick="btnAdd_DirectClick" />
                            </Items>
                        </ext:Toolbar>

                    </TopBar>
                     <DockedItems>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true" Dock="Bottom">
                        </ext:PagingToolbar>
                    </DockedItems>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>

        <ext:Window ID="WinEdit" runat="server"
            Width="600"
            Height="400"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="BorderLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:Panel runat="server" Header="false" Collapsible="true" Border="false" Region="West" Split="false" Width="300" MarginSpec="10 5 5 5" Margins='0 0 0 0' BaseCls=" background: white">
                    <Items>
                        <ext:TextField ID="TFID" Hidden="true" runat="server" />
                        <ext:TextField ID="TFPTitle" runat="server" Name="PTitle" FieldLabel="标题" MaxLength="100" AllowBlank="false" LabelWidth="50">
                        </ext:TextField>
                        <ext:DateField ID="TFPTime" runat="server" Name="PTime" FieldLabel="时间" LabelWidth="50" Note="">
                            <%--<Plugins>
                                <ext:InputMask ID="InputMask2" runat="server" Mask="yzzz/mn/dt ab:ce:fg">
                                    <MaskSymbols>
                                        <ext:MaskSymbol Name="d" Regex="[0123]" Placeholder="d" />
                                        <ext:MaskSymbol Name="t" Regex="[0-9]" Placeholder="d" />
                                        <ext:MaskSymbol Name="m" Regex="[01]" Placeholder="m" />
                                        <ext:MaskSymbol Name="n" Regex="[0-9]" Placeholder="m" />
                                        <ext:MaskSymbol Name="y" Regex="[12]" Placeholder="y" />
                                        <ext:MaskSymbol Name="z" Regex="[0-9]" Placeholder="y" />
                                        <ext:MaskSymbol Name="a" Regex="[0-2]" Placeholder="H" />
                                        <ext:MaskSymbol Name="b" Regex="[0-9]" Placeholder="H" />
                                        <ext:MaskSymbol Name="c" Regex="[0-5]" Placeholder="m" />
                                        <ext:MaskSymbol Name="e" Regex="[0-9]" Placeholder="m" />
                                        <ext:MaskSymbol Name="f" Regex="[0-5]" Placeholder="s" />
                                        <ext:MaskSymbol Name="g" Regex="[0-9]" Placeholder="s" />
                                    </MaskSymbols>
                                </ext:InputMask>
                            </Plugins>--%>
                        </ext:DateField>
                        <ext:TextField ID="TFPFrom" runat="server" Name="PFrom" FieldLabel="来源" LabelWidth="50" AllowBlank="false">
                        </ext:TextField>
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" Header="false" Collapsible="true" Border="false" Region="East" Split="false" Width="300" MarginSpec="10 5 5 5" Margins='0 0 0 0' BaseCls=" background: white">
                    <Items>
                        <ext:NumberField ID="TFPOrder" runat="server" Name="POrder" FieldLabel="排序" LabelWidth="50" AllowBlank="false" EmptyText="请填入数字">
                        </ext:NumberField>
                        <ext:ComboBox ID="TFcmb" runat="server" FieldLabel="类型" LabelWidth="50">
                            <Items>
                                <ext:ListItem Text="政策" Value="政策"></ext:ListItem>
                                <ext:ListItem Text="口径" Value="口径"></ext:ListItem>
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Index="0">
                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                    </Items>
                </ext:Panel>
                <ext:Panel
                    runat="server"
                    Region="South"
                    Border="true"
                    Header="false"
                    Height="280"
                    Width="600"
                    Layout="FitLayout">
                    <Items>
                        <ext:HtmlEditor ID="HEdit" runat="server" Text="" Height="220" Border="false" />
                    </Items>
                    <DockedItems>
                        <ext:Toolbar runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnMod" runat="server" Text="修改" Icon="ApplicationEdit">
                                    <Listeners>
                                        <Click Handler="
                            if (!#{TFPTitle}.validate() || !#{TFPFrom}.validate() ||!#{TFPOrder}.validate() ||!#{HEdit}.validate() ) {
                                Ext.Msg.alert('Error','验证有误，请核实所填项是否已填写完整!'); 
                                return false; 
                            }" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="BtnMod_DirectClick">
                                            <EventMask ShowMask="false" Msg="Verifying..." MinDelay="500" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btnConc" runat="server" Text="取消" Icon="ApplicationEdit" OnDirectClick="BtnCanc_DirectClick"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:Panel>
            </Items>
        </ext:Window>

        <ext:Window ID="Winadd" runat="server"
            Width="600"
            Height="450"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="BorderLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:FormPanel runat="server" ID="resetform">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" Header="false" Collapsible="true" Border="false" Region="West" Split="false" Width="300" MarginSpec="10 5 0 5" Margins='0 0 0 0' BaseCls=" background: white">
                            <Items>
                                <ext:TextField ID="ADID" Hidden="true" runat="server" />
                                <ext:TextField ID="ADPTitle" runat="server" Name="ADDPTitle" FieldLabel="标题" AllowBlank="false" LabelWidth="50">
                                </ext:TextField>
                                <ext:DateField ID="ADPTime" runat="server" Name="ADDPTime" FieldLabel="时间" LabelWidth="50" Note="">
                                    <%--<Plugins>
                                <ext:InputMask ID="InputMask2" runat="server" Mask="yzzz/mn/dt ab:ce:fg">
                                    <MaskSymbols>
                                        <ext:MaskSymbol Name="d" Regex="[0123]" Placeholder="d" />
                                        <ext:MaskSymbol Name="t" Regex="[0-9]" Placeholder="d" />
                                        <ext:MaskSymbol Name="m" Regex="[01]" Placeholder="m" />
                                        <ext:MaskSymbol Name="n" Regex="[0-9]" Placeholder="m" />
                                        <ext:MaskSymbol Name="y" Regex="[12]" Placeholder="y" />
                                        <ext:MaskSymbol Name="z" Regex="[0-9]" Placeholder="y" />
                                        <ext:MaskSymbol Name="a" Regex="[0-2]" Placeholder="H" />
                                        <ext:MaskSymbol Name="b" Regex="[0-9]" Placeholder="H" />
                                        <ext:MaskSymbol Name="c" Regex="[0-5]" Placeholder="m" />
                                        <ext:MaskSymbol Name="e" Regex="[0-9]" Placeholder="m" />
                                        <ext:MaskSymbol Name="f" Regex="[0-5]" Placeholder="s" />
                                        <ext:MaskSymbol Name="g" Regex="[0-9]" Placeholder="s" />
                                    </MaskSymbols>
                                </ext:InputMask>
                            </Plugins>--%>
                                </ext:DateField>
                                <ext:TextField ID="ADPFrom" runat="server" Name="ADDPFrom" FieldLabel="来源" LabelWidth="50" AllowBlank="false">
                                </ext:TextField>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Panel2" runat="server" Header="false" Collapsible="true" Border="false" Region="East" Split="false" Width="300" MarginSpec="0 5 0 5" Margins='0 0 0 0' BaseCls=" background: white">
                            <Items>
                                <ext:NumberField ID="ADPOrder" runat="server" Name="ADDPOrder" FieldLabel="排序" LabelWidth="50" AllowBlank="false" EmptyText="请填入数字">
                                </ext:NumberField>
                                <ext:ComboBox ID="ADPcmb" runat="server" FieldLabel="类型" LabelWidth="50">
                                    <Items>
                                        <ext:ListItem Text="政策" Value="政策"></ext:ListItem>
                                        <ext:ListItem Text="口径" Value="口径"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Panel3"
                            runat="server"
                            Region="South"
                            Border="true"
                            Header="false"
                            Height="280"
                            Width="600"
                            Layout="FitLayout">
                            <Items>
                                <ext:HtmlEditor ID="ADHEdit" runat="server" Text="" Height="220" Border="false" />
                            </Items>
                            <DockedItems>
                                <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                                    <Items>
                                        <ext:Button ID="Button1" runat="server" Text="增加" Icon="ApplicationEdit">
                                            <Listeners>
                                                <Click Handler="
                                                if (!#{ADPTitle}.validate() || !#{ADPFrom}.validate() ||!#{ADPOrder}.validate() ||!#{ADHEdit}.validate() ) {
                                                    Ext.Msg.alert('Error','验证有误，请核实所填项是否已填写完整!'); 
                                                    return false; 
                                                }" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnAdditem_DirectClick">
                                                    <EventMask ShowMask="false" Msg="Verifying..." MinDelay="500" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="Button3" runat="server" Text="取消" Icon="ApplicationEdit" OnDirectClick="btnAdditemCanc_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </DockedItems>
                        </ext:Panel>
                    </Items>
                </ext:FormPanel>
            </Items>
        </ext:Window>

    </form>
</body>
</html>
