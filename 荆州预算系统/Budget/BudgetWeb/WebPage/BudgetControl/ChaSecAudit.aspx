<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChaSecAudit.aspx.cs" Inherits="BudgetPage_mainPages_ChaSecAudit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分管局长审核</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js"></script> 
      <script src="../../js/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        html, body
        {
            overflow: scroll;
            overflow-y: hidden;
            margin: 0;
            height: 100%;
        }

        .txt
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 180px;
        }
    </style>
    <script type="text/javascript">
        var dbclick = function (a, b, c) {

            App.direct.DB(b.raw.DeptID, b.raw.MATime, b.raw.MATimes);
        }
        var rawclick = function (a, b, c) {
            App.direct.GetRowexpand(b.data.PIEcoSubParID);
        }
        $(function () { setTimeout(changeStyle(), 10000) })
        function changeStyle() {
            if ($("#gridview-1009 table tr").length > 0) {

                $("#gridview-1009 table tr").each(function () {
                    if ($(this).find("td:first div").text() == "总计") {
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
        
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="ViewPort1" runat="server" Layout="fit">
            <Items>
                <ext:Hidden runat="server" ID="hidflag"></ext:Hidden>

                <ext:GridPanel ID="gridpanel1" ColumnLines="true" runat="server" Layout="fit" AutoScroll="true"  
                    Title="分管局长审核">
                       <Tools><ext:Tool ID="Tool1" runat="server" Type="Prev" ><Listeners><Click Handler="window.location.href ='ControlAudit.aspx?Audit=1'"></Click></Listeners></ext:Tool></Tools>
                     <Listeners><ItemClick  Fn="rawclick"></ItemClick></Listeners>
                    <Store>
                        <ext:Store ID="AuditStore" runat="server" PageSize="9">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="PIEcoSubParID" Type="int" />
                                        <ext:ModelField Name="DepName" Type="string" />
                                        <ext:ModelField Name="PIEcoSubName" Type="string" />
                                        <ext:ModelField Name="MPFunding" Type="float" />
                                        <ext:ModelField Name="MASta" Type="string" />
                                        <ext:ModelField Name="MACause" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                             <Listeners> <Load Handler="changeStyle();" Delay="2000"></Load></Listeners>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column Sortable="true" ID="clDepName" runat="server" Text="部门名称" Flex="1" DataIndex="DepName" />
                            <ext:Column Align="center" ID="clPIEcoSubName" runat="server" Text="经济科目" Flex="1" DataIndex="PIEcoSubName" />
                            <ext:Column Align="center" ID="clBAAMon" runat="server" Text="经费（元）" Flex="1" DataIndex="MPFunding" > </ext:Column>
                            <ext:Column Align="center" ID="clBalance" runat="server" Text="审核状态" Flex="1" DataIndex="MASta" />
                            <ext:Column Align="center" ID="clMACause" runat="server" Text="原因" Flex="1" DataIndex="MACause" />
                        </Columns>
                    </ColumnModel>

                 <TopBar>
                        <ext:Toolbar ID="Toolbar1" Height="150" runat="server" BaseCls="background:transparent" Layout="ColumnLayout"> 
                            <Items>
                                   <ext:Panel ID="Panel3" runat="Server" Border="false"  Layout="AnchorLayout" ColumnWidth="0.3" BaseCls="background:transeparent" ><Items>
  <ext:Panel ID="Container1" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="5 0 5 0">
                                    <Items>
                                        <ext:Label ID="Label3" runat="server" MarginSpec="5 5 0 5" Text="部门名称：" Width="60"></ext:Label>
                                        <ext:ComboBox ID="cmbdept" runat="server" ColumnWidth="0.6"  DisplayField="DepName" MinWidth="60"> 
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel1" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 5 0" >
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" MarginSpec="5 5 0 5" Text="年　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox ID="cmbyear" runat="server" ColumnWidth="0.6" DisplayField="Year" MinWidth="60" Editable="false">
                                            <Store>
                                                <ext:Store ID="cmbyearstore" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model2" runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="Year"></ext:ModelField>
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
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel2" Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" MarginSpec="5 5 0 5" Text="月　　份：" Width="60"></ext:Label>
                                        <ext:ComboBox ID="cmbmonth" runat="server" ColumnWidth="0.6" MinWidth="60" Editable="false">
                                            <Items>
                                                <ext:ListItem Text="1" Value="1" />
                                                <ext:ListItem Text="2" Value="2" />
                                                <ext:ListItem Text="3" Value="3" />
                                                <ext:ListItem Text="4" Value="4" />
                                                <ext:ListItem Text="5" Value="5" />
                                                <ext:ListItem Text="6" Value="6" />
                                                <ext:ListItem Text="7" Value="7" />
                                                <ext:ListItem Text="8" Value="8" />
                                                <ext:ListItem Text="9" Value="9" />
                                                <ext:ListItem Text="10" Value="10" />
                                                <ext:ListItem Text="11" Value="11" />
                                                <ext:ListItem Text="12" Value="12" />
                                            </Items>
                                            <SelectedItems>
                                                <ext:ListItem Index="0">
                                                </ext:ListItem>
                                            </SelectedItems>
                                        </ext:ComboBox> 
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel4"  Border="false" runat="server" Layout="ColumnLayout" MarginSpec="0 0 10 0"  ><Items><ext:Label ID="Label4" runat="server" MarginSpec="5 5 0 5" Text="申请批次：" Width="60"></ext:Label><ext:ComboBox runat="server" ID="cmbpici" ColumnWidth="0.6"> <Items>
                                                <ext:ListItem Text="1"  Value="1"/>
                                                <ext:ListItem Text="2"  Value="2"/>
                                                <ext:ListItem Text="3"  Value="3"/>
                                                <ext:ListItem Text="4"  Value="4"/>
                                                <ext:ListItem Text="5"  Value="5"/>
                                                <ext:ListItem Text="6"  Value="6"/>
                                                <ext:ListItem Text="7"  Value="7"/>
                                                <ext:ListItem Text="8"  Value="8"/>
                                                <ext:ListItem Text="9"  Value="9"/>
                                                <ext:ListItem Text="10" Value="10" /> 
                                    <ext:ListItem Text="11"  Value="11"/>
                                                <ext:ListItem Text="12"  Value="12"/>
                                                <ext:ListItem Text="13"  Value="13"/>
                                                <ext:ListItem Text="14"  Value="14"/>
                                                <ext:ListItem Text="15"  Value="15"/>
                                                <ext:ListItem Text="16"  Value="16"/>
                                                <ext:ListItem Text="17"  Value="17"/>
                                                <ext:ListItem Text="18"  Value="18"/>
                                                <ext:ListItem Text="19"  Value="19"/>
                                                <ext:ListItem Text="20" Value="20" /> 
                                            </Items><SelectedItems>
                                                                                                                    <ext:ListItem Index="0">
                                                                                                                    </ext:ListItem>
                                                                                                                </SelectedItems> </ext:ComboBox></Items></ext:Panel>
                                <ext:Button   runat="server" MarginSpec="0 0 5 0" ID="submit" OnDirectClick="submit_DirectClick" Text="确定"></ext:Button><ext:Button  Icon="Accept" runat="server" MarginSpec="0 0 5 0" ID="Button3" OnDirectClick="qh_DirectClick" Text="切换"></ext:Button>

                                                                                                                           </Items></ext:Panel>
                              
                                   <ext:GridPanel runat="server" ID="GTPdbsx" Title="待办事项"   ColumnWidth="0.7"  Height="100" AutoScroll="True" Border="false" Layout="fit"> 
                                                                 <Store>
                                                                     <ext:Store runat="server" ID="GTPdbsxStore" PageSize="15">
                                                                         <Model>
                                                                             <ext:Model ID="Model3" runat="server">
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
                                                                 <ColumnModel ID="ColumnModel2"  runat="server">
                                                                     <Columns>
                                                                         <ext:Column ID="Column2"  Align="Center" runat="server" Flex="1" Text="部门" DataIndex="DepName"></ext:Column> 
                                                                         <ext:Column ID="Column1"  Align="Center" runat="server" Flex="1" Text="批次" DataIndex="MATimes"></ext:Column> 
                                                                         <ext:Column ID="Column5"  Align="Center" runat="server" Flex="1" Text="金额" DataIndex="MPFunding"  ></ext:Column>
                                                                         <ext:DateColumn ID="Column10" Align="Center" runat="server" Flex="1" Text="申报日期" DataIndex="MATime" Format="yyyy-MM-dd"></ext:DateColumn>
                                                                     </Columns></ColumnModel> <Listeners><ItemDblClick  Fn="dbclick"></ItemDblClick></Listeners> 
                                                             </ext:GridPanel>
                              <%--  <ext:Panel ID="Panel1" runat="server" Title="财务科审核" />--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <BottomBar>
                         <ext:Toolbar ID="Toolbar2" runat="server" BaseCls="background:transparent" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container2" runat="server" ColumnWidth="1">
                                    <Content>
                                        <div class="table_list" style="padding: 0 0 0 0; margin: 0 0 0 0">
                                            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button ID="Button1" CssClass="btns" runat="server" Text="  审核通过 " OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="Button2" CssClass="btns" runat="server" Text="  审核不通过  " OnClick="btnSel_Click" ValidationGroup="AddBI"  />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 80px;">
                                                        <asp:Label ID="lbShow" runat="server" Text="不通过原因："></asp:Label>&nbsp;&nbsp; 
                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="txt" Height="50px" Width="300px"></asp:TextBox><span
                                                            style="color: red">*</span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReason"
                                                            Display="Dynamic" ErrorMessage="不通过原因不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>

                                                    </td>

                                                </tr> 
                                            </table>
                                        </div>
                                    </Content>
                                </ext:Container> 
                            </Items>

                        </ext:Toolbar>
                    </BottomBar>
                </ext:GridPanel> 
            </Items>
            
        </ext:Viewport>
    </form>
</body>
</html>
