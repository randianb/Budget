<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinAccounting.aspx.cs" Inherits="mainPages_FinAccounting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>财务核算</title>
    <link href="../css/whsystem.css" rel="stylesheet" type="text/css" />
    <link href="../css/whtable.css" rel="stylesheet" type="text/css" />

    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../css/mytable.js"></script>

    <style type="text/css">
        html, body
        {
            overflow: scroll;
            overflow-y: hidden;
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
    <!-- 表头结束 -->
    <div class="table_list">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="line-height: 35px;">
            <tr>
                <td colspan="2" class="tr1">
                    &nbsp;<strong>财务核算处理操作</strong>
                </td>
            </tr>
            <tr>
                <td width="20%" class="tr1 right">

                </td>
                <td>
                    &nbsp;&nbsp;<asp:Button ID="btnExport" CssClass="btns" runat="server" Text=" 导出Excel到核算系统 " />
                </td>
            </tr>
        </table>
    </div>
    <div class="table_list">
    </div>
    </form>
</body>
</html>
