# ASPxGridView - How to implement select/unselect for all rows in a group row


<p>This example demonstrates how to implement select/unselect for all rows in a group row.</p>
<p>It's possible to implement this behavior only by using ASPXGridView 9.1. For more information, please refer to <a href="https://www.devexpress.com/Support/Center/p/S18760">Add client- and server-side methods to obtain rows belonging to a certain group</a>.</p>
<p>First, place ASPxCheckBox and ASPxLabel into the Grid.Templates.GroupRowContent template.<br> <br> Second, set the ASPxCheckBox.Checked property and the client-side ASPxCheckBox.ClientSideEvents.CheckedChanged event in the ASPxGridView.HtmlRowPrepared event handler.</p>
<p>In this example the ASPxLabel.Text is bound in the markup using Two-Way DataBinding.<br><br>MVC version: <a href="https://www.devexpress.com/Support/Center/p/T362032">T362032: GridView - How to implement select/unselect for all rows in a group row</a><br><br><strong>See also<br></strong><a href="https://www.devexpress.com/Support/Center/p/T299266">How to implement select/unselect for all rows in a group row in ASPxGridLookup</a></p>

<br/>


