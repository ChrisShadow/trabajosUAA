Imports ClasesRestaurante
Public Class VentaRepositorio
    Public Function GetVentas(FechaI As Date, FechaF As Date) As List(Of Ventas)
        Util.inicializaSesion("CHRISZ\SQLEXPRESS", "Restaurante_DOS", "sa", "123456")

        Dim ListVentas As New List(Of Ventas)
        Dim dt As New DataTable
        dt = Ventas.RecuperarRegistroVenta(FechaI, FechaF)
        If dt.Rows.Count > 0 Then
            'Dim Subtot(dt.Rows.Count) As Integer
            For f As Integer = 0 To dt.Rows.Count - 1
                Dim objVenta As New Ventas
                'Asignar los datos del datatable(tabla en memoria de los campos de las tablas involucradas)
                With objVenta
                    .pNroComprobante = dt.Rows(f).Item("NroComprobante")
                    .pFecha = dt.Rows(f).Item("Fecha")
                    .pAnulado = dt.Rows(f).Item("Estado")
                    .pProductoID = dt.Rows(f).Item("ProductoID")
                    .pNombre = dt.Rows(f).Item("Nombre")
                    .pCantidad = dt.Rows(f).Item("Cantidad")
                    .pPrecio = dt.Rows(f).Item("Precio")
                    'Subtot(f) = .CalcularSubtotalVenta()
                    '.Subtotal.Add(Subtot(f))
                    '.Subtotal.Add(.CalcularSubtotalVenta())
                End With
                'objVenta.Subtotal.Add(Subtot(f))
                'Asignar a la lista el objeto  
                ListVentas.Add(objVenta)
                'Limpiar el objeto para el siguiente registro 
                objVenta = Nothing
            Next
        Else
            'Producto inexistente mediante la categoría seleccionada
            Return Nothing
        End If
        'Retornar la lista producto convertir a una lista
        Return ListVentas.ToList
    End Function
End Class
