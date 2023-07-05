Imports ClasesRestaurante.Util
Public Class Ventas
    Private NroComprobante As String
    Private Fecha As Date
    Private Anulado As String
    Private ProductoID As Integer
    Private Nombre As String
    Private Cantidad As Integer
    Private Precio As Decimal

    Public Subtotal As New List(Of Integer)
    Public Property pNroComprobante As String
        Get
            Return NroComprobante
        End Get
        Set(value As String)
            NroComprobante = value
        End Set
    End Property

    Public Property pFecha As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property

    Public Property pAnulado As String
        Get
            Return Anulado
        End Get
        Set(value As String)
            Anulado = value
        End Set
    End Property

    Public Property pProductoID As Integer
        Get
            Return ProductoID
        End Get
        Set(value As Integer)
            ProductoID = value
        End Set
    End Property

    Public Property pNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property pCantidad As Integer
        Get
            Return Cantidad
        End Get
        Set(value As Integer)
            Cantidad = value
        End Set
    End Property

    Public Property pPrecio As Decimal
        Get
            Return Precio
        End Get
        Set(value As Decimal)
            Precio = value
        End Set
    End Property

    Public Shared Function RecuperarRegistroVenta(ByVal FechaI As Date, ByVal FechaF As Date) As DataTable
        Try
            Dim dtVentas As New Data.DataTable("Ventas")
            dtVentas = gDatos.TraerDataTable("spConsultarVtaXFecha", FechaI, FechaF)
            Return dtVentas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CalcularSubtotalVenta()
        Dim Subtotal As Integer
        Subtotal = pCantidad * pPrecio
        Return Subtotal
    End Function
End Class
