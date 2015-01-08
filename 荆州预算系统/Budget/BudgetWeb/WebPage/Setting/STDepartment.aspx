<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STDepartment.aspx.cs" Inherits="WebPage_Setting_STDepartment" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">


        var gridCommand = function (sender, command, record) {
            if (command == "Modify") {
                App.direct.ModifyDepartment(record.data.DepID);
            }
            if (command == "Delete") {
                Ext.Msg.confirm("提示", "确定删除？", function (btn) {
                    if (btn == "yes") {
                        App.direct.DelDepartment(record.data.DepID);
                    }
                })

            }
        }

    </script>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport runat="server" ID="vwpLayout" Layout="fit">
            <Items>
              <ext:GridPanel ColumnLines="true" ID="GridPanel1"
                    runat="server" >
                
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="DepID" />
                                        <ext:ModelField Name="DepNum" />
                                        <ext:ModelField Name="DepName" />
                                        <ext:ModelField Name="DepRem" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1"
                                runat="server"
                                Text="编号"
                                Width="100" Align="Center"
                                DataIndex="DepNum" />
                            <ext:Column ID="Column2"
                                runat="server"
                                Text="部门名称"
                                DataIndex="DepName"
                                Flex="1" />
                            <ext:Column ID="Column3"
                                runat="server"
                                Text="部门备注"
                                DataIndex="DepRem"
                                Flex="1" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Header="用户操作" Width="200">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Modify" Text="修改" />
                                    <ext:GridCommand Icon="Decline" CommandName="Delete" Text="删除" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>

                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd"
                                    Icon="ApplicationAdd"
                                    runat="server" Text="增加" OnDirectClick="btnAdd_DirectClick" />
                            </Items>
                        </ext:Toolbar>

                    </TopBar>
                </ext:GridPanel>
                
            </Items>
        </ext:Viewport>


        <ext:Window ID="Winadd" runat="server"
            Title="添加部门"
            Width="400"
            Height="130"
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
                        <ext:TextField ID="AdName" runat="server" Name="AdName" FieldLabel="部门名称" AllowBlank="false" LabelWidth="80" Width="300" MarginSpec="10 0 0 30">
                        </ext:TextField>
                        <ext:TextField ID="AdDes" runat="server" Name="AdDes" FieldLabel="部门备注" LabelWidth="80" AllowBlank="true" Width="300" MarginSpec="10 0 0 30"></ext:TextField>
                    </Items>

                    <DockedItems>
                        <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnWinAdd" MarginSpec="0 0 0 0" runat="server" Text="增加" Icon="Add" OnDirectClick="btnWinAdd_DirectClick">
                                    <Listeners>
                                        <Click Handler="
                            if (!#{AdName}.validate() ) {
                                Ext.Msg.alert('提示','部门是必填项!'); 
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

        <ext:Window ID="WinEdit" runat="server"
            Title="修改部门"
            Width="400"
            Height="130"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            CloseAction="Hide"
            Hidden="true"
            Layout="FitLayout">
            <Items>
                <ext:FormPanel runat="server" ID="reset">
                    <Items>
                        <ext:TextField ID="hiddepid" Hidden="true" runat="server" />
                        <ext:TextField ID="txtEDName" runat="server" Name="EDName" FieldLabel="部门名称" AllowBlank="false" LabelWidth="80" Width="300" MarginSpec="10 0 0 30"></ext:TextField>
                        <ext:TextField ID="txtEDDes" runat="server" Name="EDDes" FieldLabel="部门备注" LabelWidth="80" AllowBlank="true" Width="300" MarginSpec="10 0 0 30"></ext:TextField>
                    </Items>
                    <DockedItems>
                        <ext:Toolbar ID="Toolbar3" runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnMod" MarginSpec="0 0 0 0" runat="server" Text="修改" Icon="ApplicationEdit" OnDirectClick="btnMod_DirectClick"></ext:Button>
                                <ext:Button ID="btnCan" runat="server" Text="取消" Icon="PageCancel" OnDirectClick="btnCan_DirectClick"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:FormPanel>

            </Items>
        </ext:Window>

    </form>
</body>
</html>
