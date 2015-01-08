<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelMonPayPlan.aspx.cs" Inherits="BudgetPage_mainPages_SelMonPayPlan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查询月度用款计划</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../css/mytable.js"></script>

    <style type="text/css">
        html, body
        {
            overflow: scroll;
            overflow-y: hidden;
            margin: 0;
            height: 100%;
        }

        .txt
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            margin-left: 0px;
            width: 180px;
            height: 20px;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头结束 -->
        <%--<div class="table_list">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
            <tr>
                <td colspan="2" class="tr1">
                    &nbsp;<strong>查询月度用款计划</strong>
                </td>
            </tr>

            <tr>
                <td width="20%" class="tr1" align="right">
                    年份:
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlYear" CssClass="txt" runat="server" >
                        <asp:ListItem>2014</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  width="20%" class="tr1" align="right">
                    月份:
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMon" CssClass="txt" runat="server" >
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td width="20%" class="tr1 right">
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSearch" CssClass="btns" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="8" class="tr1" align="left">
                    &nbsp;<strong>查询月度用款计划表</strong>
                </td>
            </tr>
            <tr>
                <td  width="12%" class="tr1" align="center">
                    经济科目
                </td>
                <td  width="12%" class="tr1" align="center">
                    本年预算指示
                </td>
                <td  width="12%" class="tr1" align="center">
                    本年调整
                </td>
                <td  width="12%" class="tr1" align="center">
                    余额
                </td>
                <td  width="12%" class="tr1" align="center">
                    基本支出
                </td>
                <td  width="13%" class="tr1" align="center">
                    项目支出
                </td>
                <td width="13%" class="tr1" align="center">
                    合    计
                </td>
                <td width="12%" class="tr1" align="center">
                    修    改
                </td>
            </tr>
            <asp:Repeater ID="repBudCon" runat="server" 
                onitemcommand="repBudCon_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("PIEcoSubName")%>
                        </td>
                        <td>
                            <%#Eval("TYBusIns")%>
                        </td>
                        <td>
                            <%#Eval("TYAdj")%>
                        </td>
                        <td>
                            <%#Eval("MPBalance")%>
                        </td>
                        <td>
                            <%#Eval("MABasicExp")%>
                        </td>
                        <td>
                            <%#Eval("MAProExp")%>
                        </td>
                        <td>
                            <%#Eval("MATotal")%>
                        </td>
                         <td>
                            <asp:LinkButton ID="linkAlter" CommandName="UpdBI" CommandArgument='<%#Eval("CAID")%>' runat="server" Text="修改"></asp:LinkButton>
                         </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="8" class="tr1" align="center">
                    <webdiyer:AspNetPager ID="BudExeListPager" Width="500" ImagePath="~/images/PagerGif"
                        NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                        ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                        PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>--%>
        
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="ViewPort1" runat="server" Layout="FitLayout">
            <Items>


                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server" Layout="ColumnLayout" AutoScroll="true"
                    Title="查询月度用款计划">

                    <Store>
                        <ext:Store ID="AuditStore" runat="server" PageSize="17">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="DepName" Type="string" /> 
                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                        <ext:ModelField Name="MPFunding" Type="float" />
                                        <ext:ModelField Name="MASta" Type="string" />
                                        <ext:ModelField Name="MACause" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="cmAudit" runat="server" >
                        <Columns>
                            <ext:Column Sortable="true" ID="clDepName" runat="server" Text="部门名称" Flex="1" DataIndex="DepName" />
                            <ext:Column Align="center" ID="clPIEcoSubName" runat="server" Text="经济科目" Flex="1" DataIndex="PIEcoSubName" />
                            <ext:Column Align="center" ID="clBAAMon" runat="server" Text="经费（元）" Flex="1" DataIndex="MPFunding">
                                <Renderer Handler="return (value * 10000)"></Renderer>
                            </ext:Column>
                            <ext:Column Align="center" ID="clBalance" runat="server" Text="审核状态" Flex="1" DataIndex="MASta" />
                            <ext:Column Align="center" ID="clMACause" runat="server" Text="原因" Flex="1" DataIndex="MACause" />
                        </Columns>
                    </ColumnModel>

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Layout="AnchorLayout" BaseCls="background:transparent">
                            <Items>
                                <ext:Panel ID="Container1" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="5 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label3" runat="server" MarginSpec="5 5 0 5" Text="部门名称：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbdept" runat="server" ColumnWidth="0.2" DisplayField="DepName">
                                            <Store>
                                                <ext:Store ID="cmbdeptstore" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model2" runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="DepName" Type="string"></ext:ModelField>
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
                                <ext:Panel Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="年　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbyear" runat="server" ColumnWidth="0.2" DisplayField="Year">
                                            <Store>
                                                <ext:Store ID="cmbyearstore" runat="server">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="Year"></ext:ModelField>
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
                                <ext:Panel Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" MarginSpec="5 5 0 5" Text="月　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox MinWidth="60" ID="cmbmonth" runat="server" ColumnWidth="0.2">
                                            <Items>
                                                <ext:ListItem Text="1" Value="01" />
                                                <ext:ListItem Text="2" Value="02" />
                                                <ext:ListItem Text="3" Value="03" />
                                                <ext:ListItem Text="4" Value="04" />
                                                <ext:ListItem Text="5" Value="05" />
                                                <ext:ListItem Text="6" Value="06" />
                                                <ext:ListItem Text="7" Value="07" />
                                                <ext:ListItem Text="8" Value="08" />
                                                <ext:ListItem Text="9" Value="09" />
                                                <ext:ListItem Text="10" Value="10" />
                                                <ext:ListItem Text="11" Value="11" />
                                                <ext:ListItem Text="12" Value="12" />
                                            </Items>
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Button  Icon="Accept" runat="server" MarginSpec="0 0 5 0" ID="submit" OnDirectClick="submit_DirectClick" Text="确定"></ext:Button>
                                <ext:Panel runat="server" Title="查询月度用款计划" />
                            </Items>
                            
                        </ext:Toolbar>
                    </TopBar> 
                </ext:GridPanel>



            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
