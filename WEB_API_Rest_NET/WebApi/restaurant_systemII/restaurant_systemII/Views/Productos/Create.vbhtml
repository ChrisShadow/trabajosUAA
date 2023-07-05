
@Code
    ViewData("Title") = "Crear Producto"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Nuevo Producto</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.min.css">
</head>
<body>
    <div class="container">
        <div class="row mt-3">
            <div class="col">*@
                <h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Agregar un Nuevo Producto</h1>
                <hr>
                <form action="Create" method="post">
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
                            <label for="txtCodigo" class=" my-3 mx-3 ">
                                Código:
                            </label><input type="number" class="form-control" name="txtCodigo" placeholder="Ingrese el código" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtNombre" class=" my-3 mx-3 ">Nombre:</label>
                            <input type="text" class="form-control " name="txtNombre" placeholder="Ingrese el Nombre" maxlength="20" required />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPreparacion" class=" my-3 mx-3 ">
                                Preparación:
                            </label><input type="text" class="form-control" name="txtPreparacion" placeholder="Ingrese la preparación" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtCosto" class=" my-3 mx-3 ">Costo:</label>
                            <input type="number" class="form-control " name="txtCosto" placeholder="Ingrese el costo" maxlength="20" required />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPrecioVenta" class=" my-3 mx-3 ">
                                Precio Venta:
                            </label><input type="number" class="form-control" name="txtPrecioVenta" placeholder="Ingrese el precio de Venta" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtUnidadMedidaID" class=" my-3 mx-3 ">Unidad de Medida:</label>
                            <select name="txtUnidadMedidaID" id="" class="form-control">
                                @For Each row In ViewData("UnidadMedida")
                                    @<option value="@row("UnidadMedidaID")">@row("Descripcion")</option>
                                Next
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtPresentacion" class=" my-3 mx-3 ">
                                Presentación:
                            </label><input type="text" class="form-control" name="txtPresentacion" placeholder="Ingrese la presentación" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="rdbUsaIngrediente" class=" my-3 mx-3 ">¿Usa Ingresiente?:</label>
                            <div Class="form-check ">
                                <Label for="rdbUsaIngrediente" class="form-check-label my-3 mx-3 ">
                                    <input type="radio" name="rdbUsaIngrediente" id="rdbUsaIngrediente" value="S"> Sí
                                </Label>
                                <Label for="rdbUsaIngrediente" class="form-check-label my-3 mx-3 ">
                                    <input type="radio" name="rdbUsaIngrediente" id="rdbUsaIngrediente" value="N"> No
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
                                    <input type="radio" name="rdbActivo" id="rdbActivo" value="S"> Sí
                                </Label>
                                <Label for="rdbActivo" class="form-check-label my-3 mx-3 ">
                                    <input type="radio" name="rdbActivo" id="rdbActivo" value="N"> No
                                </Label>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtCategoriaID" class=" my-3 mx-3 ">
                                Tipo de Categoría:
                            </label>
                            <select name="txtCategoriaID" id="" class="form-control">
                                @For Each row In ViewData("Categorias")
                                    @<option value="@row("CategoriaID")">@row("Descripcion")</option>
                                Next
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtExistencia" class=" my-3 mx-3 ">
                                Stock:
                            </label><input type="text" class="form-control" name="txtExistencia" placeholder="Ingrese el stock" maxlength="20" required />
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
    <Script src="js/jquery-3.5.1.min.js"></Script>
    <Script src="js/popper.min.js"></Script>
    <Script src="js/bootstrap.min.js"></Script>
</body>
</html>*@
