<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyMediCost.aspx.cs" Inherits="mainPages_ApplyMediCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>医疗费申请</title>
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
        $(function(){
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
        <%--<table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
            <tr>
                <td colspan="4" class="tr1">
                    &nbsp;<strong>医疗费申请</strong>
                </td>
            </tr>
            <tr>
                <td width="15%" class="tr1 right">
                    申请类别
                </td>
                <td width="15%">
                    
                    <asp:RadioButton ID="radMed" runat="server" Checked="true" GroupName="AppType" Text="医疗费 "/>
                    &nbsp;&nbsp;
                </td>
                <td width="15%" class="tr1 right">
                    附件一：
                </td>
                <td width="55%">
                    <asp:RadioButton ID="rb1" runat="server" Checked="true" GroupName="FJ" Text="会议费 "/>
                    &nbsp;<asp:RadioButton ID="rb2" runat="server" GroupName="FJ" Text="培训费 "/>
                    &nbsp;<asp:RadioButton ID="rb3" runat="server"  GroupName="FJ" Text="交通费 "/>
                    &nbsp;<asp:RadioButton ID="rb4" runat="server" GroupName="FJ" Text="接待费 "/>
                  <asp:Button ID="Button1" runat="server" CssClass="btns" Text="新 建" OnClick="Button1_Click"  />
                </td>
            </tr>
            
        </table>--%>
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="4" class="tr1" align="left">
                    &nbsp;<strong>医疗费申请表单填写</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <img alt=""  Width="909" src="../../img/BaoXiao/医疗费报销单.png"/><%--<asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; top: 146px; position: absolute;  height:20px; width: 37px; right: 449px;" 
                        TabIndex="31" BorderStyle="None" ></asp:TextBox>--%>
                        <asp:TextBox ID="TextBox1" runat="server" 
                        style="z-index: 99; left: 312px; top: 115px; position: absolute;  height:20px; width: 284px; right: 538px;" 
                        TabIndex="1" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        style="z-index: 99; left: 769px; top: 117px; position: absolute;  height:20px; width: 140px; right: 225px;" 
                        TabIndex="2" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        style="z-index: 99; left: 179px; top: 146px; position: absolute;  height:20px; width: 44px; right: 911px;" 
                        TabIndex="3" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" 
                        style="z-index: 99; left: 663px; top: 146px; position: absolute;  height:20px; width: 62px; right: 409px;" 
                        TabIndex="4" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" 
                        style="z-index: 99; left: 748px; top: 146px; position: absolute;  height:20px; width: 59px; right: 327px;" 
                        TabIndex="5" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" 
                        style="z-index: 99; left: 828px; top: 146px; position: absolute;  height:20px; width: 53px; right: 253px;" 
                        TabIndex="6" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" 
                        style="z-index: 99; left: 71px; top: 235px; position: absolute;  height:22px; width: 50px; right: 1013px;" 
                        TabIndex="7" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" 
                        style="z-index: 99; left: 125px; top: 235px; position: absolute;  height:22px; width: 50px; right: 959px;" 
                        TabIndex="8" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox9" runat="server" 
                        style="z-index: 99; left: 183px; top: 235px; position: absolute;  height:22px; width: 243px; right: 708px;" 
                        TabIndex="9" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox10" runat="server" 
                        style="z-index: 99; left: 435px; top: 235px; position: absolute;  height:22px; width: 138px; right: 561px;" 
                        TabIndex="10" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox11" runat="server" 
                        style="z-index: 99; left: 579px; top: 234px; position: absolute;  height:23px; width: 82px; right: 473px;" 
                        TabIndex="11" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox12" runat="server" 
                        style="z-index: 99; left: 671px; top: 234px; position: absolute;  height:23px; width: 82px; right: 381px;" 
                        TabIndex="12" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox13" runat="server" 
                        style="z-index: 99; left: 762px; top: 235px; position: absolute;  height:23px; width: 82px; right: 290px;" 
                        TabIndex="13" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" 
                        style="z-index: 99; left: 852px; top: 235px; position: absolute;  height:23px; width: 152px; right: 130px;" 
                        TabIndex="14" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" 
                        style="z-index: 99; left: 69px; top: 265px; position: absolute;  height:23px; width: 51px; right: 1014px;" 
                        TabIndex="15" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" 
                        style="z-index: 99; left: 125px; top: 265px; position: absolute;  height:23px; width: 51px; right: 958px;" 
                        TabIndex="16" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox17" runat="server" 
                        style="z-index: 99; left: 183px; top: 265px; position: absolute;  height:23px; width: 243px; right: 708px;" 
                        TabIndex="17" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox18" runat="server" 
                        style="z-index: 99; left: 434px; top: 264px; position: absolute;  height:23px; width: 137px; right: 563px;" 
                        TabIndex="18" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox19" runat="server" 
                        style="z-index: 99; left: 579px; top: 265px; position: absolute;  height:23px; width: 83px; right: 472px;" 
                        TabIndex="19" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox20" runat="server" 
                        style="z-index: 99; left: 671px; top: 265px; position: absolute;  height:23px; width: 83px; right: 380px;" 
                        TabIndex="20" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox21" runat="server" 
                        style="z-index: 99; left: 761px; top: 265px; position: absolute;  height:23px; width: 83px; right: 290px;" 
                        TabIndex="21" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox22" runat="server" 
                        style="z-index: 99; left: 852px; top: 266px; position: absolute;  height:23px; width: 154px; right: 128px;" 
                        TabIndex="22" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox23" runat="server" 
                        style="z-index: 99; left: 66px; top: 299px; position: absolute;  height:23px; width: 53px; right: 1015px;" 
                        TabIndex="23" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox24" runat="server" 
                        style="z-index: 99; left: 125px; top: 296px; position: absolute;  height:23px; width: 53px; right: 956px;" 
                        TabIndex="24" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox25" runat="server" 
                        style="z-index: 99; left: 183px; top: 296px; position: absolute;  height:23px; width: 246px; right: 705px;" 
                        TabIndex="25" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox26" runat="server" 
                        style="z-index: 99; left: 435px; top: 295px; position: absolute;  height:23px; width: 134px; right: 565px;" 
                        TabIndex="26" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox27" runat="server" 
                        style="z-index: 99; left: 579px; top: 296px; position: absolute;  height:23px; width: 84px; right: 471px;" 
                        TabIndex="27" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox28" runat="server" 
                        style="z-index: 99; left: 670px; top: 295px; position: absolute;  height:23px; width: 84px; right: 380px;" 
                        TabIndex="28" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox29" runat="server" 
                        style="z-index: 99; left: 761px; top: 296px; position: absolute;  height:23px; width: 84px; right: 289px;" 
                        TabIndex="29" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox30" runat="server" 
                        style="z-index: 99; left: 851px; top: 296px; position: absolute;  height:23px; width: 154px; right: 129px;" 
                        TabIndex="30" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox31" runat="server" 
                        style="z-index: 99; left: 66px; top: 326px; position: absolute;  height:23px; width: 54px; right: 1014px;" 
                        TabIndex="31" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox32" runat="server" 
                        style="z-index: 99; left: 126px; top: 326px; position: absolute;  height:23px; width: 52px; right: 956px;" 
                        TabIndex="32" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox33" runat="server" 
                        style="z-index: 99; left: 182px; top: 325px; position: absolute;  height:23px; width: 246px; right: 706px;" 
                        TabIndex="33" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox34" runat="server" 
                        style="z-index: 99; left: 434px; top: 325px; position: absolute;  height:23px; width: 136px; right: 564px;" 
                        TabIndex="34" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox35" runat="server" 
                        style="z-index: 99; left: 579px; top: 325px; position: absolute;  height:23px; width: 86px; right: 469px;" 
                        TabIndex="35" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox36" runat="server" 
                        style="z-index: 99; left: 670px; top: 326px; position: absolute;  height:23px; width: 86px; right: 378px;" 
                        TabIndex="36" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox37" runat="server" 
                        style="z-index: 99; left: 761px; top: 326px; position: absolute;  height:23px; width: 86px; right: 287px;" 
                        TabIndex="37" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox38" runat="server" 
                        style="z-index: 99; left: 852px; top: 325px; position: absolute;  height:23px; width: 155px; right: 127px;" 
                        TabIndex="38" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox39" runat="server" 
                        style="z-index: 99; left: 70px; top: 357px; position: absolute;  height:23px; width: 47px; right: 1017px;" 
                        TabIndex="39" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox40" runat="server" 
                        style="z-index: 99; left: 127px; top: 356px; position: absolute;  height:23px; width: 47px; right: 960px;" 
                        TabIndex="40" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox41" runat="server" 
                        style="z-index: 99; left: 183px; top: 357px; position: absolute;  height:23px; width: 240px; right: 711px;" 
                        TabIndex="41" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox42" runat="server" 
                        style="z-index: 99; left: 434px; top: 356px; position: absolute;  height:23px; width: 135px; right: 565px;" 
                        TabIndex="42" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox43" runat="server" 
                        style="z-index: 99; left: 579px; top: 356px; position: absolute;  height:23px; width: 83px; right: 472px;" 
                        TabIndex="43" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox44" runat="server" 
                        style="z-index: 99; left: 670px; top: 357px; position: absolute;  height:23px; width: 83px; right: 381px;" 
                        TabIndex="44" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox45" runat="server" 
                        style="z-index: 99; left: 761px; top: 356px; position: absolute;  height:23px; width: 83px; right: 290px;" 
                        TabIndex="45" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox46" runat="server" 
                        style="z-index: 99; left: 853px; top: 356px; position: absolute;  height:23px; width: 152px; right: 129px;" 
                        TabIndex="46" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox47" runat="server" 
                        style="z-index: 99; left: 69px; top: 387px; position: absolute;  height:23px; width: 51px; right: 1014px;" 
                        TabIndex="47" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox48" runat="server" 
                        style="z-index: 99; left: 126px; top: 386px; position: absolute;  height:23px; width: 51px; right: 957px;" 
                        TabIndex="48" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox49" runat="server" 
                        style="z-index: 99; left: 183px; top: 387px; position: absolute;  height:23px; width: 242px; right: 709px;" 
                        TabIndex="49" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox50" runat="server" 
                        style="z-index: 99; left: 434px; top: 387px; position: absolute;  height:23px; width: 138px; right: 562px;" 
                        TabIndex="50" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox51" runat="server" 
                        style="z-index: 99; left: 581px; top: 388px; position: absolute;  height:22px; width: 81px; right: 472px;" 
                        TabIndex="51" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox52" runat="server" 
                        style="z-index: 99; left: 671px; top: 387px; position: absolute;  height:22px; width: 81px; right: 382px;" 
                        TabIndex="52" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox53" runat="server" 
                        style="z-index: 99; left: 763px; top: 387px; position: absolute;  height:22px; width: 81px; right: 290px;" 
                        TabIndex="53" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox54" runat="server" 
                        style="z-index: 99; left: 854px; top: 388px; position: absolute;  height:22px; width: 148px; right: 132px;" 
                        TabIndex="54" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox55" runat="server" 
                        style="z-index: 99; left: 305px; top: 417px; position: absolute;  height:22px; width: 48px; right: 781px;" 
                        TabIndex="55" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox56" runat="server" 
                        style="z-index: 99; left: 376px; top: 416px; position: absolute;  height:22px; width: 48px; right: 710px;" 
                        TabIndex="56" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox57" runat="server" 
                        style="z-index: 99; left: 448px; top: 417px; position: absolute;  height:22px; width: 48px; right: 638px;" 
                        TabIndex="57" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox58" runat="server" 
                        style="z-index: 99; left: 518px; top: 417px; position: absolute;  height:22px; width: 48px; right: 568px;" 
                        TabIndex="58" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox59" runat="server" 
                        style="z-index: 99; left: 591px; top: 415px; position: absolute;  height:22px; width: 48px; right: 495px;" 
                        TabIndex="59" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox60" runat="server" 
                        style="z-index: 99; left: 663px; top: 417px; position: absolute;  height:22px; width: 48px; right: 423px;" 
                        TabIndex="60" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox61" runat="server" 
                        style="z-index: 99; left: 753px; top: 418px; position: absolute;  height:22px; width: 120px; right: 261px;" 
                        TabIndex="61" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox62" runat="server" 
                        style="z-index: 99; left: 221px; top: 448px; position: absolute;  height:22px; width: 139px; right: 774px;" 
                        TabIndex="62" BorderStyle="None" ></asp:TextBox>
                    <asp:TextBox ID="TextBox63" runat="server" 
                        style="z-index: 99; left: 843px; top: 448px; position: absolute;  height:22px; width: 139px; right: 152px;" 
                        TabIndex="63" BorderStyle="None" ></asp:TextBox>

                    
                                                                
                </td>
            </tr>
            <tr>
                <td colspan="4"  class="tr1" align="left">
                    &nbsp;&nbsp;
                  <asp:Button ID="btnCon" runat="server" CssClass="btns" Text="确  认" OnClick="btnCon_Click" />
                    <asp:Button ID="btnAlter" CssClass="btns" runat="server" Text=" 修  改 " OnClick="btnAlter_Click"   />
                    <asp:Button ID="btnunit" runat="server" CssClass="btns" Text="填写通用报销单" OnClick="btnunit_Click" />
                   <asp:Button ID="btnCan" runat="server" CssClass="btns" Text="返  回" OnClick="btnCan_Click" />
                    <asp:Button ID="btnPrint" runat="server" CssClass="btns" OnClientClick="window.print()" Text="打  印" />
                    <asp:Label ID="lblMResult" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>
    </form>
</body>
</html>
