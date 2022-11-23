

$(document).ready(function () {
    fetch("/CatalagoProyectos/ListaProgramas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboProgramaE").append(
                        $("<option>").val(item.programaEducativoID).text(item.nombreP)
                    )
                })
            }
        })

    fetch("/CatalagoProyectos/ListaAsesores")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboAsesorI").append(
                        $("<option>").val(item.asesorInstitucionalID).text(item.nombreA)
                    )
                })
            }
        })

    fetch("/CatalagoProyectos/ListaResponsables")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboResponsableI").append(
                        $("<option>").val(item.responsableInstitucionalID).text(item.nombreR)
                    )
                })
            }
        })

    $("#cboBuscarEstudiante").select2({
        ajax: {
            url: "/CatalagoProyectos/ObtenerAlumnos",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            delay: 250,
            data: function (params) {
                return {
                    busqueda: params.term
                };
            },
            processResults: function (data,) {
                return {
                    results: data.map((item) => (
                        {
                            id: item.alumnoDualID,
                            text: item.curp,

                            nombreA: item.nombreA,
                            telefono: item.telefono,
                            esActivo: item.esActivo
                        }
                    ))
                };
            },
        },
        language: "es",
        placeholder: 'Buscar Estudiante',
        minimumInputLength: 1,
        templateResult: formatoEstudiante
    });

    $("#cboBuscarEmpresa").select2({
        ajax: {
            url: "/CatalagoProyectos/ObtenerEmpresas",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            delay: 250,
            data: function (params) {
                return {
                    busqueda: params.term
                };
            },
            processResults: function (data,) {
                return {
                    results: data.map((item) => (
                        {
                            id: item.empresaID,
                            text: item.rfc,

                            razonS: item.sectorS,
                            nombreC: item.nombreC,
                            sectorS: item.razonS,
                            representanteL: item.representanteL
                        }
                    ))
                };
            },
        },
        language:"es",
        placeholder: 'Buscar Empresa',
        minimumInputLength: 1,
        templateResult: formatoEmpresas
    });
})



function formatoEstudiante(data) {
    if (data.loading)
        return data.text;

    var contenedor = $(
        `<table width="100%">
            <tr>
                <td>
                   <p style="margin:2px">${data.nombreA}</p>
                   <p style="margin:2px">${data.telefono}</p>
                   <p style="margin:2px">${data.esActivo}</p>
                   <p style="font-weight: bolder;margin:2px">${data.text}</p> 
                </td>
            </tr>
        </table>`
    );
    return contenedor;
}

function formatoEmpresas(data) {
    if (data.loading)
        return data.text;

    var contenedor = $(
        `<table width="100%">
            <tr>
                <td>
                   <p style="margin:2px">${data.sectorS}</p>
                   <p style="margin:2px">${data.nombreC}</p>
                   <p style="margin:2px">${data.razonS}</p>
                   <p style="font-weight: bolder;margin:2px">${data.text}</p> 
                </td>
            </tr>
        </table>`
    );
    return contenedor;
}


$(document).on("select2:open", function () {
    document.querySelector(".select2-search__field").focus();
})


let estudianteDatos = [];
$("#cboBuscarEstudiante").on("select2:select", function (e) {
    const data = e.params.data;

    let estudiante_encontrado = estudianteDatos.filter(p => p.alumnoDualID == data.id)
    if (estudiante_encontrado.length > 0) {
        $("#cboBuscarEstudiante").val("").trigger("change")
        toastr.warning("", "El estudiante ya fue selecionado")
        return false
    }

    swal({
        title: "aaaqqw",
        text: "asignar este Estudiante",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (valor) {


            let estudiante = {
                alumnoDualID: data.id,
                curp: data.text,
                nombreA: data.nombreA,
                telefono: data.telefono,
                esActivo: data.esActivo
            }
            estudianteDatos.push(estudiante)

            mostrarEstudiante_Datos();

            $("#cboBuscarEstudiante").val("").trigger("change")
            swal.close()
        }
    )

})


///
let empresasProyecto = [];
$("#cboBuscarEmpresa").on("select2:select", function (e) {
    const data = e.params.data;

    let empresa_encontrada = empresasProyecto.filter(p => p.empresaID == data.id)
    if (empresa_encontrada.length > 0) {
        $("#cboBuscarEmpresa").val("").trigger("change")
        toastr.warning("", "La empresa ya fue selecionada")
        return false
    }

    swal({
        title: data.razonS,
        text: "asignar esta UE",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (valor) {


            let empresa = {
                empresaID: data.id,
                sectorS: data.sectorS,
                nombreC: data.nombreC,
                razonS: data.razonS,
                representanteL: data.representanteL
            }
            empresasProyecto.push(empresa)

            mostrarEmpresa_Datos();

            $("#cboBuscarEmpresa").val("").trigger("change")
            swal.close()
        }
    )
    
})


function mostrarEmpresa_Datos() {

    $("#tbEmpresa tbody").html("")

    empresasProyecto.forEach((item) => {
        $("#tbEmpresa tbody").append(
            $("<tr>").append(
                $("<td>").append(
                    $("<button>").addClass("btn btn-danger btn-eliminar btn-sm").append(
                        $("<i>").addClass("fas fa-trash-alt")
                    ).data("empresaID", item.empresaID)
                ),
                $("<td>").text(item.sectorS),
                $("<td>").text(item.nombreC),
                $("<td>").text(item.razonS),
                $("<td>").text(item.representanteL)
            )
        )
    })


}

function mostrarEstudiante_Datos() {

    $("#tbEstudiante tbody").html("")

    estudianteDatos.forEach((item) => {
        $("#tbEstudiante tbody").append(
            $("<tr>").append(
                $("<td>").append(
                    $("<button>").addClass("btn btn-danger btn-eliminar btn-sm").append(
                        $("<i>").addClass("fas fa-trash-alt")
                    ).data("alumnoDualID", item.alumnoDualID)
                ),
                $("<td>").text(item.curp),
                $("<td>").text(item.nombreA),
                $("<td>").text(item.telefono),
                $("<td>").text(item.esActivo)
            )
        )
    })


}

$(document).on("click", "button.btn-eliminar", function () {

    const _empresaID = $(this).data("empresaID")


    empresasProyecto = empresasProyecto.filter(p => p.empresaID != _empresaID);
    mostrarEmpresa_Datos();
})


$(document).on("click", "button.btn-eliminar", function () {

    const _alumnoDualID = $(this).data("alumnoDualID")

    estudianteDatos = estudianteDatos.filter(a => a.alumnoDualID != _alumnoDualID);
    mostrarEstudiante_Datos();
})

$("#btnAsignarProyecto").click(function () {


    if (empresasProyecto.length < 1) {
        toastr.warning("", "Debe ingresar una empresa")
        return;
    }

    const entidad =
    {
 
        programaEducativoID: $("#cboProgramaE").val()

    }

    $("#btnAsignarProyecto").LoadingOverlay("show");

    fetch("/CatalagoProyectos/RegistrarProyecto", {
        method: "POST",
        headers: { 'Content-Type': 'application/json', 'charset': 'utf-8' },
        body: JSON.stringify(entidad)
    })
        .then(response => {
            $("#btnAsignarProyecto").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {

                swal("Asginado", `Numero Proyecto: ${responseJson.objeto.numeroProyecto}`, "success")
            } else {
                swal("No asignado", "no", "error")
            }
        })
})