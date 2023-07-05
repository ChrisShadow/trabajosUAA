@Code
    ViewData("Title") = "Sales Track Record."
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

<h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Sales Track Record by Date Range</h1>
<hr>

<div class="form-group row">
    <div class="col-12 col-md-6 mb-3">
        <Label for="validationDefault02" class="form-label my-3 mx-3">Fecha Inicial</Label>
        <input type="date" id="fecha_inicio" Class="form-control" value="Otto" required>
    </div>
    <div class="col-12 col-md-6 mb-3">
        <Label for="validationDefault02" class="form-label my-3 mx-3">Fecha Final</Label>
        <input type="date" id="fecha_salida" Class="form-control" value="Otto" required>
    </div>
    <div class="col-12 col-md-6 mb-3">
        <button class="btn btn-success" onclick="ConsultarVentas()">Consultar</button>
    </div>
</div>
<table class="table table-sm table-bordered table-responsive-xl mt-3" id="datatable_plug">
    <thead class="text-center">
        <tr class="table bg-transparent">
            <th>Nro. Comprobante</th>
            <th>Fecha</th>
            <th>Estado</th>
            <th>Nombre </th>
            <th>Cantidad</th>
            <th>Precio </th>
            <th>Sub Total</th>
        </tr>
    </thead>
    <tbody class="text-left" id="ventas">
    </tbody>
    <tfoot>
        <tr class="text-center">
            <td colspan="6">TOTAL</td>
            <td id="total">Gs/. 0</td>
    </tfoot>
</table>
<script>
    function ConsultarVentas() {
        $.ajax({
            url: 'http://localhost:62643/api/Venta/GetVentas',
            data: {
                FechaIn: $('#fecha_inicio').val(),
                FechaFi: $('#fecha_salida').val()
            },
            type: 'GET',
            dateType: 'JSON',
            success: function (retorno) {
                //console.log(retorno);
                var row = "";
                var acutotal = 0;
                for (i = 0; i < retorno.length; i++) {
                    row += "<tr>";
                    row += "<td>";
                    row += retorno[i].pNroComprobante;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pFecha;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pAnulado;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pNombre;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pCantidad;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pPrecio;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].CalcularSubtotalVenta();
                    row += "</td>";
                    row += "</tr>";
                    acutotal += retorno[i].CalcularSubtotalVenta();
                }
                $('#ventas').html(row);
                $("#total").html("Gs/.   " + acutotal);
            },
            error: function () {
                $('#productos').html("");
                alert("No se ha encontrado ventas por las fechas ingresadas.");
            }
        })
    }
</script>


