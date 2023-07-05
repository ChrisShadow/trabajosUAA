Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class ProductoController
        Inherits ApiController

        Public Function GetProductos(id As Integer) As IHttpActionResult
            Dim RepoProducto As New ProductoRepositorio  ' crear el objeto de la clase
            Dim resul = RepoProducto.GetProductos(id)
            If resul Is Nothing Then
                Return NotFound()
            Else
                'Tiene datos la colección del objeto
                Return Ok(resul)
            End If

        End Function
    End Class
End Namespace