Public Class frmProductos
    Public Overrides Sub AsignarFormularioDetalle()
        formularioDetalle = New frmProducto
        tituloFormularioDetalle = "Producto"
    End Sub

    Public Overrides Sub CargarGrilla()
        Try
            nombreCampoBusqueda = "Nombre"
            dvwGenerico.Table = generar_datatabla("Select ProductoID, Codigo, Nombre, PrecioVenta, Existencia,Activo from Producto order by nombre")
            dgvLista.DataSource = dvwGenerico
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub EliminarRegistro()
        Try
            Dim id As Integer
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("ProductoID")
            If MsgBox("Esta seguro que desea eliminar el registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EjecutarSQL("Delete from Producto where ProductoID=@1", id)
                CargarGrilla()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As EventArgs) Handles dgvLista.DoubleClick
        DobleClick()
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        TotalRegistro()
    End Sub
End Class
