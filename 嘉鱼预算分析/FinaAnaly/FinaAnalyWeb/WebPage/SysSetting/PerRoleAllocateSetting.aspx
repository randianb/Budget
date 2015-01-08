<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PerRoleAllocateSetting.aspx.cs" Inherits="WebPage_SysSetting_PerRoleAllocateSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人员角色</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

<%--    <link href="../../css/tablestyle.css" rel="stylesheet" />--%>

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
        .auto-style1 {
            font-size: 13.3px;
            width: 38%;
            background-color: #eef6fd;
        }
        .auto-style2 {
            width: 88%;
        }
        .auto-style3 {
            font-size: 13.3px;
            width: 88%;
            background-color: #eef6fd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;人员角色分配</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>人员角色分配</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1">&nbsp;&nbsp;人员列表:&nbsp;
                    </td>
                   <td class="tr1">
                    </td>                  
                </tr>
                <tr>
                    <td class="tr1">
                        <asp:ListBox ID="ListBox1" runat="server" Height="100px" Width="300px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="姓名:"></asp:Label>
                         &nbsp;&nbsp;
                         <asp:TextBox ID="tb1" CssClass="txt" runat="server" Width="100px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="txt"  Text="操作员"/>  
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBox2" runat="server"  CssClass="txt"  Text="管理员" />
                    </td>
                </tr>  
            </table>
        </div>
    </form>
</body>
</html>
