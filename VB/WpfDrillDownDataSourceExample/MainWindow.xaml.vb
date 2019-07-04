Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PivotGrid
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace WpfDrillDownDataSourceExample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	''' 

	Partial Public Class MainWindow
		Inherits ThemedWindow

		Public Property OrderSourceList() As ObservableCollection(Of MyOrderRow)
		Public Property OrderDrillDownList() As ObservableCollection(Of MyOrderRow)
		Public Sub New()
			InitializeComponent()
			OrderSourceList = DatabaseHelper.CreateData()
			pivotGridControl1.DataSource = OrderSourceList
		End Sub
		Private Sub PivotGridControl1_CellSelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			OrderDrillDownList = New ObservableCollection(Of MyOrderRow)()
			For Each cellPoint As System.Drawing.Point In pivotGridControl1.MultiSelection.SelectedCells
				For Each record As PivotDrillDownDataRow In pivotGridControl1.GetCellInfo(cellPoint.X, cellPoint.Y).CreateDrillDownDataSource()
					OrderDrillDownList.Add(OrderSourceList(record.ListSourceRowIndex))
				Next record
			Next cellPoint
			lvOrders.ItemsSource = OrderDrillDownList
		End Sub
		Private Sub ThemedWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			pivotGridControl1.BestFitArea = DevExpress.Xpf.PivotGrid.FieldBestFitArea.FieldHeader
			pivotGridControl1.BestFit()
		End Sub
	End Class
End Namespace
