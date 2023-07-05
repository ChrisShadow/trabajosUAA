
Public Class frmCompras
    Public Overrides Sub AsignarFormularioDetalle()
        formularioDetalle = New frmCompra
        tituloFormularioDetalle = "Compra"
    End Sub

    Public Overrides Sub CargarGrilla()
        Try
            nombreCampoBusqueda = "Usuario"
            dvwGenerico.Table = generar_datatabla("Select Transaccion.TransaccionID as CodTransaccion,Transaccion.Fecha,Usuario.Nombre as Usuario,Transaccion.Anulado from Transaccion join Usuario on Usuario.UsuarioID=Transaccion.UsuarioID where TipoOperacionID=1 order by Fecha")
            dgvLista.DataSource = dvwGenerico
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub EliminarRegistro()
        Try
            Dim id As Integer
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("TransaccionID")
            If MsgBox("Esta seguro que desea eliminar el registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EjecutarSQL("Delete from Transaccion where TransaccionID=@1", id)
                CargarGrilla()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

