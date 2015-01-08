<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundIncEvaForm.aspx.cs" Inherits="WebPage_CusAnaly_FundIncEvaForm" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经费收入评估表</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <script src="../../js/jquery-1.7.2.min.js"></script>

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
         <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;经费收入评估表</span><p>
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
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="19" class="tr1" align="left">&nbsp;<strong>经费收入评估表</strong>
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="center" class="tr1">科目编码
                    </td>
                    <td width="15%" align="center" class="tr1">项目
                    </td>
                    <td width="15%" align="center" class="tr1">收入总数
                    </td>
                    <td width="15%" align="center" class="tr1">同期±%
                    </td>
                    <td width="15%" align="center" class="tr1">增减值
                    </td>
                    <td width="15%" align="center" class="tr1">区域±%
                    </td>
                     <td width="15%" align="center" class="tr1">增减值
                    </td>                   
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
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td class="tr1">
                        <asp:Button ID="btnComplexAssessAnalyTB" runat="server" Text="综合评估分析表" CssClass="btns" OnClick="btnComplexAssessAnalyTB_Click" />&nbsp;
                        <asp:Button ID="btnPubFundExpendEvaForm" runat="server" Text="公务经费支出评估表" CssClass="btns" OnClick="btnPubFundExpendEvaForm_Click" />&nbsp; 
                        <asp:Button ID="btnBalanceEvaForm" runat="server" Text="资产负债评估表" CssClass="btns" OnClick="btnBalanceEvaForm_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>