<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="AnalysePage_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6;IE=7;IE=8" />
    <title></title>
    <link href="ExtJs4.0/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="ExtJs4.0/ext-all-debug.js" type="text/javascript"></script>
    <script src="ExtJs4.0/locale/ext-lang-zh_CN.js" type="text/javascript"></script>
    <script src="Js/jquery-1.7.2.min.js"></script>

      <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }

        a
        {
            text-decoration: none;
        }

        ul li
        {
            list-style: none;
        }

        .head
        {
            width: 100%;
            height: 120px;
            margin: 0;
            padding: 0;
            background-color: #6387a6;
        }

        .head_center
        {
            margin: auto;
            width: 1254px;
            height: 100px;
        }

        .head_center_left
        {
            height: 29px;
            padding-top: 26px;
            font-size: 35px;
            font: bold;
            color: white;
            float: left;
            width: 800px;
        }

        .head_center_right
        {
            float: right;
            text-align: right;
            font-size: 18px;
            font-weight: bold;
            color: white;
            width: 454px;
            padding-top: 45px;
        }

            .head_center_right li
            {
                padding-top: 6px;
            }

        .wrap
        {
            margin: auto;
            width: 1254px;
            height: 100%;
        }

        .navigation
        {
            background: url(Image/navigation.png);
            width: 1254px;
            height: 40px;
            padding-top: 10px;
            margin-top: 8px;
            margin-bottom: 8px;
            font-size: 24px;
            font-weight: bold;
        }

        .analy_methods
        {
            height: 89px;
            margin-top: 10px;
        }

            .analy_methods ul li
            {
                float: left;
            }

        .analy_income
        {
            margin-top: 2px;
            background: url(Image/analy_income.png);
            height: 82px;
            width: 357px;
        }

            .analy_income ul
            {
                width: 40px;
            }

                .analy_income ul li
                {
                    float: left;
                    font: bold;
                }

        .analy_expenses
        {
            background: url(Image/analy_expenses.png);
            height: 82px;
            width: 357px;
            margin-top: 2px;
            margin-left: 91px;
            margin-right: 91px;
        }

        .analy_assets
        {
            margin-top: 2px;
            background: url(Image/analy_assets.png);
            height: 82px;
            width: 357px;
        }

        #LeftContainer
        {
            padding-left: 20px;
        }

        .analy_chart1
        {
            height: 270px;
        }

            .analy_chart1 ul li
            {
                float: left;
            }

        .analy_income_chart
        {
            margin-top: 20px;
            height: 270px;
            width: 430px;
        }

        .analy_chart2
        {
            height: 390px;
            margin-top: 40px;
        }

        .analy_chart2_left
        {
            width: 306px;
            float: left;
        }

            .analy_chart2_left li
            {
                margin-top: 16px;
            }

        .analy_chart2_right
        {
            width: 908px;
            float: right;
            margin-left: 40px;
        }

        .bottom
        {
            margin: auto;
            width: 100%;
            height: 44px;
            background: url(Image/bottom_bg.png);
            margin-top: 30px;
            text-align: center;
            line-height: 44px;
        }

        #head_menu ul
        {
            z-index: 999;
            position: absolute;
            display: none;
            color: #555555;
            background-color: #EFEFF2;
            font-size: 15px;
            width: 120px;
            text-align: center;
        }
    </style>

    <script type="text/javascript">

        $(function () {
            $("#head_menu li ").hover(function () {
                $(this).children("ul").show();
            }, function () { $(this).children("ul").hide(); });

            $("#head_menu li ul li ").hover(function () {
                $(this).css("backgroundColor", "#bcd2ee");
            }, function () { $(this).css("backgroundColor", "#EFEFF2"); });

        });

        //******Top1Method*********
        function CreateAxes(dataStore) {
            Ext.create('Ext.panel.Panel', {
                width: 400,
                height: 258,
                border: false,
                renderTo: 'AxesContainer',
                layout: 'fit',
                items: [{
                    xtype: 'chart',
                    store: dataStore,
                    axes: [{
                        type: 'Numeric',          //配置坐标轴类型为数值坐标
                        dashSize: 4,            //坐标轴前导线条长度,默认为3
                        position: 'left',         //配置坐标在左侧
                        fields: ['ParVal'],       //指定坐标对应的字段
                        title: '预算数',          //配置坐标标题
                        grid: {
                            //奇数行
                            odd: {
                                opacity: 1,            //不透明
                                fill: '#FFFF99',        //表格内的填充颜色
                                stroke: '#FF3300',      //表格线颜色
                                'stroke-width': 0.5     //表格线宽度
                            },
                            //偶数行
                            even: {
                                opacity: 0,             //透明
                                stroke: '#6600CC',    //表格线颜色
                                'stroke-width': 0.5     //表格线宽度
                            }
                        },
                        majorTickSteps: 6, //主区间数
                        minorTickSteps: 5, //副区间数
                    }, {
                        type: 'Category', //配置坐标轴类型为目录坐标
                        position: 'bottom', // 配置坐标在底部
                        fields: ['ParName'],   //指定坐标对应的字段
                        grid: true,        //启用表格
                        title: ''      //配置坐标轴标题--地区
                    }],
                    series: [{
                        type: 'line',
                        axis: 'left',
                        xField: 'ParName', //横轴坐标
                        yField: 'ParVal'//纵轴坐标
                    }]
                }]
            });
        }
        //******Top1Method*********

        //******Top2Method*********
        function CreateCenterPie(dataStore) {
            Ext.create('widget.panel', {
                width: 480,
                height: 270,
                border: false,
                renderTo: 'CenterContainer',
                layout: 'fit',
                items: [{
                    xtype: 'chart',
                    store: dataStore,
                    animate: true,          //是否启用动画效果
                    legend: {
                        position: 'bottom'      //图例位置

                    },
                    shadow: true,
                    series: [{
                        type: 'pie',    //图表序列类型
                        donut: 30,      //麦圈图中空部分半径
                        //lengthField : 'growing', //扇形区长度字段 
                        field: 'percentage', //对应饼状角度的字段名
                        showInLegend: true,  //是否显示在图例当中
                        colorSet: ["#D6D6D6", "#BCEE68", "#FFAA00", "#483D8B", '#87CEFF', '#1E90FF', "#FF3E96"], //颜色
                        label: {
                            field: 'age',// 标签字段名
                            contrast: true,
                            color: '#FFFF00',
                            renderer: function (v) {//自定义标签渲染函数
                                return "[" + v + "]";
                            },
                            display: 'left', //标签显现方式
                            font: '12px "Lucida Grande"'
                        },
                        highlight: {
                            segment: {
                                margin: 15   //空白区域宽度
                            }
                        },
                        tips: {
                            trackMouse: true, //是否启用鼠标跟踪
                            width: 50,
                            height: 28,
                            renderer: function (storeItem) { //自定义渲染函数
                                var title = storeItem.get('percentage') + '%';
                                this.setTitle(title);
                            }
                        }
                    }]
                }]
            });
        }
        //******Top2Method*********

        //******Top3Method*********
        function CreateRightPie(dataStore) {
            Ext.create('widget.panel', {
                width: 320,
                height: 270,
                border: false,
                renderTo: 'RightContainer',
                layout: 'fit',
                items: [{
                    xtype: 'chart',
                    store: dataStore,
                    animate: true,          //是否启用动画效果
                    legend: {
                        position: 'bottom'      //图例位置
                    },
                    shadow: true,
                    series: [{
                        type: 'pie',    //图表序列类型
                        donut: 30,      //麦圈图中空部分半径
                        //lengthField : 'growing', //扇形区长度字段 
                        field: 'percentage', //对应饼状角度的字段名
                        showInLegend: true,  //是否显示在图例当中
                        colorSet: ['#FF6699', '#1E90FF', '#B4EEB4', '#FFC125'], //颜色
                        label: {
                            field: 'age',// 标签字段名
                            contrast: true,
                            color: '#FFFF00',
                            renderer: function (v) {//自定义标签渲染函数
                                return "[" + v + "]";
                            },
                            display: 'middle', //标签显现方式
                            font: '12px "Lucida Grande"'
                        },
                        highlight: {
                            segment: {
                                margin: 15   //空白区域宽度
                            }
                        },
                        tips: {
                            trackMouse: true, //是否启用鼠标跟踪
                            width: 50,
                            height: 28,
                            renderer: function (storeItem) { //自定义渲染函数
                                var title = storeItem.get('percentage') + '%';
                                this.setTitle(title);
                            }
                        }
                    }]
                }]
            });
        }
        //******Top3Method*********


        //***底部柱状图绑定****

        function CreateBottmChart(dataStore) {
            Ext.get("BContainer").update("");

            Ext.create('Ext.panel.Panel', {
                //title: '费用分布图',
                width: 908,
                height: 370,
                border: false,
                renderTo: "BContainer",
                layout: 'fit',
                items: [{
                    xtype: 'chart',
                    store: dataStore,
                    axes: [{
                        type: 'Numeric',
                        position: 'left',
                        minimum: 0,  //数轴最小值
                        maximum: 1000, //数轴最大值
                        fields: ['proportion', 'growing', 'baseNum'],  //同时展示两个数据
                        title: '经费(万元)'
                    }, {
                        type: 'Category', //配置数轴类型为目录坐标
                        position: 'bottom', // 配置数轴在底部
                        fields: ['ageRange'],   //指定数轴对应的字段
                        title: ''      //配置坐标轴标题
                    }],
                    legend: {
                        position: 'bottom'      //图例位置
                    },
                    series: [{
                        type: 'column',
                        axis: 'left',
                        xField: 'ageRange', //X轴字段
                        yField: ['proportion', 'growing'], //y轴字段
                        title: ["2013年度", "2012年度"],  //配置图例说明字段
                        label: {
                            field: ['proportion', 'growing', 'baseNum'], //标签字段名
                            display: 'outside',         //标签显现方式
                            font: '13px "Lucida Grande"',   //字体
                            renderer: function (v) {    //自定义标签渲染函数
                                return v;
                            }
                        }
                    }]

                }]
            });
        }

        function CreateBottomStore(index)
        {
            if (index == 1) {
                var dsOne = new Ext.data.JsonStore({
                    fields: ['ageRange', 'proportion', 'growing'],
                    data: [
                    { ageRange: '1月', proportion: 797, growing: 674, baseNum: 55 },
                    { ageRange: '2月', proportion: 53, growing: 254, baseNum: 28 },
                    { ageRange: '3月', proportion: 236, growing: 240, baseNum: 28 },
                    { ageRange: '4月', proportion: 24, growing: 94, baseNum: 28 },
                    { ageRange: '5月', proportion: 231, growing: 267, baseNum: 28 },
                    { ageRange: '6月', proportion: 97, growing: 186, baseNum: 28 },
                    { ageRange: '7月', proportion: 328, growing: 876, baseNum: 28 },
                    { ageRange: '8月', proportion: 36, growing: 182, baseNum: 28 },
                    { ageRange: '9月', proportion: 396, growing: 222, baseNum: 20 },
                    { ageRange: '10月', proportion: 146, growing: 373, baseNum: 28 },
                    { ageRange: '11月', proportion: 275, growing: 164, baseNum: 28 },
                    { ageRange: '12月', proportion: 0, growing: 175, baseNum: 28 }
                    ]
                });
                CreateBottmChart(dsOne);
            }
            else if (index == 2) {
                var dsTwo = new Ext.data.JsonStore({
                    fields: ['ageRange', 'proportion', 'growing'],
                    data: [
                    { ageRange: '1月', proportion: 97, growing: 674, baseNum: 55 },
                    { ageRange: '2月', proportion: 153, growing: 254, baseNum: 28 },
                    { ageRange: '3月', proportion: 36, growing: 40, baseNum: 28 },
                    { ageRange: '4月', proportion: 241, growing: 194, baseNum: 28 },
                    { ageRange: '5月', proportion: 231, growing: 67, baseNum: 28 },
                    { ageRange: '6月', proportion: 97, growing: 86, baseNum: 28 },
                    { ageRange: '7月', proportion: 28, growing: 76, baseNum: 28 },
                    { ageRange: '8月', proportion: 36, growing: 182, baseNum: 28 },
                    { ageRange: '9月', proportion: 96, growing: 122, baseNum: 20 },
                    { ageRange: '10月', proportion: 46, growing: 373, baseNum: 28 },
                    { ageRange: '11月', proportion: 75, growing: 164, baseNum: 28 },
                    { ageRange: '12月', proportion: 22, growing: 175, baseNum: 28 }
                    ]
                });
                CreateBottmChart(dsTwo);
            }
            else if (index == 3) {
                var dsThree = new Ext.data.JsonStore({
                    fields: ['ageRange', 'proportion', 'growing'],
                    data: [
                    { ageRange: '1月', proportion: 111, growing: 674, baseNum: 55 },
                    { ageRange: '2月', proportion: 153, growing: 254, baseNum: 28 },
                    { ageRange: '3月', proportion: 36, growing: 240, baseNum: 28 },
                    { ageRange: '4月', proportion: 24, growing: 94, baseNum: 28 },
                    { ageRange: '5月', proportion: 31, growing: 267, baseNum: 28 },
                    { ageRange: '6月', proportion: 197, growing: 186, baseNum: 28 },
                    { ageRange: '7月', proportion: 28, growing: 876, baseNum: 28 },
                    { ageRange: '8月', proportion: 136, growing: 182, baseNum: 28 },
                    { ageRange: '9月', proportion: 96, growing: 222, baseNum: 20 },
                    { ageRange: '10月', proportion: 46, growing: 373, baseNum: 28 },
                    { ageRange: '11月', proportion: 275, growing: 164, baseNum: 28 },
                    { ageRange: '12月', proportion: 1, growing: 175, baseNum: 28 }
                    ]
                });
                CreateBottmChart(dsThree);
            }
            else
            {
                var dsFour = new Ext.data.JsonStore({
                    fields: ['ageRange', 'proportion', 'growing'],
                    data: [
                    { ageRange: '1月', proportion: 70, growing: 1, baseNum: 55 },
                    { ageRange: '2月', proportion: 4, growing: 20, baseNum: 28 },
                    { ageRange: '3月', proportion: 1, growing: 0, baseNum: 28 },
                    { ageRange: '4月', proportion: 60, growing: 1, baseNum: 28 },
                    { ageRange: '5月', proportion: 0, growing: 4, baseNum: 28 },
                    { ageRange: '6月', proportion: 1, growing: 4, baseNum: 28 },
                    { ageRange: '7月', proportion: 2, growing: 1, baseNum: 28 },
                    { ageRange: '8月', proportion: 1, growing: 0, baseNum: 28 },
                    { ageRange: '9月', proportion: 17, growing: 33, baseNum: 20 },
                    { ageRange: '10月', proportion: 552, growing: 1, baseNum: 28 },
                    { ageRange: '11月', proportion: 1, growing: 234, baseNum: 28 },
                    { ageRange: '12月', proportion: 0, growing: 0, baseNum: 28 }
                    ]
                });
                CreateBottmChart(dsFour);
            }
            return false;
        }

            //***底部柱状图绑定****

        Ext.onReady(function () {

            //******Top1Axes******
            var AxesData = new Ext.data.JsonStore({
                fields: ['ParName', 'ParVal', 'Percentage'],
                data: [
                    { "ParName": "咸宁市", "ParVal": 2152.00, "Percentage": 9.60 },
                    { "ParName": "嘉鱼县", "ParVal": 2665.00, "Percentage": 11.89 },
                    { "ParName": "赤壁市", "ParVal": 5658.00, "Percentage": 25.24 },
                    { "ParName": "通山县", "ParVal": 2112.00, "Percentage": 9.42 },
                    { "ParName": "崇阳县", "ParVal": 3654.00, "Percentage": 16.30 },
                    { "ParName": "通城县", "ParVal": 3584.00, "Percentage": 15.99 },
                    { "ParName": "咸安区", "ParVal": 2596.00, "Percentage": 11.58 }
                ]
            });
            CreateAxes(AxesData);
            //******Top1Axes******

            //******Top2Pie******
            var CenterPieData = new Ext.data.JsonStore({
                fields: ['age', 'percentage', 'growing'],
                data: [
                    { age: '赤壁市', percentage: 24, growing: 12 },
                    { age: '嘉鱼县', percentage: 70, growing: 28 },
                    { age: '咸宁市', percentage: 24, growing: 12 },
                    { age: '咸安区', percentage: 24, growing: 12 },
                    { age: '通城县', percentage: 70, growing: 28 },
                    { age: '崇阳县', percentage: 24, growing: 12 },
                    { age: '通山县', percentage: 70, growing: 28 }
                ]
            });
            CreateCenterPie(CenterPieData);
            //******Top2Pie******

            //******Top3Pie******
            var RightPieData = new Ext.data.JsonStore({
                fields: ['age', 'percentage', 'growing'],
                data: [
                    { age: '项目支出', percentage: 24, growing: 12 },
                    { age: '专项支出', percentage: 65, growing: 28 },
                    { age: '公用', percentage: 30, growing: 12 },
                    { age: '人员支出', percentage: 40, growing: 28 }
                ]
            });
            CreateRightPie(RightPieData);
            //******Bottom1******
            CreateBottomStore(1);

        });



    </script>
</head>
<body>
    <form id="form1" runat="server">
               <div class="head">
        <div class="head_center">
            <div class="head_center_left">
                <img src="Image/c1.png" />
                地税财务数据分析展示系统
            </div>

            <div class="head_center_right">
                <ul>
                    <li>
                        <a href="../Login.aspx"><img src="Image/exit.png" />退出</a></li>
                    <li>
                        <ul id="head_menu">
                            <li style="float: right;">信息公开
                                <ul>
                                    <li><a href="mainPages/InfoOvertGrids.aspx" target="_blank">信息公开详细</a></li>
                                    <li><a href="mainPages/InfoOvertList.aspx" target="_blank">信息公开图表</a></li>
                                    <li><a href="mainPages/InfoOvertTotal.aspx" target="_blank">信息公开统计</a></li>
                                </ul>
                            </li>
                            <li style="float: right; padding-left: 40px; padding-right: 40px;">自选分析
                                <ul>
                                    <li><a href="mainPages/GenYearIncome.aspx" target="_blank">年度收入分析</a></li>
                                    <li><a href="mainPages/GenYearOutlay.aspx" target="_blank">年度支出分析</a></li>
                                    <li><a href="mainPages/GenMonIncome.aspx" target="_blank">月度收入分析</a></li>
                                    <li><a href="mainPages/GenMonOutlay.aspx" target="_blank">月度支出分析</a></li>
                                </ul>
                            </li>

                            <li style="float: right;">定制分析
                                <ul class="head_menu_two">
                                    <li><a href="mainPages/UnitsPerCoeff.aspx" target="_blank">人均系数</a></li>
                                    <li><a href="mainPages/StaffCosts.aspx" target="_blank">人员支出</a></li>
                                    <li><a href="mainPages/PubExpend.aspx" target="_blank">公用支出</a></li>
                                    <li><a href="mainPages/ProExpend.aspx" target="_blank">项目支出</a></li>
                                    <li><a href="mainPages/GenReveAnalyTb.aspx" target="_blank">年度收入分析</a></li>
                                    <li><a href="mainPages/GenExpendAnalyTb.aspx" target="_blank">年度支出分析</a></li>
                                    <li><a href="mainPages/GenEAMonthTb.aspx" target="_blank">月度收入分析</a></li>
                                    <li><a href="mainPages/GenYearIncome.aspx" target="_blank">月度支出分析</a></li>
                                    <li><a href="mainPages/FixedAssetList.aspx" target="_blank">固定资产</a></li>
                                </ul>
                            </li>

                             <li style="float: right;padding-right: 40px;"><a href="Default.aspx">查看全部</a></li>
                        </ul>
                    </li>
                </ul>

            </div>
        </div>
    </div>
            <div class="wrap">
          
             <div class="analy_methods">
            <ul>
                <li>
                    <div class="analy_income">
                        <ul>
                            <li style="padding-top: 8px; font-size: 23px; color: white; padding-left: 290px;">2625</li>

                            <li style="padding-top: 13px; padding-left: 278px; font-size: 18px; font-weight: bold; color: #79B3DC">82%</li>
                        </ul>

                    </div>
                </li>
                <li>
                    <div class="analy_expenses">
                        <ul>
                            <li style="padding-top: 8px; font-size: 23px; color: white; padding-left: 282px;">3761</li>

                            <li style="padding-top: 12px; padding-left: 278px; font-size: 18px; font-weight: bold; color: #A0C35F">99%</li>
                        </ul>

                    </div>
                </li>
                <li>
                    <div class="analy_assets">
                        <ul>
                            <li style="padding-top: 8px; font-size: 23px; color: white; padding-left: 300px;">708</li>

                            <li style="padding-top: 12px; padding-left: 278px; font-size: 18px; font-weight: bold; color: #E4A750">237%</li>
                        </ul>

                    </div>
                </li>
            </ul>
        </div>
            <div class="analy_chart1">
                <ul>
                    <li>
                        <div id="AxesContainer" class="analy_income_chart">
                        </div>
                    </li>
                    <li>
                        <div id="CenterContainer">
                        </div>
                    </li>
                    <li>
                        <div id="RightContainer">
                        </div>
                    </li>
                </ul>
            </div>
            <div class="analy_chart2">
               <div class="analy_chart2_left">
                <ul>
                    <li>
                        <asp:ImageButton ID="ibtn1" OnClientClick="return CreateBottomStore(1);" runat="server" ImageUrl="Image/a1.png" /><span style="position: absolute; margin-left: -54px; margin-top: 10px; font-size: 23px; color: white;">2625</span><span style="position: absolute; margin-left: -60px; margin-top: 46px; font-weight: bold; font-size: 18px; color: #76AF3C;">18%</span></li>
                    <li>
                        <asp:ImageButton ID="ibtn2" runat="server"  OnClientClick="return CreateBottomStore(2);" ImageUrl="Image/a3.png" /><span style="position: absolute; margin-left: -40px; margin-top: 10px; font-size: 23px; color: white;">331</span><span style="position: absolute; margin-left: -58px; margin-top: 46px; font-weight: bold; font-size: 18px; color: #374359;">31%</span></li>
                    <li>
                        <asp:ImageButton ID="ibtn3" runat="server" OnClientClick="return CreateBottomStore(3);" ImageUrl="Image/a4.png" /><span style="position: absolute; margin-left: -40px; margin-top: 10px; font-size: 23px; color: white;">123</span><span style="position: absolute; margin-left: -58px; margin-top: 46px; font-weight: bold; font-size: 18px; color: #374359;">44%</span></li>
                    <li>
                        <asp:ImageButton ID="ibtn4" runat="server" OnClientClick="return CreateBottomStore(4);" ImageUrl="Image/a2.png" /><span style="position: absolute; margin-left: -54px; margin-top: 10px; font-size: 23px; color: white;">708</span><span style="position: absolute; margin-left: -60px; margin-top: 46px; font-weight: bold; font-size: 18px; color: #DE2C2C;">73%</span></li>
                </ul>
            </div>
                <div class="analy_chart2_right">
                    <div id="BContainer"></div>
                </div>
            </div>
                </div>
      
        <div class="bottom">@武汉铭天信息科技有限公司 2013</div>
    </form>
</body>
</html>
