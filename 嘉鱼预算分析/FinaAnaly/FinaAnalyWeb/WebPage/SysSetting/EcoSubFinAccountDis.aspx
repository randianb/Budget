<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EcoSubFinAccountDis.aspx.cs"
    Inherits="WebPage_SysSetting_EcoSubFinAccountDis" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经济科目决算分配</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <style type="text/css">
        html, body
        {
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
    <div class="tabtitle">
        <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;经济科目决算分配</span><p>
        </p>
    </div>
    <!-- 表头结束 -->
    <div class="table_list">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
            <tr>
                <td class="tr1" align="left" colspan="2">
                    &nbsp; <strong>
                        <asp:Label ID="lblYear" runat="server"></asp:Label>年经济科目决算分配</strong>
                </td>
            </tr>
            <tr>
                <td class="tr1" align="right" width="20%">
                    决算分配信息统计:
                </td>
                <td align="left" colspan="2">
                    &nbsp;
                    <asp:Label ID="lblTotalMon1" runat="server" Text="决算总金额:"></asp:Label>
                    <strong>
                        <asp:Label ID="lblTotalMon" runat="server" ForeColor="Red"></asp:Label></strong>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblBalance1" runat="server" Text="决算未分配余额:"></asp:Label>
                    <strong>
                        <asp:Label ID="lblBalance" runat="server" ForeColor="Red"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td class="tr1" align="right" width="20%">
                    经济科目类型:
                </td>
                <td align="left">
                    &nbsp;
                    <asp:RadioButton ID="rbtnBasePay" runat="server" Text="基本支出" GroupName="Gender" Checked="true"
                        AutoPostBack="True" OnCheckedChanged="rbtnBasePay_CheckedChanged" />&nbsp;&nbsp;
                    <asp:RadioButton ID="rbtnProPay" runat="server" Text="项目支出" GroupName="Gender" AutoPostBack="True"
                        OnCheckedChanged="rbtnProPay_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td class="tr1" align="right" width="20%">
                    经济科目名称:
                </td>
                <td align="left">
                    &nbsp;
                    <asp:DropDownList ID="ddlIncome" runat="server" CssClass="txt" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlIncome_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tr1" align="right" width="20%">
                    金额:
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtMon" runat="server" CssClass="txt" ValidationGroup="IncomeBudSetting"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMon"
                        Display="Dynamic" ErrorMessage="* 金额不能为空" ForeColor="Red" ValidationGroup="IncomeBudSetting"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMon"
                        Display="Dynamic" ErrorMessage="* 金额必须为数字并且不大于余额 " ForeColor="Red" Type="Double"
                        ValidationGroup="IncomeBudSetting"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="tr1" width="20%" align="right">
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnCon" runat="server" Text=" 确定 " CssClass="btns" ValidationGroup="IncomeBudSetting"
                        OnClick="btnCon_Click" />
                    &nbsp;
                    <asp:Button ID="btnCan" runat="server" Text=" 取消 " CssClass="btns" OnClick="btnCan_Click" />
                    &nbsp;
                    <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
            <tr>
                <td class="tr1" align="center" width="20%">
                    经济科目决算分配信息列表
                </td>
                <td class="tr1" align="center" colspan="2">
                    &nbsp;
                    <asp:Label ID="basePay1" runat="server" Text="基本支出已分配:"></asp:Label>
                    <strong>
                        <asp:Label ID="lblBaseMonTotal" runat="server" ForeColor="Red"></asp:Label></strong>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="proPay1" runat="server" Text="项目支出已分配:"></asp:Label>
                    <strong>
                        <asp:Label ID="lblProjMonTotal" runat="server" ForeColor="Red"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td class="tr1" width="25%" align="center">
                    经济科目名称
                </td>
                <td class="tr1" width="30%" align="center">
                    金额
                </td>
                <td class="tr1" width="30%" align="center">
                    类型
                </td>
            </tr>
            <asp:Repeater ID="repIncomeMon" runat="server">
                <ItemTemplate>
                    <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                        <td align="center">
                            <%# Eval("PIEcoSubName") %>
                        </td>
                        <td align="center">
                            <%# Eval("IAAMon") %>
                        </td>
                        <td align="center">
                            <%# Eval("PIType") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
