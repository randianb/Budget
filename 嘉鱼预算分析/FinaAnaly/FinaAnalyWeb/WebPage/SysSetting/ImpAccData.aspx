<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpAccData.aspx.cs" Inherits="WebPage_SysSetting_ImpAccData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>导入决算数据</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
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
            var bpiidStrs = "";
            var bmonStrs = "";
            var ppiidStrs = "";
            var pmonStrs = "";
            $('#table input[mark="HidBasicMon"]').each(function () {
                bmonStrs += $(this).val() + ",";
            });
            $("#HidBasicMonStrs").val(bmonStrs);

            $('#table input[mark="BasicPiidStr"]').each(function () {
                bpiidStrs += $(this).val() + ",";
            });
            $("#HidBasicPIIDStrs").val(bpiidStrs);


            $('#table input[mark="BasicMonStr"]').each(function () {
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
                    $(this).parent().find('input[mark="HidBasicMon"]').val($(this).val());
                    var bmonStrsTmp = "";
                    $('#table input[mark="HidBasicMon"]').each(function () {
                        bmonStrsTmp += $(this).val() + ",";
                    });
                    $("#HidBasicMonStrs").val(bmonStrsTmp);
                });
            });
            $('#table input[mark="HidProMon"]').each(function () {
                pmonStrs += $(this).val() + ",";
            });
            $("#HidProMonStrs").val(pmonStrs);

            $('#table input[mark="ProPiidStr"]').each(function () {
                ppiidStrs += $(this).val() + ",";
            });
            $("#HidProPIIDStrs").val(ppiidStrs);


            $('#table input[mark="ProMonStr"]').each(function () {
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
                    $(this).parent().find('input[mark="HidProMon"]').val($(this).val());
                    var pmonStrsTmp = "";
                    $('#table input[mark="HidProMon"]').each(function () {
                        pmonStrsTmp += $(this).val() + ",";
                    });
                    $("#HidProMonStrs").val(pmonStrsTmp);
                });
            });

        })



    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;导入决算数据</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>导入决算数据</strong>
                        <asp:HiddenField ID="HidBasicPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidBasicMonStrs" runat="server" />
                        <asp:HiddenField ID="HidProPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidProMonStrs" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">导入:</td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnImport" runat="server" Text="导入Excel"  CssClass="btns" OnClick="btnImport_Click"/>
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <table id="table" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
            <tr>
                <td class="tr1" align="left" colspan="3" width="20%">
                    经济科目决算数据信息列表
                </td>
            </tr>
            <tr>
                <td class="tr1" width="25%" align="center">
                    经济科目名称
                </td>
                <td class="tr1" width="30%" align="center">
                    基本金额（元）
                </td>
                <td class="tr1" width="30%" align="center">
                    项目金额（元）
                </td>
            </tr>
            <asp:Repeater ID="repIncomeMon" runat="server">
                <ItemTemplate>
                    <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                        <td align="left">
                            <%# Eval("column1") %>
                        </td>
                        <td align="center">
                            <input id="txtBasicMon" type="text" mark="BasicMonStr"  value='<%#Eval("column2")%>'/>
                                <input id="HidBasicMon" type="hidden"  mark="HidBasicMon" value='<%#Eval("column2")%>'/>
                                <input id="HidBasicPiid" type="hidden"  mark="BasicPiidStr" value='<%#Eval("BPIID")%>' />
                        </td>
                        <td align="center">
                            <input id="txtProMon" type="text" mark="ProMonStr"  value='<%#Eval("column3")%>'/>
                                <input id="HidProMon" type="hidden"  mark="HidProMon" value='<%#Eval("column3")%>'/>
                                <input id="HidProPiid" type="hidden"  mark="ProPiidStr" value='<%#Eval("PPIID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
                <tr>
                    <td class="tr1" colspan="5" align="right">
                        <asp:Button ID="btnSure" runat="server" Text=" 确  定 " CssClass="btns" OnClick="btnSure_Click"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
        </table>
        </div>
    </form>
</body>
</html>
