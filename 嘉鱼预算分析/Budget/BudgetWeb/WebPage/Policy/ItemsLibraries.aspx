<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemsLibraries.aspx.cs" Inherits="WebPage_Policy_ItemsLibraries" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算编辑添加</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../css/mytable.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
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
        $(function () {
            $("#txtProName").focus(function () {
                lblShowResult.text = "";
            })
        });

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
                App.direct.ModifyPolicy(record.data.PLID);
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 28px;">
                <tr>
                    <td colspan="4" class="tr1">&nbsp;<strong>年初预算编写</strong>
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

                    <td width="15%" class="tr1 right">项目名称：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtProName" runat="server" CssClass="txt" ValidationGroup="AddBI"></asp:TextBox><span
                        style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProName"
                            Display="Dynamic" ErrorMessage="项目名称不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                    <td width="15%" class="tr1 right">行政成本类别：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlAdmCostCate" CssClass="txt" runat="server">
                        <asp:ListItem Selected="True">行政单位一般行政管理项目支出</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>


                <tr>

                    <td width="15%" class="tr1 right">项目属性：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlProProper" CssClass="txt" runat="server">
                        <asp:ListItem Selected="True">持续性项目</asp:ListItem>
                        <asp:ListItem>当年项目</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td width="15%" class="tr1 right">项目类型：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlPayProType" CssClass="txt" runat="server">
                    </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td width="15%" class="tr1 right">部门：
                    </td> 
                    <td>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDeptName" CssClass="txt" runat="server">
                       
                    </asp:DropDownList> 
                    </td>
                    <td width="15%" class="tr1 right">金额：
                    </td> 
                    <td>&nbsp;&nbsp;
                        
                    <asp:TextBox ID="txtBILMon" runat="server" CssClass="txt"  Text="0" ></asp:TextBox>
                        <span style="color: red">* </span>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBILMon" Display="Dynamic" ErrorMessage="所填金额只能是数字" ForeColor="Red" ValidationExpression="^(([1-9]\d*)(\.\d{1,2})?)$|(0\.0?([1-9]\d?))$" ValidationGroup="AddBI"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td width="15%" class="tr1 right">项目简介：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtProDesc" runat="server" CssClass="txt" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProDesc"
                            Display="Dynamic" ErrorMessage="项目简介不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目申请理由和主要内容：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtBIAppReaCon" CssClass="txt" runat="server" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBIAppReaCon"
                            Display="Dynamic" ErrorMessage="项目申请理由不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目支出测算依据及说明：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtBIExpGistExp" CssClass="txt" runat="server" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBIExpGistExp"
                            Display="Dynamic" ErrorMessage="项目支出测算依据及说明不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效长期目标：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtBILongGoal" CssClass="txt" runat="server" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBILongGoal"
                            Display="Dynamic" ErrorMessage="项目绩效长期目标不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">项目绩效年度目标：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtBIYearGoal" CssClass="txt" runat="server" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBIYearGoal"
                            Display="Dynamic" ErrorMessage="项目绩效年度目标不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="tr1 right">其他说明的问题：
                    </td>
                    <td class="auto-style1" colspan="3">&nbsp;&nbsp;
                    <asp:TextBox ID="txtBIOthExpProb" CssClass="txt" runat="server" Width="75%" Height="50px"
                        TextMode="MultiLine" ValidationGroup="AddBI"></asp:TextBox><span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBIOthExpProb"
                            Display="Dynamic" ErrorMessage="其他说明问题不能为空" ForeColor="Red" ValidationGroup="AddBI"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>

                    <td class="tr1" colspan="9" align="center">&nbsp;
                        <asp:Button ID="btnSure" runat="server" Text=" 确  定 " CssClass="btns" ValidationGroup="AddBI" OnClick="btnSure_Click" />
                        <asp:Button ID="btnPostBack" CssClass="btns" OnClientClick="return confirm('你将返回上一级,未提交信息会丢失,是否确认？')" runat="server" Text=" 返  回 " OnClick="btnPostBack_Click" />
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>


        </div>
        <asp:HiddenField ID="Hidbuid" runat="server" />
        <asp:HiddenField ID="HidFlag" runat="server" />
    </form>
</body>
</html>
