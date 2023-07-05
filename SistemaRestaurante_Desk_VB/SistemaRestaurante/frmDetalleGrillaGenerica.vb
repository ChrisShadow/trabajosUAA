Public Class frmDetalleGrillaGenerica
    Protected Friend posicion As Integer
    Protected Friend vAccion As EnumAccion

    Protected Friend Enum EnumAccion As Long
        accAgregar = 0
        accModificar = 1
        accConsultar = 2
    End Enum

    Protected Friend WriteOnly Property Accion() As EnumAccion
        Set(ByVal value As EnumAccion)
            vAccion = value
        End Set
    End Property

    Overridable Function ValidarDatos() As Boolean

    End Function


    Overridable Sub Aceptar()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarDatos() = True Then
            Aceptar()
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmDetalleGrillaGenerica_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.BindingContext(dvwGenerico).Position <> posicion Then
            Me.BindingContext(dvwGenerico).Position = posicion
        End If
    End Sub
End Class