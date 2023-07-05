
@Code
    ViewData("Title") = "Listado Tipos de Categorías"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

    <html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
        <title>Tipos de Categorías</title>
        <link rel="shortcut icon" href="">
        <link rel="stylesheet" href="~/css/bootstrap.min.css">
    </head>
    <body>
        <div class="container">
            <div class="row mt-3">
                <div class="col">*@
<h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Listado de Categorías</h1>
<hr>
@*@For Each row In ViewData("Categorias")
    <ul class="list-group">
        <!--Utilizar el view data , variable local datos entre el controlador y la vista correspondiente. Usamos comando ASP.net para realizar la iteración-->
        @<li class="list-group-item list-group-item-dark">@row("Descripcion")</li>

         Next
    </ul>*@
<div class="row justify-content-end">
    <a href="Categoria/Create/ " target="_parent" class="btn btn-outline-info text-uppercase mb-3  font-weight-bold "><mark>Agregar</mark></a>
</div>
<input type="hidden" id="CategoriaID" />
<table class="table table-sm table-bordered  table-responsive-lg" id="datatable_plug">
    <thead>
        <tr class="table bg-transparent">
            <th>Código</th>
            <th>Descripción</th>
            <th>¿Está Activo?</th>
            <th>Acciones</th>
        </tr>
    </thead>
    <tbody>
        @For Each row In ViewData("Categorias")
            @<tr Class="table table-success" style="text-align:left ;">
                <td>@row("CategoriaID")</td>
                <td>@row("Descripcion")</td>
                <td>@row("Activo")</td>
                <td>
                    <!-- <a href="Categoria/Delete/@row("CategoriaID") " target="_parent" class="btn btn-outline-danger text-uppercase font-weight-bold "><mark>Eliminar</mark></a>-->
                    <a href="javascript:deletefunction(@row("CategoriaID"))" class="btn btn-outline-danger text-uppercase font-weight-bold "><mark>Eliminar</mark></a>
                    <a href="Categoria/Edit/@row("CategoriaID") " class="btn btn-outline-warning text-uppercase font-weight-bold "><mark>Actualizar</mark></a>
                </td>
            </tr>
        Next
    </tbody>
</table>
@*<button class="btn btn-primary" data-toggle="modal" data-target="#fm-modal">Abrir Modal</button>*@
<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="delete" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="">Eliminación del registo</h5>
                <button class="close" data-dismiss="modal" aria-label="Cerrar">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p>
                    ¿Está seguro que desea eliminar?
                </p>
            </div>
            <div class="modal-footer">
                <button class="btn btn-success" onclick="javascript:eliminar()">Aceptar</button>
                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
@*</div>
        </div>
    </div>
    <script src="~/js/jquery-3.5.1.min.js"></script>
    <script src="~/js/popper.min.js"></script>
    <script src="~/js/bootstrap.min.js"></script>*@ 
<script type="text/javascript">
    function eliminar() {
        //if (confirm('¿Desea eliminar el registro?')) {
        $.ajax({
            url: '/Categoria/DeleteAjax',
            data: {
                id: $('#CategoriaID').val()
            },
            type: 'GET',
            dateType: 'JSON',
            success: function (retorno) {
                location.reload();
            },
            error: function () {
                alert('se ha producido un error');
            },
            alert: function () {
                alert(retorno);
            },
        })
        //}
    }
    function deletefunction(id) {
        $('#CategoriaID').val(id);
        $('#delete').modal('show');
    }
</script>

@*</body>
    </html>*@
