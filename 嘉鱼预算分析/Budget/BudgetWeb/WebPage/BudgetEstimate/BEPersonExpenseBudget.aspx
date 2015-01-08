<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BEPersonExpenseBudget.aspx.cs" Inherits="WebPage_BudgetEstimate_BEPersonExpenseBudget" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                 <ext:Hidden runat="server" ID="hidbn"></ext:Hidden>
                <ext:GridPanel  ColumnLines="true"
                    ID="GridPanel1"
                    runat="server"
                    Title="人员经费预算表"
                    Icon="ApplicationViewColumns"
                    Layout="Column"
                    AutoScroll="true"
                    AutoHeight="false"
                    BodyStyle="width:100%"
                    AutoWidth="true"
                    Border="false">

                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" Name="aaaa">
                                    <Fields>
                                        <ext:ModelField Name="PSID" Type="int" />
                                        <ext:ModelField Name="PSName" Type="String" />
                                        <ext:ModelField Name="PDBaseData" Type="float" />
                                        <ext:ModelField Name="PDBaseLYData" Type="float" />
                                        <ext:ModelField Name="rsold" Type="String" />
                                        <ext:ModelField Name="rsnew" Type="String" />
                                        <ext:ModelField Name="rjsold" Type="String" />
                                        <ext:ModelField Name="rjsnew" Type="String" />
                                        <ext:ModelField Name="StandardQuota" Type="String" />
                                        <ext:ModelField Name="StandardQuotacount" Type="String" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>

                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" Align="Center" Text="人员经费预算（基本）" Flex="1" DataIndex="PSName" />
                            <ext:Column ID="Column2" runat="server" Align="Center" Text="本年度" Flex="1">
                                <Columns>
                                    <ext:SummaryColumn ID="SummaryColumn7" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDBaseLYData">
                                        <Editor>
                                            <ext:NumberField ID="NumberField2" runat="server" Flex="0" />
                                        </Editor>
                                    </ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn1" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsold"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn2" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsold"></ext:SummaryColumn>
                                </Columns>
                            </ext:Column>
                            <ext:Column ID="Column3" runat="server" Align="Center" Text="下年度">
                                <Columns>
                                    <ext:SummaryColumn ID="SummaryColumn3" runat="server" Align="Center" Text="定额标准（元）" Flex="0" DataIndex="StandardQuota"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn6" runat="server" Align="Center" Text="定额数（元）" Flex="0" DataIndex="StandardQuotacount"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="Column4" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDBaseData">
                                        <Editor>
                                            <ext:NumberField ID="NumberField1" runat="server" />
                                        </Editor>
                                    </ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="人数" Width="100" DataIndex="rsnew"></ext:SummaryColumn>
                                    <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="人均数（万元）" Width="100" DataIndex="rjsnew"></ext:SummaryColumn>
                                </Columns>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                            <SelectedCell ColIndex="4"></SelectedCell>
                        </ext:CellSelectionModel>
                    </SelectionModel>
                    <Plugins>
                        <ext:CellEditing ID="CellEditing1" runat="server">
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
