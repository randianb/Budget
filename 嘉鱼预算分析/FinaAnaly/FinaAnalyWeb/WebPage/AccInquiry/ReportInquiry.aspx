<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportInquiry.aspx.cs" Inherits="WebPage_AccInquiry_ReportInquiry" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报表查询</title>
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
            <span>当前位置：<b>账表查询</b>&nbsp;&nbsp;>&nbsp;&nbsp;报表查询</span><p>
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
                    <td class="tr1" align="right">年份:</td>
                    <td align="left">
                        <asp:TextBox ID="tbNum" runat="server" CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">月份:</td>
                    <td align="left">
                        <asp:TextBox ID="tbName" runat="server" CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询"  CssClass="btns" />
                    </td>
                </tr>                
            </table>            
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="7">&nbsp;<strong>报表查询</strong>
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="center" class="tr1" rowspan="2">项目</td>
                    <td width="25%" align="center" class="tr1" colspan="2">合计</td>
                    <td width="25%" align="center" class="tr1" colspan="2">基本支出</td>
                    <td width="25%" align="center" class="tr1" colspan="2">项目支出</td>
                </tr>
                <tr>
                    <td width="12.5%" align="center" class="tr1">本月数</td>
                    <td width="12.5%" align="center" class="tr1">累计数</td>
                    <td width="12.5%" align="center" class="tr1">本月数</td>
                    <td width="12.5%" align="center" class="tr1">累计数</td>
                    <td width="12.5%" align="center" class="tr1">本月数</td>
                    <td width="12.5%" align="center" class="tr1">累计数</td>
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
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="7" class="tr1" align="center">
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
