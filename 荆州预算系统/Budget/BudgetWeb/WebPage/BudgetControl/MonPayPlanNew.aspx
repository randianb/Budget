<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonPayPlanNew.aspx.cs" Inherits="WebPage_BudgetControl_MonPayPlanNew" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <script src="../../js/jquery-1.7.2.min.js"></script>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <style>
        /*#ext-gen1129 {
            display: none !important;
        }

        #ext-gen1142 {
            display: none !important;
        }
         #ext-gen1119 {
            display: none !important;
        }*/

        .x-tree-elbow-empty{display: none !important;}
            .rating-unselected { 
                width: 16px !important;
            } 
            

            .x-grid-row td {
                border-bottom: 1px solid #EDEDED !important;
                border-right: 1px solid #EDEDED !important;
            }

            .hidstyle { display: none !important; }
        </style>
    </head>

    <body >
        <script>
            //        var mouseleave= function(a, b, c) {
            //            alert(a);
            //            alert(b);
            //            alert(c);
            //            //            a.id
            //            var arr = new Array();
            //            arr = c.innerText.split("\r\n");
            //            var arr2 = parseFloat(arr[1]) - parseFloat(arr[3]); 
            //            c.innerText(arr[0] + "\r\n" + arr[1] + "\r\n" + arr[2] + "\r\n" + arr[3]);

            //        }
            //        var GetID= function(a, b, c) {
            //            alert($(a.id).parent().find(".x-grid-cell-Column2").children("div").html());
            //            //$(a.id).parent().find(".x-grid-cell-Column2").children("div").html(123456);
            //        }
            var dbclick = function (a, b, c) {

                App.direct.DB(b.raw.MPFundingAddTimes);
            }
            function getbalance() {
                var balance = parseFloat($("#treeview-1013 table .x-grid-row-selected .x-grid-cell-Column1").children("div").html()) - parseFloat($("#treeview-1013 table .x-grid-row-selected .x-grid-cell-Column3").children("div").html()); //$("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column2").children("div").replace("div", "p")
                //alert(balance);
                //$("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column2").children("div").attr("style","");
                $("#treeview-1013 table .x-grid-row-selected .x-grid-cell-Column2").children("div").html(parseFloat(balance));

            }

            function cellValFn(obj) {
                var valTmp = parseFloat(obj);
                if (isNaN(valTmp)) {
                    valTmp = 0;
                }
                return valTmp;
            }

            function Loadinit() {
                changeStyle();
                var Hidtotalapply = $("#Hidtotalapply").val();
                var total = $("#Hidtotal").val();
                //            alert(Hidtotalapply);
                //            alert(total);

                //          alert(total)
                var arr = new Array();
                var arr1 = new Array();
                if (total == "") {
                    arr = ["0", "0", "0", "0"];
                } else {
                    arr = total.split("*");
                }
                arr1 = Hidtotalapply.split("*");
                //alert($("#treeview-1013 table tr").length);
                var i = 0;
                $("#treeview-1013 table tr").each(function() {
                    //alert($(this).html());
                    //alert($(this.contains("工资福利支出")).toString()); 
                    if (!$(this).hasClass("hidstyle") && !$(this).hasClass("x-grid-header-row")) {
                        if ($(this).find('div:contains("工资福利支出")').length > 0 || $(this).find('div:contains("商品和服务支出")').length > 0 || $(this).find('div:contains("对个人和家庭补助支出")').length > 0 || $(this).find('div:contains("其他资本性支出")').length > 0) {


                            $(this).find(".x-grid-cell-Column1").children("div").html(cellValFn(arr[i]));
                            $(this).find(".x-grid-cell-Column2").children("div").html(cellValFn(arr[i]) - cellValFn(arr1[i]));
                            $(this).find(".x-grid-cell-Column3").children("div").html(cellValFn(arr1[i]));
                            ++i;
                        }
                    }
                });
            }

            function changeStyle1() {
                if ($("#gridview-1022 table tr").length > 0) {

                    $("#gridview-1022 table tr").each(function () {
                        if ($(this).find("td:first div").text() == "总计") {
                            $(this).attr("style", "color:red;font-weight:bold");
                        }
                    });
                    return;
                }
            }

            function GettatolMon() {
                if ($("#treeview-1013 table tr").length > 0) {
                    var allmon = 0.00;
                    var balancemon = 0.00;
                    var applymon = 0.00;
                    var selectid = "";
                    $("#treeview-1013 table tr").each(function() {
                        if ($(this).find(".x-grid-tree-node-leaf").length() > 0) {
                            if (!$(this).hasClass("x-grid-tree-node-expanded")) {
                                if (!isNaN(parseFloat($(this).find(".x-grid-cell-Column1").children("div").html()))) {
                                    allmon += parseFloat($(this).find(".x-grid-cell-Column1").children("div").html());
                                } else {
                                    allmon += 0;
                                }
                                if (!isNaN(parseFloat($(this).find(".x-grid-cell-Column2").children("div").html()))) {
                                    //balancemon += parseFloat($(this).find(".x-grid-cell-Column2").children("div").html());
                                    balancemon += parseFloat($(this).find(".x-grid-cell-Column1").children("div").html()) - parseFloat($(this).find(".x-grid-cell-Column3").children("div").html());
                                } else {
                                    balancemon += 0;
                                }
                                if (!isNaN(parseFloat($(this).find(".x-grid-cell-Column3").children("div").html()))) {
                                    applymon += parseFloat($(this).find(".x-grid-cell-Column3").children("div").html());
                                } else {
                                    applymon += 0;
                                }
                            }
                        }

                    });
                    $("#treeview-1013 table .x-grid-tree-node-expanded .x-grid-cell-Column1").children("div").html(parseFloat(allmon));
                    $("#treeview-1013 table .x-grid-tree-node-expanded .x-grid-cell-Column2").children("div").html(parseFloat(balancemon));
                    $("#treeview-1013 table .x-grid-tree-node-expanded .x-grid-cell-Column3").children("div").html(parseFloat(applymon));
                    //                var balance = parseFloat($("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column1").children("div").html()) - parseFloat($("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column3").children("div").html())
                    //                //$("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column2").children("div").replace("div", "p")
                    //                //alert(balance);
                    //                $("#treeview-1013 table  .x-grid-row-selected  .x-grid-cell-Column2").children("div").html(parseFloat(balance));
                }
            }

            function changeStyle() {
                if ($("#treeview-1013 table tr").length > 0) {
                    $("#treeview-1013 table tr").each(function() {
                        //                        var shtml = $(this).find("td").children("div").html();
                        //                        alert(shtml.indexOf("经济科目"))
                        //                        if (shtml.indexOf("经济科目") != -1 || shtml.indexOf("财政拨款") != -1 || shtml.html().indexOf("基本支出") != -1) {
                        //                            alert("aaaa")
                        //                            $(this).attr("style", "display: none !important;");
                        //                        }
                        if ($(this).hasClass("x-grid-tree-node-expanded")) {
                            $(this).addClass("hidstyle");
                        }
                    });
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
        <form id="form1" runat="server">
            <asp:HiddenField runat="server" ID="Hidtotal"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="Hidtotalapply"></asp:HiddenField>
            <ext:ResourceManager runat="server"></ext:ResourceManager>
            <ext:Hidden runat="server" ID="HidSlist"></ext:Hidden>
            <ext:Hidden runat="server" ID="hidflag"></ext:Hidden>
            <ext:Viewport runat="server" Layout="BorderLayout">
                <Items>
                    <ext:TreePanel Lines="false"
                                   AnchorHeight="60"
                                   ID="TPPlan"
                                   UseArrows="true"
                                   runat="server"
                                   AutoScroll="true"
                                   Animate="true"
                                   Mode="Remote"
                                   RootVisible="false"
                                   ContainerScroll="true"
                                   OnRemoteEdit="RemoteEdit" SingleExpand="True"  Region="Center"  Disabled="True" >
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server" Height="40">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Text="本月度剩余余额为："></ext:Label>
                                    <ext:Label ID="Incomebalance" runat="server" Text="" EmptyText="0"></ext:Label>
                                    <ext:ComboBox ID="cmbmon" Editable="false" runat="server" FieldLabel="选择月份" LabelWidth="60" OnDirectChange="cmbmon_DirectChange" ValueField="month" DisplayField="month">
                                        <Store>
                                            <ext:Store runat="server" ID="cmbmonstore">
                                                <Model>
                                                    <ext:Model ID="Model1" runat="server">
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
                                        <Listeners>
                                            <Collapse Handler="App.direct.GetPagedirect();"></Collapse>
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox runat="server" ID="cmbpici" FieldLabel="申请批次" LabelWidth="60">
                                        <SelectedItems>
                                            <ext:ListItem Index="0">
                                            </ext:ListItem>
                                        </SelectedItems>
                                        <Listeners>
                                            <Collapse Handler="App.direct.GetPagedirect();"></Collapse>
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:Label ID="Label3" runat="server" Text="可编辑批次1"></ext:Label>
                                    <ext:Button ID="Button1" runat="server" Text="刷新查看" OnDirectClick="Button1_DirectClick"></ext:Button>
                                    <ext:Button ID="btnsubmit" runat="server" Text="提交" OnDirectClick="btnsubmit_DirectClick"></ext:Button>
                                </Items>

                            </ext:Toolbar>
                        </TopBar>
                        <Fields>
                            <ext:ModelField Name="text" />
                            <ext:ModelField Name="CPID" Type="int" />
                            <ext:ModelField Name="PIID" Type="int" />
                            <ext:ModelField Name="PIEcoSubName" Type="string" />
                            <ext:ModelField Name="Mon" Type="float" />
                            <ext:ModelField Name="Balance" Type="float" />
                            <ext:ModelField Name="MPFunding" Type="float" />
                            <ext:ModelField Name="MPFundingAdd" Type="float" />
                            <ext:ModelField Name="MPRemark" Type="string" />
                        </Fields>
                        <ColumnModel>
                            <Columns>
                                <ext:TreeColumn Sortable="false" Align="left" Width="" ID="TreeColumn1" runat="server" DataIndex="text" Text="经济科目(元)" Flex="1">
                                </ext:TreeColumn>

                                <ext:Column ID="Column1" Sortable="false" Align="Center" runat="server" DataIndex="Mon" Text="年度预算指标(元)" Flex="1">
                                </ext:Column>
                                <ext:Column ID="Column2" Sortable="false" Align="Center" runat="server" DataIndex="Balance" Text="余额(元)" Flex="1">
                                </ext:Column>
                                <ext:Column ID="Column3" Sortable="false" Align="Center" runat="server" DataIndex="MPFunding" EmptyCellText="0" Text="当月已申请经费" Flex="1">
                                </ext:Column>
                                <ext:Column ID="Column8" Sortable="false" Align="Center" runat="server" DataIndex="MPFundingAdd" EmptyCellText="0" Text="申请经费" Flex="1">
                                    <Editor>
                                        <ext:NumberField ID="NFeditor" UI="light" runat="server">
                                            <%--                                        <Listeners><Focus Fn="GetID"></Focus></Listeners>--%>
                                            <%--                                        <Listeners><SpecialKey Handler="alert('ssss');getbalance();" Delay="3000"></SpecialKey></Listeners>--%>
                                            <Listeners>
                                                <SpecialKey Handler="getbalance();" Delay="2000"></SpecialKey>
                                            </Listeners>
                                        </ext:NumberField>
                                    </Editor>
                                </ext:Column>
                                <ext:Column ID="Column4" Sortable="false" Align="Center" runat="server" DataIndex="MPRemark" Text="备注" Flex="1">
                                    <Editor>
                                        <ext:TextArea Height="300" runat="server"></ext:TextArea>
                                    </Editor>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <Plugins>
                            <ext:CellEditing ID="CellEditing1" runat="server" />
                        </Plugins>
                        <Listeners>
                            <BeforeLoad Fn="nodeLoad" />
                            <Load Handler="changeStyle();"></Load>
                            <CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" />

                            <Render Handler="#{TPPayIncome}.getRootNode().expand(true);" Delay="50" />
                            <%--                        <Render Handler="App.direct.GetPIETotalBind();"  ></Render>--%>
                            <AfterRender Handler="Loadinit(); App.direct.GetTPPlan();App.direct.TextBind();" Delay="5000"></AfterRender>
                            <%--                        <BeforeItemMouseLeave Fn="mouseleave"></BeforeItemMouseLeave>--%>
                        </Listeners>
                        <BottomBar>
                            <ext:Toolbar runat="server" Layout="ColumnLayout">
                                <Items>
                                    <ext:TextField runat="server" ID="lbtotal1" ReadOnly="true" Text="　　总计" FieldStyle="color:red; " ColumnWidth="0.1666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="lbtotal2" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.16666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="lbtotal3" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.16666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="lbtotal4" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.16666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="lbtotal5" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.16666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="lbtotal6" ReadOnly="true" Text="" FieldStyle="color:red;text-align:center;" ColumnWidth="0.16666667" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:TreePanel>

                    <%--                <ext:GridPanel runat="server" ID="GTPHis" Title="添加月度用款历史记录" Region="South" Height="240" AutoScroll="True" Border="false" Layout="fit">--%>
                    <%--                    <Store>--%>
                    <%--                        <ext:Store runat="server" ID="GTPHisStore" PageSize="15">--%>
                    <%--                            <Model>--%>
                    <%--                                <ext:Model ID="Model2" runat="server">--%>
                    <%--                                    <Fields>--%>
                    <%--                                        <ext:ModelField Name="ParentPIEcoSubName"></ext:ModelField>--%>
                    <%--                                        <ext:ModelField Name="PIEcoSubName"></ext:ModelField>--%>
                    <%--                                        <ext:ModelField Name="MPFundingAdd1" Type="Float"></ext:ModelField>--%>
                    <%--                                        <ext:ModelField Name="MPRemark"></ext:ModelField>--%>
                    <%--                                        <ext:ModelField Name="MPPHisTime" Type="String" />--%>
                    <%--                                    </Fields>--%>
                    <%--                                </ext:Model>--%>
                    <%--                            </Model> --%>
                    <%--                            <Listeners><Load Handler="changeStyle1();" Delay="2000"></Load></Listeners>--%>
                    <%--                        </ext:Store> --%>
                    <%--                    </Store>--%>
                    <%--                    <ColumnModel>--%>
                    <%--                        <Columns>--%>
                    <%--                            <ext:RowNumbererColumn runat="server" />--%>
                    <%--                            <ext:Column ID="Column5" Align="Center" runat="server" Flex="1" Text="一级科目" DataIndex="ParentPIEcoSubName"></ext:Column>--%>
                    <%--                            <ext:Column ID="Column6" Align="Center" runat="server" Flex="1" Text="科目名称" DataIndex="PIEcoSubName"></ext:Column>--%>
                    <%--                            <ext:Column ID="Column7" Align="Center" runat="server" Flex="1" Text="申请金额（元）" DataIndex="MPFundingAdd1"></ext:Column>--%>
                    <%--                            <ext:DateColumn ID="Column10" Align="Center" runat="server" Flex="1" Text="填写日期" DataIndex="MPPHisTime" Format="yyyy-MM-dd"></ext:DateColumn>--%>
                    <%--                            <ext:Column ID="Column9" Align="Center" runat="server" Flex="1" Text="备注" DataIndex="MPRemark"></ext:Column>--%>
                    <%--                        </Columns>--%>
                    <%--                    </ColumnModel>--%>
                    <%--$1$                    <Listeners>#1#--%>
                    <%--$1$                        <AfterRender Handler="changeStyle1();" Delay="2000"></AfterRender>#1#--%>
                    <%--$1$                    </Listeners>#1#--%>
                    <%--                </ext:GridPanel>--%>
                
                    <ext:GridPanel runat="server" ID="GTPHis" Title="添加月度用款历史记录" Region="South" Height="240" AutoScroll="True" Border="false" Layout="fit">
                    <Store>
                        <ext:Store runat="server" ID="GTPHisStore" PageSize="15">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="MPFundingAddTimes"></ext:ModelField>
                                        <ext:ModelField Name="weitijiao" Type="Float"></ext:ModelField>
                                        <ext:ModelField Name="tijiao" Type="Float"></ext:ModelField>
                                        <ext:ModelField Name="shenhetongguo" Type="Float"></ext:ModelField>
                                        <ext:ModelField Name="tuihui" Type="Float" />
                                        <ext:ModelField Name="shenhebutongguo" Type="Float" />  <ext:ModelField Name="MPFunding" Type="Float" /> <ext:ModelField Name="MPTime" Type="Date" /> 
                                    </Fields>
                                </ext:Model>
                            </Model> 
                            <Listeners><Load Handler="changeStyle1();" Delay="2000"></Load></Listeners>
                        </ext:Store> 
                    </Store>
                    <ColumnModel  runat="server">
                        <Columns>
                             <ext:Column  Align="Center" runat="server" Flex="1" Text="批次" DataIndex="MPFundingAddTimes"></ext:Column>
                             <ext:RatingColumn   runat="server" Header="提交" DataIndex="weitijiao" Flex="1" Text="提交" /> 
                             <ext:RatingColumn  runat="server" Header="待审核" DataIndex="tijiao"  Flex="1" Text="待审核"/> 
                             <ext:RatingColumn  runat="server" Header="审核通过" DataIndex="shenhetongguo"  Flex="1" Text="审核通过"/> 
                             <ext:RatingColumn  runat="server" Header="退回" DataIndex="tuihui"  Flex="1" Text="退回"/> 
                             <ext:RatingColumn  runat="server" Header="审核不通过" DataIndex="shenhebutongguo"  Flex="1" Text="审核不通过"/> 
                             <ext:Column ID="Column5"  Align="Center" runat="server" Flex="1" Text="金额" DataIndex="MPFunding"  ></ext:Column>
                            <ext:DateColumn ID="Column10" Align="Center" runat="server" Flex="1" Text="填写日期" DataIndex="MPTime" Format="yyyy-MM-dd"></ext:DateColumn>
                        </Columns></ColumnModel> <Listeners><ItemDblClick  Fn="dbclick"></ItemDblClick></Listeners>
                           <BottomBar>
                            <ext:Toolbar ID="Toolbar2" runat="server" Layout="ColumnLayout">
                                <Items>
                                    <ext:TextField runat="server" ID="TF1" ReadOnly="true" Text="　　总计" FieldStyle="color:red; " ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF2" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF3" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF4" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF5" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF6" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                     <ext:TextField runat="server" ID="TF7" ReadOnly="true" Text="0" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                    <ext:TextField runat="server" ID="TF8" ReadOnly="true" Text="" FieldStyle="color:red;text-align:center;" ColumnWidth="0.125" MarginSpec="0" PaddingSpec="0"></ext:TextField>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:Viewport>
        </form>
    </body>
</html>