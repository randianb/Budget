<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance.aspx.cs" Inherits="WebPage_BudgetExecute_Maintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>嘉鱼县地方税务局维修申请表</title>
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
<%--    <!-- 表头开始 -->
    <div class="tabtitle">
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(地方税务局维修)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">       
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>地方税务局维修申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" Height="454"  Width="909" src="../../img/BaoXiao/嘉鱼县地方税务局维修申请表.jpg"  />   
                    <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 177px; top: 136px; position: absolute;  height:22px; width: 145px; right: 862px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; top: 138px; position: absolute;  height:22px; width: 69px; left: 394px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; top: 137px; position: absolute;  height:22px; width: 29px; left: 489px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 540px; top: 136px; position: absolute;  height:22px; width: 30px; " 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 260px; top: 172px; position: absolute;  height:34px; width: 633px; right: 291px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>  
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 261px; top: 220px; position: absolute;  height:32px; width: 633px; right: 290px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 260px; top: 263px; position: absolute;  height:75px; width: 633px; right: 291px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 258px; top: 349px; position: absolute;  height:33px; width: 633px; right: 243px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 258px; top: 393px; position: absolute;  height:35px; width: 633px; right: 293px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>                                                      
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="btns" Text="添  加" OnClick="btnAdd_Click" />
                  <asp:Button ID="btnAlter" runat="server" CssClass="btns" Text="修  改" OnClick="btnAlter_Click" />
                    <asp:Button ID="btnunit" runat="server" CssClass="btns" Text="填写通用报销单" OnClick="btnunit_Click" />
                   <asp:Button ID="btnCan" runat="server" CssClass="btns" Text="返  回" OnClick="btnCan_Click" />
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
