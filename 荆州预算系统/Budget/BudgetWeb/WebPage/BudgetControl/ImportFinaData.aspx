<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportFinaData.aspx.cs" Inherits="WebPage_BudgetEdit_ImportFinaData" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">

        var getcheck = function (a, b, c) {
            var radio1= App.Radio1;
            var check = App.TFMon;
            var check1 = App.CTMon;
            if (radio1.checked) {
                check.show();
                check1.hide();
            } else {
                check.hide();
                check1.show();
            }

        }
        //var gridCommand = function (sender, command, record) {
        //if (command == "Publish") {
        //    Ext.Msg.confirm("提示", "确定发布？", function (btn) {
        //        if (btn == "yes") {
        //            App.direct.PublishPolicy(record.data.PLID);
        //        }
        //    })
        //}
        //if (command == "Modify") {
        //    App.direct.ModifyPolicy(record.data.PLID);
        //}
        //    if (command == "Delete") {
        //        Ext.Msg.confirm("提示", "确定删除？", function (btn) {
        //            if (btn == "yes") {
        //                App.direct.DelFinaData(record.data.ID);
        //            }
        //        })

        //    }
        //}

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:FormPanel ID="frompanel" runat="server">
                    <Items>
                        <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                            <Items>
                                <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                                    <Items>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                        <ext:Label ID="Label1" runat="server" Text="导入财政二下数据："></ext:Label>
                                    </Items>
                                </ext:Toolbar>
                                 <ext:RadioGroup runat="server" Layout="ColumnLayout" PaddingSpec="6 0 0 0"> 
                                        <Listeners><Change  Fn="getcheck"></Change></Listeners>
                                                <Items>
                                                    <ext:Radio ID="Radio1" LabelWidth="60"  runat="server" FieldLabel="输入预算" Checked="true"></ext:Radio>
                                                    <ext:Radio ID="Radio2" LabelWidth="70" runat="server" FieldLabel="表格导入预算" ></ext:Radio>
                                                    </Items>
                                 </ext:RadioGroup> 
                                <ext:Container ID="CTMon" runat="server" PaddingSpec="6 0 0 20" Width="150"  Hidden="True" Height="24">
                                    <Items>
                                        <ext:FileUploadField ID="FUFEXC" runat="server" ButtonText="浏览···">
                                        </ext:FileUploadField>
                                    </Items>
                                </ext:Container>
                                 <ext:TextField runat="server" FieldLabel="预算金额设置" ID="TFMon"  Hidden="True"  Height="24" PaddingSpec="6 0 0 25"  LabelWidth="100" ></ext:TextField>
                                <%-- <ext:TextField ID="TextField5" runat="server" Text="未选择文件" Height="24" PaddingSpec="6 0 0 20">
                                </ext:TextField>--%>
                                <ext:TextField runat="server" FieldLabel="年度" ID="txtYear1" ReadOnly="true" Height="24" PaddingSpec="6 0 0 25" LabelWidth="35" ></ext:TextField>
                                <ext:Container runat="server" PaddingSpec="6 0 0 20" Width="40" Height="24">
                                    <Items>
                                        <ext:Button ID="btnImport" runat="server" Text="确定" OnDirectClick="btnImport_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Container>

                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>
                <ext:FormPanel ID="FormPanel2" runat="server">
                    <Items>
                        <ext:Toolbar ID="Toolbar5" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                            <Items>
                                <ext:Toolbar ID="Toolbar6" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                                    <Items>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                        <ext:Label ID="Label3" runat="server" Text="本年预加经费调整："></ext:Label>
                                    </Items>
                                </ext:Toolbar>
                                <ext:Container ID="Container5" runat="server" PaddingSpec="6 0 0 20" Width="150" Height="24">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtPreMon" FieldLabel="预加" LabelWidth="35" Width="130"  />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container6" runat="server" PaddingSpec="6 0 0 20" Width="150" Height="24">
                                    <Items>
                                        <ext:NumberField runat="server" ID="txtPreYear" FieldLabel="年度" Editable="false" Text="2014" LabelWidth="35" Width="130"    AllowBlank="false"  OnDirectChange="txtPreYear_DirectChange"/>
  
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container7" runat="server" PaddingSpec="6 0 0 20" Width="40" Height="24" >
                                    <Items>
                                        <ext:Button ID="btnPreadd" runat="server" Text="确 定" OnDirectClick="btnPreadd_DirectClick"></ext:Button>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container8" runat="server" PaddingSpec="6 0 0 30" Width="80"  Height="24" >
                                    <Items>
                                        <ext:Label runat="Server" ID="lbPre"   StyleSpec="color:red"></ext:Label>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>
                <ext:FormPanel ID="FormPanel1" runat="server">
                    <Items>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                            <Items>
                                <ext:Toolbar ID="Toolbar4" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                                    <Items>
                                        <ext:ToolbarFill></ext:ToolbarFill>
                                        <ext:Label ID="Label2" runat="server" Text="本年追加经费调整："></ext:Label>
                                    </Items>
                                </ext:Toolbar>
                                <ext:Container ID="Container2" runat="server" PaddingSpec="6 0 0 20" Width="150" Height="24">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtSupp" FieldLabel="追加" LabelWidth="35" Width="130" />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container1" runat="server" PaddingSpec="6 0 0 20" Width="150" Height="24">
                                    <Items>
                                        <ext:NumberField runat="server" ID="txtSuppyear"  Editable="false" Text="2014" FieldLabel="年度" LabelWidth="35" Width="130"    OnDirectChange="txtSuppyear_DirectChange"   AllowBlank="false"/>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container3" runat="server" PaddingSpec="6 0 0 20" Width="40" Height="24">
                                    <Items>
                                        <ext:Button ID="btnadd" runat="server" Text="确 定" OnDirectClick="btnadd_DirectClick"></ext:Button> 
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container9" runat="server" PaddingSpec="6 0 0 30"  Width="80" Height="24">
                                    <Items>
                                        <ext:Label runat="Server" ID="lbsupp"  StyleSpec="color:red"></ext:Label>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:FormPanel>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
