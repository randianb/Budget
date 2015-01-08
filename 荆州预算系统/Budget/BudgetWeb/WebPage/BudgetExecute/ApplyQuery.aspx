<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyQuery.aspx.cs" Inherits="BudgetPage_mainPages_ApplyQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>申请状态</title>

    <script src="../css/mytable.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            overflow: scroll;
            overflow-y: hidden;
            margin: 0;
            height: 100%;
        }

        .txt
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
        .auto-style1 {
            width: 1014px;
        }
        .auto-style2 {
            width: 102px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" style="line-height: 40px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>申请状态</strong>
                    </td>
                </tr>
                <%--  <tr>
                    <td class="tr1 right">部门：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDepart" CssClass="txt " runat="server" Height="20px" Width="300px">
                        <asp:ListItem Value="1104">办公室</asp:ListItem>
                        <asp:ListItem Value="1105">人事科</asp:ListItem>
                        <asp:ListItem Value="1106">财务科</asp:ListItem>
                        <asp:ListItem Value="1107">纳税服务科</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td class="auto-style2">报销单号：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARReiSinNum" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <%-- <tr>
                <td  class="tr1 right">
                    支出类型：
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARExpType" CssClass="txt" runat="server" Height="20px" Width="300px" OnSelectedIndexChanged="ddlARExpType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>基本支出</asp:ListItem>
                        <asp:ListItem>项目支出</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  class="tr1 right">
                    支出项目：
                </td>
                <td>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARExpPro" runat="server" Height="20px" Width="300px"  AutoPostBack="true" >
                        <asp:ListItem>物业管理费</asp:ListItem>
                          <asp:ListItem>会议费</asp:ListItem>
                        <asp:ListItem>文明创建活动费</asp:ListItem>
                        <asp:ListItem>培训费</asp:ListItem>
                        <asp:ListItem>稽查办案专项费</asp:ListItem>
                        <asp:ListItem> 纳税服务专项费</asp:ListItem>
                        <asp:ListItem>设备购置费</asp:ListItem>
                        <asp:ListItem>不可预见费</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
                <tr>
                    <td class="auto-style2">支出科目：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARExpSub" runat="server" Height="20px" Width="300px" AutoPostBack="true">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">时间：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                     <asp:TextBox ID="txtBITime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" CssClass="txt" runat="server" ValidationGroup="AddBI" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBITime" Display="Dynamic" ErrorMessage="项目报进日期不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">上报部门：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARRepDep" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtARRepDep" Display="Dynamic" ErrorMessage="上报部门不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">经办人：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARAgent" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtARAgent" Display="Dynamic" ErrorMessage="经办人不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">金额：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                   <asp:TextBox ID="txtARMon" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtARMon" Display="Dynamic" ErrorMessage="金额不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">事由：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                   <asp:TextBox ID="txtARExcu" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtARExcu" Display="Dynamic" ErrorMessage="事由不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style1">&nbsp;&nbsp;
                         <asp:Label ID="lbRDType" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnQue" CssClass="btns" runat="server" Text=" 查看附件 " OnClick="btnQue_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 返    回 " OnClick="btnCan_Click" />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td width="20%" class="tr1 right">修改报销单
                    </td>
                    <td>&nbsp;&nbsp;
                   
                        &nbsp;&nbsp;
                     <asp:Button ID="btnAlt" CssClass="btns" runat="server" Text="修 改" OnClick="btnAlt_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                    <asp:Button ID="btnAlter" CssClass="btns" runat="server" Text=" 修  改 " OnClick="btnAlter_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 返  回 " OnClick="btnCan_Click" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </form>
</body>
</html>

