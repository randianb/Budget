<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApprovalList.aspx.cs" Inherits="WebPage_BudgetExecute_ApprovalList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>审批</title>

    <script src="../css/mytable.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body {
            overflow: scroll;
            /*overflow-y: hidden;*/
            margin: 0;
            height: 100%;
        }

        .txt {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }

        .auto-style1 {
            width: 941px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" style="line-height: 40px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>申请单详情</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">部门：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:Label ID="lbDepName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">报销单号：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARReiSinNum" CssClass="txt" runat="server" Height="20px" Width="300px" Enabled="false"></asp:TextBox>
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
                    <td class="tr1 right">支出科目：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARExpSub" runat="server" Height="20px" Width="300px" AutoPostBack="true" Enabled="false">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">时间：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                     <asp:TextBox ID="txtBITime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})" CssClass="txt" runat="server" ValidationGroup="AddBI" Height="20px" Width="300px" Enabled="false"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBITime" Display="Dynamic" ErrorMessage="项目报进日期不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">上报部门：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARRepDep" CssClass="txt" runat="server" Height="20px" Width="300px" Enabled="false"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtARRepDep" Display="Dynamic" ErrorMessage="上报部门不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">经办人：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:TextBox ID="txtARAgent" CssClass="txt" runat="server" Height="20px" Width="300px" Enabled="false"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtARAgent" Display="Dynamic" ErrorMessage="经办人不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">金额：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                   <asp:TextBox ID="txtARMon" CssClass="txt" runat="server" Height="20px" Width="300px" Enabled="false"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtARMon" Display="Dynamic" ErrorMessage="金额不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">事由：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                   <asp:TextBox ID="txtARExcu" CssClass="txt" runat="server" Height="20px" Width="300px" Enabled="false"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtARExcu" Display="Dynamic" ErrorMessage="事由不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">支出类型：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="300px" AutoPostBack="true">
                                <asp:ListItem>财政拨款</asp:ListItem>
                                <asp:ListItem>其他资金</asp:ListItem>
                            </asp:DropDownList>
                        <br />
                        &nbsp;&nbsp;
                        <asp:RadioButton runat="server" ID="rdBase" GroupName="rd" Text="基本支出" Checked="true" />
                        <asp:RadioButton runat="server" ID="rdPro" GroupName="rd" Text="项目支出" />
                    </td>

                </tr>
                <tr>
                    <td class="tr1 right">退回原因：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                   <asp:TextBox ID="txtReason" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReason" Display="Dynamic" ErrorMessage="点退回的时候不能为空" ForeColor="Red" ValidationGroup="Return"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">查看报销单
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:Label ID="lbRDType" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;
                     <asp:Button ID="btnAlt" CssClass="btns" runat="server" Text="查  看" OnClick="btnAlt_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right"></td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:Button ID="btnAudit" CssClass="btns" runat="server" Text=" 审核通过 " OnClick="btnAudit_Click" />
                        <asp:Button ID="btnReturn" CssClass="btns" runat="server" Text=" 退  回 " ValidationGroup="Return" OnClick="btnReturn_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 取  消 " OnClick="btnCan_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
