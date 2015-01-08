<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudConExeList.aspx.cs" Inherits="mainPages_BudConExeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预算控制执行表</title>
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
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头开始 -->
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px; width:100%;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>查询</strong>
                    </td>
                </tr>

                <tr>
                    <td width="20%" class="tr1 right">选择年份
                    </td>
                    <td>&nbsp;&nbsp;
                    
                    <asp:DropDownList ID="ddlyear" runat="server" Width="150px">
                        <%--<asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem Selected="True">2013</asp:ListItem>--%>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">选择月份
                    </td>
                    <td>&nbsp;&nbsp;
                    
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                        <asp:ListItem Selected="True">01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>

                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                    <asp:Button ID="btnInq" CssClass="btns" runat="server" Text=" 查询 " OnClick="btnInq_Click" />

                        <asp:Label ID="lanotice" runat="server" Text="" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width:100%;">
                <tr>
                    <td colspan="5" class="tr1" align="left">&nbsp;<strong>预算控制执行表</strong>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1" align="center">部门名称
                    </td>
                    <td width="15%" class="tr1" align="center">年初预算（万元）
                    </td>
                    <td width="15%" class="tr1" align="center">本年调整（万元）
                    </td>
                    <td width="15%" class="tr1" align="center">累计使用（万元）
                    </td>
                    <td width="15%" class="tr1" align="center">执行比
                    </td>
                </tr>
                <asp:Repeater ID="repBudCon" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("DepName")%>
                            </td>
                            <td>
                                <%#Eval("ARMon")%>
                            </td>
                            <td>
                                <%#Eval("ChangeMon")%>
                            </td>
                            <td>
                                <%#Eval("UserMon")%>
                            </td>
                            <td>
                                <%#Eval("Pecent")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="5" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="BudExeListPager" Width="500" ImagePath="~/images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
