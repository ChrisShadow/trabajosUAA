
@Code
    ViewData("Title") = "Crear nuevo Usuario"
    Layout = "~/Views/Template/adminLTE.vbhtml"
End Code

@*<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Nuevo Usuario</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.min.css">
</head>
<body>
    <div class="container">
        <div class="row mt-3">
            <div class="col">*@
                <h1 style=" text-align:center; text-transform: uppercase ; text-decoration: dotted ;">Agregar un Nuevo Usuario</h1>
                <hr>
                <form action="Create" method="post">
                    <div class="card card-body" style="background-color: navajowhite;">
                        <div style=" text-align:left ; font-style: italic ;">
                            <span class="text-capitalize"> Datos del Usuario</span>
                        </div>
                        <div style=" text-align:center " ;>
                            <p class=" custom-control-label alert alert-secondary my-3  ">
                                <span class="text-uppercase ">
                                    <strong> Son los datos del Usuario</strong>
                                </span>
                            </p>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtNombre" class=" my-3 mx-3 ">Nombre:</label>
                            <input type="text" class="form-control " name="txtNombre" placeholder="Ingrese el Nombre" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtEmail" class=" my-3 mx-3 ">
                                Email:
                            </label><input type="email" class="form-control" name="txtEmail" placeholder="Ingrese la dirección gmail" maxlength="20" required />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtContrasenha" class=" my-3 mx-3 ">
                                Contraseña:
                            </label><input type="password" id="senhauno" class="form-control" name="txtContrasenha" placeholder="Ingrese la Contraseña" maxlength="20" required />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtContrasenha2" class=" my-3 mx-3 ">
                                Repetir Contraseña:
                            </label><input type="password" id="senhados" class="form-control" name="txtContrasenha2" placeholder="Ingrese la Contraseña" maxlength="20" onblur="verificarSenha()" />
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label class="alert-danger my-3 mx-3" id="txtError"></label>
                        </div>
                        <div class="col-12 col-md-6 mb-3">
                            <label class="alert-success my-3 mx-3" id="txtOk"></label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12 col-md-6 mb-3">
                            <label for="txtTipoUsaurioID" class=" my-3 mx-3 ">
                                Tipo de Usuario:
                            </label>
                            <select name="txtTipoUsuarioID" id="" class="form-control">
                                @For Each row In ViewData("TipoUsuario")
                                    @<option value="@row("TipoUsuarioID")">@row("Descripcion")</option>
                                Next
                            </select>
                        </div>
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
                    </div>
                    <p Class="w-100"></p>
                    <div class="form-group row">
                       <div class="col-12 text-center">
                         <div class="row justify-content-center">
                              <div class="col-12 col-sm-9 col-md-4">
                                <!--Envía a la función  del controlador-->
                                <Button Class="btn btn-primary btn-block mb-3"  type="submit" onclick="registro()">Confirmar</Button>
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
    <Script src = "js/jquery-3.5.1.min.js" ></script>
    <Script src = "js/popper.min.js" ></script>
    <Script src = "js/bootstrap.min.js" ></script>*@
    <Script type = "text/javascript" >
        function verificarSenha() {
            var senhauno = document.getElementById("senhauno");
            var senhados = document.getElementById("senhados");
            var vOk = document.getElementById("txtOk");
            var vEr = document.getElementById("txtError");
            if (senhados.value === senhauno.value) {

                vOk.append("Contraseña válida");
            } else {

                vEr.append("Las contraseñas no coinciden");
            }
        };

        function registro() {
            alert("¡Registro guardado con éxito!");
        }
    </script>
@*</body>
</html>*@
