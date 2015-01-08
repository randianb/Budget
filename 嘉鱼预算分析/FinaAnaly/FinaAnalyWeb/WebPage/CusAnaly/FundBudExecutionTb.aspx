<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundBudExecutionTb.aspx.cs" Inherits="WebPage_CusAnaly_FundBudExecutionTb" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经费预算执行情况表</title>
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
        .auto-style1 {
            background-color: #D9E7F8;
            font-size: 13.3px;
            height: 15px;
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
            <span>当前位置：<b>定制分析</b>&nbsp;&nbsp;>&nbsp;&nbsp;经费预算执行情况表</span><p>
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
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbDate" Display="Dynamic" ErrorMessage="* 年月不能为空" ForeColor="Red" ValidationGroup="UnitSetting"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">经费类型:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="txt"  AutoPostBack="True">
                            <asp:ListItem Text="零户" Value="1"></asp:ListItem>
                            <asp:ListItem Text="所有" Value="0"></asp:ListItem>                           
                            <asp:ListItem Text="区级" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">查询:</td>
                    <td align="left">
                        <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="btns"  OnClientClick="return veriSearch()" OnClick="btnSearch_Click"/>
                        <asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel " OnClientClick="return searchRequired()" OnClick="btnExport_Click"/>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="1" class="tr1" align="left">&nbsp;<strong>经费预算执行情况表</strong>
                    </td>
                    <td colspan="8" class="tr1" align="right">&nbsp;<strong>单位:万元</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="center" >项目分类
                     </td>
                    <td width="10%" class="tr1" align="center"> 合计
                    </td>
                    <td width="10%" class="tr1" align="center"> 本年预算指标
                    </td>
                    <td width="10%" class="tr1" align="center"> 增拨预算指标
                    </td>
                    <td width="10%" class="tr1" align="center" >本月实际支出                        
                     </td>
                    <td width="10%" class="tr1" align="center" >累计实际支出            
                    </td>
                    <td width="10%" class="tr1" align="center" >占预算比例
                    </td>
                    <td width="10%" class="tr1" align="center" >结余预算指标            
                    </td>
                    <td width="10%" class="tr1" align="center" >备注
                    </td>
                </tr>               
                <asp:Repeater ID="RepLeaderQuery" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <%#Eval("column1")%>
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
                            <td align="right">
                                <%#Eval("column9")%>
                            </td>                         
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>