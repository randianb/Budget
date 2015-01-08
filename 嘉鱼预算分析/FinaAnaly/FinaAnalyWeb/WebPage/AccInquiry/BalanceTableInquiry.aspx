<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BalanceTableInquiry.aspx.cs" Inherits="WebPage_AccInquiry_BalanceTableInquiry" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>余额表查询</title>
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
            <span>当前位置：<b>账表查询</b>&nbsp;&nbsp;>&nbsp;&nbsp;余额表查询</span><p>
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
                    <td class="tr1" align="right">查询期间:</td>
                    <td align="left">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="年" />
                        &nbsp;
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="月" />
                        &nbsp;
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="日" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">年期间:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" Width="60"></asp:TextBox>&nbsp;
                        至&nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="txt" Width="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">会计科目:</td>
                    <td align="left">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txt"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">统计类型:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">余额方式:</td>
                    <td align="left">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txt"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">是否显示:</td>
                    <td align="left">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="数量" />&nbsp;
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="年初数" />
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
                    <td class="tr1" colspan="8">&nbsp;<strong>余额表</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" colspan="8">
                        <asp:Button ID="btnPreview" runat="server" Text="预览" CssClass="btns" />&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text="打印" CssClass="btns" />&nbsp; 
                        <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btns" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center" class="tr1" rowspan="2">科目编码</td>
                    <td width="20%" align="center" class="tr1" rowspan="2">科目名称</td>
                    <td width="20%" align="center" class="tr1" colspan="2">前期累计</td>
                    <td width="20%" align="center" class="tr1" colspan="2">2009年</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">借贷</td>
                    <td width="10%" align="center" class="tr1" rowspan="2">期末余额</td>
                </tr>
                <tr>
                    <td width="10%" align="center" class="tr1">借方</td>
                    <td width="10%" align="center" class="tr1">贷方</td>
                    <td width="10%" align="center" class="tr1">借方</td>
                    <td width="10%" align="center" class="tr1">贷方</td>
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
