<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EcoMon.aspx.cs" Inherits="WebPage_CusAnaly_EcoMon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经济科目经费一揽表</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
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
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;经济科目经费一揽表</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" class="tr1" align="left">&nbsp;<strong>经济科目执行情况表</strong>
                    </td>
                    <td colspan="1" align="right" class="tr1">
                        <asp:Button runat="server" ID="btnCan" CssClass="btns" Text=" 退回 " OnClick="btnCan_Click" />
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="center" class="tr1">经济科目名称
                    </td>
                    <td width="25%" align="center" class="tr1">本期数(元)
                    </td>
                    <td width="25%" align="center" class="tr1">同期数(元)
                    </td>
                    <td width="25%" align="center" class="tr1">差额比
                    </td>
                </tr>
                <asp:Repeater ID="repDepExecut" runat="server">
                    <ItemTemplate>
                        <tr onmousemove="javascript:this.bgColor='#B0CDED';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                            <td align="right">
                                <%#Eval("column1")%>
                            </td>
                            <td align="right">
                                <%#Eval("column2")%>
                            </td>
                            <td align="right">
                                <%#Eval("column3")%>
                            </td>
                            <td align="right">
                                <%#Eval("column4")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="TotalOne" runat="server" class="tr1">
                    <td align="right" width="30%"><strong>合计</strong></td>
                    <td align="right" width="10%">
                        <asp:Label ID="txtTMon" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="right" width="10%">
                        <asp:Label ID="txtLMon" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="right" width="10%">
                        <asp:Label ID="txtDifference" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
