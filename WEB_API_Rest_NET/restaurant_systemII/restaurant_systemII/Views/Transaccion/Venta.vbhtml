@Code
    ViewData("Title") = "Ventas"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

<h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Listado de Ventas</h1>
<hr>
<div class="row justify-content-end">
    <a href="~/Transaccion/NuevaVenta/" class="btn btn-outline-info text-uppercase mb-3  font-weight-bold "><mark>Agregar</mark></a>
</div>
<input type="hidden" id="VentaID" />
<table class="table table-sm table-bordered table-responsive-xl mt-3" id="datatable_plug">
    <thead class="text-center">
        <tr class="table bg-transparent">
            <th>FECHA</th>
            <th>NOMBRE</th>
            <th>ANULADO</th>
            <th>ACCIONES</th>
        </tr>
    </thead>
    <tbody class="text-left">
        @For Each row In ViewData("ventas")
            @<tr Class="table table-success">
                <td>@row("Fecha")</td>
                <td>@row("Nombre")</td>
                <td>@row("Anulado")</td>
                <td>
                    <a href="#" class="btn btn-outline-warning  text-uppercase font-weight-bold " data-toggle="tooltip" data-placement="top" title="Imprimir"><mark>Print</mark></a>
                    <a href="javascript:Deletejs(@row("TransaccionID")) " class="btn btn-outline-danger text-uppercase font-weight-bold " data-toggle="tooltip" data-placement="top" title="Eliminar"><mark>Delete</mark></a>
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
<script type="text/javascript">
    function EliminarRegistro() {
        //if (confirm('¿Desea eliminar el registro?')) {
        $.ajax({
            url: '/Transaccion/Delete',
            data: {
                id: $('#VentaID').val()
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

    function Deletejs(id) {
        $('#VentaID').val(id);
        $('#delete').modal('show');
    }
</script>

