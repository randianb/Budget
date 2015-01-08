<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuildActivity.aspx.cs" Inherits="WebPage_BudgetExecute_GuildActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>嘉鱼县地方税务局公会活动呈报申请表</title>
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
                    <td colspan="4" class="auto-style1" align="left">&nbsp;<strong>公会呈报申请表单填写</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left" class="auto-style2">
                        <img alt="" src="../../img/BaoXiao/嘉鱼县地方税务局工会活动呈报申请表.jpg" />
                        <asp:TextBox ID="TextBox1" runat="server"
                            Style="z-index: 99; left: 216px; top: 124px; position: absolute; height: 22px; width: 153px; "
                            TabIndex="1" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server"
                            Style="z-index: 99; left: 385px; top: 128px; position: absolute; height: 19px; width: 85px; "
                            TabIndex="2" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server"
                            Style="z-index: 99; left: 499px; top: 128px; position: absolute; height: 19px; width: 28px; "
                            TabIndex="3" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"
                            Style="z-index: 99; left: 548px; top: 128px; position: absolute; height: 19px; width: 28px; "
                            TabIndex="4" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" runat="server"
                            Style="z-index: 99; left: 280px; top: 159px; position: absolute; height: 40px; width: 249px; "
                            TabIndex="5" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox6" runat="server"
                            Style="z-index: 99; left: 718px; top: 157px; position: absolute; height: 40px; width: 248px; "
                            TabIndex="6" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox7" runat="server"
                            Style="z-index: 99; left: 281px; top: 208px; position: absolute; height: 40px; width: 248px; "
                            TabIndex="7" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox8" runat="server"
                            Style="z-index: 99; left: 716px; top: 209px; position: absolute; height: 40px; width: 248px; "
                            TabIndex="8" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox9" runat="server"
                            Style="z-index: 99; left: 283px; top: 258px; position: absolute; height: 40px; width: 248px; "
                            TabIndex="9" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox10" runat="server"
                            Style="z-index: 99; left: 540px; top: 260px; position: absolute; height: 40px; width: 166px; "
                            TabIndex="10" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox11" runat="server"
                            Style="z-index: 99; left: 716px; top: 259px; position: absolute; height: 40px; width: 250px; "
                            TabIndex="11" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox12" runat="server"
                            Style="z-index: 99; left: 281px; top: 309px; position: absolute; height: 40px; width: 250px; right: 629px;"
                            TabIndex="12" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox13" runat="server"
                            Style="z-index: 99; left: 539px; top: 309px; position: absolute; height: 40px; width: 167px; "
                            TabIndex="13" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox14" runat="server"
                            Style="z-index: 99; left: 715px; top: 309px; position: absolute; height: 40px; width: 252px; "
                            TabIndex="14" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox15" runat="server"
                            Style="z-index: 99; left: 280px; top: 358px; position: absolute; height: 40px; width: 252px; "
                            TabIndex="15" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox16" runat="server"
                            Style="z-index: 99; left: 539px; top: 360px; position: absolute; height: 40px; width: 168px; "
                            TabIndex="16" BorderStyle="None"></asp:TextBox>
                        <asp:TextBox ID="TextBox17" runat="server"
                            Style="z-index: 99; left: 716px; top: 359px; position: absolute; height: 40px; width: 251px; "
                            TabIndex="17" BorderStyle="None"></asp:TextBox>
                       
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
