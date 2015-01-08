<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonPayPlan.aspx.cs" Inherits="BudgetPage_mainPages_MonPayPlan" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>生成月度用款计划</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <link href="../ExtJs4.0/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="../ExtJs4.0/ext-all-debug.js" type="text/javascript"></script>
    <script src="../ExtJs4.0/locale/ext-lang-zh_CN.js" type="text/javascript"></script>
    <style type="text/css">
        html, body {
            overflow: scroll;
            overflow-y: hidden;
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        
                              
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头结束 -->
       <%-- <div class="table_list">

            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>生成列表</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">部门名称
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDep" CssClass="txt" runat="server" Height="19px" Width="159px">
                          <asp:ListItem Value="1111">全局</asp:ListItem>
                         <asp:ListItem Value="1104">办公室</asp:ListItem>
                        <asp:ListItem Value="1105">人事科</asp:ListItem>
                        <asp:ListItem Value="1106">财务科</asp:ListItem>
                        <asp:ListItem Value="1107">纳税服务科</asp:ListItem> 
                       
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">年份
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlYear" CssClass="txt" runat="server" Height="19px" Width="159px">
                        <asp:ListItem>2014</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">月份
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMon" CssClass="txt" runat="server" Height="19px" Width="159px">
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
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;</td>

                </tr>
                <tr>
                    <td width="20%" class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" CssClass ="btns"  runat="server" Text="  查  询  " OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="8" class="tr1" align="left">&nbsp;<strong>生成月度用款计划</strong>
                    </td>
                </tr>
                <tr>
                    <td width="12%" class="tr1" align="center">经济科目
                    </td>
                    <td width="12%" class="tr1" align="center">本年预算指示
                    </td>
                    <td width="12%" class="tr1" align="center">本年调整
                    </td>
                    <td width="12%" class="tr1" align="center">余额
                    </td>
                    <td width="13%" class="tr1" align="center">基本支出
                    </td>
                    <td width="13%" class="tr1" align="center">项目支出
                    </td>
                    <td width="13%" class="tr1" align="center">合    计
                    </td>
                    <td width="13%" class="tr1" align="center">状    态
                    </td>
                </tr>
                <asp:Repeater ID="repBudConAudit" runat="server">
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
                                <%#Eval("MASta")%>
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
        </div>--%>
                <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="ViewPort1" runat="server">
            <Items>


                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server" Layout="ColumnLayout" AutoScroll="true" DefaultAnchor="100%"
                    Title="生成月度用款计划">

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
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column Sortable="true" ID="clDepName" runat="server" Text="部门名称" Flex="1" DataIndex="DepName" />
                            <ext:Column Align="center" ID="clPIEcoSubName" runat="server" Text="经济科目" Flex="1" DataIndex="PIEcoSubName" />
                            <ext:Column Align="center" ID="clBAAMon" runat="server" Text="经费" Flex="1" DataIndex="MPFunding" />
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
                                                                <ext:ModelField Name="DepName" Type="String"></ext:ModelField>
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
                                        <ext:ComboBox MinWidth="60" ID="cmbyear" runat="server" ColumnWidth="0.2 " DisplayField="Year">
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
                                <ext:Panel Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0">
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
                                <ext:Panel ID="Panel3" runat="server" Title="生成月度用款计划" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <BottomBar>
                         <ext:Toolbar ID="Toolbar2" runat="server" BaseCls="background:transparent" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container2" runat="server" ColumnWidth="1">
                                    <Content>
                                        <div class="table_list" style="padding: 0 0 0 0; margin: 0 0 0 0">
                                            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button ID="Button1" CssClass="btns" runat="server" Text="  审核通过 " OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="Button2" CssClass="btns" runat="server" Text="  审核不通过  " OnClick="btnSel_Click" ValidationGroup="AddBI"  />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 80px;">
                                                        <asp:Label ID="lbShow" runat="server" Text="不通过原因："></asp:Label>&nbsp;&nbsp; 
                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="txt" Height="50px" Width="300px"></asp:TextBox><span
                                                            style="color: red">*</span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReason"
                                                            Display="Dynamic" ErrorMessage="不通过原因不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>

                                                    </td>

                                                </tr> 
                                            </table>
                                        </div>
                                    </Content>
                                </ext:Container>
                                
                            </Items>

                        </ext:Toolbar>
                    </BottomBar>
                </ext:GridPanel>

            </Items>

        </ext:Viewport>

    </form>
</body>
