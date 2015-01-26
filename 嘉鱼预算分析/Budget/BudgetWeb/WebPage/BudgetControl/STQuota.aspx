<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STQuota.aspx.cs" Inherits="WebPage_Setting_STQuota" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>  
    <script src="../../js/jquery-1.7.2.min.js"></script>
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
                if (e.record.data.BaseMon == e.value) { CompanyX.Edit(e.record.data.QtID, e.record.data.PayPrjName, e.originalValue, e.value, "基本"); }
                else { CompanyX.Edit(e.record.data.QtID, e.record.data.PayPrjName, e.originalValue, e.value, "项目"); }
            }
        };
        function remarkred() { 
            if ($("#gridview-1011 table tr").length > 0) { 
                $("#gridview-1011 table tr").each(function () { 
                    if ($(this).find("td:first div").text() == "工资福利支出" || $(this).find("td:first div").text() == "商品和服务支出" || $(this).find("td:first div").text() == "其他资本性支出" || $(this).find("td:first div").text() == "对个人和家庭补助支出") {
               
                        $(this).attr("style", "color: red;font-weight:bold");
                    }
                });
                return;
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" id="Hid1000_base"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1015_base"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1051_base"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1065_base"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1051_pro"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1015_pro"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1065_pro"></ext:Hidden>
        <ext:Hidden runat="server" id="Hid1000_pro"></ext:Hidden>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="FitLayout" AutoScroll="true">
            <Items> 
                <ext:GridPanel ColumnLines="true"
                    ID="GridPanel1"
                    runat="server"
                    Title="定额设置"
                    Icon="ApplicationViewColumns"   
                    Border="false"> 
                    <Tools>  <ext:Tool Type="Refresh"  ><Listeners><Click Handler="App.direct.refresh()"></Click></Listeners></ext:Tool></Tools>
                    <Store>
                        <ext:Store ID="PayStore" runat="server"> 
                            <Model> 
                                <ext:Model ID="Model1" runat="server" Name="aaaa" > 
                                    <Fields> 
                                         <ext:ModelField Name="PIID" Type="int" />
                                        <ext:ModelField Name="QtID" Type="int" />
                                        <ext:ModelField Name="PayPrjName" Type="String" />
                                        <ext:ModelField Name="BaseMon" Type="float" />
                                         <ext:ModelField Name="ProMon" Type="float" />
                                    </Fields>
                                </ext:Model>
                            </Model>  
                             <%-- <Sorters>
                        <ext:DataSorter Property="PIID" Direction="ASC" />
                    </Sorters>--%>
                        </ext:Store> 
                    </Store>
                    <Listeners><AfterRender Delay="2000" Handler="remarkred();"></AfterRender></Listeners>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns> 
                            <ext:Column ID="Column1" runat="server" Align="Center" Text="经济科目" Flex="1" DataIndex="PayPrjName" />

                            <ext:SummaryColumn ID="Column4" runat="server" Text="基本(万元)"  Flex="1" Align="Center" Width="150" DataIndex="BaseMon">
                                <Editor>
                                    <ext:NumberField ID="NFBaseMon" runat="server" />
                                </Editor>
                            </ext:SummaryColumn>
                             <ext:SummaryColumn ID="SummaryColumn1" runat="server" Text="项目(万元)"  Flex="1" Align="Center" Width="150" DataIndex="ProMon">
                                <Editor>
                                    <ext:NumberField ID="NFProMon" runat="server" />
                                </Editor>
                            </ext:SummaryColumn>
                             <ext:SummaryColumn ID="SummaryColumn2" runat="server" Text="合计(万元)"  Flex="1" Align="Center" Width="150" >
                                <Renderer Handler="return (record.data.BaseMon + record.data.ProMon);" />
                        <SummaryRenderer FormatHandler ="true" />
                            </ext:SummaryColumn>
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
