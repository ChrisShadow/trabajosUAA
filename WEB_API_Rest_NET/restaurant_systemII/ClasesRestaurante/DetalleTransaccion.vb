Imports ClasesRestaurante.Util
Public Class DetalleTransaccion
    'Definir los atributos de la clase
    Private DetalleTransaccionID As Integer
    Private TransaccionID As Integer
    Private ProductoID As Integer
    Private Cantidad As Integer
    Private Precio As Decimal

    'Definir las propiedades
    Public Property pDetalleTransaccionID As Integer
        Get
            Return DetalleTransaccionID
        End Get
        Set(value As Integer)
            DetalleTransaccionID = value
        End Set
    End Property

    Public Property pTransaccionID As Integer
        Get
            Return TransaccionID
        End Get
        Set(value As Integer)
            TransaccionID = value
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
    'Definir los métodos
    Sub Insertar()
        Try
            gDatos.Ejecutar("spInsertarDetalleTransaccion", Me.TransaccionID, Me.ProductoID, Me.Cantidad, Me.Precio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function RecuperarRegistroDetalle(ByVal vCodigo As Integer) As DataTable
        Try
            Return gDatos.TraerDataTable("spConsultarDetalles", vCodigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarDetalle", Me.DetalleTransaccionID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
