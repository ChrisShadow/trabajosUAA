Imports ClasesRestaurante.Util
Public Class UnidadMedida
    'Definir los atributos de la clase
    Private UnidadMedidaID As Integer
    Private Descripcion As String

    Public Property pUnidadMedidaID As Integer
        Get
            Return UnidadMedidaID
        End Get
        Set(value As Integer)
            UnidadMedidaID = value
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

    'Definir los métodos

    Public Function RecuperarUnidadMedida() As DataTable
        Try
            'data table es una tabla de datos en memoria
            Return gDatos.TraerDataTable("spListarUnidadMedida")
            'No recibe parámetro porque es autoincrementable
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Segundo método para insertar datos en Unidad Medida
    Sub Guardar()
        Try
            gDatos.Ejecutar("spInsertarUnidadMedida", Me.UnidadMedidaID, Me.Descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Tercer método para eliminar datos en Unidad Medida
    Sub Eliminar()
        Try
            gDatos.Ejecutar("spEliminarUnidadMedida", Me.UnidadMedidaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Cuarto método para actualzar datos en Unidad Medida
    Sub Actualizar()
        Try
            gDatos.Ejecutar("spActualizarUnidadMedida", Me.UnidadMedidaID, Me.Descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RecuperarUnidadMedidaCon(id As Integer) As UnidadMedida
        Try
            Dim dt As New DataTable
            dt = gDatos.TraerDataTable("spConsultarUnidadMedida", id)
            If dt.Rows.Count > 0 Then
                Dim vUnidadMedida As New UnidadMedida
                With vUnidadMedida
                    .pDescripcion = dt.Rows(0).Item("Descripcion")
                    .pUnidadMedidaID = dt.Rows(0).Item("UnidadMedidaID")
                End With
                Return vUnidadMedida
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListarRegistrosUnidadMedida() As DataTable
        Try
            Dim dtUniMed As New Data.DataTable("UnidadMedida")
            dtUniMed = gDatos.TraerDataTable("spListarUnidadMedida")
            Return dtUniMed
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
