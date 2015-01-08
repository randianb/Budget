<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Icon.aspx.cs" Inherits="test" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
    <div>
        <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
