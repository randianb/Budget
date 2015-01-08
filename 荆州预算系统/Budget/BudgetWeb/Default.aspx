<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server"> 
</script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>  
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script>
        //var FirstPage = function () {
        //     this.up('plCenter').add({
        //         xtype: 'panel',
        //         title: "首页",
        //         loader: { url: "WebPage\Policy\PLNavigate.aspx" },
        //         closable: false
        //     });
        //    }
        //var CloseAllTabs = function (tabPanel, record) {
        //    var tab = tabPanel.getComponent(record.getId());
        //    plCenter.each(function (tab) {
        //        alert("sssssss");
        //        if (tab != "tabHome")
        //        { plCenter.remove(tab); };
        //    });
        //}

        //var CloseTab = function () {
        //    //1.获取当前打开(激活)的选项卡
        //    var tab = plCenter.getActiveTab(); //当前tab的id：
        //    //Ext.Msg.alert("信息2", tab.id);
        //    //2.关闭该打开的选项卡 
        //    plCenter.closeTab(tab);
        //}
        //var CloseAll_Tab = function () {
        //    //1.获取当前打开(激活)的选项卡
        //    var tab = plCenter.getActiveTab(); //当前tab的id：
        //    //Ext.Msg.alert("信息2", tab.id);
        //    //2.关闭该打开的选项卡 
        //    plCenter.closeTab(tab);
        //}
        var getnewpanel = function (tab) { 
            if (tab.id == "NodeBC5") {
                //aalert("a"); var sessiontmp = "";
//                var sessiontmp = "";
                var str = "http://" + location.hostname + ":" + location.port + "/";
                var params = str + 'WebPage/BudgetControl/SessionAJAX.ashx?t=' + new Date().toString();
//                //alert(params);
//                jQuery.ajax({
//                    type: "post",
//                    url: params,
//                    datatype: "json",
//                    contentType: "application/json; charset=utf-8",
//                    success: function (data) {
//                        sessiontmp = data.toString();
//                        //alert(data.toString());
//                    }
//                });
//               var session = sessiontmp;
                //alert(getsession());
               $.post(params, function (data) {
                    if (data != null) { 
                        if (data.toString() == "0") {
                            alert("您填写的月度用款计划尚未提交，\n未提交的月度用款计划将不会被送审");
                            App.direct.GetPayNewTab();
                        }
                        if (data.toString() == "1") {
                            
                        }
                    }
                });
//                alert(session);
//                if (session.toString() == "0") {
//                    alert("您填写的月度用款计划尚未提交，\n未提交的月度用款计划将不会被送审");
//                    App.direct.GetPayNewTab();
//                }
            }
        } 
        function getsession() { 
            var sessiontmp = "";
            var str="http://"+location.hostname+":"+location.port+"/";
            var params = str+ 'WebPage/BudgetControl/SessionAJAX.ashx?t=' + new Date().toString();
            //alert(params);
            jQuery.ajax({
                type: "post",
                url: params,
                datatype: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    sessiontmp = data.toString();
                    alert(data.toString());
                }
            });
            return sessiontmp;
        }
        var Dellist = function (tab) {
            var teburl = tab.loader.url;
            App.direct.Dellistitem(teburl);
        }
        
        var GetTab = function (tab_tem) {
            var tab_temurl = tab_tem.loader.url;
            App.direct.GetNewTab(tab_temurl);
        }
        var loadPage = function (tabPanel, record) {
            var tab = tabPanel.getComponent(record.getId());
            App.direct.Addlistitem(record.data.href);
            if (parseInt(record.getId())) {
                window.open(record.data.href);
                return;
                
            }
            //document.getElementById("HidID").value = record.getId();
            //document.getElementById("HidUrl").value += record.data.href + "*";
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

    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:HiddenField  runat="server" ID="Hidstname"/>
            <ext:Label ID="Label4" runat="server" Icon="UserGo"></ext:Label>
                        <asp:LinkButton ID="lkBtn" runat="server" OnClick="lkBtn_Click">退出</asp:LinkButton>--%>
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <div style=" position: absolute; right: 80px;top: 37px;">  <ext:LinkButton PaddingSpec="1 0 0 0" ID="Button1" runat="server"  Text="修改密码"> <Listeners>
                    <Click Handler="#{Window1}.show()" />
                </Listeners> </ext:LinkButton></div> <div style=" position: absolute; right: 20px;top: 37px;"><ext:Label ID="Label4" runat="server" Icon="UserGo"></ext:Label>
                        <asp:LinkButton ID="lkBtn" runat="server" OnClick="lkBtn_Click" style="font-size: 12px;">退出</asp:LinkButton></div>
        <ext:Viewport ID="FormPanel1" runat="server" Layout="BorderLayout">
            <Content>
                <ext:Hidden runat="server" ID="Hidstname"></ext:Hidden>
                <div id="FloatDIV" style="position: absolute; right: 15px; top: 20px; border: 0px">
                    <ext:Button ID="CloseAllPages" Hidden="true" runat="server" Text="关闭所有页" MarginSpec="0 0 8 0" OnDirectClick="CloseAllPages_DirectClick">
                        <%--<Listeners>
                            <Click Fn="CloseAllTabs" />
                        </Listeners> --%>
                    </ext:Button>
                    <ext:Button ID="ClosePage" Hidden="true" runat="server" Text="关闭当前页">
                        <%--<Listeners>
                            <Click Fn="Close_Tab" />
                        </Listeners> --%>
                        <Listeners>
                            <Click Handler="GetTab(#{plCenter}.getActiveTab());#{plCenter}.closeTab((#{plCenter}.getActiveTab())); "></Click>
                        </Listeners>
                    </ext:Button>
                </div>
            </Content>
            <Items>
                <%--Top:头部--%>
                <ext:Panel ID="plTop" runat="server" Height="90" Region="North" Title="North" AutoScroll="false" Header="false" Border="false" Margins="0" Padding="0"> 
                    <Loader ID="ldTop" runat="server" Url="Top.aspx" Mode="Frame">
                    </Loader>
                </ext:Panel>
                <%--Right:右边--%>
                <ext:Panel   ID="plRight" runat="server" Collapsible="true" Collapsed="true" IconCls="" Region="East" Split="true" Title="政策指导" Width="320">
                    <Loader ID="lbPolicy" runat="server" Url="WebPage/Policy/PolicyList.aspx" Mode="Frame">
                    </Loader> 
                </ext:Panel>

                <%--bottom:底部--%>
                <ext:Panel ID="plBottom" runat="server" Height="20" Region="South" Title="South" Header="false" Border="false">
                    <Loader ID="ldBottom" runat="server" Url="Bottom.html" Mode="Frame">
                    </Loader>
                </ext:Panel>

                <%--Left:左边--%>
                <ext:Panel  CollapseMode="Mini" ID="plLeft" runat="server" Collapsible="true" Layout="accordion" Region="West" Split="true" Title="导航" Width="175">
                    <Items>

                        <%--政策指导--%>
                        <ext:Panel ID="plGuide" runat="server" Border="false" Collapsed="True" Icon="FolderGo" Title="政策指导">
                            <Items>

                                <ext:TreePanel
                                    ID="TPGuide"
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

                        <%--基本设置--%>
                        <ext:Panel ID="plBaseSetting" runat="server" Border="false" Collapsed="true" Icon="Cog" Title="基本设置">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBaseSetting"
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

                        <%--预算测算--%>
                        <ext:Panel ID="plBudgetPreview" runat="server" Border="false" Collapsed="true" Icon="Computer" Title="预算测算">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetPreview"
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
                        </ext:Panel>

                        <%--预算编辑--%>
                        <ext:Panel ID="plBudgetEdit" runat="server" Border="false" Collapsed="true" Icon="BookEdit" Title="预算编辑">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetEdit"
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
                                        <ext:TreeStore ID="TreeStore4" runat="server" OnReadData="GetExNodes4">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <%--预算控制--%>
                        <ext:Panel ID="plBudgetControl" runat="server" Border="false" Collapsed="true" Icon="DatabaseWrench" Title="预算控制">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetControl"
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
                                        <ext:TreeStore ID="TreeStore5" runat="server" OnReadData="GetExNodes5">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <%--预算执行--%>
                        <ext:Panel ID="plBudgetExecute" runat="server" Border="false" Collapsed="true" Icon="LapTopStart" Title="预算执行">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetExecute"
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

                        <%--预算分析--%>
                        <ext:Panel ID="plBudgetAnalyse" runat="server" Border="false" Collapsed="true" Icon="ChartBar" Title="预算分析">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetAnalyse"
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
                                        <ext:TreeStore ID="TreeStore7" runat="server" OnReadData="GetExNodes7">
                                        </ext:TreeStore>
                                    </Store>
                                    <Listeners>
                                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{plCenter}, record); }" />
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>
                        <%--下载--%>
                        <ext:Panel ID="plBudgetDownload" runat="server" Border="false" Collapsed="true" Icon="DiskDownload" Title="下载专区">
                            <Items>
                                <ext:TreePanel
                                    ID="TPBudgetDownload"
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
                                        <ext:TreeStore ID="TreeStore8" runat="server" OnReadData="GetExNodes8">
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
                        <ext:TabCloseMenu ID="TabClose" CloseAllTabsText="关闭全部标签" CloseOthersTabsText="关闭其他标签" CloseTabText="关闭当前标签" runat="server">
                        </ext:TabCloseMenu>
                    </Plugins>
                    <Listeners>
                        <BeforeTabClose Handler="getnewpanel(tab)"></BeforeTabClose>
                        <TabClose Handler="Dellist(tab);"></TabClose>
                    </Listeners>

                    <%--                 <Items>
                        <ext:Panel
                            ID="tabHome"
                            runat="server"
                            Title="首页"
                            HideMode="Offsets"
                            Icon="Application">
                            <Loader ID="Loader1" runat="server" Mode="Frame" Url="WebPage\Policy\PLNavigate.aspx">
                                <LoadMask ShowMask="false" />
                            </Loader>
                        </ext:Panel>
                    </Items>--%>
                </ext:TabPanel>
               <ext:Window runat="server" ID="Window1" Width="350" Height="120" Hidden="True" Title="密码修改"    Layout="Form"　BodyPadding="5"> <Defaults>
                <ext:Parameter Name="LabelWidth" Value="60" Mode="Raw" />
            </Defaults>
                  <Items><ext:TextField 
                    ID="PasswordField" 
                    runat="server"                    
                    FieldLabel="密　　码"
                    InputType="Password" 
                    AllowBlank="false" 
                    AnchorHorizontal="100%"　Regex="^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,16}$"  RegexText="由数字和字母组成，并且要同时含有数字和字母，且长度要在8-16位之间" MsgTarget="Side" >
                        <Listeners>
                            <ValidityChange Handler="this.next().validate();" />
                            <Blur Handler="this.next().validate();" />
                        </Listeners>
                    </ext:TextField>
                <ext:TextField 　
                    runat="server"                     
                    Vtype="password"
                    FieldLabel="确认密码"
                    InputType="Password"
                    MsgTarget="Side" 
                    AnchorHorizontal="100%"  >     
                    <CustomConfig>
                        <ext:ConfigItem Name="initialPassField" Value="PasswordField" Mode="Value" />
                    </CustomConfig>                      
                </ext:TextField> </Items>
                   <Buttons><ext:Button runat="server" Text="确定" ID="btnsure" OnDirectClick="btnsure_OnDirectClick" ></ext:Button><ext:Button ID="btncs"  Text="取消" runat="server"><Listeners><Click  Handler="#{Window1}.hide()"></Click></Listeners></ext:Button></Buttons>
               </ext:Window>
            </Items> 
        </ext:Viewport>
    </form>
</body>
</html>
