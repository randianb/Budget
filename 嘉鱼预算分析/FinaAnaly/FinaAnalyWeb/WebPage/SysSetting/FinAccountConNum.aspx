<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinAccountConNum.aspx.cs" Inherits="WebPage_SysSetting_FinAccountConNum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<head runat="server">
    <title>决算控制数</title>
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
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;决算控制数</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="3">&nbsp;<strong><asp:Label ID="lblYear" runat="server"></asp:Label>年决算控制数</strong>
                        <asp:HiddenField ID="HidBBM" runat="server" />
                        <asp:HiddenField ID="HidPBM" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="30%" align="right">基本支出决算控制数:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtBasic" CssClass="txt" runat="server"
                            ValidationGroup="UnitSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBasic"
                            Display="Dynamic" ErrorMessage="* 决算控制数不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="*请输入数字"
                            Display="Dynamic" ForeColor="Red" MaximumValue="9999" MinimumValue="0"
                            ControlToValidate="txtBasic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="30%" align="right">项目支出决算控制数:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtProject" CssClass="txt" runat="server" ValidationGroup="UnitSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProject"
                            Display="Dynamic" ErrorMessage="* 决算控制数不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*请输入数字"
                            Display="Dynamic" ForeColor="Red" MaximumValue="9999" MinimumValue="0"
                            ControlToValidate="txtProject"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="20%" align="right"></td>
                    <td align="left">&nbsp;
                    <asp:Button ID="btnCon" runat="server" Text=" 确定 " CssClass="btns"
                        ValidationGroup="IncomeBudSetting" OnClick="btnCon_Click" />
                        &nbsp;
                    <asp:Button ID="btnCan" runat="server" Text=" 取消 " CssClass="btns"
                        OnClick="btnCan_Click" />
                        &nbsp;
                    <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
