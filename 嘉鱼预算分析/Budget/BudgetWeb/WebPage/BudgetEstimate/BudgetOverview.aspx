<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetOverview.aspx.cs" Inherits="WebPage_BudgetEstimate_BudgetOverview" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">

        var Blur1 = function (sender, command, record) {


        }
        var Blur2 = function (sender, command, record) {


        }
        var Blur2 = function () {
            //var txt2 = Ext.get("TextField2").Value;
            //var hidValue = Ext.get("hid").Value;

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="AnchorLayout">
            <Items>


                <ext:FormPanel BaseCls="transeparent" ID="FormPanel2"
                    runat="server"
                    Title="Form Panel"
                    BodyStyle="padding:5px 5px 0;"
                    Border="false"
                    Header="false"
                    Layout="HBoxLayout">

                    <FieldDefaults LabelAlign="top" MsgTarget="Side" />

                    <Defaults>
                        <ext:Parameter Name="Border" Value="false" />
                        <ext:Parameter Name="Flex" Value="1" />
                        <ext:Parameter Name="Layout" Value="anchor" />
                    </Defaults>
                    <Items>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" Border="true" ID="Toolbar1" runat="server" PaddingSpec="24 0 0 20" Html="基本支出(预算设置最大数额)"  Height="80">
                        </ext:Toolbar>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar2" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label3" runat="server" Text="支出" BorderSpec="0 0 1 0"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <%--  <ext:Panel ID="Panel4" runat="server" Border="false" Html="基本支出" AnchorHorizontal="10" BaseCls=" background:transparent;"></ext:Panel>--%>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="Panel5" runat="server" Border="false" Html="人员支出" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="Panel6" runat="server" Border="false" Html="公用支出" AnchorHorizontal="10" BaseCls=" background:transparent;"></ext:Panel>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar3" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label4" runat="server" Text="编制人员数"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:TextField PaddingSpec="0 0 0 20" ID="para1" runat="server" AnchorHorizontal="60%" MarginSpec="5 0 0 0" />
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar4" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label5" runat="server" Text="人均标准(万元 )"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:TextField PaddingSpec="0 0 0 20" ID="para2" runat="server" AnchorHorizontal="60%" MarginSpec="5 0 0 0" />
                                <ext:TextField PaddingSpec="0 0 0 20" ID="para3" runat="server" AnchorHorizontal="60%" MarginSpec="5 0 0 0">
                                </ext:TextField>
                            </Items>
                        </ext:Toolbar>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar13" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label12" runat="server" Text="　　" ></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>

                <ext:FormPanel BaseCls="transeparent" ID="FormPanel1"
                    runat="server"
                    Title="Form Panel"
                    BodyStyle="padding:5px 5px 0;"
                    Border="false"
                    Header="false"
                    Layout="HBoxLayout">

                    <FieldDefaults LabelAlign="top" MsgTarget="Side" />

                    <Defaults>
                        <ext:Parameter Name="Border" Value="false" />
                        <ext:Parameter Name="Flex" Value="1" />
                        <ext:Parameter Name="Layout" Value="anchor" />
                    </Defaults>

                    <Items>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" Border="true" ID="Panel1" runat="server" PaddingSpec="24 0 0 20" Html="填写(测算人均数)" Height="60">
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Panel2" runat="server" Border="true" Height="60" >
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="支出"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="Panel3" runat="server" Border="false" Html="人员支出" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar9" runat="server" Border="true" Height="60" >
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="测算数(万元)"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:TextField PaddingSpec="0 0 0 20" ID="para4" runat="server" AnchorHorizontal="60%" MarginSpec="5 0 0 0">
                                    <Listeners>
                                        <Blur Fn="Blur1"></Blur>
                                    </Listeners>
                                </ext:TextField>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar11" runat="server" Border="true" Height="60" >
                            <Items>
                                <ext:Label ID="Label10" runat="server" Text="实际数(万元)"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:TextField PaddingSpec="0 0 0 20" ID="para5" runat="server" AnchorHorizontal="60%" MarginSpec="5 0 0 0">
                                    <DirectEvents>
                                        <Blur OnEvent="gettext_Event"></Blur>
                                    </DirectEvents>
                                </ext:TextField>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar10" runat="server" Border="true" Height="60">
                            <Items>
                                <ext:Label ID="Label9" runat="server" Text="差额(万元)"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="val1" runat="server" Border="false" Html="0" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>

                <ext:FormPanel BaseCls="transeparent" ID="FormPanel3"
                    runat="server"
                    Title="Form Panel"
                    BodyStyle="padding:5px 5px 0;"
                    Border="false"
                    Header="false"
                    Layout="HBoxLayout">

                    <FieldDefaults LabelAlign="top" MsgTarget="Side" />

                    <Defaults>
                        <ext:Parameter Name="Border" Value="false" />
                        <ext:Parameter Name="Flex" Value="1" />
                        <ext:Parameter Name="Layout" Value="anchor" />
                    </Defaults>

                    <Items>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" Border="true" ID="Toolbar5" runat="server" PaddingSpec="24 0 0 20" Html="预演" Height="80">
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar7" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label7" runat="server" Text="预算总额（万元）"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="val2" runat="server" Border="false" Html="0" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar6" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label6" runat="server" Text="项目支出（万元）"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="val3" runat="server" Border="false" Html="0" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>

                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar8" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label8" runat="server" Text="不可预见费（万元）"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="val4" runat="server" Border="false" Html="0" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>
                        <ext:Toolbar BaseCls="transeparent" Flex="0" ID="Toolbar12" runat="server" Border="true" Height="80">
                            <Items>
                                <ext:Label ID="Label11" runat="server" Text="基本支出（万元）"></ext:Label><ext:MenuSeparator></ext:MenuSeparator>
                                <ext:Panel PaddingSpec="0 0 0 20" ID="val5" runat="server" Border="false" Html="0" AnchorHorizontal="10" BaseCls=" background:transparent;" MarginSpec="8 0 10 0"></ext:Panel>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>
                <ext:Panel runat="server" Border="false" Height="200" PaddingSpec="0 0 0 20"> 
                    <Content>
                        <div style="font-weight:bold;font-size:15px;" > 
                            1、填写编制人员数<br />
                            2、（人员支出和公用支出）的人均标准<br />
                            3、测算数<br />
                            4、实际数<br />
                            5、点击页面其他位置
                        </div>
                    </Content>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
