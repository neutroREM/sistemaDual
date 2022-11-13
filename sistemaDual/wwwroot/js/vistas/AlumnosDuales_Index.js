﻿
//Modelado de los datos del Estudiante
const MODEL_BASE = {
    alumnoDualID: "",
    matricula: "",
    nombre: "",
    apellidoP: "",
    apellidoM: "",
    telefono: "",
    correo: "",
    rolID: 0,
    fechaRegistro: "",
    esActivo: 1,
}


let tableData;
$(document).ready(function () {
    //Mostrar Roles
    fetch("/AlumnosDuales/ListaRoles")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboRol").append(
                        $("<option>").val(item.rolID).text(item.descripcion)
                    )
                })
            }
        })
    //Mostrar Estudiantes
    tableData = $('#tbdata').DataTable({
        responsive: true,
         "ajax": {
             "url": 'AlumnosDuales/Lista',
             "type": "GET",
             "datatype": "json"
         },
         "columns": [
             { "data": "alumnoDualID" },
             { "data": "matricula" },
             { "data": "nombre" },
             { "data": "apellidoP" },
             { "data": "apellidoM" },
             { "data": "telefono" },
             { "data": "correo" },
             { "data": "descripcion" },
             { "data": "fechaRegistro" },
             {
                 "data": "esActivo", render: function (data) {
                     if (data == 1)
                         return '<span class="badge badge-info">Activo</span>';
                     else
                         return '<span class="badge badge-danger">No activo</span>';
                 }
             },
             {
                 "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
                     '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
                 "orderable": false,
                 "searchable": false,
                 "width": "80px"
             }
         ],
         order: [[0, "desc"]],
        dom: "Bfrtip",
        buttons: [
            {
                text: 'Exportar Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Reporte Usuarios',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});



function mostrarModal(modelo = MODEL_BASE) {
    $("#txtAlumnoDualID").val(modelo.alumnoDualID)
    $("#txtMatricula").val(modelo.matricula)
    $("#txtNombre").val(modelo.nombre)
    $("#txtApellidoP").val(modelo.apellidoP)
    $("#txtApellidoM").val(modelo.apellidoM)
    $("#txtTelefono").val(modelo.telefono)
    $("#txtCorreo").val(modelo.correo)
    $("#cboRol").val(modelo.rolID == 0 ? $("#cboRol option:first").val() : modelo.rolID)
    $("#txtFechaRegistro").val(modelo.fechaRegistro)
    $("#cboEstado").val(modelo.esActivo)
    $("#modalData").modal("show")
}

$("#btnNuevo").click(function () {
    mostrarModal()
})

$("#btnGuardar").click(function () {


    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

    if (inputs_sin_valor.length > 0) {
        const mensaje = `Debe completar el campo : "${inputs_sin_valor[0].name}"`;
        toastr.warning("", mensaje)
        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
        return;
    }

    const modelo = structuredClone(MODEL_BASE);
    modelo["alumnoDualID"] = $("#txtAlumnoDualID").val()
    modelo["matricula"] = $("#txtMatricula").val()
    modelo["nombre"] = $("#txtNombre").val()
    modelo["apellidoP"] = $("#txtApellidoP").val()
    modelo["apellidoM"] = $("#txtApellidoM").val()
    modelo["telefono"] = $("#txtTelefono").val()  
    modelo["correo"] = $("#txtCorreo").val()
    modelo["rolID"] = $("#cboRol").val()
    modelo["fechaRegistro"] = $("#txtFechaRegistro").val()
    modelo["esActivo"] = $("#cboEstado").val()


    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show"); 

    if (modelo.alumnoDualID != null) {
        //Registrar Estudiante
        fetch("/AlumnosDuales/Create", {
            method: "POST",
            body: formData
        })
            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide");
                return response.ok ? response.json() : Promise.reject(response);
            })
            .then(responseJson => {
                if (responseJson.estado) {
                    tableData.row.add(responseJson.objeto).draw(false)
                    $("#modalData").modal("hide")
                    swal("Correcto", "Estudiante registrado", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    } else {
        //Editar Estudiante
        fetch("/AlumnosDuales/Editar", {
            method: "PUT",
            body: formData
        })
            .then(response => {
                $("#modalData").find("div.modal-content").LoadingOverlay("hide");
                return response.ok ? response.json() : Promise.reject(response);
            })
            .then(responseJson => {
                if (responseJson.estado) {
                    tableData.row(selectFila).data(responseJson.objeto).draw(false);
                    selectFila = null;
                    $("#modalData").modal("hide")
                    swal("Correcto", "Datos actualizados", "success")
                } else {
                    swal("Problema", "Datos no modificados", "Error")
                }
            })
    }
})

//Mostrar modal con datos del Estudiante
let selectFila;
$("#tbdata tbody").on("click", ".btn-editar", function () {

    //Seleccionar responsivamente el boton
    if ($(this).closest("tr").hasClass("child")) {
        selectFila = $(this).closest("tr").prev();
    } else {
        selectFila = $(this).closest("tr");
    }
    const data = tableData.row(selectFila).data();
    mostrarModal(data);
})



//Eliminar Estudiante
$("#tbdata tbody").on("click", ".btn-eliminar", function () {

    let fila;
    //Seleccionar responsivamente el boton
    if ($(this).closest("tr").hasClass("child")) {
        fila = $(this).closest("tr").prev();
    } else {
        fila = $(this).closest("tr");
    }
    const data = tableData.row(fila).data();

    swal({
        title: "¿Realizar Acción?",
        text: `Eliminar Estudiante "${data.nombre}"`,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (respuesta) {
            if (respuesta) {
                $(".showSweetAlert").LoadingOverlay("show");
                fetch(`/AlumnosDuales/Eliminar?AlumnoDualID=${data.alumnoDualID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "Estudiante eliminado", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})