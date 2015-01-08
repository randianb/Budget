<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Icon.aspx.cs" Inherits="test" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/javascript">
            var selectionChanged = function () {
                alert('aaa');
                window.showModalDialog("http://www.baidu.com", window, "dialogWidth=600px;dialogHeight=500px;status=false;");

            };
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Button ID="Button1" runat="server" Text="Submit">
            <Listeners>
                <Click Fn="selectionChanged"></Click>
            </Listeners>
        </ext:Button>
    </form>
</body>
</html>
