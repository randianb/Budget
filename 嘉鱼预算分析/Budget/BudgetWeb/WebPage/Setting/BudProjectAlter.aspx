<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudProjectAlter.aspx.cs"
    Inherits="mainPages_BudProjectAlter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预算项目修改</title>

    <script src="../BudgetEdit/css/mytable.js" type="text/javascript"></script>
    <link href="../BudgetEdit/css/whsystem.css" rel="stylesheet" />
    <link href="../BudgetEdit/css/whtable.css" rel="stylesheet" />

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
        <!-- 表头开始 -->
       
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>预算项目修改</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">预算项目：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtPro" Style="width: 220px; height: 24px; border: solid 1px #A3C8F5; vertical-align: middle;"
                        runat="server"></asp:TextBox>

                    </td>
                </tr>
              <tr>
                <td width="20%" class="tr1 right">
                    预留项：
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckA" Text="A" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbA" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrA" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckB" Text="B" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbB" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrB" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckC" Text="C" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbC" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrC" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckD" Text="D" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbD" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrD" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckE" Text="E" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbE" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrE" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="ckF" Text="F" runat="server" />
                    &nbsp;&nbsp;
                    <asp:TextBox ID="tbF" CssClass="txt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrF" CssClass="txt" style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                </td>
            </tr>
                <tr>
                    <td width="20%" class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                    <asp:Button ID="btnMod" CssClass="btns" runat="server" Text=" 修  改 " OnClick="btnMod_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 取  消 " OnClick="btnCan_Click" />
                        <asp:Label runat="server" ForeColor="Red" Text="预留项必须由上至下设置"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
