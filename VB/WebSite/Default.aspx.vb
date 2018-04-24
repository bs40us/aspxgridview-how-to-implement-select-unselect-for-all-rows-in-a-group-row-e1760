Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Function GetChecked(ByVal visibleIndex As Integer) As Boolean
        Dim i As Integer = 0
        Do While i < Grid.GetChildRowCount(visibleIndex)
            Dim isRowSelected As Boolean = Grid.Selection.IsRowSelectedByKey(Grid.GetChildDataRow(visibleIndex, i)("ProductID"))
            If Not isRowSelected Then
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function

    Protected Function GetCaptionText(ByVal container As GridViewGroupRowTemplateContainer) As String
        Dim captionText As String = If(Not String.IsNullOrEmpty(container.Column.Caption), container.Column.Caption, container.Column.FieldName)
        Return String.Format("{0} : {1} {2}", captionText, container.GroupText, container.SummaryText)
    End Function
    Protected Sub Grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        Dim parameters() As String = e.Parameters.Split(";"c)
        Dim index As Integer = Integer.Parse(parameters(0))
        Dim isGroupRowSelected As Boolean = Boolean.Parse(parameters(1))
        Dim i As Integer = 0
        Do While i < Grid.GetChildRowCount(index)
            Dim row As DataRow = Grid.GetChildDataRow(index, i)
            Grid.Selection.SetSelectionByKey(row("ProductID"), isGroupRowSelected)
            i += 1
        Loop
    End Sub

    Protected Sub Grid_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
        If e.RowType = GridViewRowType.Group Then
            Dim checkBox As ASPxCheckBox = TryCast(Grid.FindGroupRowTemplateControl(e.VisibleIndex, "checkBox"), ASPxCheckBox)
            If checkBox IsNot Nothing Then
                checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s, e){{ Grid.PerformCallback('{0};' + s.GetChecked()); }}", e.VisibleIndex)
                checkBox.Checked = GetChecked(e.VisibleIndex)
            End If
        End If
    End Sub
End Class
