Imports ClasesRestaurante.Util
Public Class Categoria
    'Definir los atributos de la clase
    Private CategoriaID As Integer
    Private Descripcion As String
    Private Activo As String

    'Definir las propiedades
    Public Property pCategoriaID As Integer
        Get
            Return CategoriaID
        End Get
        Set(value As Integer)
            CategoriaID = value
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

    Public Property pActivo As String
        Get
            Return Activo
        End Get
        Set(value As String)
            Activo = value
        End Set
    End Property

    'Definir los métodos(Procedimientos=realizan ciertas operaciones pero no devuelven algo. Funciones=realizan ciertas operaciones y sí devuelven un valor )

    'Primer método para devolver una lista de la tabla categoría. mediante Traer
    Public Function RecuperarCategorias() As DataTable
        Try
            'data table es una tabla de datos en memoria
            Return gDatos.TraerDataTable("spListarCategoria")
            'No recibe parámetro porque es autoincrementable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Funciones sql mediante Ejecutar
    'Segundo método para insertar datos en categoria
    Sub Guardar()
        Try
            gDatos.Ejecutar("spInsertarCategoria", Me.Descripcion, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Tercer método para eliminar datos en categoria
    Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarCategoria", Me.CategoriaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Cuarto método para insertar datos en categoria
    Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarCategoria", Me.CategoriaID, Me.Descripcion, Me.Activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RecuperarCategoria(id As Integer) As Categoria
        Try
            Dim dt As New DataTable
            dt = gDatos.TraerDataTable("spConsultarCategoria", id)
            If dt.Rows.Count > 0 Then
                Dim vCategoria As New Categoria
                With vCategoria
                    .Descripcion = dt.Rows(0).Item("Descripcion")
                    .CategoriaID = dt.Rows(0).Item("CategoriaID")
                    .Activo = dt.Rows(0).Item("Activo")
                End With
                Return vCategoria
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListarRegistrosCategoria() As DataTable
        Try
            Dim dtCat As New Data.DataTable("Categoria")
            dtCat = gDatos.TraerDataTable("spListarCategoria")
            Return dtCat
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
