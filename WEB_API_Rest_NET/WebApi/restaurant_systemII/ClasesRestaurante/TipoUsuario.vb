Imports ClasesRestaurante.Util
Public Class TipoUsuario
    'Definir los atributos de la clase
    Private TipoUsuarioID As Integer
    Private Descripcion As String
    Private ContadorEliminar As Integer = 2

    Public Property pTipoUsuarioID As Integer
        Get
            Return TipoUsuarioID
        End Get
        Set(value As Integer)
            TipoUsuarioID = value
        End Set
    End Property

    Public Property pDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    'Definir los métodos(Procedimientos=realizan ciertas operaciones pero no devuelven algo. Funciones=realizan ciertas operaciones y sí devuelven un valor )

    'Primer método para devolver una lista de la tabla categoría. mediante Traer
    Public Function RecuperarTipoUsuario() As DataTable
        Try
            'data table es una tabla de datos en memoria
            Return gDatos.TraerDataTable("spListarTipoUsuario   ")
            'No recibe parámetro porque es autoincrementable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Función para traer el último Id
    Public Function TraerId() As Integer
        Try

            'Devolvemos el objeto en número
            Return CInt((gDatos.TraerValorEscalar("spObtenerTipoUsuario")).ToString) + ContadorEliminar
            'Utilizamos la cláusula para contar la cantidad de registros existentes e incrementamos la variable contadoreliminar ya que debe incrementarse al eliminar registros
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Funciones sql mediante Ejecutar
    'Segundo método para insertar datos en categoria
    Sub Guardar()
        Try
            gDatos.Ejecutar("spInsertarTipoUsuario", Me.TipoUsuarioID, Me.Descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Tercer método para eliminar datos en categoria. Incrementamos el contador
    Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarTipoUsuario", Me.TipoUsuarioID)
            Me.ContadorEliminar = ContadorEliminar + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Cuarto método para actualzar datos en categoria
    Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarTipoUsuario", Me.TipoUsuarioID, Me.Descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RecuperarTipoUsuarioCon(id As Integer) As TipoUsuario
        Try
            Dim dt As New DataTable
            dt = gDatos.TraerDataTable("spConsultarTipoUsuario", id)
            If dt.Rows.Count > 0 Then
                Dim vTipoUsuario As New TipoUsuario
                With vTipoUsuario
                    .pDescripcion = dt.Rows(0).Item("Descripcion")
                    .pTipoUsuarioID = dt.Rows(0).Item("TipoUsuarioID")
                End With
                Return vTipoUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListarRegistrosTipoUsuario() As DataTable
        Try
            Dim dtUsuario As New Data.DataTable("TipoUsuario")
            dtUsuario = gDatos.TraerDataTable("spListarTipoUsuario")
            Return dtUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
