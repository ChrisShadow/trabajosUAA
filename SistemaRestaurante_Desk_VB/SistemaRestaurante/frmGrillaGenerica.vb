Public Class frmGrillaGenerica
    Enum Accion As Long
        accAgregar = 0
        accModificar = 1
        accConsultar = 2
    End Enum

    Protected Friend formularioDetalle As frmDetalleGrillaGenerica
    Protected Friend tituloFormularioDetalle As String
    Protected Friend nombreCampoBusqueda As String
    Protected Friend formularioPadre As Form

    Overridable Sub CargarGrilla()

    End Sub

    Private Sub frmGrillaGenerica_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGrilla()
    End Sub

    Protected Friend Sub TotalRegistro()
        lblTotalRegistro.Text = "Total de Registro: " & Me.BindingContext(dvwGenerico).Count
    End Sub

    Overridable Sub AsignarFormularioDetalle()

    End Sub
    Overridable Sub EditarRegistro(ByVal pAccion As Accion)
        AsignarFormularioDetalle()
        formularioDetalle.dvwGenerico = dvwGenerico
        formularioDetalle.posicion = Me.BindingContext(dvwGenerico).Position
        formularioDetalle.Accion = pAccion

        Select Case pAccion
            Case Accion.accAgregar
                formularioDetalle.Text = "Agregando " & tituloFormularioDetalle & "..."
            Case Accion.accModificar
                formularioDetalle.Text = "Modificando " & tituloFormularioDetalle & "..."
            Case Accion.accConsultar
                formularioDetalle.Text = "Consultando " & tituloFormularioDetalle & "..."
        End Select

        If formularioDetalle.ShowDialog(Me) = DialogResult.OK Then
            CargarGrilla()
        End If
        formularioDetalle.Close()
    End Sub

    Private Sub AgregarRegistro()
        MyClass.EditarRegistro(Accion.accAgregar)
    End Sub
    Private Sub ModificarRegistro()
        MyClass.EditarRegistro(Accion.accModificar)
    End Sub

    Protected Overridable Sub DobleClick()
        ModificarRegistro()
    End Sub

    Overridable Sub EliminarRegistro()

    End Sub

    Overridable Sub FiltrarDatos()
        If txtBusqueda.Visible = True Then
            dvwGenerico.RowFilter = nombreCampoBusqueda & " LIKE '" & txtBusqueda.Text & "%'"
            'If dvwGenerico.Count > 0 Then
            '    dgvLista.Focus()
            'Else
            '    txtBusqueda.Focus()
            'End If

            TotalRegistro()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AgregarRegistro()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ModificarRegistro()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarRegistro()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        FiltrarDatos()
    End Sub


End Class