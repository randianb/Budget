<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZTSubCorrespondInfoSetting.aspx.cs" Inherits="WebPage_SysSetting_ZTSubCorrespondInfoSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>科目对应设置</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <%--<link href="../../css/tablestyle.css" rel="stylesheet" />--%>

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
            <span>当前位置：<b>系统设置</b> >科目对应设置</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="3" class="tr1">&nbsp;<strong>收入类</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="20%"></td>
                    <td class="tr1" align="ceter">&nbsp;&nbsp;&nbsp;&nbsp;编码  
                    </td>
                    <td class="tr1" align="ceter">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 末级目名称 </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">事业收入:&nbsp;</td>                    
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="tbRetireNum" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn1" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">经营收入:&nbsp;
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="TextBox2" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn2" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">附属单位上缴收入:&nbsp;
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="TextBox4" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn3" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">其他收入:&nbsp;
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="TextBox6" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn4" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table border="0" style="line-height: 35px;">
                <tr>
                    <td colspan="3" class="tr1">&nbsp;<strong>支出类</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="20%"></td>
                    <td class="tr1" align="ceter">&nbsp;&nbsp;&nbsp;&nbsp;编码  
                    </td>
                    <td class="tr1" align="ceter">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 末级目名称 </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">事业收入:&nbsp;
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="TextBox8" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn5" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox9" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">经营收入:&nbsp;
                    </td>
                    &nbsp;&nbsp;
                    <td>
                        <asp:TextBox ID="TextBox10" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ibtn6" Style="vertical-align: middle; line-height: 35px;" ImageUrl="~/images/search_button.png" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox11" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
