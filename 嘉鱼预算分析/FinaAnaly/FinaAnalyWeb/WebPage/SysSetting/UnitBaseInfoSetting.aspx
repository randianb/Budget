<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitBaseInfoSetting.aspx.cs" Inherits="WebPage_SysSetting_UnitBaseInfoSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基本情况设置</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <%-- <link href="../../css/tablestyle.css" rel="stylesheet" />--%>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }

        .txt
        {
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
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;单位基本情况</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>单位基本情况设置</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right">单位名称:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnitName" CssClass="txt" runat="server" ValidationGroup="UnitSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtUnitName" Display="Dynamic" ErrorMessage="* 单位名称不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">组织机构代码:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnitCode" CssClass="txt" runat="server" ValidationGroup="UnitSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtUnitCode" Display="Dynamic" ErrorMessage="* 组织机构代码不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">年度:&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtYear"  onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})" CssClass="txt" ValidationGroup="UnitSetting" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtYear" Display="Dynamic" ErrorMessage="* 年度不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">人员编制数:&nbsp;&nbsp;                        
                    </td>
                    <td>
                        <asp:TextBox ID="txtStaffNum" CssClass="txt" runat="server" ValidationGroup="UnitSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtStaffNum" Display="Dynamic" ErrorMessage="* 在职职员工数不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtStaffNum" Display="Dynamic" ErrorMessage="* 在职职员工数必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="1" Type="Integer" ValidationGroup="UnitSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right"></td>
                    <td>
                        <asp:Button ID="btnSure" runat="server" ValidationGroup="UnitSetting" Text=" 保存 "  CssClass="btns" OnClick="btnSure_Click"/>
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text=" 取消 "  CssClass="btns" OnClick="btnCancel_Click"/>
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
