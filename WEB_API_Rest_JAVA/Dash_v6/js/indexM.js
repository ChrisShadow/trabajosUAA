/* Plugin */
$(document).ready(function() {
    cargardatos();
});

// modal agregar 
function agregar() {
    $("#form").modal("show");
    $('#form-content').html("Cargando...")
    $.get('./modalAgregar.html')
        .then((data) => {
            $('#form-content').html(data)

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
        const id = $('#marcaID').val()
        url = 'http://localhost:4567/marca/actualizar/' + id
        type = "put"
    } else if (tipo == 'agregar') {
        url = 'http://localhost:4567/marca/agregar' //https://rest-soft1.herokuapp.com
        type = "post"
    }

    const nombre = $('#nombre').val();
    /* Date fechaFundacion = fechaFundacion.parse($('#fecha').val();) */
    const fechaFundacion = $('#fecha').val();
    const diasCancelacion = $('#dias').val();
    const motivoCancelacion = $('#motivo').val();
    const guardarAuditoria = $('#sino').val();
    const data = { nombre: nombre, fechaFundacion: fechaFundacion, motivoCancelacion: motivoCancelacion, diasCancelacion: diasCancelacion, guardarAuditoria: guardarAuditoria }

    console.log(fechaFundacion)
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
    const id = obj.marcaID
    const nombre = obj.nombre
    const fechaFundacion = obj.fechaFundacion
    const diasCancelacion = obj.diasCancelacion
    const motivoCancelacion = obj.motivoCancelacion
    const guardarAuditoria = obj.guardarAuditoria

    $("#form").modal("show");
    $('#form-content').html("Cargando...")

    $.get('./modalEdit.html')
        .then((data) => {
            // console.log(data)
            $('#form-content').html(data)
            $('#marcaID').val(id)
            $('#nombre').val(nombre)
            $('#fecha').val(fechaFundacion)
            $('#dias').val(diasCancelacion)
            $('#motivo').val(motivoCancelacion)
            $('#sino').val(guardarAuditoria)
        })
        .fail((error) => {
            console.log(error)
        })
}

/* Eliminar */
function eliminar() {
    const id = $("#marcaID").val();
    $.ajax({
        url: "http://localhost:4567/marca/eliminar/" + id, //https://rest-soft1.herokuapp.com
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
}

function deletefunction(id) {
    $("#marcaID").val(id);
    $("#delete").modal("show");
}

/* Tuplas */
function cargardatos() {
    $("#content").html("");
    var cuerpoCat = document.getElementById("content");
    var fila = "";
    $.ajax({
        url: "http://localhost:4567/marcas", //http://localhost:4567/marcas
        data: {},
        type: "GET",
        dateType: "JSON",
        success: function(retorno) {
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
                            <td>${ element.marcaID }</td>
                            <td>${ element["nombre"] }</td>
                            <td>${ element["fechaFundacion"]}</td>
                            <td>${ element["diasCancelacion"] }</td>
                            <td>${ element["motivoCancelacion"]}</td>
                            <td>${ element["guardarAuditoria"] }</td>
                            <td> 
                                <button data-json='${ JSON.stringify(element) }' onclick="editarCampo(this)" class="editarCampo btn btn-outline-info mx-2 my-2 data-toggle="tooltip" data-placement="bottom" title="Edit"">
                                    <i class="icon-edit"></i>
                                </button>
                                <a href="javascript:deletefunction(${ element["marcaID"] })" class="btn btn-outline-danger  mx-2 my-2 data-toggle="tooltip" data-placement="bottom" title="Delete"">
                                    <i class="icon-cancel">
                                    </i>
                                </a>
                            </td>
                        </tr>
                    `
                }

                $("#content").append(fila);
                $("#datatable_plug").DataTable();

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
}