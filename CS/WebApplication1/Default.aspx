<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function btnGetSelectedRowCount_Click(s, e) {
            clientGrid.GetSelectedFieldValues('Name', OnGetSelectedFieldValues);
        }
        function OnGetSelectedFieldValues(result) {
            alert('Selected row count: ' + result.length);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" OnDataBinding="grid_DataBinding"
            KeyFieldName="ID" ClientInstanceName="clientGrid">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                    <ClearFilterButton Visible="True">
                    </ClearFilterButton>
                </dx:GridViewCommandColumn>
            </Columns>
        </dx:ASPxGridView>
        <dx:ASPxButton ID="btnDeleteSelectedRows" runat="server" OnClick="btnDeleteSelectedRows_Click"
            Text="Delete selected rows">
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnGetSelectedRowCount" runat="server" Text="Get selected row count"
            AutoPostBack="false">
            <ClientSideEvents Click="btnGetSelectedRowCount_Click" />
        </dx:ASPxButton>
    </div>
    </form>
</body>
</html>
