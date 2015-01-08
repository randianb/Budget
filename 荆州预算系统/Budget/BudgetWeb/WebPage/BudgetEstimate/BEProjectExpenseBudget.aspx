<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BEProjectExpenseBudget.aspx.cs" Inherits="WebPage_BudgetEstimate_BEProjectExpenseBudget" %>

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
        <ext:Hidden runat="server" ID="hidbn1"></ext:Hidden>
        <ext:Hidden runat="server" ID="hidbn2"></ext:Hidden>
        <ext:Hidden runat="server" ID="hidbn3"></ext:Hidden>
        <ext:Viewport runat="server" Layout="FitLayout" AutoScroll="true">
            <Items>
                <ext:Panel runat="server" AutoScroll="true" Border="false">
                    <Items> 
                        <ext:GridPanel   ColumnLines="true"
                            Border="false"
                            ID="GridPanel2"
                            runat="server"
                            Title="人员经费预算表"
                            Icon="ApplicationViewColumns"
                            AutoScroll="true"
                            AutoHeight="false"
                            AutoWidth="true"
                            Collapsible="true">
                            <Store>
                                <ext:Store ID="Store2" runat="server">
                                    <Model>
                                        <ext:Model ID="Model2" runat="server" Name="aaaa">
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

                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column ID="Column5" runat="server" Align="Center" Text="人员经费预算（基本）" Flex="1" DataIndex="PSName" />
                                    <ext:Column ID="Column6" runat="server" Align="Center" Text="本年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn15" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDBaseLYData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField4" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn3" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsold"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn6" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsold"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column7" runat="server" Align="Center" Text="下年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn18" runat="server" Align="Center" Text="定额标准（元）" Flex="0" DataIndex="StandardQuota"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn19" runat="server" Align="Center" Text="定额数（元）" Flex="0" DataIndex="StandardQuotacount"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn7" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDBaseData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField2" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn8" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsnew"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn9" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsnew"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
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

                        <ext:GridPanel   ColumnLines="true"
                            ID="GridPanel3"
                            runat="server"
                            Title="公用经费预算表"
                            Icon="ApplicationViewColumns"
                            Layout="ColumnLayout"
                            AutoScroll="true"
                            AutoHeight="false"
                            BodyStyle="width:100%"
                            AutoWidth="true"
                            Border="false"
                            Collapsible="true">

                            <Store>
                                <ext:Store ID="Store3" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PSID" Type="int" />
                                                <ext:ModelField Name="PSName" Type="String" />
                                                <ext:ModelField Name="PDProjectData" Type="float" />
                                                <ext:ModelField Name="PDProjectLYData" Type="float" />
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

                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:Column ID="Column8" runat="server" Align="Center" Text="公用经费预算" Flex="1" DataIndex="PSName" />
                                    <ext:Column ID="Column9" runat="server" Align="Center" Text="本年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn16" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDProjectLYData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField5" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn10" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsold"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn11" runat="server" Align="Center" Text="人均数" Flex="0" DataIndex="rjsold"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column10" runat="server" Align="Center" Text="下年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn20" runat="server" Align="Center" Text="定额标准（元）" Flex="0" DataIndex="StandardQuota"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn21" runat="server" Align="Center" Text="定额数（元）" Flex="0" DataIndex="StandardQuotacount"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn12" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDProjectData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField3" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn13" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsnew"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn14" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsnew"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel ID="CellSelectionModel3" runat="server">
                                    <SelectedCell ColIndex="4"></SelectedCell>
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing ID="CellEditing3" runat="server">
                                    <Listeners>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>

                        <ext:GridPanel ColumnLines="true"
                            ID="GridPanel1"
                            runat="server"
                            Title="项目经费预算表"
                            Icon="ApplicationViewColumns"
                            Layout="ColumnLayout"
                            AutoScroll="true"
                            AutoHeight="false"
                            BodyStyle="width:100%"
                            AutoWidth="true"
                            Border="false"
                            Collapsible="true">

                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server" Name="aaaa">
                                            <Fields>
                                                <ext:ModelField Name="PSID" Type="int" />
                                                <ext:ModelField Name="PSName" Type="String" />
                                                <ext:ModelField Name="PDProjectData" Type="float" />
                                                <ext:ModelField Name="PDProjectLYData" Type="float" />
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
                                    <ext:Column ID="Column1" runat="server" Align="Center" Text="项目经费预算" Flex="1" DataIndex="PSName" />
                                    <ext:Column ID="Column2" runat="server" Align="Center" Text="本年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn17" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDProjectLYData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField6" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn1" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsold"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn2" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsold"></ext:SummaryColumn>
                                        </Columns>
                                    </ext:Column>
                                    <ext:Column ID="Column3" runat="server" Align="Center" Text="下年度" Flex="1">
                                        <Columns>
                                            <ext:SummaryColumn ID="SummaryColumn22" runat="server" Align="Center" Text="定额标准（元）" Flex="0" DataIndex="StandardQuota"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn23" runat="server" Align="Center" Text="定额数（元）" Flex="0" DataIndex="StandardQuotacount"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="Column4" runat="server" Text="测算数" Align="Center" Flex="0" DataIndex="PDProjectData">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField1" runat="server" />
                                                </Editor>
                                            </ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn4" runat="server" Align="Center" Text="人数" Flex="0" DataIndex="rsnew"></ext:SummaryColumn>
                                            <ext:SummaryColumn ID="SummaryColumn5" runat="server" Align="Center" Text="人均数（万元）" Flex="0" DataIndex="rjsnew"></ext:SummaryColumn>
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
                </ext:Panel>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
