Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class VentasController
        Inherits ApiController

        Public Function GetVentas(FechaIn As String, FechaFi As String) As IHttpActionResult
            Dim vFechaIn, vFechaFi As Date
            vFechaIn = CDate(FechaIn)
            vFechaFi = CDate(FechaFi)
            Dim RepoVenta As New VentaRepositorio
            Dim resul = RepoVenta.GetVentas(vFechaIn, vFechaFi)
            If resul Is Nothing Then
                Return NotFound()
            Else
                'Tiene datos la colección del objeto
                Return Ok(resul)
            End If
        End Function
    End Class
End Namespace