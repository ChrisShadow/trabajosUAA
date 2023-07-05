Imports ClasesRestaurante
Imports System.Web.Mvc

Namespace Controllers
    Public Class ConsultaProductoXCategoriaController
        Inherits Controller

        ' GET: ConsultaProductoXCategoria
        Function Index() As ActionResult
            Return View()
        End Function
        Function ProductosPorCategoria() As ActionResult
            Dim objCategoria As New Categoria
            'En un objeto viewdata vamos a cargar todas las categorias
            ViewData("categorias") = objCategoria.RecuperarCategorias.AsEnumerable
            Return View()
        End Function
    End Class
End Namespace