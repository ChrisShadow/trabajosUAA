Imports System.Web.Mvc
Imports ClasesRestaurante.Util
'Controlador Inicial
Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Try
                inicializaSesion("CHRISZ\SQLEXPRESS", "Restaurante_DOS", "sa", "123456")
                Return View()
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace