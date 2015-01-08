<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonPayPlanNew.aspx.cs" Inherits="WebPage_BudgetControl_MonPayPlanNew" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #ext-gen1078 {
            display: none !important;
        }

        #ext-gen1088 {
            display: none !important;
        }

        #ext-gen1116 {
            display: none !important;
        }
         #ext-gen1101 {
            display: none !important;
        }

        .x-tree-elbow-empty {
            display: none !important;
        }

        .x-grid-row td { 
            border-bottom: 1px solid #EDEDED !important;
            border-right: 1px solid #EDEDED !important;
        }
    </style>
</head>

<body>
    <script>

        function changeStyle() {
            if ($("#TPPlan-body table tr").length > 0) {

                $("#TPPlan-body table tr").each(function () {
                    if ($(this).find("td:first div").text() == "经济科目" || $(this).find("td:first div").text() == "财政拨款" || $(this).find("td:first div").text() == "基本支出") {
                        $(this).attr("style", "display: none !important;");
                    }
                });
                return;
            }
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
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Hidden runat="server" ID="HidSlist"></ext:Hidden>
        <ext:Hidden runat="server" ID="hidflag"></ext:Hidden>
        <ext:Viewport runat="server" Layout="FitLayout">
            <Items>
                <ext:TreePanel Lines="false"
                    ID="TPPlan"
                    UseArrows="true"
                    runat="server"
                    AutoScroll="true"
                    Animate="true"
                    Mode="Remote"
                    RootVisible="false"
                    ContainerScroll="true"
                    OnRemoteEdit="RemoteEdit">
                     
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="40">
                            <Items>
                                <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="请选择月份：" ColumnWidth="0.1"></ext:Label>
                                <ext:ComboBox ID="cmbmon" Editable="false" runat="server" OnDirectChange="cmbmon_DirectChange" ValueField="month" DisplayField="month">
                                    <Store>
                                        <ext:Store runat="server" ID="cmbmonstore">
                                            <Model>
                                                <ext:Model ID="Model1" runat="server">
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
                                    <Listeners> <Collapse Handler="App.direct.GetPagedirect();"></Collapse></Listeners>
                                </ext:ComboBox>
                                 
                                <ext:Panel ID="Panel1" runat="server" Border="false" BodyStyle="background:transparent">
                                    <Items>
<%--                                        <ext:Button ID="Button1"   runat="server" Text="确定" ><Listeners><Click Handler="App.direct.GetPagedirect();"></Click></Listeners></ext:Button> --%>
                                        <ext:Button ID="btnsubmit" runat="server" Text="提交" OnDirectClick="btnsubmit_DirectClick"></ext:Button>
                                        <ext:Label ID="Label2" runat="server" Text="本月度剩余余额为：" MarginSpec="0 5 0 20"></ext:Label>
                                        <ext:Label ID="Incomebalance"  runat="server" Text="" EmptyText="0"></ext:Label>

                                    </Items>
                                </ext:Panel>

                            </Items>

                        </ext:Toolbar>
                    </TopBar>
                    <Fields>
                        <ext:ModelField Name="text" />
                        <ext:ModelField Name="CPID" Type="int" />
                        <ext:ModelField Name="PIID" Type="int" />
                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                        <ext:ModelField Name="Mon" Type="float" />
                        <ext:ModelField Name="Balance" Type="float" />
                        <ext:ModelField Name="MPFunding" Type="float" />
                    </Fields>
                    <ColumnModel>
                        <Columns> 
                            <ext:TreeColumn Sortable="false" Align="left" ID="TreeColumn1" runat="server" DataIndex="text" Text="经济科目(元)" Flex="1">
                            </ext:TreeColumn>

                            <ext:Column ID="Column1" Sortable="false" Align="Center" runat="server" DataIndex="Mon" Text="年度预算指标(元)" Flex="1">
                            </ext:Column>
                            <ext:Column ID="Column2" Sortable="false" Align="Center" runat="server" DataIndex="Balance" Text="余额(元)" Flex="1">
                            </ext:Column>
                            <ext:Column ID="Column3" Sortable="false"  Align="Center" runat="server" DataIndex="MPFunding" EmptyCellText="0" Text="申请经费" Flex="1">
                                <Editor>
                                    <ext:NumberField ID="NFeditor" runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:CellEditing ID="CellEditing1" runat="server" />
                    </Plugins>
                    <Listeners>
                        <BeforeLoad Fn="nodeLoad" />
                        <Load Handler="changeStyle();"></Load> 
                        <CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" />

                        <Render Handler="#{TPPayIncome}.getRootNode().expand(true);" Delay="50" />
                    </Listeners>
                </ext:TreePanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
