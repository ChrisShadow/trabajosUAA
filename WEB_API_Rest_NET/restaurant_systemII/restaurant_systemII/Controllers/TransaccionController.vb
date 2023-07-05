Imports System.Web.Mvc
Imports ClasesRestaurante
Namespace Controllers
    Public Class TransaccionController
        Inherits Controller

        ' GET: Transaccion
        'Compra
        Function Compra() As ActionResult
            ViewData("compras") = Transaccion.ListarCompras.AsEnumerable
            Return View()
        End Function
        'Create Compra
        Function NuevaCompra() As ActionResult
            ViewData("producto") = Productos.RecuperarRegistrosProducto.AsEnumerable
            Return View()
        End Function

        <HttpPost()>
        Function NuevaCompra(form As FormCollection) As ActionResult
            Try
                Dim articulos() As String = form("idArticulo").Split(",").ToArray
                Dim cantidad() As String = form("cantidad").Split(",").ToArray
                Dim precios() As String = form("precio").Split(",").ToArray
                ''
                '' Iniciamos la transacción en la base de datos
                ''
                ClasesRestaurante.Util.IniciarTransaccion()
                'Definir Cabecera
                Dim vTransaccion As New Transaccion
                With vTransaccion
                    .pUsuarioID = 3
                    .pTransaccionID = 0
                    .pTipoOperacionID = 1
                    .pNroComprobante = form("nro_comprobante")
                    .pMonto = 0
                    .pFecha = form("fecha")
                    .pAnulado = "N"
                    .pTransaccionID = .Guardar
                End With
                'Insertar el Detalle
                'Validamos que la dimensión de los vectores coincidan
                If articulos.Length = cantidad.Length And articulos.Length = precios.Length And cantidad.Length = precios.Length Then
                    Dim subtotal As Decimal = 0
                    Dim total As Decimal = 0
                    For f As Integer = 0 To articulos.Length - 1
                        Dim vDetalle As New DetalleTransaccion
                        With vDetalle
                            .pCantidad = cantidad(f)
                            .pPrecio = precios(f)
                            .pProductoID = articulos(f)
                            .pTransaccionID = vTransaccion.pTransaccionID
                            'Obtenemos el subtotal del detalle
                            subtotal = cantidad(f) * precios(f)
                            total = total + subtotal
                            .Insertar()
                        End With
                        ''
                        '' Actualizamos la existencia del producto/Stock
                        ''
                        Productos.ActualizarExistencia(articulos(f), cantidad(f), vTransaccion.pTipoOperacionID) 'Le pasamos los parámetros correspondientes que serían los arreglos asignados
                    Next
                    'Obtenemos el objeto transaccion para actualizar el monto total
                    With vTransaccion
                        .pMonto = total
                        .InsertarMonto()
                    End With
                End If
                ''
                '' Confirmamos la transacción
                ''
                ClasesRestaurante.Util.TerminarTransaccion()
                Return RedirectToAction("Compra")
            Catch ex As Exception
                ''
                '' Abortamos la transacción
                ''
                ClasesRestaurante.Util.AbortarTransaccion()
                Throw ex
            End Try
        End Function
        Function DeleteC(id As Integer) As JsonResult
            Dim vtransaccion As New Transaccion
            Dim vdetalle As New DetalleTransaccion
            Dim dt As New DataTable
            Dim dtDetalle As New Data.DataTable("detalles")
            dtDetalle = DetalleTransaccion.RecuperarRegistroDetalle(id)
            If dtDetalle.Rows.Count > 0 Then
                For j As Integer = 0 To dtDetalle.Rows.Count - 1
                    With vdetalle
                        .pProductoID = dtDetalle.Rows(j).Item("ProductoID")
                        .pTransaccionID = dtDetalle.Rows(j).Item("TransaccionID")
                        .pDetalleTransaccionID = dtDetalle.Rows(j).Item("DetalleTransaccionID")
                        .pCantidad = dtDetalle.Rows(j).Item("Cantidad")
                        .pPrecio = dtDetalle.Rows(j).Item("Precio")
                        'Actualizar Stock y cabecera
                        ''
                        '' Actualizamos la existencia del producto/Stock
                        ''
                        Productos.ActualizarExistencia(.pProductoID, .pCantidad, 2) 'Le pasamos los parámetros correspondientes que serían los arreglos asignados
                        .Eliminar()
                    End With
                Next
                'Eliminar la cabecera
                vtransaccion.pTransaccionID = id
                vtransaccion.Eliminar()
                'Devolver las filas
                dt = Transaccion.ListarCompras
            End If
            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(dt))
        End Function

        'Venta
        Function Venta() As ActionResult
            ViewData("ventas") = Transaccion.ListarVentas.AsEnumerable
            Return View()
        End Function
        'Create Venta
        Function NuevaVenta() As ActionResult
            ViewData("producto") = Productos.RecuperarRegistrosProducto.AsEnumerable
            Return View()
        End Function
        <HttpPost()>
        Function NuevaVenta(form As FormCollection) As ActionResult
            Try
                Dim articulos() As String = form("idArticulo").Split(",").ToArray
                Dim cantidad() As String = form("cantidad").Split(",").ToArray
                Dim precios() As String = form("precio").Split(",").ToArray
                ''
                '' Iniciamos la transacción en la base de datos
                ''
                ClasesRestaurante.Util.IniciarTransaccion()
                'Definir Cabecera
                Dim vTransaccion As New Transaccion
                With vTransaccion
                    .pUsuarioID = 3
                    .pTransaccionID = 0
                    .pTipoOperacionID = 2
                    .pNroComprobante = form("nro_comprobante")
                    .pMonto = 0
                    .pFecha = form("fecha")
                    .pAnulado = "N"
                    .pTransaccionID = .Guardar
                End With
                'Insertar el Detalle
                'Validamos que la dimensión de los vectores coincidan
                If articulos.Length = cantidad.Length And articulos.Length = precios.Length And cantidad.Length = precios.Length Then
                    Dim subtotal As Decimal = 0
                    Dim total As Decimal = 0
                    For f As Integer = 0 To articulos.Length - 1
                        Dim vDetalle As New DetalleTransaccion
                        With vDetalle
                            .pCantidad = cantidad(f)
                            .pPrecio = precios(f)
                            .pProductoID = articulos(f)
                            .pTransaccionID = vTransaccion.pTransaccionID
                            'Obtenemos el subtotal del detalle
                            subtotal = cantidad(f) * precios(f)
                            total = total + subtotal
                            .Insertar()
                        End With
                        ''
                        '' Actualizamos la existencia del producto/Stock
                        ''
                        Productos.ActualizarExistencia(articulos(f), cantidad(f), vTransaccion.pTipoOperacionID) 'Le pasamos los parámetros correspondientes que serían los arreglos asignados
                    Next
                    'Obtenemos el objeto transaccion para actualizar el monto total
                    With vTransaccion
                        .pMonto = total
                        .InsertarMonto()
                    End With
                End If
                ''
                '' Confirmamos la transacción
                ''
                ClasesRestaurante.Util.TerminarTransaccion()
                Return RedirectToAction("Venta")
            Catch ex As Exception
                ''
                '' Abortamos la transacción
                ''
                ClasesRestaurante.Util.AbortarTransaccion()
                Throw ex
            End Try
        End Function
        Function DeleteV(id As Integer) As JsonResult
            Dim vtransaccion As New Transaccion
            Dim vdetalle As New DetalleTransaccion
            Dim dt As New DataTable
            Dim dtDetalle As New Data.DataTable("detalles")
            dtDetalle = DetalleTransaccion.RecuperarRegistroDetalle(id)
            If dtDetalle.Rows.Count > 0 Then
                For j As Integer = 0 To dtDetalle.Rows.Count - 1
                    With vdetalle
                        .pProductoID = dtDetalle.Rows(j).Item("ProductoID")
                        .pTransaccionID = dtDetalle.Rows(j).Item("TransaccionID")
                        .pDetalleTransaccionID = dtDetalle.Rows(j).Item("DetalleTransaccionID")
                        .pCantidad = dtDetalle.Rows(j).Item("Cantidad")
                        .pPrecio = dtDetalle.Rows(j).Item("Precio")
                        'Actualizar Stock y cabecera
                        ''
                        '' Actualizamos la existencia del producto/Stock
                        ''
                        Productos.ActualizarExistencia(.pProductoID, .pCantidad, 1) 'Le pasamos los parámetros correspondientes que serían los arreglos asignados
                        .Eliminar()
                    End With
                Next
                'Eliminar la cabecera
                vtransaccion.pTransaccionID = id
                vtransaccion.Eliminar()
                'Devolver las filas
                dt = Transaccion.ListarCompras
            End If
            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(dt))
        End Function
    End Class
End Namespace