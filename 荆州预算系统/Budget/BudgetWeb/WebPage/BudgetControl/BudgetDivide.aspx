<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetDivide.aspx.cs" Inherits="WebPage_BudgetControl_BudgetDivide" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script>
        var rawclick = function (a, b, c) {
            App.direct.GetRowexpand(b.data.piidflag);
        }
        function changeStyle() {
            if ($("#gridview-1009 table tr").length > 0) {

                $("#gridview-1009 table tr").each(function () { 
                        if ($(this).find("td:first div").text() == "总计") {
                            $(this).attr("style", "color:red;font-weight:bold");
                        }  
                });
                return;
            }
        }

    </script>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Viewport ID="ViewPort1" runat="server" Layout="FitLayout">
            <Items>
                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server" AutoHeight="false" Layout="FitLayout" MaskOnDisable="false" AutoScroll="true"
                    Title="预算分配情况">

                    <Store> 
                        <ext:Store ID="DivideStore" runat="server" PageSize="17">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>  <ext:ModelField Name="piidflag" Type="int" />
                                        <ext:ModelField Name="depname" Type="string" />
                                        <ext:ModelField Name="name" Type="string" />
                                        <ext:ModelField Name="mon" Type="float" />
                                        <ext:ModelField Name="supp" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                            <Listeners> <Load Handler="changeStyle();"></Load></Listeners>
                        </ext:Store> 
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column Sortable="true" ID="clDepName" runat="server" Text="部门名称" Flex="1" DataIndex="depname" />
                            <ext:Column Align="center" ID="clPIEcoSubName" runat="server" Text="经济科目" Flex="1" DataIndex="name" />
                            <ext:Column Align="center" EmptyCellText="0.00" ID="clBAAMon" runat="server" Text="经费" Flex="1" DataIndex="mon" />
                            <ext:Column Align="center" EmptyCellText="0.00" ID="Column1" runat="server" Text="追加经费" Flex="1" DataIndex="supp" />
                        </Columns>
                    </ColumnModel>

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Layout="AnchorLayout" BaseCls="background:transparent">
                            <Items>
                                <ext:Panel ID="Panel1" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="部　　门：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbDep" MarginSpec="5 5 0 5" runat="server" ColumnWidth="0.2 " DisplayField="DepName">
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel2" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" MarginSpec="5 5 0 5" Text="经济科目：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbPPA" MarginSpec="5 5 0 5" runat="server" ColumnWidth="0.2" DisplayField="PIEcoSubName">
                                            <Store>
                                                <ext:Store ID="cmbPPAstore" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model3" runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="PIEcoSubName"></ext:ModelField>
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
                                </ext:Panel>
                                <ext:Panel ID="Panel3" runat="server" Border="false" BodyStyle="background:transparent">
                                    <Items>
                                        <ext:Button Icon="Accept" runat="server" MarginSpec="0 0 5 0" ID="submit" OnDirectClick="submit_DirectClick" Text="确定"></ext:Button>
                                        <ext:Label runat="server" ID="txtshow" MarginSpec="0 0 0 5"></ext:Label>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="预算分配情况"></ext:Panel> 
                            </Items>
                        </ext:Toolbar>
                    </TopBar>　
                    <Listeners><ItemClick  Fn="rawclick"></ItemClick></Listeners>
                </ext:GridPanel>

            </Items>

        </ext:Viewport>
    </form>
</body>
</html>
