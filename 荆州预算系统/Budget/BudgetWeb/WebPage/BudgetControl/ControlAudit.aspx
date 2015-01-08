<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlAudit.aspx.cs" Inherits="WebPage_BudgetControl_ControlAudit" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <script type="text/javascript">
            var dbclick = function(a, b, c) {

                App.direct.DB(b.raw.DeptID, b.raw.MATime, b.raw.MATimes);
            }
        </script>
        <form id="form1" runat="server">
            <ext:ResourceManager runat="server"></ext:ResourceManager> 
            <ext:Hidden runat="server" ID="hidsta"></ext:Hidden>
            <ext:Viewport runat="server" Layout="fit"><Items><ext:GridPanel runat="server" ID="GTPdbsx" Title="待办事项" Region="South" Height="240" AutoScroll="True" Border="false" Layout="fit"><Tools><ext:Tool runat="server" Type="Prev" ><Listeners><Click Handler="window.location.href ='../Policy/PLNavigate.aspx'"></Click></Listeners></ext:Tool></Tools>
                                                                 <Store>
                                                                     <ext:Store runat="server" ID="GTPdbsxStore" PageSize="15">
                                                                         <Model>
                                                                             <ext:Model ID="Model2" runat="server">
                                                                                 <Fields><ext:ModelField Name="DeptID"></ext:ModelField>
                                                                                     <ext:ModelField Name="DepName"></ext:ModelField>
                                                                                       <ext:ModelField Name="MATimes"></ext:ModelField>
                                                                                     <ext:ModelField Name="MPFundingAddTimes"></ext:ModelField> 
                                                                                     <ext:ModelField Name="MPFunding" Type="Float" /> 
                                                                                     <ext:ModelField Name="MATime" Type="Date" /> 
                                                                                 </Fields>
                                                                             </ext:Model>
                                                                         </Model> 
                                                                         <Listeners><Load Handler="changeStyle1();" Delay="2000"></Load></Listeners>
                                                                     </ext:Store> 
                                                                 </Store>
                                                                 <ColumnModel ID="ColumnModel1"  runat="server">
                                                                     <Columns>
                                                                         <ext:Column ID="Column2"  Align="Center" runat="server" Flex="1" Text="部门" DataIndex="DepName"></ext:Column> 
                                                                         <ext:Column ID="Column1"  Align="Center" runat="server" Flex="1" Text="批次" DataIndex="MATimes"></ext:Column> 
                                                                         <ext:Column ID="Column5"  Align="Center" runat="server" Flex="1" Text="金额" DataIndex="MPFunding"  ></ext:Column>
                                                                         <ext:DateColumn ID="Column10" Align="Center" runat="server" Flex="1" Text="申报日期" DataIndex="MATime" Format="yyyy-MM-dd"></ext:DateColumn>
                                                                     </Columns></ColumnModel> <Listeners><ItemDblClick  Fn="dbclick"></ItemDblClick></Listeners> 
                                                             </ext:GridPanel></Items></ext:Viewport>
        </form>
    </body>
</html>