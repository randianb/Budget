<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HisPassword.aspx.cs" Inherits="WebPage_BudgetControl_HisAllocation" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
	<script src="../../js/jquery-1.7.2.min.js"></script>
	<script type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
		<ext:ResourceManager ID="ResourceManager1" runat="server" />
	<ext:Viewport runat="server" Layout="fit" >
		<Items>
		<ext:GridPanel ID="GridPanel1" ColumnLines="true"
					runat="server"
					Title="密码修改历史记录" Layout="fit" AutoScroll="True">
					<Store>
						<ext:Store ID="Store1" runat="server"> 
							<Model>
								<ext:Model ID="Model1" runat="server">
									<Fields>
										<ext:ModelField Name="PwdID" Type="int" />
										<ext:ModelField Name="UserName" Type="String" />
										<ext:ModelField Name="UserID" Type="int" />
										<ext:ModelField Name="OldPwd" Type="String" />
										<ext:ModelField Name="NewPwd" Type="String" /> 
										<ext:ModelField Name="DepName" Type="String" /> 
										<ext:ModelField Name="CrTime" Type="Date" SortDir="ASC" /> 
									</Fields>
								</ext:Model>
							</Model>
						</ext:Store>
					</Store>
					<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>  
							<ext:Column ID="Column2"
								runat="server"
								Text="姓名"
								DataIndex="UserName"
								Flex="1" />
							<ext:Column ID="Column3"
								runat="server"
								Text="部门名称"
								DataIndex="DepName" 
								Flex="1" />
							<ext:Column ID="Column4"
								runat="server"
								Text="旧密码" 
								DataIndex="OldPwd"
								Flex="1" />　 
							<ext:Column ID="Column5"
								runat="server"
								Text="新密码" 
								DataIndex="NewPwd"
								Flex="1" />　 
							<ext:DateColumn ID="Column9"
								Format="yyyy-MM-dd"
								runat="server"
								Text="操作时间"  
								DataIndex="CrTime" 
								Flex="1" />　
						</Columns>
					</ColumnModel> 
				</ext:GridPanel>
			</Items>
	</ext:Viewport>
	</form>
</body>
</html>
