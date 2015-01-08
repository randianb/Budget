<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetAllocation.aspx.cs" Inherits="WebPage_BudgetControl_BudgetAllocation" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        var Selector = {
            add: function () {
                //source = source || (App.GridPanel2 && App.GridPanel3 && App.GridPanel4 && App.GridPanel5 && App.GridPanel6);

                var flag;
                var select = "";
                source = App.gridselect;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();

                    for (var k = 0; k < records.length; k++) {
                        if (k == records.length - 1) {
                            select += records[k].data.PIEcoSubName;
                            flag = records[k].data.ISSign;
                        }
                        else {
                            select += records[k].data.PIEcoSubName + ",";
                            flag = records[k].data.ISSign;
                        }
                        App.direct.insertSign(records[k].data.PIID, flag);
                    }
                }
                $("#Hidselector").val(select);
                Ext.Msg.alert("操作提示", "保存成功，请点击“提交”按钮进行查询分配操作!");
            }
        }


        //var CountrySelector = {
        //    add: function () {
        //        var source = App.TPPayIncome;
        //        if (source.selModel.hasSelection()) {
        //            var records = source.selModel.getSelection();
        //            for (var i = 0; i < records.length; i++) {
        //                select += records[i].data.PIID + ",";
        //            }
        //        }
        //        $("#Hidselector").val(select);
        //    }
        //}
        //var GetSelect = function () {
        //    var select = "";
        //    selChildren = App.TPPayIncome.getChecked();

        //    Ext.each(selChildren, function (node) {
        //        if (select.length > 0) {
        //            select += ", ";
        //        }

        //        select += node.data.text;
        //    });
        //    $("#Hidselector").val(select);
        //}


        var gridCommand = function (sender, command, record) {

            if (command == "Divide") {
                //$("#HidDepid").val(record.data.DepID);
                App.direct.DivideData(record.data.DepID);
            }
        }
    </script>
    <style type="text/css">
        .cbStates-list {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }

            .cbStates-list th {
                font-weight: bold;
            }

            .cbStates-list td, .cbStates-list th {
                padding: 3px;
            }

        .list-item {
            cursor: pointer;
        }
    </style>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:HiddenField  runat="server" id="HidDepid"/>--%>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport runat="server" ID="vwpLayout" Layout="fit">
            <Items> 
                <ext:Hidden ID="supp" runat="server"></ext:Hidden>
                <ext:Hidden ID="baa" runat="server"></ext:Hidden>
                <ext:Hidden runat="server" ID="Hidselector"></ext:Hidden>
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
                                        <ext:ModelField Name="BAAMon" Type="Float" />
                                        <ext:ModelField Name="SuppMon" Type="Float" />
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
                                DataIndex="BAAMon"
                                EmptyCellText="0.00"
                                Flex="1" />
                            <ext:Column ID="Column4"
                                runat="server"
                                Text="追加金额"
                                EmptyCellText="0.00"
                                DataIndex="SuppMon"
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
                                <ext:Label ID="Label1" runat="server" Text="万元"></ext:Label>
                                <ext:Label ID="Label7" runat="server" MarginSpec="0 0 0 50" Text="追加金额"></ext:Label>
                                <ext:Label ID="Label5" runat="server" Text=""></ext:Label>
                                <ext:Label ID="Label2" runat="server" Text="万元"></ext:Label>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Panel runat="Server" Border="false" BaseCls="background:transeparent" ButtonAlign="Right">
                                    <Items>
                                        <ext:Button runat="Server" Text="分配设置" ID="BtnSettingPayIncome"  Hidden="true" OnDirectClick="BtnSettingPayIncome_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Toolbar>

                    </TopBar>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        <ext:Window Hidden="true" runat="Server" Width="336" Height="180" ID="Windows" Layout="FitLayout">
            <Items>
                <ext:FormPanel BaseCls="background:transeparent" ButtonAlign="Right" Border="false" ID="FPCMB" runat="Server" MarginSpec="10 0 10 0" Layout="ColumnLayout">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <%--<ext:ComboBox ID="cmballocation" runat="Server" EmptyText="请选择">
                            <Items>
                                <ext:ListItem Text="财政拨款"></ext:ListItem>
                                <ext:ListItem Text="其他资金"></ext:ListItem>
                            </Items> 
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.getTrigger(0).show();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox runat="Server" ID="cmbpayincome" MarginSpec="0 10 0 10" EmptyText="请选择">
                            <Items>
                                <ext:ListItem Text="基本支出"></ext:ListItem>
                                <ext:ListItem Text="项目支出"></ext:ListItem>
                            </Items> 
                            <Listeners>
                                <Select Handler="#{StoreSelectIncome}.reload(); this.getTrigger(0).show();" />
                            </Listeners>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                        </ext:ComboBox>--%>
                        <%--  <ext:TextField ID="TFshow" runat="server" Enabled="false" EmptyText="请选择">
                            <Listeners>
                                <Focus Handler="if (#{cmballocation}.disable){#{TFshow}.hide();#{gridselect}.show();}"></Focus>
                            </Listeners>
                        </ext:TextField>--%>
                        <ext:GridPanel ColumnLines="true" runat="Server" ID="gridselect" Width="240" Height="130" MarginSpec="0 10 0 10">
                            <Store>
                                <ext:Store runat="Server" ID="StoreSelectIncome" >  
                                    <Model>
                                        <ext:Model ID="Model2" runat="server" IDProperty="PIID">
                                            <Fields>
                                                <ext:ModelField Name="PIID" Type="int"  ServerMapping="PIID"/>
                                                <ext:ModelField Name="PIEcoSubName" Type="String"  ServerMapping="PIEcoSubName"/>
                                                <ext:ModelField Name="ISSign" Type="Int"  ServerMapping="ISSign" ></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                  <%--  <Listeners>
                                        <Load Handler="#{cmballocation}.setDisabled(true);" />
                                    </Listeners>--%>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column ID="Column5" Sortable="false" runat="server" Text="经济科目" DataIndex="PIEcoSubName">
                                    </ext:Column>
                                    <ext:ComponentColumn ID="ComponentColumn1"
                                        Sortable="false"
                                        DataIndex="ISSign"
                                        runat="server"　
                                        Editor="true"
                                        Text="是否显示下级">
                                        <Component>
                                            <ext:ComboBox ID="cmbshow" runat="server">
                                                <Items>
                                                    <ext:ListItem Text="是" Value="1" Mode="Raw" />
                                                    <ext:ListItem Text="否" Value="0" Mode="Raw" />
                                                </Items> 
                                            </ext:ComboBox>
                                        </Component>
                                    </ext:ComponentColumn>
                                </Columns>

                            </ColumnModel>
                            <%-- <Loader runat="server"><LoadMask ShowMask="false"></LoadMask></Loader>--%>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
                            </SelectionModel>
                        </ext:GridPanel>
                        <%--                            <ListConfig Width="150" Height="300" ItemSelector=".x-boundlist-item">
                                <Tpl ID="Tpl1" runat="server">
                                    <Html>
                                        <tpl for=".">
						    <tpl if="[xindex] == 1">
							    <table class="cbStates-list">
								    <tr>
									    <th>经济科目</th>
									    <th>标记科目</th>
								    </tr>
						    </tpl>
						    <tr class="x-boundlist-item">
							    <td>{PIEcoSubName}</td>
							    <td>{Sign}</td> 
						    </tr>
						    <tpl if="[xcount-xindex]==0">
							    </table>
						    </tpl>
					    </tpl>
                                    </Html>
                                </Tpl>
                            </ListConfig>--%>
                        <%-- <ext:Label Text="分配一级科目: " runat="server" />
                        <ext:ComboBox ID="cmbsign" Disabled="true" runat="Server" Width="40" MultiSelect="true" MarginSpec="0 10 0 0" EmptyText="请选择">
                            <Items>
                                <ext:ListItem Text="是" Value="0"></ext:ListItem>
                                <ext:ListItem Text="否" Value="1"></ext:ListItem>
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Index="0"></ext:ListItem>
                            </SelectedItems>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.getTrigger(0).show();" />
                            </Listeners>
                        </ext:ComboBox>--%>
                        <ext:Button runat="Server" ID="btnreset" Text="重选">
                            <Listeners>
                                <Click Handler="#{cmballocation}.setDisabled(false);#{cmballocation}.clearValue();#{cmbselect}.clearValue();#{cmbpayincome}.clearValue();"></Click>
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="Server" ID="btnDivde" Text="分配" OnDirectClick="btnDivde_DirectClick"></ext:Button>
                        <ext:Button runat="Server" Text="保存">
                            <Listeners>
                                <Click Handler="Selector.add();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="Server" ID="btnsave" Text="提交" Hidden="true" OnDirectClick="btnsave_DirectClick">
                        </ext:Button>
                    </Items>
                    <Listeners>
                        <ValidityChange Handler="#{btnDivde}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
        </ext:Window>


        <%-- <ext:Window ID="WinAdd" runat="server"
            Title="分配"
            Width="460"
            Height="295"
            Icon="UserAdd"
            Hidden="true"
            Layout="FitLayout">
            <Items>

                
                <ext:GridPanel ID="gridpanel2" runat="server" Border="false">
                    <Store>
                        <ext:Store ID="Store2" runat="server" PageSize="10"> 
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Name" Type="string" />
                                        <ext:ModelField Name="BAAMon" Type="float" />
                                        <ext:ModelField Name="SuppMon" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:SummaryColumn Sortable="true" ID="SummaryColumn1" runat="server" Text="经济科目名称" Flex="1" DataIndex="Name" />
                            <ext:SummaryColumn Sortable="true" ID="SummaryColumn2" runat="server" Text="经费" Flex="1" DataIndex="BAAMon" />
                            <ext:SummaryColumn Sortable="true" ID="SummaryColumn3" runat="server" Text="追加经费" Flex="1" DataIndex="SuppMon" />
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
        </ext:Window>--%>

        <%-- <ext:Window ID="WinAdd" runat="server" Hidden="true" Height="500" Width="400"
            Title="预算分配" Layout="FitLayout">
            <Items> 
                <ext:TreePanel
                    ID="TPPayIncome"
                    runat="server" Height="650"
                    SingleExpand="false"
                    UseArrows="true"
                    RootVisible="false"
                    Disabled="true"
                    Lines="false"
                    ColumnWidth="0.3" AutoScroll="true" OnRemoteEdit="RemoteEdit" OnRemoteAppend="RemoteAppend" OnRemoteMove="RemoteMove">

                    <Store>
                        <ext:TreeStore ID="TStore" runat="server"  OnReadData="GetNodes" ModelName="text">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="text" />
                                        <ext:ModelField Name="BAAMon" Type="Float" />
                                        <ext:ModelField Name="SuppMon" Type="Float" />
                                    </Fields>
                                </ext:Model>
                            </Model> 
                        </ext:TreeStore>
                    </Store> 

                    <ColumnModel>
                        <Columns>
                            <ext:TreeColumn ID="TreeColumn1" runat="server" DataIndex="text" Text="经济科目" Flex="1">
                            </ext:TreeColumn>

                            <ext:Column ID="Column5" runat="server" DataIndex="BAAMon" Text="分配金额">
                                <Editor>
                                    <ext:NumberField ID="NumberField1" runat="server" />
                                </Editor>
                            </ext:Column>

                            <ext:Column ID="Column6" runat="server" DataIndex="SuppMon" Text="追加余额">
                                <Editor>
                                    <ext:NumberField ID="NumberField2" runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>

                    <Listeners>
                        <CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" />

                        <Render Handler="#{TPPayIncome}.getRootNode().expand(true);" Delay="50" />
                    </Listeners>
                    <DockedItems>
                        <ext:Button ID="GetSelect" runat="server" Dock="Bottom" Text="设置经济科目" OnDirectClick="GetSelect_DirectClick">
                            <Listeners>
                                <Click Fn="GetSelect" />
                            </Listeners>
                        </ext:Button>
                    </DockedItems>
                </ext:TreePanel>
            </Items>
        </ext:Window>--%>
        <%-- <ext:Window ID="Window1" runat="server"
            Title="添加"
            Width="300"
            Height="210"
            Icon="UserAdd"
            AnimCollapse="false"
            HideMode="Offsets"
            Resizable="false"
            CloseAction="Hide"
            Hidden="true">
            <Items>

                <ext:Container ID="Container1" runat="server" Layout="ColumnLayout" PaddingSpec="10 0 0 10">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="选择经济科目名称：" Width="120"></ext:Label>
                        <ext:ComboBox ID="ComboBox1" runat="server" DisplayField="PayPrjName" PaddingSpec="0 0 0 ０">
                            <Store>
                                <ext:Store ID="cmbName" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
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
                    </Items>
                </ext:Container>
                <ext:Container ID="Container2" runat="server" Layout="ColumnLayout" PaddingSpec="20 0 0 10">
                    <Items>
                        <ext:Label ID="Label2" runat="server" Text="经　　　　　费　：" Width="120"></ext:Label>
                        <ext:TextField runat="server" PaddingSpec="0 0 0 0" ID="tfMon"></ext:TextField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container4" runat="server" Layout="ColumnLayout" PaddingSpec="20 0 0 10">
                    <Items>
                        <ext:Label ID="Label8" runat="server" Text="追　加　经　费　：" Width="120"></ext:Label>
                        <ext:TextField runat="server" PaddingSpec="0 0 0 0" ID="suppMon"></ext:TextField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container3" runat="server" Layout="ColumnLayout" PaddingSpec="20 0 0 130">

                    <Items>
                        <%--<ext:Button ID="btnSure" runat="server" Text="确定" OnDirectClick="btnSure_DirectClick" Width="50" Height="24"></ext:Button>--%>
        <%--<ext:Button ID="btnSure" runat="server" Text="确定" Width="50" Height="24">
            <Listeners>
                <Click Handler="
                                                if (!#{tfMon}.validate() && !#{suppMon}.validate()) {
                                                    Ext.Msg.alert('Error','验证有误，请核实所填项是否已填写完整!'); 
                                                    return false; 
                                                }" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnSure_DirectClick">
                    <EventMask ShowMask="false" Msg="Verifying..." MinDelay="500" />
                </Click>
            </DirectEvents>
        </ext:Button>
        </Items>
                </ext:Container>
                <ext:Hidden ID="tatal" runat="server"></ext:Hidden>
        <ext:Hidden ID="supp" runat="server"></ext:Hidden>
        </Items>
        </ext:Window> --%>
    </form>
</body>
</html>

