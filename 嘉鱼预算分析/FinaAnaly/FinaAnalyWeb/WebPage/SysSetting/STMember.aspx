<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STMember.aspx.cs" Inherits="WebPage_SysSetting_STMember" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script type="text/javascript">
        var selectionChanged = function (selModel, selected) {

            if (selected.length > 0) {
                var uid = selected[0].data.id;

                App.direct.Memberselect(uid);
            }
        };
    </script>

    <%--<link href="/resources/css/examples.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidUserID" />
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="ColumnLayout">
                    <Items>
                        <ext:TreePanel
                            ID="STMem" Title="部门列表"
                            runat="server" Height="650"
                            SingleExpand="true"
                            UseArrows="true"
                            RootVisible="false"
                            ColumnWidth="0.3">
                            <Store>
                                <ext:TreeStore runat="server" OnReadData="GetNodes" ID="ctl825">
                                </ext:TreeStore>
                            </Store>
                            <Listeners>
                                <SelectionChange Fn="selectionChanged"></SelectionChange>
                            </Listeners>
                        </ext:TreePanel>

                        <ext:Panel ID="PlMenber"
                            runat="server" Height="650"
                            Title="人员信息"
                            ColumnWidth="0.7">

                            <Items>
                                <ext:Button ID="btnAdd" MarginSpec="20 0 0 50" Width="80" runat="server" Text=" 增  加 " OnDirectClick="btnAdd_DirectClick1" />
                                <ext:Button ID="btnDel" MarginSpec="20 0 0 20" Width="80" runat="server" Text=" 删  除 " OnDirectClick="btnDel_DirectClick" />

                                <ext:TextField ID="TextField1" LabelWidth="60"
                                    runat="server" MarginSpec="30 0 0 50"
                                    AllowBlank="false"
                                    FieldLabel="姓  名"
                                    Name="user" />

                                <ext:ComboBox ID="ComboBox1" LabelWidth="60"
                                    runat="server" MarginSpec="10 0 0 50"
                                    FieldLabel="所在部门"
                                    Name="state"
                                    DisplayField="name"
                                    ValueField="abbr"
                                    QueryMode="Local"
                                    TypeAhead="true">
                                </ext:ComboBox>

                                <ext:TextField ID="TextField3" LabelWidth="60"
                                    runat="server" MarginSpec="10 0 0 50"
                                    AllowBlank="false"
                                    FieldLabel="登录帐号" Regex="^[A-Za-z]+$" RegexText="必须为英文字母"
                                    Name="worknum" />

                                <ext:TextField ID="TextField4" Name="idnum" runat="server" LabelWidth="60" MarginSpec="10 0 0 50" FieldLabel="身份证号" Regex="/^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/"
                                    RegexText="请输入正确的身份证号码." />
                                <ext:TextField ID="txtRem" LabelWidth="60"
                                    runat="server" MarginSpec="10 0 0 50"
                                    AllowBlank="true"
                                    FieldLabel="人员备注"
                                    Name="userrem" />
                                <ext:TextField ID="UserID" Hidden="true" Text="" runat="server" />


                                <ext:FieldSet ID="FieldSet1"
                                    runat="server" MarginSpec="20 0 0 50"
                                    Title="人员权限"
                                    Collapsible="true" Width="220"
                                    DefaultAnchor="100%">
                                    <%--  <Defaults>
                                        <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                                    </Defaults>--%>
                                    <Items>
                                        <ext:Radio ID="Radio1" runat="server" FieldLabel="管理员" Name="aa"></ext:Radio>
                                        <ext:Radio ID="Radio2" runat="server" FieldLabel="操作员" Name="aa"></ext:Radio>
                                        <%--   <ext:RadioGroup ID="RadioGroup1" runat="server" MarginSpec="10 0 0 20" FieldLabel="管理员" GroupName="aaa"></ext:RadioGroup>
                                        <ext:RadioGroup ID="RadioGroup2" runat="server" MarginSpec="10 0 0 20" FieldLabel="局领导" GroupName="aaa"></ext:RadioGroup>
                                        <ext:RadioGroup ID="RadioGroup3" runat="server" MarginSpec="10 0 0 20" FieldLabel="审核员" GroupName="aaa"></ext:RadioGroup>
                                        <ext:RadioGroup ID="RadioGroup4" runat="server" MarginSpec="10 0 0 20" FieldLabel="查询人员" GroupName="aaa"></ext:RadioGroup>
                                        <ext:RadioGroup ID="RadioGroup5" runat="server" MarginSpec="10 0 0 20" FieldLabel="录入人员" GroupName="aaa"></ext:RadioGroup>--%>
                                        <%--      <ext:Checkbox ID="chkMan" MarginSpec="10 0 0 20" runat="server" FieldLabel="管理员" Name="man" />
                                        <ext:Checkbox ID="chkCash" MarginSpec="0 0 0 20" runat="server" FieldLabel="局领导" Name="cash" />
                                        <ext:Checkbox ID="chkLead" MarginSpec="0 0 0 20" runat="server" FieldLabel="审核员" Name="lead" />
                                        <ext:Checkbox ID="chkAudit" MarginSpec="0 0 0 20" runat="server" FieldLabel="查询人员" Name="audit" />
                                        <ext:Checkbox ID="chkEntry" MarginSpec="0 0 10 20" runat="server" FieldLabel="录入人员" Name="entry" />--%>
                                    </Items>
                                </ext:FieldSet>

                                <ext:Button ID="btnMod" MarginSpec="20 0 0 120" Width="65" Icon="UserEdit" runat="server" Text="确定" OnDirectClick="btnMod_DirectClick" />
                                <ext:Button ID="btnCan" MarginSpec="20 0 0 20" Width="65" Icon="Cancel" runat="server" Text="取消" OnDirectClick="btnCan_DirectClick" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>


        <ext:Window ID="Winadd" runat="server"
            Title="添加人员"
            Width="350"
            Height="430"
            Icon="ApplicationForm"
            AnimCollapse="false"
            Border="false"
            HideMode="Offsets"
            Resizable="false"
            Layout="BorderLayout"
            CloseAction="Hide"
            Hidden="true">
            <Items>
                <ext:Panel ID="Panel3" runat="server" Header="false" Collapsible="true" Border="false" Region="West" Split="false" Width="300" MarginSpec="10 5 5 5" Margins='0 0 0 0' BaseCls=" background: white">
                    <Items>
                        <ext:TextField ID="DepID" Hidden="true" runat="server" />
                        <ext:TextField ID="UserName" MarginSpec="0 0 0 50" runat="server" Name="UserName" FieldLabel="人员姓名" AllowBlank="false" LabelWidth="60">
                        </ext:TextField>
                        <ext:TextField ID="UserIDNum" MarginSpec="10 0 0 50" runat="server" Name="UserIDNum" FieldLabel="身份证号" Regex="/^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/" RegexText="请输入正确的身份证号码." AllowBlank="false" LabelWidth="60">
                        </ext:TextField>
                        <ext:TextField ID="UserRem" MarginSpec="10 0 0 50" runat="server" Name="UserRem" FieldLabel="人员备注" AllowBlank="true" LabelWidth="60">
                        </ext:TextField>
                        <ext:TextField ID="UserNum" MarginSpec="10 0 0 50" runat="server" Name="UserNum" Regex="/^\d+$/" RegexText="必须为数字" FieldLabel="人员工号" LabelWidth="60" AllowBlank="false">
                        </ext:TextField>
                        <ext:TextField ID="UserDep" MarginSpec="10 0 0 50" runat="server" Name="UserDep" FieldLabel="所属部门" LabelWidth="60" AllowBlank="false">
                        </ext:TextField>

                        <ext:ComboBox ID="cbbSta" MarginSpec="10 0 0 50"
                            runat="server"
                            FieldLabel="人员状态"
                            LabelWidth="60"
                            TypeAhead="true">
                            <Items>
                                <ext:ListItem Text="正常" Value="正常" />
                                <ext:ListItem Text="禁用" Value="禁用" />
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Index="0" />
                            </SelectedItems>
                        </ext:ComboBox>

                        <%--   <ext:ComboBox ID="cmbDepnaem"
                            runat="server"
                            FieldLabel="所在部门" MarginSpec="10 0 0 50"
                            Name="state" LabelWidth="60"
                            DisplayField="name"
                            ValueField="abbr"
                            QueryMode="Local"
                            TypeAhead="true">
                        </ext:ComboBox>--%>

                        <ext:FieldSet ID="FieldSet2"
                            runat="server" MarginSpec="20 0 0 50"
                            Title="人员权限"
                            Collapsible="true" Width="210"
                            DefaultAnchor="100%">

                            <Items>
                                <ext:Checkbox ID="chkManAdd" MarginSpec="10 0 0 20" runat="server" FieldLabel="管理员" Name="man" />
                                <ext:Checkbox ID="chkCashAdd" MarginSpec="0 0 0 20" runat="server" FieldLabel="操作员" Name="cash" />
                            </Items>
                        </ext:FieldSet>
                        <ext:Button ID="Button1" runat="server" Text="增加" Icon="UserAdd" OnDirectClick="btnWinAdd_DirectClick"></ext:Button>
                        <ext:Button ID="Button2" runat="server" Text="取消" Icon="Cancel" OnDirectClick="btnWinCancel_DirectClick"></ext:Button>
                    </Items>


                </ext:Panel>


                <%--<ext:Panel ID="Panel4" runat="server" Header="false" Collapsible="true" Border="false" Region="East" Split="false" Width="300" MarginSpec="10 5 5 5" Margins='0 0 0 0' BaseCls=" background: white">
                 
                    <DockedItems>
                        <ext:Toolbar ID="Toolbar2" runat="server" Dock="Bottom">
                            <Items>
                                <ext:Button ID="btnWinAdd" MarginSpec="0 0 10 100" runat="server" Text="增加" Icon="ApplicationEdit" OnDirectClick="btnWinAdd_DirectClick"></ext:Button>
                                <ext:Button ID="btnWinCancel" runat="server" Text="取消" Icon="ApplicationEdit" OnDirectClick="btnWinCancel_DirectClick"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:Panel>--%>
            </Items>
        </ext:Window>


    </form>
</body>
</html>

