<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncomeBudAllocat.aspx.cs"
    Inherits="WebPage_SysSetting_IncomeBudAllocat" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经济科目预算分配</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }

        .txt
        {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
        .ss {
            background:none;
            width:0px;
        }
    </style>
    <script type="text/javascript">
        //var select = function (a)
        //{
        //    App.direct.setAllNode(a.data.text);
        //} 
    </script>
    <script type="text/javascript"> 
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
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Viewport runat="server" Layout="FitLayout">
            <Items>
                <ext:Panel runat="server" Layout="AnchorLayout">
                    <Items>
                        <ext:Panel runat="server" Border="false" Collapsible="true">
                            <Content>
                                <div class="tabtitle">
                                    <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;经济科目预算分配</span><p>
                                    </p>
                                </div>
                                <!-- 表头结束 -->
                                <div class="table_list" runat="server">
                                    <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                                        <tr>
                                            <td class="tr1" align="left">&nbsp; <strong>
                                                <asp:Label ID="lblYear" runat="server"></asp:Label>年经济科目预算分配</strong>
                                                <asp:HiddenField ID="HidPIIDBasicStrs" runat="server" />
                                                <asp:HiddenField ID="HidMonBasicStrs" runat="server" />
                                                <asp:HiddenField ID="HidPIIDProjectStrs" runat="server" />
                                                <asp:HiddenField ID="HidMonProjectStrs" runat="server" />
                                                <asp:HiddenField ID="HidMonBasicTotal" runat="server" />
                                                <asp:HiddenField ID="HidMonProjectTotal" runat="server" />
                                            </td>
                                            <td class="tr1" align="right">
                                                <strong>单位(万元)</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tr1" align="right" width="20%">预算分配信息统计:
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="center" rowspan="2">
                                                            <asp:Label ID="Label4" runat="server" Text="年初预算:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="Label6" runat="server" Text="基本支出年初预算:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <strong>
                                                                <asp:Label ID="lblTotalMonBasic" runat="server" ForeColor="Red"></asp:Label></strong>
                                                        </td>
                                                        <td align="center" rowspan="2">
                                                            <asp:Label ID="Label8" runat="server" Text="追加预算金额:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="Label2" runat="server" Text="基本支出追加预算金额:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <strong>
                                                                <asp:Label ID="lblAddMonBasic" runat="server" ForeColor="Red"></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label3" runat="server" Text="项目支出年初预算:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <strong>
                                                                <asp:Label ID="lblTotalMonProject" runat="server" ForeColor="Red"></asp:Label></strong>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="Label5" runat="server" Text="项目支出追加预算金额:"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <strong>
                                                                <asp:Label ID="lblAddMonProject" runat="server" ForeColor="Red"></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td align="left" colspan="2">&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="预算未分配余额:"></asp:Label>
                                                            <strong>
                                                                <ext:Label runat="server" ID="lblBalance" StyleSpec="color:red ;"  ></ext:Label></strong>
                                                                <%--<asp:Label ID="lblBalance" runat="server" ForeColor="Red"></asp:Label></strong>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </Content>
                        </ext:Panel>
                        <ext:Hidden ID="HidIBA" runat="server"></ext:Hidden>
                        <ext:Hidden ID="HidYear" runat="server"></ext:Hidden>
                        <ext:Panel ID="plallocation" runat="server" Layout="FitLayout" Height="500" Title="分配金额" AutoHeight="false"
                            AutoScroll="true">
                            <Items>
                                <ext:TreePanel
                                    ID="TPPayIncome"
                                    runat="server"
                                    AutoScroll="true"
                                    Animate="true"
                                    Border="false"
                                    Mode="Remote"
                                    RootVisible="false"
                                    ContainerScroll="true"
                                    OnRemoteEdit="RemoteEdit">

                                    <%--                                    <Store>
                                        <ext:TreeStore ID="TStore" runat="server" OnReadData="GetNodes" ModelName="text" >
                                        </ext:TreeStore>
                                    </Store>--%> 
                                    <Fields>
                                        <ext:ModelField Name="text" />
                                        <ext:ModelField Name="IBAMon" />
                                    </Fields>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:TreeColumn ID="TreeColumn1" runat="server" DataIndex="text" Text="经济科目" Flex="1">
                                            </ext:TreeColumn>
                                            <ext:Column ID="Column5" runat="server" DataIndex="IBAMon" Text="分配金额" Flex="1">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField1" runat="server" > 
                                                    </ext:NumberField>
                                                    
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
                                        <%--<ItemExpand Fn="select"></ItemExpand>--%>
                                        <%--<CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" /> --%>
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>
                    </Items>
                    <%--                     <DockedItems>
                                <ext:Button ID="GetBack" runat="server" Dock="Bottom" Text="返回" OnDirectClick="GetBack_DirectClick">
                                </ext:Button>
                            </DockedItems>--%>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
