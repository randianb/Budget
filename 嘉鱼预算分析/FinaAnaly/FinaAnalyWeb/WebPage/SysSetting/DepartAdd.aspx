<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartAdd.aspx.cs" Inherits="WebPage_SysSetting_DepartAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门添加</title>
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
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;部门设置&nbsp;&nbsp;>&nbsp;&nbsp;部门添加</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>部门修改</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right">部门名称:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepName" CssClass="txt" runat="server" ValidationGroup="DepAdd"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtDepName" Display="Dynamic" ErrorMessage="* 部门名称不能为空" ForeColor="Red" ValidationGroup="DepAdd"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">部门备注:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepRemark" TextMode="MultiLine" Height="80" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right"></td>
                    <td>
                        <asp:Button ID="btnSure" runat="server" ValidationGroup="DepAdd" Text=" 保存 " CssClass="btns" OnClick="btnSure_Click" />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text=" 放弃 " CssClass="btns" OnClick="btnCancel_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1">&nbsp;
                        <strong>页面操作</strong>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnPostBack" runat="server" Text=" 返回上一级 " CssClass="btns" OnClick="btnPostBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

