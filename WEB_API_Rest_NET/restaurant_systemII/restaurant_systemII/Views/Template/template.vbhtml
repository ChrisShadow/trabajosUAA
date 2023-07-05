
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <title>Project Template</title>
    <link rel="shortcut icon" href="">
    <link rel="stylesheet" href="~/css/bootstrap.min.css">
    <link href="~/scripts/datables/jquery.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary ">
        <div class="container">
            <!-- Nos sirve para agregar un logotipo al menu -->
            <a href="#" class="navbar-brand">Menu</a>

            <!-- Nos permite usar el componente collapse para dispositivos moviles -->
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar" aria-controls="navbar" aria-expanded="false" aria-label="Menu de Navegacion">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbar">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a href="Home" class="nav-link">Inicio <span class="sr-only">(Actual)</span></a>
                    </li>
                    <li class="nav-item dropdown">
                        <a href="#" class="nav-link dropdown-toggle" id="menu-categorias" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Sitios
                        </a>
                        <div class="dropdown-menu" aria-labelledby="menu-categorias">
                            <a href="Categoria" class="dropdown-item">CATEGORÍA</a>
                            <a href="Productos" class="dropdown-item">PRODUCTO</a>
                            <a href="TipoUsuario" class="dropdown-item">TIPO USUARIO</a>
                            <a href="UnidadMedida" class="dropdown-item">UNIDAD DE MEDIDA</a>
                            <a href="Usuario" class="dropdown-item">USUARIO</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a href="https://web.facebook.com/profile.php?id=100009131788493" class="nav-link">Contacto</a>
                    </li>
                    <li class="nav-item">
                        <a href="#" class="nav-link disabled">Proximamente</a>
                    </li>
                </ul>

                <form action="" class="form-inline my-2 my-lg-0">
                    <input type="text" class="form-control mr-sm-2" placeholder="Buscar" arial-label="Buscar">
                    <button class="btn btn-light my-s my-sm-0" type="submit">Buscar</button>
                </form>
            </div>
        </div>
    </nav>
    <div class="container">
        <div class="row mt-3">
            <div class="col">
                @RenderBody()
            </div>
        </div>
    </div>
    <!-- Optional JavaScript; choose one of the two! -->
    <!-- Option 1: Bootstrap Bundle With Popper -->
    <script src="~/js/jquery-3.5.1.min.js"></script>
    <script src="~/js/popper.min.js"></script>
    <script src="~/js/bootstrap.min.js"></script>
    <script src="~/scripts/datables/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatable_plug').DataTable();
        });
    </script>
</body>
</html>
