<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BraFundLimitTB.aspx.cs" Inherits="WebPage_BraFundInquiry_BraFundLimitTB" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>科所经费额度表</title>
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
                ids += record.data.FAID + "*" + record.data.NUMBEROFPEOPLE + "#";
                //} 
            }

            App.direct.clicksave(ids);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tabtitle">
            <span>当前位置：<b>科、所经费查询</b>&nbsp;&nbsp;>&nbsp;&nbsp;科所经费额度表</span><p>
            </p>
        </div>
        <!-- 表头结束 -->
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
                <tr>
                    <td class="tr1" colspan="2">&nbsp;<strong>导入数据</strong>
                        <asp:HiddenField ID="HidBasicPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidBasicMonStrs" runat="server" />
                        <asp:HiddenField ID="HidProPIIDStrs" runat="server" />
                        <asp:HiddenField ID="HidProMonStrs" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tr1" align="right">导入:</td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnImport" runat="server" Text="导入Excel" CssClass="btns" OnClick="btnImport_Click1" />
                        &nbsp;
                        <asp:Label ID="lblShowResult" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <%--<table id="table" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 30px;">
                <tr>
                    <td class="tr1" align="left" colspan="2" width="20%"><strong>科所经费额度表</strong>
                    </td>
                    <td class="tr1" align="right" colspan="8" width="20%"><strong>单位:元</strong>
                    </td>
                </tr>
                <tr>
                    <td class="tr1" width="10%" align="center">部门名称
                    </td>
                    <td class="tr1" width="10%" align="center">人数
                    </td>
                    <td class="tr1" width="10%" align="center">
                        <asp:Label ID="lblYear" runat="server" />年额度
                    </td>
                    <td class="tr1" width="10%" align="center">常规经费
                    </td>
                    <td class="tr1" width="10%" align="center">三万活动下乡经费
                    </td>
                    <td class="tr1" width="10%" align="center">绩效管理优秀单位
                    </td>
                    <td class="tr1" width="10%" align="center">党风廉政先进单位
                    </td>
                    <td class="tr1" width="10%" align="center">五比五亮五创先进奖
                    </td>
                    <td class="tr1" width="10%" align="center">八有优胜和标准税务所合格单位
                    </td>
                    <td class="tr1" width="10%" align="center">规费奖励经费
                    </td>
                </tr>
            </table>--%>
        </div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:GridPanel ID="GridPanel1" runat="server" Title="科所经费额度表" Layout="FitLayout" ColumnLines="true" Height="600">
            <Store>
                <ext:Store ID="Store1" runat="server" PageSize="25">
                    <Model>
                        <ext:Model ID="Model1" runat="server">
                            <Fields>
                                <ext:ModelField Name="FAID" />
                                <ext:ModelField Name="DEPARTMENT" />
                                <ext:ModelField Name="NUMBEROFPEOPLE" />
                                <ext:ModelField Name="LIMIT" Type="Float" />
                                <ext:ModelField Name="RFOUNDING" Type="Float" />
                                <ext:ModelField Name="ATCFOR" Type="Float" />
                                <ext:ModelField Name="JXGLYXDY" Type="Float" />
                                <ext:ModelField Name="DFLZYXDW" Type="Float" />
                                <ext:ModelField Name="WBWLWCXJJ" Type="Float" />
                                <ext:ModelField Name="BYHBSHGDW" Type="Float" />
                                <ext:ModelField Name="GFJLJF" Type="Float" />
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
                        DataIndex="DEPARTMENT" Flex="1" />
                    <ext:ComponentColumn ID="Column2"
                        runat="server"
                        Text="人数" Align="Center"
                        DataIndex="NUMBEROFPEOPLE"
                        Flex="1" Editor="true">
                        <Component>
                            <ext:TextField runat="server" ID="TextField1" />
                        </Component>
                    </ext:ComponentColumn>
                    <ext:Column ID="Column3"
                        runat="server"
                        Text="" Align="Center"
                        DataIndex="LIMIT"
                        Flex="1" />
                    <ext:Column ID="Column4"
                        runat="server"
                        Text="常规经费" Align="Center"
                        DataIndex="RFOUNDING"
                        Flex="1" />
                    <ext:Column ID="Column5"
                        runat="server"
                        Text="三万活动下乡经费" Align="Center"
                        DataIndex="ATCFOR"
                        Flex="1" Editor="true">
                    </ext:Column>
                    <ext:Column ID="Column6"
                        runat="server"
                        Text="绩效管理优秀单位" Align="Center"
                        DataIndex="JXGLYXDY"
                        Flex="1" Editor="true">
                    </ext:Column>
                    <ext:Column ID="Column7"
                        runat="server"
                        Text="党风廉政先进单位" Align="Center"
                        DataIndex="DFLZYXDW"
                        Flex="1" Editor="true">
                    </ext:Column>
                    <ext:Column ID="Column8"
                        runat="server"
                        Text="五比五亮五创先进奖" Align="Center"
                        DataIndex="WBWLWCXJJ"
                        Flex="1" Editor="true">
                    </ext:Column>
                    <ext:Column ID="Column9"
                        runat="server"
                        Text="八有优胜和标准税务所合格单位" Align="Center"
                        DataIndex="BYHBSHGDW"
                        Flex="1" Editor="true">
                    </ext:Column>
                    <ext:Column ID="Column10"
                        runat="server"
                        Text="规费奖励经费" Align="Center"
                        DataIndex="GFJLJF"
                        Flex="1" Editor="true">
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:GridPanel>
    </form>
</body>
</html>
