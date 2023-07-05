@Code
    ViewData("Title") = "Nueva Venta"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

<div class="row">
    <div class="col">
        <h1 class="text-left mb-3 text-danger">Nueva Venta</h1>
        <form action="NuevaVenta" method="post">
            <div class="form-group row">
                <div class="col-12 col-md-6 mb-3">
                    <label for="nro_comprobante" class=" my-3 mx-3 ">Nro. Comprobante:</label>
                    <input type="text" class="form-control " name="nro_comprobante" placeholder="Nro. Comprobante" required />
                </div>
                <div class="col-12 col-md-6 mb-3">
                    <label for="fecha" class=" my-3 mx-3 ">Fecha Compra:</label>
                    <input type="date" class="form-control" name="fecha" required />
                </div>
            </div>
            <div class="user-panel">
                <div class="form-group row">
                    <div class="col-12 col-md-6 mb-3">
                        <label for="pidarticulo" class=" my-3 mx-3 ">Seleccione el artículo:</label>
                        <p class="w-100"></p>
                        <select name="pidarticulo" id="pidarticulo" class="col-12 col-md-12 h-25 ">
                            @For Each row In ViewData("producto")
                                @<option value="@row("ProductoID")">@row("Nombre")</option>
                            Next
                        </select>
                    </div>
                    <div class="col-12 col-md-6 mb-3">
                        <label for="pcantidad" class=" my-3 mx-3 ">Cantidad:</label>
                        <input type="number" class="form-control " id="pcantidad" name="pcantidad" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-12 col-md-6 mb-3">
                        <label for="pprecio" class=" my-3 mx-3 ">Precio Costo:</label>
                        <input type="number" class="form-control " id="pprecio" name="pprecio" />
                    </div>
                    <div class="col-12 col-md-6 mb-3">
                        <p class="mb-2"></p>
                        <Button name="bt_add" id="bt_add" type="button" Class="btn btn-primary mt-5  " onclick="agregar()"><i class=" fa fa-plus" aria-hidden="true"></i></Button>
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col mb-3">
                    <table class="table table-sm table-bordered table-responsive-xl mt-3">
                        <thead class="text-center" style=" background-color:#A9D0F5">
                            <tr class="table bg-transparent">
                                <th>OPCIONES</th>
                                <th>ARTICULO</th>
                                <th>CANTIDAD</th>
                                <th>PRECIO</th>
                                <th>SUBTOTAL</th>
                            </tr>
                        </thead>
                        <tbody class="text-left" id="detalles">
                        </tbody>
                        <tfoot>
                            <tr class="text-center">
                                <td colspan="4">TOTAL</td>
                                <td id="total">Gs/. 0</td>
                        </tfoot>
                    </table>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-12 text-center">
                    <div class="row justify-content-center">
                        <div class="col-12 col-sm-9 col-md-4">
                            <!--Envía a la función  del controlador-->
                            <Button Class="btn btn-info   btn-block mb-3" type="submit">Guardar</Button>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-12 col-sm-9 col-md-4">
                            <Button Class="btn btn-danger   btn-block mt-3" type="reset">Limpiar</Button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</div>
<script type="text/javascript">
    let cont = 0;
    var total = 0;
    subtotal = [];
    var fila = "";
    function agregar() {
        idarticulo = $("#pidarticulo").val();
        articulo = $("#pidarticulo option:selected").text();
        cantidad = $("#pcantidad").val();
        precio = $("#pprecio").val();

        if (idarticulo != "" && cantidad != "" && cantidad > 0 && precio != "") {
            subtotal[cont] = (cantidad * precio);
            total = total + subtotal[cont];
            fila = '<tr class="selected" id="fila' + cont + '"><td><button type="button" class="btn btn-warning" onclick="eliminar(' + cont + ');">X</button></td><td><input type="hidden" name="idArticulo" id="idArticulo" value="' + idarticulo + '">' + articulo + '</td><td> <input type="number"  name="cantidad" id="cantidad" value="' + cantidad + '"></td><td> <input type="number"  name="precio" id="precio" value="' + precio + '"></td><td>' + subtotal[cont] + '</td></tr>';
            cont++;
            limpiar();
            //fila += '<tfoot><tr class="text-center"><td colspan="4">TOTAL</td><td>Gs/.  ' + total + ' </td></tr></tfoot>';
            $("#total").html("Gs/.   " + total);
            $("#detalles").append(fila);
        } else {
            alert("Error al ingresar el detalle del ingreso, revise los datos del articulo");
            $("#detalles").append('<tr class="text-center"><td colspan="5"> Error al ingresar el detalle del ingreso, revise los datos del articulo </td></tr>');
        }
    }
    function eliminar(index) {
        total = total - subtotal[index];
        $("#total").html("Gs/.   " + total);
        $("#fila" + index).remove();
        //evaluar();
    }
    function limpiar() {
        $("#pcantidad").val("");
        $("#pprecio").val("");
    }
</script>


