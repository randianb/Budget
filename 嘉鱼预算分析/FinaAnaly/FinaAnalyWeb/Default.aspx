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
                    //autoScroll: true
                });
            }

            tabPanel.setActiveTab(tab);
        };
    </script>
    <style type="text/css">
        #menu {
            font: 13px verdana, arial, sans-serif;
        }

            #menu, #menu li {
                list-style: none;
                padding: 20px 10px 10px 10px;
                margin: 0;
                float: left;
            }

                #menu li a {
                    /*display:block;*/
                    width: 530px;
                    height: 20px;
                    /*line-height:20px;*/
                    /*padding:20px 20px;*/
                    text-align: center;
                    text-decoration: none;
                }

        .fontstrong {
            font-size: 34px;
            font-family: '微软雅黑';
            font-weight: bolder;
            color: #fff;
        }
    </style>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="Viewport1" runat="server" Layout="border">
            <Items>
                <%--Top:头部--%>
                <%--Top:头部--%>
                <ext:Panel ID="plTop" BodyStyle="background: url(img/bg/s1.jpg)  repeat-x ; margin: 0px; padding: 0px;" runat="server" Height="80" Region="North" Title="North" Header="false" Border="false">
                    <%--<Loader ID="ldTop" runat="server" Url="Top.aspx" Mode="Frame">
                    </Loader>--%>
                    <Content>
                        <%--<div style="font-size: 36px; font-family: 微软雅黑; font-weight: bold; position: absolute; left: 180px; top: 30px;">
                            武汉市江岸区地税财务分析系统
                        </div>--%>
                        <%--<div style="position: absolute; left: 5px; top: 2px;">
                            <image src="img/bg/s2.jpg" style="width: 64px; height: 60px; margin-left: 6px;"></image>
                        </div>--%>
                        <div style="position: absolute; left: 200px; top: 20px; vertical-align: middle;">
                            <strong class="fontstrong">
                                <p class="weltitle">
                                    <img src="img/bg/111.png" />
                                </p>

                            </strong>
                        </div>
                    </Content>
                    <Items>
                        <ext:Toolbar ID="tb1" runat="server" Border="false" BaseCls="background:transparent" Layout="ColumnLayout">
                            <Items>
                                <ext:Image ID="img1" runat="server" ImageUrl="img/bg/s2.jpg" Width="177" Border="false" Header="false"></ext:Image>
                                <%--   <ext:Image ID="Image2" runat="server" ImageUrl="img/bg/111.png" Width="180" Border="false" Header="false" style="font-size: 36px;font-weight: bold; position: absolute;left: 180px; top: 30px;"></ext:Image>--%>
                                <ext:Label ID="Label1" runat="server" ColumnWidth="1"></ext:Label>
                                <ext:Panel ID="Image1" runat="server" Border="false" BodyStyle="background:url(img/bg/s3.jpg) ">
                                    <Content>
                                        <div style="float: right; width: 630px; height: 90px;">
                                            <ul id="menu">
                                                <li>
                                                    <ext:Label ID="Label2" runat="server" Icon="Folder" Text="使用单位："></ext:Label>
                                                    <ext:Label ID="Label3" runat="server" Text="江岸区"></ext:Label>
                                                </li>
                                                <li>
                                                    <ext:Label ID="Label7" runat="server" Icon="Group" Text="当前部门："></ext:Label>
                                                    <ext:Label ID="lbDep" runat="server" Text=""></ext:Label>
                                                </li>
                                                <li>
                                                    <ext:Label ID="Label4" runat="server" Icon="UserB" Text="用户名："></ext:Label>
                                                    <ext:Label ID="lbUser" runat="server" Text=""></ext:Label>
                                                </li>
                                                <li>
                                                    <ext:Label ID="Label5" runat="server" Icon="UserGo"></ext:Label>
                                                    <asp:LinkButton ID="lbtnExit" runat="server" Text="退出" OnClick="lbtnExit_Click"></asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Toolbar>
                    </Items>

                </ext:Panel>


                <%-- <%--Right:右边--%>
                <%--<ext:Panel ID="plRight" runat="server" Collapsible="true" Region="East" Split="false" Title="政策指导" Width="175">
                    <Loader ID="lbPolicy" runat="server" Url="WebPage/CusAnaly/PolicyList.aspx" Mode="Frame">
                    </Loader>
                </ext:Panel>--%>

                <%--bottom:底部--%>
                <ext:Panel ID="plBottom" runat="server" Height="20" Region="South" Title="South" Header="false" Border="false">
                    <Loader ID="ldBottom" runat="server" Url="Bottom.html" Mode="Frame">
                    </Loader>
                </ext:Panel>


                <%--Left:左边--%>
                <ext:Panel ID="plLeft" runat="server" Collapsible="true" Layout="accordion" Region="West" Split="true" Title="财务分析系统" Width="210">
                    <Items>

                        <%--系统设置--%>
                        <ext:Panel ID="plSysSetting" runat="server" Border="false" Collapsed="True" Icon="Cog" Title="系统设置">
                            <Items>

                                <ext:TreePanel
                                    ID="TPSysSetting"
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

                        <%--预算执行情况分析--%>
                        <ext:Panel ID="plAccInquiry" runat="server" Border="false" Collapsed="true" Icon="Zoom" Title="预算执行情况分析">
                            <Items>
                                <ext:TreePanel
                                    ID="TPAccInquiry"
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

                        <%--部门经费支出明细表--%>
                        <ext:Panel ID="plCusAnaly" runat="server" Border="false" Collapsed="True" Icon="FolderGo" Title="部门经费支出明细表">
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
                                        <ext:TreeStore ID="TreeStore4" runat="server" OnReadData="GetExNodes3">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <%--经费支出分析明细表--%>
                        <ext:Panel ID="plDataAnaly" runat="server" Border="false" Collapsed="true" Icon="BookEdit" Title="经费支出分析明细表">
                            <Items>
                                <ext:TreePanel
                                    ID="TPDataAnaly"
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
                                        <ext:TreeStore ID="TreeStore3" runat="server" OnReadData="GetExNodes5">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <%--自选分析--%>
                        <ext:Panel ID="plOptAnaly" runat="server" Border="false" Collapsed="true" Icon="ApplicationForm" Title="自选分析">
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
                                        <ext:TreeStore ID="TreeStore5" runat="server" OnReadData="GetExNodes4">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>


                        <%--科、所经费查询--%>
                        <ext:Panel ID="Panel1" runat="server" Border="false" Collapsed="true" Icon="ZoomIn" Title="科所经费查询">
                            <Items>
                                <ext:TreePanel
                                    ID="TreePanel1"
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
                                        <ext:TreeStore ID="TreeStore6" runat="server" OnReadData="GetExNodes6">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>


                <%--Center:中间--%>
                <ext:TabPanel ID="plCenter" runat="server" Region="Center" Title="Center" Header="false">
                    <Plugins>
                        <ext:TabCloseMenu ID="TabCloseMenu1" CloseAllTabsText="关闭全部标签" CloseOthersTabsText="关闭其他标签" CloseTabText="关闭当前标签" runat="server">
                        </ext:TabCloseMenu>
                    </Plugins>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

