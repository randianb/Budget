<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepExecution.aspx.cs" Inherits="WebPage_CusAnaly_DepExecution" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门经费一览表</title>
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
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;部门经费一览表</span><p>
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
                    <td class="tr1" align="right">部门:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDep" runat="server" CssClass="txt" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">年月:</td>
                    <td align="left">
                        <asp:TextBox ID="tbDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})" runat="server" CssClass="txt"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">经费类型:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Text="零户" Value="1"></asp:ListItem>
                            <asp:ListItem Text="所有" Value="0"></asp:ListItem>                           
                            <asp:ListItem Text="区级" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="btns"  OnClientClick="return veriSearch()" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel " OnClientClick="return searchRequired()" OnClick="btnExport_Click"/>
                    </td>
                </tr>
            </table>

            <div id="TbOne" runat="server">
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="8" class="tr1" align="left">&nbsp;<strong>部门执行情况表</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="center" rowspan="2" class="tr1">部门名称
                        </td>
                        <td width="10%" align="center" rowspan="2" class="tr1">年初预算(万元)
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">本期数(元)
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">同期数(元)
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">差额比
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                    </tr>
                    <asp:Repeater ID="RepBugetTarget" runat="server" OnItemCommand="RepBugetTarget_ItemCommand">
                        <ItemTemplate>
                            <tr onmousemove="javascript:this.bgColor='#B0CDED';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("DepID")%>' CommandName="PostToDetails" Text='<%#Eval("column1")%>'></asp:LinkButton>
                                </td>
                                <td align="right">
                                    <%#Eval("column2")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column3")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column4")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column5")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column6")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column7")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column8")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="TotalOne" runat="server">
                        <td align="center" width="30%"><strong>合计</strong></td>
                        <td align="right" width="10%">                            
                            <asp:Label ID="txtStartMon" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="10%">
                            <asp:Label ID="TextBox1" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="10%">
                            <asp:Label ID="TextBox2" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right"  width="10%">
                            <asp:Label ID="TextBox3" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="10%">
                            <asp:Label ID="TextBox4" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right"  width="10%">
                            <asp:Label ID="TextBox5" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right"  width="10%">
                            <asp:Label ID="TextBox6" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="TbTwo" runat="server">
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="1" class="tr1" align="left">&nbsp;<strong>部门执行情况表</strong>
                        </td>
                        <td colspan="6" class="tr1" align="right">&nbsp;<strong>单位（元）</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="center" class="tr1" rowspan="2">部门名称
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">本期数
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">同期数
                        </td>
                        <td width="25%" align="center" class="tr1" colspan="2">差额比
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                        <td align="center" class="tr1">本月
                        </td>
                        <td align="center" class="tr1">累计
                        </td>
                    </tr>
                    <asp:Repeater ID="repDepExecut" runat="server" OnItemCommand="repDepExecut_ItemCommand">
                        <ItemTemplate>
                            <tr onmousemove="javascript:this.bgColor='#B0CDED';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="PostToDetails" CommandArgument='<%#Eval("DepID")%>' Text='<%#Eval("column1")%>'></asp:LinkButton>
                                </td>
                                <td align="right">
                                    <%#Eval("column2")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column3")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column4")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column5")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column6")%>
                                </td>
                                <td align="right">
                                    <%#Eval("column7")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="TotalTwo" runat="server" class="tr1">
                        <td align="center" width="20%"><strong>合计</strong></td>
                        <td align="right" width="15%">
                            <asp:Label ID="txtThisThis" runat="server" Text=""></asp:Label>
                        </td>                                                            
                        <td align="right" width="15%">                                   
                            <asp:Label ID="txtThisTotal" runat="server" Text=""></asp:Label>
                        </td>                                                            
                        <td align="right"  width="15%">                                  
                            <asp:Label ID="txtLastThis" runat="server" Text=""></asp:Label>
                        </td>                                                            
                        <td align="right" width="15%">                                   
                            <asp:Label ID="txtLastTotal" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right"  width="10%">
                            <asp:Label ID="txtDifThis" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right"  width="10%">
                            <asp:Label ID="txtDifTotal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
