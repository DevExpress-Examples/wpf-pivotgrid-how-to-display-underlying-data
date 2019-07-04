using System;
using System.Collections.ObjectModel;

namespace WpfDrillDownDataSourceExample
{
    public class MyOrderRow
    {
        public int ID { get; internal set; }
        public DateTime OrderDate { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal UnitPrice { get; internal set; }
        public string CustomerName { get; internal set; }
        public string ProductName { get; internal set; }
        public string CategoryName { get; internal set; }
        public string SalesPersonName { get; internal set; }
        public decimal ExtendedPrice { get; internal set; }
    }

    public class MyOrderDataList : ObservableCollection<MyOrderRow> { }
}