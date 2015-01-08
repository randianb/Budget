<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarnControlIndexSetting.aspx.cs" Inherits="WebPage_SysSetting_WarnControlIndexSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预警指标设置</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <%--<link href="../../css/tablestyle.css" rel="stylesheet" />--%>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 120px;
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
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;预算预警指标</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>预算预警指标</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right" width="15%">年度:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtYear" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})" CssClass="txt" runat="server" ValidationGroup="WarmIndex"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtYear" Display="Dynamic" ErrorMessage="* 年度不能为空" ForeColor="Red" ValidationGroup="WarmIndex"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right">黄色预警指标:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="tbName" CssClass="txt" runat="server" ValidationGroup="WarmIndex"></asp:TextBox>
                        &nbsp;<strong>%</strong>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="tbName" Display="Dynamic" ErrorMessage="* 黄色预警指标不能为空" ForeColor="Red" ValidationGroup="WarmIndex"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbName" Display="Dynamic" ErrorMessage="* 黄色预警指标必须为数字" ForeColor="Red" MaximumValue="99999" MinimumValue="1" Type="Integer" ValidationGroup="UnitSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right">红色预警指标:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="tbOrgan" CssClass="txt" runat="server" ValidationGroup="WarmIndex"></asp:TextBox>
                         &nbsp;<strong>%</strong>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbOrgan" Display="Dynamic" ErrorMessage="* 红色预警指标不能为空" ForeColor="Red" ValidationGroup="WarmIndex"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbOrgan" Display="Dynamic" ErrorMessage="* 虹色预警指标必须为数字" ForeColor="Red" MaximumValue="99999" MinimumValue="1" Type="Integer" ValidationGroup="UnitSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right"></td>
                    <td>
                        <asp:Button ID="btnSure" runat="server" ValidationGroup="WarmIndex" Text=" 保存 " CssClass="btns" OnClick="btnSure_Click" />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text=" 取消 " CssClass="btns" OnClick="btnCancel_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
