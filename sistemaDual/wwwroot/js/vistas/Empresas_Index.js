//
const MODEL_DATA = {
    empresaID: "",
    razonS: "",
    nombreC: "",
    sectorS: "",
    representanteL: "",
    correoR: "",
    domicilioID: 0,
    direccion: ""
}


//
let tableData
$(document).ready(function () {
    tableData = $('#tbdata').DataTable({
        responsive: true,
         "ajax": {
             "url": '/Empresas/Lista',
             "type": "GET",
             "datatype": "json"
         },
         "columns": [
             { "data": "empresaID" },
             { "data": "razonS" },
             { "data": "nombreC" },
             { "data": "sectorS" },
             { "data": "representanteL" },
             { "data": "correoR" },
             { "data": "domicilioID", "visible": false, "searchable": false },
             { "data": "direccion"},
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
})

//
function mostrarModal(modelo = MODEL_DATA) {
    $("#txtEmpresaID").val(modelo.empresaID)
    $("#txtRazonS").val(modelo.razonS)
    $("#txtNombreC").val(modelo.nombreC)
    $("#txtSectorS").val(modelo.sectorS)
    $("#txtRepresentanteL").val(modelo.representanteL)
    $("#txtCorreoR").val(modelo.correoR)
    $("#txtDomicilioID").val(modelo.domicilioID)
    $("#txtDireccion").val(modelo.direccion)
    $("#modalData").modal("show")
}

$("#btnNuevo").click(function () {
    mostrarModal()
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

    const modelo = structuredClone(MODEL_DATA);
    modelo["empresaID"] = $("#txtEmpresaID").val()
    modelo["razonS"] = $("#txtRazonS").val()
    modelo["nombreC"] = $("#txtNombreC").val()
    modelo["sectorS"] = $("#txtSectorS").val()
    modelo["representanteL"] = $("#txtRepresentanteL").val()
    modelo["correoR"] = $("#txtCorreoR").val()
    modelo["domicilioID"] = parseInt($("#txtDomicilioID").val())
    modelo["direccion"] = $("#txtDireccion").val()

    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    if (modelo.domicilioID == 0) {
        //
        fetch("/Empresas/Crear", {
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
                    swal("Correcto", "Unidad Empresarial Registrada", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })
    //
    } else {
        fetch("/Empresas/Editar", {
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
                    $("#modalData").modal("hide")
                    swal("Correcto", "Empresa actualizada", "success")
                } else {
                    swal("Problema", responseJson.mensaje, "error")
                }
            })

    }
})


//
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
        text: `Eliminar UE "${data.nombreC}"`,
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
                fetch(`/Empresas/Eliminar?EmpresaID=${data.empresaID}`, {
                    method: "DELETE"
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {
                            tableData.row(fila).remove().draw()
                            swal("Correcto", "UE retirada", "success")
                        } else {
                            swal("Problema", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})