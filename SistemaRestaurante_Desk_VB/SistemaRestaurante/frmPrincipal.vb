Public Class frmPrincipal
    Private Sub TiposDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeUsuariosToolStripMenuItem.Click
        Dim frm As New frmTiposUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.ConnectionString = "data source = .\SQLEXPRESS; initial catalog = Restaurante_UNO; user id = sa; password = 123456"

        ''
        '' Control de Acceso
        ''
        Me.Visible = False
        If LoginForm1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Visible = True
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub

    Private Sub UnidadesDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadesDeMedidaToolStripMenuItem.Click
        Dim frm As New frmUnidadesMedida
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim frm As New frmUsuarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        Dim frm As New frmCompras
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frm As New frmProductos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MantenimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientosToolStripMenuItem.Click

    End Sub
End Class