const MODEL_BASE = {
    responsableInstitucionalID: 0,
    curp: "",
    nombreR: "",
    apellidoP: "",
    apellidoM: "",
    correo: "",
    telefono: "",
    cargo: "",
    universidadID: 0,
}


let tableData;
$(document).ready(function () {
    //Mostrar PE
    fetch("/ResponsablesInstitucionales/ListaUniversidades")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboUniversidad").append(
                        $("<option>").val(item.universidadID).text(item.nombreU)
                    )
                })
            }
        })
    //Mostrar Mentores
    tableData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": '/ResponsablesInstitucionales/Lista',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "responsableInstitucionalID", "visible": false, "searchable": false },
            { "data": "curp" },
            { "data": "nombreR" },
            { "data": "apellidoP" },
            { "data": "apellidoM" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "cargo" },
            { "data": "nombreU"},
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
                filename: 'Reporte Responsables Institucionales',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});


function mostrarModal(modelo = MODEL_BASE) {
    $("#txtResponsableInstitucionalID").val(modelo.responsableInstitucionalID)
    $("#txtCurp").val(modelo.curp)
    $("#txtNombreR").val(modelo.nombreR)
    $("#txtApellidoP").val(modelo.apellidoP)
    $("#txtApellidoM").val(modelo.apellidoM)
    $("#txtCorreo").val(modelo.correo)
    $("#txtTelefono").val(modelo.telefono)
    $("#txtCargo").val(modelo.cargo)
    $("#cboUniversidad").val(modelo.universidadID == 0 ? $("#cboUniversidad option:first").val() : modelo.universidadID)
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
    modelo["responsableInstitucionalID"] = parseInt($("#txtResponsableInstitucionalID").val())
    modelo["curp"] = $("#txtCurp").val()
    modelo["nombreR"] = $("#txtNombreR").val()
    modelo["apellidoP"] = $("#txtApellidoP").val()
    modelo["apellidoM"] = $("#txtApellidoM").val()
    modelo["correo"] = $("#txtCorreo").val()
    modelo["telefono"] = $("#txtTelefono").val()
    modelo["cargo"] = $("#txtCargo").val()
    modelo["universidadID"] = $("#cboUniversidad").val()


    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.responsableInstitucionalID == 0) {
        //Registrar Mentor
        fetch("/ResponsablesInstitucionales/Crear", {
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
                    swal("Correcto", "Responsable Registrado", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    } else {
        //Editar Mentor
        fetch("/ResponsablesInstitucionales/GuardarCambios", {
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
                    swal("Problema", responseJson.mensaje, "Error")
                }
            })
    }

})


//Mostrar modal con datos del Mentor
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


//Eliminar Mentor
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
        text: `¿Eliminar Responsable?"${data.nombreR}"`,
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
                fetch(`/ResponsablesInstitucionales/Eliminar?ResponsableInstitucionalID=${data.responsableInstitucionalID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "Responsable Eliminado", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})
