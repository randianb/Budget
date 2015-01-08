<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberManage.aspx.cs" Inherits="WebPage_SysSetting_MemberManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人员设置</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;人员设置</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <asp:HiddenField ID="HidUsid" runat="server" />
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                <tr>
                    <td class="tr1" width="15%" align="left">&nbsp;<strong>部门列表</strong>
                    </td>
                    <td class="tr1" width="15%" align="left">&nbsp;<strong>人员列表</strong>
                    </td>
                    <td class="tr1" width="70%" align="left" colspan="2">&nbsp;<strong><asp:Label ID="lblTipInfo" runat="server" Text="修改"></asp:Label>人员信息</strong>
                    </td>
                </tr>
                <tr>
                    <td rowspan="7">
                        <asp:ListBox ID="DepartList" Width="90%" Height="90%" runat="server" OnSelectedIndexChanged="DepartList_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                    </td>
                    <td rowspan="7">
                       <asp:ListBox ID="StaffList" Width="90%" Height="90%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StaffList_SelectedIndexChanged"></asp:ListBox> 

                    </td>
                    <td class="tr1" width="10%" align="right">姓名:</td>
                    <td align="left">
                        <asp:TextBox ID="txtStaffName" CssClass="txt" runat="server" ValidationGroup="Member" OnTextChanged="txtStaffName_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtStaffName" Display="Dynamic" ErrorMessage="* 姓名不能为空" ForeColor="Red" ValidationGroup="Member"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="right">所在部门:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDepart" runat="server" CssClass="txt" ValidationGroup="Member"></asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="ddlDepart" Display="Dynamic" ErrorMessage="* 部门不能为空" ForeColor="Red" ValidationGroup="Member"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="right">登录账号:</td>
                    <td align="left">
                        <asp:TextBox ID="txtAccount" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="right">身份证号:</td>
                    <td align="left">
                        <asp:TextBox ID="txtIDNum" CssClass="txt" runat="server" ValidationGroup="Member"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtIDNum" Display="Dynamic" ErrorMessage="* 身份证号不能为空" ForeColor="Red" ValidationGroup="Member"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ErrorMessage="* 身份证号格式不正确" ValidationExpression="\d{17}[\d|X]|\d{15}" ValidationGroup="Member"
                             runat="server" ControlToValidate="txtIDNum" ForeColor="Red" ></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="right">人员备注:</td>
                    <td align="left">
                        <asp:TextBox ID="txtRem" CssClass="txt" runat="server" ValidationGroup="DepAdd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   <td class="tr1" width="10%" align="right">人员权限:</td>
                    <td align="left">
                        <asp:RadioButton ID="rbtnUser" runat="server" Text="部门用户" Checked="true"  GroupName="Limt"/>
                        <asp:RadioButton ID="rbtnBureau" runat="server" Text="局领导"   GroupName="Limt"/>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="right"></td>
                    <td align="left">
                        <asp:Button ID="btnSave" runat="server" Text="保存"  CssClass="btns" ValidationGroup="Member" OnClick="btnSave_Click"/>&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="取消"  CssClass="btns" OnClick="btnCancel_Click"/>&nbsp;
                        <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="return confirm('是否删除当前显示人员信息？')" CssClass="btns" OnClick="btnDel_Click"/>&nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </form>
</body>
</html>
