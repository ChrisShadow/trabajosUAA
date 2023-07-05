Imports ClasesRestaurante.Util
Public Class Transaccion
    'Definir los atributos de la clase
    Private TransaccionID As Integer
    Private TipoOperacionID As Integer
    Private Fecha As Date
    Private UsuarioID As Integer
    Private Anulado As String
    Private Monto As Decimal
    Private NroComprobante As String

    'Definir las propiedades
    Public Property pTransaccionID As Integer
        Get
            Return TransaccionID
        End Get
        Set(value As Integer)
            TransaccionID = value
        End Set
    End Property

    Public Property pTipoOperacionID As Integer
        Get
            Return TipoOperacionID
        End Get
        Set(value As Integer)
            TipoOperacionID = value
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

    Public Property pUsuarioID As Integer
        Get
            Return UsuarioID
        End Get
        Set(value As Integer)
            UsuarioID = value
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

    Public Property pMonto As Decimal
        Get
            Return Monto
        End Get
        Set(value As Decimal)
            Monto = value
        End Set
    End Property

    Public Property pNroComprobante As String
        Get
            Return NroComprobante
        End Get
        Set(value As String)
            NroComprobante = value
        End Set
    End Property
    'Definir los métodos
    Public Shared Function ListarCompras() As DataTable
        Try
            Dim dtComp As New Data.DataTable("Compras")
            dtComp = gDatos.TraerDataTable("spListarCompras")
            Return dtComp
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListarVentas() As DataTable
        Try
            Dim dtVent As New Data.DataTable("Ventas")
            dtVent = gDatos.TraerDataTable("spListarVentas")
            Return dtVent
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar() As Integer
        'Creamos una función para guardar la cabecera y retornar el ID. 
        Dim TransaccionID As Integer = 0
        Try
            'Utilizamos la función TraerValor porque el proc. devuelve un valor
            TransaccionID = gDatos.TraerValor("spInsertarTransaccion", Me.TipoOperacionID, Me.Fecha, Me.UsuarioID, Me.Anulado, Me.pNroComprobante, Me.TransaccionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return TransaccionID
    End Function
    Sub InsertarMonto()
        Try
            gDatos.Ejecutar("spActualizarTransaccion", Me.TransaccionID, Me.Monto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarTransaccion", Me.TransaccionID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
