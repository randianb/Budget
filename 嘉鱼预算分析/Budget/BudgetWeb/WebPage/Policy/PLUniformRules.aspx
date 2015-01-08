<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PLUniformRules.aspx.cs" Inherits="WebPage_Policy_PLUniformRules" ValidateRequest="false" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .docTitleCls
        {
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
<%--        <ext:FormPanel runat="server" X="40" Y="250" Border="false">
            <Items>
                <ext:Window ID="WinEdit" runat="server"
                    Title="文本编辑"
                    Width="500"
                    Height="400"
                    Icon="ApplicationForm"
                    AnimCollapse="false"
                    Border="false"
                    HideMode="Offsets"
                    Layout="BorderLayout"
                    CloseAction="Hide"
                    Hidden="true">

                    <Items>
                        <ext:HtmlEditor ID="HEdit" runat="server" Region="Center" Text="">
                        </ext:HtmlEditor>
                        <ext:Toolbar ID="Toolbar2" runat="server" Region="South">
                            <Items>
                                <ext:Button ID="btnMod" runat="server" Text="修改" Icon="ApplicationEdit" OnDirectClick="btnMod_DirectClick"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Window>
            </Items>
        </ext:FormPanel>--%>

        <ext:Toolbar runat="server">
            <Items>
                <ext:Button runat="server" OnDirectClick="btnModUR_DirectClick" Text="修改"></ext:Button>
            </Items>
        </ext:Toolbar>
        <%=ctext %>







        <%--        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout">
            
        </ext:Viewport>--%>
        <%--<ext:Viewport runat="server" Layout="FitLayout">--%>
        <%--<Content>--%>
        <%--</Content>--%>
        <%--<Items>--%>
        <%--<ext:Panel ID="plContent" runat="server" Header="false" Layout="HBoxLayout" Border="false">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="btnModUR" runat="server" Text="修改" Icon="ApplicationEdit" OnDirectClick="btnModUR_DirectClick">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <LayoutConfig>
                        <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                    </LayoutConfig>
                    <Items>
                        <ext:Container ID="KJEditor" runat="server" AutoHeight="true"></ext:Container>
                    </Items>
                </ext:Panel>--%>

        <%--            </Items>
        </ext:Viewport>--%>
    </form>

</body>
</html>
