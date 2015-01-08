<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterMonPayPlan.aspx.cs" Inherits="BudgetPage_mainPages_AlterMonPayPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改月度用款计划</title>
<link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }
        .txt
        {
            width: 160px;
            height: 55px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        
                              
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- 表头结束 -->
    <div class="table_list">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="text-align: center;">
            <tr>
                <td colspan="7" class="tr1" align="left">
                    &nbsp;<strong>修改月度用款计划列表</strong>
                </td>
            </tr>
            <tr>
                <td width="14%" class="tr1" align="center" rowspan="2">
                    经济科目
                </td>
                <td width="14%" class="tr1" align="center" rowspan="2">
                    本年预算指示
                </td>
                <td rowspan="2" width="14%" class="tr1" align="center">
                    本年调整
                </td>
                <td rowspan="2" width="13%" class="tr1" align="center">
                    余额
                </td>
                <td colspan="3" width="45%" class="tr1" align="center">
                    1月
                </td>
                
            </tr>
            <tr>
                <td class="tr1" align="center" width="15%" >
                    基本支出
                </td>
                <td class="tr1" align="center" width="15%" >
                    项目支出
                </td>
                <td class="tr1" align="center" width="15%" >
                    合    计
                </td>
            </tr>
            <tr>
                <td>
                    经费支出
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server">2100.0</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server">2472.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server">4327.0</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server">42.45</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server">42743</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server">38.7</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    工资福利支出
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server">733.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server">727.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server">73273.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server">7327.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server">733.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server">676.7</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    基本工资
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server">7373.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server">373.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server">74337.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server">73.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox17" runat="server">7327.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox18" runat="server">73.7</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    职务工资
                </td>
                <td>
                    <asp:TextBox ID="TextBox19" runat="server">3743.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox20" runat="server">773.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox21" runat="server">295.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox22" runat="server">83.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox23" runat="server">2472.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox24" runat="server">377.74</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    级别工资
                </td>
                <td>
                    <asp:TextBox ID="TextBox25" runat="server">37.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox26" runat="server">772.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox27" runat="server">3473.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox28" runat="server">4502.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox29" runat="server">452.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox30" runat="server">954.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他工资
                </td>
                <td>
                    <asp:TextBox ID="TextBox31" runat="server">953.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox32" runat="server">971.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox33" runat="server">321.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox34" runat="server">9872.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox35" runat="server">9875.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox36" runat="server">65713.2</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    津贴补贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox37" runat="server">985.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox38" runat="server">4782.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox39" runat="server">9875.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox40" runat="server">542.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox41" runat="server">985.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox42" runat="server">3221.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    岗位津贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox43" runat="server">985.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox44" runat="server">316.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox45" runat="server">9787.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox46" runat="server">9875.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox47" runat="server">123.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox48" runat="server">9875.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    规范补贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox49" runat="server">987.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox50" runat="server">892.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox51" runat="server">8935.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox52" runat="server">3212.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox53" runat="server">98235.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox54" runat="server">6458.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    保留津贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox55" runat="server">98546.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox56" runat="server">655.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox57" runat="server">987.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox58" runat="server">631.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox59" runat="server">982.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox60" runat="server">3211.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    交通补助
                </td>
                <td>
                    <asp:TextBox ID="TextBox61" runat="server">95.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox62" runat="server">983.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox63" runat="server">31.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox64" runat="server">985.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox65" runat="server">785.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox66" runat="server">942.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他
                </td>
                <td>
                    <asp:TextBox ID="TextBox67" runat="server">3283.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox68" runat="server">965.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox69" runat="server">321.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox70" runat="server">987.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox71" runat="server">123.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox72" runat="server">325.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    奖金
                </td>
                <td>
                    <asp:TextBox ID="TextBox73" runat="server">325.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox74" runat="server">987.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox75" runat="server">321.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox76" runat="server">632.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox77" runat="server">6453.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox78" runat="server">321.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    社会保障缴费
                </td>
                <td>
                    <asp:TextBox ID="TextBox79" runat="server">987.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox80" runat="server">741.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox81" runat="server">3589.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox82" runat="server">123.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox83" runat="server">9872.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox84" runat="server">32.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    伙食补助
                </td>
                <td>
                   
                    <asp:TextBox ID="TextBox85" runat="server">637.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox86" runat="server">983.2</asp:TextBox>
                  
                </td>
                <td>
                    <asp:TextBox ID="TextBox87" runat="server">2321.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox88" runat="server">9787.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox89" runat="server">321.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox90" runat="server">74.3</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    其他福利工资补助
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox91" runat="server">982.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox92" runat="server">874.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox93" runat="server">329.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox94" runat="server">12.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox95" runat="server">98.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox96" runat="server">74.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    商品和服务支出
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox97" runat="server">694.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox98" runat="server">987.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox99" runat="server">243.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox100" runat="server">865.2</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox101" runat="server">3452.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox102" runat="server">987.6</asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    办公费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox103" runat="server">98.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox104" runat="server">45.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox105" runat="server">78.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox106" runat="server">7839.9</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox107" runat="server">785.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox108" runat="server">98.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    印刷费
                </td>
                <td>
                     
                    <asp:TextBox ID="TextBox109" runat="server">2332.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox110" runat="server">36.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox111" runat="server">74.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox112" runat="server">963.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox113" runat="server">123.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox114" runat="server">125.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    咨询费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox115" runat="server">125.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox116" runat="server">789.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox117" runat="server">12.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox118" runat="server">85.9</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox119" runat="server">123.6</asp:TextBox>
                   
                </td>
                <td>
                    <asp:TextBox ID="TextBox120" runat="server">75.9</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    手术费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox121" runat="server">96.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox122" runat="server">123.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox123" runat="server">963.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox124" runat="server">789.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox125" runat="server">96.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox126" runat="server">78.4</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    水费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox127" runat="server">98.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox128" runat="server">12.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox129" runat="server">987.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox130" runat="server">123.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox131" runat="server">35.9</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox132" runat="server">5555.6</asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    电费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox133" runat="server">896.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox134" runat="server">3221.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox135" runat="server">784.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox136" runat="server">78.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox137" runat="server">97.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox138" runat="server">321.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    邮电费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox139" runat="server">852.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox140" runat="server">743.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox141" runat="server">987.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox142" runat="server">364.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox143" runat="server">123.2</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox144" runat="server">9874.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    取暖费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox145" runat="server">23.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox146" runat="server">98.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox147" runat="server">36.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox148" runat="server">987.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox149" runat="server">987.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox150" runat="server">145.6</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    物业管理费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox151" runat="server">21.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox152" runat="server">26.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox153" runat="server">589.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox154" runat="server">654.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox155" runat="server">147.6</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox156" runat="server">678.4</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    交通费
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox157" runat="server">67.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox158" runat="server">98.1</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox159" runat="server">63.4</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox160" runat="server">987.4</asp:TextBox>
                  
                </td>
                <td>
                    <asp:TextBox ID="TextBox161" runat="server">23.2</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox162" runat="server">1059.3</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    保险费
                </td>
                <td>
                   
                    <asp:TextBox ID="TextBox163" runat="server">9582.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox164" runat="server">123.3</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox165" runat="server">47.9</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox166" runat="server">32.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox167" runat="server">986.5</asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="TextBox168" runat="server">41.2</asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    养路费
                </td>
                <td>
                    <asp:TextBox ID="TextBox169" runat="server">45.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox170" runat="server">46.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox171" runat="server">14.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox172" runat="server">96.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox173" runat="server">87.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox174" runat="server">43.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    燃油费
                </td>
                <td>
                    <asp:TextBox ID="TextBox175" runat="server">97.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox176" runat="server">13.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox177" runat="server">79.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox178" runat="server">15.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox179" runat="server">598.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox180" runat="server">785.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    修理费
                </td>
                <td>
                    <asp:TextBox ID="TextBox181" runat="server">34.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox182" runat="server">45.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox183" runat="server">95.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox184" runat="server">7645.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox185" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox186" runat="server">8000.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他机动车船费用
                </td>
                <td>
                    <asp:TextBox ID="TextBox187" runat="server">565.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox188" runat="server">652.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox189" runat="server">784.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox190" runat="server">635.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox191" runat="server">897.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox192" runat="server">374.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    差旅费
                </td>
                <td>
                    <asp:TextBox ID="TextBox193" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox194" runat="server">425.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox195" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox196" runat="server">467.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox197" runat="server">31.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox198" runat="server">749.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    出国费
                </td>
                <td>
                    <asp:TextBox ID="TextBox199" runat="server">655.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox200" runat="server">897.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox201" runat="server">324.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox202" runat="server">85.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox203" runat="server">12.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox204" runat="server">968.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    维修（护）费
                </td>
                <td>
                    <asp:TextBox ID="TextBox205" runat="server">85.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox206" runat="server">98.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox207" runat="server">78.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox208" runat="server">96.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox209" runat="server">765.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox210" runat="server">985.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    租赁费
                </td>
                <td>
                    <asp:TextBox ID="TextBox211" runat="server">87.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox212" runat="server">96.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox213" runat="server">85.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox214" runat="server">78.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox215" runat="server">98.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox216" runat="server">75.1</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    会议费
                </td>
                <td>
                    <asp:TextBox ID="TextBox217" runat="server">12.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox218" runat="server">85.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox219" runat="server">71.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox220" runat="server">987.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox221" runat="server">96.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox222" runat="server">1100.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    培训费
                </td>
                <td>
                    <asp:TextBox ID="TextBox223" runat="server">74.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox224" runat="server">63.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox225" runat="server">42.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox226" runat="server">855.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox227" runat="server">98.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox228" runat="server">99.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    科室业务培训
                </td>
                <td>
                    <asp:TextBox ID="TextBox229" runat="server">65.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox230" runat="server">431.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox231" runat="server">497.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox232" runat="server">68.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox233" runat="server">84.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox234" runat="server">98.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    职工教育培训
                </td>
                <td>
                    <asp:TextBox ID="TextBox235" runat="server">52.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox236" runat="server">79.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox237" runat="server">46.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox238" runat="server">835.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox239" runat="server">798.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox240" runat="server">1435.2</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    招待费
                </td>
                <td>
                    <asp:TextBox ID="TextBox241" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox242" runat="server">455.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox243" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox244" runat="server">487.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox245" runat="server">535.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox246" runat="server">568.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    劳务费
                </td>
                <td>
                    <asp:TextBox ID="TextBox247" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox248" runat="server">135.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox249" runat="server">124.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox250" runat="server">598.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox251" runat="server">94.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox252" runat="server">895.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    临时人员工资
                </td>
                <td>
                    <asp:TextBox ID="TextBox253" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox254" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox255" runat="server">71.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox256" runat="server">4638.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox257" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox258" runat="server">4385.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    后勤人员费用
                </td>
                <td>
                    <asp:TextBox ID="TextBox259" runat="server">598.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox260" runat="server">535.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox261" runat="server">235.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox262" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox263" runat="server">598.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox264" runat="server">438.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    工会经费
                </td>
                <td>
                    <asp:TextBox ID="TextBox265" runat="server">895.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox266" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox267" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox268" runat="server">798.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox269" runat="server">428.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox270" runat="server">79.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    福利费
                </td>
                <td>
                    <asp:TextBox ID="TextBox271" runat="server">438.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox272" runat="server">965.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox273" runat="server">982.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox274" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox275" runat="server">748.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox276" runat="server">986.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    工作人员福利
                </td>
                <td>
                    <asp:TextBox ID="TextBox277" runat="server">35.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox278" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox279" runat="server">35.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox280" runat="server">689.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox281" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox282" runat="server">498.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    集体福利费
                </td>
                <td>
                    <asp:TextBox ID="TextBox283" runat="server">97.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox284" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox285" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox286" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox287" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox288" runat="server">468.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他补助费
                </td>
                <td>
                    <asp:TextBox ID="TextBox289" runat="server">68.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox290" runat="server">84.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox291" runat="server">235.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox292" runat="server">865.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox293" runat="server">135.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox294" runat="server">498.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    被装购置费
                </td>
                <td>
                    <asp:TextBox ID="TextBox295" runat="server">85.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox296" runat="server">398.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox297" runat="server">147.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox298" runat="server">359.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox299" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox300" runat="server">184.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他商品和服务支出
                </td>
                <td>
                    <asp:TextBox ID="TextBox301" runat="server">968.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox302" runat="server">135.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox303" runat="server">188.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox304" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox305" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox306" runat="server">7.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    宣传费
                </td>
                <td>
                    <asp:TextBox ID="TextBox307" runat="server">135.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox308" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox309" runat="server">4135.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox310" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox311" runat="server">36.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox312" runat="server">5620.3</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    稽查办案费
                </td>
                <td>
                    <asp:TextBox ID="TextBox313" runat="server">35.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox314" runat="server">2568.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox315" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox316" runat="server">45.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox317" runat="server">854.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox318" runat="server">965.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    征收管理费
                </td>
                <td>
                    <asp:TextBox ID="TextBox319" runat="server">85.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox320" runat="server">452.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox321" runat="server">96.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox322" runat="server">321.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox323" runat="server">845.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox324" runat="server">1253.6</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    协税护税费
                </td>
                <td>
                    <asp:TextBox ID="TextBox325" runat="server">78.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox326" runat="server">598.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox327" runat="server">438.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox328" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox329" runat="server">198.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox330" runat="server">468.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他
                </td>
                <td>
                    <asp:TextBox ID="TextBox331" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox332" runat="server">85.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox333" runat="server">465.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox334" runat="server">538.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox335" runat="server">5.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox336" runat="server">897.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    对个人和家庭的补助
                </td>
                <td>
                    <asp:TextBox ID="TextBox337" runat="server">35.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox338" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox339" runat="server">895.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox340" runat="server">465.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox341" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox342" runat="server">465.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    离休费
                </td>
                <td>
                    <asp:TextBox ID="TextBox343" runat="server">953.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox344" runat="server">568.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox345" runat="server">465.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox346" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox347" runat="server">168.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox348" runat="server">197.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    退休费
                </td>
                <td>
                    <asp:TextBox ID="TextBox349" runat="server">465.1</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox350" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox351" runat="server">1385.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox352" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox353" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox354" runat="server">466.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    退职（役)费
                </td>
                <td>
                    <asp:TextBox ID="TextBox355" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox356" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox357" runat="server">438.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox358" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox359" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox360" runat="server">498.2</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    抚恤金
                </td>
                <td>
                    <asp:TextBox ID="TextBox361" runat="server">68.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox362" runat="server">463.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox363" runat="server">463.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox364" runat="server">463.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox365" runat="server">463.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox366" runat="server">463.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    生活补助
                </td>
                <td>
                    <asp:TextBox ID="TextBox367" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox368" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox369" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox370" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox371" runat="server">138.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox372" runat="server">138.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    救济费
                </td>
                <td>
                    <asp:TextBox ID="TextBox373" runat="server">465.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox374" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox375" runat="server">465.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox376" runat="server">498.7</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox377" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox378" runat="server">468.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    医疗费
                </td>
                <td>
                    <asp:TextBox ID="TextBox379" runat="server">35.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox380" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox381" runat="server">468.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox382" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox383" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox384" runat="server">435.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    奖励金
                </td>
                <td>
                    <asp:TextBox ID="TextBox385" runat="server">35.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox386" runat="server">435.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox387" runat="server">435.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox388" runat="server">435.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox389" runat="server">435.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox390" runat="server">435.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    助学金
                </td>
                <td>
                    <asp:TextBox ID="TextBox391" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox392" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox393" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox394" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox395" runat="server">588.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox396" runat="server">588.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    住房公积金
                </td>
                <td>
                    <asp:TextBox ID="TextBox397" runat="server">95.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox398" runat="server">465.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox399" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox400" runat="server">438.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox401" runat="server">438.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox402" runat="server">463.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    提租补贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox403" runat="server">98.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox404" runat="server">438.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox405" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox406" runat="server">468.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox407" runat="server">498.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox408" runat="server">468.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    住房补贴
                </td>
                <td>
                    <asp:TextBox ID="TextBox409" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox410" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox411" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox412" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox413" runat="server">468.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox414" runat="server">468.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他对个人和家庭补助支出
                </td>
                <td>
                    <asp:TextBox ID="TextBox415" runat="server">85.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox416" runat="server">639.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox417" runat="server">85.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox418" runat="server">789.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox419" runat="server">184.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox420" runat="server">897.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    其他资本性支出
                </td>
                <td>
                    <asp:TextBox ID="TextBox421" runat="server">874.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox422" runat="server">52.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox423" runat="server">58.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox424" runat="server">474.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox425" runat="server">125.3</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox426" runat="server">475.8</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    房屋建筑构建
                </td>
                <td>
                    <asp:TextBox ID="TextBox427" runat="server">987.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox428" runat="server">639.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox429" runat="server">174.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox430" runat="server">985.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox431" runat="server">845.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox432" runat="server">965.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    办公设备购置
                </td>
                <td>
                    <asp:TextBox ID="TextBox433" runat="server">45.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox434" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox435" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox436" runat="server">474.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox437" runat="server">985.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox438" runat="server">123.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    专用设备购建
                </td>
                <td>
                    <asp:TextBox ID="TextBox439" runat="server">96.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox440" runat="server">85.2</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox441" runat="server">875.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox442" runat="server">958.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox443" runat="server">35.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox444" runat="server">96.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    交通工具购置
                </td>
                <td>
                    <asp:TextBox ID="TextBox445" runat="server">985.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox446" runat="server">635.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox447" runat="server">258.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox448" runat="server">369.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox449" runat="server">874.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox450" runat="server">985.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    大型修缮
                </td>
                <td>
                    <asp:TextBox ID="TextBox451" runat="server">358.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox452" runat="server">987.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox453" runat="server">36.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox454" runat="server">987.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox455" runat="server">85.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox456" runat="server">987.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    信息网络建设
                </td>
                <td>
                    <asp:TextBox ID="TextBox457" runat="server">96.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox458" runat="server">874.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox459" runat="server">159.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox460" runat="server">357.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox461" runat="server">825.9</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox462" runat="server">57.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    计算机设备购置费
                </td>
                <td>
                    <asp:TextBox ID="TextBox463" runat="server">58.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox464" runat="server">471.6</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox465" runat="server">285.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox466" runat="server">987.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox467" runat="server">395.8</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox468" runat="server">6358.5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    计算机应用费
                </td>
                <td>
                    <asp:TextBox ID="TextBox469" runat="server">985.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox470" runat="server">369.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox471" runat="server">247.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox472" runat="server">98.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox473" runat="server">385.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox474" runat="server">358.4</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    计算机应用费
                </td>
                <td>
                    <asp:TextBox ID="TextBox475" runat="server">935.5</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox476" runat="server">358.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox477" runat="server">987.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox478" runat="server">96.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox479" runat="server">35.4</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox480" runat="server">36.5</asp:TextBox>
                </td>
            </tr>

        </table>
    </div>
    <div class="table_list">
       <table >
           <tr >
            <td class="tr1" align ="center" >
                <asp:Button ID="btnAlter" CssClass ="btns" runat="server" Text="  修  改  " OnClick="btnAlter_Click" />
            </td>
            </tr>
       </table>
    </div>
    </form>
</body>
</html>
