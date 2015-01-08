<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GrassrootUnitDayPubSpendScheduleAnaly.aspx.cs" Inherits="WebPage_CusAnaly_GrassrootUnitDayPubSpendScheduleAnaly" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基层单位日常公用支出明细表</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/float_zxx.js"></script>
    <script src="../../js/layer/layer.js"></script>
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

        .auto-style1 {
            background-color: #D9E7F8;
            font-size: 13.3px;
            height: 15px;
        }

        .ab {
            position: fixed;
            top: 0px;
        }
    </style>

    <script type="text/javascript">
        //验证文本框
        function txtTips(id, msg, guideInt) {
            layer.tips(msg, $("#" + id), {
                guide: guideInt,
                time: 2,
                style: ['background-color:#FF0000; color:#fff', '#FF0000'],
                maxWidth: 240
            });
        }

        function searchRequired() {
            if ($("#tbDate").val() == "") {
                txtTips("tbDate", "请选择查询日期", 1);
                return false;
            }
            //layer.load('正在导出Excel，请稍候...', 0);
            return true;
        }

        //加载层
        function veriSearch() {
            if ($("#tbDate").val() == "") {
                txtTips("tbDate", "请选择查询日期", 1);
                return false;
            }
            layer.load('正在查询并分析数据，请稍候...', 0);
            return true;
        }

        function scrollLis() {
            var toTop = offs.top - $(window).scrollTop();
            if (toTop == 0 || toTop < 0) {
                if (!$('#floatTitleTb').hasClass('ab')) {
                    $('#floatTitleTb').addClass('ab');
                    $('#floatTitleTb').width(($('#dateshowTb').width() + 12));
                }
            } else {
                $('#floatTitleTb').removeClass('ab');
                $('#floatTitleTb').width(($('#dateshowTb').width() + 12));
            }
        }

        $(function () {

            if ($("#HidSearchFlag").val() == "1") {
                layer.closeAll();
                //$("#floatTitleTb").css("style", "width:98.5%");
            }
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HidSearchFlag" Value="0" runat="server" />
        <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;基层单位日常公用支出明细表</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>查询条件</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">年月:</td>
                    <td align="left">
                        <asp:TextBox ID="tbDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})" runat="server" CssClass="txt" ValidationGroup="UnitSetting"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">经费类型:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                            <asp:ListItem Text="零户" Value="1"></asp:ListItem>
                            <asp:ListItem Text="所有" Value="0"></asp:ListItem>
                            <asp:ListItem Text="区级" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="btns" OnClientClick="return veriSearch()" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel " OnClientClick="return searchRequired()" OnClick="btnExport_Click"/>
                    </td>
                </tr>
            </table>
            <table  border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;"> 
                 <tr>
                    <td colspan="23" class="tr1" align="left">&nbsp;<strong>基层单位日常公用支出明细表</strong>
                    </td>
                </tr>
                <tr>
                    <td width="8%" class="tr1" align="center" rowspan="3">所别
                    </td>
                    <td width="6%" class="tr1" align="center" rowspan="3">预算数(万元)
                    </td>
                    <td width="72%" class="tr1" align="center" colspan="18">支出类（元）                        
                    </td>
                    <td width="8%" class="tr1" align="center" colspan="2">合计             
                    </td>
                    <td width="6%" class="tr1" align="center" rowspan="3">结余余额
                    </td>
                </tr>
                <tr>
                    <td width="8%" class="auto-style1" align="center" colspan="2">办公费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">印刷费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">水电费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">邮电费                       
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">差旅费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">公务用车运行维护费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">培训费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">会议费                        
                    </td>
                    <td width="8%" class="auto-style1" align="center" colspan="2">其他                        
                    </td>
                    <td width="5%" class="tr1" align="center" rowspan="2">本月                        
                    </td>
                    <td width="5%" class="tr1" align="center" rowspan="2">累计                        
                    </td>
                </tr>
                <tr>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                    <td width="4%" class="tr1" align="center">本月</td>
                    <td width="4%" class="tr1" align="center">累计</td>
                </tr>                             
                <asp:Repeater ID="RepLeaderQuery" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td width="8%" align="right">
                                <%#Eval("TheOther")%>
                            </td>
                            <td width="6%" align="right">
                                <%#Eval("PlanNum")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("AdminExpThis")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("AdminExpTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("PrintCostThis")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("PrintCostTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("UtilitThis")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("UtilitTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("PostFeesThis")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("PostFeesTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("TravelThis")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("TravelTatol")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("VehicleFeeThis")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("VehicleFeeTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("TrainThis")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("TrainTatol")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("MeetingThis")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("MeetingTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("OtherThis")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("OtherTatol")%>
                            </td>
                            <td width="4%"  align="right">
                                <%#Eval("SumThis")%>
                            </td>
                            <td  width="4%" align="right">
                                <%#Eval("SumTatol")%>
                            </td>
                            <td  width="6%" align="right">
                                <%#Eval("Balance")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        var offs = $('#floatTitleTb').offset();
        $(window).scroll(function () {
            scrollLis();
        });
    </script>
</body>
</html>
