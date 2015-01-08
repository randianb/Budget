<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformationPrinted.aspx.cs" Inherits="ReimForms_InformationPrinted" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>嘉鱼县地方税务局资料印制申请表</title>
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
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(资料印制)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>资料印制申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" Height="454" src="../../img/BaoXiao/资料印制申请表%20.jpg"  />   
                    <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 234px; top: 129px; position: absolute;  height:21px; width: 140px; right: 760px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 411px; top: 132px; position: absolute;  height:19px; width: 63px; right: 660px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 508px; top: 132px; position: absolute;  height:19px; width: 23px; right: 603px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 555px; top: 133px; position: absolute;  height:19px; width: 26px; right: 553px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 118px; top: 197px; position: absolute;  height:24px; width: 162px; right: 854px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 289px; top: 197px; position: absolute;  height:24px; width: 161px; right: 684px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 459px; top: 200px; position: absolute;  height:24px; width: 163px; right: 512px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 630px; top: 202px; position: absolute;  height:24px; width: 161px; right: 343px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 799px; top: 204px; position: absolute;  height:24px; width: 161px; right: 294px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 119px; top: 231px; position: absolute;  height:24px; width: 160px; right: 855px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 291px; top: 234px; position: absolute;  height:24px; width: 158px; right: 685px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 461px; top: 235px; position: absolute;  height:26px; width: 159px; right: 514px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 629px; top: 236px; position: absolute;  height:26px; width: 162px; right: 343px;" 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 800px; top: 239px; position: absolute;  height:24px; width: 159px; right: 175px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 114px; top: 269px; position: absolute;  height:24px; width: 165px; right: 855px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 291px; top: 267px; position: absolute;  height:27px; width: 158px; right: 685px;" 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 460px; top: 269px; position: absolute;  height:28px; width: 159px; right: 515px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 628px; top: 272px; position: absolute;  height:25px; width: 161px; right: 345px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 798px; top: 276px; position: absolute;  height:24px; width: 161px; right: 175px;" 
                        TabIndex="19" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox20" runat="server" 
                        style="z-index: 99; left: 114px; top: 301px; position: absolute;  height:27px; width: 167px; right: 853px;" 
                        TabIndex="20" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox21" runat="server" 
                        style="z-index: 99; left: 291px; top: 303px; position: absolute;  height:28px; width: 157px; right: 686px;" 
                        TabIndex="21" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox22" runat="server" 
                        style="z-index: 99; left: 458px; top: 306px; position: absolute;  height:24px; width: 161px; right: 515px;" 
                        TabIndex="22" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox23" runat="server" 
                        style="z-index: 99; left: 630px; top: 309px; position: absolute;  height:25px; width: 161px; right: 343px;" 
                        TabIndex="23" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox24" runat="server" 
                        style="z-index: 99; left: 800px; top: 310px; position: absolute;  height:25px; width: 158px; right: 176px;" 
                        TabIndex="24" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox25" runat="server" 
                        style="z-index: 99; left: 113px; top: 338px; position: absolute;  height:26px; width: 167px; right: 854px;" 
                        TabIndex="25" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox26" runat="server" 
                        style="z-index: 99; left: 288px; top: 341px; position: absolute;  height:24px; width: 159px; right: 687px;" 
                        TabIndex="26" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox27" runat="server" 
                        style="z-index: 99; left: 458px; top: 340px; position: absolute;  height:27px; width: 160px; right: 516px;" 
                        TabIndex="27" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox28" runat="server" 
                        style="z-index: 99; left: 631px; top: 343px; position: absolute;  height:25px; width: 158px; right: 345px;" 
                        TabIndex="28" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox29" runat="server" 
                        style="z-index: 99; left: 801px; top: 343px; position: absolute;  height:26px; width: 155px; right: 178px;" 
                        TabIndex="29" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox30" runat="server" 
                        style="z-index: 99; left: 288px; top: 373px; position: absolute;  height:27px; width: 160px; right: 686px;" 
                        TabIndex="30" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox31" runat="server" 
                        style="z-index: 99; left: 458px; top: 376px; position: absolute;  height:24px; width: 161px; right: 515px;" 
                        TabIndex="31" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox32" runat="server" 
                        style="z-index: 99; left: 630px; top: 378px; position: absolute;  height:25px; width: 156px; right: 348px;" 
                        TabIndex="32" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox33" runat="server" 
                        style="z-index: 99; left: 797px; top: 378px; position: absolute;  height:26px; width: 164px; right: 173px;" 
                        TabIndex="33" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox34" runat="server" 
                        style="z-index: 99; left: 252px; top: 411px; position: absolute;  height:24px; width: 231px; right: 651px;" 
                        TabIndex="34" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox35" runat="server" 
                        style="z-index: 99; left: 658px; top: 414px; position: absolute;  height:24px; width: 305px; right: 171px;" 
                        TabIndex="35" BorderStyle="None" ></asp:TextBox>

               
                    
                                                                
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="btns" Text="添 加" OnClick="btnAdd_Click"/>
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
