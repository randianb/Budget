<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudgetReviewDetails.aspx.cs" Inherits="BudgetPage_mainPages_BudgetReviewDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算审核</title>
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
        function BackChk() {
            $("#spanbcn").text("*");
            $("#spanback").text("*");
            if ($("#txtBudConNumber").val() == "") {
                $("#txtBudConNumber").focus();
                $("#spanbcn").text("*请填写预算控制数");
                return false;
            }
            if ($("#txtBackReason").val() == "") {
                $("#txtBackReason").focus();
                $("#spanback").text("*请填写退回原因");
                return false;
            }
            return true;
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
            $("#BudCostProTb input[name='" + id + "']").each(function () {
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
                    <td colspan="4" class="tr1">&nbsp;<strong>预算审核</strong>
                        <asp:HiddenField ID="Hidbuid" runat="server" />
                        <asp:HiddenField ID="Hiddepid" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目类别：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlProType" CssClass="txt" runat="server">
                        <asp:ListItem>一般项目</asp:ListItem>
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
                        <asp:TextBox ID="txtItemNumber" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                    </td>
                    <td width="15%" class="tr1 right">项目名称：
                    
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtProName" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">行政成本类别：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlAdmCostCate" CssClass="txt" runat="server" Enabled="false">
                            <asp:ListItem Selected="True">行政单位一般行政管理项目支出</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">项目安排频度：
                     
                    </td>
                    <td>&nbsp;&nbsp;
                     <asp:DropDownList ID="ddlBIPlanHz" CssClass="txt" runat="server">
                         <asp:ListItem Value="常年性项目">常年性项目</asp:ListItem>
                         <asp:ListItem Value="延续性项目">延续性项目</asp:ListItem>
                         <asp:ListItem Value="一次性项目">一次性项目</asp:ListItem>
                     </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目起始时间：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIStaTime" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                    </td>
                    <td width="15%" class="tr1 right">项目终止时间：
                        
                    </td>
                    <td>&nbsp;&nbsp;
                 <asp:TextBox ID="txtBIEndTime" ReadOnly="True" runat="server" CssClass="txt"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目负责人：
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBICharger" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                    </td>
                    <td width="15%" class="tr1 right">项目属性：

                    </td>
                    <td>&nbsp;&nbsp;
                         <asp:DropDownList ID="ddlProProper" CssClass="txt" runat="server">
                             <asp:ListItem>持续性项目</asp:ListItem>
                             <asp:ListItem>当年项目</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目类型：
                    </td>
                    <td>&nbsp;&nbsp;
                       <asp:DropDownList ID="ddlPayProType" CssClass="txt" runat="server" ReadOnly="True">
                       </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">预算控制数：

                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBudConNumber" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目报进日期：
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBITime" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox><span style="color: red">*</span>
                    </td>
                    <td width="15%" class="tr1 right">预算金额：
                    </td>
                    <td width="35%">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIMon" CssClass="txt" runat="server" CausesValidation="false" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目简介：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtProDesc" runat="server" CssClass="txt" Width="75%" ReadOnly="True" Height="50px" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目申请理由和主要内容：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIAppReaCon" CssClass="txt" runat="server" Width="75%" Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目支出测算依据及说明：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIExpGistExp" CssClass="txt" runat="server" Width="75%" Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效长期目标：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBILongGoal" CssClass="txt" runat="server" Width="75%" Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效年度目标：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIYearGoal" CssClass="txt" runat="server" Width="75%" Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">其他说明的问题：
                    
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBIOthExpProb" CssClass="txt" runat="server" Width="75%" Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">
                        <span style="color: red">退回原因：</span>
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                        <asp:TextBox ID="txtBackReason" CssClass="txt" runat="server" Width="75%" Height="50px" TextMode="MultiLine" ValidationGroup="BackChk"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请填写退回原因" ControlToValidate="txtBackReason" Display="Dynamic" ForeColor="Red" ValidationGroup="BackChk"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>


            <table id="BudCostProTb" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr>
                    <td width="12%" rowspan="3" class="tr1" align="center">行号</td>
                    <td width="12%" rowspan="3" class="tr1" align="center">当前年度</td>
                    <td width="12%" rowspan="3" class="tr1" align="center">经济科目</td>
                    <td width="12%" rowspan="3" class="tr1" align="center">总计</td>
                    <td width="48%" colspan="4" class="tr1" align="center"></td>
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
                <asp:Repeater ID="repBudExam" runat="server" OnItemDataBound="repBudExam_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td width="12%">
                                <input name="txt1" type="text" id="txt1" readonly="readonly" value='<%# Eval("CostID") %>' class="txtJs">
                            </td>
                            <td width="12%">
                                <input name="txt2" type="text" id="txt2" readonly="readonly" class="txtJs" value='<%# Eval("BCPCurrYear") %>' onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})">
                            </td>
                            <td width="12%">
                                <asp:HiddenField ID="HidPIID" Value='<%# Eval("PIID") %>' runat="server" />
                                <asp:DropDownList ID="ddlIncome" CssClass="txtJs" name="txt3" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <td width="12%">
                                <input name="txt4" type="text" id="txt4" readonly="readonly" value='<%# Eval("BCPTotal") %>' class="txtJs">
                            </td>
                            <td width="12%">
                                <input name="txt5" type="text" id="txt5" readonly="readonly" value='<%# Eval("BCPSubtFinAllo") %>' class="txtJs">
                            </td>
                            <td width="12%">
                                <input name="txt6" type="text" id="txt6" readonly="readonly" value='<%# Eval("BCPSubtExp") %>' class="txtJs">
                            </td>
                            <td width="12%">
                                <input name="txt7" type="text" id="txt7" readonly="readonly" value='<%# Eval("BCInExpenses") %>' class="txtJs">
                            </td>
                            <td width="12%">
                                <input name="txt8" type="text" id="txt8" readonly="readonly" value='<%# Eval("BCOutFunding") %>' class="txtJs">
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr id="TotalRow">
                    <td class="tr1" width="36%" colspan="3" align="center">&nbsp;&nbsp; <strong>项目金额合计栏</strong>
                    </td>
                    <td width="12%">
                        <asp:TextBox ID="txt4Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="12%">
                        <asp:TextBox ID="txt5Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="12%">
                        <asp:TextBox ID="txt6Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="12%">
                        <asp:TextBox ID="txt7Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td width="12%">
                        <asp:TextBox ID="txt8Total" CssClass="txtJs" runat="server" Text="0" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="9">
                        <asp:Button ID="btnAppo" runat="server" Text=" 审核通过 " CausesValidation="false" CssClass="btns" OnClick="btnAppo_Click" />
                        <asp:Button ID="btnReturn" runat="server" Text=" 退 回 " OnClientClick="return BackChk();" CssClass="btns" OnClick="btnReturn_Click" />
                        <asp:Button ID="btnElimin" runat="server" Text=" 淘 汰 " OnClientClick="return BackChk();" CssClass="btns" OnClick="btnElimin_Click" />
                        <asp:Button ID="btnPostBack" CssClass="btns" runat="server" Text=" 返  回 " OnClick="btnPostBack_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
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
