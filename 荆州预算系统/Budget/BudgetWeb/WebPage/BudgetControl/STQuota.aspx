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
            var expD = /^[\d-]+$/;
            var sss = e.value.toString();
            if (!expD.test(sss)) {
                alert("数据格式应该为（数字）、（数字-数字）"); 
            } else {
                if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                    CompanyX.Edit(e.record.data.QtID, e.record.data.PayPrjName, e.originalValue, e.value, e.record.data);
                }
            } 
           
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport runat="server" ID="vwpLayout" Layout="FitLayout" AutoScroll="true">
            <Items>
                <ext:GridPanel ColumnLines="true"
                    ID="GridPanel1"
                    runat="server"
                    Title="定额设置"
                    Icon="ApplicationViewColumns"   
                    Border="false"> 
                    <Store>
                        <ext:Store ID="PayStore" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" Name="aaaa">
                                    <Fields>
                                        <ext:ModelField Name="QtID" Type="int" />
                                        <ext:ModelField Name="PayPrjName" Type="String" />
                                        <ext:ModelField Name="Money" Type="String" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="40">
                            <Items>
                                <ext:Label ID="Label3" runat="server" MarginSpec="5 5 0 5" Text="部门名称：" ColumnWidth="0.1" ></ext:Label>
                                        <ext:ComboBox  ID="cmbdept" runat="server" DisplayField="DepName"> 
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="请选择月份：" ColumnWidth="0.1"></ext:Label> 
                                <ext:ComboBox ID="cmbmon" Editable="false" runat="server"  ValueField="month" DisplayField="month">
                                    <Store>
                                        <ext:Store runat="server" ID="cmbmonstore">
                                            <Model>
                                                <ext:Model ID="Model2" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="month"></ext:ModelField>
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <SelectedItems>
                                        <ext:ListItem Index="0"> 
                                        </ext:ListItem> 
                                    </SelectedItems>  
                                </ext:ComboBox> 
                                <ext:Button runat="server" ID="btnSure" Text="确定" OnDirectClick="btnSure_OnDirectClick" />
                            </Items>

                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" Align="Center" Text="经济科目" Flex="1" DataIndex="PayPrjName" /> 
                            <ext:Column ID="Column4" runat="server" Text="定额(万元)"  Flex="1" Align="Center" Width="150" DataIndex="Money">
                                <Editor>
                                    <ext:TextField ID="Money" runat="server" />
                                </Editor>
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
