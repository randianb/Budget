<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportCkData.aspx.cs" Inherits="WebPage_OptAnaly_ImportCkData" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

<%--        <ext:Panel ID="Panel1" runat="server" Height="80" Title="导入核算数据" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox ID="cmbYear" runat="server" FieldLabel="核算数据" Width="300px" Margin="10">
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
                <ext:Button ID="btnImport" runat="server" Text="导入" Icon="ArrowRefresh" Margin="10" OnDirectClick="btnImport_DirectClick">
                </ext:Button>
            </Items>
        </ext:Panel>--%>
           <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:FormPanel ID="frompanel" runat="server">
                    <Items>
                        <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                            <Items>
                                <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                                    <Items>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                        <ext:Label ID="Label1" runat="server" Text="导入核算数据："></ext:Label>
                                    </Items>
                                </ext:Toolbar>
                                <ext:Container ID="Container4" runat="server" PaddingSpec="6 0 0 20" Width="150" Height="24">
                                    <Items>
                                        <ext:FileUploadField ID="FUFEXC" runat="server"  ButtonText="浏览···" >
                                        </ext:FileUploadField>
                                    </Items>
                                </ext:Container>
                               <%-- <ext:TextField ID="TextField5" runat="server" Text="未选择文件" Height="24" PaddingSpec="6 0 0 20">
                                </ext:TextField>--%>
                                <ext:TextField runat="server" FieldLabel="年度" ID="txtYear1" ReadOnly="true" Height="24" PaddingSpec="6 0 0 25" LabelWidth="65"></ext:TextField>
                                <ext:Container ID="Container1" runat="server" PaddingSpec="6 0 0 20" Width="40" Height="24">
                                    <Items>
                                        <ext:Button ID="btnImport" runat="server" Text="导 入" OnDirectClick="btnImport_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>

            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
