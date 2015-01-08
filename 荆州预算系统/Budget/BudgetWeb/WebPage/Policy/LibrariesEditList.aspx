<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LibrariesEditList.aspx.cs"
    Inherits="WebPage_Policy_LibrariesEditList" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">

        var gridCommand = function (sender, command, record) {
            switch (command) {
                case "Modify":
                    App.direct.Modify_Handler(record.data.BudItID);
                    break;
                case "Delete":
                    App.direct.Delete_Handler(record.data.BudItID);
                    break;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" Layout="fit">
            <Items>
                <ext:GridPanel ColumnLines="true" ID="gridpanel1" runat="server"
                    Title="预算项目类库">
                    <Store>
                        <ext:Store ID="stBudget" runat="server" PageSize="18">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="BudItID" Type="int" />
                                        <ext:ModelField Name="DepID" Type="int" />
                                        <ext:ModelField Name="BILProName" Type="string" />
                                        <ext:ModelField Name="BILProCategory" Type="string" />
                                        <ext:ModelField Name="BILMon" Type="float" />
                                        <ext:ModelField Name="BILAppReaCon" Type="string" />
                                        <ext:ModelField Name="BILExpGistExp" Type="string" />
                                        <ext:ModelField Name="BILYearGoal" Type="string" />
                                        <ext:ModelField Name="DepName" Type="string" />
                                        <ext:ModelField Name="BILProType" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column1" runat="server" Text="编号" Flex="1"
                                DataIndex="BudItID" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column2" runat="server" Text="部门名" Flex="1"
                                DataIndex="DepName" />
                            <%-- <ext:SummaryColumn Sortable="true" ID="SummaryColumn1" runat="server" Text="部门" Flex="1"
                                DataIndex="DepID" />--%>
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column3" runat="server" Text="项目名称" Flex="1"
                                DataIndex="BILProName" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column5" runat="server" Text="项目类别" Flex="1"
                                DataIndex="BILProCategory" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="SummaryColumn2" runat="server" Text="项目类型" Flex="1"
                                DataIndex="BILProType" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column6" runat="server" Text="金额" Flex="1"
                                DataIndex="BILMon" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column7" runat="server" Text="申请理由" Flex="1"
                                DataIndex="BILAppReaCon" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column8" runat="server" Text="申请依据" Flex="1"
                                DataIndex="BILExpGistExp" />
                            <ext:SummaryColumn Sortable="true" Align="Center" ID="Column9" runat="server" Text="项目绩效年度目标" Flex="1"
                                DataIndex="BILYearGoal" />

                            <ext:CommandColumn ID="CommandColumn1" Align="Center" runat="server" Header="修改">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Modify" Text="修改" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn2" Align="Center" runat="server" Header="删除">
                                <Commands>
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
                    <DockedItems>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true" Dock="Bottom">
                        </ext:PagingToolbar>
                    </DockedItems>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        <ext:Window ID="WinAdd" runat="server" Title="添加员工" Width="400" Height="380" Icon="UserAdd"
            AnimCollapse="false" Border="false" HideMode="Offsets" Resizable="false" Layout="AnchorLayout"
            CloseAction="Hide" Hidden="true">
            <Items>
                <ext:Container ID="Container1" runat="server" Anchor="10" PaddingSpec="8 0 0 60">
                    <Items>
                        <ext:TextField ID="TextField1" runat="server" FieldLabel="员工姓名" Name="EmName" />
                        <ext:TextField ID="TextField2" runat="server" FieldLabel="员工工号" Name="EmID" />
                        <ext:TextField ID="TextField3" runat="server" FieldLabel="员工性别" Name="EmSex" />
                        <ext:TextField ID="TextField4" runat="server" FieldLabel="身份证号" Name="EmIdenID" />
                        <ext:TextField ID="TextField5" runat="server" FieldLabel="部门名称" Name="DID" />
                        <ext:TextField ID="TextField6" runat="server" FieldLabel="员工职务" Name="EmJob" />
                        <ext:TextField ID="TextField7" runat="server" FieldLabel="入职时间" Name="EmJoinTime" />
                        <ext:TextField ID="TextField8" runat="server" FieldLabel="家庭住址" Name="EmAddress" />
                        <ext:TextField ID="TextField9" runat="server" FieldLabel="联系电话" Name="EmTel" />
                        <ext:TextField ID="TextField10" runat="server" FieldLabel="电子邮箱" Name="EmEmail" />
                        <ext:TextField ID="TextField11" runat="server" FieldLabel="银行卡号" Name="EmBank" />
                    </Items>
                </ext:Container>
                <ext:Container ID="Container2" runat="server" Anchor="100" PaddingSpec="8 0 0 130">
                    <Items>
                        <ext:Button ID="BtnAddtolist" runat="server" Text="添加" Icon="UserAdd" Margins="10">
                        </ext:Button>
                        <ext:Button ID="BtnCans" runat="server" Text="取消" Icon="Disk" Margin="10">
                        </ext:Button>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
