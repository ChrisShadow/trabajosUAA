Imports System.Web.Mvc
Imports ClasesRestaurante

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller

        ' GET: Usuario
        'Método para mostrar o listar
        Function Index() As ActionResult
            Try

                'Utilizar el méodo de la clase Usuario
                Dim dt As New DataTable

                dt = Usuario.RecuperarRegistrosUsuario()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("usuarios") = dt.AsEnumerable

                'llamamos a la vista en donde serán mostrados los datos 
                Return View()
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        Function Create() As ActionResult
            Try
                Dim dt As New DataTable
                dt = TipoUsuario.ListarRegistrosTipoUsuario()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("TipoUsuario") = dt.AsEnumerable
                Return View()
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase tiposuario
                Dim vUsuario As New Usuario
                'Asignamos a las propiedades los datos del formulario
                With vUsuario
                    .pNombre = form("txtNombre")
                    .pEmail = form("txtEmail")
                    .pContraseña = form("txtContrasenha")
                    .pTipoUsuarioID = form("txtTipoUsuarioID")
                    .pActivo = form("rdbActivo")
                    '.pEmail = form("txtEmail")
                    .Insertar() ' Llamamos al método para guardar el usuario
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function


        Function Edit(id As Integer) As ActionResult
            Try
                Dim dt As New DataTable
                dt = TipoUsuario.ListarRegistrosTipoUsuario()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("TipoUsuario") = dt.AsEnumerable
                Dim vUsuario As New Usuario
                vUsuario = vUsuario.RecuperarRegistro(id)
                Return View(vUsuario)
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase tiposuario
                Dim vUsuario As New Usuario
                'Asignamos a las propiedades los datos del formulario
                With vUsuario
                    .pUsuarioID = form("txtUsuarioID")
                    .pNombre = form("txtNombre")
                    .pEmail = form("txtEmail")
                    .pContraseña = form("txtContrasenha")
                    .pTipoUsuarioID = form("txtTipoUsuarioID")
                    .pActivo = form("rdbActivo")
                    '.pEmail = form("txtEmail")
                    .Actualizar() ' Llamamos al método para guardar el tipo usuario
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        Function Delete(id As Integer) As ActionResult
            Try
                Dim vUsuario As New Usuario
                vUsuario = vUsuario.RecuperarRegistro(id)
                vUsuario.Eliminar()
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function
    End Class
End Namespace