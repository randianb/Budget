<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportCkData.aspx.cs" Inherits="WebPage_OptAnaly_ImportCkData" %>

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

        <ext:Panel ID="Panel1" runat="server" Height="80" Title="导入核算数据" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox ID="cmbYear" runat="server" FieldLabel="核算数据" Width="300px" Margin="10">
                    <Items>
                        <ext:ListItem Text="2011" Value="2011" />
                        <ext:ListItem Text="2012" Value="2012" />
                        <ext:ListItem Text="2013" Value="2013" />
                        <ext:ListItem Text="2014" Value="2014" />
                    </Items>
                    <SelectedItems>
                        <ext:ListItem Value="2014"></ext:ListItem>
                    </SelectedItems>
                </ext:ComboBox>
                <ext:Button ID="btnImport" runat="server" Text="导入" Icon="ArrowRefresh" Margin="10" OnDirectClick="btnImport_DirectClick">
                </ext:Button>
            </Items>
        </ext:Panel>

    </form>
</body>
</html>
