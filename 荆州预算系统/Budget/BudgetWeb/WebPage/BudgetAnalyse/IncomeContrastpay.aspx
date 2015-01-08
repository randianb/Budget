<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncomeContrastpay.aspx.cs" Inherits="WebPage_BudgetControl_IncomeContrastpay" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
</script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>  
        <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
        <script>
            var edit = function (editor, e) { 
                if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                    CompanyX.Edit(e.record.data.ICPID, e.record.data.InComeSouce,e.record.data.DepName,e.originalValue, e.value,e.record.data.DepID);
                }
            };
            function changeStyle() { 
                if ($("#gridview-1009 table tr").length > 0) { 
                    $("#gridview-1009 table tr").each(function () {
                        if ($(this).find("td:eq(1) div").text() == "总计") {
                            $(this).attr("style", "color:red;font-weight:bold");
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
            <ext:Viewport ID="Viewport1" runat="server" Layout="fit" >
                <Items>
                    <ext:GridPanel ID="GridPanel1" ColumnLines="true"
                                   runat="server"
                                   Title="收入与支出对比分析表" Layout="fit" AutoScroll="True" >
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ComboBox ID="cmbdept" FieldLabel="选择部门" LabelWidth="60" runat="server" ColumnWidth="0.2"  DisplayField="DepName" MinWidth="60"> 
                                        <SelectedItems>
                                            <ext:ListItem Index="0">
                                            </ext:ListItem>
                                        </SelectedItems>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbmon" FieldLabel="选择月份" LabelWidth="60" Editable="false" runat="server" OnDirectChange="cmbmon_DirectChange" ValueField="month" DisplayField="month">
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
                                        <Listeners> <Collapse Handler="App.direct.GetPagedirect();"></Collapse> </Listeners>
                                    </ext:ComboBox>
                                    <ext:Button runat="server" ID="Btnsure" Text="确定" OnDirectClick="BtnsureDirectEvents"></ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="Store1" runat="server"> 
                                <Model>
                                    <ext:Model ID="Model1" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="ICPID" Type="int" />
                                            <ext:ModelField Name="DepName" Type="String" />
                                            <ext:ModelField Name="DepID" Type="String" />
                                            <ext:ModelField Name="InComeSouce" Type="String" /> 
                                            <ext:ModelField Name="InComeMon" Type="Float" /> 
                                             <ext:ModelField Name="PayMon" Type="Float" />
                                             <ext:ModelField Name="BalanceMon" Type="Float" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                                 <Listeners><Load Handler="changeStyle();"></Load></Listeners>
                            </ext:Store>

                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" Width="35" />  
                                <ext:Column ID="Column3"
                                            runat="server"
                                            Text="部门名称"
                                            DataIndex="DepName" 
                                            Flex="1" />
                                <ext:Column ID="Column4"
                                            runat="server"
                                            Text="资金来源" 
                                            DataIndex="InComeSouce"
                                            Flex="1" />　 
                                <ext:Column ID="Column5"
                                            runat="server"
                                            EmptyCellText="0"
                                            Text="金额（元）" 
                                            DataIndex="InComeMon"
                                            Flex="1"> 
                                </ext:Column> 　
                                 <ext:Column ID="Column1"
                                            runat="server"
                                            EmptyCellText="0"
                                            Text="支出（元）" 
                                            DataIndex="PayMon"
                                            Flex="1"> 
                                </ext:Column> 
                                 <ext:Column ID="Column2"
                                            runat="server"
                                            EmptyCellText="0"
                                            Text="差额（元）" 
                                            DataIndex="BalanceMon"
                                            Flex="1"> 
                                </ext:Column> 
                            </Columns>
                        </ColumnModel>  
                    </ext:GridPanel>
                </Items>
            </ext:Viewport>
        </form>
    </body>
</html>