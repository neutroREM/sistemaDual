const MODEL_BASE = {
    alumnoDualID: "",
    matricula: "",
    nombre: "",
    apellidoP: "",
    apellidoM: "",
    telefono: "",
    correo: "",
    cuatrimestre: "",
    tipo: "",
    promedio: "",
    fechaRegistro: "",
    esActivo: "",
    programaEducativoID: "",
    rolID: "",
    domicilioID: "",
    estatusID: "",
    becaDualID:""
}

let table;

$(document).ready(function () {

    fetch("/AlumnosDuales/ListaRoles")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboRolID").append(
                        $("<option>").val(item.rolID).text(item.descripcion)
                    )
                })
            }
        })

    $('#tbdata').DataTable({
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
             { "data": "cuatrimestre" },
             { "data": "tipo" },
             { "data": "promedio" },
             { "data": "fechaRegistro" },
             {
                 "data": "esActivo", render: function (data) {
                     if (data == 1)
                         return '<span class="badge badge-info">Activo</span>';
                     else
                         return '<span class="badge badge-info">No activo</span>';
                 }
             },
             { "data": "programaEducativoID" },
             { "data": "rolID" },
             { "data": "domicilioID" },
             { "data": "estatusID" },
             { "data": "becaDualID" },
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
    $("#txtCuatrimestre").val(modelo.cuatrimestre)
    $("#txtTipo").val(modelo.tipo)
    $("#txtPromedio").val(modelo.promedio)
    $("#txtFechaRegistro").val(modelo.fechaRegistro)
    $("#cboEstado").val(modelo.esActivo)
    $("#txtProgramaEducativoID").val(modelo.programaEducativoID)
    $("#cboRolID").val(modelo.rolID == 0 ? $("#cboRolID option.first").val() : modelo.rolID)
    $("#txtDomicilioID").val(modelo.domicilioID)
    $("#txtEstatusID").val(modelo.estatusID)
    $("#txtBecaDualID").val(modelo.becaDualID)

    $("#modalData").modal("show")
}

$("#btnNuevo").click(function () {
    mostrarModal()
})

$("#btnGuardar").click(function () {

    debugger;
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
    modelo["cuatrimestre"] = $("#txtCuatrimestre").val()
    modelo["tipo"] = $("#txtTipo").val()
    modelo["promedio"] = $("#txtPromedio").val()
    modelo["fechaRegistro"] = $("#txtFechaRegistro").val()
    modelo["esActivo"] = $("#cboEstado").val()
    modelo["ProgramaEducativoID"] = $("#txtProgramaEducativoID").val()
    modelo["rolID"] = $("#cboRolID").val()
    modelo["domicilioID"] = $("#txtDomicilioID").val()
    modelo["estatusID"] = $("#txtEstatusID").val()
    modelo["becaDualID"] = $("#txtBecaDualID").val()

    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $("#modalData").find("div.modal-content").LoadingOverlay("show"); 

    if (modelo.alumnoDualID == 0) {

        fetch("AlumnosDuales/Create", {
            method: "POST",
            body: formData
        })
            .then(response => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide"); 
            return response.ok ? response.json() : Promise.reject(response);
            })
            .then(reponseJson => {
                if (reponseJson.estado) {
                    table.row.add(responseJson.objeto).draw(false)
                    $("#modalData").modal("hide")
                    swal("Listo!", "Estudiante Registrado", "success")
                } else {
                    swal("NoCompletado!", "Estudiante No Registrado", "error")
                }
            })

    }
})