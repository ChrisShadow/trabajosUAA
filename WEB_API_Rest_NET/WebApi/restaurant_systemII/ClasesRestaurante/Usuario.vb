Imports ClasesRestaurante.Util
Public Class Usuario
    'Definir los atributos de la clase
    Private UsuarioID As Integer
    Private Nombre As String
    Private Email As String
    Private Contraseña As String
    Private TipoUsuarioID As Integer
    Private Activo As String

    Public Property pUsuarioID() As Integer
        Get
            Return UsuarioID
        End Get

        Set(ByVal value As Integer)
            UsuarioID = value
        End Set
    End Property

    Public Property pNombre() As String
        Get
            Return Nombre
        End Get

        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property pEmail() As String
        Get
            Return Email
        End Get

        Set(ByVal value As String)
            Email = value
        End Set
    End Property

    Public Property pContraseña() As String
        Get
            Return Contraseña
        End Get

        Set(ByVal value As String)
            Contraseña = value
        End Set
    End Property

    Public Property pTipoUsuarioID() As Integer
        Get
            Return TipoUsuarioID
        End Get

        Set(ByVal value As Integer)
            TipoUsuarioID = value
        End Set
    End Property

    Public Property pActivo() As String
        Get
            Return Activo
        End Get

        Set(ByVal value As String)
            Activo = value
        End Set
    End Property

    'Definir los métodos(Procedimientos=realizan ciertas operaciones pero no devuelven algo. Funciones=realizan ciertas operaciones y sí devuelven un valor )
    'Funciones sql mediante Ejecutar


    'Primer método para devolver una lista de la tabla usuario. mediante Shared el cual no se necesita instanciar el objeto a la hora de utilizar 
    'conveniente para listas y mediante Traer
    Public Shared Function RecuperarRegistrosUsuario() As DataTable
        Try
            Dim dtUsuario As New Data.DataTable("Usuario")
            dtUsuario = gDatos.TraerDataTable("spListarUsuarios")
            Return dtUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'método para insertar datos en usuario
    Public Sub Insertar()
        Try
            gDatos.Ejecutar("spInsertarUsuario", Me.Nombre, Me.Email, Me.Contraseña, Me.TipoUsuarioID, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'método para aztualizar datos en usuario
    Public Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarUsuario", Me.UsuarioID, Me.Nombre, Me.Email, Me.Contraseña, Me.TipoUsuarioID, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'método para eliminar datos en usuario
    Public Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarUsuario", Me.UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Para consultar
    Public Function RecuperarRegistro(ByVal vCodigo As Integer) As Usuario
        Try
            Dim dtUsuario As New Data.DataTable("Usuario")
            dtUsuario = gDatos.TraerDataTable("spConsultarUsuario", vCodigo)
            If dtUsuario.Rows.Count > 0 Then
                Dim vUsuario As New Usuario
                vUsuario.pUsuarioID = dtUsuario.Rows(0).Item("UsuarioID")
                vUsuario.pNombre = dtUsuario.Rows(0).Item("Nombre")
                vUsuario.pEmail = dtUsuario.Rows(0).Item("Email")
                vUsuario.pContraseña = dtUsuario.Rows(0).Item("Contraseña")
                vUsuario.pTipoUsuarioID = dtUsuario.Rows(0).Item("TipoUsuarioID")
                vUsuario.pActivo = dtUsuario.Rows(0).Item("Activo")
                Return vUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
