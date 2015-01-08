<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayIncomeAllocation.aspx.cs" Inherits="WebPage_BudgetControl_PayIncomeAllocation" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .addico {
            background-image: none;
            padding: 0;
            margin: 0;
            width: 0;
        } 
           .x-grid-row td { 
            border-bottom: 1px solid #EDEDED !important;
            border-right: 1px solid #EDEDED !important;
        }
                   .x-tree-elbow-empty {
            display: none !important;
        }
        #ext-gen1091{ display: none !important;}
        #ext-gen1101{ display: none !important;}
        #ext-gen1114{ display: none !important;}
    </style>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script>
        var GetSelect = function () {
            var select = "";
            selChildren = App.TPPayIncome.getChecked();

            Ext.each(selChildren, function (node) {
                if (select.length > 0) {
                    select += ", ";
                }

                select += node.data.text;
            });
            $("#Hidselector").val(select);
        }
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


       
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <%-- <asp:HiddenField  runat="server"   ID="HidSlist"/>--%>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Viewport runat="server" ID="vwpLayout" Layout="FitLayout">
            
            <Items> 
                 <ext:Hidden runat="server" ID="HidSlist"/>
                <ext:Hidden ID="HidLeaf" runat="Server"></ext:Hidden>
                <ext:Hidden ID="HidDepid" runat="server"></ext:Hidden>
                <ext:Hidden ID="HidSupp" runat="server"></ext:Hidden>
                <ext:Hidden ID="HidBAA" runat="server"></ext:Hidden>
                <%--<ext:Hidden ID="HidPIID" runat="server"></ext:Hidden>--%>
                <ext:Hidden ID="Hidselector" runat="server"></ext:Hidden>
                <ext:FormPanel ID="plallocation" runat="server"
                    Title="预算分配" Layout="FitLayout">
                    <Items>
                        <ext:TreePanel
                            ID="TPPayIncome"
                            Lines="false"
                            UseArrows="true"
                            runat="server"
                            AutoScroll="true"
                            Animate="true"
                            Mode="Remote"
                            RootVisible="false"
                            ContainerScroll="true"
                            OnRemoteEdit="RemoteEdit">

                            <%--<Store>
                                <ext:TreeStore ID="TStore" runat="server" OnReadData="GetNodes" ModelName="text">
                                </ext:TreeStore>
                            </Store>--%>
                            <Fields>
                                <ext:ModelField Name="text" />
                                <ext:ModelField Name="BAAMon" />
                                <ext:ModelField Name="SuppMon" />
                            </Fields>
                            <ColumnModel>
                                <Columns>
                                    <ext:TreeColumn ID="TreeColumn1" runat="server" DataIndex="text" Text="经济科目" Flex="4">
                                    </ext:TreeColumn>
                                    <ext:Column ID="Column5" runat="server" DataIndex="BAAMon" Text="分配金额" Flex="1">
                                        <Editor>
                                            <ext:NumberField runat="server" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ID="Column6" runat="server" DataIndex="SuppMon" Text="追加余额" Flex="1">
                                        <Editor>
                                            <ext:NumberField runat="server" />
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <Plugins>
                                <ext:CellEditing ID="CellEditing1" runat="server" />
                                <%--<ext:RowEditing runat="server" />--%>
                            </Plugins>
                            <Listeners>
                                <BeforeLoad Fn="nodeLoad" />
                                <CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" />

                                <Render Handler="#{TPPayIncome}.getRootNode().expand(true);" Delay="50" />
                            </Listeners>
                            <DockedItems>
                                <ext:Button ID="GetBack" runat="server" Dock="Bottom" Text="返回" OnDirectClick="GetBack_DirectClick">
                                </ext:Button>
                            </DockedItems>
                            <TopBar>
                                <ext:Toolbar runat="server" Layout="ColumnLayout">
                                    <Items>
                                        <ext:Label runat="server" Text="总余额剩余为：  "></ext:Label>
                                        <ext:Label ID="BAA" runat="server" Text=""></ext:Label>
                                        <ext:Label ID="Label3" runat="server" Text="万元"></ext:Label>
                                        <ext:Label PaddingSpec="0 0 0 10" runat="server" Text="追加金额剩余为：  "></ext:Label>
                                        <ext:Label ID="SUPP" runat="server" Text=""></ext:Label>
                                        <ext:Label ID="Label4" runat="server" Text="万元"></ext:Label> 
                                        <ext:Panel runat="server" BaseCls="background:transeparent" MarginSpec="0 0 3 10">
                                            <Items>
                                                <ext:Button ID="Button1" runat="server" Text="关闭所有展开">
                                                    <Listeners>
                                                        <Click Handler="#{TPPayIncome}.collapseAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:TreePanel>
                    </Items>
                </ext:FormPanel> 
            </Items>
        </ext:Viewport> 
    </form>
</body>
</html>
