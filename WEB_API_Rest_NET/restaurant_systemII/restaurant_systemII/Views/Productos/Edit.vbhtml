
@Code
    ViewData("Title") = "Editar Producto"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Editar Producto</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.min.css">
</head>
<body>
    <div class="container">
        <div class="row mt-3">
            <div class="col">*@
                <h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Modificar el registro: <span class="badge badge-info ml-2">@Model.pProductoID</span>  de Producto</h1>
                <hr>
                <form action="Edit" method="post"> 
                    <div class="card card-body" style="background-color: navajowhite;">
                        <div style=" text-align:left ; font-style: italic ;">
                            <span class="text-capitalize"> Datos del Producto</span>
                        </div>
                        <div style=" text-align:center " ;>
                            <p class=" custom-control-label alert alert-secondary my-3  ">
                                <span class="text-uppercase ">
                                    <strong> Son los datos del Producto</strong>
                                </span>
                            </p>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <input type="hidden" name="txtProductoID" value="@Model.pProductoID" />
                            <label for="txtCodigo" class=" my-3 mx-3 ">
                                Código:
                            </label><input type="number" class="form-control" name="txtCodigo" placeholder="Ingrese el código" maxlength="20" required value=" @Model.pCodigo" />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtNombre" class=" my-3 mx-3 ">Nombre:</label>
                            <input type="text" class="form-control " name="txtNombre" placeholder="Ingrese el Nombre" maxlength="20" required value=" @Model.pNombre" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPreparacion" class=" my-3 mx-3 ">
                                Preparación:
                            </label><input type="text" class="form-control" name="txtPreparacion" placeholder="Ingrese la preparación" maxlength="20" required value=" @Model.pPreparacion" />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtCosto" class=" my-3 mx-3 ">Costo:</label>
                            <input type="number" class="form-control " name="txtCosto" placeholder="Ingrese el costo" maxlength="20" required value=" @Model.pCosto" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPrecioVenta" class=" my-3 mx-3 ">
                                Precio Venta:
                            </label><input type="number" class="form-control" name="txtPrecioVenta" placeholder="Ingrese el precio de Venta" maxlength="20" required value=" @Model.pPrecioVenta" />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtUnidadMedidaID" class=" my-3 mx-3 ">Unidad de Medida:</label>
                            <select name="txtUnidadMedidaID" id="" class="form-control">
                                @For Each row In ViewData("UnidadMedida")
                                    @<option value="@row("UnidadMedidaID")" @IIf(Model.pUnidadMedidaID = row("UnidadMedidaID"), "Selected", "")>@row("Descripcion")</option>
                                Next
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPresentacion" class=" my-3 mx-3 ">
                                Presentación:
                            </label><input type="text" class="form-control" name="txtPresentacion" placeholder="Ingrese la presentación" maxlength="20" required value=" @Model.pPrecioVenta" />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="rdbUsaIngrediente" class=" my-3 mx-3 ">¿Usa Ingresiente?:</label>
                            <div Class="form-check ">
                                <Label for="rdbUsaIngrediente" class="form-check-label my-3 mx-3 ">
                                    @IIf(Model.pUsaIngrediente = "s", Html.Raw("<input type='radio' name='rdbUsaIngrediente' id='rdbUsaIngrediente' value='s' checked> Sí"), Html.Raw("<input type='radio' name='rdbUsaIngrediente' id='rdbUsaIngrediente' value='s' > Sí"))
                                </Label>
                                <Label for="rdbUsaIngrediente" class="form-check-label my-3 mx-3 ">
                                    @IIf(Model.pUsaIngrediente = "n", Html.Raw("<input type='radio' name='rdbUsaIngrediente' id='rdbUsaIngrediente' value='n' checked> No"), Html.Raw("<input type='radio' name='rdbUsaIngrediente' id='rdbUsaIngrediente' value='n'> No"))
                                </Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <Label for="rdbActivo" class=" my-3 mx-3 ">
                                Activo:
                            </Label>
                            <div Class="form-check ">
                                <Label for="rdbActivo" class="form-check-label my-3 mx-3 ">
                                    @IIf(Model.pvActivo = "s", Html.Raw("<input type='radio' name='rdbActivo' id='rdbActivo' value='s' checked> Sí"), Html.Raw("<input type='radio' name='rdbActivo' id='rdbActivo' value='s' > Sí"))
                                </Label>
                                <Label for="rdbActivo" class="form-check-label my-3 mx-3 ">
                                    @IIf(Model.pvActivo = "n", Html.Raw("<input type='radio' name='rdbActivo' id='rdbActivo' value='n' checked> No"), Html.Raw("<input type='radio' name='rdbActivo' id='rdbActivo' value='n'> No"))
                                </Label>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtCategoriaID" class=" my-3 mx-3 ">
                                Tipo de Categoría:
                            </label>
                            <select name="txtCategoriaID" id="" class="form-control">
                                @For Each row In ViewData("Categorias")
                                    @<option value="@row("CategoriaID")" @IIf(Model.pCategoriaID = row("CategoriaID"), "Selected", "")>@row("Descripcion")</option>
                                Next
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtExistencia" class=" my-3 mx-3 ">
                                Stock:
                            </label><input type="text" class="form-control" name="txtExistencia" placeholder="Ingrese el stock" maxlength="20" required value=" @Model.pStock" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 text-center">
                            <div class="row justify-content-center">
                                <div class="col-12 col-sm-9 col-md-4">
                                    <!--Envía a la función  del controlador-->
                                    <Button Class="btn btn-primary btn-block mb-3" type="submit" onclick="registro()">Confirmar</Button>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-12 col-sm-9 col-md-4">
                                    <Button Class="btn btn-primary btn-block mt-3" type="reset">Cancelar</Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            @*</div>
        </div>
    </div>
</body>
</html>*@
