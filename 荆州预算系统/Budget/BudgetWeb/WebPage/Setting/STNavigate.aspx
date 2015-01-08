<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STNavigate.aspx.cs" Inherits="WebPage_Setting_STNavigate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        a img {
            border: none;
        }

        a {
            text-decoration: none;
            cursor: pointer;
            color: #222;
            font-size: 14px;
            white-space: nowrap;
            text-overflow: ellipsis;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="50%" height="60%" border="0" style="margin-top: 10%">
                <tr>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/初始化.png") %>' width="128" height="145" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头右.png") %>' width="70" height="70" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/与上年预算关联.png") %>' width="128" height="145" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头右.png") %>' width="70" height="70" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/部门信息更新.png") %>' width="128" height="145" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头下.png") %>' width="70" height="70" /></td>
                </tr>
                <tr>

                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/本年预算指标.png") %>' width="128" height="145" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头左.png") %>' width="70" height="70" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/本年参数更新.png") %>' width="128" height="145" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头左.png") %>' width="70" height="70" /></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/2/人员信息更新.png") %>' width="128" height="145" /></td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
