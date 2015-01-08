<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaderQuery.aspx.cs" Inherits="mainPages_LeaderQuery" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>局领导查询</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />

    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="../css/mytable.js"></script>

    <style type="text/css">
        html, body
        {
            overflow: scroll;
            overflow-y: hidden;
            margin: 0;
            height: 100%;
        }

        .txt
        {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }

        .auto-style2 {
            width: 896px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $("#chkAll").click(function () {
                if ($(this).attr("checked") == "checked") {
                    $("input[name='chkItem']").each(function () {
                        $(this).attr("checked", true);
                    });
                }
                else {
                    $("input[name='chkItem']").each(function () {
                        $(this).attr("checked", false);
                    });
                }
            });

            $("input[name='chkItem']").each(function () {
                $(this).click(function () {
                    if ($("input[name='chkItem']").length == $("input[name='chkItem']:checked").length) {
                        $("#chkAll").attr("checked", true);
                    }
                    else {
                        $("#chkAll").attr("checked", false);
                    }
                });
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>局领导查询</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">部门名称:&nbsp;&nbsp;
                    </td>
                    <td class="auto-style2">&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDep" CssClass="txt" runat="server" Width="150px">
                        <%--<asp:ListItem Value="1104">办公室</asp:ListItem>
                        <asp:ListItem Value="1105">人事科</asp:ListItem>
                        <asp:ListItem Value="1106">财务科</asp:ListItem>
                        <asp:ListItem Value="1107">纳税服务科</asp:ListItem>
                        <asp:ListItem Value="1111">全局</asp:ListItem> --%>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">选择年份
                    </td>
                    <td class="auto-style2">&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlyear" runat="server" Width="150px">
                        <%--<asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem >2013</asp:ListItem>
                        <asp:ListItem Selected="True">2014</asp:ListItem>--%>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">选择月份
                    </td>
                    <td class="auto-style2">&nbsp;&nbsp;
                    
                    <asp:DropDownList ID="ddlmonth" runat="server" Width="150px">
                        <asp:ListItem Selected="True">01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>

                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right"></td>
                    <td class="auto-style2">&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" CssClass="btns" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center; width:100%;">
                <tr>
                    <td colspan="6" class="tr1" align="left">&nbsp;<strong>局领导查询列表</strong>
                    </td>
                    <td colspan="1" class="tr1" align="center">
                        <asp:Button ID="btnexport" CssClass="btns" runat="server" Text=" 导出 " OnClick="btnexport_Click" /></td>
                </tr>
                <tr>
                    <td width="11%" class="tr1" align="center">申请时间
                    </td>
                    <td width="11%" class="tr1" align="center">报销单号
                    </td>
                    <%--<td width="11%" class="tr1" align="center">
                    支出类型
                </td>
                <td width="11%" class="tr1" align="center">
                    支出项目
                </td>--%>
                    <td width="11%" class="tr1" align="center">支出科目
                    </td>
                    <td width="11%" class="tr1" align="center">经办人
                    </td>
                    <td width="11%" class="tr1" align="center">金额
                    </td>
                    <td width="13%" class="tr1" align="center">事由
                    </td>
                    <td width="13%" class="tr1" align="center">申请单状态
                    </td>
                </tr>
                <asp:Repeater ID="RepLeaderQuery" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("ARTime")%>
                            </td>
                            <td>
                                <%#Eval("ARReiSinNum")%>
                            </td>
                            <%--<td>
                            <%#Eval("ARExpType")%>
                        </td>
                        <td>
                            <%#Eval("PayPrjName")%>
                        </td>--%>
                            <td>
                                <%#Eval("ARRepDep")%>
                            </td>
                            <td>
                                <%#Eval("ARAgent")%>
                            </td>
                            <td>
                                <%#Eval("ARMon")%>
                            </td>
                            <td>
                                <%#Eval("ARExcu")%>
                            </td>
                            <td>
                                <%#Eval("ARListSta")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="7" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="LeadQueryPager1" Width="500" ImagePath="~/images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
