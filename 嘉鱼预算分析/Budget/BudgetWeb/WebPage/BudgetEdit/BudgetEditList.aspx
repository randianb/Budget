<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetEditList.aspx.cs" Inherits="WebPage_BudgetEdit_BudgetEditList" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        var gridCommand = function (sender, command, record) {
            switch (command) {
                case "ReimAppendix":
                    App.direct.ReimAppendix_Handler(record.data.BudID);
                    break;
                case "FixAssetPurchase":
                    App.direct.FixAssetPurchase_Handler(record.data.BudID);
                    break;
                case "SubMit":
                    App.direct.SubMit_Handler(record.data.BudID);
                    break;
                case "Modify":
                    App.direct.Modify_Handler(record.data.BudID);
                    break;
                case "Delete":
                    App.direct.Delete_Handler(record.data.BudID);
                    break;
                case "Subfield":
                    App.direct.Subfield_Handler(record.data.BudID);
                    break;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:Panel
                    ID="GridPanel2"
                    runat="server"
                    Title="预算编辑"
                    Border="false">
                </ext:Panel>
                <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>

                        <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false" Width="300" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Label ID="Label1" runat="server" Text="部门名称："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:ComboBox ID="cbDepment"
                            runat="server"
                            DisplayField="depname"
                            ValueField="depid"
                            Style="margin-top: 8px"
                            Width="160"
                            LabelWidth="50"
                            Editable="false"
                            QueryMode="Local"
                            ForceSelection="true"
                            TriggerAction="All"
                            EmptyText="Loading..."
                            ValueNotFoundText="Loading...">
                            <Store>
                                <ext:Store
                                    runat="server"
                                    ID="DepStore">
                                    <Model>
                                        <ext:Model ID="Model2" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="depid" Type="String" />
                                                <ext:ModelField Name="depname" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <SelectedItems>
                                <ext:ListItem Index="0"></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                        <ext:Container ID="Container3" runat="server" PaddingSpec="6 0 0 20">
                            <Items>
                                <ext:Button ID="btnInquiry" runat="server" Text="查 询" Height="24" Width="40" OnDirectClick="btnInquiry_DirectClick">
                                </ext:Button>
                                <ext:Label ID="lbDes" runat="server" Style="color: red"></ext:Label>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Toolbar>

                <ext:GridPanel ID="gridpanel1" ColumnLines="true" runat="server" AutoHeight="false" Layout="FitLayout" AutoScroll="true"
                    Title="数据查询结果及操作">
                    <Store>
                        <ext:Store ID="stBudget" runat="server" PageSize="12">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="BICode" Type="string" />
                                        <ext:ModelField Name="BIProName" Type="string" />
                                        <ext:ModelField Name="BIProType" Type="string" />
                                        <ext:ModelField Name="BIFunSub" Type="string" />
                                        <ext:ModelField Name="BIMon" Type="string" />
                                        <ext:ModelField Name="BIYear" Type="string" />
                                        <ext:ModelField Name="BudSta" Type="string" />
                                        <ext:ModelField Name="BudID" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column Sortable="true" ID="Column1" runat="server" Text="项目编号" Flex="1" DataIndex="BICode" />
                            <ext:Column Sortable="true" ID="Column2" runat="server" Text="项目名称" Flex="1" DataIndex="BIProName" />
                            <ext:Column Sortable="true" ID="Column3" runat="server" Text="项目类型" Flex="1" DataIndex="BIProType" />
                            <ext:Column Sortable="true" ID="Column5" runat="server" Text="功能科目" Flex="1" DataIndex="BIFunSub" />
                            <ext:Column Sortable="true" ID="Column6" runat="server" Text="金额" Flex="1" DataIndex="BIMon" />
                            <ext:Column Sortable="true" ID="Column7" runat="server" Text="年度" Flex="1" DataIndex="BIYear" />
                            <ext:Column Sortable="true" ID="Column8" runat="server" Text="项目状态" Flex="1" DataIndex="BudSta" />
                            <ext:CommandColumn ID="CommandColumn3" runat="server" Header="附件" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="ReimAppendix" Text="附件" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn4" runat="server" Header="固定资产采购" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="FixAssetPurchase" Text="固定资产采购" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn5" runat="server" Header="提交" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="SubMit" Text="提交" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Header="修改" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Modify" Text="修改" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn2" runat="server" Header="删除" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="Decline" CommandName="Delete" Text="删除" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <DockedItems>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true" Dock="Bottom">
                        </ext:PagingToolbar>
                    </DockedItems>
                </ext:GridPanel>
                <ext:Toolbar ID="Toolbar5" runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" ID="ctl125" />
                        <ext:Button ID="HisBug" runat="server" Text="历史预算项目" Icon="ApplicationViewList" OnDirectClick="HisBug_DirectClick">
                        </ext:Button>
                        <ext:Button ID="btnAdd" runat="server" Text="添加" Icon="ApplicationAdd" OnDirectClick="btnAdd_DirectClick">
                        </ext:Button>

                    </Items>
                </ext:Toolbar>


                <ext:Window ID="WinHisBug" runat="server"
                    Title="历史预算项目列表"
                    Width="600"
                    Height="370"
                    Icon="ApplicationViewList"
                    Hidden="true"
                    Layout="FitLayout" >
                    <Items>
                        <ext:GridPanel ColumnLines="true" ID="gridpanel3" runat="server" Layout="FitLayout">
                            <Store>
                                <ext:Store ID="StoreHisBug" runat="server" PageSize="12">
                                    <%--OnReadData="MyData_Refresh"--%>
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="BudID" Type="int" />
                                                <%-- <ext:ModelField Name="DepName" Type="int" />--%>
                                                <ext:ModelField Name="BIProName" Type="string" />
                                                <ext:ModelField Name="BIProCategory" Type="string" />
                                                <ext:ModelField Name="BIMon" Type="float" />
                                                <ext:ModelField Name="BIAppReaCon" Type="string" />
                                                <ext:ModelField Name="BIExpGistExp" Type="string" />
                                                <ext:ModelField Name="BIYearGoal" Type="string" />
                                                <%-- <ext:ModelField Name="DepName" Type="string" />--%>
                                                <ext:ModelField Name="BIProType" Type="string" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column Sortable="true" ID="SummaryColumn1" runat="server" Text="编号" Flex="1" DataIndex="BudID" />
                                    <%-- <ext:Column Sortable="true" ID="SummaryColumn2" runat="server" Text="部门" Flex="1" DataIndex="DepName" />--%>
                                    <ext:Column Sortable="true" ID="SummaryColumn3" runat="server" Text="项目名称" Flex="1" DataIndex="BIProName" />
                                    <ext:Column Sortable="true" ID="SummaryColumn4" runat="server" Text="项目类型" Flex="1" DataIndex="BIProType" />
                                    <ext:Column Sortable="true" ID="SummaryColumn5" runat="server" Text="金额" Flex="1" DataIndex="BIMon" />
                                    <ext:Column Sortable="true" ID="SummaryColumn6" runat="server" Text="申请理由" Flex="1" DataIndex="BIAppReaCon" />
                                    <ext:Column Sortable="true" ID="Column9" runat="server" Text="申请依据" Flex="1" DataIndex="BIExpGistExp" />
                                    <ext:CommandColumn ID="CommandColumn6" runat="server" Header="确定" Flex="1" DataIndex="">
                                        <Commands>
                                            <ext:GridCommand Icon="TableEdit" CommandName="Subfield" Text="确定" />
                                        </Commands>
                                        <Listeners>
                                            <Command Fn="gridCommand"></Command>
                                        </Listeners>
                                    </ext:CommandColumn>
                                </Columns>
                            </ColumnModel> 
                            <DockedItems>
                                <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true" Dock="Bottom">
                                </ext:PagingToolbar>
                            </DockedItems>
                        </ext:GridPanel>

                    </Items>
                </ext:Window>
            </Items>
        </ext:Viewport>



        <ext:Window ID="WinAdd" runat="server"
            Title="添加员工"
            Width="400"
            Height="380"
            Icon="UserAdd"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="AnchorLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:Container ID="Container1" runat="server" Anchor="10" PaddingSpec="8 0 0 60">
                    <Items>
                        <ext:TextField ID="TextField1" runat="server"
                            FieldLabel="员工姓名"
                            Name="EmName" />

                        <ext:TextField ID="TextField2" runat="server"
                            FieldLabel="员工工号"
                            Name="EmID" />

                        <ext:TextField ID="TextField3" runat="server"
                            FieldLabel="员工性别"
                            Name="EmSex" />
                        <ext:TextField ID="TextField4" runat="server"
                            FieldLabel="身份证号"
                            Name="EmIdenID" />

                        <ext:TextField ID="TextField5" runat="server"
                            FieldLabel="部门名称"
                            Name="DID" />

                        <ext:TextField ID="TextField6" runat="server"
                            FieldLabel="员工职务"
                            Name="EmJob" />
                        <ext:TextField ID="TextField7" runat="server"
                            FieldLabel="入职时间"
                            Name="EmJoinTime" />

                        <ext:TextField ID="TextField8" runat="server"
                            FieldLabel="家庭住址"
                            Name="EmAddress" />

                        <ext:TextField ID="TextField9" runat="server"
                            FieldLabel="联系电话"
                            Name="EmTel" />
                        <ext:TextField ID="TextField10" runat="server"
                            FieldLabel="电子邮箱"
                            Name="EmEmail" />

                        <ext:TextField ID="TextField11" runat="server"
                            FieldLabel="银行卡号"
                            Name="EmBank" />
                    </Items>
                </ext:Container>

                <ext:Container ID="Container2" runat="server" Anchor="100" PaddingSpec="8 0 0 130">
                    <Items>
                        <ext:Button ID="Button3"
                            runat="server"
                            Text="添加"
                            Icon="UserAdd"
                            Margins="10">
                        </ext:Button>

                        <ext:Button ID="Button4"
                            runat="server"
                            Text="取消"
                            Icon="Disk"
                            Margin="10">
                        </ext:Button>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Window>


    </form>
</body>
</html>

