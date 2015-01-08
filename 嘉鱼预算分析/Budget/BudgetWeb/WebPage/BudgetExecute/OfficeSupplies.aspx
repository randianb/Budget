<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfficeSupplies.aspx.cs" Inherits="ReimForms_OfficeSupplies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>嘉鱼县地方税务局办公室用品购置申请表</title>
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
        <span>当前位置：<b>预算执行</b> ><b>报销系统</b> > 申请(办公室用品)</span><p>
        </p>
    </div>
    <!-- 表头结束 -->--%>
    <div class="table_list">       
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>办公室用品购置申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left" class="auto-style2">
                    <img alt="" Height="454"  Width="909" src="../../img/BaoXiao/办公用品购置申请表.jpg"  />
                     <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 212px; top: 128px; position: absolute;  height:19px; width: 145px; " 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 426px; top: 128px; position: absolute;  height:19px; width: 43px; right: 665px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; top: 128px; position: absolute;  height:19px; width: 24px; right: 614px; left: 496px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; top: 130px; position: absolute;  height:19px; width: 28px; right: 629px; left: 545px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 123px; top: 193px; position: absolute;  height:24px; width: 138px; right: 873px; bottom: 431px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; top: 195px; position: absolute;  height:23px; width: 142px; left: 292px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; top: 198px; position: absolute;  height:23px; width: 139px; left: 466px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; top: 200px; position: absolute;  height:21px; width: 137px; left: 632px; right: 367px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 796px; top: 199px; position: absolute;  height:23px; width: 135px; right: 203px; bottom: 426px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 124px; top: 230px; position: absolute;  height:23px; width: 139px; right: 871px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 294px; top: 231px; position: absolute;  height:23px; width: 139px; right: 703px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 463px; top: 232px; position: absolute;  height:24px; width: 141px; right: 530px; bottom: 392px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 634px; top: 231px; position: absolute;  height:23px; width: 142px; right: 358px;" 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; top: 235px; position: absolute;  height:23px; width: 141px; right: 193px; left: 800px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 122px; top: 264px; position: absolute;  height:23px; width: 140px; right: 872px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 293px; top: 265px; position: absolute;  height:23px; width: 140px; right: 703px;" 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; top: 270px; position: absolute;  height:23px; width: 137px; left: 465px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 629px; top: 269px; position: absolute;  height:23px; width: 137px; right: 368px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 802px; top: 270px; position: absolute;  height:23px; width: 137px; right: 195px;" 
                        TabIndex="19" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox20" runat="server" 
                        style="z-index: 99; left: 123px; top: 301px; position: absolute;  height:23px; width: 136px; right: 875px;" 
                        TabIndex="20" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox21" runat="server" 
                        style="z-index: 99; left: 290px; top: 304px; position: absolute;  height:23px; width: 136px; right: 710px;" 
                        TabIndex="21" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox22" runat="server" 
                        style="z-index: 99; left: 462px; top: 302px; position: absolute;  height:26px; width: 136px; right: 538px;" 
                        TabIndex="22" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox23" runat="server" 
                        style="z-index: 99; left: 635px; top: 300px; position: absolute;  height:26px; width: 136px; right: 365px;" 
                        TabIndex="23" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox24" runat="server" 
                        style="z-index: 99; left: 799px; top: 303px; position: absolute;  height:26px; width: 136px; right: 201px;" 
                        TabIndex="24" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox25" runat="server" 
                        style="z-index: 99; left: 120px; top: 334px; position: absolute;  height:23px; width: 138px; " 
                        TabIndex="25" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox26" runat="server" 
                        style="z-index: 99; left: 291px; top: 337px; position: absolute;  height:23px; width: 138px; " 
                        TabIndex="26" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox27" runat="server" 
                        style="z-index: 99; left: 635px; top: 339px; position: absolute;  height:23px; width: 136px; right: 365px;" 
                        TabIndex="28" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox28" runat="server" 
                        style="z-index: 99; left: 461px; top: 337px; position: absolute;  height:23px; width: 136px; right: 539px;" 
                        TabIndex="27" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox29" runat="server" 
                        style="z-index: 99; left: 801px; top: 342px; position: absolute;  height:23px; width: 142px; right: 191px;" 
                        TabIndex="29" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox30" runat="server" 
                        style="z-index: 99; left: 295px; top: 373px; position: absolute;  height:23px; width: 136px; right: 703px;" 
                        TabIndex="30" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox31" runat="server" 
                        style="z-index: 99; left: 460px; top: 374px; position: absolute;  height:23px; width: 136px; right: 540px;" 
                        TabIndex="31" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox32" runat="server" 
                        style="z-index: 99; left: 629px; top: 377px; position: absolute;  height:23px; width: 136px; right: 371px;" 
                        TabIndex="32" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox33" runat="server" 
                        style="z-index: 99; left: 804px; top: 375px; position: absolute;  height:25px; width: 135px; right: 195px;" 
                        TabIndex="33" BorderStyle="None" ></asp:TextBox>
                      <asp:TextBox ID="TextBox34" runat="server" 
                        style="z-index: 99; left: 272px; top: 406px; position: absolute;  height:23px; width: 145px; " 
                        TabIndex="34" BorderStyle="None" ></asp:TextBox>
                     <asp:TextBox ID="TextBox35" runat="server" 
                        style="z-index: 99; left: 652px; top: 408px; position: absolute;  height:23px; width: 145px; " 
                        TabIndex="35" BorderStyle="None" ></asp:TextBox>               
                                                                
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
