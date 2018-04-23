Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows.Controls
Imports DevExpress.AgDataGrid
Imports DevExpress.Data.Filtering

Namespace AgDataGrid_CustomizeFilterDropdown
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
		End Sub

		Private Sub grid_ShowFilterPopup(ByVal sender As Object, ByVal e As DevExpress.AgDataGrid.ShowFilterPopupEventArgs)
			If e.Column.FieldName <> "UnitPrice" Then
				Return
			End If
			e.FilterBox.FilterItems.Clear()
			Dim filterItems As New List(Of Object)()
			filterItems.Add(New FilterInfo(CriteriaOperator.Parse("[UnitPrice] < 50"), "Less than $50"))
			filterItems.Add(New FilterInfo(CriteriaOperator.Parse("[UnitPrice] >= 50 AND [UnitPrice] < 100"), "Between $50 And $100"))
			e.FilterBox.FilterItems = filterItems
		End Sub
	End Class
End Namespace
