<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetEditAddPage.aspx.cs" Inherits="WebPage_BudgetEdit_BudgetEditAddPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算编辑添加</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="css/mytable.js" type="text/javascript"></script>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 180px;
        }

        .txtJs {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 92%;
        }
    </style>

    <script type="text/javascript">

        //添加行的辅助方法
        function fnComAddNew(htstr) {
            var target = document.getElementById('divReBook');
            var node = document.createElement('div');
            node.innerHTML = htstr;
            target.appendChild(node);
        }

        //添加行的方法
        function fnAddNew(obj) {
            $("#btnDel").attr("style", "");
            var target = document.getElementById('divReBook');
            var node = document.createElement('div');
            node.innerHTML = $("#ext").html();
            var rc = parseInt($("#HidRowCount").val());
            rc += 1;
            $("#HidRowCount").val(rc);
            target.appendChild(node);
            $("#divReBook div:last").find("input[type = text]").each(function () {
                var idTmp = $(this).attr("id");
                if (idTmp == "txt1") {
                    $(this).val(rc);
                }
                if (idTmp == "txt4" || idTmp == "txt5" || idTmp == "txt6" || idTmp == "txt7" || idTmp == "txt8") {
                    $(this).val("0");
                }
            });
        }

        //删除行的方法
        function removeMe(obj) {
            var e = obj;
            while (e.nodeName != 'DIV') { e = e.parentNode; }
            if ($(e).attr("id") != "ext") {
                var rc = parseInt($("#HidRowCount").val());
                rc -= 1;
                $("#HidRowCount").val(rc);
                e.parentNode.removeChild(e);
                RowTotal();
                if (rc==1) {
                    $("#btnDel").attr("style", "display:none");
                }
            }
            else {
                alert("该行不允许删除！"); 
            }
        }
        //文本框非空验证的方法
        function txtCheck() {
            var flag = true;
            $("#divReBook").find("input[type=text]").each(function () {
                if ($(this).val() == "") {
                    $("#lblShowResult").text("*经济科目费用表必须填写，且每个内容都是必填项");
                    flag = false;
                }
            });
            return flag;
        }
        //数值统计的方法
        function MonSumFn(obj) {
            while (obj.nodeName != 'DIV') {
                obj = obj.parentNode;
            }
            var txt7 = $(obj).find("input[name='txt7']").val();
            var txt8 = $(obj).find("input[name='txt8']").val();
            var inexp = parseInt(txt7);
            if (isNaN(inexp)) {
                inexp = 0;
            }
            var outfund = parseInt(txt8);
            if (isNaN(outfund)) {
                outfund = 0;
            }
            var MonSum = inexp + outfund;
            $(obj).find("input[name='txt4']").val(MonSum);
            $(obj).find("input[name='txt5']").val(MonSum);
            $(obj).find("input[name='txt6']").val(MonSum);

            RowTotal();
        }

        function RowTotal() {
            $("#TotalRow").show();
            columnTotal("txt4");
            columnTotal("txt5");
            columnTotal("txt6");
            columnTotal("txt7");
            columnTotal("txt8");
        }

        function columnTotal(id) {
            var sumVal = 0;
            $("#divReBook input[name='" + id + "']").each(function () {
                var txtVal = parseInt($(this).val());
                if (isNaN(txtVal)) {
                    txtVal = 0;
                }
                sumVal += txtVal;
            });
            var Assigtxt = id + "Total";
            $("#" + Assigtxt).val(sumVal);
            if (id == "txt4") {
                $("#HidMonTotal").val(sumVal);
            }
        }

        $(function () {
            $("#btnSure").click(function () {
                return txtCheck();
            });
            $("#ddlPayProType").change(function () {
                $("#HidPPID").val($("#ddlPayProType").val());
            });
        });

    </script>

    <script type="text/javascript">


        var gridCommand = function (sender, command, record) {
            if (command == "Publish") {
                Ext.Msg.confirm("提示", "确定发布？", function (btn) {
                    if (btn == "yes") {
                        App.direct.PublishPolicy(record.data.PLID);
                    }
                })
            }
            if (command == "Modify") {
                App.direct.ModifyPolicy(record.data.BudItID);
            }
            if (command == "Delete") {
                Ext.Msg.confirm("提示", "确定删除？", function (btn) {
                    if (btn == "yes") {
                        App.direct.DelPolicy(record.data.PLID);
                    }
                })

            }
        }
        var select = function (sender, command, record) {

            if (sender.value == 1) {

                App.direct.GetSelect1();
            }
            if (sender.value == 2) {

                App.direct.GetSelect2();
            }
            if (sender.value == 3) {

                App.direct.GetSelect3();
            }
            if (sender.value == 4) {

                App.direct.GetSelect4();
            }

        }
        $(function () { 
           $("#btnDel").attr("style", "display:none;");  
        })
      
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr>
                    <td colspan="4" class="tr1">&nbsp;<strong>年初预算编写</strong>
                        <asp:HiddenField ID="HidDepid" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目类别：
                    </td>
                    <td>&nbsp;&nbsp;
                   <asp:DropDownList ID="ddlProType" CssClass="txt" runat="server">
                       <asp:ListItem Selected="True">一般项目</asp:ListItem>
                       <asp:ListItem>一般项目</asp:ListItem>
                       <asp:ListItem>不可预见费项目</asp:ListItem>
                       <asp:ListItem>科技研究与开发项目</asp:ListItem>
                       <asp:ListItem>公费医疗项目</asp:ListItem>
                   </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">功能科目：

                    </td>
                    <td width="35%">&nbsp;&nbsp;
                  <asp:DropDownList ID="ddlFunSub" CssClass="txt" runat="server">
                      <asp:ListItem Value="一般行政管理事务(税收)" Selected="True">一般行政管理事务(税收)</asp:ListItem>
                      <asp:ListItem Value="税务办案">税务办案</asp:ListItem>
                      <asp:ListItem Value="代扣代收代征税款手续费">代扣代收代征税款手续费</asp:ListItem>
                      <asp:ListItem Value="税务宣传">税务宣传</asp:ListItem>
                      <asp:ListItem Value="协税护税">协税护税</asp:ListItem>
                      <asp:ListItem Value="信息化建设(税收)">信息化建设(税收)</asp:ListItem>
                      <asp:ListItem Value="其它税收事务支出">其它税收事务支出</asp:ListItem>
                  </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目编号：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtItemNumber" CssClass="txt" runat="server" ValidationGroup="AddBI" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItemNumber" Display="Dynamic" ErrorMessage="项目编号不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">项目名称：
                    
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtProName" runat="server" CssClass="txt" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProName" Display="Dynamic" ErrorMessage="项目名称不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">行政成本类别：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlAdmCostCate" CssClass="txt" runat="server">
                            <asp:ListItem Selected="True">行政单位一般行政管理项目支出</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">项目安排频度：
                     
                    </td>
                    <td>&nbsp;&nbsp;
                       <asp:DropDownList ID="ddlBIPlanHz" CssClass="txt" runat="server">
                           <asp:ListItem Selected="True" Value="常年性项目">常年性项目</asp:ListItem>
                           <asp:ListItem Value="延续性项目"> 续性项目</asp:ListItem>
                           <asp:ListItem Value="一次性项目">一次性项目</asp:ListItem>
                       </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目起始时间：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIStaTime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'txtBIEndTime\')}'})" CssClass="txt" runat="server" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtBIStaTime" Display="Dynamic" ErrorMessage="项目起始时间不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">项目终止时间：
                        
                    </td>
                    <td>&nbsp;&nbsp;
                 <asp:TextBox ID="txtBIEndTime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'txtBIStaTime\')}',maxDate:'2020-01-01'})" runat="server" CssClass="txt" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtBIEndTime" Display="Dynamic" ErrorMessage="项目终止时间不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目负责人：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBICharger" CssClass="txt" runat="server" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBICharger" Display="Dynamic" ErrorMessage="项目负责人不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">项目属性：

                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlProProper" CssClass="txt" runat="server">
                            <asp:ListItem Selected="True">持续性项目</asp:ListItem>
                            <asp:ListItem>当年项目</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目类型：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlPayProType" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPayProType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">预算控制数：

                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBudConNumber" CssClass="txt" runat="server" CausesValidation="false" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目报进日期：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBITime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" CssClass="txt" runat="server" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBITime" Display="Dynamic" ErrorMessage="项目报进日期不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">预算年度:</td>
                    <td width="35%">&nbsp;&nbsp;
                          <asp:TextBox ID="txtyear" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})" CssClass="txt" runat="server"   ValidationGroup="AddBI"  ></asp:TextBox><span style="color: red">*</span>  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtyear" Display="Dynamic" ErrorMessage="预算年度不能为空"  ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator><asp:Button ID="btnSure1" runat="server" Text="项目库" OnClick="btnSure1_Click" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目简介：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtProDesc" runat="server" CssClass="txt" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProDesc" Display="Dynamic" ErrorMessage="项目简介不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目申请理由和主要内容：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIAppReaCon" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBIAppReaCon" Display="Dynamic" ErrorMessage="项目申请理由不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目支出测算依据及说明：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIExpGistExp" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBIExpGistExp" Display="Dynamic" ErrorMessage="项目支出测算依据及说明不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效长期目标：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBILongGoal" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBILongGoal" Display="Dynamic" ErrorMessage="项目绩效长期目标不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效年度目标：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIYearGoal" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBIYearGoal" Display="Dynamic" ErrorMessage="项目绩效年度目标不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">其他说明的问题：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIOthExpProb" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBIOthExpProb" Display="Dynamic" ErrorMessage="其他说明问题不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>


            <table id="BudCostProTb" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr>
                    <td width="11%" rowspan="3" class="tr1" align="center">行号</td>
                    <td width="11%" rowspan="3" class="tr1" align="center">当前年度</td>
                    <td width="11%" rowspan="3" class="tr1" align="center">经济科目</td>
                    <td width="11%" rowspan="3" class="tr1" align="center">总计</td>
                    <td width="44%" colspan="4" class="tr1" align="center"></td>
                    <td width="11%" rowspan="3" class="tr1" align="center">行操作</td>
                </tr>
                <tr>
                    <td rowspan="2" class="tr1" align="center">小计(财政拨款)</td>
                    <td colspan="3" class="tr1" align="center">经济拨款（补助）</td>
                </tr>
                <tr class="tr1 right">
                    <td class="tr1" align="center">小计(经费)</td>
                    <td class="tr1" align="center">内部开支(经费)</td>
                    <td class="tr1" align="center">外部拨款(经费)</td>
                </tr>
                <tr>
                    <td colspan="9" style="border: 0px;">
                        <div id="divReBook" style="border: 0px; margin-left: -12px;">
                            <div id="ext">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td width="11%">
                                            <asp:TextBox ID="txt1" CssClass="txtJs" name="txt1" Text="1" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>

                                        <td width="11%">
                                            <asp:TextBox ID="txt2" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})" CssClass="txtJs" name="txt2" runat="server"></asp:TextBox>
                                        </td>
                                        <td width="11%">
                                            <asp:DropDownList ID="ddlIncome" CssClass="txtJs" name="txt3" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="11%">
                                            <asp:TextBox ID="txt4" CssClass="txtJs" name="txt4" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td width="11%">
                                            <asp:TextBox ID="txt5" CssClass="txtJs" name="txt5" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td width="11%">
                                            <asp:TextBox ID="txt6" CssClass="txtJs" name="txt6" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td width="11%">
                                            <asp:TextBox ID="txt7" CssClass="txtJs" name="txt7" Text="0" onkeyup="MonSumFn(this);" runat="server"></asp:TextBox>
                                        </td>
                                        <td width="11%">
                                            <asp:TextBox ID="txt8" CssClass="txtJs" name="txt8" Text="0" onkeyup="MonSumFn(this);" runat="server"></asp:TextBox>
                                        </td>
                                        <td width="11%" align="center">
                                            <input id="btnDel" type="button" value="删除" onclick="removeMe(this)" class="btns" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr id="TotalRow" style="display: none;">
                    <td class="tr1" width="33%" colspan="3" align="center">&nbsp;&nbsp; <strong>项目金额合计栏</strong>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt4Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt5Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt6Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt7Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt8Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%" align="center"></td>
                </tr>
                <tr>
                    <td class="tr1" colspan="9" align="center">
                        <input id="btnAddRows" type="button" value="+添加行" onclick="fnAddNew();" class="btns" />
                        <asp:Button ID="btnSure" runat="server" Text=" 确  定 " CssClass="btns" ValidationGroup="AddBI" OnClick="btnSure_Click" />
                        <asp:Button ID="btnPostBack" CssClass="btns" OnClientClick="return confirm('你将返回上一级,未提交信息会丢失,是否确认？')" runat="server" Text=" 返  回 " OnClick="btnPostBack_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="HidRowCount" Value="1" runat="server" />
                        <asp:HiddenField ID="HidPPID" runat="server" />
                        <asp:HiddenField ID="HidMonTotal" Value="0" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <ext:ResourceManager runat="server" />
        <ext:Window ID="WinAdd" runat="server"
            Title="商品和劳务支出"
            Width="600"
            Height="358"
            Icon="UserAdd"
            Hidden="true">
            <Items>
                 <ext:Container runat="server" ID="ctl">
                    <Items>
                        <ext:Label runat="server" ID="lb1" Text="选择类型"></ext:Label>
                    </Items>
                </ext:Container> 
                <ext:Container ID="Container1" runat="server" Layout="ColumnLayout" PaddingSpec="8 0 0 0">
                    <Items>
                        <ext:ComboBox runat="server" ID="cb1" Width="120" LabelWidth="50" QueryMode="Local" TypeAhead="true">
                            <Items> 
                                <ext:ListItem Text="部门" Value="1"></ext:ListItem>
                                <ext:ListItem Text="项目类型" Value="2"></ext:ListItem>
                                <ext:ListItem Text="经济科目" Value="3"></ext:ListItem> 
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Index="0">
                                </ext:ListItem>
                            </SelectedItems>
                            <Listeners>
                                <Select Fn="select"></Select>
                            </Listeners>
                        </ext:ComboBox>

                        <ext:ComboBox runat="server" ID="cb2" Width="120" DisplayField="DepName"
                            ValueField="DepID" LabelWidth="50" QueryMode="Local" TypeAhead="true" PaddingSpec="0 0 0 15" Hidden="true">
                            <SelectedItems>
                                <ext:ListItem Index="0">
                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>
                        <%--<ext:ComboBox runat="server" ID="StrPz" Width="120" DisplayField="PayPrjName"
                            ValueField="PPID" LabelWidth="50" QueryMode="Local" TypeAhead="true" PaddingSpec="0 0 0 15" Hidden="true">
                            <SelectedItems>
                                <ext:ListItem Index="0">
                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox>--%>
                         <ext:ComboBox runat="server" ID="cb3" Width="120"  
                            LabelWidth="50" QueryMode="Local" TypeAhead="true" PaddingSpec="0 0 0 15" Hidden="true">
                                    <Items>
                                        <ext:ListItem Text="常年性项目"></ext:ListItem>
                                        <ext:ListItem Text="续性项目"></ext:ListItem>
                                        <ext:ListItem Text="一次性项目"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox> 
                        <ext:ComboBox runat="server" ID="cb4" Width="120" DisplayField="PIEcoSubName"
                            ValueField="PIID" LabelWidth="50" QueryMode="Local" TypeAhead="true" PaddingSpec="0 0 0 15" Hidden="true">
                            <SelectedItems>
                                <ext:ListItem Index="0">
                                </ext:ListItem>
                            </SelectedItems>
                        </ext:ComboBox> 
                        <ext:Button runat="server" ID="Button1" Width="60" Text="查 看" Hidden="true" OnDirectClick="Button1_DirectClick"></ext:Button>
                   </Items>
                </ext:Container>
                <ext:GridPanel  ColumnLines="true" ID="gridpanel1" runat="server"  PaddingSpec="15 0 0 0">
                    <Store>
                        <ext:Store ID="stBudget" runat="server" PageSize="9">
                            <%--OnReadData="MyData_Refresh"--%>
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="BudItID" Type="int" />
                                        <ext:ModelField Name="DepName" Type="string" />
                                        <ext:ModelField Name="BILProName" Type="string" />
                                        <ext:ModelField Name="BILProType" Type="string" />
                                        <ext:ModelField Name="BILMon" Type="string" />
                                        <ext:ModelField Name="BILAppReaCon" Type="string" />
                                        <ext:ModelField Name="BILExpGistExp" Type="string" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column Sortable="true" ID="Column1" runat="server" Text="编号" Flex="1" DataIndex="BudItID" />
                            <ext:Column Sortable="true" ID="Column2" runat="server" Text="部门" Flex="1" DataIndex="DepName" />
                            <ext:Column Sortable="true" ID="Column3" runat="server" Text="项目名称" Flex="1" DataIndex="BILProName" />
                            <ext:Column Sortable="true" ID="Column5" runat="server" Text="项目类型" Flex="1" DataIndex="BILProType" />
                            <ext:Column Sortable="true" ID="Column6" runat="server" Text="金额" Flex="1" DataIndex="BILMon" />
                            <ext:Column Sortable="true" ID="Column7" runat="server" Text="申请理由" Flex="1" DataIndex="BILAppReaCon" />
                            <ext:Column Sortable="true" ID="Column9" runat="server" Text="申请依据" Flex="1" DataIndex="BILExpGistExp" />
                            <ext:CommandColumn ID="CommandColumn3" runat="server" Header="查看" Flex="1" DataIndex="">
                                <Commands>
                                    <ext:GridCommand Icon="TableEdit" CommandName="Modify" Text="查看" />
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

        </ext:Window>
        <ext:Window ID="Window1" runat="server"
            Title="商品和劳务支出"
            Width="600"
            Height="520"
            Icon="UserAdd"
            Hidden="true">
            <Items>
                <ext:Hidden ID="BudItID" runat="server"></ext:Hidden>
                <ext:Panel
                    ID="GridPanel2"
                    runat="server"
                    Title="导入财政数据"
                    Icon="ApplicationViewColumns" Border="false">
                </ext:Panel>
                <ext:Toolbar ID="Toolbar3" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar2" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2407"></ext:ToolbarFill>
                                <ext:Label ID="Label1" runat="server" Text="项目类别："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel1" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="cmbProProper"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="一般性项目"></ext:ListItem>
                                        <ext:ListItem Text="不可预见费项目"></ext:ListItem>
                                        <ext:ListItem Text="科技研究与开发项目"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>

                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar5" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2413"></ext:ToolbarFill>
                                <ext:Label ID="Label3" runat="server" Text="功能科目："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel2" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="cmbFunSub"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="一般行政管理事务(税收)"></ext:ListItem>
                                        <ext:ListItem Text="代扣代收代征税款手续费"></ext:ListItem>
                                        <ext:ListItem Text="税务宣传"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>

                <ext:Toolbar ID="Toolbar1" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <%--                        <ext:Toolbar ID="Toolbar4" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2420"></ext:ToolbarFill>
                                <ext:Label ID="Label2" runat="server" Text="项目编号："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel3" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFBICode" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>--%>
                        <ext:Toolbar ID="Toolbar15" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2465"></ext:ToolbarFill>
                                <ext:Label ID="Label10" runat="server" Text="项目属性："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel10" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="cmbBIProType"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="持续性项目"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar6" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2426"></ext:ToolbarFill>
                                <ext:Label ID="Label4" runat="server" Text="项目名称："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel4" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFProName" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>
                <ext:Toolbar ID="Toolbar7" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar8" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2433"></ext:ToolbarFill>
                                <ext:Label ID="Label5" runat="server" Text="行政成本类别："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel5" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="cmbAdmCostCate"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="行政单位一般行政管理项目支出"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar9" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2439"></ext:ToolbarFill>
                                <ext:Label ID="Label6" runat="server" Text="项目安排频度："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel6" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="TFBIPlanHz"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="常年性项目"></ext:ListItem>
                                        <ext:ListItem Text="续性项目"></ext:ListItem>
                                        <ext:ListItem Text="一次性项目"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>
                <%--<ext:Toolbar ID="Toolbar10" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar11" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2446"></ext:ToolbarFill>
                                <ext:Label ID="Label7" runat="server" Text="项目起始时间："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel7" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFStartTime" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar12" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2452"></ext:ToolbarFill>
                                <ext:Label ID="Label8" runat="server" Text="项目终止时间："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel8" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFEndTime" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>--%>
                <%--<ext:Toolbar ID="Toolbar13" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar14" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2459"></ext:ToolbarFill>
                                <ext:Label ID="Label9" runat="server" Text="项目负责人："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel9" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFBICharger" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar15" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2465"></ext:ToolbarFill>
                                <ext:Label ID="Label10" runat="server" Text="项目属性："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel10" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:ComboBox ID="cmbBIProType"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    QueryMode="Local"
                                    TypeAhead="true" PaddingSpec="5 0 0 15">
                                    <Items>
                                        <ext:ListItem Text="持续性项目"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>--%>
                <ext:Toolbar ID="Toolbar16" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar17" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2472"></ext:ToolbarFill>
                                <ext:Label ID="Label11" runat="server" Text="项目类型："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel11" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <%--<ext:ComboBox ID="cmbPayProType"
                                    runat="server"
                                    Width="160"
                                    LabelWidth="50"
                                    PaddingSpec="5 0 0 15" DisplayField="PayPrjName">
                                    <Store>
                                        <ext:Store runat="server" ID="StorePayProType" OnDataBinding="">
                                            <Model>
                                                <ext:Model runat="server" Name="PPID"></ext:Model>
                                                <ext:Model runat="server" Name="PayPrjName"></ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>--%>
                                <ext:ComboBox MinWidth="60" ID="cmbPayProType" runat="server" ValueField="PPID" Width="160"
                                    LabelWidth="50"
                                    PaddingSpec="5 0 0 15" DisplayField="PayPrjName">
                                    <Store>
                                        <ext:Store ID="StorePayProType" runat="server" >
                                            <Model>
                                                <ext:Model ID="Model3" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PPID"></ext:ModelField>
                                                        <ext:ModelField Name="PayPrjName"></ext:ModelField>
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <SelectedItems>
                                        <ext:ListItem Index="0"></ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar18" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2478"></ext:ToolbarFill>
                                <ext:Label ID="Label12" runat="server" Text="预算控制数："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel12" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFConNum" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>
                <%-- <ext:Toolbar ID="Toolbar19" runat="server" Height="35" Border="false" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar20" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2485"></ext:ToolbarFill>
                                <ext:Label ID="Label13" runat="server" Text="项目报进日期："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel13" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TextField8" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar21" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2491"></ext:ToolbarFill>
                                <ext:Label ID="Label14" runat="server"></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel14" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>--%>
                <%-- <ext:Toolbar ID="Toolbar19" runat="server" Height="35" Border="false" BaseCls="backround:transparent" BorderSpec="0 1 1 0" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar20" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill1"></ext:ToolbarFill>
                                <ext:Label ID="Label13" runat="server" Text="项目报进日期："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel13" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TFReportTime" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>
                        <ext:Toolbar ID="Toolbar21" runat="server" Height="35" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill2"></ext:ToolbarFill>
                                <ext:Label ID="Label14" runat="server" Text=""></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel14" runat="server" ColumnWidth="0.3" Height="35">
                            <Items>
                                <ext:TextField ID="TextField2" runat="server" PaddingSpec="5 0 0 15" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>--%>

                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar22" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar23" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ctl2497"></ext:ToolbarFill>
                                <ext:Label ID="Label15" runat="server" Text="项目简介："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel15" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBIProDescrip" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar24" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar25" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill3"></ext:ToolbarFill>
                                <ext:Label ID="Label16" runat="server" Text="项目申请理由和主要内容："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel16" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBILAppReaCon" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar26" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar27" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill4"></ext:ToolbarFill>
                                <ext:Label ID="Label17" runat="server" Text="项目支出测算依据及说明："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel17" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBILExpGistExp" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar28" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar29" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill5"></ext:ToolbarFill>
                                <ext:Label ID="Label18" runat="server" Text="项目绩效长期目标："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel18" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBILLongGoal" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>
                <ext:Hidden runat="server" ID="decodeuse"></ext:Hidden>
                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar30" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar31" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill6"></ext:ToolbarFill>
                                <ext:Label ID="Label19" runat="server" Text="项目绩效年度目标："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel19" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBILYearGoal" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>

                <ext:Toolbar BaseCls="backround:transparent" ID="Toolbar32" runat="server" Height="50" Layout="ColumnLayout">
                    <Items>
                        <ext:Toolbar ID="Toolbar33" runat="server" Height="50" Border="false" ColumnWidth="0.2" BorderSpec="0 0 1 0">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill7"></ext:ToolbarFill>
                                <ext:Label ID="Label20" runat="server" Text="其他说明的问题："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <%--<ext:TextArea runat="server" ID="TFBIProDescrip" ColumnWidth="0.8" Height="50"></ext:TextArea>--%>
                        <ext:Panel ID="Panel20" runat="server" ColumnWidth="0.8" Height="50" PaddingSpec="0 0 0 0">
                            <Items>
                                <ext:TextArea runat="server" ID="TFBILOthExpProb" Height="50" Width="478" Border="false"></ext:TextArea>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>
            </Items>
            <BottomBar>
                <ext:Toolbar runat="server" Dock="Bottom">
                    <Items>
                        <ext:Panel runat="server"   Border="false" ButtonAlign="Right">
                           
                            <Content>  
                                <asp:Button ID="btnuse"  Width="100px" Height="30px" style="margin-left:480px ; " runat="server" Text="使用" OnClick="btnuse_Click" />
                            </Content>
                            <%-- <ext:Button ID="btnuse" runat="server" Text="使用" OnDirectClick="btnuse_DirectClick"></ext:Button>--%>
                        </ext:Panel>

                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Window>
    </form>
</body>
</html>
