<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiposUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstTiposUsuario = New System.Windows.Forms.ListBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.dgvTiposUsuarios = New System.Windows.Forms.DataGridView()
        Me.colTipoUsuarioID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTiposUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstTiposUsuario
        '
        Me.lstTiposUsuario.FormattingEnabled = True
        Me.lstTiposUsuario.ItemHeight = 16
        Me.lstTiposUsuario.Location = New System.Drawing.Point(12, 61)
        Me.lstTiposUsuario.Name = "lstTiposUsuario"
        Me.lstTiposUsuario.Size = New System.Drawing.Size(376, 228)
        Me.lstTiposUsuario.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(409, 61)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(409, 99)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(409, 137)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(107, 32)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'dgvTiposUsuarios
        '
        Me.dgvTiposUsuarios.AllowUserToAddRows = False
        Me.dgvTiposUsuarios.AllowUserToDeleteRows = False
        Me.dgvTiposUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTiposUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipoUsuarioID, Me.colDescripcion})
        Me.dgvTiposUsuarios.Location = New System.Drawing.Point(12, 332)
        Me.dgvTiposUsuarios.Name = "dgvTiposUsuarios"
        Me.dgvTiposUsuarios.ReadOnly = True
        Me.dgvTiposUsuarios.RowHeadersWidth = 51
        Me.dgvTiposUsuarios.RowTemplate.Height = 24
        Me.dgvTiposUsuarios.Size = New System.Drawing.Size(548, 204)
        Me.dgvTiposUsuarios.TabIndex = 4
        '
        'colTipoUsuarioID
        '
        Me.colTipoUsuarioID.DataPropertyName = "TipoUsuarioID"
        Me.colTipoUsuarioID.HeaderText = "Cód. Tipo Usuario"
        Me.colTipoUsuarioID.MinimumWidth = 6
        Me.colTipoUsuarioID.Name = "colTipoUsuarioID"
        Me.colTipoUsuarioID.Width = 125
        '
        'colDescripcion
        '
        Me.colDescripcion.DataPropertyName = "Descripcion"
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.MinimumWidth = 6
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.Width = 125
        '
        'frmTiposUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 679)
        Me.Controls.Add(Me.dgvTiposUsuarios)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lstTiposUsuario)
        Me.Name = "frmTiposUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Tipos de Usuario"
        CType(Me.dgvTiposUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstTiposUsuario As ListBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents dgvTiposUsuarios As DataGridView
    Friend WithEvents colTipoUsuarioID As DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As DataGridViewTextBoxColumn
End Class
