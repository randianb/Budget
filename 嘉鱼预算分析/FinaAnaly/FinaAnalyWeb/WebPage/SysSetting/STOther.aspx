<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STOther.aspx.cs" Inherits="WebPage_SysSetting_STOther" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script type="text/javascript">
        var gridCommand = function (sender, command, record) {
            switch (command) {
                case "Modify":
                    App.direct.Modify_Handler(record.data.BudID);
                    break;
                case "Delete":
                    App.direct.Delete_Handler(record.data.BudID);
                    break;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server">
            </ext:ResourceManager>
            <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
                <Items>
                    <ext:Panel ID="Panel1"
                        runat="server"
                        Title="导入财政数据">
                        <Items>
                        </Items>
                    </ext:Panel>
                    <ext:Toolbar ID="Toolbar24" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                        <Items>
                            <ext:Toolbar ID="Toolbar25" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                                <Items>
                                    <ext:ToolbarFill></ext:ToolbarFill>
                                    <ext:Hidden ID="hidID" runat="server"></ext:Hidden>
                                    <ext:Label ID="Label16" runat="server" Text="系统名称："></ext:Label>
                                </Items>
                            </ext:Toolbar>
                            <ext:Panel ID="Panel15" runat="server" ColumnWidth="0.8" Height="50">
                                <Items>
                                    <ext:TextField ID="TFSysName" runat="server" PaddingSpec="10 0 0 15" Height="25" Width="150" Name="SysName" />
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Toolbar>
                    <ext:Toolbar ID="Toolbar26" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                        <Items>
                            <ext:Toolbar ID="Toolbar27" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                                <Items>
                                    <ext:ToolbarFill></ext:ToolbarFill>
                                    <ext:Label ID="Label17" runat="server" Text="默认年份："></ext:Label>
                                </Items>
                            </ext:Toolbar>
                            <ext:Panel ID="Panel16" runat="server" ColumnWidth="0.8" Height="50">
                                <Items>
                                    <ext:TextField ID="TFDefaultYear" runat="server" PaddingSpec="10 0 0 15" Height="25" Width="150" Name="DefaultYear" />

                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Toolbar>
                    <ext:Toolbar ID="Toolbar28" runat="server" Height="50" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                        <Items>
                            <ext:Toolbar ID="Toolbar29" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                                <Items>
                                    <ext:ToolbarFill></ext:ToolbarFill>
                                    <ext:Label ID="Label18" runat="server" Text="基本人数："></ext:Label>
                                </Items>
                            </ext:Toolbar>
                            <ext:Panel ID="Panel17" runat="server" ColumnWidth="0.8" Height="50">
                                <Items>
                                    <ext:TextField ID="TFPopNum" runat="server" PaddingSpec="10 0 0 15" Height="25" Width="150" Name="PepNum" />
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Toolbar>
                    <ext:Toolbar ID="Toolbar34" runat="server" Height="40">
                        <Items>
                            <ext:Button ID="btnSure" runat="server" Text="确定" Icon="ApplicationAdd" Height="25">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Items>
            </ext:Viewport>


        </div>
    </form>
</body>
</html>

