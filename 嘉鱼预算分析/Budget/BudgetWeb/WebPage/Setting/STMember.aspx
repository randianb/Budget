<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STMember.aspx.cs" Inherits="WebPage_Setting_STMember" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>

        <script type="text/javascript">
            var selectionChanged = function(selModel, selected) {
                if (selected.length > 0 && selected[0].childNodes.length == 0) {
                    var uid = selected[0].data.id;
                    App.direct.Memberselect(uid);
                }
            };
            var selectdept = function(q, w, e) {
                App.direct.selectdep(w.data.text);
            };

            var getcheck = function (a, b, c) {
                var Radio4 = App.Radio4;
                var fs = App.FieldSet2;
                if (Radio4.checked) {
                    fs.show();
                } else {
                    fs.hide();
                    Radio4.setValue(false);
                }

            }
            var nodeLoad = function(store, operation, options) {
                var node = operation.node;

                App.direct.NodeLoad(node.getId(), {
                    success: function(result) {
                        node.set('loading', false);
                        node.set('loaded', true);
                        var data = Ext.decode(result);
                        node.appendChild(data, undefined, true);
                        node.expand();
                    },

                    failure: function(errorMsg) {
                        Ext.Msg.alert('错误', '请重新打开页面');
                    }
                });

                return false;
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
                            <ext:Hidden runat="server" ID="hidUserID1" />
                            <ext:TreePanel
                                ID="STMem" Title="部门列表"
                                runat="server" Height="650"
                                SingleExpand="false"
                                UseArrows="true"
                                RootVisible="false"
                                ColumnWidth="0.3">
                                <%--<Store>
                                <ext:TreeStore runat="server" OnReadData="GetNodes" ID="ctl825">
                                </ext:TreeStore>
                            </Store>--%>
                                <Listeners>
                                    <BeforeLoad Fn="nodeLoad" />
                                    <SelectionChange Fn="selectionChanged"></SelectionChange>
                                    <ItemClick Fn="selectdept"></ItemClick>
                                </Listeners>
                            </ext:TreePanel>

                            <ext:FormPanel ID="PlMenber"
                                           runat="server" Height="650"
                                           Title="人员信息"
                                           ColumnWidth="0.7">

                                <Items>
                                    <%--<ext:Button ID="btnAdd" MarginSpec="20 0 0 50" Width="80" runat="server" Text=" 增  加 " OnDirectClick="btnAdd_DirectClick1" />--%>


                                    <ext:TextField ID="TextField1" LabelWidth="60"
                                                   runat="server" MarginSpec="30 0 0 50"
                                                   AllowBlank="true"
                                                   FieldLabel="姓  名"
                                                   Name="user">
                                        <DirectEvents>
                                            <Blur OnEvent="gettext_Event"></Blur>
                                        </DirectEvents>
                                    </ext:TextField>
                                    <ext:TextField LabelWidth="60" EmptyText="请先在左边选择部门" MarginSpec="10 0 0 50" FieldLabel="所在部门" runat="server" ID="ComboBox1" ReadOnly="true"></ext:TextField>
                                    <%--<ext:ComboBox ID="ComboBox1" LabelWidth="60" Editable="false"
                                    runat="server" MarginSpec="10 0 0 50"
                                    FieldLabel="所在部门"
                                    Name="state"
                                    QueryMode="Local"
                                    TypeAhead="true">
                                    <SelectedItems>
                                        <ext:ListItem Index="0"></ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>--%>
                                    <%-- DisplayField="name"
                                    ValueField="abbr"--%>
                                    <ext:TextField ID="TextField3" LabelWidth="60"
                                                   runat="server" MarginSpec="10 0 0 50"
                                                   AllowBlank="true"
                                                   ReadOnly="true"
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
                                            <ext:RadioGroup runat="server" Layout="AnchorLayout">
                                                <Items>
                                                    <ext:Radio ID="Radio1" runat="server" FieldLabel="管理员" Checked="true"></ext:Radio>
                                                    <ext:Radio ID="Radio2" runat="server" FieldLabel="局领导"></ext:Radio>
                                                    <ext:Radio ID="Radio3" runat="server" FieldLabel="审核员"></ext:Radio>
                                                    <ext:Radio ID="Radio4" runat="server" FieldLabel="录入人员"></ext:Radio>
                                                    <ext:Radio ID="Radio5" runat="server" FieldLabel="查询人员"></ext:Radio> 
                                                    <ext:Radio ID="Radio6" runat="server" FieldLabel="出纳员"></ext:Radio>
                                                </Items>
                                               <Listeners><Change  Fn="getcheck"></Change></Listeners>
                                            </ext:RadioGroup>

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
                                       <ext:FieldSet ID="FieldSet2"
                                           Hidden="True"
                                                  runat="server" MarginSpec="20 0 0 50"
                                                  Title="是否为超级用户"
                                                  Collapsible="true" Width="220"
                                                  DefaultAnchor="100%">
                                           <Items>
                                    <ext:RadioGroup MarginSpec="20 0 0 0" ID="RadioGroup1"   runat="server"   >
                                           <Defaults>
                                        <ext:Parameter Name="labelWidth" Value="20" Mode="Raw" />
                                                <ext:Parameter Name="Width" Value="20" Mode="Raw" />
                                    </Defaults>
                                        <Items>
                                            <ext:Radio ID="Radio7" runat="server" FieldLabel="是" Checked="False"></ext:Radio>
                                            <ext:Radio ID="Radio8" runat="server" FieldLabel="否" Checked="True"></ext:Radio>
                                        </Items>
                                    </ext:RadioGroup>
                                               </Items> </ext:FieldSet>
                                    <ext:Button ID="btnMod" MarginSpec="20 0 0 55" Width="60" Icon="UserEdit" runat="server" Text="确定">
                                        <Listeners>
                                            <Click Handler="
                                                if (!#{TextField1}.validate() || !#{TextField3}.validate() ||!#{TextField4}.validate() ) {
                                                    Ext.Msg.alert('Error','验证有误，请核实所填项是否已填写完整!'); 
                                                    return false; 
                                                }" />
                                        </Listeners>
                                        <DirectEvents>
                                            <Click OnEvent="btnMod_DirectClick">
                                                <EventMask ShowMask="false" Msg="Verifying..." MinDelay="500" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnDel" MarginSpec="20 0 0 90" runat="server" Text=" 删除 " Width="60" Icon="Delete" OnDirectClick="btnDel_DirectClick" />
                                </Items>
                            </ext:FormPanel>

                        </Items>
                    </ext:Panel>

                </Items>
            </ext:Viewport>
        </form>
    </body>
</html>