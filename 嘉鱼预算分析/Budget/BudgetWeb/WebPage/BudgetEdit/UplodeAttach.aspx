<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UplodeAttach.aspx.cs" Inherits="BudgetPage_mainPages_UplodeAttach" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>附件管理列表</title>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="css/mytable.js" type="text/javascript"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />
    <script src="My97DatePicker/WdatePicker.js"></script>
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
    <script type="text/javascript">

        function CheckFileType(btnid, uploadid, lblid) {
            var objButton = document.getElementById(btnid); //上传按钮
            var objFileUpload = document.getElementById(uploadid); //FileUpload
            var objMSG = document.getElementById(lblid); //显示提示信息用的DIV
            var FileName = new String(objFileUpload.value); //文件名
            var extension = new String(FileName.substring(FileName.lastIndexOf(".") + 1, FileName.length)); //文件扩展名

            if (extension == "doc" || extension == "docx") {
                objButton.disabled = false; //启用上传按钮
                objMSG.innerHTML = "";
            }
            else {
                objButton.disabled = true; //禁用上传按钮
                objMSG.innerHTML = "* 请您选择doc文件";
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>上传附件</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">上传附件：
                    </td>
                    <td>&nbsp; &nbsp;
                    <asp:FileUpload ID="fup" Width="200" onChange="javascript:CheckFileType('btn', 'fup', 'lbl');"
                        CssClass="txt" runat="server"></asp:FileUpload>
                        &nbsp; &nbsp;
                    
                    <asp:Button ID="btn" CssClass="btns" Enabled="False" runat="server" Text=" 导入 " OnClick="btn_Click" />
                        <asp:Button ID="btnBack" CssClass="btns" runat="server" Text=" 返回 " OnClick="btnBack_Click" />
               
                    <asp:Label ID="lbl" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="4" class="tr1" align="left">&nbsp;<strong>上传附件列表</strong>
                    </td>
                </tr>
                <tr>
                    <td width="25%" class="tr1" align="center">编号
                    </td>
                    <td width="30%" class="tr1" align="center">名称
                    </td>
                    <td width="25%" class="tr1" align="center">时间
                    </td>
                    <td width="20%" class="tr1" align="center">删除
                    </td>
                </tr>
                <asp:Repeater ID="repAnnex" runat="server" OnItemCommand="repAnnex_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("APID")%>
                            </td>
                            <td>
                                <%#  Eval("APName")%>
                            </td>
                            <td>
                                <%# Common.ParseUtil.ToDateTime(Eval("ApTime").ToString(),DateTime.Now).ToString("yyyy")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Del" CommandArgument='<%# Eval("APID")%>' 
                                OnClientClick="return confirm('确认删除该条记录？')" Text="删除"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="4" class="tr1" align="center">
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="600" ImagePath="~/images/PagerGif"
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
