<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UniformRulesaMod.aspx.cs" Inherits="WebPage_Policy_UniformRulesaMod" ValidateRequest="false" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:HtmlEditor ID="HEdit" runat="server" Region="Center" ToFrontOnShow="False" Text="">
                </ext:HtmlEditor>
                <ext:Toolbar ID="Toolbar2" runat="server" Region="South" PaddingSpec="0 0 12 0">
                    <Items>
                        <ext:Button ID="btnMod" runat="server" Text="修改" Icon="ApplicationEdit" OnDirectClick="btnMod_DirectClick"></ext:Button>
                        <ext:Button ID="btnBack" runat="server" Text="返回" Icon="PageBack" OnDirectClick="btnBack_DirectClick"></ext:Button>
                    </Items>
                </ext:Toolbar>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
