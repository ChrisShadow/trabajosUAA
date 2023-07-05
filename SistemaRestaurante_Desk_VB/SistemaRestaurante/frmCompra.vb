

'Public Class frmCompra
'    Dim id As Integer
'    Dim UltimoTransaccionID As Integer
'    Dim ProductoSeleccionadoID As Integer

'    Private Sub FrmCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        If vAccion = EnumAccion.accAgregar Then
'            CargarCombo()
'            dtFechaCompra.Select()
'            gbxDetalle.Enabled = False
'        ElseIf vAccion = EnumAccion.accModificar Then
'            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UnidadMedidaID")
'            Dim tabla As New DataTable("UnidadMedida")
'            tabla = generar_datatabla("Select * from UnidadMedida where UnidadMedidaID =" & id)
'            If tabla.Rows.Count > 0 Then
'                '  txtDescripcion.Text = tabla.Rows(0).Item("Descripcion")
'            End If
'        End If
'    End Sub

'    Sub CargarCombo()
'        Try
'            With cboProducto
'                .DataSource = generar_datatabla("Select * from Producto order by Nombre desc")
'                .DisplayMember = "Nombre"
'                .ValueMember = "ProductoID"
'            End With
'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Private Sub BtnHabilitarDetalle_Click(sender As Object, e As EventArgs) Handles btnHabilitarDetalle.Click
'        Try
'            '
'            'Iniciar la transacción
'            '
'            EjecutarSQL("insert Transaccion values(@1,@2,@3,@4)", 1, dtFechaCompra.Text, 2, "N")
'            gbxDetalle.Enabled = True


'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
'        Try
'            If ValidarDetalle() = True Then
'                ''
'                '' Paso 1
'                ''
'                UltimoTransaccionID = TraerValor("Select Isnull(max(TransaccionID),0) as TransaccionID from Transaccion")
'                ProductoSeleccionadoID = cboProducto.SelectedValue

'                ''
'                '' Paso 2
'                ''
'                EjecutarSQL("insert DetalleTransaccion values(@1,@2,@3,@4)", UltimoTransaccionID, ProductoSeleccionadoID, nudCantidad.Value, nudPrecio.Value)

'                ''
'                '' Actualizar el stock en producto
'                ''
'                EjecutarSQL("update Producto set Existencia=isnull(Existencia,0) + @1 where ProductoID=@2", nudCantidad.Value, ProductoSeleccionadoID)

'                RecuperarDetalle()
'                LimpiarDetalle()
'            End If


'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Sub RecuperarDetalle()
'        Try
'            Dim dtDetalleTransaccion As New DataTable

'            dtDetalleTransaccion = generar_datatabla("select p.ProductoID,p.Nombre,dt.Precio,dt.Cantidad from DetalleTransaccion dt join Producto p on p.ProductoID=dt.ProductoID where TransaccionID=" & UltimoTransaccionID)

'            dgvDetalle.DataSource = dtDetalleTransaccion

'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Sub LimpiarDetalle()
'        cboProducto.SelectedIndex = -1
'        nudPrecio.Value = 0
'        nudCantidad.Value = 0
'        cboProducto.Focus()
'    End Sub

'    Function ValidarDetalle() As Boolean
'        If cboProducto.Text = "" Then
'            MsgBox("Debe seleccionar un producto.")
'            cboProducto.Focus()
'            Return False
'        End If

'        If nudCantidad.Value = 0 Then
'            MsgBox("La cantidad debe ser mayor a cero.")
'            nudCantidad.Focus()
'            Return False
'        End If

'        If nudPrecio.Value = 0 Then
'            MsgBox("El precio de compra debe ser mayor a cero.")
'            nudPrecio.Focus()
'            Return False
'        End If



'        Return True
'    End Function


'    Public Overrides Sub Aceptar()
'        Try
'            If vAccion = EnumAccion.accAgregar Then
'                ''
'                '' Confirmar la operación
'                ''
'            ElseIf vAccion = EnumAccion.accModificar Then

'            End If
'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Public Overrides Function ValidarDatos() As Boolean

'        Return True
'    End Function
'End Class



Imports System.Data.SqlClient
Public Class frmCompra
    Dim id As Integer
    Dim UltimoTransaccionID As Integer
    Dim ProductoSeleccionadoID As Integer
    ''
    '' Definimos una varible para la transacción
    ''
    Dim MiTransaccion As SqlTransaction
    Private Sub FrmCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vAccion = EnumAccion.accAgregar Then
            CargarCombo()
            dtFechaCompra.Select()
            gbxDetalle.Enabled = False
        ElseIf vAccion = EnumAccion.accModificar Then
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UnidadMedidaID")
            Dim tabla As New DataTable("UnidadMedida")
            tabla = generar_datatabla("Select * from UnidadMedida where UnidadMedidaID =" & id)
            If tabla.Rows.Count > 0 Then
                '  txtDescripcion.Text = tabla.Rows(0).Item("Descripcion")
            End If
        End If
    End Sub

    Sub CargarCombo()
        Try
            With cboProducto
                .DataSource = generar_datatabla("Select * from Producto order by Nombre desc")
                .DisplayMember = "Nombre"
                .ValueMember = "ProductoID"
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnHabilitarDetalle_Click(sender As Object, e As EventArgs) Handles btnHabilitarDetalle.Click
        Try
            ''
            '' PASO 1
            '' Iniciar la transacción
            ''
            MiTransaccion = IniciarTransaccion()

            EjecutarSQL("insert Transaccion values(@1,@2,@3,@4)", MiTransaccion, 1, dtFechaCompra.Text, 2, "N")
            gbxDetalle.Enabled = True


        Catch ex As Exception
            AnularTransaccion(MiTransaccion)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If ValidarDetalle() = True Then
                ''
                '' PASO 2
                ''
                UltimoTransaccionID = TraerValor("Select Isnull(max(TransaccionID),0) as TransaccionID from Transaccion", MiTransaccion)
                ProductoSeleccionadoID = cboProducto.SelectedValue

                ''
                '' PASO 3
                ''
                EjecutarSQL("insert DetalleTransaccion values(@1,@2,@3,@4)", MiTransaccion, UltimoTransaccionID, ProductoSeleccionadoID, nudCantidad.Value, nudPrecio.Value)

                ''
                '' PASO 4
                '' Actualizar el stock en producto
                ''
                EjecutarSQL("update Producto set Existencia=isnull(Existencia,0) + @1 where ProductoID=@2", MiTransaccion, nudCantidad.Value, ProductoSeleccionadoID)

                RecuperarDetalle()
                LimpiarDetalle()
            End If


        Catch ex As Exception
            AnularTransaccion(MiTransaccion)
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RecuperarDetalle()
        Try
            Dim dtDetalleTransaccion As New DataTable

            dtDetalleTransaccion = generar_datatabla("select p.ProductoID,p.Nombre,dt.Precio,dt.Cantidad from DetalleTransaccion dt join Producto p on p.ProductoID=dt.ProductoID where TransaccionID=" & UltimoTransaccionID, MiTransaccion)

            dgvDetalle.DataSource = dtDetalleTransaccion

        Catch ex As Exception
            AnularTransaccion(MiTransaccion)
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub LimpiarDetalle()
        cboProducto.SelectedIndex = -1
        nudPrecio.Value = 0
        nudCantidad.Value = 0
        cboProducto.Focus()
    End Sub

    Function ValidarDetalle() As Boolean
        If cboProducto.Text = "" Then
            MsgBox("Debe seleccionar un producto.")
            cboProducto.Focus()
            Return False
        End If

        If nudCantidad.Value = 0 Then
            MsgBox("La cantidad debe ser mayor a cero.")
            nudCantidad.Focus()
            Return False
        End If

        If nudPrecio.Value = 0 Then
            MsgBox("El precio de compra debe ser mayor a cero.")
            nudPrecio.Focus()
            Return False
        End If



        Return True
    End Function


    Public Overrides Sub Aceptar()
        Try
            If vAccion = EnumAccion.accAgregar Then
                ''
                '' PASO 5
                '' Confirmar la operación
                ''
                ConfirmarTransaccion(MiTransaccion)

            ElseIf vAccion = EnumAccion.accModificar Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Function ValidarDatos() As Boolean
        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        AnularTransaccion(MiTransaccion)
    End Sub


End Class
