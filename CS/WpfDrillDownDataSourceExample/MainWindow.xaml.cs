using DevExpress.Xpf.Core;
using DevExpress.Xpf.PivotGrid;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfDrillDownDataSourceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : ThemedWindow
    {
        public ObservableCollection<MyOrderRow> OrderSourceList { get; set; }
        public ObservableCollection<MyOrderRow> OrderDrillDownList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OrderSourceList = DatabaseHelper.CreateData();
            pivotGridControl1.DataSource = OrderSourceList;
        }
        private void PivotGridControl1_CellSelectionChanged(object sender, RoutedEventArgs e)
        {
            OrderDrillDownList = new ObservableCollection<MyOrderRow>();
            foreach (System.Drawing.Point cellPoint in pivotGridControl1.MultiSelection.SelectedCells)
            {
                foreach (PivotDrillDownDataRow record in pivotGridControl1.GetCellInfo(cellPoint.X, cellPoint.Y).CreateDrillDownDataSource())
                {
                    OrderDrillDownList.Add(OrderSourceList[record.ListSourceRowIndex]);
                }
            }
            lvOrders.ItemsSource = OrderDrillDownList;
        }
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            pivotGridControl1.BestFitArea = DevExpress.Xpf.PivotGrid.FieldBestFitArea.FieldHeader;
            pivotGridControl1.BestFit();
        }
    }
}
