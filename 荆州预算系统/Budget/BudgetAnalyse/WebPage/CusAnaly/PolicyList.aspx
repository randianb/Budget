<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyList.aspx.cs" Inherits="WebPage_CusAnaly_PolicyList" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>政策列表</title>
    <script type="text/javascript">
        var selectionChanged = function (selModel, selected) {

            if (selected.length > 0) {
                alert(selected[0].data);
                var st = selected[0].data.PContent;
                window.showModalDialog("PolicyContent.aspx?rt=" + st, window, "dialogWidth=600px;dialogHeight=500px;status=false;");
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:GridPanel ID="GridPanel1" runat="server" Title="Title" Header="false" HideHeaders="true" Border="false">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Model>
                        <ext:Model ID="Model1" runat="server" IDProperty="name">
                            <Fields>
                                <ext:ModelField Name="Key" Type="string" />
                                <ext:ModelField Name="Val" Type="string" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel Header="false">
                <Columns>
                    <ext:Column ID="Column1"
                        runat="server"
                        Sortable="false"
                        fixed="true"
                        Resizable="false"
                        Hideable="false"
                        MenuDisabled="false"
                        header=""
                        Flex="10"
                        DataIndex="Key" />
                </Columns>
                <Columns>
                    <ext:Column ID="Column2"
                        runat="server"
                        fixed="true"
                        Resizable="false"
                        Hideable="false"
                        MenuDisabled="false"
                        Sortable="false"
                        Flex="20"
                        Visible="false"
                        DataIndex="Val" />
                </Columns>
            </ColumnModel>
            <Listeners>
                <SelectionChange Fn="selectionChanged" />
                <%--<ItemClick Handler="returned"></ItemClick>--%>
            </Listeners>
        </ext:GridPanel>
    </form>
</body>
</html>

