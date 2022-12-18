<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/195058597/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828661)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Pivot Grid for WPF - How to Display Underlying Records


This example demonstrates how to obtain records from the control's underlying data source for a selected cell or multiple selected cells.

* Click a cell to show the underlying data in the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl).
* Select multiple cells to show the order IDs of the orders summarized in the selected cells. Order IDs are displayed as buttons in the [ItemsControl](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.itemscontrol) control.

![](/images/screenshot.png)

The [PivotGridControl.CellClick](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CellClick) event is handled in XAML with the [DXEvent](https://docs.devexpress.com/WPF/115778) DevExpress MVVM framework extension. When the cell is clicked, the [CreateDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotCellBaseEventArgs.CreateDrillDownDataSource) method returns the [PivotDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotDrillDownDataSource) instance that contains underlying data for the current cell. The `PivotDrillDownDataSource` object is used as the GridControl's data source (it is assigned to the [GridControl.ItemsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ItemsSource) property.)


The [PivotGridControl.CellSelectionChanged](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CellSelectionChanged) event is handled in the code-behind. The coordinates of the selected cells are obtained with the [PivotGridControl.MultiSelection.SelectedCells](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.Selection.IMultipleSelection.SelectedCells) notation. For each (X, Y) pair of cell coordinates, the [PivotGridControl.GetCellInfo](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.GetCellInfo(System.Int32-System.Int32)) method returns an object whose  [CreateDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotCellBaseEventArgs.CreateDrillDownDataSource) method yields the [PivotDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotDrillDownDataSource) object. The `PivotDrillDownDataSource` exposes an enumerator and supports an iteration over a collection of [PivotDrillDownDataRow](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotDrillDownDataRow) objects. The [PivotDrillDownDataRow.ListSourceRowIndex](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotDrillDownDataRow.ListSourceRowIndex) property value is an index of the record in the original data source, so the source record is also available and can be added to a collection. The resulting collection is bound to [ItemsControl](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.itemscontrol) for display.


## Files to Look At

- [MainWindow.xaml](./CS/WpfDrillDownDataSourceExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfDrillDownDataSourceExample/MainWindow.xaml))
- [MainWindow.xaml.cs](./CS/WpfDrillDownDataSourceExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfDrillDownDataSourceExample/MainWindow.xaml.vb))
- [DatabaseHelper.cs](./CS/WpfDrillDownDataSourceExample/DatabaseHelper.cs) (VB: [DatabaseHelper.vb](./VB/WpfDrillDownDataSourceExample/DatabaseHelper.vb))

## Documentation

- [Drill Down to the Underlying Data](https://docs.devexpress.com/WPF/8056)
- [Asynchronous Mode](https://docs.devexpress.com/WPF/9776)

## More Examples

-  [Pivot Grid for WPF - How to Display Underlying (Drill-Down) Records](https://github.com/DevExpress-Examples/how-to-obtain-underlying-data-e2173)
