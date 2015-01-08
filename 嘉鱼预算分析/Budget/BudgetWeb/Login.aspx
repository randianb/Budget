<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="skins/main.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <script type="text/javascript">
        window.onload = function () {
            
                document.getElementsByName('uname').item(0).focus();
            }
    </script>


<%--    <script type="text/javascript">

        function onclick1() {
            alert("Click button");
        }
</script>--%>

    <div id="bg2">
        <div style="height: 215px"></div>
        <div id="logobox3">
            <h2>辅助预算管理系统</h2>
            <div class="lform">
                <form action="" method="post" runat="server">
                    <p>
                        <label runat="server">用户名：<asp:TextBox ID="txtUer" runat="server"></asp:TextBox></label></p>
                    <p>
                        <label runat="server">密　码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></label></p>

                    <p class="subox">
                        <asp:ImageButton ID="ibtnLogin" ImageUrl="~/skins/sb1.jpg"  style="vertical-align: bottom" runat="server" OnClick="ibtnLogin_Click" />
                        <asp:ImageButton ID="ibtnCancel" ImageUrl="~/skins/sb2.jpg"  style="vertical-align: bottom" runat="server" OnClick="ibtnCancel_Click" />


<%--                        <a href="#" style="margin-left: 10px">
                            <img src="skins/sb2.jpg" alt="" /></a>--%>
                    </p>
                </form>
            </div>
        </div>
    </div>

    <div style="height: 22px;"></div>
    <p class="copyright" style="text-align: center; color: #FFF">Copyright@ 2013-2014  武汉铭天信息科技</p>

</body>
</html>
