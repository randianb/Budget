<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudProjectList.aspx.cs" Inherits="WebPage_Setting_BudProjectList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算项目</title>

    <script src="../BudgetEdit/css/mytable.js" type="text/javascript"></script>
    <link href="../BudgetEdit/css/whsystem.css" rel="stylesheet" />
    <link href="../BudgetEdit/css/whtable.css" rel="stylesheet" />
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>项目控制数据</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">数据
                    </td>
                    <td>&nbsp; &nbsp;
                    <asp:Button ID="btnAdd" CssClass="btns" runat="server" Text=" 添  加 " OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="5" class="tr1" align="left">&nbsp;<strong>项目控制列表</strong>

                    </td>

                </tr>
                <tr>
                    <td width="20%" class="tr1" align="center">支出经济科目
                    </td>
                    <td width="20%" class="tr1" align="center">是否启用
                    </td>
                    <td width="20%" class="tr1" align="center">备注
                    </td>
                    <td width="20%" class="tr1" align="center">修改
                    </td>
                    <td width="20%" class="tr1" align="center">删除
                    </td>
                </tr>
                <asp:Repeater ID="repBudPro" runat="server" OnItemCommand="repBudPro_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("PIEcoSubName")%>
                            </td>
                            <td>
                                <%#Eval("YNUse")%>
                            </td>
                            <td>
                                <%#Eval("BCRemark")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtnAlt" CommandName="AltPro" CommandArgument='<%#Eval("PIID")%>' runat="server" Text="修改"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="linkDel" CommandName="DelPro" CommandArgument='<%#Eval("PIID")%>' runat="server" Text="删除"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="5" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="ProListPager" Width="500" ImagePath="~/images/PagerGif"
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
