<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expense.aspx.cs" Inherits="ReimForms_Expense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>嘉鱼县地方税务局费用报销单</title>
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
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(费用报销)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">
       
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>费用报销单填写</strong>
                </td>
            </tr>
            <tr id="printtr">
                <td colspan="4" align="left">
                    <img alt="" Height="454" Width="909" src="../../img/BaoXiao/费用报销单.jpg"  />
                    <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 249px; top: 135px; position: absolute;  height:22px; width: 131px; right: 756px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 402px; top: 137px; position: absolute;  height:19px; width: 60px; " 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 489px; top: 137px; position: absolute;  height:19px; width: 31px; right: 614px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 541px; top: 138px; position: absolute;  height:19px; width: 27px; right: 566px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 219px; top: 168px; position: absolute;  height:30px; width: 310px; right: 607px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 648px; top: 169px; position: absolute;  height:30px; width: 92px; right: 396px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 867px; top: 168px; position: absolute;  height:31px; width: 86px; right: 183px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                  
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 274px; top: 209px; position: absolute;  height:30px; width: 449px; right: 413px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 749px; top: 211px; position: absolute;  height:30px; width: 205px; " 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 181px; top: 252px; position: absolute;  height:30px; width: 771px; right: 184px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 342px; top: 292px; position: absolute;  height:30px; width: 184px; right: 610px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 671px; top: 292px; position: absolute;  height:30px; width: 282px; right: 183px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 243px; top: 332px; position: absolute;  height:33px; width: 709px; right: 184px;" 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 217px; top: 376px; position: absolute;  height:30px; width: 734px; right: 185px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 210px; top: 418px; position: absolute;  height:23px; width: 248px; right: 678px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 515px; top: 416px; position: absolute;  height:30px; width: 254px; " 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 840px; top: 417px; position: absolute;  height:30px; width: 113px; right: 183px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    
                    <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 965px; top: 289px; position: absolute;  height:48px; width: 19px; right: 152px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>

                    
                                                                
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="btns" Text="添 加" OnClick="btnAdd_Click"/>
                  <asp:Button ID="btnAlter" runat="server" CssClass="btns" Text="修  改" OnClick="btnAlter_Click"/>
                     
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
