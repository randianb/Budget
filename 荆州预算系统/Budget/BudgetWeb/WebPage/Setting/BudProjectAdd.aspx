<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BudProjectAdd.aspx.cs" Inherits="mainPages_BudProjectAdd" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预算项目添加</title>

    <script src="../BudgetEdit/css/mytable.js" type="text/javascript"></script>
    <link href="../BudgetEdit/css/whsystem.css" rel="stylesheet" />
    <link href="../BudgetEdit/css/whtable.css" rel="stylesheet" />
    <style type="text/css">
        html, body
        {
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
        /*#App.ddlPayIncome_Container
        {
            border:none;
            border-style:none;
        }
        #ddlPayIncome
        {
             border:none;
            border-style:none;
        }
        #ddlPayIncome-inputRow
        {
              border:none;
            border-style:none;
        }
        #ddlPayIncome-inputEl
        {
            border:none;
            border-style:none;
        }
        #ext-gen1031
        {
 border:none;
            border-style:none;       
        }
        #ddlPayIncome-inputCell
        {
           
        }
        #ddlPayIncome-triggerWrap
        {
             border:none;
            border-style:none;  
        }
        #ddlPayIncome-bodyEl
        {
             border:none;
            border-style:none;
        }
        #ddlPayIncome-labelCell
        {
          
        }
        #ddlPayIncome-inputRow
        {
           
        }
        #ext-gen1029
        {
        }
        #ext-gen1030
        {
            border:none;
            border-style:none;
        }
        #ddlPayIncome-indicator
        {
            border:none;
            border-style:none;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <!-- 表头开始 -->

        <!-- 表头结束 -->
        <ext:Viewport runat="server" ID="vwpLayout" Layout="AnchorLayout">
            <Items>
                <ext:Panel ID="Panel1"
                    runat="server"
                    Title="预算项目添加">
                    <Items>
                    </Items>
                </ext:Panel>
                <ext:Toolbar ID="Toolbar24" runat="server" Height="50" Border="false" BaseCls="backround:transparent" Layout="ColumnLayout" MarginSpec="10 10 0 10">
                    <Items>
                        <ext:Toolbar ID="Toolbar25" runat="server" Height="50" Border="true" ColumnWidth="0.20" MarginSpec="0 0 0 0">
                            <Items>
                                <ext:ToolbarFill></ext:ToolbarFill>
                                <ext:Hidden ID="hidID" runat="server"></ext:Hidden>
                                <ext:Label ID="Label16" runat="server" Text="经济科目名称："></ext:Label>
                            </Items>
                        </ext:Toolbar>
                        <ext:Panel ID="Panel15" runat="server" ColumnWidth="0.80" Height="50">
                            <Items>
                                <ext:ComboBox ID="ddlPayIncome" runat="server" MarginSpec="13 0 0 25" Width="120px" DisplayField="PIEcoSubName">
                                    <Store>
                                        <ext:Store ID="cmbName" runat="server">
                                            <Model>
                                                <ext:Model ID="Model3" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PIEcoSubName" Type="String">
                                                        </ext:ModelField> 
                                                    </Fields>

                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Toolbar>
            </Items>
        </ext:Viewport>
        <div class="table_list">
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 40px;">
                <%--                <tr>
                    <td colspan="2" class="tr1">&nbsp;<strong>预算项目添加</strong>
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">经济科目名称：
                    </td>
                    <td style="background-color: white">
                        <ext:Panel runat="server">
                            <Items>
                                <ext:ComboBox ID="ddlPayIncome" runat="server" Width="120px" BorderSpec="0 0 0 0" DisplayField="PayPrjName" ValueField="PIID">
                                    <Store>
                                        <ext:Store ID="cmbName" runat="server">
                                            <Model>
                                                <ext:Model ID="Model3" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="PayPrjName" Type="String">
                                                        </ext:ModelField>
                                                        <ext:ModelField Name="PIID" Type="int">
                                                        </ext:ModelField>
                                                    </Fields>

                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <SelectedItems>
                                        <ext:ListItem Index="0">
                                        </ext:ListItem>
                                    </SelectedItems>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>


                    </td>
                </tr>--%>
                <tr>
                    <td width="20%" class="tr1 right">预留项：
                    </td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckA" Text="A" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbA" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrA" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">&nbsp;</td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckB" Text="B" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbB" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrB" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">&nbsp;</td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckC" Text="C" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbC" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrC" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">&nbsp;</td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckD" Text="D" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbD" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrD" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">&nbsp;</td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckE" Text="E" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbE" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrE" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right">&nbsp;</td>
                    <td>&nbsp;&nbsp;
                    <asp:CheckBox ID="ckF" Text="F" runat="server" />
                        &nbsp;&nbsp;
                    <asp:TextBox ID="tbF" CssClass="txt" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    控制标准：
                    <asp:TextBox ID="tbCtrF" CssClass="txt" Style="width: 80px;" runat="server"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="tr1 right"></td>
                    <td>&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" CssClass="btns" runat="server" Text=" 添  加 " OnClick="btnAdd_Click" />
                        <asp:Button ID="btnCan" CssClass="btns" runat="server" Text=" 取  消 " OnClick="btnCan_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="table_list">
        </div>
    </form>
</body>
</html>
