Imports System.Web.Mvc
Imports ClasesRestaurante
Namespace Controllers
    Public Class UnidadMedidaController
        Inherits Controller

        ' GET: UnidadMedida
        Function Index() As ActionResult
            Try
                'Utilizar el méodo de la clase unidad de medida

                'Instanciar el objeto y crear la tabla auxiliar para volcar el contendo de la lista de registros de la tabla unidad de medida
                Dim vUnidadMedida As New UnidadMedida
                Dim dt As New DataTable

                dt = vUnidadMedida.RecuperarUnidadMedida
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("UnidadMedida") = dt.AsEnumerable

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
                'Creamos el objeto de la clase unidad de medida
                Dim vUni As New UnidadMedida
                'Asignamos a las propiedades los datos del formulario
                With vUni
                    .pDescripcion = form("txtDescripcion")
                    .Guardar() ' Llamamos al método para guardar la unidad de medida
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Delete(id As Integer) As ActionResult
            Try
                Dim vUnim As New UnidadMedida
                vUnim = vUnim.RecuperarUnidadMedidaCon(id)
                Return View(vUnim)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <HttpPost()>
        Function Delete(form As FormCollection) As ActionResult
            Try
                Dim vUM As New UnidadMedida
                'vCategoria = vCategoria.RecuperarCategoria("txtCategoriaID")
                With vUM
                    .pUnidadMedidaID = form("txtUnidadMedidaID")
                    .Eliminar()
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Edit(id As Integer) As ActionResult
            Try
                Dim vUMd As New UnidadMedida
                vUMd = vUMd.RecuperarUnidadMedidaCon(id)
                Return View(vUMd)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase unidad de medida
                Dim vUn As New UnidadMedida
                'Asignamos en las propiedades los datos del formulario
                With vUn
                    .pDescripcion = form("txtDescripcion")
                    .pUnidadMedidaID = form("txtUnidadMedidaID")
                    .Actualizar() 'Llamamos al metodo para Actualizar la unidad de medida
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function DeleteAjax(id As Integer) As ActionResult
            Try
                Dim vUM As New UnidadMedida
                'With vUM
                '    .pUnidadMedidaID = id
                '    .Eliminar()
                'End With
                vUM = vUM.RecuperarUnidadMedidaCon(id)
                vUM.Eliminar()
                Return RedirectToAction("Index")
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace