Imports System.Data.SqlClient
Public Class frmTipoUsuario

    Public vTipoAccion As String
    Public vID As Integer

    'Dim MiConexion As New SqlConnection("data source = .\SQLEXPRESS; initial catalog = Restaurante; user id = sa; password = 123")

    'Dim InstruccionSQL As String
    'Dim MiComandoSQL As SqlCommand

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If ValidarDatos() = True Then
                If vTipoAccion = "Agregar" Then
                    'MiConexion.Open()
                    'InstruccionSQL = "insert TipoUsuario values('" & txtDescripcion.Text & "')"

                    'MiComandoSQL = New SqlCommand(InstruccionSQL, MiConexion)

                    'MiComandoSQL.ExecuteNonQuery()
                    'MiConexion.Close()
                    EjecutarSQL("insert TipoUsuario values(@1)", txtDescripcion.Text)
                    Me.Close()
                Else 'Modificar registro
                    'MiConexion.Open()
                    'InstruccionSQL = "update TipoUsuario set Descripcion='" & txtDescripcion.Text & "' where TipoUsuarioID=" & vID

                    'MiComandoSQL = New SqlCommand(InstruccionSQL, MiConexion)

                    'MiComandoSQL.ExecuteNonQuery()
                    'MiConexion.Close()
                    EjecutarSQL("update TipoUsuario set Descripcion=@1 where TipoUsuarioID=@2", txtDescripcion.Text, vID)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub

    Function ValidarDatos() As Boolean
        If txtDescripcion.Text = "" Then
            MsgBox("Debe ingresar la descripción")
            txtDescripcion.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub frmTipoUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vTipoAccion = "Agregar" Then
            Me.Text = "Agregar tipo de usuario..."
        Else
            Me.Text = "Modificando tipo de usuario"

            'MiConexion.Open()
            'InstruccionSQL = "select * from TipoUsuario where TipoUsuarioID=" & vID
            'MiComandoSQL = New SqlCommand(InstruccionSQL, MiConexion)
            'Dim Adaptador As New SqlDataAdapter(MiComandoSQL)
            Dim tabla As New DataTable
            tabla = generar_datatabla("select * from TipoUsuario where TipoUsuarioID=" & vID)
            'Adaptador.Fill(tabla)
            'MiConexion.Close()

            If tabla.Rows.Count > 0 Then
                txtDescripcion.Text = tabla.Rows(0).Item("Descripcion")
            End If

        End If
    End Sub
End Class