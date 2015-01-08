<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FixAssetPurchaseUpd.aspx.cs" Inherits="BudgetPage_mainPages_FixAssetPurchaseUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="css/mytable.js" type="text/javascript"></script>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }
        .txt
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 180px;
        }
    </style>
    <script type="text/javascript">

        $(function () {
            $("#txtPrice").keyup(function () {
                total();
            });
            $("#txtNum").keyup(function () {
                total();
            });
        });
        function total()
        {
            var price = parseInt($("#txtPrice").val());
            if (isNaN(price))
            {
                price = 0;
            }
            var num = parseInt($("#txtNum").val());
            if (isNaN(num)) {
                num = 0;
            }
            var sum = price * num;
            $("#txtMon").val(sum);
            $("#HidTotal").val(sum);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <!-- 表头结束 -->
        <div class="table_list" />
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
            <tr>
                <td colspan="2" class="tr1">&nbsp;
                    <strong>固定资产采购情况</strong>
                    <asp:HiddenField ID="HidBudid" runat="server" />
                    <asp:HiddenField ID="HidTotal" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">固定资产名称：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtSort" CssClass="txt" ValidationGroup="AddFap" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="AddFap" ErrorMessage="*固定资产名称不能为空" ControlToValidate="txtSort" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">型号：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtModel" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="AddFap" ErrorMessage="*型号不能为空" ControlToValidate="txtModel" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">品牌：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtBrand" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="AddFap" ErrorMessage="*品牌不能为空" ControlToValidate="txtBrand" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">单价：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrice" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="单价不能为空" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" ValidationGroup="AddFap"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="* 单价必须为数字" ForeColor="Red" MaximumValue="99999999" MinimumValue="0" Type="Double" ValidationGroup="AddFap"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">数量：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtNum" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="数量不能为空" ControlToValidate="txtNum" Display="Dynamic" ForeColor="Red" ValidationGroup="AddFap"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtNum" Display="Dynamic" ErrorMessage="*数量必须为整数" ForeColor="Red" MaximumValue="99999999" MinimumValue="0" Type="Integer" ValidationGroup="AddFap"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">金额：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtMon" CssClass="txt" runat="server" ValidationGroup="AddFap" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">是否政府采购：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlIsGovper" CssClass="txt" runat="server">
                        <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">配置信息：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtConfig" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="配置信息不能为空" ControlToValidate="txtConfig" Display="Dynamic" ForeColor="Red" ValidationGroup="AddFap"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">备注：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtRemark" CssClass="txt" runat="server" ValidationGroup="AddFap"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="备注不能为空" ControlToValidate="txtRemark" Display="Dynamic" ForeColor="Red" ValidationGroup="AddFap"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">时间：
                </td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtTime" ValidationGroup="AddFap" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd',maxDate:'2020-01-01'})" CssClass="txt" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">
                </td>
                <td>&nbsp;&nbsp;
                    <asp:Button ID="btnUpd"  ValidationGroup="UpdFap" CssClass="btns" runat="server" Text="修改" OnClick="btnUpd_Click" />
                    <asp:Button ID="btnCan" CssClass="btns" runat="server" Text="取消" OnClick="btnCan_Click"/>
                    <asp:Label ID="lbResult" runat="server" Text=" "></asp:Label>
                    <asp:Label ID="lblShowResult" runat="server" ForeColor="Red" Text=" "></asp:Label>
                </td>
            </tr>
        </table>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
