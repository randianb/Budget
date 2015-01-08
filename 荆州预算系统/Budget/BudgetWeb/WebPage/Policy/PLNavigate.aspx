<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PLNavigate.aspx.cs" Inherits="WebPage_Policy_PLNavigate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="noticecss/css/bootstrap.min.css" rel="stylesheet" />
    <script src="noticecss/js/bootstrap.min.js"></script> <script src="noticecss/js/jquery.min.js"></script>
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
<%--     <link href="http://libs.baidu.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet">--%>
<%--   <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>--%>
<%--   <script src="http://libs.baidu.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>--%>
    <style type="text/css">
        .auto-style1 {
            width: 76px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 10%;  " >
              <div runat="server" class="alert alert-warning" id="hidtj">
       <a href="../BudgetControl/ControlAudit.aspx?Audit=0" class="alert-link">预算控制当前未办事项提醒：您有<%=Sjtj %>条数据财务室待审核 </a> </div> 
        <div runat="server" class="alert alert-warning" id="hidsbtj" >
       <a href="../BudgetEdit/BudgetExamine.aspx" class="alert-link"  >预算编审当前未办事项提醒：您有<%=Sjsbtj %>条数据未上报 </a> </div> 
        <div runat="server" class="alert alert-warning" id="hidsh"  >
       <a href="../BudgetControl/ControlAudit.aspx?Audit=1" class="alert-link"  >预算控制当前未办事项提醒：您有<%=Sjsh %>条数据局领导待审核 </a></div>
            <div runat="server" class="alert alert-warning" id="hidsbsh" > 
       <a href="../BudgetEdit/BudgetReview.aspx" class="alert-link"  >预算编审当前未办事项提醒：您有<%=Sjsh %>条数据未未审核 </a></div>
        </div> 
        
        <div  style="height:90%;  "  align="center" >
            <table  style="width:50%; height:60% ;border:0px; margin-top: 10%">
                <tr>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/初始化.png") %>'  width="128" height="145" /></td>
                    <td class="auto-style1">
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头右.png") %>' width="70" height="70" /></td>
                    <td>
                        <a href='<%=ResolveUrl("~/WebPage/BudgetEstimate/PENavigate.aspx") %>'><img src='<%=ResolveUrl("~/img/dh/1/预算测算.png") %>' width="128" height="145" /></a></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头右.png") %>' width="70" height="70" /></td>
                    <td>
                        <a href='<%=ResolveUrl("~/WebPage/BudgetEdit/BENavigate.aspx")%>'><img src='<%=ResolveUrl("~/img/dh/1/预算编审.png") %>' width="128" height="145" /></a></td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头下.png") %>' width="70" height="70" /></td>
                </tr>
                <tr>
                    <td>
                        <a href='<%=ResolveUrl("~/WebPage/BudgetExecute/BXNavigate.aspx")%>'><img src='<%=ResolveUrl("~/img/dh/1/预算执行.png") %>' width="128" height="145" /></a></td>
                    <td class="auto-style1">
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头左.png") %>' width="70" height="70" /></td>
                    <td>
                        <a href='<%=ResolveUrl("~/WebPage/BudgetAnalyse/BANavigate.aspx")%>'><img src='<%=ResolveUrl("~/img/dh/1/预算分析.png") %>' width="128" height="145" /></a></td>
                    <td>
                        <img src='<%=ResolveUrl("~/img/dh/1/箭头左.png") %>' width="70" height="70" /></td>
                    <td>
                        <a href='<%=ResolveUrl("~/WebPage/BudgetControl/BCNavigate.aspx")%>'><img src='<%=ResolveUrl("~/img/dh/1/预算控制.png") %>' width="128" height="145" /></a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
