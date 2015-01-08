<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnlh" runat="server" Text="零户" OnClick="btnlh_Click" />
        <asp:Button ID="btnqj" runat="server" Text="区级" OnClick="btnqj_Click" />
        <asp:Button ID="Button1" runat="server" Text="零户上级数据" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="区级上级数据" OnClick="Button2_Click"/>
        <asp:Label  ID="lblResutle" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
