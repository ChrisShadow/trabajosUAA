Imports ClasesRestaurante.Util
Public Class Productos
    'Definir los atributos de la clase
    Private ProductoID As Integer
    Private Codigo As Integer
    Private Nombre As String
    Private Preparacion As String
    Private Costo As Integer
    Private PrecioVenta As Integer
    Private UnidadMedidaID As Integer
    Private Presentacion As String
    Private UsaIngrediente As String
    Private vActivo As String
    Private CategoriaID As Integer
    Private Stock As Integer

    Public Property pProductoID As Integer
        Get
            Return ProductoID
        End Get
        Set(value As Integer)
            ProductoID = value
        End Set
    End Property

    Public Property pCodigo As Integer
        Get
            Return Codigo
        End Get
        Set(value As Integer)
            Codigo = value
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

    Public Property pPreparacion As String
        Get
            Return Preparacion
        End Get
        Set(value As String)
            Preparacion = value
        End Set
    End Property

    Public Property pCosto As Integer
        Get
            Return Costo
        End Get
        Set(value As Integer)
            Costo = value
        End Set
    End Property

    Public Property pPrecioVenta As Integer
        Get
            Return PrecioVenta
        End Get
        Set(value As Integer)
            PrecioVenta = value
        End Set
    End Property

    Public Property pUnidadMedidaID As Integer
        Get
            Return UnidadMedidaID
        End Get
        Set(value As Integer)
            UnidadMedidaID = value
        End Set
    End Property

    Public Property pPresentacion As String
        Get
            Return Presentacion
        End Get
        Set(value As String)
            Presentacion = value
        End Set
    End Property

    Public Property pUsaIngrediente As String
        Get
            Return UsaIngrediente
        End Get
        Set(value As String)
            UsaIngrediente = value
        End Set
    End Property

    Public Property pvActivo As String
        Get
            Return vActivo
        End Get
        Set(value As String)
            vActivo = value
        End Set
    End Property

    Public Property pCategoriaID As Integer
        Get
            Return CategoriaID
        End Get
        Set(value As Integer)
            CategoriaID = value
        End Set
    End Property

    Public Property pStock As Integer
        Get
            Return Stock
        End Get
        Set(value As Integer)
            Stock = value
        End Set
    End Property

    'Definir los métodos

    Public Shared Function RecuperarRegistrosProducto() As DataTable
        Try
            Dim dtProducto As New Data.DataTable("Producto")
            dtProducto = gDatos.TraerDataTable("spListarProductos")
            Return dtProducto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'método para insertar datos en producto
    Public Sub Insertar()
        Try
            gDatos.Ejecutar("spInsertarProductos", Me.Codigo, Me.Nombre, Me.Preparacion, Me.Costo, Me.PrecioVenta, Me.UnidadMedidaID, Me.Presentacion, Me.UsaIngrediente, Me.vActivo, Me.CategoriaID, Me.Stock)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'método para aztualizar datos en producto
    Public Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarProductos", Me.ProductoID, Me.Codigo, Me.Nombre, Me.Preparacion, Me.Costo, Me.PrecioVenta, Me.UnidadMedidaID, Me.Presentacion, Me.UsaIngrediente, Me.vActivo, Me.CategoriaID, Me.Stock)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Para compra
    'Actualizar la existencia actual o stock del prodcuto, Shared para llamar al método sin crear el objeto
    Public Shared Sub ActualizarExistencia(_ProductoID As Integer, _Cantidad As Integer, _TipoOper As Integer)
        Try
            gDatos.Ejecutar("spActulizarExistencia", _ProductoID, _Cantidad, _TipoOper)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'método para eliminar datos en producto
    Public Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarProductos", Me.ProductoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Para consultar
    Public Function RecuperarRegistro(ByVal vCodigo As Integer) As Productos
        Try
            Dim dtProducto As New Data.DataTable("Producto")
            dtProducto = gDatos.TraerDataTable("spConsultarProductos", vCodigo)
            If dtProducto.Rows.Count > 0 Then
                Dim vProducto As New Productos
                vProducto.pProductoID = dtProducto.Rows(0).Item("ProductoID")
                vProducto.pCodigo = CStr(dtProducto.Rows(0).Item("Codigo").ToString)
                vProducto.pNombre = dtProducto.Rows(0).Item("Nombre")
                vProducto.pPreparacion = dtProducto.Rows(0).Item("Preparacion")
                vProducto.pCosto = CInt(dtProducto.Rows(0).Item("Costo").ToString)
                vProducto.pPrecioVenta = CInt(dtProducto.Rows(0).Item("PrecioVenta").ToString)
                vProducto.pUnidadMedidaID = dtProducto.Rows(0).Item("UnidadMedidaID")
                vProducto.pPresentacion = dtProducto.Rows(0).Item("Presentacion")
                vProducto.pUsaIngrediente = dtProducto.Rows(0).Item("UsaIngrediente")
                vProducto.pvActivo = dtProducto.Rows(0).Item("Activo")
                vProducto.pCategoriaID = dtProducto.Rows(0).Item("CategoriaID")
                vProducto.pStock = dtProducto.Rows(0).Item("Existencia")
                Return vProducto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
