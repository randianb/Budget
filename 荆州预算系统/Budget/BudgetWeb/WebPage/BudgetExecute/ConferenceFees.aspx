<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConferenceFees.aspx.cs" Inherits="ReimForms_ConferenceFees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>嘉鱼县地方税务局工作会议呈报申请表</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../css/mytable.js"></script>
    <style type="text/css">
        html, body
        {
            overflow: scroll;
            
            margin: 0;
            height: 100%;
        }
        .txt
        {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--<!-- 表头开始 -->
    <div class="tabtitle">
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(工作会议)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">        
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>工作会议呈报申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" Height="454"  Width="909" src="../../img/BaoXiao/工作会议呈报申请表.jpg"  />
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 545px; top: 127px; position: absolute;  height:20px; width: 30px; right: 559px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 286px; top: 311px; position: absolute;  height:36px; width: 240px; " 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 537px; top: 310px; position: absolute;  height:36px; width: 166px; " 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 711px; top: 309px; position: absolute;  height:36px; width: 244px; right: 179px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>                     
                     <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 210px; top: 127px; position: absolute;  height:20px; width: 175px; right: 749px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 404px; top: 126px; position: absolute;  height:20px; width: 71px; right: 659px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 285px; top: 161px; position: absolute;  height:36px; width: 240px; right: 609px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 713px; top: 162px; position: absolute;  height:36px; width: 240px; right: 181px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 287px; top: 211px; position: absolute;  height:36px; width: 241px; right: 606px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 714px; top: 211px; position: absolute;  height:36px; width: 240px; right: 180px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 287px; top: 259px; position: absolute;  height:36px; width: 240px; bottom: 353px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 539px; top: 261px; position: absolute;  height:36px; width: 163px; bottom: 351px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 713px; top: 261px; position: absolute;  height:36px; width: 241px; bottom: 351px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 286px; top: 359px; position: absolute;  width: 241px; height: 36px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 538px; top: 360px; position: absolute;  width: 163px; height: 36px;" 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 711px; top: 359px; position: absolute;  width: 244px; height: 36px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 497px; top: 127px; position: absolute;  height:20px; width: 30px; right: 607px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox> 
                        

                    
                                                                
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="btns" Text="添  加" OnClick="btnAdd_Click"/>
                  <asp:Button ID="btnAlter" runat="server" CssClass="btns" Text="修  改" OnClick="btnAlter_Click"/>
                    <asp:Button ID="btnunit" runat="server" CssClass="btns" Text="填写通用报销单" OnClick="btnunit_Click" />
                   <asp:Button ID="btnCan" runat="server" CssClass="btns" Text="返  回" OnClick="btnCan_Click"/>
                    <asp:Button ID="btnPrint" runat="server" CssClass="btns" OnClientClick="window.print()" Text="打  印" />
                    <asp:Label ID="lblMResult" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="tr1" align="center">
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>
    </form>
</body>
</html>
