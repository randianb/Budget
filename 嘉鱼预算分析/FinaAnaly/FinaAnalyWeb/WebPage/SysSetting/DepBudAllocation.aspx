<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepBudAllocation.aspx.cs" Inherits="WebPage_SysSetting_DepBudAllocation" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门预算分配</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
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
    <script type="text/javascript">

     


        $(function () {
            var depidStrs = "";
            var monStrs = "";
            $('#table input[mark="HidMon"]').each(function () {
                monStrs += $(this).val()+",";
            });
            $("#HidMonStrs").val(monStrs);

            $('#table input[mark="DepidStr"]').each(function () {
                depidStrs += $(this).val() + ",";
            });
            $("#HidDepidStrs").val(depidStrs);


            $('#table input[mark="MonStr"]').each(function () {
                $(this).keyup(function () {

                    var valTmp = parseFloat($(this).val());
                    if (isNaN(valTmp)) {
                        layer.tips('预算金额为数字', this, {
                            guide: 1,
                            time: 2,
                            style: ['background-color:#c00; color:#fff', '#c00'],
                            maxWidth: 130
                        });
                        $(this).val("");
                    }

                    $(this).parent().find('input[mark="HidMon"]').val($(this).val());
                    var monStrsTmp = "";
                    var monTotal = 0;
                    $('#table input[mark="HidMon"]').each(function () {
                        monStrsTmp += $(this).val() + ",";
                        monTotal += parseFloat($(this).val());
                    });
                    $("#HidMonStrs").val(monStrsTmp);
                    var TotalAdd = parseFloat($("#lblTotalMon").text()) + parseFloat($("#lblAddMon").text());
                    if (monTotal > TotalAdd) {
                       
                        layer.tips('添加预算超过年初预算',this, {
                            guide: 1,
                            time: 3,
                            style: ['background-color:#c00; color:#fff', '#c00'],
                            maxWidth: 180
                        });
                        $("#btnSure").attr("disabled", true);
                        //layer.tips('超过年初预算不能提交', $("#btnSure"), {
                        //    guide: 0,
                        //    time:3,
                        //    style: ['background-color:#c00; color:#fff', '#c00'],
                        //    maxWidth: 210
                        //});
                    }
                    else {
                        $("#btnSure").attr("disabled", false);
                    }

                });
            });
        })


     
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tabtitle">
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;部门预算分配</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                <tr>
                    <td class="tr1" align="left">&nbsp;
                        <strong>
                            <asp:Label ID="lblYear" runat="server"></asp:Label>部门预算分配</strong>
                        <asp:HiddenField ID="HidDepidStrs" runat="server" />
                        <asp:HiddenField ID="HidMonStrs" runat="server" />
                    </td>
                    <td class="tr1" align="right">
                        <strong>单位(万元)</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right" width="20%">预算分配信息统计:</td>
                    <td align="left" colspan="2">&nbsp;
                        <asp:Label ID="lblTotalMon1" runat="server" Text="年初预算:"></asp:Label>
                        <strong>
                            <asp:Label ID="lblTotalMon" runat="server" ForeColor="Red"></asp:Label></strong>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAddMon1" runat="server" Text="追加预算金额:"></asp:Label>
                        <strong>
                            <asp:Label ID="lblAddMon" runat="server" ForeColor="Red"></asp:Label></strong>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBalance1" runat="server" Text="预算未分配余额:"></asp:Label>
                        <strong>
                            <asp:Label ID="lblBalance" runat="server" ForeColor="Red"></asp:Label></strong>
                    </td>
                </tr>
                <%-- <tr>
                    <td class="tr1" align="right" width="20%">部门名称:</td>
                    <td align="left">
                        &nbsp;
                        <asp:DropDownList ID="ddlDep" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right" width="20%">金额:</td>
                    <td align="left">
                        &nbsp;
                        <asp:TextBox ID="txtMon" runat="server" CssClass="txt" ValidationGroup="DepBudSetting"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtMon" Display="Dynamic" ErrorMessage="* 金额不能为空" ForeColor="Red" ValidationGroup="DepBudSetting"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMon" Type="Double" Display="Dynamic" ErrorMessage="* 金额必须为数字并且不大于余额 " ForeColor="Red" ValidationGroup="DepBudSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="20%" align="right"></td>
                    <td align="left">
                        &nbsp;
                        <asp:Button ID="btnCon" runat="server" Text=" 确定 " CssClass="btns" ValidationGroup="DepBudSetting" OnClick="btnCon_Click" />
                        &nbsp;
                        <asp:Button ID="btnCan" runat="server" Text=" 取消 " CssClass="btns" OnClick="btnCan_Click" />
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>--%>
            </table>
            <table id="table" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                <tr>
                    <td class="tr1" colspan="5">&nbsp;<strong>部门信息列表</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="25%" align="center">部门名称
                    </td>
                    <td class="tr1" width="30%" align="center">金额（万元）
                    </td>
                </tr>
                <asp:Repeater ID="repDepartMon" runat="server">
                    <ItemTemplate>
                        <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                            <td align="center">
                                <%# Eval("DepName") %>
                            </td>
                            <td align="center">
                                <input id="txtMon" type="text" mark="MonStr"  value='<%#Eval("DBAMon")%>'/>
                                <input id="HidMon" type="hidden"  mark="HidMon" value='<%#Eval("DBAMon")%>' />
                                <input id="HidDepid" type="hidden"  mark="DepidStr" value='<%#Eval("DepID")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="tr1" colspan="5" align="right">
                        <asp:Button ID="btnSure" runat="server" Text=" 确  定 " CssClass="btns" OnClick="btnSure_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
