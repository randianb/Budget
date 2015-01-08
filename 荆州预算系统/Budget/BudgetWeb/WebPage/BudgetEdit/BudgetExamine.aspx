<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetExamine.aspx.cs" Inherits="WebPage_BudgetEdit_BudgetExamine" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

 <script type="text/javascript">
     var gridCommand = function (sender, command, record) {
         switch (command) {
             case "Report":
                 App.direct.Report_Handler(record.data.BudID);
                 break;
             case "Look":
                 App.direct.Look_Handler(record.data.BudID);
                 break;
         }
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" ID="vwpLayout" >
            <Items>
                <ext:Panel
                    ID="GridPanel2"
                    runat="server"  
                    Title="预算上报"  
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
                            DisplayField="DepName"
                            ValueField="DepID"
                            Style="margin-top: 8px"
                            Width="160"
                            LabelWidth="50"
                            QueryMode="Local"
                            TypeAhead="true"
                            PaddingSpec="0 0 0 8">
                            <SelectedItems>
                                <ext:ListItem Index="0">

                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                          <ext:ComboBox runat="server" ID="cmbyear" OnLoad="YearBind" Style="margin-top: 8px;margin-left: 8px"
                            Width="160"
                            LabelWidth="50">
                             <SelectedItems>
                                <ext:ListItem Index="0"></ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                        <ext:Container ID="Container3" runat="server" PaddingSpec="6 0 0 20" >
                            <Items >
                                 <ext:Button ID="btnInquiry" runat="server" Text="查 询" Height="24" Width="40" OnDirectClick="btnInquiry_DirectClick"   >
                                </ext:Button>
                            </Items> 
                        </ext:Container> 
                    </Items>
                </ext:Toolbar>

                <ext:GridPanel  ColumnLines="true" ID="gridpanel1" runat="server"  Layout="AnchorLayout" AutoScroll="true"
                    Title="预算上报列表数据显示及操作">
                    <Store>
                        <ext:Store ID="stBudget" runat="server" PageSize="12">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="BICode" Type="string" />
                                        <ext:ModelField Name="BIProName" Type="string" />
                                        <ext:ModelField Name="BIProType" Type="string" />
                                        <ext:ModelField Name="DepName" Type="string" />
                                        <ext:ModelField Name="BIYear" Type="string" />
                                        <ext:ModelField Name="BudSta" Type="string" />
                                        <ext:ModelField Name="ReportNum" Type="string" />
                                        <ext:ModelField Name="BudID" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:SummaryColumn Sortable="true" ID="Column1" runat="server" Text="项目编号" Flex="1" DataIndex="BICode" />
                            <ext:SummaryColumn Sortable="true" ID="Column2" runat="server" Text="项目名称" Flex="1" DataIndex="BIProName" />
                            <ext:SummaryColumn Sortable="true" ID="Column3" runat="server" Text="项目类型" Flex="1" DataIndex="BIProType" />
                            <ext:SummaryColumn Sortable="true" ID="Column5" runat="server" Text="部门名称" Flex="1" DataIndex="DepName" />
                            <ext:SummaryColumn Sortable="true" ID="Column6" runat="server" Text="年度" Flex="1" DataIndex="BIYear" />
                            <ext:SummaryColumn Sortable="true" ID="Column7" runat="server" Text="项目状态" Flex="1" DataIndex="BudSta" />
                            <ext:SummaryColumn Sortable="true" ID="Column8" runat="server" Text="上报次数" Flex="1" DataIndex="ReportNum" />
                            <ext:CommandColumn ID="CommandColumn3" runat="server" Header="上报局党组" Flex="1" DataIndex="">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Report" Text="上报局党组" />
                                </Commands>
                                <Listeners>
                                    <Command Fn="gridCommand"></Command>
                                </Listeners>
                            </ext:CommandColumn>
                            <ext:CommandColumn ID="CommandColumn4" runat="server" Header="查看" Flex="1">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Look" Text="查看" />
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

