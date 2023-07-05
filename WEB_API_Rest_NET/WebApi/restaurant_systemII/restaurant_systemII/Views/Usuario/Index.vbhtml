
@Code
    ViewData("Title") = "Listado de Usuarios"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

<!--<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Usuarios</title>
    <link rel="shortcut icon" href="">-->
<!--<link rel="stylesheet" href="~/css/bootstrap.min.css">
</head>
<body>

    <div class="container">
        <div class="row mt-3">
            <div class="col">-->
<h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Listado de Usuarios</h1>
<hr>
<div class="row justify-content-end">
    <a href="Usuario/Create/" class="btn btn-outline-info text-uppercase mb-3  font-weight-bold "><mark>Agregar</mark></a>
</div>
<input type="hidden" id="UsuarioID" />
    <table class="table table-sm table-bordered table-responsive-lg" id="datatable_plug">
        <thead>
            <tr class="table bg-transparent">
                <th>ID</th>
                <th>Nombre</th>
                <th>Email</th>
                <th>Tipo Usuario</th>
                <th>Activo</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each row In ViewData("usuarios")
                @<tr Class="table table-success" style="text-align:left ;">
                    <td>@row("UsuarioID")</td>
                    <td>@row("Nombre")</td>
                    <td>@row("Email")</td>
                    <td>@row("TipoUsuario")</td>
                    <td>@IIf(row("Estado") = "Si", Html.Raw(<a href="#" class="btn btn-outline-success" data-toggle="tooltip" data-placement="top" title="Actualizar">Sí</a>), Html.Raw(<a href="#" class="btn btn-outline-danger" data-toggle="tooltip" data-placement="top" title="Actualizar">No</a>))</td>
                    <td>
                        <a href="/Usuario/Edit/@row("UsuarioID") " class="btn btn-outline-warning  text-uppercase font-weight-bold "><mark> Actualizar</mark></a>
                        <a href="javascript:Eliminar(@row("UsuarioID")) " class="btn btn-outline-danger text-uppercase font-weight-bold "><mark>Eliminar</mark></a>
                    </td>
                </tr>
            Next
        </tbody>
    </table>

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
                    <button class="btn btn-success" onclick="javascript:EliminarRegistro()">Aceptar</button>
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
    function EliminarRegistro() {
        //if (confirm('¿Desea eliminar el registro?')) {
            $.ajax({
                url: '/Usuario/Delete',
                data: {
                    id: $('#UsuarioID').val()
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

    function Eliminar(id) {
        $('#UsuarioID').val(id);
        $('#delete').modal('show');
    }
</script>
@*</body>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 </body>
</html>*@
