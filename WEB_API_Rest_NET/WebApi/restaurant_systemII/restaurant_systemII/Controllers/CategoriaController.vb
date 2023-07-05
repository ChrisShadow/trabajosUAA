Imports System.Web.Mvc

'Para recuperar la lista de categoría
Imports ClasesRestaurante
Namespace Controllers
    Public Class CategoriaController
        Inherits Controller



        ' GET: Categoria
        'Método para mostrar o listar
        Function Index() As ActionResult
            Try
                'Utilizar el méodo de la clase Categoría

                'Instanciar el objeto y crear la tabla auxiliar para volcar el contendo de la lista de registros de la tabla categoría
                Dim vCategoria As New Categoria
                Dim dt As New DataTable

                dt = vCategoria.RecuperarCategorias
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista
                ViewData("Categorias") = dt.AsEnumerable

                'llamamos a la vista en donde serán mostrados los datos 
                Return View()
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        'Método para insertar o editar 
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
                'Creamos el objeto de la clase categoría
                Dim vCategoria As New Categoria
                'Asignamos a las propiedades los datos del formulario
                With vCategoria
                    .pDescripcion = form("txtDescripcion")
                    .pActivo = form("rbEstado")
                    .Guardar() ' Llamamos al método para guardar la categoría
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Delete(id As Integer) As ActionResult
            Try
                Dim vCategoria As New Categoria
                vCategoria = vCategoria.RecuperarCategoria(id)
                Return View(vCategoria)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        <HttpPost()>
        Function Delete(form As FormCollection) As ActionResult
            Try
                Dim vCategoria As New Categoria
                'vCategoria = vCategoria.RecuperarCategoria("txtCategoriaID")
                With vCategoria
                    .pCategoriaID = form("txtCategoriaID")
                    .Eliminar()
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Edit(id As Integer) As ActionResult
            Try
                Dim vCategoria As New Categoria
                vCategoria = vCategoria.RecuperarCategoria(id)
                Return View(vCategoria)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase categoria
                Dim vCategoria As New Categoria
                'Asignamos en las propiedades los datos del formulario
                With vCategoria
                    .pDescripcion = form("txtDescripcion")
                    .pActivo = form("rbEstado")
                    .pCategoriaID = form("txtCategoriaID")
                    .Actualizar() 'Llamamos al metodo para Actualizar la categoria
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function DeleteAjax(id As Integer) As ActionResult
            Try
                Dim vCategoria As New Categoria
                'With vCategoria
                '    .pCategoriaID = id
                '    .Eliminar()
                'End With
                vCategoria = vCategoria.RecuperarCategoria(id)
                vCategoria.Eliminar()
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace