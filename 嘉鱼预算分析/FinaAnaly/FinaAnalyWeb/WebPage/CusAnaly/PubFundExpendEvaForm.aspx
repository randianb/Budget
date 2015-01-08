<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubFundExpendEvaForm.aspx.cs" Inherits="WebPage_CusAnaly_PubFundExpendEvaForm" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>日常公用经费支出评估表</title>
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
            top: 145px;
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
            if ($("#tbStartDate").val() == "") {
                txtTips("tbStartDate", "请选择查询日期", 1);
                return false;
            }
            if ($("#tbEndDate").val() == "") {
                txtTips("tbEndDate", "请选择查询日期", 1);
                return false;
            }
            //layer.load('正在导出Excel，请稍候...', 0);
            return true;
        }

        //加载层
        function veriSearch() {
            if ($("#tbStartDate").val() == "") {
                txtTips("tbStartDate", "请选择查询日期", 1);
                return false;
            }
            if ($("#tbEndDate").val() == "") {
                txtTips("tbEndDate", "请选择查询日期", 1);
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
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;日常公用经费支出评估表</span><p>
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
                        <asp:TextBox ID="tbStartDate" onFocus="var tbEndDate=$dp.$('tbEndDate');WdatePicker({onpicked:function(){tbEndDate.focus();},maxDate:'#F{$dp.$D(\'tbEndDate\')}',dateFmt:'yyyy-MM'})" runat="server" CssClass="txt" ValidationGroup="UnitEnd"></asp:TextBox>
                        至
                        <asp:TextBox ID="tbEndDate" CssClass ="txt"  runat="server" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'tbStartDate\')}',dateFmt:'yyyy-MM'})"  ValidationGroup="UnitEnd"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbStartDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitEnd"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="tbEndDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitEnd"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
               <tr>
                    <td class="tr1" align="right">经费类型:</td>
                    <td id="searchTd2" align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt"  AutoPostBack="True">
                            <asp:ListItem Text="零户" Value="1"></asp:ListItem>
                            <asp:ListItem Text="所有" Value="0"></asp:ListItem>                           
                            <asp:ListItem Text="区级" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td id="searchTd3" align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询"  CssClass="btns" OnClientClick="return veriSearch()" OnClick="btnSearch_Click"/>
                        <asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel " OnClientClick="return searchRequired()" OnClick="btnExport_Click"/>
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>                
            </table>
            <table id="floatTitleTb" border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="2" class="tr1" align="left">&nbsp;<strong>日常公用经费支出评估表</strong>
                    </td>
                    <td colspan="17" class="tr1" align="right">&nbsp;<strong>单位（元）</strong>
                    </td>
                </tr>
                <tr>
                    <td width="23%" align="center" class="tr1">经济科目
                    </td>
                    <td width="7%" align="center" class="tr1">本期支出总数
                    </td>
                    <td width="7%" align="center" class="tr1">同期支出总数
                    </td>
                    <td width="7%" align="center" class="tr1">同期±%
                    </td>
                    <td width="7%" align="center" class="tr1">增减值
                    </td>
                    <td width="7%" align="center" class="tr1">本期人平数
                    </td>
                    <td width="7%" align="center" class="tr1">同期人平数
                    </td>
                    <td width="7%" align="center" class="tr1">人平±%
                    </td>
                    <td width="7%" align="center" class="tr1">增减值
                    </td>
                    <td width="7%" align="center" class="tr1">本期区域人平数
                    </td>
                    <td width="7%" align="center" class="tr1">人平区域±%
                    </td>
                    <td width="7%" align="center" class="tr1">增减值
                    </td>
                </tr>
            </table>
            <table id="dateshowTb" border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;margin-top:-7px;">               
                <asp:Repeater ID="RepPubFund" runat="server">
                    <ItemTemplate>
                        <tr>
                            <%--<td align="center">
                                <%#Eval("column1")%>
                            </td>--%>
                            <td width="23%" align="left">
                                <%#Eval("column2")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column3")%>
                            </td>
                            <td  width="7%" align="right">
                                <%#Eval("column4")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column5")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column6")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column7")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column8")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column9")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column10")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column11")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column12")%>
                            </td>
                            <td width="7%"  align="right">
                                <%#Eval("column13")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="13" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="LeadQueryPager1" Width="500" ImagePath="~/images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <%--<tr>
                    <td class="tr1">
                        <asp:Button ID="btnComplexAssessAnalyTB" runat="server" Text="综合评估分析表" CssClass="btns" OnClick="btnComplexAssessAnalyTB_Click" />&nbsp;
                        <asp:Button ID="btnBalanceEvaForm" runat="server" Text="资产负债评估表" CssClass="btns" OnClick="btnBalanceEvaForm_Click" />&nbsp; 
                        <asp:Button ID="btnFundIncEvaForm" runat="server" Text="经费收入评估表" CssClass="btns" OnClick="btnFundIncEvaForm_Click" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        var offs = $('#floatTitleTb').offset();
        var offs1 = $('#fixed').offset();
        $(window).scroll(function () {
            scrollLis();
        });
    </script>
</body>
</html>
