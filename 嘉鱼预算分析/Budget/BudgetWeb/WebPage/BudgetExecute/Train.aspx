<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Train.aspx.cs" Inherits="ReimForms_Train" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>嘉鱼县地方税务局培训呈报申请表</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../css/mytable.js"></script>
    <style type="text/css">
        html, body {
            overflow: scroll;
            
            margin: 0;
            height: 100%;
            width: 1113px;
        }

        .txt {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }

        .auto-style1 {
            background-color: #D9E7F8;
            font-size: 13.3px;
            height: 26px;
        }

        .auto-style2 {
            height: 26px;
        }
    </style> 

</head>
<body>
    <%--<object class="NoPrint" visible="false" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0px" id="WB" width="0px"></object>--%>
   
    <form id="form1" runat="server">
        <%--    <!-- 表头开始 -->
    <div class="tabtitle">
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(培训呈报)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
                <tr>
                    <td colspan="4" class="auto-style1" align="left">&nbsp;<strong>培训呈报申请表单填写</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left" class="auto-style2">
                        <img alt="" src="../../img/BaoXiao/培训呈报申请表.jpg" />
                        <asp:TextBox ID="TextBox1" runat="server"
                            Style="z-index: 99; left: 206px; top: 125px; position: absolute; height: 19px; width: 153px; "
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server"
                            Style="z-index: 99; left: 435px; top: 128px; position: absolute; height: 19px; width: 32px; right: 667px; bottom: 501px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server"
                            Style="z-index: 99; left: 490px; top: 129px; position: absolute; height: 19px; width: 23px; right: 621px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"
                            Style="z-index: 99; left: 541px; top: 129px; position: absolute; height: 19px; width: 24px; right: 569px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" runat="server"
                            Style="z-index: 99; left: 282px; top: 161px; position: absolute; height: 30px; width: 210px; right: 582px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox6" runat="server"
                            Style="z-index: 99; left: 707px; top: 162px; position: absolute; height: 30px; width: 207px; right: 160px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox7" runat="server"
                            Style="z-index: 99; left: 283px; top: 200px; position: absolute; height: 30px; width: 211px; right: 640px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox8" runat="server"
                            Style="z-index: 99; left: 711px; top: 203px; position: absolute; height: 30px; width: 207px; right: 156px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox9" runat="server"
                            Style="z-index: 99; left: 285px; top: 248px; position: absolute; height: 61px; width: 574px; right: 215px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox10" runat="server"
                            Style="z-index: 99; left: 281px; top: 326px; position: absolute; height: 30px; width: 576px; right: 277px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox11" runat="server"
                            Style="z-index: 99; left: 278px; top: 369px; position: absolute; height: 30px; width: 579px; right: 217px;"
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left">&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="btns" Text="添 加" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnAlter" runat="server" CssClass="btns" Text="修  改" OnClick="btnAlter_Click" />
                        <asp:Button ID="btnunit" runat="server" CssClass="btns" Text="填写通用报销单" OnClick="btnunit_Click" />
                        <asp:Button ID="btnCan" runat="server" CssClass="btns" Text="返  回" OnClick="btnCan_Click" /> 
                        <asp:Button ID="btnPrint" runat="server" CssClass="btns" Text="打  印" OnClientClick="window.print()" />
                        <asp:Label ID="lblMResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="tr1" align="center"></td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
