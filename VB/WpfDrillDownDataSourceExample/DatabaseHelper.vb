Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace WpfDrillDownDataSourceExample

    Public Module DatabaseHelper

'#Region "Fields"
        Private ReadOnly random As System.Random = New System.Random()

        Private ReadOnly FirstNames As String() = {"Julia", "Stephanie", "Alex", "John", "Curtis", "Keith", "Timothy", "Jack", "Miranda", "Alice"}

        Private ReadOnly LastNames As String() = {"Black", "White", "Brown", "Smith", "Cooper", "Parker", "Walker", "Hunter", "Burton", "Douglas", "Fox", "Simpson"}

        Private ReadOnly Adjectives As String() = {"Ancient", "Modern", "Mysterious", "Elegant", "Red", "Green", "Blue", "Amazing", "Wonderful", "Astonishing", "Lovely", "Beautiful", "Inexpensive", "Famous", "Magnificent", "Fancy"}

        Private ReadOnly ProductNames As String() = {"Ice Cubes", "Bicycle", "Desk", "Hamburger", "Notebook", "Tea", "Cellphone", "Butter", "Frying Pan", "Napkin", "Armchair", "Chocolate", "Yoghurt", "Statuette", "Keychain"}

        Private ReadOnly CategoryNames As String() = {"Business", "Presents", "Accessories", "Home", "Hobby"}

        Private ReadOnly CustomerNames As String()

        Private ReadOnly SalesPersonNames As String()

        Private ReadOnly Products As WpfDrillDownDataSourceExample.ProductDataRecord()

'#End Region
        Sub New()
            WpfDrillDownDataSourceExample.DatabaseHelper.CustomerNames = WpfDrillDownDataSourceExample.DatabaseHelper.GenerateUniqueValues(Of System.[String])(CInt((WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](CInt((40)), CInt((50))))), CType((AddressOf WpfDrillDownDataSourceExample.DatabaseHelper.GeneratePersonName), System.Func(Of System.[String]))).ToArray()
            WpfDrillDownDataSourceExample.DatabaseHelper.SalesPersonNames = WpfDrillDownDataSourceExample.DatabaseHelper.GenerateUniqueValues(Of System.[String])(CInt((WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](CInt((40)), CInt((50))))), CType((AddressOf WpfDrillDownDataSourceExample.DatabaseHelper.GeneratePersonName), System.Func(Of System.[String]))).ToArray()
            WpfDrillDownDataSourceExample.DatabaseHelper.Products = WpfDrillDownDataSourceExample.DatabaseHelper.GenerateProducts()
        End Sub

'#Region "Public"
        Public Function CreateData() As ObservableCollection(Of WpfDrillDownDataSourceExample.MyOrderRow)
            Dim orderList As System.Collections.ObjectModel.ObservableCollection(Of WpfDrillDownDataSourceExample.MyOrderRow) = New System.Collections.ObjectModel.ObservableCollection(Of WpfDrillDownDataSourceExample.MyOrderRow)()
            For i As Integer = 0 To 1500 - 1
                Dim row As WpfDrillDownDataSourceExample.MyOrderRow = New WpfDrillDownDataSourceExample.MyOrderRow()
                row.ID = i
                Dim product = WpfDrillDownDataSourceExample.DatabaseHelper.GetProduct()
                row.OrderDate = WpfDrillDownDataSourceExample.DatabaseHelper.GetOrderDate()
                row.Quantity = WpfDrillDownDataSourceExample.DatabaseHelper.GetQuantity()
                row.UnitPrice = WpfDrillDownDataSourceExample.DatabaseHelper.GetProductPrice(product)
                row.ExtendedPrice = row.Quantity * row.UnitPrice
                row.CustomerName = WpfDrillDownDataSourceExample.DatabaseHelper.GetCustomerName()
                row.ProductName = product.ProductName
                row.CategoryName = product.CategoryName
                row.SalesPersonName = WpfDrillDownDataSourceExample.DatabaseHelper.GetSalesPersonName()
                orderList.Add(row)
            Next

            Return orderList
        End Function

        Public Function GetOrderDate() As DateTime
            Return New System.DateTime(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](2017, 2019), WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](1, 13), WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](1, 28))
        End Function

        Public Function GetQuantity() As Integer
            Return WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](1, 100)
        End Function

        Public Function GetProductPrice(ByVal product As WpfDrillDownDataSourceExample.ProductDataRecord) As Decimal
            Dim price = product.UnitPrice * CDec((0.5 + WpfDrillDownDataSourceExample.DatabaseHelper.random.NextDouble()))
            Return System.Math.Round(price, 2)
        End Function

        Public Function GetProduct() As ProductDataRecord
            Return WpfDrillDownDataSourceExample.DatabaseHelper.Products(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.Products.Length))
        End Function

        Public Function GetCustomerName() As String
            Return WpfDrillDownDataSourceExample.DatabaseHelper.CustomerNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.CustomerNames.Length))
        End Function

        Public Function GetSalesPersonName() As String
            Return WpfDrillDownDataSourceExample.DatabaseHelper.SalesPersonNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.SalesPersonNames.Length))
        End Function

'#End Region
'#Region "Private"
        Private Function GenerateUniqueValues(Of T)(ByVal count As Integer, ByVal generateValue As System.Func(Of T)) As List(Of T)
            Dim values = New System.Collections.Generic.HashSet(Of T)()
            While values.Count < count
                Dim value = generateValue()
                If Not values.Contains(value) Then values.Add(value)
            End While

            Return values.ToList()
        End Function

        Private Function GenerateProducts() As WpfDrillDownDataSourceExample.ProductDataRecord()
            Return GenerateUniqueValues(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](80, 100), New Global.System.Func(Of System.String)(AddressOf WpfDrillDownDataSourceExample.DatabaseHelper.GenerateProductName)).[Select](Function(productName) New WpfDrillDownDataSourceExample.ProductDataRecord With {.ProductName = productName, .UnitPrice = WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](10, 500), .CategoryName = WpfDrillDownDataSourceExample.DatabaseHelper.GenerateCategoryName()}).ToArray()
        End Function

        Private Function GenerateCategoryName() As String
            Return WpfDrillDownDataSourceExample.DatabaseHelper.CategoryNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.CategoryNames.Length))
        End Function

        Private Function GeneratePersonName() As String
            Return WpfDrillDownDataSourceExample.DatabaseHelper.FirstNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.FirstNames.Length)) & " " & WpfDrillDownDataSourceExample.DatabaseHelper.LastNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.LastNames.Length))
        End Function

        Private Function GenerateProductName() As String
            Return WpfDrillDownDataSourceExample.DatabaseHelper.Adjectives(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.Adjectives.Length)) & " " & WpfDrillDownDataSourceExample.DatabaseHelper.ProductNames(WpfDrillDownDataSourceExample.DatabaseHelper.random.[Next](WpfDrillDownDataSourceExample.DatabaseHelper.ProductNames.Length))
        End Function
'#End Region
    End Module

    Public Class ProductDataRecord

        Public Property ProductName As String

        Public Property CategoryName As String

        Public Property UnitPrice As Decimal
    End Class
End Namespace
