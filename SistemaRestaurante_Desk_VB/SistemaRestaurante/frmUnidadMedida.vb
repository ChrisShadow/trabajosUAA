Public Class frmUnidadMedida
    Dim id As Integer

    Private Sub frmUnidadMedida_Load(sender As Object, e As EventArgs) Handles Me.Load
        If vAccion = EnumAccion.accAgregar Then
            txtDescripcion.Select()
        ElseIf vAccion = EnumAccion.accModificar Then
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UnidadMedidaID")
            Dim tabla As New DataTable("UnidadMedida")
            tabla = generar_datatabla("Select * from UnidadMedida where UnidadMedidaID =" & id)
            If tabla.Rows.Count > 0 Then
                txtDescripcion.Text = tabla.Rows(0).Item("Descripcion")
            End If
        End If
    End Sub


    Public Overrides Sub Aceptar()
        Try
            If vAccion = EnumAccion.accAgregar Then
                EjecutarSQL("Insert UnidadMedida values(@1)", txtDescripcion.Text)
            ElseIf vAccion = EnumAccion.accModificar Then
                EjecutarSQL("update UnidadMedida set Descripcion=@1 where UnidadMedidaID=@2", txtDescripcion.Text, id)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Function ValidarDatos() As Boolean
        If txtDescripcion.Text = "" Then
            MsgBox("Debe ingresar la descripción")
            txtDescripcion.Focus()
            Return False
        End If
        Return True
    End Function
End Class
