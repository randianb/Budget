<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoricalTra.aspx.cs" Inherits="BudgetPage_mainPages_HistoricalTra" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>历史记录</title>

    <script src="css/mytable.js" type="text/javascript"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
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
        <asp:HiddenField ID="hidBudID" runat="server" />
     
        <!-- 表头结束 -->
        <div class="table_list">
            <%--<table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">历史记录列表</td>
                </tr>
                <tr>
                    <td width="20%" class="tr1" align="right">部门名称
                    </td>
                    <td>&nbsp; &nbsp;
                    <asp:DropDownList ID="ddlDep" CssClass="txt" runat="server">
                    </asp:DropDownList>
                        <asp:Button ID="btnSelect" CssClass="btns" runat="server" Text=" 查  询 " OnClick="btnSelect_Click" />
                    </td>
                </tr>
            </table>--%>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="8" class="tr1" align="left">&nbsp;<strong>历史记录列表数据显示及操作</strong>
                    </td>
                </tr>
                <tr>
                    <td width="12.5%" class="tr1" align="center">项目编号
                    </td>
                    <td width="12.5%" class="tr1" align="center">项目名称
                    </td>
                    <td width="12.5%" class="tr1" align="center">项目类别
                    </td>
                    <td width="12.5%" class="tr1" align="center">功能科目
                    </td>
                    <td width="12.5%" class="tr1" align="center">预算金额
                    </td>
                    <td width="12.5%" class="tr1" align="center">预算控制数
                    </td>
                    <td width="12.5%" class="tr1" align="center">项目状态
                    </td>
                    <td width="12.5%" class="tr1" align="center">查看
                    </td>
                </tr>
                <asp:Repeater ID="repTra" runat="server" OnItemCommand="repTra_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("BICode")%>
                            </td>
                            <td>
                                <%#Eval("BIProName")%>  <%--BICharger--%>
                            </td>
                            <td>
                                <%#Eval("BIProType")%>
                            </td>
                            <td>
                                <%#Eval("BIFunSub")%>
                            </td>
                            <td>
                                <%#Eval("BIMon")%>
                            </td>
                            <td>
                                <%#Eval("BIConNum")%>
                            </td>
                            <td>
                                <%#Eval("BudSta")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="linkLook" CommandName="Look" CommandArgument='<%#Eval("BudHisID")%>' runat="server" Text="查看"></asp:LinkButton>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="TraPager" Width="500" ImagePath="~/img/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="12" NumericButtonCount="9" MoreButtonType="Image" runat="server" OnPageChanged="TraPager_PageChanged"></webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
             <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;" class="auto-style1">
                <tr>
                    <td class="tr1" align="left">页面操作
                    </td>
                </tr>
                <tr align="right">
                    <td>
                        <asp:Button ID="btnBack" CssClass="btns" runat="server" Text="  返回  " OnClick="btnBack_Click"/>
            
                    </td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
    <p>
        &nbsp;&nbsp;
    </p>
</body>
</html>
