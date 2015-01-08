<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyList.aspx.cs" Inherits="BudgetPage_mainPages_ApplyList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>申请</title>
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
        .auto-style1 {
            width: 883px;
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
    <!-- 表头开始 -->
    <!-- 表头结束 --><div class="table_list">
             <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
            <tr>
                <td colspan="2" class="tr1">
                    &nbsp;<strong>申请表</strong>
                </td>
            </tr>
            
            <tr>
                <td width="20%" class="tr1 right">
                     选择年份
                </td>
                <td class="auto-style1">
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlYear" runat="server" width="150px">
                        <%--<asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem >2013</asp:ListItem>
                        <asp:ListItem Selected="True">2014</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
                 <tr>
                <td width="20%" class="tr1 right">
                     选择月份
                </td>
                <td class="auto-style1">
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMonth" runat="server" width="150px">
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
                <td width="20%" class="tr1 right">
                </td>
                <td class="auto-style1">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSearch" CssClass="btns" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
               
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" CssClass="btns" runat="server" Text=" 添加 " OnClick="btnAdd_Click" />
                    <asp:Label runat="server" ID="lbshow" ForeColor="Red"></asp:Label>
                </td>
            
            
            </tr>
        </table>
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="9" class="tr1" align="left">
                    &nbsp;<strong>申请列表</strong>
                </td>
            </tr>
            <tr>
                <td width="10%" class="tr1" align="center">
                    申请时间
                 </td>
                <td width="10%" class="tr1" align="center">
                    报销单号
                </td>
                <%--<td width="10%" class="tr1" align="center">
                    支出类型
                </td>
                <td width="10%" class="tr1" align="center">
                    支出项目
                </td>--%>
                <td width="10%" class="tr1" align="center">
                    上报单位
                </td>
                <td width="10%" class="tr1" align="center">
                    经办人
                </td>
                <td width="10%" class="tr1" align="center">
                    金额
                </td>
                <td width="10%" class="tr1" align="center">
                    申请表状态
                </td>
                <td width="7%" class="tr1" align="center">
                    提交
                </td>
                <td width="7%" class="tr1" align="center">
                    修改
                </td>
                <td width="6%" class="tr1" align="center">
                    删除
                </td>

            </tr>
            <asp:Repeater ID="repReiStaQue" runat="server" OnItemCommand="repReiStaQue_ItemCommand">
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
                            <%#Eval("ARListSta")%>
                        </td>
                        <td>
                        <asp:LinkButton ID="lbtnTJ" CommandName="lbtnTJ" CommandArgument='<%#Eval("ARID")%>' runat="server" Text="提交"></asp:LinkButton>
                        </td>
                         <td>
                        <asp:LinkButton ID="lbtnAlt" CommandName="AltPro" CommandArgument='<%#Eval("ARID")%>' runat="server" Text="修改"></asp:LinkButton>
                        </td>
                        <td>
                        <asp:LinkButton ID="linkDel" CommandName="DelPro" CommandArgument='<%#Eval("ARID")%>' runat="server" Text="删除"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="9" class="tr1" align="center">
                    <webdiyer:AspNetPager ID="ReiStaQuePager" Width="500" ImagePath="~/images/PagerGif"
                        NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                        ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                        PageSize="20" NumericButtonCount="10" MoreButtonType="Image" runat="server">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
