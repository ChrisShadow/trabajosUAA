Public Class frmUnidadesMedida
    Public Overrides Sub AsignarFormularioDetalle()
        formularioDetalle = New frmUnidadMedida
        tituloFormularioDetalle = "Unidad de Medida"
    End Sub

    Public Overrides Sub CargarGrilla()
        Try
            nombreCampoBusqueda = "Descripcion"
            dvwGenerico.Table = generar_datatabla("Select * from UnidadMedida order by Descripcion")
            dgvLista.DataSource = dvwGenerico
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub EliminarRegistro()
        Try
            Dim id As Integer
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UnidadMedidaID")
            If MsgBox("Esta seguro que desea eliminar el registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EjecutarSQL("Delete from UnidadMedida where UnidadMedidaID=@1", id)
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
