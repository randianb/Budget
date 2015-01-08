<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusinessTrip.aspx.cs" Inherits="WebPage_BudgetExecute_BusinessTrip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>公差旅费报销单</title>
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
                    &nbsp;<strong>公差旅费报销单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" Height="454"  Width="909" src="../../img/BaoXiao/公差旅费报销单.jpg"  />   
                    <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 388px; top: 117px; position: absolute;  height:18px; width: 81px; right: 605px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 498px; top: 117px; position: absolute;  height:18px; width: 48px; right: 528px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 571px; top: 117px; position: absolute;  height:18px; width: 48px; right: 455px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 851px; top: 97px; position: absolute;  height:20px; width: 88px; right: 135px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 111px; top: 153px; position: absolute;  height:50px; width: 75px; right: 888px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 229px; top: 151px; position: absolute;  height:54px; width: 103px; right: 802px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 402px; top: 151px; position: absolute;  height:55px; width: 222px; right: 450px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 193px; top: 243px; position: absolute;  height:21px; width: 53px; right: 828px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 256px; top: 243px; position: absolute;  height:21px; width: 76px; right: 742px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 467px; top: 243px; position: absolute;  height:21px; width: 51px; right: 556px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 528px; top: 243px; position: absolute;  height:21px; width: 93px; right: 453px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox27" runat="server" 
                        style="z-index: 99; left: 630px; top: 244px; position: absolute;  height:20px; width: 22px; right: 532px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox28" runat="server" 
                        style="z-index: 99; left: 656px; top: 244px; position: absolute;  height:20px; width: 22px; " 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox29" runat="server" 
                        style="z-index: 99; left: 684px; top: 245px; position: absolute;  height:20px; width: 57px; right: 443px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox30" runat="server" 
                        style="z-index: 99; left: 747px; top: 245px; position: absolute;  height:20px; width: 23px; right: 414px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox31" runat="server" 
                        style="z-index: 99; left: 774px; top: 245px; position: absolute;  height:20px; width: 22px; " 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox32" runat="server" 
                        style="z-index: 99; left: 801px; top: 246px; position: absolute;  height:20px; width: 62px; right: 321px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox87" runat="server" 
                        style="z-index: 99; left: 869px; top: 245px; position: absolute;  height:20px; width: 38px; right: 277px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox34" runat="server" 
                        style="z-index: 99; left: 913px; top: 246px; position: absolute;  height:20px; width: 38px; right: 233px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>              
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 631px; top: 217px; position: absolute;  height:21px; width: 20px; " 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 658px; top: 217px; position: absolute;  height:21px; width: 20px; right: 396px;" 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 684px; top: 217px; position: absolute;  height:21px; width: 57px; right: 333px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 748px; top: 218px; position: absolute;  height:21px; width: 21px; " 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox21" runat="server" 
                        style="z-index: 99; left: 774px; top: 218px; position: absolute;  height:21px; width: 21px; right: 389px;" 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox20" runat="server" 
                        style="z-index: 99; left: 803px; top: 217px; position: absolute;  height:21px; width: 58px; right: 213px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox22" runat="server" 
                        style="z-index: 99; left: 869px; top: 217px; position: absolute;  height:21px; width: 38px; right: 167px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox23" runat="server" 
                        style="z-index: 99; left: 914px; top: 217px; position: absolute;  height:21px; width: 38px; right: 122px;" 
                        TabIndex="19" BorderStyle="None" ></asp:TextBox>


                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 193px; top: 275px; position: absolute;  height:21px; width: 53px; right: 828px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox24" runat="server" 
                        style="z-index: 99; left: 254px; top: 275px; position: absolute;  height:21px; width: 81px; right: 739px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox25" runat="server" 
                        style="z-index: 99; left: 466px; top: 274px; position: absolute;  height:21px; width: 54px; " 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox26" runat="server" 
                        style="z-index: 99; left: 526px; top: 274px; position: absolute;  height:21px; width: 95px; " 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox36" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:20px; width: 21px; right: 507px; left: 656px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox33" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:20px; width: 60px; left: 683px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox35" runat="server" 
                        style="z-index: 99; top: 274px; position: absolute;  height:20px; width: 18px; left: 749px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox38" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:20px; width: 18px; left: 775px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox37" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:21px; width: 56px; right: 326px; left: 802px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox39" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:21px; width: 36px; right: 279px; left: 869px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox40" runat="server" 
                        style="z-index: 99; top: 275px; position: absolute;  height:21px; width: 36px; right: 235px; left: 913px; bottom: 352px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>

                   <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 193px; top: 305px; position: absolute;  height:21px; width: 53px; right: 828px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox43" runat="server" 
                        style="z-index: 99; left: 254px; top: 305px; position: absolute;  height:21px; width: 81px; right: 739px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox44" runat="server" 
                        style="z-index: 99; left: 493px; top: 306px; position: absolute;  height:21px; width: 30px; bottom: 321px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox45" runat="server" 
                        style="z-index: 99; left: 540px; top: 306px; position: absolute;  height:21px; width: 23px; right: 511px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox46" runat="server" 
                        style="z-index: 99; left: 581px; top: 306px; position: absolute;  height:21px; width: 23px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox47" runat="server" 
                        style="z-index: 99; left: 630px; top: 304px; position: absolute;  height:21px; width: 23px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox48" runat="server" 
                        style="z-index: 99; left: 656px; top: 304px; position: absolute;  height:21px; width: 23px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>


                    <asp:TextBox ID="TextBox49" runat="server" 
                        style="z-index: 99; top: 274px; position: absolute;  height:21px; width: 57px;width: 23px; left: 630px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox85" runat="server" 
                        style="z-index: 99; top: 274px; position: absolute;  height:21px; width: 57px;width: 23px; left: 655px; right: 506px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox41" runat="server" 
                        style="z-index: 99; top: 305px; position: absolute;  height:21px; width: 57px;width: 56px; left: 684px; right: 444px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>                 
                    <asp:TextBox ID="TextBox50" runat="server" 
                        style="z-index: 99; left: 749px; top: 304px; position: absolute;  height:21px; width: 19px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox51" runat="server" 
                        style="z-index: 99; left: 775px; top: 305px; position: absolute;  height:21px; width: 19px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox52" runat="server" 
                        style="z-index: 99; left: 802px; top: 304px; position: absolute;  height:21px; width: 60px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox53" runat="server" 
                        style="z-index: 99; left: 871px; top: 305px; position: absolute;  height:20px; width: 34px; right: 279px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox54" runat="server" 
                        style="z-index: 99; left: 914px; top: 304px; position: absolute;  height:21px; width: 39px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 193px; top: 335px; position: absolute;  height:21px; width: 53px; right: 828px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>


                    <asp:TextBox ID="TextBox55" runat="server" 
                        style="z-index: 99; left: 256px; top: 335px; position: absolute;  height:21px; width: 78px; right: 740px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox56" runat="server" 
                        style="z-index: 99; left: 492px; top: 337px; position: absolute;  height:21px; width: 32px; right: 550px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox57" runat="server" 
                        style="z-index: 99; left: 539px; top: 337px; position: absolute;  height:21px; width: 25px; right: 510px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox58" runat="server" 
                        style="z-index: 99; left: 583px; top: 337px; position: absolute;  height:21px; width: 24px; right: 467px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox59" runat="server" 
                        style="z-index: 99; left: 630px; top: 335px; position: absolute;  height:21px; width: 24px; right: 422px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox60" runat="server" 
                        style="z-index: 99; left: 656px; top: 335px; position: absolute;  height:21px; width: 24px; right: 396px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox61" runat="server" 
                        style="z-index: 99; left: 684px; top: 335px; position: absolute;  height:21px; width: 57px; right: 335px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox62" runat="server" 
                        style="z-index: 99; left: 749px; top: 335px; position: absolute;  height:21px; width: 20px; right: 307px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox63" runat="server" 
                        style="z-index: 99; left: 775px; top: 335px; position: absolute;  height:21px; width: 20px; right: 281px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox64" runat="server" 
                        style="z-index: 99; left: 801px; top: 335px; position: absolute;  height:21px; width: 61px; right: 214px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox65" runat="server" 
                        style="z-index: 99; left: 871px; top: 335px; position: absolute;  height:21px; width: 34px; right: 171px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox42" runat="server" 
                        style="z-index: 99; left: 914px; top: 335px; position: absolute;  height:21px; width: 34px; right: 236px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox66" runat="server" 
                        style="z-index: 99; left: 920px; top: 303px; position: absolute;  height:21px; width: 34px; right: 230px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 193px; top: 362px; position: absolute;  height:21px; width: 53px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>


                    <asp:TextBox ID="TextBox67" runat="server" 
                        style="z-index: 99; left: 255px; top: 362px; position: absolute;  height:21px; width: 80px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox68" runat="server" 
                        style="z-index: 99; left: 467px; top: 365px; position: absolute;  height:19px; width: 153px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox69" runat="server" 
                        style="z-index: 99; left: 871px; top: 366px; position: absolute;  height:19px; width: 35px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox70" runat="server" 
                        style="z-index: 99; left: 914px; top: 366px; position: absolute;  height:19px; width: 35px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox71" runat="server" 
                        style="z-index: 99; left: 229px; top: 404px; position: absolute;  height:19px; width: 31px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox72" runat="server" 
                        style="z-index: 99; left: 278px; top: 404px; position: absolute;  height:19px; width: 27px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox73" runat="server" 
                        style="z-index: 99; left: 321px; top: 404px; position: absolute;  height:19px; width: 27px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox74" runat="server" 
                        style="z-index: 99; left: 368px; top: 404px; position: absolute;  height:19px; width: 27px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox75" runat="server" 
                        style="z-index: 99; top: 404px; position: absolute;  height:19px; width: 27px; left: 412px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox76" runat="server" 
                        style="z-index: 99; left: 456px; top: 404px; position: absolute;  height:19px; width: 27px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox77" runat="server" 
                        style="z-index: 99; left: 519px; top: 404px; position: absolute;  height:17px; width: 74px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox78" runat="server" 
                        style="z-index: 99; left: 628px; top: 418px; position: absolute;  height:21px; width: 114px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox79" runat="server" 
                        style="z-index: 99; left: 749px; top: 418px; position: absolute;  height:21px; width: 94px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>


                    <asp:TextBox ID="TextBox80" runat="server" 
                        style="z-index: 99; left: 853px; top: 419px; position: absolute;  height:21px; width: 95px; " 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox81" runat="server" 
                        style="z-index: 99; left: 187px; top: 451px; position: absolute;  height:21px; width: 127px; right: 762px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox82" runat="server" 
                        style="z-index: 99; left: 393px; top: 452px; position: absolute;  height:21px; width: 145px; right: 538px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox83" runat="server" 
                        style="z-index: 99; left: 625px; top: 450px; position: absolute;  height:21px; width: 145px; right: 414px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox84" runat="server" 
                        style="z-index: 99; left: 957px; top: 256px; position: absolute;  height:133px; width: 23px; right: 204px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                                                                          
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
