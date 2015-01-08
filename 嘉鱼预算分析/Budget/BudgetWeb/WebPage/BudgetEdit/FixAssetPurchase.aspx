<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FixAssetPurchase.aspx.cs" Inherits="BudgetPage_mainPages_FixAssetPurchase" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>固定资产管理列表</title>
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
       
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="2" class="tr1" align="left">固定资产采购添加
                    </td>
                </tr>
                <tr align="center">
                    <td width="20%"  class="tr1" align="right">操作： &nbsp;
                    </td>
                    <td align="left">&nbsp; 
                        <asp:Button ID="btnAdd" CssClass="btns" runat="server"  Text="添加资产" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnBack" CssClass="btns" runat="server" Text=" 返回 " OnClick="btnBack_Click"  />
                    </td>
                    
                        
                    
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="8" class="tr1" align="left">&nbsp;<strong>固定资产采购情况表显示及操作</strong>
                    </td>
                </tr>
                <tr>
                    <td width="12.5%" class="tr1" align="center">固定资产名称
                    </td>
                    <td width="12.5%" class="tr1" align="center">型号
                    </td>
                    <td width="12.5%" class="tr1" align="center">品牌
                    </td>
                    <td width="12.5%" class="tr1" align="center">单价
                    </td>
                    <td width="12.5%" class="tr1" align="center">数量
                    </td>
                    <td width="12.5%" class="tr1" align="center">时间
                    </td>
                    <td width="12.5%" class="tr1" align="center">修改
                    </td>
                    <td width="12.5%" class="tr1" align="center">删除
                    </td>
                </tr>
                <asp:Repeater ID="repFix" runat="server" OnItemCommand="repFix_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("FAName")%>
                            </td>
                            <td>
                                <%#Eval("FAModel")%>
                            </td>
                            <td>
                                <%#Eval("FABrand")%>
                            </td>
                            <td>
                                <%#Eval("FAPrice")%>
                            </td>
                            <td>
                                <%#Eval("FANum")%>
                            </td>
                            <td>
                                <%#Eval("FATime")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkUpd" CommandName="UpdFix" CommandArgument='<%#Eval("FAID")%>' runat="server" Text="修改"></asp:LinkButton>
                            </td>
                               <td>
                                <asp:LinkButton ID="linkDel" CommandName="DelFix" CommandArgument='<%#Eval("FAID")%>' OnClientClick="return confirm('确认删除该条记录？')"
                                    runat="server" Text="删除"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="500" ImagePath="~/images/PagerGif"
                            NavigationButtonType="Image" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always"
                            ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ButtonImageExtension="gif"
                            PageSize="20" NumericButtonCount="9" MoreButtonType="Image" runat="server">
                            runat="server">
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
