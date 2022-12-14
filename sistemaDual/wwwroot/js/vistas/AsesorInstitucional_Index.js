
const MODEL_BASE = {
    asesorInstitucionalID: 0,
    curp: "",
    nombreA: "",
    apellidoP: "",
    apellidoM: "",
    correo: "",
    telefono: "",
    programaEducativoID: 0,
}


let tableData;
$(document).ready(function () {
    //Mostrar PE
    fetch("/AsesoresInstitucionales/ListaProgramas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboPrograma").append(
                        $("<option>").val(item.programaEducativoID).text(item.nombreP)
                    )
                })
            }
        })
    //Mostrar Mentores
    tableData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": '/AsesoresInstitucionales/Lista',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "asesorInstitucionalID", "visible": false, "searchable": false },
            { "data": "curp" },
            { "data": "nombreA" },
            { "data": "apellidoP" },
            { "data": "apellidoM" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "nombreP" },
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
                filename: 'Reporte de Asesores Institucionales',
                exportOptions: {
                    columns: [1,2,3,4,5,6,7]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
})


function mostrarModal(modelo = MODEL_BASE) {
    $("#txtAsesorInstitucionalID").val(modelo.asesorInstitucionalID)
    $("#txtCurp").val(modelo.curp)
    $("#txtNombreA").val(modelo.nombreA)
    $("#txtApellidoP").val(modelo.apellidoP)
    $("#txtApellidoM").val(modelo.apellidoM)
    $("#txtCorreo").val(modelo.correo)
    $("#txtTelefono").val(modelo.telefono)
    $("#cboPrograma").val(modelo.programaEducativoID == 0 ? $("#cboPrograma option:first").val() : modelo.programaEducativoID)
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
    modelo["asesorInstitucionalID"] = parseInt($("#txtAsesorInstitucionalID").val())
    modelo["curp"] = $("#txtCurp").val()
    modelo["nombreA"] = $("#txtNombreA").val()
    modelo["apellidoP"] = $("#txtApellidoP").val()
    modelo["apellidoM"] = $("#txtApellidoM").val()
    modelo["correo"] = $("#txtCorreo").val()
    modelo["telefono"] = $("#txtTelefono").val()
    modelo["cargo"] = $("#txtCargo").val()
    modelo["programaEducativoID"] = $("#cboPrograma").val()


    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.asesorInstitucionalID == 0) {
        //Registrar Mentor
        fetch("/AsesoresInstitucionales/Crear", {
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
                    swal("Correcto", "Asesor Registrado", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    } else {
        //Editar Mentor
        fetch("/AsesoresInstitucionales/GuardarCambios", {
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
        text: `¿Eliminar Asesor?"${data.nombreA}"`,
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
                fetch(`/AsesoresInstitucionales/Eliminar?AsesorInstitucionalID=${data.asesorInstitucionalID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "Asesor Eliminado", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})













