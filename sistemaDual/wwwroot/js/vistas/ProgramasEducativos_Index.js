//
const MODEL_BASE = {
    programaEducativoID: 0,
    nombreP: "",
    version: "",
    universidadID: ""
}

let tableData;
$(document).ready(function () {
    //Mostrar Universidades
    fetch("/ProgramasEducativos/ListaUniversidades")
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
            "url": '/ProgramasEducativos/Lista',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "programaEducativoID", "visible": false, "searchable": false },
            { "data": "nombreP" },
            { "data": "version" },
            { "data": "nombreU" },
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
                filename: 'Reporte Programas Educativos',
                exportOptions: {
                    columns: [1, 2, 3]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});


function mostrarModal(modelo = MODEL_BASE) {
    $("#txtProgramaEducativoID").val(modelo.programaEducativoID)
    $("#txtNombreP").val(modelo.nombreP)
    $("#txtVersion").val(modelo.version)
    $("#cboUniversidad").val(modelo.universidadID == "" ? $("#cboUniversidad option:first").val() : modelo.universidadID)
    $("#modalData").modal("show")
}


$("#btnNuevo").click(function () {
    mostrarModal()
})


//
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
    modelo["programaEducativoID"] = parseInt($("#txtProgramaEducativoID").val())
    modelo["nombreP"] = $("#txtNombreP").val()
    modelo["version"] = $("#txtVersion").val()
    modelo["universidadID"] = $("#cboUniversidad").val()


    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.programaEducativoID == 0) {
        //Registrar Programa
        fetch("/ProgramasEducativos/Crear", {
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
                    swal("Correcto", "PE registrado", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    } else {
        //Editar Mentor
        fetch("/ProgramasEducativos/Editar", {
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
        text: `Eliminar PE "${data.nombreP}"`,
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
                fetch(`/ProgramasEducativos/Eliminar?ProgramaEducativoID=${data.programaEducativoID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "Programa Eliminado", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})