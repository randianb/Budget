﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
        ul {
           
         
           padding:0;
            
        }
        li {
            float:left;
            padding-top:40px;
            padding-right:10px;

        }
    </style>
</head>
<body style="background: url(img/bg/s1.jpg); margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <div>
            <img src="img/bg/s2.jpg" />
            <span style="font-size: 36px; font-family: 宋体; font-weight: bold; position: absolute; left: 180px; top: 30px;">地税财务数据分析展示系统1.0</span>
            <div style="float:right; width:512px; height:90px; background:url(img/bg/s3.jpg); " >
         
                    <ul style="list-style:none;">
                        <li>
                            <ext:Label ID="Label1" runat="server" Icon="Folder" Text="使用单位："></ext:Label>
                            <ext:Label ID="Label2" runat="server" Text="嘉鱼县"></ext:Label>
                        </li>
                        <li>
                            <ext:Label ID="Label7" runat="server" Icon="Group" Text="当前部门："></ext:Label>
                            <ext:Label ID="lbDep" runat="server" Text=""></ext:Label>
                        </li>
                        <li>
                            <ext:Label ID="Label3" runat="server" Icon="UserB" Text="用户名："></ext:Label>
                            <ext:Label ID="lbUser" runat="server" Text=""></ext:Label>
                           
                        </li>
                        <li>
                            <ext:Label ID="Label4" runat="server" Icon="UserGo"></ext:Label>
                            <asp:LinkButton ID="lkBtn" runat="server" OnClick="lkBtn_Click">退出</asp:LinkButton>
                        </li>
                    </ul>
                  
                   
                    
               
            </div>
        </div>



    </form>
</body>
</html>
