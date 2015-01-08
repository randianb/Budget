<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyAddOld.aspx.cs" Inherits="BudgetPage_mainPages_ApplyAddOld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>申请添加</title>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../css/mytable.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body {
            overflow: scroll;
            overflow-y: scroll;
            margin: 0;
            height: 100%;
        }

        .txt {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
    <script type="text/javascript">


        $(function () {

            GetValue();
        });
        function GetValue() {
            $("#txtARMon").blur(function () {
                var Mon = $("#txtARMon").val();
                var aaa = $("#HidtxtARMon").val() - $("#txtARMon").val();
                $("#lbBalance").text("余额为" + aaa + "元");
            }).keyup(function () {
                var Mon = $("#txtARMon").val();
                var aaa = $("#HidtxtARMon").val() - $("#txtARMon").val();
                $("#lbBalance").text("余额为" + aaa + "元");
            });
        }

        function change() {
            if ($("#txtBITime").val().length <= 0) {
                $("#latt").text("请先选择报销时间！");
                $("#ddlARExpSub").val("0");
                return false;
            }
            alert("xx");
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头结束 -->
        <asp:HiddenField runat="Server" ID="HidtxtARMon" />
        <div class="table_list">
            <table border="0" style="line-height: 40px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>申请表添加</strong>
                    </td>
                </tr>
                <%--     <tr>
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
                    <td class="tr1 right">报销单号：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtARReiSinNum" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
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
                    <asp:DropDownList ID="ddlARExpPro" runat="server" Height="20px" Width="300px" OnSelectedIndexChanged="ddlARExpPro_SelectedIndexChanged" AutoPostBack="true" >
                       <%-- <asp:ListItem>物业管理费</asp:ListItem>
                          <asp:ListItem>会议费</asp:ListItem>
                        <asp:ListItem>文明创建活动费</asp:ListItem>
                        <asp:ListItem>培训费</asp:ListItem>
                        <asp:ListItem>稽查办案专项费</asp:ListItem>
                        <asp:ListItem> 纳税服务专项费</asp:ListItem>
                        <asp:ListItem>设备购置费</asp:ListItem>
                        <asp:ListItem>不可预见费</asp:ListItem>--%>
                <%--        </asp:DropDownList>
                </td>
            </tr>--%>
                <tr>
                    <td class="tr1 right">报销时间：
                    </td>
                    <td>&nbsp;&nbsp;
                     <asp:TextBox ID="txtBITime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" CssClass="txt" runat="server" ValidationGroup="AddBI" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBITime" Display="Dynamic" ErrorMessage="项目报进日期不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">支出科目：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARExpSub" runat="server" Height="20px" Width="300px" OnSelectedIndexChanged="ddlARExpSub_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                        <span style="color: red">*</span>
                        <asp:Label ForeColor="Red" runat="server" ID="latt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">上报部门：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlARRepDep" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:DropDownList><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlARRepDep" Display="Dynamic" ErrorMessage="上报部门不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">经办人：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtARAgent" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtARAgent" Display="Dynamic" ErrorMessage="经办人不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">金额：
                    </td>
                    <td>&nbsp;&nbsp;
                   <asp:TextBox ID="txtARMon" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtARMon" Display="Dynamic" ErrorMessage="金额不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtARMon" Display="Dynamic" ErrorMessage="*金额必须为数字" ForeColor="Red" MaximumValue="9999999" MinimumValue="0" Type="Double" ValidationGroup="AddFap"></asp:RangeValidator>
                        <asp:Label ID="lbdes" runat="server" ForeColor="Red" Text="余额为" Visible="false"></asp:Label>
                        <asp:Label ID="lbBalance" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 right">事由：
                    </td>
                    <td>&nbsp;&nbsp;
                   <asp:TextBox ID="txtARExcu" CssClass="txt" runat="server" Height="20px" Width="300px"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtARExcu" Display="Dynamic" ErrorMessage="事由不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>


                <tr>
                    <td class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" CssClass="btns" runat="server" Text=" 添  加 " ValidationGroup="AddBI" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 返  回 " OnClick="btnCan_Click" />
                        <asp:Label ID="lbResult" runat="server" ForeColor="Red"></asp:Label>
                        &nbsp;
                    </td>
                </tr>

                <tr>
                    <td width="20%" class="auto-style1">选择申请类别
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                    <asp:RadioButton ID="radTra" GroupName="AppType" Text="差旅费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radMed" GroupName="AppType" Text="医疗费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                     <asp:RadioButton ID="radPur" GroupName="AppType" Text="购置费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radTrain" GroupName="AppType" Text="培训费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radMeet" GroupName="AppType" Text="会议费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radPrint" GroupName="AppType" Text="印刷费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="radMaintenance" GroupName="AppType" Text="维修（护）费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radUnion" GroupName="AppType" Text="工会经费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radCar" GroupName="AppType" Text="公务用车运行维护费" runat="server" Visible="false" />
                        &nbsp;&nbsp;
                    <asp:RadioButton ID="radOth" GroupName="AppType" Text="其它费用" runat="server" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnAddDoc" CssClass="btns" runat="server" Text="添加报销单" OnClick="btnAddDoc_Click" />
                        <asp:Label ID="Label1" runat="server" Text="请在申请表添加完成后，再点击添加报销单" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
        <div class="table_list" style="font-size: 16px">
            1、选择报销时间。<br />
            2、选择支出科目。<br />
            3、选择部门。<br />
            4、填写经办人。<br />
            5、填写金额且金额不能超过余额。<br />
            6、填写事由。<br />
            7、点击添加，添加申请表。<br />
            8、第7步已完成添加，如果需要添加报销单据，可选择添加报销类型然后点击添加报销单。<br />
            <br />
        </div>
    </form>
</body>
</html>
