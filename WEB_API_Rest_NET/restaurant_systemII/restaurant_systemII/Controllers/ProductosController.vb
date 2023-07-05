Imports System.Web.Mvc
Imports ClasesRestaurante

Namespace Controllers
    Public Class ProductosController
        Inherits Controller

        ' GET: Productos
        Function Index() As ActionResult
            Try

                'Utilizar el méodo de la clase Productos
                Dim dt As New DataTable

                dt = Productos.RecuperarRegistrosProducto()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("productos") = dt.AsEnumerable

                'llamamos a la vista en donde serán mostrados los datos 
                Return View()
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        Function Create() As ActionResult
            Try
                Dim dt As New DataTable
                Dim dtuno As New DataTable
                dt = UnidadMedida.ListarRegistrosUnidadMedida()
                dtuno = Categoria.ListarRegistrosCategoria()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista

                ViewData("Categorias") = dtuno.AsEnumerable
                ViewData("UnidadMedida") = dt.AsEnumerable
                Return View()
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase tiposuario
                Dim vProducto As New Productos
                'Asignamos a las propiedades los datos del formulario
                With vProducto
                    .pCodigo = form("txtCodigo")
                    .pNombre = form("txtNombre")
                    .pPreparacion = form("txtPreparacion")
                    .pCosto = form("txtCosto")
                    .pPrecioVenta = form("txtPrecioVenta")
                    .pUnidadMedidaID = form("txtUnidadMedidaID")
                    .pPresentacion = form("txtPresentacion")
                    .pUsaIngrediente = form("rdbUsaIngrediente")
                    .pvActivo = form("rdbActivo")
                    .pCategoriaID = form("txtCategoriaID")
                    .pStock = form("txtExistencia")
                    '.pEmail = form("txtEmail")
                    .Insertar() ' Llamamos al método para guardar el producto
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        Function Edit(id As Integer) As ActionResult
            Try
                Dim dt As New DataTable
                Dim dtuno As New DataTable
                dt = UnidadMedida.ListarRegistrosUnidadMedida()
                dtuno = Categoria.ListarRegistrosCategoria()
                'Creamos una  un objeto para almacenar datos de manera temporal y utilizar en la vista, es una especie de varable local(puede almacenar lista, valores numéricos, fecha. string)
                'Convertirlo a un array para recorrer el objeto y mostrar en la vista
                ViewData("Categorias") = dtuno.AsEnumerable
                ViewData("UnidadMedida") = dt.AsEnumerable
                Dim vProduct As New Productos
                vProduct = vProduct.RecuperarRegistro(id)
                Return View(vProduct)
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Try
                'Creamos el objeto de la clase tiposuario
                Dim vProducto As New Productos
                'Asignamos a las propiedades los datos del formulario
                With vProducto
                    .pProductoID = form("txtProductoID")
                    .pCodigo = form("txtCodigo")
                    .pNombre = form("txtNombre")
                    .pPreparacion = form("txtPreparacion")
                    .pCosto = form("txtCosto")
                    .pPrecioVenta = form("txtPrecioVenta")
                    .pUnidadMedidaID = form("txtUnidadMedidaID")
                    .pPresentacion = form("txtPresentacion")
                    .pUsaIngrediente = form("rdbUsaIngrediente")
                    .pvActivo = form("rdbActivo")
                    .pCategoriaID = form("txtCategoriaID")
                    .pStock = form("txtExistencia")
                    '.pEmail = form("txtEmail")
                    .Actualizar() ' Llamamos al método para actualizar el producto
                End With
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function

        Function Delete(id As Integer) As ActionResult
            Try
                Dim vProd As New Productos
                vProd = vProd.RecuperarRegistro(id)
                vProd.Eliminar()
                Return RedirectToAction("Index")
            Catch ex As Exception
                Return Content(ex.Message)
            End Try
        End Function
    End Class
End Namespace