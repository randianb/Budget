<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BreakdownInquiry.aspx.cs" Inherits="WebPage_AccInquiry_BreakdownInquiry" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>明细账查询</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <script src="../../js/jquery-1.7.2.min.js"></script>

    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 200px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>账表查询</b>&nbsp;&nbsp;>&nbsp;&nbsp;明细账查询</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>查询条件</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">会计期间:</td>
                    <td align="left">
                        <asp:TextBox ID="tbYear" runat="server" CssClass="txt" Width="60"></asp:TextBox>&nbsp;
                        年&nbsp;<asp:TextBox ID="tbMon" runat="server" CssClass="txt" Width="60"></asp:TextBox>
                        &nbsp;月&nbsp;<asp:TextBox ID="tbDay" runat="server" CssClass="txt" Width="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">科目编码:</td>
                    <td align="left">
                        <asp:TextBox ID="tbNum" runat="server" CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">科目名称:</td>
                    <td align="left">
                        <asp:TextBox ID="tbName" runat="server" CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">凭证类型:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">是否显示未发生:</td>
                    <td align="left">
                        <asp:RadioButton ID="rbOccurTrue" runat="server" Text="是" />&nbsp;&nbsp;
                        <asp:RadioButton ID="rbOccurNo" runat="server" Text="否" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">是否显示未结账:</td>
                    <td align="left">
                        <asp:RadioButton ID="rbCheckoutTrue" runat="server" Text="是" />&nbsp;&nbsp;
                        <asp:RadioButton ID="rbCheckoutNo" runat="server" Text="否" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">外币:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlForeignCur" runat="server" CssClass="txt"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="9">&nbsp;<strong>明细账</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" colspan="9">
                        <asp:Button ID="btnPreview" runat="server" Text="预览" CssClass="btns" />&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text="打印" CssClass="btns" />&nbsp; 
                        <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btns" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" class="tr1" colspan="2">2009</td>
                    <td width="20%" align="center" class="tr1" colspan="2">凭证</td>
                    <td width="20%" align="center" class="tr1" rowspan="2">摘要</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">借方金额</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">贷方金额</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">方向</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">余额</td>
                </tr>
                <tr>
                    <td width="10%" align="center" class="tr1">月</td>
                    <td width="10%" align="center" class="tr1">日</td>
                    <td width="10%" align="center" class="tr1">字</td>
                    <td width="10%" align="center" class="tr1">号</td>
                </tr>
                <asp:Repeater ID="RepLeaderQuery" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                            <td>
                                <%#Eval("")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="13" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="LeadQueryPager1" Width="500" ImagePath="~/images/PagerGif"
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

