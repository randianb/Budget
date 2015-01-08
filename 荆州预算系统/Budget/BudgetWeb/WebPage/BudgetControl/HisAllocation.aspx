<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HisAllocation.aspx.cs" Inherits="WebPage_BudgetControl_HisAllocation" %>

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
					Title="预算分配历史记录" Layout="fit" AutoScroll="True">
					<Store>
						<ext:Store ID="Store1" runat="server"> 
							<Model>
								<ext:Model ID="Model1" runat="server">
									<Fields>
										<ext:ModelField Name="BAAHisID" Type="int" />
										<ext:ModelField Name="OldBAAMon" Type="Float" />
										<ext:ModelField Name="OldSuppMon" Type="Float" />
										<ext:ModelField Name="NewBAAMon" Type="Float" />
										<ext:ModelField Name="NewSuppMon" Type="Float" />
										<ext:ModelField Name="AddBAAMon" Type="Float" />
										<ext:ModelField Name="AddSuppMon" Type="Float" />
										<ext:ModelField Name="DepName" Type="String"/> 
										<ext:ModelField Name="UserOp" Type="String"/> 
										<ext:ModelField Name="Crtime"  Type="Date"  SortDir="ASC"/> 
									</Fields>
								</ext:Model>
							</Model>
						</ext:Store>
					</Store>
					<ColumnModel ID="ColumnModel1" runat="server">
						<Columns>  
							<ext:Column ID="Column2"
								runat="server"
								Text="部门名称"
								DataIndex="DepName"
								Flex="1" />
							<ext:Column ID="Column3"
								runat="server"
								Text="旧分配金额（万元）"
								DataIndex="OldBAAMon"
								EmptyCellText="0.00"
								Flex="1" />
							<ext:Column ID="Column4"
								runat="server"
								Text="旧追加金额（万元）"
								EmptyCellText="0.00"
								DataIndex="OldSuppMon"
								Flex="1" />　
							<ext:Column ID="Column1"
								runat="server"
								Text="新分配金额（万元）"
								DataIndex="NewBAAMon"
								EmptyCellText="0.00"
								Flex="1" />
							<ext:Column ID="Column5"
								runat="server"
								Text="新追加金额（万元）"
								EmptyCellText="0.00"
								DataIndex="NewSuppMon"
								Flex="1" />　
							<ext:Column ID="Column6"
								runat="server"
								Text="（差额）分配金额（万元）"
								DataIndex="AddBAAMon"
								EmptyCellText="0.00"
								Flex="1" />
							<ext:Column ID="Column7"
								runat="server"
								Text="（差额）追加金额（万元）"
								EmptyCellText="0.00"
								DataIndex="AddSuppMon"
								Flex="1" />　
							<ext:Column ID="Column8"
								runat="server"
								Text="操作员" 
								DataIndex="UserOp"
								Flex="1" />　
							<ext:DateColumn ID="Column9"
								Format="yyyy-MM-dd"
								runat="server"
								Text="操作时间"  
								DataIndex="Crtime" 
								Flex="1" />　
						</Columns>
					</ColumnModel> 
				</ext:GridPanel>
			</Items>
	</ext:Viewport>
	</form>
</body>
</html>
