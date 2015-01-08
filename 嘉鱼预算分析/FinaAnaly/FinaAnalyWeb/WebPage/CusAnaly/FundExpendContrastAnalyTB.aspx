<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundExpendContrastAnalyTB.aspx.cs" Inherits="WebPage_CusAnaly_FundExpendContrastAnalyTB" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经费支出对比分析表</title>
     <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
   
    <script src="../../js/float_zxx.js"></script>
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

       .ab {
            position: fixed;
            top: 0px;
        }
          .ab1 {
            position: fixed;
            top: 108px;
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
                if (!$('#floatTitleTb').hasClass('ab1')) {
                    $('#floatTitleTb').addClass('ab1');
                    $('#floatTitleTb').width(($('#dateshowTb').width() + 12));
                }
                if (!$('#fixed').hasClass('ab')) {
                    $('#fixed').addClass('ab');
                    $('#fixed').width(($('#dateshowTb').width() + 12));
                }
                $("#searchTd1").addClass("tr1");
                $("#searchTd2").addClass("tr1");
                $("#searchTd3").addClass("tr1");


            } else {
                $('#fixed').removeClass('ab');
                $('#fixed').width(($('#dateshowTb').width() + 12));
                $('#floatTitleTb').removeClass('ab1');
                $('#floatTitleTb').width(($('#dateshowTb').width() + 12));


                $("#searchTd1").removeClass("tr1");
                $("#searchTd2").removeClass("tr1");
                $("#searchTd3").removeClass("tr1");
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
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;经费支出对比分析表</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table id="fixed" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>查询条件</strong>
                    </td>
                </tr>           
                <tr>
                    <td class="tr1" align="right">年月:</td>
                    <td id="searchTd1" align="left">
                        <asp:TextBox ID="tbDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})" runat="server" CssClass="txt" ValidationGroup="UnitSetting"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td id="searchTd2" align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询"  CssClass="btns"  OnClientClick="return veriSearch()" OnClick="btnSearch_Click"/>
                        <asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel " OnClientClick="return searchRequired()" OnClick="btnExport_Click"/>
                    </td>
                </tr>                
            </table>
            <table id="floatTitleTb" border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
               <tr>
                    <td colspan="19" class="tr1" align="left">&nbsp;<strong>经费支出对比分析表</strong>
                    </td>
                </tr>               
                <tr>
                    <td width="15%" id="firstTd" align="center" rowspan="3" class="tr1">支出项目
                    </td>
                    <td width="30%" align="center" colspan="6" class="tr1">上年支出（元）
                    </td>
                    <td width="30%" align="center" colspan="6" class="tr1">本年支出（元）
                    </td>
                    <td width="10%" align="center" colspan="2" class="tr1">比同期+、-%
                    </td>
                    <td width="10%" align="center" colspan="2" class="tr1">比同期+、-额（元）
                    </td>
                    <td width="5%" align="center" rowspan="3" class="tr1">备   注
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="center" class="tr1" colspan="3">本月</td>
                    <td width="15%" align="center" class="tr1" colspan="3">累计</td>
                    <td width="15%" align="center" class="tr1" colspan ="3">本月</td>
                    <td width="15%" align="center" class="tr1" colspan ="3">累计</td>
                    <td width="5%" align="center" class="tr1" rowspan="2">本月</td>
                    <td width="5%" align="center" class="tr1" rowspan="2">累计</td>
                    <td width="5%" align="center" class="tr1" rowspan="2">本月</td>
                    <td width="5%" align="center" class="tr1" rowspan="2">累计</td>
                </tr>
                <tr>
                    <td width="5%" align="center" class="tr1">合计</td>
                    <td width="5%" align="center" class="tr1">零户经费</td>
                    <td width="5%" align="center" class="tr1">区级经费</td>
                    <td width="5%" align="center" class="tr1">合计</td>
                    <td width="5%" align="center" class="tr1">零户经费</td>
                    <td width="5%" align="center" class="tr1">区级经费</td>
                    <td width="5%" align="center" class="tr1">合计</td>
                    <td width="5%" align="center" class="tr1">零户经费</td>
                    <td width="5%" align="center" class="tr1">区级经费</td>
                    <td width="5%" align="center" class="tr1">合计</td>
                    <td width="5%" align="center" class="tr1">零户经费</td>
                    <td width="5%" align="center" class="tr1">区级经费</td>
                </tr>
            </table>
            <table id="dateshowTb" border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;margin-top:-7px">               
                <asp:Repeater ID="RepFunExpend" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="15%" align="left">
                            <%#Eval("column1")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column2")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column3")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column4")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column5")%>
                        </td> 
                        <td width="5%"  align="right">
                            <%#Eval("column6")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column7")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column8")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column9")%>
                        </td>
                        <td  width="5%" align="right">
                            <%#Eval("column10")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column11")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column12")%>
                        </td> 
                         <td width="5%"  align="right">
                            <%#Eval("column13")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column14")%>
                        </td>  
                         <td width="5%"  align="right">
                            <%#Eval("column15")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column16")%>
                        </td>
                        <td width="5%"  align="right">
                            <%#Eval("column17")%>
                        </td>
                        <td  width="5%" align="right">
                            <%#Eval("column18")%>
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