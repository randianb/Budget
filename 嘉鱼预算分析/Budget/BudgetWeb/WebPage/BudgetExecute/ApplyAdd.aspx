<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyAdd.aspx.cs" Inherits="WebPage_BudgetExecute_ApplyAdd" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .textred {
            color: red;
        }
    </style>
</head>
<body>
    <script>

        var GetNode = function (a, b, c) {
            var str = a.selected.items[0].data.text;
            var id = a.selected.items[0].data.id;
            //var parentid = a.selected.items[0].data.parentId;
            //alert(parentid);
           
            var getsub = App.ddlARExpSub;
            if (a.selected.items[0].data.leaf) {
                getsub.setValue(id, str, false);
                App.direct.SelectChange();
            }
            else { Ext.Msg.alert('提示', '您选中的' + str + '未分配数据,不能被选中.'); }
        }


        var getValues = function (tree) {
            alert(tree);
            var msg = "",
                selNodes = tree.getSelected();

            Ext.each(selNodes, function (node) {
                msg.push(node.id);
            });

            return msg.join(",");
        };
        var getText = function (tree) {
            alert(tree);
            var msg = "",
                selNodes = tree.getSelected();
            //msg.push("[");

            Ext.each(selNodes, function (node) {
                if (msg.length > 1) {
                    msg.push(",");
                }

                msg.push(node.text);
            });

            //msg.push("]");

            return msg.join("");
        };

        var syncValue = function (value) {
            var tree = this.component;

            if (tree.rendered) {
                var ids = value.split(",");
                tree.setChecked({ ids: ids, silent: true });

                tree.getSelectionModel().clearSelections();
                Ext.each(ids, function (id) {
                    var node = tree.getNodeById(id);

                    if (node) {
                        node.ensureVisible(function () {
                            tree.getSelectionModel().select(tree.getNodeById(this.id), null, true);
                        }, node);
                    }
                }, this);
            }
        };


        var nodeLoad = function (store, operation, options) {
            var node = operation.node;
            App.direct.NodeLoad(node.getId(), {
                success: function (result) {
                    node.set('loading', false);
                    node.set('loaded', true);
                    var data = Ext.decode(result);
                    node.appendChild(data, undefined, true);
                    node.expand();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('错误', "网络超时.");
                }
            });

            return false;
        };
    </script>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Hidden runat="server" ID="HidtxtARMon"></ext:Hidden>
        <ext:FormPanel ID="FormPanel1"
            runat="server"
            Title="申请表"
            Frame="true" ButtonAlign="Left">
            <FieldDefaults>
                <CustomConfig>
                    <ext:ConfigItem Name="LabelWidth" Value="100" Mode="Raw" />
                    <ext:ConfigItem Name="PreserveIndicatorIcon" Value="true" Mode="Raw" />
                </CustomConfig>
            </FieldDefaults>
            <Items>
                <ext:Panel runat="server">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtARReiSinNum" Editable="false" PaddingSpec="10 0 0 10" runat="server" FieldLabel="报销单号" IsRemoteValidation="false" AllowBlank="false">
                            <%--  <RemoteValidation OnValidation="CheckField" />--%>
                        </ext:TextField>

                        <ext:DateField
                            ID="txtBITime"
                            runat="server"
                            PaddingSpec="0 0 0 10"
                            FieldLabel="报销时间" LabelWidth="100"
                            EnableKeyEvents="true" IndicatorCls="textred" />


                        <%--  <ext:ComboBox ID="ddlARExpSub" PaddingSpec="0 0 0 10" runat="server" DisplayField="PIEcoSubName"
                            AllowBlank="false"
                            Editable="false"
                            FieldLabel="支出科目"
                            IsRemoteValidation="false" IndicatorCls="textred"> 
                            <Store>
                                <ext:Store runat="server" ID="storeddlARExpSub">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="PIEcoSubName"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <SelectedItems>
                                <ext:ListItem Index="0"></ext:ListItem>
                            </SelectedItems>
                            <Listeners>
                                <Select Handler="App.direct.SelectChange();"></Select>
                            </Listeners>
                        </ext:ComboBox>--%>
                        <ext:DropDownField
                            PaddingSpec="0 0 0 10"
                            ID="ddlARExpSub"
                            FieldLabel="支出科目"
                            runat="server"
                            Editable="false"
                            TriggerIcon="SimpleArrowDown"
                            Mode="ValueText">
                            <Component>
                                <ext:TreePanel ID="TPPayIncome"
                                    runat="server"
                                    Icon="Accept"
                                    Height="300"
                                    UseArrows="true"
                                    AutoScroll="true"
                                    Animate="true"
                                    EnableDD="true"
                                    ContainerScroll="true"
                                    RootVisible="false">
                                    <Fields>
                                        <ext:ModelField Name="text" />
                                    </Fields>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:TreeColumn ID="TreeColumn1" Sortable="false" runat="server" DataIndex="text" Text="经济科目" Flex="4">
                                            </ext:TreeColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <Buttons>
                                        <ext:Button ID="Button1" runat="server" Text="Close">
                                            <Listeners>
                                                <Click Handler="#{ddlARExpSub}.collapse();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Buttons>
                                    <Listeners>
                                        <BeforeLoad Fn="nodeLoad" />
                                        <Select Fn="GetNode"></Select>
                                        <%--<Select  Handler="this.dropDownField.setValue(getValues(this), getText(this), false);"></Select>
                                        <CheckChange Handler="this.dropDownField.setValue(getValues(this), getText(this), false);" />--%>
                                    </Listeners>
                                    <SelectionModel>
                                        <ext:TreeSelectionModel ID="TreeSelectionModel1" runat="server" Mode="Single" />
                                    </SelectionModel>
                                </ext:TreePanel>
                            </Component>
                            <Listeners>
                                <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="20" />
                            </Listeners>
                            <SyncValue Fn="syncValue" />
                        </ext:DropDownField>

                        <ext:ComboBox ID="ddlARRepDep" PaddingSpec="0 0 0 10" runat="server" DisplayField="DepName"
                            AllowBlank="false"
                            Editable="false"
                            FieldLabel="上报部门"
                            IsRemoteValidation="false">
                            <%--  <RemoteValidation OnValidation="CheckCombo" />--%>
                            <Store>
                                <ext:Store runat="server" ID="storeddlARRepDep">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="DepID"></ext:ModelField>
                                                <ext:ModelField Name="DepName"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <SelectedItems>
                                <ext:ListItem Index="0"></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>

                        <ext:TextField ID="txtARAgent" IndicatorCls="textred" PaddingSpec="0 0 0 10" runat="server" FieldLabel="经办人" IsRemoteValidation="false" AllowBlank="false">
                            <%--<RemoteValidation OnValidation="CheckField" />--%>
                        </ext:TextField>

                        <ext:TextField ID="txtARMon" PaddingSpec="0 0 0 10"
                            runat="server" FieldLabel="上报金额" IsRemoteValidation="false" Regex="/^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$/" RegexText="填写金额不正确." AllowBlank="false" IndicatorCls="textred">
                            <%-- <RemoteValidation OnValidation="CheckField" />--%>
                        </ext:TextField>


                        <ext:TextField ID="txtARExcu" PaddingSpec="0 0 0 10" runat="server" FieldLabel="事由" IsRemoteValidation="false" AllowBlank="false">
                            <%-- <RemoteValidation OnValidation="CheckField" />--%>
                        </ext:TextField>
                    </Items>
                </ext:Panel>
            </Items>
            <DockedItems>
                <ext:Panel runat="server" Dock="Bottom" Border="false" Layout="ColumnLayout" BaseCls="background:tranceparent">
                    <Items>
                        <ext:RadioGroup ID="RadioGroup1" runat="server">
                            <Items>
                                <ext:Radio ID="radMed" Hidden="true" LabelWidth="40" FieldLabel="医疗费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radPur" Hidden="true" LabelWidth="40" FieldLabel="购置费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radTrain" Hidden="true" LabelWidth="40" FieldLabel="培训费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radMeet" Hidden="true" LabelWidth="40" FieldLabel="会议费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radPrint" Hidden="true" LabelWidth="40" FieldLabel="印刷费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radTra" Hidden="true" LabelWidth="40" FieldLabel="差旅费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radCar" Hidden="true" LabelWidth="120" FieldLabel="公务用车运行维护费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radMaintenance" Hidden="true" LabelWidth="80" FieldLabel="维修（护）费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radUnion" Hidden="true" LabelWidth="55" FieldLabel="工会经费" runat="server" />
                                <ext:ToolbarSeparator />
                                <ext:Radio ID="radOth" Hidden="true" LabelWidth="55" FieldLabel="其它费用" runat="server" />
                            </Items>
                        </ext:RadioGroup>
                        <ext:Button ID="btnAddDoc" runat="server" Text="添加报销单" Hidden="true" OnDirectClick="btnAddDoc_DirectClick" />
                    </Items>
                </ext:Panel>
            </DockedItems>
            <Buttons>
                <ext:Button ID="btnAdd" runat="server" Text="添加" Disabled="true" OnDirectClick="btnAdd_DirectClick" />
                <ext:Button ID="btnexit" runat="server" Text="返回" OnDirectClick="btnexit_DirectClick" />
            </Buttons>
            <Listeners>
                <ValidityChange Handler="#{btnAdd}.setDisabled(!valid);#{btnAddDoc}.setVisible(valid);#{btnAddDoc}.setDisabled(valid);" />
            </Listeners>
        </ext:FormPanel>

    </form>
</body>
</html>
