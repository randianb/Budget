<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyList.aspx.cs" Inherits="WebPage_Policy_PolicyList" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        var selectionChanged = function (selModel, selected) {

            if (selected.length > 0) {
                var plid = selected[0].data.PLID;
                window.showModalDialog("PolicyContent.aspx?plid=" + plid, window, "dialogWidth=600px;dialogHeight=500px;status=false;");
            }
        };

        var onShow = function (toolTip, grid) {
            var view = grid.getView(),
                store = grid.getStore(),
                record = view.getRecord(view.findItemByChild(toolTip.triggerElement)),
                column = view.getHeaderByCell(toolTip.triggerElement),
                data = record.get(column.dataIndex);

            toolTip.update(data);
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport runat="server" Layout="AnchorLayout">
            <Items>

                <ext:FormPanel runat="server" ID="reset" Border="false">
                    <Items>
                        <ext:GridPanel ColumnLines="true" ID="GridPanel1" runat="server" Title="Title" Header="false" HideHeaders="true" Border="false">
                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server" IDProperty="name">
                                            <Fields>
                                                <ext:ModelField Name="PLID" Type="string" />
                                                <ext:ModelField Name="PTitle" Type="string" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel Header="false">
                                <Columns>
                                    <ext:Column ID="Column1"
                                        runat="server"
                                        Sortable="false"
                                        fixed="true"
                                        Resizable="false"
                                        Hideable="false"
                                        MenuDisabled="false"
                                        header=""
                                        Flex="10"
                                        DataIndex="PTitle" />
                                </Columns>
                                <Columns>
                                    <ext:Column ID="Column2"
                                        runat="server"
                                        fixed="true"
                                        Resizable="false"
                                        Hideable="false"
                                        MenuDisabled="false"
                                        Sortable="false"
                                        Flex="20"
                                        Visible="false"
                                        DataIndex="PLID" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single" />
                            </SelectionModel>

                            <Listeners>
                                <SelectionChange Fn="selectionChanged" />
                                <%--<ItemClick Handler="returned"></ItemClick>--%>
                            </Listeners>
                        </ext:GridPanel>
                    </Items>
                </ext:FormPanel>
                <ext:ToolTip ID="ToolTip1" runat="server" Target="={#{GridPanel1}.getView().el}"
                    Delegate=".x-grid-cell" TrackMouse="true">
                    <Listeners>
                        <Show Handler="onShow(this, #{GridPanel1});" />
                    </Listeners>
                </ext:ToolTip>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
