
@Code
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Eliminar Tipo de Usuario</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.css">
</head>
<body>
    <div class="container">
        <div class="row mt-3">
            <div class="col">*@
                <h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Eliminar el Tipo de Usuario</h1>
                <hr>
                <form action="Delete" method="post">
                    <div class="card card-body" style="background-color: navajowhite;">
                        <div style=" text-align:left ; font-style: italic ;">
                            <span class="text-capitalize"> Datos del Tipo de Usuario</span>
                        </div>
                        <div style=" text-align:center " ;>
                            <p class=" custom-control-label alert alert-secondary my-3  ">
                                <span class="text-uppercase ">
                                    <strong> Son los datos del Tipo de Usuario</strong>
                                </span>
                            </p>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <input type="hidden" name="txtTipoUsuarioID" value="@Model.pTipoUsuarioID" />
                            <label for="txtDescripcion" class=" my-3 mx-3 ">
                                Descripción:
                            </label><input type="text" name="txtDescripcion" maxlength="20" required value="@Model.pDescripcion" />
                        </div>
                    </div>
                    <p Class="w-100"></p>
                    <div class="form-group row">
                        <div class="col-12 text-center">
                            <div class="row justify-content-center">
                                <div class="col-12 col-sm-9 col-md-4">
                                    <!--Envía a la función  del controlador-->
                                    <input class="btn btn-primary mb-3" type="submit" name="btnEnviar" id="btnEnviar" onclick="baja()" value="Eliminar">
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

                <!--<button class="btn btn-secondary btn-block" data-toggle="modal" data-target="#fm-modal" name="btnConfirm" id="btnConfirm">Confirmar</button>
                <div class="modal fade" id="fm-modal" tabindex="-1" role="dialog" aria-labelledby="fm-modal" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-tittle" id="">¿Desea eliminar el registro?</h5>
                                <button class="close" data-dismiss="modal" aria-label="Cerrar">
                                    <span aria-hidden="true"> &times; </span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <h2>Confirmar la baja</h2>
                                <p>El tipo de usuario: @Model.pDescripcion </p><br />
                                <div class="modal-footer">
                                    <button class="btn btn-info" id="btnSi">Sí</button>
                                    <button class="btn btn-default" data-dismiss="modal">No</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>-->

            @*</div>
        </div>
    </div>
    <script src="~/js/jquery-3.5.1.min.js"></script>
    <script src="~/js/popper.min.js"></script>
    <script src="~/js/bootstrap.min.js"></script>*@
    <script type="text/javascript">
        function baja() {
           
        }
    </script>

@*</body>
</html>*@
