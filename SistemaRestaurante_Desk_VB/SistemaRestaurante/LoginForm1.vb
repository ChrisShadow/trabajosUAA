Public Class LoginForm1

    ' TODO: inserte el c�digo para realizar autenticaci�n personalizada usando el nombre de usuario y la contrase�a proporcionada 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuaci�n: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementaci�n de IPrincipal utilizada para realizar la autenticaci�n. 
    ' Posteriormente, My.User devolver� la informaci�n de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Dim dtUsuario As New DataTable("Usuario")

            'dtUsuario = generar_datatabla("Select * from Usuario where Email='" & UsernameTextBox.Text & "' and Contrase�a='" & PasswordTextBox.Text & "'")

            dtUsuario = generar_datatabla("SELECT * from Usuario where Contrase�a =(CONVERT(NVARCHAR(32),HashBytes('MD5', '" & PasswordTextBox.Text & "'),2))")

            If dtUsuario.Rows.Count > 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.None
                MsgBox("No se ha encontrado el usuario")
            End If
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.None
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Function ValidarDatos() As Boolean
        If UsernameTextBox.Text = "" Then
            MsgBox("Debe ingresar el usuario")
            UsernameTextBox.Focus()
            Return False
        End If

        If PasswordTextBox.Text = "" Then
            MsgBox("Debe ingresar la contrase�a")
            PasswordTextBox.Focus()
            Return False
        End If

        Return True
    End Function


End Class
