<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BCPro.aspx.cs" Inherits="WebPage_BudgetControl_BCPro" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                CompanyX.Edit(e.record.data.PJID, e.record.data.PJName, e.originalValue, e.value, e.record.data);
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
                    Title="项目设置"
                    Icon="ApplicationViewColumns"   
                    Border="false">  
                    <Store>
                        <ext:Store ID="PayStore" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" Name="aaaa">
                                    <Fields>
                                        <ext:ModelField Name="PJID" Type="int" />
                                        <ext:ModelField Name="PJName" Type="String" /> 
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>

                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                              <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server"></ext:RowNumbererColumn>
                            <ext:Column ID="Column1" runat="server" Align="Center" Text="经济科目" Width="150" DataIndex="PJName" >
                                 <Editor>
                                   <ext:TextField runat="server" ID="tfpjname"></ext:TextField>
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
                   <TopBar><ext:Toolbar ID="Toolbar1" runat="server"><Items><ext:Button runat="server" ID="btnAdd" OnDirectClick="btnAdd_DirectClick" Text="添加"></ext:Button></Items></ext:Toolbar> </TopBar> 
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
          <ext:Window ID="Winadd" runat="server"
            Title="添加项目"
            Width="400"
            Height="100"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="FitLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:FormPanel runat="server" ID="resetform">
                    <Items> 
                        <ext:TextField ID="AdName" runat="server" Name="AdName" FieldLabel="项目名称" AllowBlank="false" LabelWidth="80" Width="300" MarginSpec="10 0 0 30">
                        </ext:TextField> 
                    </Items>

                    <DockedItems>
                        <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnWinAdd" MarginSpec="0 0 0 0" runat="server" Text="增加" Icon="Add" OnDirectClick="btnWinAdd_DirectClick">
                                    <Listeners>
                                        <Click Handler="
                            if (!#{AdName}.validate() ) {
                                Ext.Msg.alert('提示','项目名称是必填项!'); 
                                            return false; 
                            }" />
                                    </Listeners> 
                                </ext:Button>
                                <ext:Button ID="btnWinCancel" runat="server" Text="取消" Icon="ApplicationEdit" OnDirectClick="btnWinCancel_DirectClick"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:FormPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
