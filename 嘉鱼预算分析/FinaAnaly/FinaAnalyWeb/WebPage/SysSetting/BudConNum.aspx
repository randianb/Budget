<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudConNum.aspx.cs" Inherits="WebPage_SysSetting_BudConNum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算控制数</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />
    <link href="../../css/whtable.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 120px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        function CheckFileType() {
            var objButton = document.getElementById("btnImport");//上传按钮
            var objFileUpload = document.getElementById('fupFile');//FileUpload
            var objMSG = document.getElementById('lblShowResult');//显示提示信息用的DIV
            var FileName = new String(objFileUpload.value);//文件名
            var extension = new String(FileName.substring(FileName.lastIndexOf(".") + 1, FileName.length));//文件扩展名

            if (extension == "xls" || extension == "xlsx") {
                objButton.disabled = false;//启用上传按钮
                objMSG.innerHTML = "";
            }
            else {
                objButton.disabled = true;//禁用上传按钮
                objMSG.innerHTML = "* 请您选择Excel文件";
            }
        }


        function Tips(msg) {
            layer.msg(msg, 2, -1);
        }


        $(function () {            
            $("#txtProBudMon").val($("#HidPBM").val());            
            $("#txtProAddMon").val($("#HidPAM").val());
            $("#txtTUserMon").val($("#HidTUM").val());
            $("#txtTPubMon").val($("#HidTPM").val());
            $("#txtTFamMon").val($("#HidTFM").val());
            $("#txtAddUserMon").val($("#HidAUM").val());
            $("#txtAddPubMon").val($("#HidAPM").val());
            $("#txtAddFamMon").val($("#HidAFM").val());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tabtitle">
            <span>当前位置：<b>系统设置</b>&nbsp;&nbsp;>&nbsp;&nbsp;预算控制数</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                <tr>
                    <td class="tr1" align="left" colspan="4">&nbsp;                     
                        <strong>
                            <asp:Label ID="lblYear" runat="server"></asp:Label>年预算控制数</strong>
                        &nbsp;&nbsp;&nbsp;&nbsp;<strong>总共</strong><asp:Label ID="lblBudMon" runat="server" ForeColor="Red"></asp:Label><strong>万元预算金额</strong>                       
                        <asp:HiddenField ID="HidPBM" runat="server" />                        
                        <asp:HiddenField ID="HidPAM" runat="server" />
                        <asp:HiddenField ID="HidTUM" runat="server"/>
                        <asp:HiddenField ID="HidTPM" runat="server"/>
                        <asp:HiddenField ID="HidTFM" runat="server" />
                        <asp:HiddenField ID="HidAUM" runat="server" />
                        <asp:HiddenField ID="HidAPM" runat="server" />
                        <asp:HiddenField ID="HidAFM" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center" rowspan="7"><strong >基本支出</strong></td>
                    <td class="tr1" width="15%" align="left" rowspan="3">年初预算
                        <asp:Label runat="server" ID="lblthisMon" ForeColor="Red"></asp:Label>万元
                    </td>                        
                    <td class="tr1" width="15%" align="center">人员经费</td>
                    <td align="left">
                        <asp:TextBox ID="txtTUserMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtTUserMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>                 
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center">公用经费</td>
                    <td align="left">
                        <asp:TextBox ID="txtTPubMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtTPubMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center">对个人和家庭补助支出</td>
                    <td align="left">
                        <asp:TextBox ID="txtTFamMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtTFamMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="tr1">                        
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="left" rowspan="3">追加预算
                        <asp:Label runat="server" ID="lblAddMon" ForeColor="Red"></asp:Label>万元
                    </td>
                    <td class="tr1" width="15%" align="center">人员经费</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddUserMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtAddUserMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center">公用经费</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddPubMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtAddPubMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="center">对个人和家庭补助支出</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddFamMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                       
                        <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtAddFamMon" Display="Dynamic" ErrorMessage="* 基本支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="0" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right">项目支出年初预算：</td>
                    <td align="left">
                        <asp:TextBox ID="txtProBudMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtProBudMon" Display="Dynamic" ErrorMessage="* 项目支出预算不能为空" ForeColor="Red" ValidationGroup="BudMonSetting"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtProBudMon" Display="Dynamic" ErrorMessage="* 项目支出预算控制数必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="1" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                    <td class="tr1" width="15%" align="right">项目支出追加预算金额：</td>
                    <td align="left">
                        <asp:TextBox ID="txtProAddMon" runat="server" CssClass="txt" ValidationGroup="BudMonSetting"></asp:TextBox>&nbsp;万元                      
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtProAddMon" Display="Dynamic" ErrorMessage="* 项目支出追加金额必须为数字" ForeColor="Red" MaximumValue="9999" MinimumValue="1" Type="Double" ValidationGroup="BudMonSetting"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="15%" align="right"></td>
                    <td align="left" colspan="5">
                        <asp:Button ID="btnCon" runat="server" Text=" 确定 " CssClass="btns" ValidationGroup="BudMonSetting" OnClick="btnCon_Click" />
                        &nbsp;
                        <asp:Button ID="btnCan" runat="server" Text=" 取消 " CssClass="btns" OnClick="btnCan_Click" />
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
