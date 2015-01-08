<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LismitManage.aspx.cs" Inherits="WebPage_SysSetting_LismitManage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <title></title>
    <script type="text/javascript">
        var selectionChanged = function (selModel, selected) {
            //if (selected.length > 0 && selected[0].childNodes.length == 0) {
            //    var uid = selected[0].data.id;
            //    App.direct.Memberselect(uid);
            //}
        };
        var selectdept = function (q, w, e) {
            var textstr = w.data.text;
            Ext.get('hidText').setValue(textstr);
            App.direct.selectdep(w.data.id);
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
                    Ext.Msg.alert('错误', '请重新打开页面');
                }
            });

            return false;
        };

        var nodeLoad1 = function (store, operation, options) {
            var node = operation.node;

            App.direct.NodeLoad1(node.getId(), {
                success: function (result) {
                    node.set('loading', false);
                    node.set('loaded', true);
                    var data = Ext.decode(result);
                    node.appendChild(data, undefined, true);
                    node.expand();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('错误', '请重新打开页面');
                }
            });

            return false;
        };

        var Selector = {
            add: function () {
                //source = source || (App.GridPanel2 && App.GridPanel3 && App.GridPanel4 && App.GridPanel5 && App.GridPanel6);

                var flag;
                var select = "";
                source = App.GridPanel1;
                if (source.selModel.hasSelection()) {
                    var records = source.selModel.getSelection();
                    if (records.length > 1) {
                        Ext.Msg.alert("操作提示", "只能选择一条记录！");
                    }
                    else {
                        var selectid = records[0].data.PerID;
                        App.direct.alerttt(selectid);
                    }
                }
                else {
                    //$("#Hidselector").val(select);
                    Ext.Msg.alert("操作提示", "请选择一条记录！");
                }
            }
        }

        var gridCommand = function (sender, command, record) {
            App.direct.Click_Handler(record.data.PerID);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidFlag" Value="0" runat="server" />
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" AutoScroll="true">
            <Items>
                <ext:Panel runat="server" ID="Panel1" Layout="ColumnLayout" AutoScroll="true">
                    <Items>
                        <ext:Hidden runat="server" ID="hidUserID1" />
                        <ext:Hidden runat="server" ID="hidText" />
                        <ext:Hidden runat="server" ID="Hidden1" Text="0" />
                        <%-- <ext:Hidden runat="server" ID="hidflag" />--%>
                        <ext:TreePanel
                            ID="STMem" Title="部门列表"
                            runat="server"  Height="650"
                            
                            RootVisible="false"
                            ColumnWidth="0.2" AutoScroll="true">
                            <Root>
                            </Root>
                            <Listeners>
                                <BeforeLoad Fn="nodeLoad" />
                                <SelectionChange Fn="selectionChanged"></SelectionChange>
                                <ItemClick Fn="selectdept"></ItemClick>
                            </Listeners>
                        </ext:TreePanel>

                        <ext:FormPanel ID="PlMenber"
                            runat="server" Height="650"
                            Title="人员信息" ColumnWidth="0.8">

                            <Items>

                                <ext:FieldSet ID="FieldSet1"
                                    runat="server" MarginSpec="20 0 0 50"
                                    Title="权限设置"
                                    Collapsible="true" Width="250"
                                    DefaultAnchor="100%">
                                    <Items>

                                        <ext:CheckboxGroup ID="CheckboxGroup1" runat="server"
                                            Layout="AnchorLayout">
                                            <Items>
                                                <ext:Checkbox ID="Checkbox1" LabelWidth="140"
                                                    FieldLabel="系统设置" runat="server">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="Checkbox2" LabelWidth="140"
                                                    FieldLabel="预算执行情况分析" runat="server">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="Checkbox3" LabelWidth="140"
                                                    FieldLabel="部门经费支出明细表" runat="server">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="Checkbox4" LabelWidth="140"
                                                    FieldLabel="经费支出分析明细表" runat="server">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="Checkbox5" LabelWidth="140"
                                                    FieldLabel="自选分析" runat="server">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="Checkbox6" LabelWidth="140"
                                                    FieldLabel="科、所经费查询" runat="server">
                                                </ext:Checkbox>
                                            </Items>
                                        </ext:CheckboxGroup>
                                    </Items>
                                </ext:FieldSet>

                                <ext:TextField ID="TextField3" LabelWidth="60"
                                    runat="server" MarginSpec="30 0 0 50"
                                    AllowBlank="true" Hidden="true"
                                    FieldLabel="ID"
                                    Name="ID" />

                                <ext:Button ID="btnEdit" MarginSpec="20 0 0 55" Width="60"
                                    Icon="UserEdit" runat="server" Text="保存" OnDirectClick="btnEdit_DirectClick">
                                </ext:Button>

                            </Items>
                        </ext:FormPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>