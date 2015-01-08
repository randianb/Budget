<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetEditAlter.aspx.cs" Inherits="mainPages_BudgetEditAlter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预算编辑修改</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="css/mytable.js" type="text/javascript"></script>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }

        .txt
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 180px;
        }

        .txtJs
        {
            border: solid 1px #A3C8F5;
            vertical-align: middle;
            width: 92%;
        }
    </style>

    <script type="text/javascript">

        function totalBIMon() {
            var total = 0;
            $("input[name='txt4']").each(function () {
                var selfVal = parseInt($(this).val());
                if (isNaN(selfVal)) {
                    selfVal = 0;
                }
                total += selfVal;
            });
            $("#txtBIMon").val(total);
        }

        //添加行的辅助方法
        function fnComAddNew(htstr) {
            var target = document.getElementById('divReBook');
            var node = document.createElement('div');
            node.innerHTML = htstr;
            target.appendChild(node);
        }
        //添加行的方法
        function fnAddNew(obj) {
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
            }
            else {
                alert("该行不允许删除！");
            }
        }
        //获取选中下拉列表的值方法
        function getSelect() {
            var idStrs = "";
            $("#divReBook select").each(function () {
                idStrs += $(this).find("option:selected").val() + ",";
            });
            $("#HidSelectVal").val(idStrs);
        }
        //文本框有非空验证
        function txtCheck() {
            getSelect();
            var flag = true;
            $("#divReBook").find("input[type=text]").each(function () {
                if ($(this).val() == "") {
                    $("#lblShowResult").text("*经济科目费用表必须填写，且每个内容都是必填项");
                    flag = false;
                }
            });
            return flag;
        }

        //数值统计的总方法
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
        //多列统计方法汇总
        function RowTotal() {
            $("#TotalRow").show();
            columnTotal("txt4");
            columnTotal("txt5");
            columnTotal("txt6");
            columnTotal("txt7");
            columnTotal("txt8");
        }
        //单列统计方法
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
                var bcn = parseInt($("#txtBudConNumber").val());
                if(isNaN(bcn)){
                    bcn=0;
                }
                if (bcn != 0){
                    if (sumVal > bcn) {
                        $("#lblTip").text("*预算金额超标！");
                        $("#btnUpd").attr("disabled", true);
                    }
                    else {
                        $("#lblTip").text("");
                        $("#btnUpd").attr("disabled", false);
                    }
                }
                
            }
        }


        $(function () {
            $("#divReBook div:first").attr("id", "ext");
            $("#btnUpd").click(function () {
                return txtCheck();
            });
            RowTotal();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr>
                    <td colspan="4" class="tr1">&nbsp;<strong>年初预算编写</strong>
                        <asp:HiddenField ID="Hidbuid" runat="server" />
                        <asp:HiddenField ID="Hiddepid" runat="server" />
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
                           <asp:ListItem Value="延续性项目">延续性项目</asp:ListItem>
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
                        <asp:TextBox ID="txtBudConNumber" CssClass="txt" runat="server" CausesValidation="false" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目报进日期：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBITime" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" CssClass="txt" runat="server" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBITime" Display="Dynamic" ErrorMessage="项目报进日期不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">预算金额：
                    </td>
                    <td width="35%">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIMon" CssClass="txt" runat="server" CausesValidation="false" ReadOnly="true"></asp:TextBox>
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
                <tr>
                    <td width="15%" class="tr1 right">
                        <span style="color: red">退回原因：</span>
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBackReason" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
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
                            <asp:Repeater ID="repPayProject" runat="server" OnItemDataBound="repPayProject_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td width="11%">
                                                    <input name="txt1" type="text" id="txt1" value='<%# Eval("CostID") %>' class="txtJs"  readonly="readonly">
                                                </td>
                                                <td width="11%">
                                                    <input name="txt2" type="text" id="txt2" class="txtJs" value='<%# Eval("BCPCurrYear") %>' onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})">
                                                </td>
                                                <td width="11%">
                                                    <asp:HiddenField ID="HidPIID" Value='<%# Eval("PIID") %>' runat="server" />
                                                    <asp:DropDownList ID="ddlIncome" CssClass="txtJs" name="txt3" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="11%">
                                                    <input name="txt4" type="text" id="txt4" onkeyup="totalBIMon();" value='<%# Eval("BCPTotal") %>'  readonly="readonly" class="txtJs">
                                                </td>
                                                <td width="11%">
                                                    <input name="txt5" type="text" id="txt5" value='<%# Eval("BCPSubtFinAllo") %>'  readonly="readonly" class="txtJs">
                                                </td>
                                                <td width="11%">
                                                    <input name="txt6" type="text" id="txt6" value='<%# Eval("BCPSubtExp") %>'  readonly="readonly" class="txtJs">
                                                </td>
                                                <td width="11%">
                                                    <input name="txt7" type="text" id="txt7" onkeyup="MonSumFn(this);" value='<%# Eval("BCInExpenses") %>' class="txtJs">
                                                </td>
                                                <td width="11%">
                                                    <input name="txt8" type="text" id="txt8" onkeyup="MonSumFn(this);" value='<%# Eval("BCOutFunding") %>' class="txtJs">
                                                </td>
                                                <td width="11%" align="center">
                                                    <input id="btnDel" type="button" value="删除" onclick="removeMe(this)" class="btns" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr id="TotalRow">
                    <td class="tr1" width="33%" colspan="3" align="center">
                       &nbsp;&nbsp; <strong>项目金额合计栏</strong>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt4Total" CssClass="txtJs" runat="server" Text="0"  ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt5Total" CssClass="txtJs" runat="server" Text="0"  ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt6Total" CssClass="txtJs" runat="server"  Text="0"  ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt7Total" CssClass="txtJs" runat="server" Text="0"  ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%">
                        <asp:TextBox ID="txt8Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="11%" align="center">
                       
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="center">
                        <input id="btnAddRows" type="button" value="+添加行" onclick="fnAddNew();" class="btns" />
                        <asp:Button ID="btnUpd" runat="server" Text=" 修  改 " CssClass="btns" ValidationGroup="AddBI" OnClick="btnUpd_Click" />
                        <asp:Button ID="btnPostBack" CssClass="btns" OnClientClick="return confirm('你将返回上一级,修改后未提交信息会丢失,是否确认？')" runat="server" Text=" 返  回 " OnClick="btnPostBack_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblTip" runat="server" ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="HidSelectVal" runat="server" />
                        <asp:HiddenField ID="HidRowCount" Value="1" runat="server" />
                        <asp:HiddenField ID="HidMonTotal" Value="0" runat="server" />
                        <asp:HiddenField ID="hidPPID" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
