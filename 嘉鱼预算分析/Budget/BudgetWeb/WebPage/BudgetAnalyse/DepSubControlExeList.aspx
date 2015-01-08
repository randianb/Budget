<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepSubControlExeList.aspx.cs"
    Inherits="mainPages_DepSubControlExeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门项目执行表</title>
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
    <!-- 表头结束 -->
    <div class="table_list">
      <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
            <tr>
                <td colspan="2" class="tr1">
                    &nbsp;<strong>部门项目执行表查询</strong>
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    选择部门
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" CssClass="txt"  runat="server">
                        <asp:ListItem>办公室</asp:ListItem>
                        <asp:ListItem>人事科</asp:ListItem>
                        <asp:ListItem>财务科</asp:ListItem>
                        <asp:ListItem>纳税服务科</asp:ListItem>
                        <asp:ListItem>全局</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSel" CssClass ="btns"  runat="server" Text="查 询" OnClick="btnSel_Click" />
                </td>
            </tr>
        </table>
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="8" class="tr1" align="left">
                    &nbsp;<strong>部门项目执行表</strong>
                </td>
            </tr>
            <tr>
                <td class="tr1" align="center">
                    部门
                </td>
                <td class="tr1" align="center">
                    项目
                </td>
                <td class="tr1" align="center">
                    年初预算
                </td>
                <td class="tr1" align="center">
                    本年调整
                </td>
                <td class="tr1" align="center">
                    合计
                </td>
                <td class="tr1" align="center">
                    本期发生
                </td>
                <td class="tr1" align="center">
                    余额
                </td>
                <td class="tr1" align="center">
                    执行率
                </td>
            </tr>
            <asp:Repeater ID="repDepSubConExeList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                           <%#Eval("DepName") %>
                        </td>
                        <td>
                            <%#Eval("PayPrjName") %>
                        </td>
                        <td>
                            652355
                        </td>
                        <td>
                            452215
                        </td>
                        <td>
                            352215
                        </td>
                        <td>
                            254415
                        </td>
                        <td>
                            24415
                        </td>
                        <td>
                            <%#Eval("ARMon") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="8" class="tr1" align="center">
                    <webdiyer:AspNetPager ID="DepSubConExeListPager"  Width="500" ImagePath="~/images/PagerGif"
                        NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                        ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                        PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>
    </form>
</body>
</html>
