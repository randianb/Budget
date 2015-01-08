<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetCollect.aspx.cs" Inherits="WebPage_BudgetEdit_BudgetCollect" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预算汇总</title>
    <script src="css/mytable.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function FildNameShowByChk() {
            if ($("#cbBIProType").attr("checked") == "checked") {
                $("#lblFildName").text("部门名称");
            }
            else {
                $("#lblFildName").text("功能科目");
            }
        }





        $(function () {
            $("#ddlDep").change(function () {
                if ($(this).val() == "0") {
                    $("#cbBIProType").attr("disabled", false);
                }
                else {
                    $("#cbBIProType").attr("disabled", true);
                    $("#cbBIProType").attr("checked", false);
                }
            });
            FildNameShowByChk();
            $("#cbBIProType").click(function () {
                FildNameShowByChk();
            });




            $("#topTb input[type='hidden']").each(function () {
                if ($(this).val() == "-1") {

                    var tr = this.parentNode.parentNode;
                    $(tr).css("color", "#FF0033");
                } 
            });
        });
    </script>
    <style type="text/css">
        html, body {
            overflow: scroll;
            overflow-y: hidden;
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
</head>
<body>
    <form id="form1" runat="server">

        <asp:HiddenField ID="hidDepID" runat="server" />
<asp:HiddenField ID="hidtotal" runat="server" />
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>预算汇总列表查询</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">部门名称：&nbsp;
                    </td>
                    <td>&nbsp; &nbsp;
                    <asp:DropDownList ID="ddlDep" CssClass="txt" runat="server">
                    </asp:DropDownList>
                        &nbsp;
                        <asp:CheckBox ID="cbBIProType" Text="按照项目类型汇总" Enabled="false" runat="server" />&nbsp;
                        <asp:RadioButton ID="rbtnAudit" runat="server" Text="审核通过" Checked="true" GroupName="rbType" />&nbsp;
                        <asp:RadioButton ID="rbtnReported" runat="server" Text="已上报" GroupName="rbType" />&nbsp;
                        <asp:Button ID="btnSelect" CssClass="btns" runat="server" Text=" 查  询 " OnClick="btnSelect_Click" />
                        <asp:Label ID="lashow" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="topTb" runat="server">
                <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                    <tr>
                        <td colspan="6" class="tr1" align="left">&nbsp;<strong>预算汇总列表数据显示及操作</strong></td>
                        <td colspan="1" class="tr1" align="center">
                            <asp:Button ID="btnexport0" CssClass="btns" runat="server" Text=" 导出全部 " OnClick="btnexport_Click" />
                        </td>
                        <td colspan="1" class="tr1" align="center">
                            <asp:Button ID="Button2" CssClass="btns" runat="server" Text=" 导出当前页 " OnClick="btnexport_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="tr1" align="center">项目编号
                        </td>
                        <td width="15%" class="tr1" align="center">项目类型
                        </td>
                        <td width="15%" class="tr1" align="center">项目名称
                        </td>

                        <td width="15%" class="tr1" align="center">
                            <asp:Label ID="lblFildName" runat="server" Text="功能科目"></asp:Label>
                        </td>
                        <td width="10%" class="tr1" align="center">预算金额
                        </td>
                        <td width="10%" class="tr1" align="center">年度
                        </td>
                        <td width="10%" class="tr1" align="center">项目状态
                        </td>
                        <td width="10%" class="tr1" align="center">查看
                        </td>

                    </tr>
                    <asp:Repeater ID="repBudget" runat="server" OnItemCommand="repBudget_ItemCommand" OnItemDataBound="repBudget_ItemDataBound">
                        <ItemTemplate>
                            <tr class="SignStyle">
                                <td>
                                    <%#Eval("BICode")%>
                                </td>
                                <td>
                                    <%#Eval("BIProType")%>
                                </td>
                                <td>
                                    <%#Eval("BIProName")%>
                                </td>

                                <td>
                                    <%#Eval("BIFunSub")%>
                                </td>
                                <td>
                                    <%#Eval("BIMon")%>
                                </td>
                                <td>
                                    <%# Common.common.GetYear(Eval("BIStaTime").ToString()) %>
                                </td>
                                <td>
                                    <%#Eval("BudSta")%>
                                </td>

                                <td>
                                    <asp:HiddenField ID="HidBudID" Value='<%#Eval("IsRed")%>' runat="server" />

                                    <asp:LinkButton ID="linkReview" CommandName="Review" CommandArgument='<%#Eval("BudID")%>' runat="server" Text="查看"></asp:LinkButton>
                                </td>
                                <%--<td>
                                <asp:LinkButton ID="linkDel" CommandName="DelBI" CommandArgument='<%#Eval("BudID")%>' OnClientClick="return confirm('确认删除该条记录？')"
                                    runat="server" Text="删除"></asp:LinkButton>
                            </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="8" class="tr1" align="center">
                            <webdiyer:AspNetPager ID="BudgetPager" Width="500" ImagePath="~/img/PagerGif"
                                NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                                ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                                PageSize="12" NumericButtonCount="9" MoreButtonType="Image" runat="server" OnPageChanged="BudgetPager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>


            </div>
            <div id="Div1" runat="server">
                <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                    <tr>
                        <td colspan="5" class="tr1" align="left">&nbsp;<strong>预算汇总列表数据显示及操作1</strong>
                        </td>
                        <td colspan="1" class="tr1" align="center">
                            <asp:Button ID="btnexport" CssClass="btns" runat="server" Text=" 导出全部 " OnClick="btnexport_Click" /></td>
                        <td colspan="1" class="tr1" align="center">
                            <asp:Button ID="Button1" CssClass="btns" runat="server" Text=" 导出当前页 " OnClick="btnexport_Click" /></td>
                    </tr>
                    <tr>
                        <td width="15%" class="tr1" align="center">部门名称
                        </td>
                        <td width="15%" class="tr1" align="center">项目类型
                        </td>
                        <td width="15%" class="tr1" align="center">项目名称
                        </td>
                        <td width="10%" class="tr1" align="center">预算金额
                        </td>
                        <td width="10%" class="tr1" align="center">年度
                        </td>
                        <td width="10%" class="tr1" align="center">项目状态
                        </td>
                        <td width="10%" class="tr1" align="center">查看
                        </td>

                    </tr>
                    <asp:Repeater ID="repBudget1" runat="server" OnItemCommand="repBudget_ItemCommand" OnItemDataBound="repBudget_ItemDataBound">
                        <ItemTemplate>
                            <tr class="SignStyle" id="listtr" runat="server">
                                <td>
                                    <%#Eval("DepName")%>
                                </td>
                                <td>
                                    <%#Eval("BIProType")%>
                                </td>
                                <td>
                                    <%#Eval("BIProName")%>
                                </td>

                                <%--  <td>
                                    <%#Eval("BIFunSub")%>
                                </td>--%>
                                <td>
                                    <%#Eval("BIMon")%>
                                </td>
                                <td>
                                    <%# Common.common.GetYear(Eval("BIStaTime").ToString()) %>
                                </td>
                                <td>
                                    <%#Eval("BudSta")%>
                                </td>

                                <td>
                                    <%-- <asp:HiddenField ID="HidBudID" Value='<%#Eval("IsRed")%>' runat="server" />--%>

                                    <asp:LinkButton ID="linkReview" CommandName="Review" CommandArgument='<%#Eval("BudID")%>' runat="server" Text="查看"></asp:LinkButton>
                                </td>
                                <%--<td>
                                <asp:LinkButton ID="linkDel" CommandName="DelBI" CommandArgument='<%#Eval("BudID")%>' OnClientClick="return confirm('确认删除该条记录？')"
                                    runat="server" Text="删除"></asp:LinkButton>
                            </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="8" class="tr1" align="center">
                            <webdiyer:AspNetPager ID="BudgetPager1" Width="500" ImagePath="~/img/PagerGif"
                                NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                                ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                                PageSize="12" NumericButtonCount="9" MoreButtonType="Image" runat="server" OnPageChanged="BudgetPager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
            <%--      <div id="BottTb" runat="server" visible="false">
                <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                    <tr>
                        <td colspan="5" class="tr1" align="left">&nbsp;<strong>预算按项目类型汇总列表数据显示及操作</strong>
                        </td>
                    </tr>
                    <tr>

                        <td width="15%" class="tr1" align="center">项目类型
                        </td>

                        <td width="10%" class="tr1" align="center">预算金额
                        </td>
                        <td width="10%" class="tr1" align="center">年度
                        </td>
                        <td width="10%" class="tr1" align="center">项目状态
                        </td>
                        <td width="10%" class="tr1" align="center">查看
                        </td>

                    </tr>
                    <asp:Repeater ID="repBudProType" runat="server" OnItemCommand="repBudget_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("BIProType")%>
                                </td>
                                <td>
                                    <%#Eval("BIMon")%>
                                </td>
                                <td>
                                    <%# Eval("BIStaTime") %>
                                </td>
                                <td>
                                    <%#Eval("BudSta")%>
                                </td>

                                <td>
                                    <asp:LinkButton ID="linkReview" CommandName="Review" CommandArgument='<%#Eval("BIProType")%>' ToolTip='<%# Eval("BIStaTime") %>' runat="server" Text="查看"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="5" class="tr1" align="center">
                            <webdiyer:AspNetPager ID="BudProTypePager" Width="500" ImagePath="~/BudgetPage/images/PagerGif"
                                NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                                ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                                PageSize="10" NumericButtonCount="9" MoreButtonType="Image" runat="server" OnPageChanged="BudProTypePager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>--%>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>

</html>


