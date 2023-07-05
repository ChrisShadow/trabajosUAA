Public Class frmUsuario
    Dim id As Integer

    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarCombos()
        If vAccion = EnumAccion.accAgregar Then
            txtNombre.Select()
        ElseIf vAccion = EnumAccion.accModificar Then
            id = dvwGenerico(Me.BindingContext(dvwGenerico).Position)("UsuarioID")
            Dim tabla As New DataTable("Usuario")
            tabla = generar_datatabla("Select * from Usuario where UsuarioID =" & id)

            If tabla.Rows.Count > 0 Then
                txtNombre.Text = tabla.Rows(0).Item("Nombre")
                txtEmail.Text = tabla.Rows(0).Item("Email")
                txtContraseña.Text = tabla.Rows(0).Item("Contraseña")
                cboTipoUsuario.SelectedValue = tabla.Rows(0).Item("TipoUsuarioID")
                If tabla.Rows(0).Item("Activo") = "S" Then
                    rdbSi.Checked = True
                Else
                    rdbNo.Checked = True
                End If
            End If

        End If
    End Sub

    Public Overrides Sub Aceptar()
        Try
            Dim Estado As String
            If rdbSi.Checked = True Then
                Estado = "S"
            Else
                Estado = "N"
            End If
            If vAccion = EnumAccion.accAgregar Then
                EjecutarSQL("Insert Usuario values(@1,@2,@3,@4,@5)", txtNombre.Text, txtEmail.Text, txtContraseña.Text, cboTipoUsuario.SelectedValue, Estado)
            ElseIf vAccion = EnumAccion.accModificar Then
                EjecutarSQL("update Usuario set Nombre=@1,Email=@2,Contraseña=@3,TipoUsuarioID=@4,Activo=@5 where UsuarioID=@6", txtNombre.Text, txtEmail.Text, txtContraseña.Text, cboTipoUsuario.SelectedValue, Estado, id)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Function ValidarDatos() As Boolean
        If txtNombre.Text = "" Then
            MsgBox("Debe ingresar el nombre del usuario")
            txtNombre.Focus()
            Return False
        End If

        If txtEmail.Text = "" Then
            MsgBox("Debe ingresar el E-mail")
            txtEmail.Focus()
            Return False
        End If
        If txtContraseña.Text = "" Then
            MsgBox("Debe ingresar la contraseña")
            txtContraseña.Focus()
            Return False
        End If
        If cboTipoUsuario.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un tipo de usuario")
            cboTipoUsuario.Focus()
            Return False
        End If
        If rdbSi.Checked = False And rdbNo.Checked = False Then
            MsgBox("Debe seleccionar el estado del usuario")
            Return False
        End If

        Return True
    End Function

    Sub CargarCombos()
        Try
            With cboTipoUsuario
                .DataSource = generar_datatabla("Select * from TipoUsuario order by Descripcion")
                .DisplayMember = "Descripcion"
                .ValueMember = "TipoUsuarioID"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
