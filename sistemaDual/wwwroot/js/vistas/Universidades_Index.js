
const MODEL_BASE = {
    universidadID: "",
    nombreU: "",
    domicilioID: 0,
    direccion: "",
    colonia: "",
    municipio: "",
    codigoPostal: "",
    otros: "",
}


let tableData;
$(document).ready(function () {
    tableData = $('#tbdata').DataTable({
        responsive: true,
         "ajax": {
             "url": '/Universidades/Lista',
             "type": "GET",
             "datatype": "json"
         },
        "columns": [
             { "data": "universidadID" },
             { "data": "nombreU" },
             { "data": "domicilioID","visible":false,"searchable":false },
             { "data": "direccion" },
             { "data": "municipio" },
             { "data": "colonia" },
             { "data": "codigoPostal" },
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
                    columns: [1, 2]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});

function mostrarModal(modelo = MODEL_BASE) {
    $("#txtDomicilioID").val(modelo.domicilioID)
    $("#txtUniversidadID").val(modelo.universidadID)
    $("#txtNombreU").val(modelo.nombreU)
    $("#txtDireccion").val(modelo.direccion)
    $("#txtColonia").val(modelo.colonia)
    $("#txtMunicipio").val(modelo.municipio)
    $("#txtCodigoPostal").val(modelo.codigoPostal)
    $("#txtOtros").val(modelo.otros)
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
    modelo["universidadID"] = $("#txtUniversidadID").val()
    modelo["nombreU"] = $("#txtNombreU").val()
    modelo["domicilioID"] = parseInt($("#txtDomicilioID").val())
    modelo["direccion"] = $("#txtDireccion").val()
    modelo["colonia"] = $("#txtColonia").val()
    modelo["municipio"] = $("#txtMunicipio").val()
    modelo["codigoPostal"] = $("#txtCodigoPostal").val()
    modelo["otros"] = $("#txtOtros").val()

    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.domicilioID == 0) {
        //Crear
        fetch("/Universidades/Crear", {
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
                    swal("Correcto", "Universidad Registrada", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
        //Editar
    } else {
        fetch("/Universidades/Editar", {
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
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    }
})

let selectFila;
$("#tbdata tbody").on("click",".btn-editar", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectFila = $(this).closest("tr").prev();
    } else {
        selectFila = $(this).closest("tr");
    }
    const data = tableData.row(selectFila).data();
    //console.log(data)
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
        text: `Eliminar Universidad "${data.nombre}"`,
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
                fetch(`/Universidades/Eliminar?UniversidadID=${data.universidadID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "uni remove", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})