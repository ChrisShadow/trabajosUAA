Imports System.Web.Mvc

'Para recuperar la lista de categoría
Imports ClasesRestaurante
Namespace Controllers
    Public Class TipoUsuarioController
        Inherits Controller

        ' GET: TipoUsuario
        'Método para mostrar o listar
        Function Index() As ActionResult
            Try
                'Utilizar el méodo de la clase TipoUsuario

                'Instanciar el objeto y crear la tabla auxiliar para volcar el contendo de la lista de registros de la tabla tipousuario
                Dim vTipoUsuario As New TipoUsuario
                Dim dt As New DataTable

                dt = vTipoUsuario.RecuperarTipoUsuario
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("TipoUsuario") = dt.AsEnumerable

                'llamamos a la vista en donde serán mostrados los datos 
                Return View()
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Function Create() As ActionResult
            Try

                Return View()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase tiposuario
                Dim vTipoUsuario As New TipoUsuario
                Dim id As Integer
                'Asignamos a las propiedades los datos del formulario
                With vTipoUsuario
                    id = .TraerId
                    .pTipoUsuarioID = id
                    .pDescripcion = form("txtDescripcion")
                    .Guardar() ' Llamamos al método para guardar el tipo usuario
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Delete(id As Integer) As ActionResult
            Try
                Dim vTipoUsuario As New TipoUsuario
                vTipoUsuario = vTipoUsuario.RecuperarTipoUsuarioCon(id)
                Return View(vTipoUsuario)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        <HttpPost()>
        Function Delete(form As FormCollection) As ActionResult
            Try
                Dim vTipoUsuario As New TipoUsuario
                'vCategoria = vCategoria.RecuperarCategoria("txtCategoriaID")
                With vTipoUsuario
                    .pTipoUsuarioID = form("txtTIpoUsuarioID")
                    .Eliminar()
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Edit(id As Integer) As ActionResult
            Try
                Dim vTipoUsuario As New TipoUsuario
                vTipoUsuario = vTipoUsuario.RecuperarTipoUsuarioCon(id)
                Return View(vTipoUsuario)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase categoria
                Dim vTipoUsuario As New TipoUsuario
                'Asignamos en las propiedades los datos del formulario
                With vTipoUsuario
                    .pTipoUsuarioID = form("txtTipoUsuarioID")
                    .pDescripcion = form("txtDescripcion")
                    .Actualizar() 'Llamamos al metodo para Actualizar la categoria
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function DeleteAjax(id As Integer) As ActionResult
            Try
                Dim vTipoUs As New TipoUsuario
                'With vCategoria
                '    .pCategoriaID = id
                '    .Eliminar()
                'End With
                vTipoUs = vTipoUs.RecuperarTipoUsuarioCon(id)
                vTipoUs.Eliminar()
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace