<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
    Inherits SistemaRestaurante.frmGrillaGenerica

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.colUsuarioID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContraseña = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTipoUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxFiltros.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxFiltros
        '
        Me.gbxFiltros.Size = New System.Drawing.Size(896, 102)
        '
        'lblFiltro
        '
        Me.lblFiltro.Size = New System.Drawing.Size(58, 17)
        Me.lblFiltro.Text = "Nombre"
        '
        'dgvLista
        '
        Me.dgvLista.AllowUserToAddRows = False
        Me.dgvLista.AllowUserToDeleteRows = False
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUsuarioID, Me.colNombre, Me.colEmail, Me.colContraseña, Me.colActivo, Me.colTipoUsuario})
        Me.dgvLista.Location = New System.Drawing.Point(12, 185)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.ReadOnly = True
        Me.dgvLista.RowHeadersWidth = 51
        Me.dgvLista.RowTemplate.Height = 24
        Me.dgvLista.Size = New System.Drawing.Size(896, 309)
        Me.dgvLista.TabIndex = 4
        '
        'colUsuarioID
        '
        Me.colUsuarioID.DataPropertyName = "UsuarioID"
        Me.colUsuarioID.HeaderText = "Cód. Usuario"
        Me.colUsuarioID.MinimumWidth = 6
        Me.colUsuarioID.Name = "colUsuarioID"
        Me.colUsuarioID.ReadOnly = True
        Me.colUsuarioID.Width = 125
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "Nombre"
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MinimumWidth = 6
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 125
        '
        'colEmail
        '
        Me.colEmail.DataPropertyName = "Email"
        Me.colEmail.HeaderText = "E-mail"
        Me.colEmail.MinimumWidth = 6
        Me.colEmail.Name = "colEmail"
        Me.colEmail.ReadOnly = True
        Me.colEmail.Width = 125
        '
        'colContraseña
        '
        Me.colContraseña.DataPropertyName = "Contraseña"
        Me.colContraseña.HeaderText = "Contraseña"
        Me.colContraseña.MinimumWidth = 6
        Me.colContraseña.Name = "colContraseña"
        Me.colContraseña.ReadOnly = True
        Me.colContraseña.Width = 125
        '
        'colActivo
        '
        Me.colActivo.DataPropertyName = "Activo"
        Me.colActivo.FalseValue = "N"
        Me.colActivo.HeaderText = "Esta Activo?"
        Me.colActivo.IndeterminateValue = "N"
        Me.colActivo.MinimumWidth = 6
        Me.colActivo.Name = "colActivo"
        Me.colActivo.ReadOnly = True
        Me.colActivo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colActivo.TrueValue = "S"
        Me.colActivo.Width = 125
        '
        'colTipoUsuario
        '
        Me.colTipoUsuario.DataPropertyName = "Descripcion"
        Me.colTipoUsuario.HeaderText = "Tipo Usuario"
        Me.colTipoUsuario.MinimumWidth = 6
        Me.colTipoUsuario.Name = "colTipoUsuario"
        Me.colTipoUsuario.ReadOnly = True
        Me.colTipoUsuario.Width = 125
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(920, 523)
        Me.Controls.Add(Me.dgvLista)
        Me.Name = "frmUsuarios"
        Me.Text = "Manteimiento de Usuarios"
        Me.Controls.SetChildIndex(Me.gbxFiltros, 0)
        Me.Controls.SetChildIndex(Me.dgvLista, 0)
        Me.gbxFiltros.ResumeLayout(False)
        Me.gbxFiltros.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvLista As DataGridView
    Friend WithEvents colUsuarioID As DataGridViewTextBoxColumn
    Friend WithEvents colNombre As DataGridViewTextBoxColumn
    Friend WithEvents colEmail As DataGridViewTextBoxColumn
    Friend WithEvents colContraseña As DataGridViewTextBoxColumn
    Friend WithEvents colActivo As DataGridViewCheckBoxColumn
    Friend WithEvents colTipoUsuario As DataGridViewTextBoxColumn
End Class
