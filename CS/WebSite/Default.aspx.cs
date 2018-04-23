using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
    }

    protected bool GetChecked(int visibleIndex) {
        for(int i = 0; i < Grid.GetChildRowCount(visibleIndex); i++) {
            bool isRowSelected = Grid.Selection.IsRowSelectedByKey(Grid.GetChildDataRow(visibleIndex, i)["ProductID"]); 
            if(!isRowSelected)
                return false;
        }
        return true;
    }

    protected string GetCaptionText(GridViewGroupRowTemplateContainer container) {
        string captionText = !string.IsNullOrEmpty(container.Column.Caption) ? container.Column.Caption : container.Column.FieldName;
        return string.Format("{0} : {1} {2}", captionText, container.GroupText, container.SummaryText);
    }
    protected void Grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        string[] parameters = e.Parameters.Split(';');
        int index = int.Parse(parameters[0]);
        bool isGroupRowSelected = bool.Parse(parameters[1]);
        for(int i = 0; i < Grid.GetChildRowCount(index); i++) {
            DataRow row = Grid.GetChildDataRow(index, i);
            Grid.Selection.SetSelectionByKey(row["ProductID"], isGroupRowSelected);
        }
    }

    protected void Grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e) {
        if(e.RowType == GridViewRowType.Group) {
            ASPxCheckBox checkBox = Grid.FindGroupRowTemplateControl(e.VisibleIndex, "checkBox") as ASPxCheckBox;
            if(checkBox != null) {
                checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e){{ Grid.PerformCallback('{0};' + s.GetChecked()); }}", e.VisibleIndex);
                checkBox.Checked = GetChecked(e.VisibleIndex);
            }
        }
    }
}
