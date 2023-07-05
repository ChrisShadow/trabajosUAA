Imports ClasesRestaurante
'Para establecer los requerimientos de los datos conectanando a la base de datos correspondiente
Public Class ProductoRepositorio
    'Obetener productos por categoría 
    Public Function GetProductos(id As Integer) As List(Of Productos) ' mediante el id de categóría
        Util.inicializaSesion("CHRISZ\SQLEXPRESS", "Restaurante_DOS", "sa", "123456")

        Dim ListProductos As New List(Of Productos)
        Dim dt As New DataTable
        dt = Productos.RecuperarProductosPorCategoria(id)
        If dt.Rows.Count > 0 Then
            For f As Integer = 0 To dt.Rows.Count - 1
                Dim objProducto As New Productos
                'Asignar los datos del datatable(tabla en memoria de los campos de la tabla producto)
                With objProducto
                    .pvActivo = dt.Rows(f).Item("Activo")
                    .pCategoriaID = dt.Rows(f).Item("CategoriaID")
                    .pCodigo = dt.Rows(f).Item("Codigo")
                    .pCosto = dt.Rows(f).Item("Costo")
                    .pStock = dt.Rows(f).Item("Existencia")
                    .pNombre = dt.Rows(f).Item("Nombre")
                    .pPrecioVenta = dt.Rows(f).Item("PrecioVenta")
                    .pPreparacion = dt.Rows(f).Item("Preparacion")
                    .pPresentacion = dt.Rows(f).Item("Presentacion")
                    .pUnidadMedidaID = dt.Rows(f).Item("UnidadMedidaID")
                    .pProductoID = dt.Rows(f).Item("ProductoID")
                End With
                'Asignar a la lista el objeto  
                ListProductos.Add(objProducto)
                'Limpiar el objeto para el siguiente registro 
                objProducto = Nothing
            Next
        Else
            'Producto inexistente mediante la categoría seleccionada
            Return Nothing
        End If
        'Retornar la lista producto convertir a una lista
        Return ListProductos.ToList
    End Function
End Class
