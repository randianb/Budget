<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        var loadPage = function (tabPanel, record) {
            var tab = tabPanel.getComponent(record.getId());

            if (!tab) {
                tab = tabPanel.add({
                    id: record.getId(),
                    title: record.data.text,
                    closable: true,
                    loader: {
                        url: record.data.href,
                        renderer: "frame",
                        loadMask: {
                            showMask: true,
                            msg: "Loading " + record.data.href + "..."
                        }
                    }, 
                });
            }

            tabPanel.setActiveTab(tab);
        };
    </script>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="Viewport1" runat="server" Layout="border">
            <Items>
                <%--Top:头部--%>
                <ext:Panel ID="plTop" runat="server" Height="90" Region="North" Title="North" Header="false" Border="false">
                    <Loader ID="ldTop" runat="server" Url="Top.aspx" Mode="Frame">
                    </Loader>
                </ext:Panel>

                <%--Right:右边--%>
                <ext:Panel ID="plRight" runat="server" Collapsible="true" Region="East" Split="false" Title="政策指导" Width="175">
                    <Loader ID="lbPolicy" runat="server" Url="WebPage/CusAnaly/PolicyList.aspx" Mode="Frame">
                    </Loader>
                </ext:Panel>

                <%--bottom:底部--%>
                <ext:Panel ID="plBottom" runat="server" Height="20" Region="South" Title="South" Header="false" Border="false">
                    <Loader ID="ldBottom" runat="server" Url="Bottom.html" Mode="Frame">
                    </Loader>
                </ext:Panel>


                <%--Left:左边--%>
                <ext:Panel ID="plLeft" runat="server" Collapsible="true" Layout="accordion" Region="West" Split="true" Title="导航" Width="175">
                    <Items>

                        <%--定制分析--%>
                        <ext:Panel ID="plCusAnaly" runat="server" Border="false" Collapsed="True" Icon="FolderGo" Title="定制分析">
                            <Items>

                                <ext:TreePanel
                                    ID="TPCusAnaly"
                                    runat="server"
                                    Header="false"
                                    AutoScroll="true"
                                    Lines="false"
                                    UseArrows="true"
                                    CollapseFirst="false"
                                    RootVisible="false"
                                    Border="false"
                                    Animate="true">

                                    <Store>
                                        <ext:TreeStore ID="TreeStore1" runat="server" OnReadData="GetExNodes1">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <%--自选分析--%>
                        <ext:Panel ID="plOptAnaly" runat="server" Border="false" Collapsed="true" Icon="Cog" Title="自选分析">
                            <Items>
                                <ext:TreePanel
                                    ID="TPOptAnaly"
                                    runat="server"
                                    Header="false"
                                    AutoScroll="true"
                                    Lines="false"
                                    UseArrows="true"
                                    CollapseFirst="false"
                                    RootVisible="false"
                                    Border="false"
                                    Animate="true">

                                    <Store>
                                        <ext:TreeStore ID="TreeStore2" runat="server" OnReadData="GetExNodes2">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <%--信息公开--%>
 <%--                       <ext:Panel ID="plInfoPublic" runat="server" Border="false" Collapsed="true" Icon="BookEdit" Title="信息公开">
                            <Items>
                                <ext:TreePanel
                                    ID="TPInfoPublic"
                                    runat="server"
                                    Header="false"
                                    AutoScroll="true"
                                    Lines="false"
                                    UseArrows="true"
                                    CollapseFirst="false"
                                    RootVisible="false"
                                    Border="false"
                                    Animate="true">

                                    <Store>
                                        <ext:TreeStore ID="TreeStore3" runat="server" OnReadData="GetExNodes3">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>--%>
                   
                    </Items>
                </ext:Panel>


                <%--Center:中间--%>
                <ext:TabPanel ID="plCenter" runat="server" Region="Center" Title="Center" Header="false">
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

