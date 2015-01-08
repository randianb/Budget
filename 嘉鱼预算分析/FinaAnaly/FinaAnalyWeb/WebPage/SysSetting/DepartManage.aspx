<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartManage.aspx.cs" Inherits="WebPage_SysSetting_DepartManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门设置</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 200px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;部门设置</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>部门信息操作</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center"></td>
                    <td align="left">
                        <asp:Button ID="btnAddDepart" runat="server" Text=" 添加部门 " CssClass="btns" OnClick="btnAddDepart_Click" />
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                <tr>
                    <td class="tr1" colspan="5">&nbsp;<strong>部门信息列表</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center">部门编号
                    </td>
                    <td class="tr1" width="25%" align="center">部门名称
                    </td>
                    <td class="tr1" width="30%" align="center">部门备注
                    </td>
                    <td class="tr1" width="15%" align="center">修改
                    </td>
                    <td class="tr1" width="15%" align="center">删除
                    </td>
                </tr>
                <asp:Repeater ID="repDepart" runat="server" OnItemCommand="repDepart_ItemCommand">
                    <ItemTemplate>
                        <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                            <td align="center">
                                <%# Eval("DepID") %>
                            </td>
                            <td align="center">
                                <%# Eval("DepName") %>
                            </td>
                            <td align="center">
                                <%# Eval("DepRem") %>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnUpd" CommandName="UpdDep" CommandArgument='<%# Eval("DepID") %>'
                                    runat="server" Text="修改"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnDel" CommandName="DelDep" OnClientClick='return confirm("是否删除该行记录？")' CommandArgument='<%# Eval("DepID") %>'
                                    runat="server" Text="删除"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="tr1" colspan="5" align="center">
                        <webdiyer:AspNetPager ID="pagerDepart" Width="500" ImagePath="../../images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="14" NumericButtonCount="10" MoreButtonType="Image" runat="server" OnPageChanged="pagerDepart_PageChanged">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
