<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarRecordSheet.aspx.cs" Inherits="WebPage_BudgetExecute_CarRecordSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>地方税务局长途出车记录单填写</title>
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
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(地方税务局维修)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">       
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>地方税务局长途出车记录单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" Height="454" src="../../img/BaoXiao/嘉鱼县地方税务局长途出车记录单.jpg"  />   
                    <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 327px; top: 142px; position: absolute;  height:21px; width: 145px; right: 602px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 490px; top: 142px; position: absolute;  height:19px; width: 39px; right: 545px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 544px; top: 142px; position: absolute;  height:20px; width: 39px; right: 491px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 61px; top: 210px; position: absolute;  height:26px; width: 234px; right: 779px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 300px; top: 211px; position: absolute;  height:27px; width: 232px; right: 595px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 536px; top: 212px; position: absolute;  height:26px; width: 232px; right: 306px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 773px; top: 212px; position: absolute;  height:26px; width: 232px; right: 69px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 63px; top: 249px; position: absolute;  height:27px; width: 232px; " 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 299px; top: 250px; position: absolute;  height:26px; width: 232px; right: 543px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 536px; top: 247px; position: absolute;  height:31px; width: 232px; right: 306px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 772px; top: 247px; position: absolute;  height:31px; width: 232px; right: 70px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 62px; top: 284px; position: absolute;  height:29px; width: 232px; bottom: 335px; right: 780px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 299px; top: 288px; position: absolute;  height:27px; width: 232px; " 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 536px; top: 285px; position: absolute;  height:29px; width: 232px; " 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 772px; top: 285px; position: absolute;  height:33px; width: 232px; " 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 62px; top: 326px; position: absolute;  height:26px; width: 232px; " 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 299px; top: 328px; position: absolute;  height:26px; width: 232px; " 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 535px; top: 323px; position: absolute;  height:29px; width: 232px; " 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 771px; top: 323px; position: absolute;  height:33px; width: 232px; " 
                        TabIndex="19" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox20" runat="server" 
                        style="z-index: 99; left: 298px; top: 364px; position: absolute;  height:28px; width: 705px; " 
                        TabIndex="20" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox21" runat="server" 
                        style="z-index: 99; left: 298px; top: 402px; position: absolute;  height:27px; width: 705px; " 
                        TabIndex="21" BorderStyle="None" ></asp:TextBox>
                                                                        
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
