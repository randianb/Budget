<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyTravelCost.aspx.cs" Inherits="mainPages_ApplyTravelCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>差旅费申请</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />

    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>

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

   <script type="text/javascript">
       $(function () {
           $("#radTra").click(function () {
               window.location.href = "ApplyTravelCost.aspx"
           });
           $("#radMed").click(function () {
               window.location.href = "ApplyMediCost.aspx"
           });
           $("#radOth").click(function () {
               window.location.href = "ApplyOtherCost.aspx"
           });
       });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <!-- 表头结束 -->
    <div class="table_list">        
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>差旅费申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt="" src="../../img/BaoXiao/差旅费报销单.png" />
                    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 99; left: 221px; top: 110px;
                        position: absolute; width: 245px; height: 21px; bottom: 517px; right: 668px;"
                        TabIndex="1" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 99; left: 816px; top: 112px;
                        position: absolute; width: 29px; height: 21px; bottom: 515px; right: 289px;"
                        TabIndex="2" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" Style="z-index: 99; left: 868px; top: 112px;
                        position: absolute; width: 29px; height: 21px; bottom: 515px; right: 237px;"
                        TabIndex="3" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" Style="z-index: 99; left: 918px; top: 113px;
                        position: absolute; width: 29px; height: 21px; bottom: 514px; right: 187px;"
                        TabIndex="4" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" Style="z-index: 99; left: 113px; top: 192px;
                        position: absolute; width: 21px; height: 19px; bottom: 437px; right: 1000px;"
                        TabIndex="5" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" Style="z-index: 99; left: 141px; top: 192px;
                        position: absolute; width: 21px; height: 19px; bottom: 437px; "
                        TabIndex="6" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" Style="z-index: 99; left: 169px; top: 193px;
                        position: absolute; width: 21px; height: 19px; bottom: 436px; right: 944px;"
                        TabIndex="7" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" Style="z-index: 99; left: 197px; top: 192px;
                        position: absolute; width: 38px; height: 19px; bottom: 437px; right: 899px;"
                        TabIndex="8" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" Style="z-index: 99; left: 243px; top: 192px;
                        position: absolute; width: 19px; height: 19px; bottom: 437px; right: 872px;"
                        TabIndex="9" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" Style="z-index: 99; left: 268px; top: 193px;
                        position: absolute; width: 17px; height: 19px; bottom: 436px; right: 849px;"
                        TabIndex="10" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" Style="z-index: 99; left: 292px; top: 192px;
                        position: absolute; width: 17px; height: 19px; bottom: 437px; right: 825px;"
                        TabIndex="11" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" Style="z-index: 99; left: 316px; top: 194px;
                        position: absolute; width: 39px; height: 19px; bottom: 435px; right: 779px;"
                        TabIndex="12" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" Style="z-index: 99; left: 363px; top: 195px;
                        position: absolute; width: 38px; height: 17px; bottom: 436px; right: 733px;"
                        TabIndex="13" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" Style="z-index: 99; left: 409px; top: 195px;
                        position: absolute; width: 55px; height: 17px; bottom: 436px; right: 670px;"
                        TabIndex="14" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" Style="z-index: 99; left: 473px; top: 195px;
                        position: absolute; width: 55px; height: 17px; bottom: 436px; right: 606px;"
                        TabIndex="15" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" Style="z-index: 99; left: 536px; top: 195px;
                        position: absolute; width: 33px; height: 17px; bottom: 436px; right: 565px;"
                        TabIndex="16" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" Style="z-index: 99; left: 577px; top: 195px;
                        position: absolute; width: 48px; height: 17px; bottom: 436px; right: 509px;"
                        TabIndex="17" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" Style="z-index: 99; left: 634px; top: 195px;
                        position: absolute; width: 65px; height: 17px; bottom: 436px; "
                        TabIndex="18" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox19" runat="server" Style="z-index: 99; left: 708px; top: 195px;
                        position: absolute; width: 91px; height: 17px; bottom: 436px; right: 335px;"
                        TabIndex="19" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox20" runat="server" Style="z-index: 99; left: 809px; top: 195px;
                        position: absolute; width: 73px; height: 17px; bottom: 436px; "
                        TabIndex="20" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox21" runat="server" Style="z-index: 99; left: 893px; top: 195px;
                        position: absolute; width: 49px; height: 17px; bottom: 436px; right: 192px;"
                        TabIndex="21" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox22" runat="server" Style="z-index: 99; left: 950px; top: 194px;
                        position: absolute; width: 49px; height: 17px; bottom: 437px; right: 135px;"
                        TabIndex="22" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox23" runat="server" Style="z-index: 99; left: 113px; top: 218px;
                        position: absolute; width: 21px; height: 19px; bottom: 411px; "
                        TabIndex="23" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox24" runat="server" Style="z-index: 99; left: 141px; top: 217px;
                        position: absolute; width: 21px; height: 19px; bottom: 412px; "
                        TabIndex="24" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox25" runat="server" Style="z-index: 99; left: 169px; top: 218px;
                        position: absolute; width: 21px; height: 19px; bottom: 411px; right: 944px;"
                        TabIndex="25" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox26" runat="server" Style="z-index: 99; left: 197px; top: 219px;
                        position: absolute; width: 38px; height: 19px; bottom: 410px; "
                        TabIndex="26" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox27" runat="server" Style="z-index: 99; left: 244px; top: 218px;
                        position: absolute; width: 16px; height: 19px; bottom: 411px; "
                        TabIndex="27" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox28" runat="server" Style="z-index: 99; left: 269px; top: 218px;
                        position: absolute; width: 16px; height: 19px; bottom: 411px; "
                        TabIndex="28" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox29" runat="server" Style="z-index: 99; left: 293px; top: 218px;
                        position: absolute; width: 16px; height: 19px; bottom: 411px; "
                        TabIndex="29" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox30" runat="server" Style="z-index: 99; left: 317px; top: 219px;
                        position: absolute; width: 37px; height: 19px; bottom: 410px; "
                        TabIndex="30" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox31" runat="server" Style="z-index: 99; left: 363px; top: 219px;
                        position: absolute; width: 37px; height: 19px; bottom: 410px; "
                        TabIndex="31" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox32" runat="server" Style="z-index: 99; left: 410px; top: 219px;
                        position: absolute; width: 54px; height: 19px; bottom: 410px; right: 670px;"
                        TabIndex="32" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox33" runat="server" Style="z-index: 99; left: 473px; top: 220px;
                        position: absolute; width: 54px; height: 19px; bottom: 409px; right: 607px;"
                        TabIndex="33" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox34" runat="server" Style="z-index: 99; left: 537px; top: 219px;
                        position: absolute; width: 30px; height: 19px; bottom: 410px; "
                        TabIndex="34" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox35" runat="server" Style="z-index: 99; left: 580px; top: 218px;
                        position: absolute; width: 43px; height: 19px; bottom: 411px; right: 511px;"
                        TabIndex="35" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox36" runat="server" Style="z-index: 99; left: 634px; top: 220px;
                        position: absolute; width: 63px; height: 19px; bottom: 409px; right: 437px;"
                        TabIndex="36" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox37" runat="server" Style="z-index: 99; left: 708px; top: 219px;
                        position: absolute; width: 88px; height: 19px; bottom: 410px; "
                        TabIndex="37" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox38" runat="server" Style="z-index: 99; left: 808px; top: 219px;
                        position: absolute; width: 75px; height: 19px; bottom: 410px; "
                        TabIndex="38" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox39" runat="server" Style="z-index: 99; left: 893px; top: 220px;
                        position: absolute; width: 48px; height: 19px; bottom: 409px; "
                        TabIndex="39" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox40" runat="server" Style="z-index: 99; left: 950px; top: 219px;
                        position: absolute; width: 48px; height: 19px; bottom: 410px; "
                        TabIndex="40" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox41" runat="server" Style="z-index: 99; left: 113px; top: 243px;
                        position: absolute; width: 21px; height: 19px; "
                        TabIndex="41" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox42" runat="server" Style="z-index: 99; left: 141px; top: 243px;
                        position: absolute; width: 21px; height: 19px; bottom: 386px; "
                        TabIndex="42" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox43" runat="server" Style="z-index: 99; left: 169px; top: 244px;
                        position: absolute; width: 21px; height: 19px; bottom: 385px; right: 944px;"
                        TabIndex="43" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox44" runat="server" Style="z-index: 99; left: 197px; top: 244px;
                        position: absolute; width: 38px; height: 19px; bottom: 385px; "
                        TabIndex="44" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox45" runat="server" Style="z-index: 99; left: 243px; top: 245px;
                        position: absolute; width: 16px; height: 19px; bottom: 384px; "
                        TabIndex="45" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox46" runat="server" Style="z-index: 99; left: 268px; top: 245px;
                        position: absolute; width: 16px; height: 19px; bottom: 384px; "
                        TabIndex="46" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox47" runat="server" Style="z-index: 99; left: 292px; top: 245px;
                        position: absolute; width: 16px; height: 19px; bottom: 384px; "
                        TabIndex="47" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox48" runat="server" Style="z-index: 99; left: 316px; top: 244px;
                        position: absolute; width: 37px; height: 19px; bottom: 385px; "
                        TabIndex="48" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox49" runat="server" Style="z-index: 99; left: 362px; top: 246px;
                        position: absolute; width: 37px; height: 19px; bottom: 383px; "
                        TabIndex="49" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox50" runat="server" Style="z-index: 99; left: 410px; top: 245px;
                        position: absolute; width: 54px; height: 19px; bottom: 384px; right: 670px;"
                        TabIndex="50" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox51" runat="server" Style="z-index: 99; left: 474px; top: 246px;
                        position: absolute; width: 54px; height: 19px; bottom: 383px; right: 606px;"
                        TabIndex="51" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox52" runat="server" Style="z-index: 99; left: 537px; top: 246px;
                        position: absolute; width: 30px; height: 19px; bottom: 383px; "
                        TabIndex="52" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox53" runat="server" Style="z-index: 99; left: 580px; top: 245px;
                        position: absolute; width: 43px; height: 19px; bottom: 384px; right: 511px;"
                        TabIndex="53" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox54" runat="server" Style="z-index: 99; left: 633px; top: 246px;
                        position: absolute; width: 63px; height: 19px; bottom: 383px; right: 438px;"
                        TabIndex="54" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox55" runat="server" Style="z-index: 99; left: 709px; top: 246px;
                        position: absolute; width: 88px; height: 19px; bottom: 383px; "
                        TabIndex="55" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox56" runat="server" Style="z-index: 99; left: 807px; top: 246px;
                        position: absolute; width: 75px; height: 19px; bottom: 383px; "
                        TabIndex="56" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox57" runat="server" Style="z-index: 99; left: 891px; top: 246px;
                        position: absolute; width: 48px; height: 19px; bottom: 383px; "
                        TabIndex="57" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox58" runat="server" Style="z-index: 99; left: 949px; top: 245px;
                        position: absolute; width: 48px; height: 19px; bottom: 384px; "
                        TabIndex="58" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox59" runat="server" Style="z-index: 99; left: 113px; top: 271px;
                        position: absolute; width: 21px; height: 19px; "
                        TabIndex="59" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox60" runat="server" Style="z-index: 99; left: 140px; top: 270px;
                        position: absolute; width: 21px; height: 19px; bottom: 359px; right: 973px;"
                        TabIndex="60" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox61" runat="server" Style="z-index: 99; left: 168px; top: 271px;
                        position: absolute; width: 21px; height: 19px; bottom: 358px; right: 945px;"
                        TabIndex="61" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox62" runat="server" Style="z-index: 99; left: 197px; top: 271px;
                        position: absolute; width: 38px; height: 19px; bottom: 358px; "
                        TabIndex="62" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox63" runat="server" Style="z-index: 99; left: 244px; top: 270px;
                        position: absolute; width: 16px; height: 19px; bottom: 359px; "
                        TabIndex="63" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox64" runat="server" Style="z-index: 99; left: 268px; top: 271px;
                        position: absolute; width: 16px; height: 19px; bottom: 358px; "
                        TabIndex="64" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox65" runat="server" Style="z-index: 99; left: 292px; top: 271px;
                        position: absolute; width: 16px; height: 19px; bottom: 358px; "
                        TabIndex="65" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox66" runat="server" Style="z-index: 99; left: 316px; top: 271px;
                        position: absolute; width: 37px; height: 19px; bottom: 358px; "
                        TabIndex="66" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox67" runat="server" Style="z-index: 99; left: 364px; top: 271px;
                        position: absolute; width: 37px; height: 19px; bottom: 358px; "
                        TabIndex="67" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox68" runat="server" Style="z-index: 99; left: 410px; top: 271px;
                        position: absolute; width: 54px; height: 19px; bottom: 358px; right: 670px;"
                        TabIndex="68" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox69" runat="server" Style="z-index: 99; left: 474px; top: 271px;
                        position: absolute; width: 54px; height: 19px; bottom: 358px; right: 606px;"
                        TabIndex="69" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox70" runat="server" Style="z-index: 99; left: 538px; top: 272px;
                        position: absolute; width: 30px; height: 19px; bottom: 357px; "
                        TabIndex="70" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox71" runat="server" Style="z-index: 99; left: 580px; top: 271px;
                        position: absolute; width: 43px; height: 19px; bottom: 358px; right: 511px;"
                        TabIndex="71" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox72" runat="server" Style="z-index: 99; left: 633px; top: 272px;
                        position: absolute; width: 63px; height: 19px; bottom: 357px; right: 438px;"
                        TabIndex="72" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox73" runat="server" Style="z-index: 99; left: 707px; top: 272px;
                        position: absolute; width: 88px; height: 19px; bottom: 357px; "
                        TabIndex="73" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox74" runat="server" Style="z-index: 99; left: 807px; top: 272px;
                        position: absolute; width: 75px; height: 19px; bottom: 357px; "
                        TabIndex="74" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox75" runat="server" Style="z-index: 99; left: 892px; top: 272px;
                        position: absolute; width: 48px; height: 19px; bottom: 357px; "
                        TabIndex="75" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox76" runat="server" Style="z-index: 99; left: 950px; top: 272px;
                        position: absolute; width: 48px; height: 19px; bottom: 357px; "
                        TabIndex="76" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox77" runat="server" Style="z-index: 99; left: 113px; top: 296px;
                        position: absolute; width: 21px; height: 19px; "
                        TabIndex="77" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox78" runat="server" Style="z-index: 99; left: 141px; top: 297px;
                        position: absolute; width: 21px; height: 19px; bottom: 332px; right: 972px;"
                        TabIndex="78" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox79" runat="server" Style="z-index: 99; left: 169px; top: 297px;
                        position: absolute; width: 21px; height: 19px; bottom: 332px; right: 944px;"
                        TabIndex="79" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox80" runat="server" Style="z-index: 99; left: 197px; top: 297px;
                        position: absolute; width: 38px; height: 19px; bottom: 332px; "
                        TabIndex="80" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox81" runat="server" Style="z-index: 99; left: 244px; top: 296px;
                        position: absolute; width: 16px; height: 19px; bottom: 333px; "
                        TabIndex="81" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox82" runat="server" Style="z-index: 99; left: 269px; top: 296px;
                        position: absolute; width: 16px; height: 19px; bottom: 333px; "
                        TabIndex="82" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox83" runat="server" Style="z-index: 99; left: 292px; top: 297px;
                        position: absolute; width: 16px; height: 19px; bottom: 332px; "
                        TabIndex="83" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox84" runat="server" Style="z-index: 99; left: 316px; top: 297px;
                        position: absolute; width: 37px; height: 19px; bottom: 332px; "
                        TabIndex="84" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox85" runat="server" Style="z-index: 99; left: 363px; top: 297px;
                        position: absolute; width: 37px; height: 19px; bottom: 332px; right: 734px;"
                        TabIndex="85" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox86" runat="server" Style="z-index: 99; left: 409px; top: 297px;
                        position: absolute; width: 54px; height: 19px; bottom: 332px; right: 671px;"
                        TabIndex="86" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox87" runat="server" Style="z-index: 99; left: 473px; top: 297px;
                        position: absolute; width: 54px; height: 19px; bottom: 332px; right: 607px;"
                        TabIndex="87" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox88" runat="server" Style="z-index: 99; left: 538px; top: 297px;
                        position: absolute; width: 30px; height: 19px; bottom: 332px; "
                        TabIndex="88" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox89" runat="server" Style="z-index: 99; left: 578px; top: 297px;
                        position: absolute; width: 43px; height: 19px; bottom: 332px; right: 513px;"
                        TabIndex="89" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox90" runat="server" Style="z-index: 99; left: 634px; top: 297px;
                        position: absolute; width: 63px; height: 19px; bottom: 332px; right: 437px;"
                        TabIndex="90" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox91" runat="server" Style="z-index: 99; left: 706px; top: 298px;
                        position: absolute; width: 88px; height: 19px; bottom: 331px; "
                        TabIndex="91" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox92" runat="server" Style="z-index: 99; left: 807px; top: 297px;
                        position: absolute; width: 75px; height: 19px; bottom: 332px; right: 252px;"
                        TabIndex="92" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox93" runat="server" Style="z-index: 99; left: 893px; top: 297px;
                        position: absolute; width: 48px; height: 19px; bottom: 332px; "
                        TabIndex="93" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox94" runat="server" Style="z-index: 99; left: 949px; top: 296px;
                        position: absolute; width: 48px; height: 19px; bottom: 333px; "
                        TabIndex="94" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox95" runat="server" Style="z-index: 99; left: 113px; top: 322px;
                        position: absolute; width: 21px; height: 19px; "
                        TabIndex="95" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox96" runat="server" Style="z-index: 99; left: 140px; top: 321px;
                        position: absolute; width: 21px; height: 19px; bottom: 308px; right: 973px;"
                        TabIndex="96" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox97" runat="server" Style="z-index: 99; left: 168px; top: 322px;
                        position: absolute; width: 21px; height: 19px; bottom: 307px; right: 945px;"
                        TabIndex="97" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox98" runat="server" Style="z-index: 99; left: 198px; top: 323px;
                        position: absolute; width: 38px; height: 19px; bottom: 306px; "
                        TabIndex="98" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox99" runat="server" Style="z-index: 99; left: 244px; top: 322px;
                        position: absolute; width: 16px; height: 19px; bottom: 307px; "
                        TabIndex="99" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox100" runat="server" Style="z-index: 99; left: 268px; top: 322px;
                        position: absolute; width: 16px; height: 19px; bottom: 307px; "
                        TabIndex="100" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox101" runat="server" Style="z-index: 99; left: 292px; top: 322px;
                        position: absolute; width: 16px; height: 19px; bottom: 307px; "
                        TabIndex="101" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox102" runat="server" Style="z-index: 99; left: 316px; top: 323px;
                        position: absolute; width: 37px; height: 19px; bottom: 306px; "
                        TabIndex="102" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox103" runat="server" Style="z-index: 99; left: 362px; top: 323px;
                        position: absolute; width: 37px; height: 19px; bottom: 306px; "
                        TabIndex="103" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox104" runat="server" Style="z-index: 99; left: 409px; top: 323px;
                        position: absolute; width: 54px; height: 19px; bottom: 306px; right: 671px;"
                        TabIndex="104" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox105" runat="server" Style="z-index: 99; left: 474px; top: 323px;
                        position: absolute; width: 54px; height: 19px; bottom: 306px; right: 606px;"
                        TabIndex="105" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox106" runat="server" Style="z-index: 99; left: 537px; top: 324px;
                        position: absolute; width: 30px; height: 19px; bottom: 305px; "
                        TabIndex="106" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox107" runat="server" Style="z-index: 99; left: 578px; top: 323px;
                        position: absolute; width: 43px; height: 19px; bottom: 306px; right: 513px;"
                        TabIndex="107" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox108" runat="server" Style="z-index: 99; left: 634px; top: 324px;
                        position: absolute; width: 63px; height: 19px; bottom: 305px; right: 437px;"
                        TabIndex="108" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox109" runat="server" Style="z-index: 99; left: 708px; top: 324px;
                        position: absolute; width: 88px; height: 19px; bottom: 305px; "
                        TabIndex="109" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox110" runat="server" Style="z-index: 99; left: 808px; top: 324px;
                        position: absolute; width: 75px; height: 19px; bottom: 305px; "
                        TabIndex="110" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox111" runat="server" Style="z-index: 99; left: 893px; top: 324px;
                        position: absolute; width: 48px; height: 19px; bottom: 305px; "
                        TabIndex="111" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox112" runat="server" Style="z-index: 99; left: 948px; top: 324px;
                        position: absolute; width: 48px; height: 19px; bottom: 305px; "
                        TabIndex="112" BorderStyle="None"></asp:TextBox>

                    <asp:TextBox ID="TextBox113" runat="server" Style="z-index: 99; left: 363px; top: 349px;
                        position: absolute; width: 37px; height: 19px; bottom: 280px; "
                        TabIndex="113" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox114" runat="server" Style="z-index: 99; left: 409px; top: 349px;
                        position: absolute; width: 54px; height: 19px; bottom: 280px; right: 671px;"
                        TabIndex="114" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox115" runat="server" Style="z-index: 99; left: 474px; top: 349px;
                        position: absolute; width: 54px; height: 19px; bottom: 280px; right: 606px;"
                        TabIndex="115" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox116" runat="server" Style="z-index: 99; left: 537px; top: 350px;
                        position: absolute; width: 30px; height: 19px; bottom: 279px; "
                        TabIndex="116" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox117" runat="server" Style="z-index: 99; left: 579px; top: 349px;
                        position: absolute; width: 43px; height: 19px; bottom: 280px; right: 512px;"
                        TabIndex="117" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox118" runat="server" Style="z-index: 99; left: 634px; top: 348px;
                        position: absolute; width: 63px; height: 19px; bottom: 281px; right: 437px;"
                        TabIndex="118" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox119" runat="server" Style="z-index: 99; left: 708px; top: 349px;
                        position: absolute; width: 88px; height: 19px; bottom: 280px; "
                        TabIndex="119" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox120" runat="server" Style="z-index: 99; left: 808px; top: 350px;
                        position: absolute; width: 75px; height: 19px; bottom: 279px; "
                        TabIndex="120" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox121" runat="server" Style="z-index: 99; left: 894px; top: 350px;
                        position: absolute; width: 48px; height: 19px; bottom: 279px; "
                        TabIndex="121" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox122" runat="server" Style="z-index: 99; left: 949px; top: 350px;
                        position: absolute; width: 48px; height: 19px; bottom: 279px; "
                        TabIndex="122" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox123" runat="server" Style="z-index: 99; left: 236px; top: 374px;
                        position: absolute; width: 298px; height: 19px; bottom: 255px; "
                        TabIndex="123" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox124" runat="server" Style="z-index: 99; left: 231px; top: 399px;
                        position: absolute; width: 124px; height: 19px; right: 779px;"
                        TabIndex="124" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox125" runat="server" Style="z-index: 99; left: 458px; top: 400px;
                        position: absolute; width: 124px; height: 19px; "
                        TabIndex="125" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox126" runat="server" Style="z-index: 99; left: 782px; top: 400px;
                        position: absolute; width: 124px; height: 19px; "
                        TabIndex="126" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox127" runat="server" Style="z-index: 99; left: 189px; top: 426px;
                        position: absolute; width: 182px; height: 16px; "
                        TabIndex="127" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox128" runat="server" Style="z-index: 99; left: 469px; top: 427px;
                        position: absolute; width: 162px; height: 16px; "
                        TabIndex="128" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox129" runat="server" Style="z-index: 99; left: 817px; top: 427px;
                        position: absolute; width: 162px; height: 16px; "
                        TabIndex="129" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="TextBox130" runat="server" Style="z-index: 99; left: 1010px; top: 214px;
                        position: absolute; width: 16px; height: 107px; "
                        TabIndex="130" BorderStyle="None"></asp:TextBox>
                       
                </td>
            </tr> 
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCon" CssClass="btns" runat="server" Text=" 确  认 " OnClick="btnCon_Click" />
                    <asp:Button ID="btnAlter" CssClass="btns" runat="server" Text=" 修  改 " OnClick="btnAlter_Click"   />
                    <asp:Button ID="btnunit" runat="server" CssClass="btns" Text="填写通用报销单" OnClick="btnunit_Click" />
                    <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 返  回 " OnClick="btnCan_Click" />
                    <asp:Button ID="btnPrint" runat="server" CssClass="btns" OnClientClick="window.print()" Text="打  印" />
                    <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>
    </form>
</body>
</html>
