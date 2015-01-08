<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BraFundUsagStat.aspx.cs" Inherits="WebPage_BraFundInquiry_BraFundUsagStat" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>各科、所经费使用情况统计表</title>
    <link href="../../css/whsystem.css" rel="stylesheet" />

    <link href="../../css/whtable.css" rel="stylesheet" />

    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        html, body {
            margin: 0;
            height: 100%;
        }

        .txt {
            width: 160px;
            height: 22px;
            border: solid 1px #A3C8F5;
            vertical-align: middle;
        }
    </style>
    <script>

        var interval;
        $(function () {

            flagred();
        });

        function flagred() {
            interval = setInterval(changeStyle, "1000");
        }
        function changeStyle() {
            if ($("#gridview-1009 table tr").length > 0) {

                $("#gridview-1009 table tr").each(function () {
                    if ($(this).find("td:first div").text() == "区局合计") {
                        //$(this).find("td:first div").attr("style", "color:red;font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(1) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(2) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(3) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(4) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(5) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(6) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(7) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:eq(8) div").attr("style", "font-weight:bold;text-align:center;");
                        //$(this).find("td:last div").attr("style", "font-weight:bold;text-align:center;");

                        $(this).find("div").each(function (index) {
                            if (index == 0) {
                                $(this).attr("style", "color:red;font-weight:bold;text-align:center;");
                            }
                            else {
                                $(this).attr("style", "font-weight:bold;text-align:center;");
                            }
                        });

                    }
                });
                clearTimeout(interval);
            }
        }

        var click = function () {
            var storeCount = Ext.getCmp('GridPanel1').getStore().getCount();
            var store = Ext.getCmp('GridPanel1').getStore();
            var records = store.getRange(0, storeCount);
            var ids = "";
            //ChangePro  ChangeBefore ChangeAfter 
            for (var i = 0; i < records.length; i++) {
                var record = records[i];
                //if (record.data.ChangeAfter != "") {
                ids += record.data.FAUDID +"*"+ record.data.XJJH + "#";
                //} 
            }

            App.direct.clicksave(ids);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 表头开始 -->
        <div class="tabtitle">
            <span>当前位置：<b>科、所经费查询</b>&nbsp;&nbsp;>&nbsp;&nbsp;各科、所经费使用情况统计表</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <%--<tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>导入决算数据</strong>
                        <asp:HiddenField ID="HidBasicPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidBasicMonStrs" runat="server" />
                        <asp:HiddenField ID="HidProPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidProMonStrs" runat="server" />
                    </td>
                </tr>--%>
                <tr>
                    <td class="tr1" align="right">导入数据:</td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnImport" runat="server" Text="导入Excel" CssClass="btns" OnClick="btnImport_Click" />
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        <%--            <table id="table" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                <tr>
                    <td class="tr1" align="left" colspan="2" width="20%"><strong>各科、所经费使用情况统计表</strong>
                    </td>
                    <td class="tr1" align="right" colspan="7" width="20%"><strong>单位:元</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="20%" align="center" rowspan="2">部门名称
                    </td>
                    <td class="tr1" width="10%" align="center" rowspan="2">
                        <asp:Label ID="lblYear" runat="server" />年额度
                    </td>
                    <td class="tr1" width="40%" align="center" colspan="4">累计已用款
                    </td>
                    <td class="tr1" width="10%" align="center" rowspan="2">可用余额
                    </td>
                    <td class="tr1" width="10%" align="center" rowspan="2">占额度比
                    </td>
                    <td class="tr1" width="10%" align="center" rowspan="2">备注
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="center">总计
                    </td>
                    <td class="tr1" width="10%" align="center">其中:现金
                    </td>
                    <td class="tr1" width="10%" align="center">现金计划
                    </td>
                    <td class="tr1" width="10%" align="center">现金可用余额
                    </td>
                </tr>
                <asp:Repeater ID="repIncomeMon" runat="server">
                    <ItemTemplate>
                        <tr onmousemove="javascript:this.bgColor='#F0FFFF';" onmouseout="javascript:this.bgColor='#FFFFFF';">
                            <td align="center">
                                <%# Eval("DEPARTMENT") %>
                            </td> 
                            <td align="center">
                                <%# Eval("ED") %>
                            </td>
                            <td align="center">
                                <%# Eval("TZ") %>
                            </td>
                            <td align="center">
                                <%# Eval("QZXJ") %>
                            </td>
                            <td align="center">
                                <%# Eval("XJJH") %>
                            </td>
                            <td align="center">
                                <%# Eval("XJKYED") %>
                            </td>
                            <td align="center">
                                <%# Eval("KYYE") %>
                            </td>
                            <td align="center">
                                <%# Eval("column1") %>
                            </td>
                            <td align="center">
                                <%# Eval("BZ") %>
                            </td>                        
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>--%>
        </div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:GridPanel ID="GridPanel1" runat="server" Title="科所经费使用情况统计表" Layout="FitLayout" ColumnLines="true" Height="600">
            <Store>
                <ext:Store ID="Store1" runat="server" PageSize="25">
                    <Model>
                        <ext:Model ID="Model1" runat="server">
                            <Fields>
                                <ext:ModelField Name="FAUDID" />
                                <ext:ModelField Name="DEPARTMENT" />
                                <ext:ModelField Name="data1"  Type="Float"/>
                                <ext:ModelField Name="data2" Type="Float" />
                                <ext:ModelField Name="data3" Type="Float" />
                                <ext:ModelField Name="XJJH" Type="Float" />
                                <ext:ModelField Name="data4" Type="Float" />
                                <ext:ModelField Name="data5" Type="Float" />
                                <ext:ModelField Name="data6"  />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1"
                        runat="server"
                        Text="部门名称"
                        Width="100" Align="Center"
                        DataIndex="DEPARTMENT" Flex="1" RowSpan="2" />
                    <ext:Column ID="Column3"
                        runat="server"
                        Text="" Align="Center"
                        DataIndex="data1"
                        Flex="1" RowSpan="2" />
                    <ext:Column ID="Column4"
                        runat="server"
                        Text="累计已用款" Align="Center"
                        DataIndex="RFOUNDING"
                        Flex="6" ColSpan="4">
                        <Columns>
                            <ext:Column ID="Column5"
                                runat="server"
                                Text="总计" Align="Center"
                                DataIndex="data2">
                            </ext:Column>
                            <ext:Column ID="Column6"
                                runat="server"
                                Text="其中:现金" Align="Center"
                                DataIndex="data3">
                            </ext:Column>
                            <ext:ComponentColumn ID="Column7"
                                runat="server"
                                Text="现金计划" Align="Center"
                                DataIndex="XJJH"
                                Editor="true">
                                <Component>
                                    <ext:TextField runat="server" ID="TextField3" />
                                </Component>
                            </ext:ComponentColumn>
                            <ext:Column ID="Column8"
                                runat="server"
                                Text="现金可用余额" Align="Center"
                                DataIndex="data4">
                            </ext:Column>
                        </Columns>
                    </ext:Column>

                    <ext:Column ID="Column9"
                        runat="server"
                        Text="可用余额" Align="Center"
                        DataIndex="data5"
                        Flex="1" RowSpan="2">
                    </ext:Column>
                    <ext:Column ID="Column10"
                        runat="server"
                        Text="占额度比" Align="Center"
                        DataIndex="data6"
                        Flex="1"  RowSpan="2">
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <TopBar>
                <ext:Toolbar ID="Toolbar2" runat="server" Height="25">
                    <Items>
                        <ext:Button ID="BookSave" Icon="DatabaseSave" runat="server" Text="保存">
                            <Listeners>
                                <Click Fn="click" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnGetData" Icon="ApplicationCascade" runat="server" Text="提取数据" OnDirectClick="btnGetData_DirectClick"/>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:GridPanel>
    </form>
</body>
</html>

