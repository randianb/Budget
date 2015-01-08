<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudConList.aspx.cs" Inherits="BudgetPage_mainPages_BudConList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预算控制列表</title>
    <script src="../css/mytable.js" type="text/javascript"></script>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body {
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HidYear" runat="server" />
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width: 100%;">
                <tr>
                    <td class="tr1" align="left">&nbsp;<strong><%=CurrentYear %>年度省级预算控制</strong>
                    </td>
                    <td class="tr1" align="right">单位（万元）</td>
                </tr>
                <tr>
                    <td width="14%" class="tr1" align="center">项目名称
                    </td>
                    <td width="14%" class="tr1" align="center">经费
                    </td>

                </tr>
                <asp:Repeater ID="repBudConList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("PPID")%>
                            </td>
                            <td>
                                <%# Eval("ProPA0M")%>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="600" ImagePath="~/images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width: 100%;">
                <tr>
                    <td colspan="6" class="tr1" align="left">&nbsp;<strong><%=CurrentYear %>年度本地区预算控制</strong>
                    </td>
                </tr>
                <tr>
                    <td width="14%" class="tr1" align="center">项目名称
                    </td>
                    <td width="14%" class="tr1" align="center">经费
                    </td>
                    <%--<td width="14%" class="tr1" align="center">
                </td>--%>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Detail">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("BIProType")%>
                            </td>
                            <td>
                                <%# Eval("Mon")%>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="BudConListPager" Width="600" ImagePath="~/img/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width: 100%;">
                <tr>
                    <td colspan="6" class="tr1" align="left">&nbsp;<strong><%=CurrentYear %>本年度基本支出预算金额显示</strong>
                    </td>
                </tr>
                <tr>
                    <td width="14%" class="tr1" align="center">项目名称
                    </td>
                    <td width="14%" class="tr1" align="center">经费
                    </td>
                    <%--<td width="14%" class="tr1" align="center">
                </td>--%>
                </tr>
                <tr>
                    <td>基本支出
                    </td>
                    <td>
                      <%= Session["BaseMon"]%>
                    </td>

                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width: 100%;">
                <tr>
                    <td width="14%" class="tr1" align="center">合计
                    </td>
                    <td width="14%" class="tr1" align="center">
                        <%= Session["TotalMon"]%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
