<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<br />
		<br />
		<dxwgv:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" DataSourceID="GridDataSource" 
			KeyFieldName="ProductID" ClientInstanceName="Grid" OnCustomCallback="Grid_CustomCallback" OnHtmlRowPrepared="Grid_HtmlRowPrepared">
			<Columns>
				<dxwgv:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" />
				<dxwgv:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0" Visible="false" />
				<dxwgv:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1" />
				<dxwgv:GridViewDataTextColumn FieldName="SupplierID" VisibleIndex="2" />
				<dxwgv:GridViewDataComboBoxColumn Caption="Category Name" FieldName="CategoryID" VisibleIndex="3">
					<PropertiesComboBox ValueField="CategoryID" TextField="CategoryName" 
						DataSourceID="CategoryDataSource" ValueType="System.Int32" />
				</dxwgv:GridViewDataComboBoxColumn>
				<dxwgv:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="4" />
				<dxwgv:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="5" />
				<dxwgv:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="6" />
				<dxwgv:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="7" />
				<dxwgv:GridViewDataTextColumn FieldName="ReorderLevel" VisibleIndex="8" />
			</Columns>
			<Templates>
				<GroupRowContent>
				   <table>
					   <tr><td>
							<dxe:ASPxCheckBox ID="checkBox" runat="server" />
					   </td><td>
							<dxe:ASPxLabel ID="CaptionText" runat="server" Text='<%#GetCaptionText(Container)%>' />
					   </td></tr>
				   </table>
				</GroupRowContent>
			</Templates>
			<Settings ShowGroupPanel="true" />
			<GroupSummary>
				<dxwgv:ASPxSummaryItem FieldName="CategoryName" SummaryType="Count" />
			</GroupSummary>
		</dxwgv:ASPxGridView>
		<asp:AccessDataSource ID="GridDataSource" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Products]" />
		<asp:AccessDataSource ID="CategoryDataSource" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT * FROM [Categories]" />

		<dxe:ASPxButton ID="btn" runat="server" Text="PostBack" />
	</form>
</body>
</html>