<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BraFundJournal.aspx.cs" Inherits="WebPage_BraFundInquiry_BraFundJournal" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        var interval;
        $(function () {

            flagred();
        });

        function flagred() {
            interval = setInterval(changeStyle, "1000");
        }
        function changeStyle() {
            if ($("#gridview-1012 table tr").length > 0) {

                $("#gridview-1012 table tr").each(function () {
                    var tdModel = $(this).find("td:first div");
                    if (tdModel.text() == "合计") {
                        $(this).find("td:eq(0) div").attr("style", "font-weight:bold;text-align:center;");

                        $(this).find("td").each(function (index) {
                            if (index == 1 || index == 4 || index == 6 || index == 7) {
                                //var valTmp = $(this).find("div:").text();
                                //alert(valTmp);
                                $(this).find("div").html("");
                            }
                            if (index == 5) {
                                var valTmp = $("#HidValue2").val();
                                $(this).find("div").html(valTmp).css("style", "font-weight:bold;text-align:left;");
                            }
                        });
                    }
                });
                clearTimeout(interval);
            }
        }

        var selectdept = function (q, w, e) {
            var textstr = w.data.text;
            App.direct.selectdep(textstr);
        };


        var nodeLoad = function (store, operation, options) {
            var node = operation.node;

            App.direct.NodeLoad(node.getId(), {
                success: function (result) {
                    node.set('loading', false);
                    node.set('loaded', true);
                    var data = Ext.decode(result);
                    node.appendChild(data, undefined, true);
                    node.expand();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('错误', '请重新打开页面');
                }
            });

            return false;
        };

        var click = function () {
            var storeCount = Ext.getCmp('GridPanel1').getStore().getCount();
            var store = Ext.getCmp('GridPanel1').getStore();
            var records = store.getRange(0, storeCount);
            var ids = "";
            //ChangePro  ChangeBefore ChangeAfter 
            for (var i = 0; i < records.length; i++) {
                var record = records[i];
                //if (record.data.ChangeAfter != "") {
                ids += record.data.FAUDID + "*" + record.data.BXRQ + "*" + record.data.ZY + "*" + record.data.JE + "*" + record.data.FJZS + "*" + record.data.BZ + "#";
                //} 
            }

            App.direct.clicksave(ids);
        }

        var selectclick = function (q, w, e) {
            var textstr = w.data.FAUDID;
            App.direct.selectclick(textstr);
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:Hidden ID="HidText" runat="server" />
        <ext:Hidden ID="Hididstr" runat="server" />
        <ext:Hidden ID="HidValue1" runat="server" />
        <ext:Hidden ID="HidValue2" runat="server" />
        <ext:Hidden ID="HidValue3" runat="server" />
        <ext:Hidden ID="HidValue4" runat="server" />
        <ext:Hidden ID="HidValue5" runat="server" Text="1000000" />
        <ext:Hidden ID="HidValue6" runat="server" />
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" Style="">
            <Items>
                <ext:Hidden ID="hidquerystr" runat="server" />


                <ext:Hidden ID="Hiddentext" runat="server" />
                <ext:Hidden ID="Hiddenid" runat="server" />
                <ext:Panel ID="Panel1" runat="server" Layout="BorderLayout">
                    <Items>
                        <ext:Panel ID="Panel4" runat="server" Title="" Icon="Application" Width="240" MinWidth="240" Region="West" AutoScroll="true" Layout="FitLayout">
                            <Items>
                                <ext:TreePanel
                                    ID="STMem" Title="部门列表"
                                    runat="server" Height="800"
                                    SingleExpand="false"
                                    UseArrows="true"
                                    RootVisible="false"
                                    ColumnWidth="0.2" AutoScroll="true">
                                    <Root>
                                    </Root>
                                    <Listeners>
                                        <BeforeLoad Fn="nodeLoad" />
                                        <ItemClick Fn="selectdept"></ItemClick>
                                    </Listeners>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Panel3" runat="server" Width="1220" MinWidth="700" Border="false" Region="Center" Layout="FitLayout">
                            <Items>
                                <ext:GridPanel ID="GridPanel1" runat="server" Title="科、所经费日记帐" Layout="FitLayout" ColumnLines="true" AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="Store1" runat="server" PageSize="25" OnReadData="Store1_ReadData">
                                            <Model>
                                                <ext:Model ID="Model1" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="FAUDID" />
                                                        <ext:ModelField Name="index" />
                                                        <ext:ModelField Name="BXRQ" Type="Date" />
                                                        <ext:ModelField Name="BM" />
                                                        <ext:ModelField Name="ZFLX" />
                                                        <ext:ModelField Name="ZY" />
                                                        <ext:ModelField Name="JE" Type="Float" />
                                                        <ext:ModelField Name="FJZS" />
                                                        <ext:ModelField Name="BZ" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:Column ID="Column1"
                                                runat="server"
                                                Text="序号"
                                                Width="100" Align="Center"
                                                DataIndex="index" Flex="1" />
                                            <ext:ComponentColumn ID="Column2"
                                                runat="server"
                                                Text="报销日期" Align="Center"
                                                DataIndex="BXRQ"
                                                Flex="1" Editor="true">
                                                <Component>
                                                    <ext:DateField runat="server" ID="DateField1" Format="yyyy-MM-dd" d />
                                                </Component>
                                            </ext:ComponentColumn>
                                            <ext:Column ID="Column3"
                                                runat="server"
                                                Text="部门" Align="Center"
                                                DataIndex="BM"
                                                Flex="1" />
                                            <ext:Column ID="Column4"
                                                runat="server"
                                                Text="支付类型" Align="Center"
                                                DataIndex="ZFLX"
                                                Flex="1" />
                                            <ext:ComponentColumn ID="Column5"
                                                runat="server"
                                                Text="摘要" Align="Center"
                                                DataIndex="ZY"
                                                Flex="1" Editor="true">
                                                <Component>
                                                    <ext:TextField runat="server" ID="TextField1" />
                                                </Component>
                                            </ext:ComponentColumn>
                                            <ext:ComponentColumn ID="Column6"
                                                runat="server"
                                                Text="金额" Align="Center"
                                                DataIndex="JE"
                                                Flex="1" Editor="true">
                                                <Component>
                                                    <ext:TextField runat="server" ID="TextField2" />
                                                </Component>
                                            </ext:ComponentColumn>
                                            <ext:ComponentColumn ID="Column7"
                                                runat="server"
                                                Text="附件张数" Align="Center"
                                                DataIndex="FJZS"
                                                Flex="1" Editor="true">
                                                <Component>
                                                    <ext:TextField runat="server" ID="TextField3" />
                                                </Component>
                                            </ext:ComponentColumn>
                                            <ext:ComponentColumn ID="Column8"
                                                runat="server"
                                                Text="备注" Align="Center"
                                                DataIndex="BZ"
                                                Flex="1" Editor="true">
                                                <Component>
                                                    <ext:TextField runat="server" ID="TextField4" />
                                                </Component>
                                            </ext:ComponentColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <Listeners>
                                        <ItemClick Fn="selectclick"></ItemClick>
                                    </Listeners>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar7" runat="server">
                                            <Items>
                                                <ext:Label ID="Label87" runat="server" Text="每页显示条数:" />
                                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                <ext:ComboBox ID="ComboBox20" runat="server" Width="60">
                                                    <Items>
                                                        <ext:ListItem Text="10" />
                                                        <ext:ListItem Text="20" />
                                                        <ext:ListItem Text="25" />
                                                        <ext:ListItem Text="30" />
                                                        <ext:ListItem Text="50" />
                                                        <ext:ListItem Text="100" />
                                                        <ext:ListItem Text="200" />
                                                        <ext:ListItem Text="300" />
                                                        <ext:ListItem Text="500" />
                                                        <ext:ListItem Text="1000" />
                                                    </Items>
                                                    <SelectedItems>
                                                        <ext:ListItem Value="25" />
                                                    </SelectedItems>
                                                    <Listeners>
                                                        <Select Handler="#{GridPanel1}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel1}.store.reload();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar2" runat="server" Height="25">
                                            <Items>
                                                <ext:RadioGroup ID="CheckboxGroup1" runat="server" ColumnsWidths="60,60" OnDirectChange="CheckboxGroup1_DirectChange">
                                                    <Items>
                                                        <ext:Radio ID="rdCash" runat="server" BoxLabel="现金" />
                                                        <ext:Radio ID="rdNoCash" runat="server" BoxLabel="非现金" />
                                                    </Items>
                                                </ext:RadioGroup>
                                                <ext:Button ID="btnAdd" runat="server" Text="增加" Icon="BookAdd" OnDirectClick="btnAdd_DirectClick" />
                                                <ext:Button ID="BookSave" Icon="DatabaseSave" runat="server" Text="保存">
                                                    <Listeners>
                                                        <Click Fn="click" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="Button2" runat="server" Text="插入" Icon="PageBreakInsert" OnDirectClick="Button2_DirectClick" />
                                                <ext:Button ID="btnDel" runat="server" Text="删除" Icon="Delete" OnDirectClick="btnDel_DirectClick">
                                                </ext:Button>
                                                <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Zoom" OnDirectClick="btnSearch_DirectClick" />
                                                <%--<ext:Button ID="btnExcel" runat="server" Text="导出" Icon="PageExcel"  OnDirectClick="btnExcel_DirectClick"/>--%>
                                                <ext:Container ID="Container1" runat="server">
                                                    <Content>
                                                        <ext:Label ID="Label1" runat="server" Icon="PageExcel" MarginSpec="0 0 0 0" PaddingSpec="0 0 0 0" />
                                                        <asp:Button ID="btnExcel" runat="server" MarginSpec="0 0 0 0" CssClass="aa" PaddingSpec="0 0 0 0" Text="导出" BorderStyle="None" BackColor="Transparent" OnClick="btnExcel_Click" />
                                                    </Content>
                                                </ext:Container>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>

        <ext:Window ID="WinSearch" runat="server"
            Title="查询"
            Width="600"
            Height="350"
            Icon="UserAdd"
            AnimCollapse="false"
            Resizable="true"
            CloseAction="Hide"
            Hidden="true"
            Layout="AnchorLayout"
            AutoScroll="true">
            <Items>
                <ext:Panel ID="Panel2" runat="server" AutoScroll="true" Title="查询界面">
                    <Items>
                        <ext:Toolbar ID="Toolbar30" runat="server" Layout="AnchorLayout" BodyStyle="width:100%;height:95%">
                            <Items>
                                <ext:Container ID="Container31" runat="server" Layout="ColumnLayout" BodyStyle="width:100%">
                                    <Items>
                                        <ext:Label ID="Label54" runat="server" Text="部门名称： " MarginSpec="25 0 0 24"></ext:Label>
                                        <ext:ComboBox ID="ComboBox1" runat="server" MarginSpec="20 0 0 10" Width="160">
                                        </ext:ComboBox>
                                        <ext:Label ID="Label11" runat="server" Text="报销日期： " MarginSpec="25 0 0 60"></ext:Label>
                                        <ext:DateField ID="DateField2" runat="server" MarginSpec="20 0 0 10" Width="160"></ext:DateField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container48" runat="server" Layout="ColumnLayout" BodyStyle="width:100%">
                                    <Items>
                                        <ext:Label ID="Label57" runat="server" Text="金额： " MarginSpec="25 0 0 48"></ext:Label>
                                        <ext:TextField ID="TextField131" runat="server" MarginSpec="20 0 0 10" Width="160"></ext:TextField>
                                        <ext:Label ID="Label82" runat="server" Text="至： " MarginSpec="25 0 0 96"></ext:Label>
                                        <ext:TextField ID="TextField148" runat="server" MarginSpec="20 0 0 10" Width="160"></ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container58" runat="server" Layout="ColumnLayout" BodyStyle="width:100%">
                                    <Items>
                                        <ext:Label ID="Label71" runat="server" Text="开始日期： " MarginSpec="25 0 0 24"></ext:Label>
                                        <ext:DateField ID="DateField15" runat="server" MarginSpec="20 0 0 10" Width="160"></ext:DateField>
                                        <ext:Label ID="Label72" runat="server" Text="结束日期： " MarginSpec="25 0 0 60"></ext:Label>
                                        <ext:DateField ID="DateField16" runat="server" MarginSpec="20 0 0 10" Width="160"></ext:DateField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container52" runat="server" Layout="ColumnLayout" BodyStyle="width:100%">
                                    <Items>
                                        <ext:Label ID="Label60" runat="server" Text="支付类型： " MarginSpec="25 0 80 24"></ext:Label>
                                        <ext:ComboBox ID="TextField134" runat="server" MarginSpec="20 0 75 10" Width="160">
                                            <Items>
                                                <ext:ListItem Text="现金" Value="0" />
                                                <ext:ListItem Text="非现金" Value="1" />
                                            </Items>
                                        </ext:ComboBox>
                                        <ext:Label ID="Label59" runat="server" Text="摘要： " MarginSpec="25 0 80 84"></ext:Label>
                                        <ext:TextField ID="TextField5" runat="server" MarginSpec="20 0 75 10" Width="160">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Toolbar>
                        <ext:Toolbar ID="Toolbar31" runat="server" Layout="ColumnLayout" BodyStyle="width:100%;height:5%">
                            <Items>
                                <ext:Toolbar ID="Toolbar32" runat="server" ColumnWidth="0.7" Border="false"></ext:Toolbar>
                                <ext:Toolbar ID="Toolbar33" runat="server" ColumnWidth="0.3" Border="false">
                                    <Items>
                                        <ext:Container ID="Container67" runat="server" Width="40">
                                            <Items>
                                                <ext:Button ID="Button1" runat="server" Text="查询" OnDirectClick="Button1_DirectClick"></ext:Button>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container68" runat="server" Width="40">
                                            <Items>
                                                <ext:Button ID="btnCancel" runat="server" Text="取消" OnDirectClick="btnCancel_DirectClick"></ext:Button>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container69" runat="server" Width="80">
                                            <Items>
                                                <ext:Button ID="btnEmpty" runat="server" Text="清空查询条件" OnDirectClick="btnEmpty_DirectClick"></ext:Button>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Toolbar>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
