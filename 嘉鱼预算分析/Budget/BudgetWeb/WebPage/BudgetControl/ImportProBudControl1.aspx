<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportProBudControl1.aspx.cs" Inherits="WebPage_BudgetControl_ImportProBudControl1" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title></title>
    <script>

        var edit = function (editor, e) {
            /*
                "e" is an edit event with the following properties:

                    grid - The grid
                    record - The record that was edited
                    field - The field name that was edited
                    value - The value being set
                    originalValue - The original value for the field, before the edit.
                    row - The grid table row
                    column - The grid Column defining the column that was edited.
                    rowIdx - The row index that was edited
                    colIdx - The column index that was edited
            */

            // Call DirectMethod
            if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                CompanyX.Edit(e.record.data.PSID, e.record.data.PSName, e.originalValue, e.value, e.record.data);
            }
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" Layout="AnchorLayout">
            <Items>
                 <ext:GridPanel
                     ColumnLines="true"
            ID="GridPanel2"
            runat="server"
            Title="填入财政下放数据"
            Icon="ApplicationViewColumns"
            Layout="ColumnLayout"
            AutoScroll="true"
            AutoHeight="false"
            BodyStyle="width:100%"
            AutoWidth="true"
            Border="false"
            Collapsible="true">

            <Store>
                <ext:Store ID="Store2" runat="server">
                    <Model>
                        <ext:Model ID="Model2" runat="server" Name="aaaa">
                            <Fields>
                                <ext:ModelField Name="PSID" Type="int" />
                                <ext:ModelField Name="PSName" Type="String" />
                                <ext:ModelField Name="PDBaseData" Type="float" />
                                <ext:ModelField Name="rs1" Type="String" />
                                <ext:ModelField Name="rs2" Type="String" />
                                <ext:ModelField Name="rjs1" Type="String" />
                                <ext:ModelField Name="rjs2" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>

            <ColumnModel ID="ColumnModel2" runat="server">
                <Columns>
                    <ext:Column ID="Column5" runat="server" Align="Center" Text="费用名称" Flex="1" DataIndex="PSName" />
                    <ext:Column ID="Column6" runat="server" Align="Center" Text="类型" Flex="1" DataIndex="PSName" />
                    <ext:Column ID="Column7" runat="server" Align="Center" Text="省下发金额" Flex="1" DataIndex="PSName" />
                    
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel ID="CellSelectionModel2" runat="server">
                    <SelectedCell ColIndex="4"></SelectedCell>
                </ext:CellSelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:CellEditing ID="CellEditing2" runat="server">
                    <Listeners>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>

        </ext:GridPanel>
            </Items>
        </ext:Viewport>
       

        
    </form>
</body>
</html>
