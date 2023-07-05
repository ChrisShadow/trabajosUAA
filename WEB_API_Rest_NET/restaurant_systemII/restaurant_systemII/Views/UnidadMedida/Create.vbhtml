
@Code
    ViewData("Title") = "Agregar Nueva Unidad de Medida"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Nueva Unidad de Medida</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.css">
</head>
<body>
    <div class="container">
        <div class="row mt-3">
            <div class="col">*@
                <h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Agregar una nueva unidad de medida</h1>
                <hr>
                <form action="Create" method="post">
                    <div class="card card-body" style="background-color: navajowhite;">
                        <div style=" text-align:left ; font-style: italic ;">
                            <span class="text-capitalize"> Datos de la Unidad de Medida</span>
                        </div>
                        <div style=" text-align:center " ;>
                            <p class=" custom-control-label alert alert-secondary my-3  ">
                                <span class="text-uppercase ">
                                    <strong> Son los datos de la Unidad de Medida</strong>
                                </span>
                            </p>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtDescripcion" class=" my-3 mx-3 ">
                                Descripción:
                            </label><input type="text" name="txtDescripcion" maxlength="20" required />
                        </div>   
                    </div>
                    <p Class="w-100"></p>
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
    <script src="~/js/jquery-3.5.1.min.js"></script>
    <script src="~/js/popper.min.js"></script>
    <script src="~/js/bootstrap.min.js"></script>*@
    <script type="text/javascript">
        function registro() {
            alert("¡Registro guardado con éxito!", "Nueva Categoría");
        }


    </script>
@*</body>
</html>*@
