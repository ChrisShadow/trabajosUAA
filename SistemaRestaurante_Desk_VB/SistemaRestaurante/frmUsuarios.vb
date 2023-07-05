Public Class frmUsuarios
    Public Overrides Sub AsignarFormularioDetalle()
        formularioDetalle = New frmUsuario
        tituloFormularioDetalle = "Usuario"
    End Sub

    Public Overrides Sub CargarGrilla()
        Try
            nombreCampoBusqueda = "Nombre"
            dvwGenerico.Table = generar_datatabla("Select UsuarioID,Nombre,Email,Contraseña,Activo,TipoUsuario.Descripcion from Usuario join TipoUsuario on TipoUsuario.TipoUsuarioID=Usuario.TipoUsuarioID order by Nombre desc")
            dgvLista.DataSource = dvwGenerico
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub EliminarRegistro()
        Try
            Dim id As Integer
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UsuarioID")
            If MsgBox("Esta seguro que desea eliminar el registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EjecutarSQL("Delete from Usuario where UsuarioID=@1", id)
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
