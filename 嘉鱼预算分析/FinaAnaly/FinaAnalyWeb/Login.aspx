<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="skins/main.css" rel="stylesheet" type="text/css"/>
<title></title>
</head>
<body>
<script type="text/javascript">
    window.onload = function () {
        document.getElementsByName('uname').item(0).focus();
    }
</script>
<div id="bg2">
	<div style="height:245px"></div>
		<div id="logobox2">
			<h2>江 岸 地 税 财 务 分 析 系 统 <span style="font-size:12px"></span></h2>
			<div class="lform" runat="server">
				<form action="" method="post" runat="server">
					<p runat="server"><label>用户名：</label><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></p>
					<p runat="server"><label>密　码：</label><asp:TextBox ID="txtPow" runat="server" TextMode="Password"></asp:TextBox></p>
					
					<p class="subox">
                        <asp:Button id="btnRequest" runat="server" Text="确认登录" OnClick="txtRequest_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button id="btnCancel" runat="server" Text="清空重填"  OnClick="btnCancel_Click"/>
					</p>
				</form>
			</div>
		</div>
</div>

<div style="height:120px;"></div>
<p class="copyright" style="text-align:center;color:#4B7597">Copyright@   武汉铭天信息科技有限责任公司  版权所有</p>

</body>
</html>
