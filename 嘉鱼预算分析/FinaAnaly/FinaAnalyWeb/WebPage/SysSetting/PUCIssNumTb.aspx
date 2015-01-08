<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PUCIssNumTb.aspx.cs" Inherits="WebPage_SysSetting_PUCIssNumTb" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>市局下达数</title>
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
                monStrs += $(this).val() + ",";
            });
            $("#HidMonStrs").val(monStrs);

            $('#table input[mark="DepidStr"]').each(function () {
                depidStrs += $(this).val() + ",";
            });
            $("#HidDepidStrs").val(depidStrs);


            $('#table input[mark="MonStr"]').each(function () {
                $(this).keyup(function () {

                    var valTmp = parseInt($(this).val());
                    if (isNaN(valTmp)) {
                        layer.tips('金额为数字', this, {
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
                        monTotal += parseInt($(this).val());
                    });
                    $("#HidMonStrs").val(monStrsTmp);
                    var TotalAdd = parseInt($("#lblTotalMon").text()) + parseInt($("#lblAddMon").text());
                    if (monTotal > TotalAdd) {
                        layer.tips('添加预算超过年初预算', this, {
                            guide: 1,
                            time: 3,
                            style: ['background-color:#c00; color:#fff', '#c00'],
                            maxWidth: 180
                        });
                        $("#btnSure").attr("disabled", true);
                        layer.tips('超过年初预算不能提交', $("#btnSure"), {
                            guide: 0,
                            time: 3,
                            style: ['background-color:#c00; color:#fff', '#c00'],
                            maxWidth: 210
                        });
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
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;市局下达数</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table id="table" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                <tr>
                    <td class="tr1" colspan="5">&nbsp;<strong><asp:Label ID="lblYear" runat="server"/>市局下达数</strong>
                        <asp:HiddenField ID="HidDepidStrs" runat="server" />
                        <asp:HiddenField ID="HidMonStrs" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td class="tr1" width="25%" align="center">项目名称
                    </td>
                    <td class="tr1" width="30%" align="center">金额（元）
                    </td>
                </tr>
                <asp:Repeater ID="repDepartMon" runat="server">
                    <ItemTemplate>
                        <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                            <td align="center">
                                <%# Eval("PIEcoSubName") %>
                            </td>
                            <td align="center">
                                <input id="txtMon" type="text" mark="MonStr"  value='<%#Eval("PUCMon")%>'/>
                                <input id="HidMon" type="hidden"  mark="HidMon" value='<%#Eval("PUCMon")%>' />
                                <input id="HidDepid" type="hidden"  mark="DepidStr" value='<%#Eval("PUCID")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="tr1" colspan="2" align="right">
                        <asp:Button ID="btnSure" runat="server" Text=" 确  定 " CssClass="btns" OnClick="btnSure_Click"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
