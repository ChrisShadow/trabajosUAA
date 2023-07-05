@Code
    ViewData("Title") = "ProductosPorCategoria"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

<h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Listado de Productos por Categoría</h1>
<hr>

<div class="form-group row">
    <div class="col-12 col-md-6 mb-3">
        <label for="txtCategoria" class=" my-3 mx-3 ">Categoría:</label>
        <select name="cboCategoria" id="cboCategoria" class="form-control" onchange="BuscarProductos()">
            <option value="0">--Seleccione una opción--</option>
            @For Each fila In ViewData("categorias")
                @<option value="@fila("CategoriaID")">@fila("Descripcion")</option>
            Next
        </select>
    </div>
</div>
<table class="table table-sm table-bordered table-responsive-xl mt-3" id="datatable_plug">
    <thead class="text-center">
        <tr class="table bg-transparent">
            <th>CÓDIGO</th>
            <th>DESCRIPCIÓN</th>
        </tr>
    </thead>
    <tbody class="text-left" id="productos">
      
    </tbody>
</table>
<script>
    function BuscarProductos() {
        $.ajax({
            url: 'http://localhost:62643/api/Producto/GetProductos',
            data: {
                id: $('#cboCategoria').val()
            },
            type: 'GET',
            dateType: 'JSON',
            success: function (retorno) {
                //console.log(retorno);
                var row = "";
                for (i = 0; i < retorno.length; i++) {
                    row += "<tr>";
                    row += "<td>";
                    row += retorno[i].pProductoID;
                    row += "</td>";
                    row += "<td>";
                    row += retorno[i].pNombre;
                    row += "</td>";
                    row += "</tr>";
                }
                $('#productos').html(row);
            },
            error: function () {
                $('#productos').html("");
                alert("No se ha encontrado productos para la categoria seleccionada.");
            }
        })
    }
</script>
