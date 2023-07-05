Imports System.Data.SqlClient
Public Class frmTiposUsuario
    'Dim MiConexion As New SqlConnection("data source = .\SQLEXPRESS; initial catalog = Restaurante; user id = sa; password = 123")

    Dim InstruccionSQL As String
    'Dim MiComandoSQL As SqlCommand
    Private Sub frmTiposUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarTiposUsuarios()
    End Sub

    Sub CargarTiposUsuarios()
        InstruccionSQL = "Select * from TipoUsuario order by Descripcion"
        'MiConexion.Open()
        'MiComandoSQL = New SqlCommand(InstruccionSQL, MiConexion)
        'Dim Adaptador As New SqlDataAdapter(MiComandoSQL)
        'Dim TablaUsuario As New DataTable
        'Adaptador.Fill(TablaUsuario)
        'MiConexion.Close()

        'lstTiposUsuario.DataSource = TablaUsuario
        lstTiposUsuario.DataSource = generar_datatabla(InstruccionSQL)
        lstTiposUsuario.DisplayMember = "Descripcion"
        lstTiposUsuario.ValueMember = "TipoUsuarioID"

        dgvTiposUsuarios.DataSource = generar_datatabla(InstruccionSQL)


    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim IDSeleccionado As Integer
            IDSeleccionado = lstTiposUsuario.SelectedValue
            'InstruccionSQL = "Delete from TipoUsuario where TipoUsuarioID=" & CStr(IDSeleccionado)
            'MiConexion.Open()
            'MiComandoSQL = New SqlCommand(InstruccionSQL, MiConexion)
            'MiComandoSQL.ExecuteNonQuery()
            'MiConexion.Close()
            EjecutarSQL("Delete from TipoUsuario where TipoUsuarioID=@1", IDSeleccionado)

            CargarTiposUsuarios()

        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New frmTipoUsuario
        frm.vTipoAccion = "Agregar"
        frm.ShowDialog()
        CargarTiposUsuarios()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim frm As New frmTipoUsuario
        frm.vTipoAccion = "Modificar"
        frm.vID = lstTiposUsuario.SelectedValue
        frm.ShowDialog()
        CargarTiposUsuarios()
    End Sub
End Class