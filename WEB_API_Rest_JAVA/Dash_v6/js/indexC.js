/* Plugin */
$(document).ready(function() {
    cargardatos();
    // $('#datatable_plug').DataTable();
});

// modal agregar 
function agregar() {
    $("#form").modal("show");
    $('#form-content').html("Cargando...")
    $.get('./modalAgregar.html')
        .then((data) => {
            // console.log(data)
            $('#form-content').html(data)
                // $("#form").modal("show");

        })
        .fail((error) => {
            console.log(error)
        })
}

function aceptar(tipo) {
    let url = ''
    let type = ""
    $(".insert").attr('disabled', 'disabled').text('Cargando...')
    if (tipo == 'editar') {
        const id = $('#categoriaID').val()
        url = 'http://localhost:4567/categoria/actualizar/' + id //https://rest-soft1.herokuapp.com/categoria/actualizar/
        type = "put"
    } else if (tipo == 'agregar') {
        url = 'http://localhost:4567/categoria/agregar'
        type = "post"
    }

    const descripcion = $('#descripcion').val();
    const activo = $('#activo').val();

    // console.log(data)
    // return;
    const data = { descripcion: descripcion, activo: activo }

    $.ajax({
        url: url,
        type: type,
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: 'application/json',
        success: function(retorno) {
            // location.reload();
            $("#form").modal("hide");
            alert('Operación Exitosa.')
            cargardatos()
            location.reload();
            $(".insert").prop('disabled', false).text('Aceptar')
        },
        error: function(e) {
            console.log(e)
            alert("se ha producido un error");
            $(".insert").prop('disabled', false).text('Aceptar')
        }
    });

}
// LA FUNCION EDITAR CAMPO OPTINE EL ATTRIBUTO DATA-JSON LA FILA DE LA TABLA Y LO COMBIERTE EN OBJETO PARA PORDER RENDERIZAR 
function editarCampo(element) {
    const obj = JSON.parse($(element).attr('data-json'))
        //console.log(obj)
    const id = obj.categoriaID
    const descripcion = obj.descripcion
    const estado = (obj.activo).trim()

    $("#form").modal("show");
    $('#form-content').html("Cargando...")

    $.get('./modalEdit.html')
        .then((data) => {
            // console.log(data)
            $('#form-content').html(data)
            $('#categoriaID').val(id)
            $('#descripcion').val(descripcion)
            $('#activo').val(estado).trigger('click')
        })
        .fail((error) => {
            console.log(error)
        })
}

/* Eliminar */
function eliminar() {
    const id = $("#CategoriaID").val();
    $.ajax({
        url: "http://localhost:4567/categoria/eliminar/" + id,
        type: "DELETE",
        dateType: "JSON",
        success: function(retorno) {
            location.reload();
        },
        error: function() {
            alert("se ha producido un error");
        },
        alert: function() {
            alert(retorno);
        },
    });
    //}
}

function deletefunction(id) {
    $("#CategoriaID").val(id);
    $("#delete").modal("show");
}

/* Tuplas */
function cargardatos() {
    $("#content").html("");
    var cuerpoCat = document.getElementById("content");
    var fila = "";
    $.ajax({
        url: "http://localhost:4567/categorias",
        data: {
            /* id: $('#CategoriaID').val() */
        },
        type: "GET",
        dateType: "JSON",
        success: function(retorno) {
            // if (typeof tablet !== 'undefined') {
            //     tablet.destroy();
            // }
            console.log(retorno);
            if (retorno) {
                // como se recibia del ajax un string, se pudo parsea a un objeto, la funcion es Json.parse()
                const arrayRetorno = JSON.parse(retorno);

                // for: recorre un array
                for (let index = 0; index < arrayRetorno.length; ++index) {
                    const element = arrayRetorno[index];
                    //     console.log("estoy aqui", element)
                    fila += `
                        <tr Class="table table-success" style="text-align:left ;"> 
                            <td>${ element.categoriaID }</td>
                            <td>${ element["descripcion"] }</td>
                            <td>${element["activo"] }</td>
                            <td> 
                                <button data-json='${ JSON.stringify(element) }' onclick="editarCampo(this)" class="editarCampo btn btn-outline-info mx-2 my-2 data-toggle="tooltip" data-placement="bottom" title="Edit"">
                                    <i class="icon-edit"></i>
                                </button>
                                <a href="javascript:deletefunction(${ element["categoriaID"] })" class="btn btn-outline-danger mx-2 my-2 data-toggle="tooltip" data-placement="bottom" title="Delete"">
                                    <i class="icon-cancel">
                                    </i>
                                </a>
                            </td>
                        </tr>
                    `
                }

                $("#content").append(fila);
                /* tablet = */
                $("#datatable_plug").DataTable();

                /* Aún corregir para que funcione
                             $.each(retorno, function(key, value) {
                                 fila += '<tr Class="table table-success" style="text-align:left ;"> ';
                                 fila += '<td>' + value.categoriaID + '</td> ';
                                 fila += '<td>' + value.descripcion + '</td> ';
                                 fila += '<td>' + value.activo + '</td> ';
                                 fila += '<td> <a href="/edit.html?CategoriaID=' + value.categoriaID + '" class="btn btn-outline-info text-uppercase font-weight-bold mr-2"><i class="icon-edit"></i>Editar</a>';
                                 fila += '<a href="javascript:deletefunction(' + value.categoriaID + ')" class="btn btn-outline-danger text-uppercase font-weight-bold ml-2"><i class="icon-cancel"></i>Eliminar</a></td></tr>';
                             }); */
                /* console.log(retorno); */

                // console.log( arrayRetorno)

                // usando la funciona map: recorre un array y retorna otro array dependiendo del return del contenido
                // la comilla especial ``: template string, sirve para crear contenidos sin concatenar para mostrar / interpretar se usa un caracter espacial ${}
                /* const table = arrayRetorno.map((element) => {
                                 return `<tr Class="table table-success" style="text-align:left;">
                                     <td> ${element.categoriaID}</td>
                                     <td> ${element['descripcion']}</td>
                                     <td> ${element['activo']}</td>
                                     <td> <a href="/edit.html?categoriaID= ${element['categoriaID']} " class="btn btn-outline-info text-uppercase font-weight-bold mr-2"><i class="icon-edit"></i>Editar</a>
                                     <a href="javascript:deletefunction( ${element['categoriaID']} )" class="btn btn-outline-danger text-uppercase font-weight-bold ml-2"><i class="icon-cancel"></i>Eliminar</a></td></tr>
                                 `
                             }) */

                // for in : recorre un objeto y array
                // for (const key in arrayRetorno) {
                //     const element = arrayRetorno[key];
                //     fila += `<tr Class="table table-success" style="text-align:left;">
                //         <td> ${element.categoriaID}</td>
                //         <td> ${element['descripcion']}</td>
                //         <td> ${element['activo']}</td>
                //         <td> <a href="/edit.html?categoriaID= ${element['categoriaID']} " class="btn btn-outline-info text-uppercase font-weight-bold mr-2"><i class="icon-edit"></i>Editar</a>
                //         <a href="javascript:deletefunction( ${element['categoriaID']} )" class="btn btn-outline-danger text-uppercase font-weight-bold ml-2"><i class="icon-cancel"></i>Eliminar</a></td>
                //      </tr>
                //     `;
                // }
                //console.log(fila);
                //  $('#content').html('');
                // $('#content').append(fila);
            }
            /* location.reload(); */
        },
        error: function() {
            alert("se ha producido un error");
        },
        alert: function() {
            alert(retorno);
        },
    });
    //}
}